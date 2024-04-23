using System;
namespace TestingLR2
{
    public class MinDigit
    {
        public static int Minim(int a)
        {
            int min = a % 10;
            a /= 10;
            while (a != 0)
            {
                if (a % 10 < min)
                {
                    min = a % 10;
                }
                a /= 10;
            }
            return min;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число: ");
            int a = int.Parse(Console.ReadLine());
            while (a <= 0)
            {

                Console.WriteLine("Ошибка!!!");
                a = int.Parse(Console.ReadLine());

            }
            MinDigit min = new MinDigit();
            double s = MinDigit.Minim(a);
            Console.WriteLine("Минимальная цифра: " + s);
        }
    }
}