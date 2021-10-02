using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using HelpWanted.Models;
using Microsoft.AspNetCore.Hosting;

namespace HelpWanted.Services
{
    public class JsonToProjectService
    {
        public IWebHostEnvironment WebHostEnvironment { get;}
        
        public JsonToProjectService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get {return Path.Combine(WebHostEnvironment.WebRootPath, "data", "projects.json");}
        }

        public IEnumerable<Project> GetProjects()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Project[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }
    }
}