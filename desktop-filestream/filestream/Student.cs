
namespace filestream
{
    public class Student
    {
        private static int _counter = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }

        public Student() => Id = _counter++;

        public override string ToString()
        {
            return $"ID: {Id}, name: {Name}, age: {Age}, major: {Major}";
        }
    }
}