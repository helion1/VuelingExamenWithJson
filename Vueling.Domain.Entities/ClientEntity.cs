using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Domain.Entities {
    public class ClientEntity  {
        
        public ClientEntity() {
        }

        public ClientEntity(string id, string name, string email, string role) {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}
