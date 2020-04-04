namespace графы
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.adjnode = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.adjnodelist = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.adjedge = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.adjedgelist = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pathtree = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.incmatrix = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Матрица смежности вершин";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // adjnode
            // 
            this.adjnode.Location = new System.Drawing.Point(32, 30);
            this.adjnode.Name = "adjnode";
            this.adjnode.Size = new System.Drawing.Size(152, 96);
            this.adjnode.TabIndex = 1;
            this.adjnode.Text = "";
            this.adjnode.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Список смежности вершин";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // adjnodelist
            // 
            this.adjnodelist.Location = new System.Drawing.Point(220, 30);
            this.adjnodelist.Name = "adjnodelist";
            this.adjnodelist.Size = new System.Drawing.Size(152, 96);
            this.adjnodelist.TabIndex = 3;
            this.adjnodelist.Text = "";
            this.adjnodelist.TextChanged += new System.EventHandler(this.RichTextBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Матрица смежности ребер";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // adjedge
            // 
            this.adjedge.Location = new System.Drawing.Point(32, 163);
            this.adjedge.Name = "adjedge";
            this.adjedge.Size = new System.Drawing.Size(152, 96);
            this.adjedge.TabIndex = 5;
            this.adjedge.Text = "";
            this.adjedge.TextChanged += new System.EventHandler(this.RichTextBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Список смежности ребер";
            // 
            // adjedgelist
            // 
            this.adjedgelist.Location = new System.Drawing.Point(220, 163);
            this.adjedgelist.Name = "adjedgelist";
            this.adjedgelist.Size = new System.Drawing.Size(152, 96);
            this.adjedgelist.TabIndex = 7;
            this.adjedgelist.Text = "";
            this.adjedgelist.TextChanged += new System.EventHandler(this.RichTextBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Дерево путей";
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // pathtree
            // 
            this.pathtree.Location = new System.Drawing.Point(410, 163);
            this.pathtree.Name = "pathtree";
            this.pathtree.Size = new System.Drawing.Size(152, 96);
            this.pathtree.TabIndex = 9;
            this.pathtree.Text = "";
            this.pathtree.TextChanged += new System.EventHandler(this.RichTextBox5_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Заполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(479, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Очистить все";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // incmatrix
            // 
            this.incmatrix.Location = new System.Drawing.Point(410, 30);
            this.incmatrix.Name = "incmatrix";
            this.incmatrix.Size = new System.Drawing.Size(152, 96);
            this.incmatrix.TabIndex = 12;
            this.incmatrix.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Матрица инцидентности";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 316);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.incmatrix);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pathtree);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.adjedgelist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.adjedge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.adjnodelist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.adjnode);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Графы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox adjnode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox adjnodelist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox adjedge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox adjedgelist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox pathtree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox incmatrix;
        private System.Windows.Forms.Label label6;
    }
}

