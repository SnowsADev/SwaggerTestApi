using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestProject_Swagger.Models
{
    public class TeamMember
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }

        public TeamMember(int id) : this(id, "onbekend", "onbekend") { }

        public TeamMember(int id, string naam, string email)
        {
            this.ID = id;
            this.Name = naam;
            this.Email = email;
        }
    }
}
