using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Models
{
    public class Facilitator
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsSystemAdmin { get; set; }
    }
}
