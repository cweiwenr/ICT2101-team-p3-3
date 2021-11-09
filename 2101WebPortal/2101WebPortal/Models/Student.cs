using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vraze.Models
{
    public class Student
    {
        /// <summary>
        /// The internal id of the student entity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The tudent's marticulation number
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Student's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Stores whether the student has completed the tutorial challenge
        /// </summary>
        public bool HasCompletedTutorial { get; set; }
    }
}
