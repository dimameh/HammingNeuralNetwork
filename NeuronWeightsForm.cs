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
    public partial class NeuronWeightsForm : Form 
    {
        public Neuron Neuron { get; private set; }

        public NeuronWeightsForm(Neuron neuron) 
        {
            InitializeComponent();
            Neuron = neuron;
            LoadData();
        }

        private void LoadData()
        {
            weightsDataGrid.ColumnCount = Neuron.Weights.GetLength(0);
            weightsDataGrid.RowCount = Neuron.Weights.GetLength(1);
            weightsDataGrid.DefaultCellStyle.ForeColor = Color.Green;

            for (int n = 0; n < Neuron.Weights.GetLength(0); n++) 
            {
                DataGridViewColumn column = weightsDataGrid.Columns[n];
                column.Width = 32;

                for (int m = 0; m < Neuron.Weights.GetLength(1); m++) 
                {
                    int color = (int)((1 - Neuron.Weights[n, m]) * 255);
                    weightsDataGrid.Rows[m].Cells[n].Style.BackColor = Color.FromArgb(color, color, color);
                    weightsDataGrid.Rows[m].Cells[n].Value = Neuron.Weights[n, m];
                }
            }
        }
    }
}
