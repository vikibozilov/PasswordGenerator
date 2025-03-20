using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добре дошли в генератора на пароли!");

            // Въвеждаме желаната дължина на паролата
            Console.Write("Въведи дължината на паролата: ");
            int length = int.Parse(Console.ReadLine());

            // Избираме дали да включваме специални символи
            Console.Write("Искаш ли да включиш специални символи (y/n): ");
            bool includeSpecialChars = Console.ReadLine().ToLower() == "y";

            // Генерираме паролата
            string password = GeneratePassword(length, includeSpecialChars);

            // Извеждаме паролата
            Console.WriteLine("Генерираната парола е: " + password);
        }

        static string GeneratePassword(int length, bool includeSpecialChars)
        {
            // Символи, които ще се използват за паролата
            string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            // Обединяваме всички възможни символи
            string allChars = lowerChars + upperChars + digits;

            // Ако потребителят иска специални символи, добавяме ги към възможните символи
            if (includeSpecialChars)
            {
                allChars += specialChars;
            }

            // Създаваме обект за случайни числа
            Random random = new Random();

            // Строим паролата
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                // Генерираме случайни символи от възможните
                password[i] = allChars[random.Next(allChars.Length)];
            }

            // Връщаме генерираната парола като низ
            return new string(password);
        }
    }
}
