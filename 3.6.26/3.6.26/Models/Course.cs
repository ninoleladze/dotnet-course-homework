namespace _3._6._26.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public List<StudentCourses> StudentCourses { get; set; }

    }
}
