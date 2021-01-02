using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pragmatechUpWork.Models;

namespace pragmatechUpWork.Utils
{
    public class Utilities
    {
        // Bu bizim Dbe qosulmagimiz ucun lazim olacaq
        // readonly edirik cunki ctor icinde buna object menimsedeceyik 
        // yerde qalan hallard constant olacaq
        private readonly DbConnections _context = null;
        public Utilities(DbConnections argContext)
        {
            _context = argContext;
        }


        public async Task<int> AddProject(Project client_data)
        {
            var newProject = new Project()
            {
                Name = client_data.Name,
                Category = client_data.Category,
                MinCost = client_data.MinCost,
                MaxCost = client_data.MaxCost,
                ProjectManager = "User Tesdir",
                StartDate = client_data.StartDate,
                EndDate = client_data.EndDate,
                GithubUrl = client_data.GithubUrl,
                ProjectInfo = client_data.ProjectInfo,
                Status = (int)ProjectStatus.Draft,
            };

            await _context.Project.AddAsync(newProject);
            await _context.SaveChangesAsync();

            return newProject.ProjectId;
        }

        public async Task<Project> GetProject(int id)
        {
            var project = await _context.Project.FindAsync(id);

            if (project != null)
            {
                var bookDetails = new Project()
                {
                    Name = project.Name,
                    Category = project.Category,
                    MinCost = project.MinCost,
                    MaxCost = project.MaxCost,
                    ProjectManager = project.ProjectManager,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    GithubUrl = project.GithubUrl,
                    ProjectInfo = project.ProjectInfo,
                    Status = project.Status,
                };

                return bookDetails;
            }

            return null;
        }

        public async Task<List<Project>> GetWholeProjects()
        {
            var wholeProject = await _context.Project.ToListAsync();

            if (wholeProject?.Any() == true)
            {
                List<Project> projectsDetails = new List<Project>();

                foreach (var project in wholeProject)
                {
                    projectsDetails.Add(new Project()
                    {
                        ProjectId = project.ProjectId,
                        Name = project.Name,
                        Category = project.Category,
                        MinCost = project.MinCost,
                        MaxCost = project.MaxCost,
                        ProjectManager = project.ProjectManager,
                        StartDate = project.StartDate,
                        EndDate = project.EndDate,
                        GithubUrl = project.GithubUrl,
                        ProjectInfo = project.ProjectInfo,
                        Status = project.Status,
                    });
                }

                return projectsDetails;
            }

            return null;
        }

        public async void EditProject(int id, Project editProject)
        {
            var dataFromDb = _context.Project.FirstOrDefault(e => e.ProjectId == id);
            if (dataFromDb == null)
            {
                return;
            }
            else
            {
                dataFromDb.Name = editProject.Name;
                dataFromDb.Category = editProject.Category;
                dataFromDb.MinCost = editProject.MinCost;
                dataFromDb.MaxCost = editProject.MaxCost;
                dataFromDb.StartDate = editProject.StartDate;
                dataFromDb.EndDate = editProject.EndDate;
                dataFromDb.GithubUrl = editProject.GithubUrl;
                dataFromDb.ProjectInfo = editProject.ProjectInfo;

                await _context.SaveChangesAsync();
            }


        }

        public void RemoveProject(int id)
        {
            var dataFromDb = _context.Project.FirstOrDefault(e => e.ProjectId == id);
            if (dataFromDb == null)
            {
                return;
            }
            else
            {
                _context.Project.Remove(dataFromDb);
                _context.SaveChanges();
            }

        }

    }
}
