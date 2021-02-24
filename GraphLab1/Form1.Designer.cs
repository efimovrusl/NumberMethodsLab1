
namespace GraphLab1
{
    partial class Graph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tablePanel1 = new System.Windows.Forms.Panel();
            this.DrawButton = new System.Windows.Forms.Button();
            this.graph_canvas = new System.Windows.Forms.Panel();
            this.tablePanel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(104)))), ((int)(((byte)(149)))));
            this.panel1.Controls.Add(this.tablePanel2);
            this.panel1.Controls.Add(this.tablePanel1);
            this.panel1.Controls.Add(this.DrawButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 95);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tablePanel1
            // 
            this.tablePanel1.BackColor = System.Drawing.Color.White;
            this.tablePanel1.Location = new System.Drawing.Point(12, 12);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Size = new System.Drawing.Size(336, 72);
            this.tablePanel1.TabIndex = 1;
            // 
            // DrawButton
            // 
            this.DrawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawButton.Location = new System.Drawing.Point(740, 12);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(186, 72);
            this.DrawButton.TabIndex = 0;
            this.DrawButton.Text = "GO!";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // graph_canvas
            // 
            this.graph_canvas.AutoSize = true;
            this.graph_canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.graph_canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.graph_canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graph_canvas.Location = new System.Drawing.Point(0, 95);
            this.graph_canvas.Name = "graph_canvas";
            this.graph_canvas.Size = new System.Drawing.Size(939, 485);
            this.graph_canvas.TabIndex = 1;
            this.graph_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // tablePanel2
            // 
            this.tablePanel2.BackColor = System.Drawing.Color.White;
            this.tablePanel2.Location = new System.Drawing.Point(376, 12);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Size = new System.Drawing.Size(336, 72);
            this.tablePanel2.TabIndex = 2;
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(939, 580);
            this.Controls.Add(this.graph_canvas);
            this.Controls.Add(this.panel1);
            this.Name = "Graph";
            this.ShowIcon = false;
            this.Text = "Graph1";
            this.Load += new System.EventHandler(this.Graph_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel graph_canvas;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Panel tablePanel1;
        private System.Windows.Forms.Panel tablePanel2;
    }
}

