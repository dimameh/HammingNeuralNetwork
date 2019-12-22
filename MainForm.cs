using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckSymbolsNeuroWeb 
{
    public partial class MainForm : Form 
    {
        /// <summary>
        /// Начальная точка рисования
        /// </summary>
        private Point StartPoint { get; set; }

        /// <summary>
        /// Используемая нейронная сеть
        /// </summary>
        private NeuroWeb CurrentNeuroWeb { get; set; } = new NeuroWeb("memory.txt");

        private int[,] dataArray;

        public MainForm() 
        {
            InitializeComponent();
            GraphTools.InitPictureBox(inputPictureBox);
            CurrentNeuroWeb = new NeuroWeb("memory.txt");
            string[] items = CurrentNeuroWeb.GetObjectNames().ToArray();
            if (items.Length > 0) 
            {
                valuesComboBox.Items.AddRange(items);
                valuesComboBox.SelectedIndex = 0;
            }

            dataArray = new int[CurrentNeuroWeb.NeuronArrayWidth,
                CurrentNeuroWeb.NeuronArrayHeight];
            GraphTools.InitPictureBox(inputPictureBox);
            GraphTools.InitPictureBox(letterPictureBox);
            GraphTools.InitPictureBox(compressedPictureBox);
        }

        private void inputPictureBox_MouseDown(object sender, MouseEventArgs e) 
        {
            StartPoint = new Point(e.X, e.Y);
        }

        private void inputPictureBox_MouseMove(object sender, MouseEventArgs e) 
        {
            if (e.Button == MouseButtons.Left) {
                Point endP = new Point(e.X, e.Y);
                Bitmap image = (Bitmap)inputPictureBox.Image;
                using (Graphics g = Graphics.FromImage(image)) {
                    g.DrawLine(new Pen(Color.Black), StartPoint, endP);
                }
                inputPictureBox.Image = image;
                StartPoint = endP;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CurrentNeuroWeb.SaveState();
        }

        private void recognizeButton_Click(object sender, EventArgs e) 
        {
            Recognize();
        }

        private void Recognize()
        {
            int[,] clipArr = GraphTools.CutImageToArray((Bitmap)inputPictureBox.Image, new Point(inputPictureBox.Width, inputPictureBox.Height));
            if (clipArr == null)
            {
                return;
            }
            dataArray = GraphTools.LeadArray(clipArr, CurrentNeuroWeb.NeuronArrayWidth, CurrentNeuroWeb.NeuronArrayHeight);
            letterPictureBox.Image = GraphTools.GetBitmapFromArr(clipArr);
            compressedPictureBox.Image = GraphTools.GetBitmapFromArr(dataArray);
            string resultName = CurrentNeuroWeb.RecognizeData(dataArray);
            if (resultName == null)
            {
                resultName = "null";
            }

            MessageBox.Show("Результат распознавания - " + resultName + " ?", "", MessageBoxButtons.OK);
        }

        private void clearButton_Click(object sender, EventArgs e) 
        {
            GraphTools.InitPictureBox(inputPictureBox);
            GraphTools.InitPictureBox(letterPictureBox);
            GraphTools.InitPictureBox(compressedPictureBox);
        }

        private void addDataButton_Click(object sender, EventArgs e) 
        {
            string litera = valuesComboBox.SelectedIndex >= 0 ? (string)valuesComboBox.Items[valuesComboBox.SelectedIndex] : valuesComboBox.Text;
            if (litera.Length == 0) 
            {
                MessageBox.Show("Не выбран ни один символ для занесения в память.");
                return;
            }
            CurrentNeuroWeb.SetTraining(valuesComboBox.Text, dataArray);
            GraphTools.InitPictureBox(inputPictureBox);
            GraphTools.InitPictureBox(letterPictureBox);
            GraphTools.InitPictureBox(compressedPictureBox);
            MessageBox.Show("Выбранный символ '" + litera + "' успешно добавлен в память нейрона " + valuesComboBox.Text);
        }

        private void addNameButton_Click(object sender, EventArgs e)
        {
            var symbol = newValueTextBox.Text;
            if (symbol == null || symbol.Length == 0) {
                MessageBox.Show("Значение не может иметь длину 0 символов.");
                return;
            }
            valuesComboBox.Items.Add(symbol);
            valuesComboBox.SelectedIndex = valuesComboBox.Items.Count - 1;
            MessageBox.Show("Сейчас значение '" + symbol + "' в списке, теперь можно научить нейросеть сеть его распознавать.");
        }

        private void drawButton_Click(object sender, EventArgs e) 
        {
            inputPictureBox.Image = GraphTools.DrawLitera(inputPictureBox.Image, (string)valuesComboBox.SelectedItem);
            int[,] clipArr = GraphTools.CutImageToArray((Bitmap)inputPictureBox.Image, new Point(inputPictureBox.Width, inputPictureBox.Height));
            if (clipArr == null) {
                return;
            }
            dataArray = GraphTools.LeadArray(clipArr, CurrentNeuroWeb.NeuronArrayWidth, CurrentNeuroWeb.NeuronArrayHeight);
            letterPictureBox.Image = GraphTools.GetBitmapFromArr(clipArr);
            compressedPictureBox.Image = GraphTools.GetBitmapFromArr(dataArray);
        }
    }
}
