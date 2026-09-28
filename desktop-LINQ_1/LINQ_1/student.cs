
namespace LINQ_1
{
    internal class Student
    {
        private static int _counter = 1;

        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public double Grade { get; set; }
        public string Group { get; set; } = string.Empty;

        public Student()
        {
            Id = _counter++;
        }

        public override string ToString() =>
            $"Id: {Id}, Name: {Name}, Age: {Age}, Grade: {Grade:F2}, Group: {Group}";
    }
}