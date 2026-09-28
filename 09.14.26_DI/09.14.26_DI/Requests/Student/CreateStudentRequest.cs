namespace _09._14._26_DI.Requests.Student
{
    public class CreateStudentRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string Minor { get; set; } = null!;
        public double GPA { get; set; }
    }
}
