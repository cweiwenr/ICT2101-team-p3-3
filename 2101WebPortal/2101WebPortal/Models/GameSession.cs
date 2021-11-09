using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Models
{
    public class GameSession
    {
        public int Id { get; set; }
        public string AccessCode { get; set; }
        public DateTime SessionStartTime { get; set; }
        public DateTime SessionEndTime { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByFacilitatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Student> StudentList { get; set; }
    }
}
