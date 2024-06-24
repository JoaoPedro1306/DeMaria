namespace DeMaria {
    partial class MainForm {
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
            this.CustomerButton = new System.Windows.Forms.Button();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.UserButton = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.ProductButton = new System.Windows.Forms.Button();
            this.StoreButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.CustomerButton);
            this.panel1.Controls.Add(this.TitlePanel);
            this.panel1.Controls.Add(this.UserButton);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.ChangePasswordButton);
            this.panel1.Controls.Add(this.ProductButton);
            this.panel1.Controls.Add(this.StoreButton);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 523);
            this.panel1.TabIndex = 0;
            // 
            // CustomerButton
            // 
            this.CustomerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerButton.Location = new System.Drawing.Point(360, 128);
            this.CustomerButton.Margin = new System.Windows.Forms.Padding(4);
            this.CustomerButton.Name = "CustomerButton";
            this.CustomerButton.Size = new System.Drawing.Size(160, 148);
            this.CustomerButton.TabIndex = 9;
            this.CustomerButton.Text = "Clientes";
            this.CustomerButton.UseVisualStyleBackColor = true;
            this.CustomerButton.Click += new System.EventHandler(this.CustomerButton_Click);
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.LabelTitle);
            this.TitlePanel.Location = new System.Drawing.Point(3, 64);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(899, 57);
            this.TitlePanel.TabIndex = 9;
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitle.Location = new System.Drawing.Point(399, 14);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(103, 38);
            this.LabelTitle.TabIndex = 7;
            this.LabelTitle.Text = "label1";
            this.LabelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // UserButton
            // 
            this.UserButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserButton.Location = new System.Drawing.Point(360, 302);
            this.UserButton.Margin = new System.Windows.Forms.Padding(4);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(160, 148);
            this.UserButton.TabIndex = 8;
            this.UserButton.Text = "Usuários";
            this.UserButton.UseVisualStyleBackColor = true;
            this.UserButton.Click += new System.EventHandler(this.UserButton_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(173, 302);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(160, 148);
            this.button6.TabIndex = 6;
            this.button6.Text = "Relatórios";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChangePasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordButton.Location = new System.Drawing.Point(552, 302);
            this.ChangePasswordButton.Margin = new System.Windows.Forms.Padding(4);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(160, 148);
            this.ChangePasswordButton.TabIndex = 5;
            this.ChangePasswordButton.Text = "Alterar Senha";
            this.ChangePasswordButton.UseVisualStyleBackColor = true;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // ProductButton
            // 
            this.ProductButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductButton.Location = new System.Drawing.Point(552, 128);
            this.ProductButton.Margin = new System.Windows.Forms.Padding(4);
            this.ProductButton.Name = "ProductButton";
            this.ProductButton.Size = new System.Drawing.Size(160, 148);
            this.ProductButton.TabIndex = 4;
            this.ProductButton.Text = "Produtos";
            this.ProductButton.UseVisualStyleBackColor = true;
            this.ProductButton.Click += new System.EventHandler(this.ProductButton_Click);
            // 
            // StoreButton
            // 
            this.StoreButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StoreButton.Location = new System.Drawing.Point(173, 128);
            this.StoreButton.Margin = new System.Windows.Forms.Padding(4);
            this.StoreButton.Name = "StoreButton";
            this.StoreButton.Size = new System.Drawing.Size(160, 148);
            this.StoreButton.TabIndex = 1;
            this.StoreButton.Text = "Loja";
            this.StoreButton.UseVisualStyleBackColor = true;
            this.StoreButton.Click += new System.EventHandler(this.StoreButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(939, 555);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Página Principal";
            this.panel1.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ProductButton;
        private System.Windows.Forms.Button StoreButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button ChangePasswordButton;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Button UserButton;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Button CustomerButton;
    }
}