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
        [BsonId]
        public Guid id;
        [JsonPropertyName("user")]
        public string Name {get; set;}
        [JsonPropertyName("projName")]
        public string ProjectName {get; set;}
        [JsonPropertyName("projDesc")]
        public string ProjectDescription {get; set;}
        [JsonPropertyName("helpWanted")]
        public string HelpNeeded {get; set;}

        public Project()
        {

        }

        public Project(string name, string projectName, string projectDescription, string helpNeeded)
        {
            Name = name;
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            HelpNeeded = helpNeeded;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Project>(this);
        }
    }
}