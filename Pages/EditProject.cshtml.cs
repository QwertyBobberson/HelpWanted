using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HelpWanted.Models;

namespace HelpWanted.Pages
{
    public class EditProjectModel : PageModel
    {
        private readonly ILogger<EditProjectModel> _logger;

        public EditProjectModel(ILogger<EditProjectModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
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
