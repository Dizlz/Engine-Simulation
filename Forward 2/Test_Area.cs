using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward_2
{
    public class Test_Area
    {
        //Счетчик времени
        int Time;

        //Скорость коленвала
        float V_Speed;
       
        //Температура двигателя
        double T_Engine;
                             
        //Стандартный тест
        public string standart_test(double T_Surrounding, string More_Inf, int engine_number)
        {
            T_Engine = T_Surrounding;
            V_Speed = 0;            
            Time = 0;

            //Текущая зависимость M & V
            int j = 0;
            
            //Инициализация двигателя
            Engine engine= new Engine();
                        
            if (engine_number == 1 )
            {
                engine.standartengine();
            }
            else if (engine_number == 2)
            {
                engine.forcedengine();
            }
            else
            {
                return "Двигатель не найден";
            }
            
            //Запуск и тестирование
            while ((T_Engine < engine.T_Overheat) & (Time < 1000))
            {
               
                engine.start_engine(T_Surrounding, ref V_Speed, ref T_Engine, ref j );

                //Подсчет времени
                Time++;

                //Вывод дополнительной информации
                if (More_Inf == "Yes")
                {
                    Console.WriteLine("Время: " + Time);
                    Console.WriteLine("Температура двигателя: " + T_Engine);
                    Console.WriteLine("Скорость коленвала:" + V_Speed);       
                    Console.WriteLine("-------------------");
                }
            }
            //Результат тестирования
            if (Time >= 1000)
            {
                return "Двигатель работал в течении " + Time + " секунд. Перегрев не произошел";
            }
            return "Перегрев произошел спустя " + Time + " секунд после старта теста.";

        }
    }
}
