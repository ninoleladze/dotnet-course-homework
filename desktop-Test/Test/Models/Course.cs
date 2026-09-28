namespace Test.Models
{
    public class Course
    {
        private static int _count = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Course()
        {
            Id = _count++;
        }

        public override string ToString()
        {
            return $"Id={Id}, Title={Title}, Description={Description}";
        }
    }
}