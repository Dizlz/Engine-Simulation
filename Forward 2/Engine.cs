using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forward_2
{
    public class Engine
    {

        //Момент инерции двигателя
        public float I_Momentum;

        //Кусочно-линейная зависимость крутящего момента 
        public float[] M_Torgue_jump;

        //Скорость вращения коленвала
        public float[] V_Crankshaft_speed_jump;

        //Температура перегрева
        public float T_Overheat;

        //Коэффициент зависимости скорости нагрева от крутящего момента
        public float Hm_Torgue;

        //Коэффициент зависимости скорости нагрева от скорости вращения коленвала
        public float Hv_Crankshaft_speed;

        //Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды           
        public float C_Temp;

        
        //Стандартный двигатель
        public void standartengine()
        {
            I_Momentum = 10;
            M_Torgue_jump = new float[] { 20, 75, 100, 105, 75, 0 };
            V_Crankshaft_speed_jump = new float[] { 0, 75, 150, 200, 250, 300 };
            T_Overheat = 110;
            Hm_Torgue = 0.01F;
            Hv_Crankshaft_speed = 0.0001F;
            C_Temp = 0.1F;
        }

        //Форсированный двигатель
        public void forcedengine()
        {
            I_Momentum = 10;
            M_Torgue_jump = new float[] { 40, 125, 200, 300, 200, 0 };
            V_Crankshaft_speed_jump = new float[] { 0, 100, 250, 300, 400, 500 };
            T_Overheat = 150;
            Hm_Torgue = 0.01F;
            Hv_Crankshaft_speed = 0.0001F;
            C_Temp = 0.1F;
        }
        
        
        
        //Включение двигателя
        public void start_engine(double T_Surrounding, ref float V, ref double T_Engine, ref int j)
        {
            //Анализ зависимости M & V
            if (j < V_Crankshaft_speed_jump.Length - 1)
            {
                if (V >= V_Crankshaft_speed_jump[j + 1])
                {
                    j++;
                }
            }
            //Ускорение коленвала
            V += M_Torgue_jump[j] / I_Momentum;
            //Нагрев двигателя
            T_Engine += M_Torgue_jump[j] * Hm_Torgue + Math.Pow(V, 2) * Hv_Crankshaft_speed;
            //Охлаждение двигателя 
            T_Engine += C_Temp * (T_Surrounding - T_Engine);           
        }             
    }    
}
