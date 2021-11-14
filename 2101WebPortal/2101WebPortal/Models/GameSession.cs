using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Models
{
    public class GameSession
    {
        [DisplayName("Session ID")]
        [Required(ErrorMessage = "Please enter a session ID")]
        public int Id { get; set; }
        [DisplayName("Challenge ID")]
        [Required(ErrorMessage = "Please enter a Challenge ID")]
        public int ChallengeId { get; set; }
        [DisplayName("Access Code")]
        [Required(ErrorMessage = "Please enter an Access code")]
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
