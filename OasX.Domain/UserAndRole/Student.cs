using System.Collections.Generic;

namespace OasX.Domain
{
    public class Student : Member
    {
        public Student() {
            SubscribeCourses = new List<Course>();
        }

        public virtual ICollection<Course> SubscribeCourses { get; set; }

        public void Subscribe(Course course) {
            SubscribeCourses.Add(course);
        }
    }
}