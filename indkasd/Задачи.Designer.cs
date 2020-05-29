namespace indkasd
{
    partial class Задачи
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
            this.label6 = new System.Windows.Forms.Label();
            this.path_to_graph = new System.Windows.Forms.TextBox();
            this.choose_graph = new System.Windows.Forms.Button();
            this.choose_cycles = new System.Windows.Forms.Button();
            this.path_to_cycles = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.run = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.preview = new System.Windows.Forms.RichTextBox();
            this.preview_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.task1 = new System.Windows.Forms.RadioButton();
            this.task3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.task5 = new System.Windows.Forms.RadioButton();
            this.task2 = new System.Windows.Forms.RadioButton();
            this.task4 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 28);
            this.label6.TabIndex = 6;
            this.label6.Text = "Граф:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // path_to_graph
            // 
            this.path_to_graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.path_to_graph.Location = new System.Drawing.Point(58, 3);
            this.path_to_graph.Name = "path_to_graph";
            this.path_to_graph.Size = new System.Drawing.Size(383, 20);
            this.path_to_graph.TabIndex = 7;
            // 
            // choose_graph
            // 
            this.choose_graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choose_graph.Location = new System.Drawing.Point(447, 3);
            this.choose_graph.Name = "choose_graph";
            this.choose_graph.Size = new System.Drawing.Size(107, 22);
            this.choose_graph.TabIndex = 8;
            this.choose_graph.Text = "Обзор";
            this.choose_graph.UseVisualStyleBackColor = true;
            this.choose_graph.Click += new System.EventHandler(this.choose_graph_Click);
            // 
            // choose_cycles
            // 
            this.choose_cycles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choose_cycles.Enabled = false;
            this.choose_cycles.Location = new System.Drawing.Point(447, 31);
            this.choose_cycles.Name = "choose_cycles";
            this.choose_cycles.Size = new System.Drawing.Size(107, 23);
            this.choose_cycles.TabIndex = 11;
            this.choose_cycles.Text = "Обзор";
            this.choose_cycles.UseVisualStyleBackColor = true;
            this.choose_cycles.Click += new System.EventHandler(this.choose_cycles_Click);
            // 
            // path_to_cycles
            // 
            this.path_to_cycles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.path_to_cycles.Enabled = false;
            this.path_to_cycles.Location = new System.Drawing.Point(58, 31);
            this.path_to_cycles.Name = "path_to_cycles";
            this.path_to_cycles.Size = new System.Drawing.Size(383, 20);
            this.path_to_cycles.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(3, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 29);
            this.label7.TabIndex = 9;
            this.label7.Text = "ФМЦ:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.choose_cycles, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.choose_graph, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.path_to_cycles, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.path_to_graph, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(557, 57);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // run
            // 
            this.run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.run.Location = new System.Drawing.Point(337, 3);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(105, 24);
            this.run.TabIndex = 13;
            this.run.Text = "Выполнить";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // cancel
            // 
            this.cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancel.Location = new System.Drawing.Point(448, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(106, 24);
            this.cancel.TabIndex = 14;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.run, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.cancel, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 382);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(557, 30);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(563, 412);
            this.tableLayoutPanel5.TabIndex = 17;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 66);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(557, 310);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 19;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.preview, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.preview_label, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(258, 310);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // preview
            // 
            this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview.Enabled = false;
            this.preview.Location = new System.Drawing.Point(3, 65);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(253, 242);
            this.preview.TabIndex = 1;
            this.preview.Text = "";
            // 
            // preview_label
            // 
            this.preview_label.AutoSize = true;
            this.preview_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview_label.Location = new System.Drawing.Point(3, 0);
            this.preview_label.Name = "preview_label";
            this.preview_label.Size = new System.Drawing.Size(253, 62);
            this.preview_label.TabIndex = 2;
            this.preview_label.Text = "Предпросмотр";
            this.preview_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.task1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.task3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.task5, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.task2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.task4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.843137F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76471F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.843137F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.70588F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.843137F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.70588F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.843137F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.803922F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.843137F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.803922F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(287, 310);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // task1
            // 
            this.task1.AutoSize = true;
            this.task1.Location = new System.Drawing.Point(3, 3);
            this.task1.Name = "task1";
            this.task1.Size = new System.Drawing.Size(70, 17);
            this.task1.TabIndex = 0;
            this.task1.TabStop = true;
            this.task1.Text = "Задача 1";
            this.task1.UseVisualStyleBackColor = true;
            this.task1.CheckedChanged += new System.EventHandler(this.task1_CheckedChanged);
            // 
            // task3
            // 
            this.task3.AutoSize = true;
            this.task3.Location = new System.Drawing.Point(3, 132);
            this.task3.Name = "task3";
            this.task3.Size = new System.Drawing.Size(70, 17);
            this.task3.TabIndex = 2;
            this.task3.TabStop = true;
            this.task3.Text = "Задача 3";
            this.task3.UseVisualStyleBackColor = true;
            this.task3.CheckedChanged += new System.EventHandler(this.task3_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "    Дан связный неориентированный граф, проверить, \r\n    будет ли он Эйлеровым.";
            // 
            // task5
            // 
            this.task5.AutoSize = true;
            this.task5.Location = new System.Drawing.Point(3, 255);
            this.task5.Name = "task5";
            this.task5.Size = new System.Drawing.Size(70, 17);
            this.task5.TabIndex = 4;
            this.task5.TabStop = true;
            this.task5.Text = "Задача 5";
            this.task5.UseVisualStyleBackColor = true;
            this.task5.CheckedChanged += new System.EventHandler(this.task5_CheckedChanged);
            // 
            // task2
            // 
            this.task2.AutoSize = true;
            this.task2.Location = new System.Drawing.Point(3, 63);
            this.task2.Name = "task2";
            this.task2.Size = new System.Drawing.Size(70, 17);
            this.task2.TabIndex = 1;
            this.task2.TabStop = true;
            this.task2.Text = "Задача 2";
            this.task2.UseVisualStyleBackColor = true;
            this.task2.CheckedChanged += new System.EventHandler(this.task2_CheckedChanged);
            // 
            // task4
            // 
            this.task4.AutoSize = true;
            this.task4.Enabled = false;
            this.task4.Location = new System.Drawing.Point(3, 201);
            this.task4.Name = "task4";
            this.task4.Size = new System.Drawing.Size(70, 17);
            this.task4.TabIndex = 3;
            this.task4.TabStop = true;
            this.task4.Text = "Задача 4";
            this.task4.UseVisualStyleBackColor = true;
            this.task4.CheckedChanged += new System.EventHandler(this.task4_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 45);
            this.label2.TabIndex = 6;
            this.label2.Text = "    Дан неориентированный граф, дана вершина. \r\n    Построить произвольную максим" +
    "альную клику, \r\n    содержащую данную вершину.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(3, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 45);
            this.label3.TabIndex = 7;
            this.label3.Text = "    Дан слабосвязный ориентированный граф. \r\n    Проверить, возможно ли построить" +
    " топологическую\r\n    сортировку.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(3, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "    В разработке";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(3, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 34);
            this.label5.TabIndex = 9;
            this.label5.Text = "    Реализовать алгоритм А* нахождения кратчайшего \r\n    пути.";
            // 
            // Задачи
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 412);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Name = "Задачи";
            this.Text = "Задачи";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox path_to_graph;
        private System.Windows.Forms.Button choose_graph;
        private System.Windows.Forms.Button choose_cycles;
        private System.Windows.Forms.TextBox path_to_cycles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RichTextBox preview;
        private System.Windows.Forms.Label preview_label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton task1;
        private System.Windows.Forms.RadioButton task3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton task5;
        private System.Windows.Forms.RadioButton task2;
        private System.Windows.Forms.RadioButton task4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}