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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PRD_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRD_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRD_DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRD_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRD_STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.MinimumSize = new System.Drawing.Size(796, 344);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 344);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRD_ID,
            this.PRD_NAME,
            this.PRD_DESCRIPTION,
            this.PRD_PRICE,
            this.PRD_STOCK});
            this.dataGridView1.Location = new System.Drawing.Point(25, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(740, 211);
            this.dataGridView1.TabIndex = 0;
            // 
            // PRD_ID
            // 
            this.PRD_ID.HeaderText = "ID";
            this.PRD_ID.Name = "PRD_ID";
            this.PRD_ID.ReadOnly = true;
            this.PRD_ID.Visible = false;
            // 
            // PRD_NAME
            // 
            this.PRD_NAME.HeaderText = "Nome";
            this.PRD_NAME.Name = "PRD_NAME";
            // 
            // PRD_DESCRIPTION
            // 
            this.PRD_DESCRIPTION.HeaderText = "Descrição";
            this.PRD_DESCRIPTION.Name = "PRD_DESCRIPTION";
            // 
            // PRD_PRICE
            // 
            this.PRD_PRICE.HeaderText = "Preço (R$)";
            this.PRD_PRICE.Name = "PRD_PRICE";
            // 
            // PRD_STOCK
            // 
            this.PRD_STOCK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PRD_STOCK.HeaderText = "Estoque";
            this.PRD_STOCK.Name = "PRD_STOCK";
            this.PRD_STOCK.Width = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Produtos";
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.Red;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.Window;
            this.button5.Location = new System.Drawing.Point(462, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(138, 40);
            this.button5.TabIndex = 9;
            this.button5.Text = "Excluir";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.Window;
            this.button6.Location = new System.Drawing.Point(318, 67);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(138, 40);
            this.button6.TabIndex = 8;
            this.button6.Text = "Consultar";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.BackColor = System.Drawing.Color.Green;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.Window;
            this.button7.Location = new System.Drawing.Point(25, 67);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(138, 40);
            this.button7.TabIndex = 6;
            this.button7.Text = "Incluir";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.BackColor = System.Drawing.Color.Goldenrod;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.Window;
            this.button8.Location = new System.Drawing.Point(174, 67);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(138, 40);
            this.button8.TabIndex = 7;
            this.button8.Text = "Editar";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(820, 369);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(836, 408);
            this.Name = "Product";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRD_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRD_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRD_DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRD_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRD_STOCK;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}