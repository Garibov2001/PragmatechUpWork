using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_CoreMVC.UI;
using pragmatechUpWork_CoreMVC.UI.IdentityClasses;
using pragmatechUpWork_CoreMVC.UI.Models;
using pragmatechUpWork_Entities;
using pragmatechUpWork_GeneralLayer.Enums;
using pragmatechUpWork_NotificationServices.Abstract;
using pragmatechUpWork_NotificationServices.General;

namespace pragmatechUpWork.Controllers
{
    public class TaskController : Controller
    {
        private readonly IUnitOfWork unitofWork = null;
        private UserManager<ApplicationUser> userManager { get; set; }
        private IEmailService emailService;
        private IHostingEnvironment hostingEnvironment { get; set; }

        public TaskController(
            IUnitOfWork _unitofWork,
            UserManager<ApplicationUser> _userManager,
            IEmailService _emailService,
            IHostingEnvironment _hostingEnvironment)
        {
            unitofWork = _unitofWork;
            userManager = _userManager;
            emailService = _emailService;
            hostingEnvironment = _hostingEnvironment;
        }

        [Authorize()]
        [HttpGet]
        [Route("/profile/tasks", Name = "profile-whole_tasks")]
        public async Task<IActionResult> ProfileTasks()
        {
            //Active Page
            ViewBag.TasksPage = true;

            var currentUser = await userManager.GetUserAsync(User);
            var roles = await userManager.GetRolesAsync(currentUser);
            var model = new AllProjectTasksWithOthers();

            if (roles.Contains(UserRolesEnum.Müəllim.ToString()))
            {
                var projectTasks = await unitofWork.ProjectTasks.GetAll();

                if (projectTasks.Any())
                {
                    foreach (var projectTask in projectTasks)
                    {
                        projectTask.Project = await unitofWork.Projects.GetProjectByID(projectTask.ProjectId);
                    }
                }

                model.projecttasks = projectTasks;
            }
            else
            {
                var appliedTasks = await unitofWork.AplliedTasks.GetAppliedTasksByUserID(currentUser.Id);

                if (appliedTasks.Any())
                {
                    foreach (var appliedTask in appliedTasks)
                    {
                        appliedTask.Task = await unitofWork.ProjectTasks.GetTasksByID(appliedTask.TaskID);
                        appliedTask.Task.Project = await unitofWork.Projects.GetProjectByID(appliedTask.Task.ProjectId);
                    }
                }

                model.appliedTasks = appliedTasks;
            }

            return View("profile_tasks", model);
        }

        [Authorize()]
        [HttpGet]
        [Route("/tasks", Name = "task-whole_task")]
        public async Task<IActionResult> WholeTasks()
        {

            var projectTasks = await unitofWork.ProjectTasks.GetAllDescending();

            if (projectTasks.Any())
            {
                foreach (var projectTask in projectTasks)
                {
                    projectTask.Project = await unitofWork.Projects.GetProjectByID(projectTask.ProjectId);
                }
            }

            var model = new AllProjectTasksWithOthers()
            {
                projecttasks = projectTasks
            };
            return View("whole_tasks", model);
        }


        #region Task Milestones

        [HttpGet]
        [Route("/profile/task/{task_id}/milestones", Name = "task-profile_milestones")]
        public async Task<IActionResult> TaskMilestones(int task_id)
        {
            var projectTask = await unitofWork.ProjectTasks.GetTasksByID(task_id);
            //var model = new TaskMilestonesWithOthers
            //{

            //}

            return View("task_milestones", projectTask);
        }


        [HttpGet]
        [Route("/profile/task/{task_id}/milestone/add", Name = "task-profile_milestone-add")]
        public async Task<IActionResult> AddTaskMilestone(int task_id)
        {
            var projectTask = await unitofWork.ProjectTasks.GetTasksByID(task_id);

            return View("task_milestone_add");
        }


        [HttpGet]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/edit", Name = "task-profile_milestone-edit")]
        public async Task<IActionResult> EditTaskMilestone(int task_id, int milestone_id)
        {
            return View("task_milestone_edit");
        }

        [HttpPost]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/remove", Name = "task-profile_milestone-remove")]
        public async Task<IActionResult> RemoveTaskMilestones(int task_id, int milestone_id)
        {
            return View("task_milestone");
        }

        [HttpGet]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/proofs", Name = "task-profile_milestone-proofs")]
        public async Task<IActionResult> TaskMilestoneProofs(int? task_id, int? milestone_id)
        {
            //Query string is empty or not
            if (task_id == null || milestone_id == null) return NotFound();

            var project_task = await unitofWork.ProjectTasks.GetTasksByID(task_id.GetValueOrDefault());
            //Task exists or not
            if (project_task == null) return NotFound();

            var task_milestone = await unitofWork.TaskMilestones.GetTaskMilestoneByID(milestone_id.GetValueOrDefault());
            //Milestone exist or not
            if (task_milestone == null) return NotFound();

            //Milestone belongs to Task or not
            if (task_milestone.ProjectTaskId != task_id) return NotFound();

            var confirmedTask = await unitofWork.AplliedTasks.GetConfirmedByTaskID(project_task.TaskId);
            // If task doesn't have confirmed
            if (confirmedTask == null) return NotFound();

            // Get the info of requested user:
            var currentUser = await userManager.GetUserAsync(User);
            var roles = await userManager.GetRolesAsync(currentUser);


            if (roles.Contains(UserRolesEnum.Müəllim.ToString()))
            {
                ViewBag.ProjectManager = true;
            }
            else
            {
                // Only owner can see its proofs
                if (confirmedTask.UserID != currentUser.Id)
                {
                    return NotFound();
                }

                ViewBag.ProjectManager = false;
            }



            var model = new AllProjectTaskMilestoneProofsWithOthers
            {
                user = await userManager.FindByIdAsync(confirmedTask.UserID),
                task = project_task,
                project = await unitofWork.Projects.GetProjectByID(project_task.ProjectId),
                taskMilestone = task_milestone,
                milestoneProofs = await unitofWork.TaskMilestoneProofs.GetProofsByMilestoneID(task_milestone.ID)
            };

            return View("task_milestone_proofs", model);

        }


        [HttpGet]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/proof/add", Name = "task-profile_milestone-proof-add")]
        public async Task<IActionResult> TaskMilestoneProofAdd(int? task_id, int? milestone_id)
        {
            //Query string is empty or not
            if (task_id == null || milestone_id == null) return NotFound();

            var project_task = await unitofWork.ProjectTasks.GetTasksByID(task_id.GetValueOrDefault());
            //Task exists or not
            if (project_task == null) return NotFound();

            var task_milestone = await unitofWork.TaskMilestones.GetTaskMilestoneByID(milestone_id.GetValueOrDefault());
            //Milestone exist or not
            if (task_milestone == null) return NotFound();

            //Milestone belongs to Task or not
            if (task_milestone.ProjectTaskId != task_id) return NotFound();

            var confirmedTask = await unitofWork.AplliedTasks.GetConfirmedByTaskID(project_task.TaskId);
            // If task doesn't have confirmed
            if (confirmedTask == null) return NotFound();


            var model = new ProjectTaskMilestoneProofWithOthers
            {
                user = await userManager.FindByIdAsync(confirmedTask.UserID),
                task = project_task,
                project = await unitofWork.Projects.GetProjectByID(project_task.ProjectId),
                taskMilestone = task_milestone,
                milestoneProof = new ProjectTaskMilestoneProof()
            };


            return View("task_milestone_proof_add", model);
        }

        [HttpPost]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/proof/add", Name = "task-profile_milestone-proof-add")]
        public async Task<IActionResult> TaskMilestoneProofAdd(int? task_id, int? milestone_id,
            ProjectTaskMilestoneProofWithOthers client_data)
        {
            //Query string is empty or not
            if (task_id == null || milestone_id == null) return NotFound();

            var project_task = await unitofWork.ProjectTasks.GetTasksByID(task_id.GetValueOrDefault());
            //Task exists or not
            if (project_task == null) return NotFound();

            var task_milestone = await unitofWork.TaskMilestones.GetTaskMilestoneByID(milestone_id.GetValueOrDefault());
            //Milestone exist or not
            if (task_milestone == null) return NotFound();

            //Milestone belongs to Task or not
            if (task_milestone.ProjectTaskId != task_id) return NotFound();

            var confirmedTask = await unitofWork.AplliedTasks.GetConfirmedByTaskID(project_task.TaskId);
            // If task doesn't have confirmed
            if (confirmedTask == null) return NotFound();

            var model = new ProjectTaskMilestoneProofWithOthers
            {
                user = await userManager.FindByIdAsync(confirmedTask.UserID),
                task = project_task,
                project = await unitofWork.Projects.GetProjectByID(project_task.ProjectId),
                taskMilestone = task_milestone,
                milestoneProof = new ProjectTaskMilestoneProof()
            };



            if (!ModelState.IsValid)
            {

                return View("task_milestone_proof_add", model);
            }



            // get current root folder and combine it with needed folder
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images", "proof-images");
            // get unique name for our image
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + client_data.Image.FileName;
            // combine folder with image name
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            // upload image to server
            await client_data.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));

            var proof = new ProjectTaskMilestoneProof
            {
                ProofContent = client_data.milestoneProof.ProofContent,
                ProofImagePath = uniqueFileName,
                MilestoneId = task_milestone.ID
            };

            await unitofWork.TaskMilestoneProofs.Add(proof);

            return RedirectToRoute("task-profile_milestone-proofs", new { task_id = task_id.GetValueOrDefault(), milestone_id = milestone_id.GetValueOrDefault() });
        }


        [HttpGet]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/proof/{proof_id}/edit", Name = "task-profile_milestone-proof-edit")]
        public async Task<IActionResult> TaskMilestoneProofEdit(int? task_id, int? milestone_id, int? proof_id)
        {
            //Query string is empty or not
            if (task_id == null || milestone_id == null || proof_id == null) return NotFound();

            var project_task = await unitofWork.ProjectTasks.GetTasksByID(task_id.GetValueOrDefault());
            //Task exists or not
            if (project_task == null) return NotFound();

            var task_milestone = await unitofWork.TaskMilestones.GetTaskMilestoneByID(milestone_id.GetValueOrDefault());
            //Milestone exist or not
            if (task_milestone == null) return NotFound();

            var milestone_proof = await unitofWork.TaskMilestoneProofs.GetTaskMilestoneProofByID(proof_id.GetValueOrDefault());
            //Proof exist or not
            if (milestone_proof == null) return NotFound();

            //Milestone belongs to Task or not
            if (task_milestone.ProjectTaskId != task_id) return NotFound();

            //Proof belongs to Milestone or not
            if (milestone_proof.MilestoneId != task_milestone.ID) return NotFound();

            var confirmedTask = await unitofWork.AplliedTasks.GetConfirmedByTaskID(project_task.TaskId);

            // If task doesn't have confirmed
            if (confirmedTask == null) return NotFound();

            var user = userManager.GetUserAsync(User);

            // Current user is proof's owner or not
            if (confirmedTask.UserID != user.Result.Id) return NotFound();

            var model = new MilestoneProofEditViewModel
            {
                task = project_task,
                project = await unitofWork.Projects.GetProjectByID(project_task.ProjectId),
                taskMilestone = task_milestone,
                milestoneProof = milestone_proof,
            };

            return View("task_milestone_proof_edit", model);
        }

        [HttpPost]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/proof/{proof_id}/edit", Name = "task-profile_milestone-proof-edit")]
        public async Task<IActionResult> TaskMilestoneProofEdit(int? task_id, int? milestone_id, int? proof_id,
            MilestoneProofEditViewModel client_data)
        {
            //Query string is empty or not
            if (task_id == null || milestone_id == null || proof_id == null) return NotFound();

            var project_task = await unitofWork.ProjectTasks.GetTasksByID(task_id.GetValueOrDefault());
            //Task exists or not
            if (project_task == null) return NotFound();

            var task_milestone = await unitofWork.TaskMilestones.GetTaskMilestoneByID(milestone_id.GetValueOrDefault());
            //Milestone exist or not
            if (task_milestone == null) return NotFound();


            var milestone_proof = await unitofWork.TaskMilestoneProofs.GetTaskMilestoneProofByID(proof_id.GetValueOrDefault());
            //Proof exist or not
            if (milestone_proof == null) return NotFound();

            //Milestone belongs to Task or not
            if (task_milestone.ProjectTaskId != task_id) return NotFound();

            //Proof belongs to Milestone or not
            if (milestone_proof.MilestoneId != task_milestone.ID) return NotFound();

            var confirmedTask = await unitofWork.AplliedTasks.GetConfirmedByTaskID(project_task.TaskId);
            // If task doesn't have confirmed
            if (confirmedTask == null) return NotFound();

            var user = userManager.GetUserAsync(User);

            // Current user is proof's owner or not
            if (confirmedTask.UserID != user.Result.Id) return NotFound();


            var model = new MilestoneProofEditViewModel
            {
                task = project_task,
                project = await unitofWork.Projects.GetProjectByID(project_task.ProjectId),
                taskMilestone = task_milestone,
                milestoneProof = milestone_proof,
            };

            if (!ModelState.IsValid)
            {
                return View("task_milestone_proof_edit", model);
            }

            // Image is not edited
            if (client_data.Image == null)
            {
                client_data.milestoneProof.ProofImagePath = milestone_proof.ProofImagePath;
                client_data.milestoneProof.Milestone = task_milestone;

                await unitofWork.TaskMilestoneProofs.Update(client_data.milestoneProof);
            }
            //Image edited
            else
            {
                // get current root folder and combine it with needed folder
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images", "proof-images");
                // get unique name for our image
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + client_data.Image.FileName;
                // combine folder with image name
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // upload image to server
                await client_data.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));

                client_data.milestoneProof.ProofImagePath = uniqueFileName;
                client_data.milestoneProof.Milestone = task_milestone;


                await unitofWork.TaskMilestoneProofs.Update(client_data.milestoneProof);

            }

            return RedirectToRoute("task-profile_milestone-proofs", new { task_id = task_id.GetValueOrDefault(), milestone_id = milestone_id.GetValueOrDefault() });
        }


        [HttpDelete]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/proof/{proof_id}/remove", Name = "task-profile_milestone-proof-remove")]
        public async Task<IActionResult> TaskMilestoneProofRemove(int? task_id, int? milestone_id, int? proof_id)
        {
            //Query string is empty or not
            if (task_id == null || milestone_id == null || proof_id == null) return NotFound();

            var project_task = await unitofWork.ProjectTasks.GetTasksByID(task_id.GetValueOrDefault());
            //Task exists or not
            if (project_task == null) return NotFound();

            var task_milestone = await unitofWork.TaskMilestones.GetTaskMilestoneByID(milestone_id.GetValueOrDefault());
            //Milestone exist or not
            if (task_milestone == null) return NotFound();

            var milestone_proof = await unitofWork.TaskMilestoneProofs.GetTaskMilestoneProofByID(proof_id.GetValueOrDefault());
            //Proof exist or not
            if (milestone_proof == null) return NotFound();

            //Milestone belongs to Task or not
            if (task_milestone.ProjectTaskId != task_id) return NotFound();

            //Proof belongs to Milestone or not
            if (milestone_proof.MilestoneId != task_milestone.ID) return NotFound();

            var confirmedTask = await unitofWork.AplliedTasks.GetConfirmedByTaskID(project_task.TaskId);

            // If task doesn't have confirmed
            if (confirmedTask == null) return NotFound();

            var user = userManager.GetUserAsync(User);

            // Current user is proof's owner or not
            if (confirmedTask.UserID != user.Result.Id) return NotFound();

            var resut = await unitofWork.TaskMilestoneProofs.Delete(proof_id.GetValueOrDefault());

            if (resut)
            {
                return Json(new { error = "none" });
            }

            return Json(new { error = "exist" });
        }


        // Task owner sends proof for confirmation
        [HttpPost]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/apply", Name = "task-profile_milestone-proof-apply")]
        public async Task<IActionResult> TaskMilestoneApply(int? task_id, int? milestone_id)
        {
            //Query string is empty or not
            if (task_id == null || milestone_id == null) return NotFound();

            var project_task = await unitofWork.ProjectTasks.GetTasksByID(task_id.GetValueOrDefault());
            //Task exists or not
            if (project_task == null) return NotFound();

            var task_milestone = await unitofWork.TaskMilestones.GetTaskMilestoneByID(milestone_id.GetValueOrDefault());
            //Milestone exist or not
            if (task_milestone == null) return NotFound();

            //Milestone belongs to Task or not
            if (task_milestone.ProjectTaskId != task_id) return NotFound();
            
            var confirmedTask = await unitofWork.AplliedTasks.GetConfirmedByTaskID(project_task.TaskId);
            // If task doesn't have confirmed
            if (confirmedTask == null) return NotFound();


            // Get the info of requested user:
            var currentUser = await userManager.GetUserAsync(User);
  
            // Only owner can send for apply
            if (confirmedTask.UserID != currentUser.Id)
            {
                return NotFound();
            }


            task_milestone.Status = (int)MilestoneStatus.TesdiqlenmeyiGozleyir;
            await unitofWork.TaskMilestones.Update(task_milestone);

            return RedirectToRoute("task-profile_milestone-proofs", new { task_id = task_id.GetValueOrDefault(), milestone_id = milestone_id.GetValueOrDefault() });
        }


        // Project Manger accepts proof for milestone
        [HttpPost]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/accept", Name = "task-profile_milestone-proof-accept")]
        public async Task<IActionResult> TaskMilestoneAcceptApply(int? task_id, int? milestone_id,
            AllProjectTaskMilestoneProofsWithOthers client_data)
        {
            //Query string is empty or not
            if (task_id == null || milestone_id == null) return NotFound();

            var project_task = await unitofWork.ProjectTasks.GetTasksByID(task_id.GetValueOrDefault());
            //Task exists or not
            if (project_task == null) return NotFound();

            var task_milestone = await unitofWork.TaskMilestones.GetTaskMilestoneByID(milestone_id.GetValueOrDefault());
            //Milestone exist or not
            if (task_milestone == null) return NotFound();

            //Milestone belongs to Task or not
            if (task_milestone.ProjectTaskId != task_id) return NotFound();

            var confirmedTask = await unitofWork.AplliedTasks.GetConfirmedByTaskID(project_task.TaskId);
            // If task doesn't have confirmed
            if (confirmedTask == null) return NotFound();


            // Get the info of requested user:
            var currentUser = await userManager.GetUserAsync(User);
            var roles = await userManager.GetRolesAsync(currentUser);

            // Only project manager can send accept apply
            if (!roles.Contains(UserRolesEnum.Müəllim.ToString()))
            {
                return NotFound();            
            }


            string subject = "Pragmatech sübut Qəbulu";
            string body = $"Task: {project_task.Name}\nMilestone: {task_milestone.Name}\nProject Managerin sözü: {client_data.Message}";
            string targetEmail = userManager.FindByIdAsync(confirmedTask.UserID).Result.Email;
            var message = new Message(
                new string[] { $"{targetEmail}" }, subject, body);
            emailService.SendEmail(message);

            
            task_milestone.Status = (int)MilestoneStatus.Tamamlanib;
            await unitofWork.TaskMilestones.Update(task_milestone);

            return RedirectToRoute("task-profile_milestone-proofs", new { task_id = task_id.GetValueOrDefault(), milestone_id = milestone_id.GetValueOrDefault() });
        }


        // Project Manger rejects proof for milestone
        [HttpPost]
        [Route("/profile/task/{task_id}/milestone/{milestone_id}/reject", Name = "task-profile_milestone-proof-reject")]
        public async Task<IActionResult> TaskMilestoneRejectApply(int? task_id, int? milestone_id,
            AllProjectTaskMilestoneProofsWithOthers client_data)
        {
            //Query string is empty or not
            if (task_id == null || milestone_id == null) return NotFound();

            var project_task = await unitofWork.ProjectTasks.GetTasksByID(task_id.GetValueOrDefault());
            //Task exists or not
            if (project_task == null) return NotFound();

            var task_milestone = await unitofWork.TaskMilestones.GetTaskMilestoneByID(milestone_id.GetValueOrDefault());
            //Milestone exist or not
            if (task_milestone == null) return NotFound();

            //Milestone belongs to Task or not
            if (task_milestone.ProjectTaskId != task_id) return NotFound();

            var confirmedTask = await unitofWork.AplliedTasks.GetConfirmedByTaskID(project_task.TaskId);
            // If task doesn't have confirmed
            if (confirmedTask == null) return NotFound();


            // Get the info of requested user:
            var currentUser = await userManager.GetUserAsync(User);
            var roles = await userManager.GetRolesAsync(currentUser);

            // Only project manager can reject apply
            if (!roles.Contains(UserRolesEnum.Müəllim.ToString()))
            {
                return NotFound();
            }


            string subject = "Pragmatech sübut Qəbul olunmaması";
            string body = $"Task: {project_task.Name}\nMilestone: {task_milestone.Name}\nProject Managerin sözü: {client_data.Message}";
            string targetEmail = userManager.FindByIdAsync(confirmedTask.UserID).Result.Email;
            var message = new Message(
                new string[] { $"{targetEmail}" }, subject, body);
            emailService.SendEmail(message);


            task_milestone.Status = (int)MilestoneStatus.LegvEdilib;
            await unitofWork.TaskMilestones.Update(task_milestone);

            return RedirectToRoute("task-profile_milestone-proofs", new { task_id = task_id.GetValueOrDefault(), milestone_id = milestone_id.GetValueOrDefault() });
        }




        #endregion 




        //Elave olunacaq
        [Authorize()]
        [HttpGet]
        [Route("/applied/tasks", Name = "project-applied_task")]
        public async Task<IActionResult> AppliedTasks()
        {
            //Active Page
            ViewBag.ProjectsPage = true;

            var appliedTasks = await unitofWork.AplliedTasks.GetAppliedTasksByStatus(false);

            if (appliedTasks.Any())
            {
                foreach (var appliedTask in appliedTasks)
                {
                    appliedTask.Task = await unitofWork.ProjectTasks.GetTasksByID(appliedTask.TaskID);
                }
            }

            var model = new AllApliedTasksWithOthers()
            {
                appliedTasks = appliedTasks,
                appliedTask = new UserApplyAndConfirmTask()
            };
            return View("applied_tasks", model);
        }

        //Elave olunacaq
        [Authorize()]
        [HttpGet]
        [Route("/single_applied/tasks/{id}", Name = "single-applied_task")]
        public async Task<IActionResult> Single_AppliedTasks(int id)
        {
            var appliedTask = await unitofWork.AplliedTasks.GetAppliedTasksByID(id);

            if (appliedTask != null)
            {
                appliedTask.Task = await unitofWork.ProjectTasks.GetTasksByID(appliedTask.TaskID);
            }

            var model = new AppliedTaskWithOthers()
            {
                applyTask = appliedTask,
                user = userManager.FindByIdAsync(appliedTask.UserID).Result
            };
            return View("single_appliedtask", model);
        }

        //Elave olunacaq
        [Authorize()]
        [HttpPost]
        [Route("/confirmed/tasks", Name = "project-confirmed_task")]
        public async Task<IActionResult> ConfirmTask(AppliedTaskWithOthers appliedTask)
        {

            ProjectTask task = await unitofWork.ProjectTasks.GetTasksByID(appliedTask.applyTask.TaskID);

            appliedTask.applyTask.Task = task;
            appliedTask.applyTask.Status = true;

            var user = userManager.FindByIdAsync(appliedTask.applyTask.UserID).Result;

            bool result = await unitofWork.AplliedTasks.Update(appliedTask.applyTask);
            if (result == true)
            {
                EmailGonder(user.Email, user.Name, task.Name);
            }

            return RedirectToRoute("project-applied_task");
        }

        //Elave olunacaq
        private void EmailGonder(string targetEmail, string user, string taskName)
        {
            string subject = "Pragmatech Task Teklifi Qebulu";
            string body = string.Format("{0} bəy {1} taskı hakkındakı teklifiniz müdüriyyət tərəfindən qebul olundu.Taskı qeyd etdiyiniz vaxtda tehvil vermeyiniz xahis olunur.", user, taskName);
            var message = new Message(
                new string[] { $"{targetEmail}" }, subject, body);
            emailService.SendEmail(message);
        }

        [Authorize()]
        [HttpGet]
        [Route("/task/{id}", Name = "task-single_task")]
        public async Task<IActionResult> SingleTask(int id)
        {
            ProjectTask task = await unitofWork.ProjectTasks.GetTasksByID(id);
            var model = new ProjectTaskWithOther()
            {
                projectTask = task,
                project = await unitofWork.Projects.GetProjectByTask(task),
                appliedTask = new UserApplyAndConfirmTask()
            };

            return View("single_task", model);
        }


        [Authorize()]
        [HttpPost]
        [Route("/task/{id}", Name = "task-single_task")]
        public async Task<IActionResult> SingleTask(int id, UserApplyAndConfirmTask appliedTask)
        {
            ProjectTask task = await unitofWork.ProjectTasks.GetTasksByID(id);

            var model = new ProjectTaskWithOther()
            {
                projectTask = task,
                project = await unitofWork.Projects.GetProjectByTask(task),
                appliedTask = new UserApplyAndConfirmTask()

            };

            if (ModelState.IsValid)
            {
                appliedTask.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                appliedTask.TaskID = id;
                appliedTask.Task = task;
                appliedTask.ApplyDate = DateTime.Now;

                bool result = await unitofWork.AplliedTasks.Add(appliedTask);
                model.appliedTask = appliedTask;

                ViewBag.Success = true;
                return View("single_task", model);
            }
            else
            {
                return View("single_task", model);
            }
        }

        [Authorize()]
        [HttpGet]
        [Route("/task/create", Name = "task-create_task")]
        public async Task<IActionResult> CreateTask()
        {
            //Active Page
            ViewBag.TasksPage = true;

            var Projects = await unitofWork.Projects.GetAll();

            var model = new ProjectTaskWithOther()
            {
                projects = new SelectList(Projects, nameof(Project.ProjectId), nameof(Project.Name)),
                projectTask = new ProjectTask(),
            };
            ViewBag.ProjectTask = model.projects;

            return View("create_task", model);
        }

        [Authorize()]
        [HttpPost]
        [Route("/task/create", Name = "task-create_task")]
        public async Task<IActionResult> CreateTask(ProjectTaskWithOther client_post)
        {
            //Active Page
            ViewBag.TasksPage = true;

            if (ModelState.IsValid)
            {
                var project = await unitofWork.Projects.GetProjectByID(client_post.projectTask.ProjectId);
                client_post.projectTask.Project = project;
                client_post.projectTask.Status = 0;

                await unitofWork.ProjectTasks.Add(client_post.projectTask);

                return RedirectToRoute("profile-whole_tasks");
            }
            else
            {
                var Projects = await unitofWork.Projects.GetAll();

                var model = new ProjectTaskWithOther()
                {
                    projects = new SelectList(Projects, nameof(Project.ProjectId), nameof(Project.Name))
                };
                return View("create_task", model);
            }
        }

        [Authorize()]
        [HttpGet]
        [Route("/task/{id}/edit", Name = "task-edit_task")]
        public async Task<IActionResult> EditTask(int id)
        {
            //Active Page
            ViewBag.TasksPage = true;

            var projectTask = await unitofWork.ProjectTasks.GetTasksByID(id);

            if (projectTask != null)
            {
                projectTask.Project = await unitofWork.Projects.GetProjectByID(projectTask.ProjectId);
                var Projects = await unitofWork.Projects.GetAll();

                var model = new ProjectTaskWithOther()
                {
                    projects = new SelectList(Projects, nameof(Project.ProjectId), nameof(Project.Name), projectTask.ProjectId),
                    projectTask = projectTask
                };


                return View("edit_task", model);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize()]
        [HttpPost]
        [Route("/task/{id}/edit", Name = "task-edit_task")]
        public async Task<IActionResult> EditTask(int id, ProjectTaskWithOther client_data)
        {
            //Active Page
            ViewBag.TasksPage = true;

            if (ModelState.IsValid)
            {
                if (client_data == null)
                {
                    return NotFound();
                }
                else
                {
                    client_data.projectTask.Project = await unitofWork.Projects.GetProjectByID(client_data.projectTask.ProjectId);

                    await unitofWork.ProjectTasks.Update(client_data.projectTask);
                    return RedirectToRoute("profile-whole_tasks");
                }
            }
            else
            {
                var Projects = await unitofWork.Projects.GetAll();

                var model = new ProjectTaskWithOther()
                {
                    projects = new SelectList(Projects, nameof(Project.ProjectId), nameof(Project.Name), client_data.projectTask.ProjectId),
                };
                return View("edit_task", model);
            }
        }

        [Authorize()]
        [HttpDelete]
        [Route("/task/{id}/remove", Name = "task-remove_task")]
        public async Task<IActionResult> RemoveTask(int id)
        {
            var projecttask = await unitofWork.ProjectTasks.GetTasksByID(id);
            if (projecttask == null)
            {
                return NotFound();
            }
            else
            {
                await unitofWork.ProjectTasks.Delete(id);
            }
            var responseData = new
            {
                error = "none",
            };

            return Json(responseData);
        }




    }
}
