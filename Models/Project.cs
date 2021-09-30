using System.Text.Json.Serialization;
using System.Text.Json;

namespace HelpWanted.Models
{
    public class Project
    {
        [JsonPropertyName("user")]
        public string Name {get; set;}
        [JsonPropertyName("project name")]
        public string ProjectName {get; set;}
        [JsonPropertyName("project description")]
        public string ProjectDescription {get; set;}
        [JsonPropertyName("help needed")]
        public string HelpNeeded {get; set;}

        public override string ToString()
        {
            return JsonSerializer.Serialize<Project>(this);
        }
    }
}