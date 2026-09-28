namespace _3._6._26.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<StudentCourses> StudentCourses { get; set; }



    }
}
