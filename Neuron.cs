using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CheckSymbolsNeuroWeb 
{
    /// <summary>
    /// Нейрон, распознающий образ сравнивая с эталонными образами
    /// </summary>
    public class Neuron
    {
        /// <summary>
        /// Название образа который распознается нейроном
        /// </summary>
        public string Name { get; set; }

        //Массив весов, память нейрона
        public double[,] Weights { get; set; }

        /// <summary>
        /// Количество образов в памяти
        /// </summary>
        public int TrainingCount { get; set; }
        
        public Neuron()
        {

        }

        /// <summary>
        /// Инициализировать нейрон
        /// </summary>
        /// <param name="name">Название образа</param>
        /// <param name="x">Длина массива весов</param>
        /// <param name="y">Ширина массива весов</param>
        public void Init(string name, int x, int y)
        {
            Name = name;
            Weights = new double[x,y];
            TrainingCount = 0;
        }

        /// <summary>
        /// Добавляем новый образ в массив памяти
        /// </summary>
        /// <param name="data">Массив нового образа</param>
        /// <returns>Количество образов в памяти</returns>
        public int Training(int[,] data)
        {
            //Проверка на то инициализирован ли массив и он такого же размера что и data
            if (data == null || Weights.GetLength(0) != data.GetLength(0) ||
                Weights.GetLength(1) != data.GetLength(1)) 
            {
                return TrainingCount;
            }

            TrainingCount++;

            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                for (int j = 0; j < Weights.GetLength(1); j++)
                {
                    //Если в data лежат не дискретные значения, переводим их в дискретные
                    data[i, j] = data[i, j] == 0 ? 0 : 1;
                    //Пересчитываем каждый элемент в памяти с учетом значений из data
                    //Начальное влияние каждого участка делаем половиной и делим на количество тренировок в базе,
                    //чтобы высчитать его влияние
                    //Умножаем на 2 чтобы первый раз он лучше запомнил образ
                    Weights[i, j] += 2 * (data[i, j] - 0.5) / TrainingCount;
                    //Вносим корректировки, если что-то пошло не так
                    if (Weights[i, j] > 1) 
                    {
                        // значение памяти не может быть больше 1
                        Weights[i, j] = 1;
                    }

                    if (Weights[i, j] < 0) 
                    {
                        // значение памяти не может быть меньше 0
                        Weights[i, j] = 0;
                    }
                }
            }


            return TrainingCount;
        }

        /// <summary>
        /// Распознать символ
        /// </summary>
        /// <param name="data">Массив входных данных</param>
        /// <returns>Степень уверенности в том что эта штука похожа на те что нейрон знает в процентах</returns>
        public double Recognize(int[,] data)
        {
            //Проверяем соответствует ли входной массив хранимому в памяти по размеру.
            if (Weights.GetLength(0) != data.GetLength(0) ||
                Weights.GetLength(1) != data.GetLength(1)) {
                throw new ArgumentException("Размер входного массива не соответствует массиву памяти нейрона");
            }

            double result = 0;

            for (int i = 0; i < Weights.GetLength(0); i++)
            {
                for (int j = 0; j < Weights.GetLength(1); j++)
                {
                    // Cчитаем то насколько отклоняются значения из памяти от входных
                    // в процентах, то есть за каждый процент отклонения от эталона
                    // вычитаем из 100% уверенности в идентичности один процент
                    result += 1 - Math.Abs(Weights[i, j] - data[i, j]);
                }
            }

            //Возвращаем среднее арифметическое отклонение
            return result / (Weights.GetLength(0) * Weights.GetLength(1));
        }
    }
}
