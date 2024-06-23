namespace DeMaria.Views.Customer {
    partial class Customer {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataGridViewCustomer = new System.Windows.Forms.DataGridView();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ConsultButton = new System.Windows.Forms.Button();
            this.IncludeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(870, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clientes";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.ConsultButton);
            this.panel1.Controls.Add(this.IncludeButton);
            this.panel1.Controls.Add(this.DataGridViewCustomer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.MinimumSize = new System.Drawing.Size(1777, 507);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1777, 507);
            this.panel1.TabIndex = 5;
            // 
            // DataGridViewCustomer
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DataGridViewCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewCustomer.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewCustomer.Location = new System.Drawing.Point(24, 197);
            this.DataGridViewCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridViewCustomer.Name = "DataGridViewCustomer";
            this.DataGridViewCustomer.RowHeadersWidth = 51;
            this.DataGridViewCustomer.Size = new System.Drawing.Size(1728, 283);
            this.DataGridViewCustomer.TabIndex = 5;
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.Goldenrod;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.EditButton.ForeColor = System.Drawing.SystemColors.Window;
            this.EditButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EditButton.Location = new System.Drawing.Point(216, 126);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(184, 49);
            this.EditButton.TabIndex = 22;
            this.EditButton.Text = "Editar";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Red;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.DeleteButton.ForeColor = System.Drawing.SystemColors.Window;
            this.DeleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteButton.Location = new System.Drawing.Point(600, 126);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(184, 49);
            this.DeleteButton.TabIndex = 21;
            this.DeleteButton.Text = "Excluir";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ConsultButton
            // 
            this.ConsultButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ConsultButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConsultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ConsultButton.ForeColor = System.Drawing.SystemColors.Window;
            this.ConsultButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConsultButton.Location = new System.Drawing.Point(408, 126);
            this.ConsultButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConsultButton.Name = "ConsultButton";
            this.ConsultButton.Size = new System.Drawing.Size(184, 49);
            this.ConsultButton.TabIndex = 20;
            this.ConsultButton.Text = "Consultar";
            this.ConsultButton.UseVisualStyleBackColor = false;
            this.ConsultButton.Click += new System.EventHandler(this.ConsultButton_Click);
            // 
            // IncludeButton
            // 
            this.IncludeButton.BackColor = System.Drawing.Color.Green;
            this.IncludeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.IncludeButton.FlatAppearance.BorderSize = 0;
            this.IncludeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IncludeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.IncludeButton.ForeColor = System.Drawing.SystemColors.Window;
            this.IncludeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IncludeButton.Location = new System.Drawing.Point(24, 126);
            this.IncludeButton.Margin = new System.Windows.Forms.Padding(4);
            this.IncludeButton.Name = "IncludeButton";
            this.IncludeButton.Size = new System.Drawing.Size(184, 49);
            this.IncludeButton.TabIndex = 19;
            this.IncludeButton.Text = "Incluir";
            this.IncludeButton.UseVisualStyleBackColor = false;
            this.IncludeButton.Click += new System.EventHandler(this.IncludeButton_Click);
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1813, 524);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1831, 571);
            this.Name = "Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DataGridViewCustomer;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ConsultButton;
        private System.Windows.Forms.Button IncludeButton;
    }
}