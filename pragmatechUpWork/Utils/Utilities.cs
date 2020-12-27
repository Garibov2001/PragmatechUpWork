using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pragmatechUpWork.Data;
using pragmatechUpWork.Models;

namespace pragmatechUpWork.Utils
{
    public class Utilities
    {
        // Bu bizim Dbe qosulmagimiz ucun lazim olacaq
        // readonly edirik cunki ctor icinde buna object menimsedeceyik 
        // yerde qalan hallard constant olacaq
        private readonly UpWrokDbConnections _context = null;
        public Utilities(UpWrokDbConnections argContext)
        {
            _context = argContext;
        }


        public async Task<int> AddProject(ProjectModel client_data)
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
                Status = (int)Status.Draft,
            };

            await _context.project.AddAsync(newProject);
            await _context.SaveChangesAsync();

            return newProject.Id;
        }

        public async Task<ProjectModel> GetProject(int id)
        {
            var project = await _context.project.FindAsync(id);

            if (project != null)
            {
                var bookDetails = new ProjectModel()
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

        public async Task<List<ProjectModel>> GetWholeProjects()
        {
            var wholeProject = await _context.project.ToListAsync();

            if (wholeProject?.Any() == true)
            {
                List<ProjectModel> projectsDetails = new List<ProjectModel>();

                foreach (var project in wholeProject)
                {
                    projectsDetails.Add(new ProjectModel()
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
                    });
                }

                return projectsDetails;
            }

            return null;
        }

    }
}
