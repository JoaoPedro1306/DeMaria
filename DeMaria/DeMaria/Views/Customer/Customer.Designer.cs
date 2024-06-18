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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CST_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CST_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CST_CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CST_EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CST_PHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADR_ZIP_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADR_STREET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADR_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADR_COMPLEMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADR_CITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADR_STATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(544, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clientes";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(36, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Incluir";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Goldenrod;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(180, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Window;
            this.button3.Location = new System.Drawing.Point(324, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Consultar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.Window;
            this.button4.Location = new System.Drawing.Point(468, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "Excluir";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.MinimumSize = new System.Drawing.Size(1163, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 412);
            this.panel1.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CST_ID,
            this.CST_NAME,
            this.CST_CPF,
            this.CST_EMAIL,
            this.CST_PHONE,
            this.ADR_ZIP_CODE,
            this.ADR_STREET,
            this.ADR_NUMBER,
            this.ADR_COMPLEMENT,
            this.ADR_CITY,
            this.ADR_STATE,
            this.ADR_ID});
            this.dataGridView1.Location = new System.Drawing.Point(37, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1094, 231);
            this.dataGridView1.TabIndex = 5;
            // 
            // CST_ID
            // 
            this.CST_ID.HeaderText = "ID";
            this.CST_ID.Name = "CST_ID";
            this.CST_ID.ReadOnly = true;
            this.CST_ID.Visible = false;
            // 
            // CST_NAME
            // 
            this.CST_NAME.HeaderText = "Nome";
            this.CST_NAME.Name = "CST_NAME";
            // 
            // CST_CPF
            // 
            this.CST_CPF.HeaderText = "CPF";
            this.CST_CPF.Name = "CST_CPF";
            // 
            // CST_EMAIL
            // 
            this.CST_EMAIL.HeaderText = "Email";
            this.CST_EMAIL.Name = "CST_EMAIL";
            // 
            // CST_PHONE
            // 
            this.CST_PHONE.HeaderText = "Telefone";
            this.CST_PHONE.Name = "CST_PHONE";
            // 
            // ADR_ZIP_CODE
            // 
            this.ADR_ZIP_CODE.HeaderText = "CEP";
            this.ADR_ZIP_CODE.Name = "ADR_ZIP_CODE";
            // 
            // ADR_STREET
            // 
            this.ADR_STREET.HeaderText = "Rua";
            this.ADR_STREET.Name = "ADR_STREET";
            // 
            // ADR_NUMBER
            // 
            this.ADR_NUMBER.HeaderText = "Número";
            this.ADR_NUMBER.Name = "ADR_NUMBER";
            // 
            // ADR_COMPLEMENT
            // 
            this.ADR_COMPLEMENT.HeaderText = "Complemento";
            this.ADR_COMPLEMENT.Name = "ADR_COMPLEMENT";
            // 
            // ADR_CITY
            // 
            this.ADR_CITY.HeaderText = "Cidade";
            this.ADR_CITY.Name = "ADR_CITY";
            // 
            // ADR_STATE
            // 
            this.ADR_STATE.HeaderText = "Estado";
            this.ADR_STATE.Name = "ADR_STATE";
            // 
            // ADR_ID
            // 
            this.ADR_ID.HeaderText = "ADR_ID";
            this.ADR_ID.Name = "ADR_ID";
            this.ADR_ID.ReadOnly = true;
            this.ADR_ID.Visible = false;
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1187, 434);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1203, 473);
            this.Name = "Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CST_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CST_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CST_CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn CST_EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CST_PHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADR_ZIP_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADR_STREET;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADR_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADR_COMPLEMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADR_CITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADR_STATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADR_ID;
    }
}