namespace indkasd
{
    partial class Result
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.current_task_num = new System.Windows.Forms.Label();
            this.current_answer = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.current_task_num, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.current_answer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.72727F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 153);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // current_task_num
            // 
            this.current_task_num.AutoSize = true;
            this.current_task_num.Dock = System.Windows.Forms.DockStyle.Fill;
            this.current_task_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.current_task_num.Location = new System.Drawing.Point(3, 0);
            this.current_task_num.Name = "current_task_num";
            this.current_task_num.Size = new System.Drawing.Size(305, 41);
            this.current_task_num.TabIndex = 0;
            this.current_task_num.Text = "label1";
            this.current_task_num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // current_answer
            // 
            this.current_answer.AutoSize = true;
            this.current_answer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.current_answer.Location = new System.Drawing.Point(3, 41);
            this.current_answer.Name = "current_answer";
            this.current_answer.Size = new System.Drawing.Size(305, 112);
            this.current_answer.TabIndex = 1;
            this.current_answer.Text = "label2";
            this.current_answer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 153);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Result";
            this.Text = "Result";
            this.Load += new System.EventHandler(this.Result_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label current_task_num;
        private System.Windows.Forms.Label current_answer;
    }
}