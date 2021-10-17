using System.Text.Json.Serialization;
using System.Text.Json;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;

namespace HelpWanted.Models
{
    public class Project
    {
        public static Project ProjectToView;

        [BsonId]
        public Guid id {get; set;}
        
        [JsonPropertyName("user")]
        public static string UserName {get; set;}

        public string Name;
        
        [JsonPropertyName("projName")]
        public string ProjectName {get; set;}
        
        [JsonPropertyName("projDesc")]
        public string ProjectDescription {get; set;}
        
        [JsonPropertyName("helpType")]
        public Enums.HelpTypes HelpType {get; set;}
        
        [JsonPropertyName("helpWanted")]
        public string HelpWanted {get; set;}

        [JsonPropertyName("helpSkills")]
        public string[] HelpSkills {get; set;}

        [JsonPropertyName("teamMembers")] 
        public string[] TeamMembers {get; set;}

        [JsonPropertyName("percentFinished")]
        public Enums.Progress Progress {get; set;}

        public Project()
        {

        }


        public Project(string _name, string projectName, string projectDescription, string helpWanted, string[] helpSkills, Enums.HelpTypes helpType, string[] teamMembers, Enums.Progress progress)
        {
            Name = _name;
            ProjectName = projectName!= null ? projectName : "";
            ProjectDescription = projectDescription!= null ? projectDescription : "";
            HelpWanted = helpWanted!= null ? helpWanted : "";
            HelpType = helpType;
            TeamMembers = teamMembers!= null ? teamMembers : new string[0];
            Progress = progress;
            HelpSkills = helpSkills!= null ? HelpSkills : new string[0];
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Project>(this);
        }
    }
}