using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pragmatechUpWork.Data;
using pragmatechUpWork.Models;

namespace pragmatechUpWork.Utils
{
    public class ProjectUtility
    {
        // Bu bizim Dbe qosulmagimiz ucun lazim olacaq
        // readonly edirik cunki ctor icinde buna object menimsedeceyik 
        // yerde qalan hallard constant olacaq
        private readonly UpWrokDbConnections _context = null;
        public ProjectUtility(UpWrokDbConnections argContext)
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
                   
                };

                return bookDetails;
            }

            return null;
        }


    }
}
