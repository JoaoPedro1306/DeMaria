namespace DeMaria.Views.Product {
    partial class Product {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ConsultButton = new System.Windows.Forms.Button();
            this.IncludeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.ConsultButton);
            this.panel1.Controls.Add(this.IncludeButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DataGridViewProduct);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.MinimumSize = new System.Drawing.Size(1061, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1061, 423);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(444, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Produtos";
            // 
            // DataGridViewProduct
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewProduct.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewProduct.DefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridViewProduct.Location = new System.Drawing.Point(33, 139);
            this.DataGridViewProduct.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewProduct.Name = "DataGridViewProduct";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridViewProduct.RowHeadersWidth = 51;
            this.DataGridViewProduct.Size = new System.Drawing.Size(987, 260);
            this.DataGridViewProduct.TabIndex = 0;
            // 
            // EditButton
            // 
            this.EditButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditButton.BackColor = System.Drawing.Color.Goldenrod;
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.EditButton.ForeColor = System.Drawing.SystemColors.Window;
            this.EditButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EditButton.Location = new System.Drawing.Point(227, 82);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(184, 49);
            this.EditButton.TabIndex = 18;
            this.EditButton.Text = "Editar";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteButton.BackColor = System.Drawing.Color.Red;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.DeleteButton.ForeColor = System.Drawing.SystemColors.Window;
            this.DeleteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteButton.Location = new System.Drawing.Point(611, 82);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(184, 49);
            this.DeleteButton.TabIndex = 17;
            this.DeleteButton.Text = "Excluir";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ConsultButton
            // 
            this.ConsultButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsultButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ConsultButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConsultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ConsultButton.ForeColor = System.Drawing.SystemColors.Window;
            this.ConsultButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConsultButton.Location = new System.Drawing.Point(419, 82);
            this.ConsultButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConsultButton.Name = "ConsultButton";
            this.ConsultButton.Size = new System.Drawing.Size(184, 49);
            this.ConsultButton.TabIndex = 16;
            this.ConsultButton.Text = "Consultar";
            this.ConsultButton.UseVisualStyleBackColor = false;
            this.ConsultButton.Click += new System.EventHandler(this.ConsultButton_Click);
            // 
            // IncludeButton
            // 
            this.IncludeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IncludeButton.BackColor = System.Drawing.Color.Green;
            this.IncludeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.IncludeButton.FlatAppearance.BorderSize = 0;
            this.IncludeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IncludeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.IncludeButton.ForeColor = System.Drawing.SystemColors.Window;
            this.IncludeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.IncludeButton.Location = new System.Drawing.Point(35, 82);
            this.IncludeButton.Margin = new System.Windows.Forms.Padding(4);
            this.IncludeButton.Name = "IncludeButton";
            this.IncludeButton.Size = new System.Drawing.Size(184, 49);
            this.IncludeButton.TabIndex = 15;
            this.IncludeButton.Text = "Incluir";
            this.IncludeButton.UseVisualStyleBackColor = false;
            this.IncludeButton.Click += new System.EventHandler(this.IncludeButton_Click);
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1093, 454);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1109, 493);
            this.Name = "Product";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DataGridViewProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ConsultButton;
        private System.Windows.Forms.Button IncludeButton;
    }
}