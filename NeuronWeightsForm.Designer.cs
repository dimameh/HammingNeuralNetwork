namespace CheckSymbolsNeuroWeb {
    partial class NeuronWeightsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.weightsDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.weightsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // weightsDataGrid
            // 
            this.weightsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weightsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weightsDataGrid.Location = new System.Drawing.Point(0, 0);
            this.weightsDataGrid.Name = "weightsDataGrid";
            this.weightsDataGrid.RowHeadersWidth = 51;
            this.weightsDataGrid.RowTemplate.Height = 24;
            this.weightsDataGrid.Size = new System.Drawing.Size(800, 450);
            this.weightsDataGrid.TabIndex = 1;
            // 
            // NeuronWeights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.weightsDataGrid);
            this.Name = "NeuronWeights";
            this.Text = "NeuronWeights";
            ((System.ComponentModel.ISupportInitialize)(this.weightsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView weightsDataGrid;
    }
}