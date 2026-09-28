namespace backnew111hm
{
    internal class Program
    {
        static void Main()
        {
            Person person = new Person();
            person.SayHello();

            Student student = new Student();

            student.SetAge(17);
            student.SayHello();
            student.Study();
            student.ShowAge();

            Teacher teacher = new Teacher();
            teacher.SetAge(30);
            teacher.SayHello();
            teacher.Explain();
            teacher.ShowAge();
        }
    }
}