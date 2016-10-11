namespace LINQtoSQLDLinqDesigner
{
    partial class Form1
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
            this.dgRole = new System.Windows.Forms.DataGridView();
            this.dgPerson = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // dgRole
            // 
            this.dgRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgRole.Location = new System.Drawing.Point(0, 0);
            this.dgRole.Name = "dgRole";
            this.dgRole.Size = new System.Drawing.Size(659, 150);
            this.dgRole.TabIndex = 0;
            // 
            // dgPerson
            // 
            this.dgPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPerson.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgPerson.Location = new System.Drawing.Point(0, 200);
            this.dgPerson.Name = "dgPerson";
            this.dgPerson.Size = new System.Drawing.Size(659, 150);
            this.dgPerson.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 350);
            this.Controls.Add(this.dgPerson);
            this.Controls.Add(this.dgRole);
            this.Name = "Form1";
            this.Text = "Roles and people";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRole;
        private System.Windows.Forms.DataGridView dgPerson;
    }
}

