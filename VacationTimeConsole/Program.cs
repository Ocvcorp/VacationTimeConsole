using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationTimeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Конечные даты
            DateTime firstDay;
            DateTime finishDay;

            Console.WriteLine("****Vacation period****");         
            if (FormattedDate("first",out firstDay) && FormattedDate("finish", out finishDay))
            {
                if (firstDay<=finishDay)//если даты введены последовательно
                {
                    Console.WriteLine("Your vacation period will be {0} day(s)",
                                        finishDay.AddDays(1).Subtract(firstDay).Days);
                }
                else//если вводимый первый день оказался по дате позже последнего дня
                {
                    Console.WriteLine("Chronological mistake. Last day can't be earlier than first day");
                }               
            }
            else
                Console.WriteLine("Proccess skipped");


            Console.WriteLine("Program finishes. Press any key to quit");
            Console.ReadKey();
        }
        
        static bool FormattedDate(string dayPoint, out DateTime date)// функция проверки формата даты и извлечения даты из строки
        {
            bool isCorrectFormat=false;
            ConsoleKey key;                     
            do 
            {
                Console.WriteLine("Input a "+dayPoint+" day date like dd:mm:yyyy"); 
                try//разбор строки
                {
                    date=DateTime.Parse(Console.ReadLine());
                    isCorrectFormat = true;
                    break;
                }
                catch (Exception e)//исключение если месяцы и номер дня не соответствуют календарю
                {
                    Console.WriteLine(e.Message);
                }               
                date = DateTime.Now;//"резервное" присвоение для параметра out
                Console.WriteLine("Incorrect Date or Date Format. To try again press any key, or 'Esc' to quit");
                key=Console.ReadKey().Key;//считывание решения пользователя
            } while (key != ConsoleKey.Escape);
            return isCorrectFormat;
        }
    }
}
