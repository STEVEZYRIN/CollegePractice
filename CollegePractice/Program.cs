using System;
using System.Numerics;
using CollegePractice.OOP;

namespace CollegePractice
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var rectangle = CreateRectangle();
                Test(rectangle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private static Rectangle CreateRectangle()
        {
            Console.WriteLine("Введите координаты левого верхнего угла");
            float x = Convert.ToSingle(Console.ReadLine());
            float y = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Введите размеры прямоугольника");
            var width = Convert.ToSingle(Console.ReadLine());
            var height = Convert.ToSingle(Console.ReadLine());

            return new Rectangle(new Vector2(x, y), width, height);
        }

        private static void Test(Rectangle rect)
        {
            Console.WriteLine("Исходное состояние");
            Console.WriteLine(rect);

            rect.Width = 8;
            rect.Height = 4;
            Console.WriteLine("После изменения размеров:");
            Console.WriteLine(rect);
            
            rect.Position = new Vector2(0, 0);
            Console.WriteLine("После перемещения в начало координат:");
            Console.WriteLine(rect);
            
            Console.WriteLine($"Периметр: {rect.Perimeter:F2}");
            Console.WriteLine($"лощадь: {rect.Area:F2}");
        }
    }
}