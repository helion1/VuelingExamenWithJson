using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Application.Dto {
    public class ClientDto {
        public ClientDto(){
        }

        public ClientDto(string id, string name, string email, string role) {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
  
    }
}
