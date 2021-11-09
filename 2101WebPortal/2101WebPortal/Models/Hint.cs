using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Models
{
    public class Hint
    {
        public int Id { get; set; }
        public int ChallengeId { get; set; }
        public string HintInformation { get; set; }
    }
}
