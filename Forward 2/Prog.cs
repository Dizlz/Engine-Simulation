using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward_2
{
    class Prog
    {
        static void Main()
        {

            //Вывод подробной информации
            Console.Write("Хотите видеть подробную информацию?(Напишите Yes/No. Может повлиять на скорость работы программы!) ");
            string More_Inf = Console.ReadLine();

            //Температура окружающей среды
            Console.Write("Температура окружающей среды: ");
            double T_Surrounding = Convert.ToDouble(Console.ReadLine());

            //Создание тестового стенда
            Test_Area test_area = new Test_Area();

            //Выбор двигателя
            Console.WriteLine("Какой двигатель тестировать?(Введите номер)\n1)Стандартный \n2)Форсированный");
            int engine_number =Convert.ToInt32( Console.ReadLine()); 

            //Тестирование
            Console.WriteLine(test_area.standart_test(T_Surrounding, More_Inf, engine_number));
            Console.ReadKey();
        }
    }
}
