using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace course.api.Models.Courses
{
    public class CourseViewModelInput
    {
        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required!")]
        public string Description { get; set; }
    }
}
