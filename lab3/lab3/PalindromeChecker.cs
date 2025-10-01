using System;
using System.Linq;

namespace lab3
{
    public class PalindromeChecker
    {
        public bool IsPalindrome(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Введений рядок не може бути порожнім");

            string normalized = NormalizeString(input);

            if (normalized.Length == 0)
                throw new ArgumentException("Рядок не містить літер або цифр");

            // Перевірка на паліндром
            for (int i = 0; i < normalized.Length / 2; i++)
            {
                if (normalized[i] != normalized[normalized.Length - 1 - i])
                    return false;
            }

            return true;
        }

        public string GetNormalizedString(string input)
        {
            return NormalizeString(input);
        }

        private string NormalizeString(string input)
        {
            // Видаляємо всі символи, крім літер та цифр, і перетворюємо в нижній регістр
            return new string(input
                .ToLower()
                .Where(c => char.IsLetterOrDigit(c))
                .ToArray());
        }
    }
}