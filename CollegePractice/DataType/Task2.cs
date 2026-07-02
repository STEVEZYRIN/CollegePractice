using System;
using System.Collections.Generic;
using System.Text;

namespace CollegePractice.DataType
{
    internal class Task2
    {
        /// <summary>
        /// Функция, которая выводит на экран ромб (диамант) из символов X.
        /// </summary>
        /// <param name="N"> Длина каждой диоганали (положительное нечётное целое число). </param>
        public static string DrawRhombus(int N)
        {

            if (N <= 0)
                throw new ArgumentOutOfRangeException(nameof(N), "Число должно быть положительным");
            if (N % 2 == 0)
                throw new ArgumentException("Число должно быть нечетным", nameof(N));

            var result = new StringBuilder();
            int center = N / 2;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int distance = Math.Abs(i - center) + Math.Abs(j - center);
                    result.Append(distance == center ? "X" : " ");
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
