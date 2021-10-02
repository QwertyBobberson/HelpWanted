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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        public JsonToProjectService jsonToProjectService;
        public IEnumerable<Project> Projects {get; private set;}

        public IndexModel(
            ILogger<IndexModel> _logger,
            JsonToProjectService _jsonToProjectService
            )
        {
            logger = _logger;
            jsonToProjectService = _jsonToProjectService;
        }

        public void OnGet()
        {
            MongoDBAccess db = new MongoDBAccess("Projects");
            Projects = db.GetItems<Project>("Projects");
        }
    }
}
