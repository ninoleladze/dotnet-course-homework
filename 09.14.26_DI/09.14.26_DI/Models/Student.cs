namespace _09._14._26_DI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public double GPA { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;

    }
}
