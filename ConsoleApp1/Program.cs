namespace ConsoleApp1
{
    public class Program
    {
        private static int _age;

        public static int Age
        {
            get { return _age; }
            set
            {
                _age = 10;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            _age = 20;
            Console.WriteLine($"年龄:{Age}");

            Age = 20;
            Console.WriteLine($"年龄:{Age}");

            Console.ReadLine();
        }
    }
}
