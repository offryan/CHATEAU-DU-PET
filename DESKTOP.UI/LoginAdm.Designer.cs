
//namespace ChateauBanco.UI
//{
//    partial class LoginAdm
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.btnEntrar = new System.Windows.Forms.Button();
//            this.btnCancelar = new System.Windows.Forms.Button();
//            this.lblAutenticação = new System.Windows.Forms.Label();
//            this.btnSair = new System.Windows.Forms.Button();
//            this.lblEmail = new System.Windows.Forms.Label();
//            this.lblSenha = new System.Windows.Forms.Label();
//            this.txtEmail = new System.Windows.Forms.TextBox();
//            this.txtSenha = new System.Windows.Forms.TextBox();
//            this.SuspendLayout();
//            // 
//            // btnEntrar
//            // 
//            this.btnEntrar.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnEntrar.Location = new System.Drawing.Point(84, 336);
//            this.btnEntrar.Name = "btnEntrar";
//            this.btnEntrar.Size = new System.Drawing.Size(115, 36);
//            this.btnEntrar.TabIndex = 0;
//            this.btnEntrar.Text = "Entrar";
//            this.btnEntrar.UseVisualStyleBackColor = true;
//            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
//            // 
//            // btnCancelar
//            // 
//            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnCancelar.Location = new System.Drawing.Point(342, 336);
//            this.btnCancelar.Name = "btnCancelar";
//            this.btnCancelar.Size = new System.Drawing.Size(115, 36);
//            this.btnCancelar.TabIndex = 1;
//            this.btnCancelar.Text = "Cancelar";
//            this.btnCancelar.UseVisualStyleBackColor = true;
//            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
//            // 
//            // lblAutenticação
//            // 
//            this.lblAutenticação.AutoSize = true;
//            this.lblAutenticação.Font = new System.Drawing.Font("Microsoft Uighur", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblAutenticação.Location = new System.Drawing.Point(178, 36);
//            this.lblAutenticação.Name = "lblAutenticação";
//            this.lblAutenticação.Size = new System.Drawing.Size(204, 63);
//            this.lblAutenticação.TabIndex = 2;
//            this.lblAutenticação.Text = "Autenticação";
//            // 
//            // btnSair
//            // 
//            this.btnSair.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnSair.Location = new System.Drawing.Point(365, 440);
//            this.btnSair.Name = "btnSair";
//            this.btnSair.Size = new System.Drawing.Size(115, 36);
//            this.btnSair.TabIndex = 3;
//            this.btnSair.Text = "Sair";
//            this.btnSair.UseVisualStyleBackColor = true;
//            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
//            // 
//            // lblEmail
//            // 
//            this.lblEmail.AutoSize = true;
//            this.lblEmail.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblEmail.Location = new System.Drawing.Point(79, 171);
//            this.lblEmail.Name = "lblEmail";
//            this.lblEmail.Size = new System.Drawing.Size(64, 36);
//            this.lblEmail.TabIndex = 4;
//            this.lblEmail.Text = "Email:";
//            // 
//            // lblSenha
//            // 
//            this.lblSenha.AutoSize = true;
//            this.lblSenha.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblSenha.Location = new System.Drawing.Point(78, 234);
//            this.lblSenha.Name = "lblSenha";
//            this.lblSenha.Size = new System.Drawing.Size(65, 36);
//            this.lblSenha.TabIndex = 5;
//            this.lblSenha.Text = "Senha:";
//            // 
//            // txtEmail
//            // 
//            this.txtEmail.Location = new System.Drawing.Point(145, 179);
//            this.txtEmail.Name = "txtEmail";
//            this.txtEmail.Size = new System.Drawing.Size(312, 20);
//            this.txtEmail.TabIndex = 6;
//            // 
//            // txtSenha
//            // 
//            this.txtSenha.Location = new System.Drawing.Point(145, 242);
//            this.txtSenha.Name = "txtSenha";
//            this.txtSenha.Size = new System.Drawing.Size(312, 20);
//            this.txtSenha.TabIndex = 7;
//            // 
//            // LoginAdm
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
//            this.ClientSize = new System.Drawing.Size(500, 500);
//            this.Controls.Add(this.txtSenha);
//            this.Controls.Add(this.txtEmail);
//            this.Controls.Add(this.lblSenha);
//            this.Controls.Add(this.lblEmail);
//            this.Controls.Add(this.btnSair);
//            this.Controls.Add(this.lblAutenticação);
//            this.Controls.Add(this.btnCancelar);
//            this.Controls.Add(this.btnEntrar);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.Name = "LoginAdm";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "LoginAdm";
//            this.Load += new System.EventHandler(this.LoginAdm_Load);
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.Button btnEntrar;
//        private System.Windows.Forms.Button btnCancelar;
//        private System.Windows.Forms.Label lblAutenticação;
//        private System.Windows.Forms.Button btnSair;
//        private System.Windows.Forms.Label lblEmail;
//        private System.Windows.Forms.Label lblSenha;
//        private System.Windows.Forms.TextBox txtEmail;
//        private System.Windows.Forms.TextBox txtSenha;
//    }
//}