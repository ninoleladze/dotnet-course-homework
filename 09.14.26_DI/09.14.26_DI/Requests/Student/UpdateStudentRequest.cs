namespace _09._14._26_DI.Requests.Student
{
    public class UpdateStudentRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Major { get; set; }
        public string? Minor { get; set; }
        public double? GPA { get; set; }
    }
}
