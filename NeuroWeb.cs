
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CheckSymbolsNeuroWeb 
{
    /// <summary>
    /// Нейронная сеть
    /// </summary>
    public class NeuroWeb
    {
        /// <summary>
        /// Длина массива памяти нейронов
        /// </summary>
        public int NeuronArrayWidth { get; private set; } = 10;

        /// <summary>
        /// Высота массива памяти нейронов
        /// </summary>
        public int NeuronArrayHeight { get; private set; } = 10;

        /// <summary>
        /// Файл, где хранится память всех нейронов нейросети
        /// </summary>
        private string MemoryFilename { get; set; } = "memory.txt";

        /// <summary>
        /// Список нейронов нейросети
        /// </summary>
        private List<Neuron> NeuronArray { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="filename"></param>
        public NeuroWeb(string filename)
        {
            MemoryFilename = filename;
            NeuronArray = InitNeuroWeb();
        }

        /// <summary>
        /// Инициализируем сеть из файла
        /// </summary>
        /// <returns>Инициализированный список нейронов</returns>
        private List<Neuron> InitNeuroWeb()
        {
            if (!File.Exists(MemoryFilename)) 
            {
                return new List<Neuron>();
            }
            string[] lines = File.ReadAllLines(MemoryFilename);

            if (lines.Length == 0) {
                return new List<Neuron>();
            }

            JavaScriptSerializer json = new JavaScriptSerializer();
            List<object> deserializedObjects = json.Deserialize<List<object>>(lines[0]);
            List<Neuron> neuroWeb = new List<Neuron>();

            foreach (var item in deserializedObjects) 
            {
                neuroWeb.Add(NeuronCreate((Dictionary<string, object>)item));
            }
            return neuroWeb;
        }

        /// <summary>
        /// Создаем нейрон по десериализованному объекту
        /// </summary>
        /// <param name="deserializedObject">Десериализованный объект</param>
        /// <returns>Собранный нейрон</returns>
        private Neuron NeuronCreate(Dictionary<string, object> deserializedObject)
        {
            Neuron neuron = new Neuron();
            string neuronName = deserializedObject["Name"].ToString();
            object[] weightData = (object[])deserializedObject["Weights"];

            int arrSize = (int)Math.Sqrt(weightData.Length);
            neuron.Init(neuronName, arrSize,arrSize);
            neuron.TrainingCount = (int)deserializedObject["TrainingCount"];
            int index = 0;
            for (int i = 0; i < neuron.Weights.GetLength(0); i++)
            {
                for (int j = 0; j < neuron.Weights.GetLength(1); j++)
                {
                    neuron.Weights[i,j] = double.Parse(weightData[index].ToString());
                    index++;
                }
            }

            return neuron;
        }

        /// <summary>
        /// Протаскивает входные данные по всем нейронам сети и выбирает тот
        /// который больше всех уверен что он прав
        /// </summary>
        /// <param name="data">Входные данные</param>
        /// <returns>Имя нейрона</returns>
        public string RecognizeData(int[,] data)
        {
            string result = null;
            double max = 0;
            foreach (var neuron in NeuronArray)
            {
                double confidence = neuron.Recognize(data);
                if (confidence > max)
                {
                    max = confidence;
                    result = neuron.Name;
                }
            }

            return result;
        }

        /// <summary>
        /// Сохранить нейронную сеть в файл
        /// </summary>
        public void SaveState() 
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            string jStr = json.Serialize(NeuronArray);
            StreamWriter file = new StreamWriter(MemoryFilename);
            file.WriteLine(jStr);
            file.Close();
        }

        /// <summary>
        /// Получить список всех названий объектов которые могут распознать нейроны сети
        /// </summary>
        /// <returns></returns>
        public List<string> GetObjectNames() 
        {
            var res = new List<string>();
            foreach (var neuron in NeuronArray)
            {
                res.Add(neuron.Name);
            }
            return res;
        }

        /// <summary>
        /// Добавить образ для нейрона
        /// </summary>
        /// <param name="trainingName">Название образа</param>
        /// <param name="data">Данные образа</param>
        public void SetTraining(string trainingName, int[,] data) {
            Neuron neuron = NeuronArray.Find(v => v.Name.Equals(trainingName));
            if (neuron == null) // если нейрона с таким именем не существует, создадим новыи и добавим
            {                   // его в массив нейронов
                neuron = new Neuron();
                neuron.Init(trainingName, NeuronArrayWidth, NeuronArrayHeight);
                NeuronArray.Add(neuron);
            }
            int countTrainig = neuron.Training(data); // обучим нейрон новому образу
            string messageStr = "Имя образа - " + neuron.Name +
                                " вариантов образа в памяти - " + countTrainig;

            // покажем визуальное отображение памяти обученного нейрона
            Form resultForm = new NeuronWeightsForm(neuron);
            resultForm.Text = messageStr;
            resultForm.Show();
        }
    }
}
