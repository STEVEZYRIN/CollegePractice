using System;
using System.Collections.Generic;
using System.Text;

namespace CollegePractice.DataType
{
    public static class Task1
    {
        /// <summary>
        /// Функция, которая формирует и возвращает строку с расчетом сложных процентов по годам.
        /// </summary>
        /// <param name="initialDeposit"> Начальный вклад (положительное число). </param>
        /// <param name="years"> Количество лет (положительное целое число). </param>
        /// <param name="interestRate"> Годовая процентная ставка (положительное число). </param>
        /// <returns> Строка, где для каждого года расчета указана сумма накоплений, округленная до 2 знаков после запятой. </returns>
        public static string CompoundInterst(float initialDeposit, uint years, float interestRate)
        {
            if (initialDeposit <= 0)
                return "Начальный депозит должен быть положительным числом.";
            if (interestRate < 0)
                return "Процентная ставка не может быть отрицательной.";

            var result = new StringBuilder();
            interestRate = 1f + (interestRate / 100);

            for (int i = 0; i < years; i++)
            {
                initialDeposit *= interestRate;
                result.AppendLine($"Год {i}: {initialDeposit:F2} руб");
            }

            return result.ToString();
        }
    }
}