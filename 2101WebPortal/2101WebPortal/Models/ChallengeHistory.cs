using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Models
{
    public class ChallengeHistory
    {
        public int Id { get; set; }
        public int ChallengeId { get; set; }
        public int SessionId { get; set; }
        public int StudentId { get; set; }
        public string Solution { get; set; }
        public int Points { get; set; }
    }
}
