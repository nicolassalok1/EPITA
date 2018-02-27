using System;

namespace Client.FormIhm
{

    partial class Form1
    {


        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBagage = new System.Windows.Forms.TextBox();
            this.B_new = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "iata";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonIATA_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "id";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonid_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id/IATA :";
            // 
            // TBagage
            // 
            this.TBagage.Location = new System.Drawing.Point(158, 89);
            this.TBagage.Name = "TBagage";
            this.TBagage.Size = new System.Drawing.Size(100, 20);
            this.TBagage.TabIndex = 4;
            // 
            // B_new
            // 
            this.B_new.Location = new System.Drawing.Point(158, 226);
            this.B_new.Name = "B_new";
            this.B_new.Size = new System.Drawing.Size(114, 23);
            this.B_new.TabIndex = 5;
            this.B_new.Text = "Nouveau Bagage";
            this.B_new.UseVisualStyleBackColor = true;
            this.B_new.Click += new System.EventHandler(this.B_new_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.B_new);
            this.Controls.Add(this.TBagage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox TBagage;
        private System.Windows.Forms.Button B_new;
    }
}

