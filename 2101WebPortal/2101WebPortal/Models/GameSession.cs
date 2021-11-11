using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Models
{
    public class GameSession
    {
        [DisplayName("Session ID")]
        public int Id { get; set; }
        [DisplayName("Challenge ID")]
        public int ChallengeId { get; set; }
        [DisplayName("Access Code")]
        public string AccessCode { get; set; }
        public DateTime SessionStartTime { get; set; }
        public DateTime SessionEndTime { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByFacilitatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        [DisplayName("Student List")]
        public List<Student> StudentList { get; set; }
    }
}
