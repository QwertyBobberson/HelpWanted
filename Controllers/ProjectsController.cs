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
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            MongoDBAccess mongoDBAccess = new MongoDBAccess(MongoDBAccess.databaseName);
            return mongoDBAccess.GetItems<Project>(MongoDBAccess.databaseName);
        }
    }
}