using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpWanted.Models;
using HelpWanted.Services;
using System.Collections.Generic;
using System;

namespace HelpWanted.Controllers
{
    [Route("/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        public JsonToProjectService jsonToProjectsService {get;}

        public ProjectsController(JsonToProjectService _jsonToProjectService)
        {
            jsonToProjectsService = _jsonToProjectService;
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            MongoDBAccess mongoDBAccess = new MongoDBAccess("Projects");
            return mongoDBAccess.GetItems<Project>("Projects");
        }
    }
}