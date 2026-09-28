namespace _3._6._26.Models
{
    public class StudentCourses
    {
     
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
