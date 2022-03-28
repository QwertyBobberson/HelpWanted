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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace HelpWanted.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        public IEnumerable<Project> Projects {get; private set;}
        public string AccessToken {get; private set;}
        public string IdToken {get; private set;}

        public IndexModel(ILogger<IndexModel> _logger)
        {
            logger = _logger;
        }

        public void OnGet()
        {
            MongoDBAccess db = new MongoDBAccess(MongoDBAccess.databaseName);
            Projects = db.GetItems<Project>(MongoDBAccess.collectionName);


            foreach(var claim in User.Claims)
            {
                if(claim.Type == "preferred_username")
                {
                    Project.UserName = claim.Value;
                }
            }
        }
    }
}
