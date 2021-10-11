using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HelpWanted.Services;
using HelpWanted.Models;
using MongoDB.Driver;
namespace HelpWanted.Pages
{
    public class ViewProjectModel : PageModel
    {
        private readonly ILogger<ViewProjectModel> logger;
        public IEnumerable<Project> Projects {get; private set;}

        public ViewProjectModel(ILogger<ViewProjectModel> _logger)
        {
            logger = _logger;
        }

        public void OnGet()
        {
            MongoDBAccess db = new MongoDBAccess(MongoDBAccess.databaseName);
            Projects = db.GetItems<Project>(MongoDBAccess.databaseName);
        }
    }
}
