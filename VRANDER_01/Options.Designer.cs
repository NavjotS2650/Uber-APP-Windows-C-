namespace VRANDER_01
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.btnUpdateDelete = new System.Windows.Forms.Button();
            this.btnBookCar = new System.Windows.Forms.Button();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdateDelete
            // 
            this.btnUpdateDelete.BackColor = System.Drawing.Color.Gold;
            this.btnUpdateDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDelete.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdateDelete.Location = new System.Drawing.Point(48, 131);
            this.btnUpdateDelete.Name = "btnUpdateDelete";
            this.btnUpdateDelete.Size = new System.Drawing.Size(372, 65);
            this.btnUpdateDelete.TabIndex = 0;
            this.btnUpdateDelete.Text = "Update/Delete";
            this.btnUpdateDelete.UseVisualStyleBackColor = false;
            this.btnUpdateDelete.Click += new System.EventHandler(this.btnUpdateDelete_Click);
            // 
            // btnBookCar
            // 
            this.btnBookCar.BackColor = System.Drawing.Color.Gold;
            this.btnBookCar.FlatAppearance.BorderSize = 20;
            this.btnBookCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookCar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnBookCar.Location = new System.Drawing.Point(45, 46);
            this.btnBookCar.Name = "btnBookCar";
            this.btnBookCar.Size = new System.Drawing.Size(375, 65);
            this.btnBookCar.TabIndex = 1;
            this.btnBookCar.Text = "Book a Car";
            this.btnBookCar.UseVisualStyleBackColor = false;
            this.btnBookCar.Click += new System.EventHandler(this.btnBookCar_Click);
            // 
            // btnFeedback
            // 
            this.btnFeedback.BackColor = System.Drawing.Color.Gold;
            this.btnFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedback.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFeedback.Location = new System.Drawing.Point(48, 217);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(372, 65);
            this.btnFeedback.TabIndex = 2;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = false;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.Gold;
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnHistory.Location = new System.Drawing.Point(45, 305);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(372, 65);
            this.btnHistory.TabIndex = 3;
            this.btnHistory.Text = "View History";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(166, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select an Option";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.btnBookCar);
            this.groupBox1.Controls.Add(this.btnUpdateDelete);
            this.groupBox1.Controls.Add(this.btnHistory);
            this.groupBox1.Controls.Add(this.btnFeedback);
            this.groupBox1.Location = new System.Drawing.Point(59, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 410);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(578, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateDelete;
        private System.Windows.Forms.Button btnBookCar;
        private System.Windows.Forms.Button btnFeedback;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}