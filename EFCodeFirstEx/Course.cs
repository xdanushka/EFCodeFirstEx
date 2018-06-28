using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

//multiple relationships
namespace EFCodeFirstEx
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        [ForeignKey("OnlineTeacher")]
        public Teacher OnlineTeacher { get; set; }

        [ForeignKey("ClassRoomTeacher")]
        public Teacher ClassRoomTeacher { get; set; }
    }

    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }

        //one teacher can have many courses
        [InverseProperty("OnlineTeaacher")]
        public ICollection<Course> OnlineCourses { get; set; }

        [InverseProperty("ClassRoomTeacher")]
        public ICollection<Course> ClassRoomCourses { get; set; }

    }
}
