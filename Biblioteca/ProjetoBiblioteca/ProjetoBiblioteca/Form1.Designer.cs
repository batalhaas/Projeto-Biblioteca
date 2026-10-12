namespace ProjetoBibliotecaForms
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtEditora = new System.Windows.Forms.TextBox();
            this.txtTombo = new System.Windows.Forms.TextBox();
            this.btnAdicionarLivro = new System.Windows.Forms.Button();
            this.btnAdicionarExemplar = new System.Windows.Forms.Button();
            this.btnEmprestar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnPesquisarSintetico = new System.Windows.Forms.Button();
            this.btnPesquisarAnalitico = new System.Windows.Forms.Button();
            this.lstResultados = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtIsbn
            // 
            this.txtIsbn.Location = new System.Drawing.Point(515, 152);
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(100, 22);
            this.txtIsbn.TabIndex = 0;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(350, 214);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(100, 22);
            this.txtTitulo.TabIndex = 1;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(319, 302);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(100, 22);
            this.txtAutor.TabIndex = 2;
            // 
            // txtEditora
            // 
            this.txtEditora.Location = new System.Drawing.Point(506, 247);
            this.txtEditora.Name = "txtEditora";
            this.txtEditora.Size = new System.Drawing.Size(100, 22);
            this.txtEditora.TabIndex = 3;
            // 
            // txtTombo
            // 
            this.txtTombo.Location = new System.Drawing.Point(479, 311);
            this.txtTombo.Name = "txtTombo";
            this.txtTombo.Size = new System.Drawing.Size(100, 22);
            this.txtTombo.TabIndex = 4;
            // 
            // btnAdicionarLivro
            // 
            this.btnAdicionarLivro.Location = new System.Drawing.Point(65, 85);
            this.btnAdicionarLivro.Name = "btnAdicionarLivro";
            this.btnAdicionarLivro.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarLivro.TabIndex = 5;
            this.btnAdicionarLivro.Text = "button1";
            this.btnAdicionarLivro.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarExemplar
            // 
            this.btnAdicionarExemplar.Location = new System.Drawing.Point(50, 151);
            this.btnAdicionarExemplar.Name = "btnAdicionarExemplar";
            this.btnAdicionarExemplar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarExemplar.TabIndex = 6;
            this.btnAdicionarExemplar.Text = "button2";
            this.btnAdicionarExemplar.UseVisualStyleBackColor = true;
            // 
            // btnEmprestar
            // 
            this.btnEmprestar.Location = new System.Drawing.Point(223, 85);
            this.btnEmprestar.Name = "btnEmprestar";
            this.btnEmprestar.Size = new System.Drawing.Size(75, 23);
            this.btnEmprestar.TabIndex = 7;
            this.btnEmprestar.Text = "button3";
            this.btnEmprestar.UseVisualStyleBackColor = true;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(251, 141);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(75, 23);
            this.btnDevolver.TabIndex = 8;
            this.btnDevolver.Text = "button4";
            this.btnDevolver.UseVisualStyleBackColor = true;
            // 
            // btnPesquisarSintetico
            // 
            this.btnPesquisarSintetico.Location = new System.Drawing.Point(147, 181);
            this.btnPesquisarSintetico.Name = "btnPesquisarSintetico";
            this.btnPesquisarSintetico.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisarSintetico.TabIndex = 9;
            this.btnPesquisarSintetico.Text = "button5";
            this.btnPesquisarSintetico.UseVisualStyleBackColor = true;
            // 
            // btnPesquisarAnalitico
            // 
            this.btnPesquisarAnalitico.Location = new System.Drawing.Point(123, 256);
            this.btnPesquisarAnalitico.Name = "btnPesquisarAnalitico";
            this.btnPesquisarAnalitico.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisarAnalitico.TabIndex = 10;
            this.btnPesquisarAnalitico.Text = "button6";
            this.btnPesquisarAnalitico.UseVisualStyleBackColor = true;
            // 
            // lstResultados
            // 
            this.lstResultados.FormattingEnabled = true;
            this.lstResultados.ItemHeight = 16;
            this.lstResultados.Location = new System.Drawing.Point(78, 337);
            this.lstResultados.Name = "lstResultados";
            this.lstResultados.Size = new System.Drawing.Size(120, 84);
            this.lstResultados.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstResultados);
            this.Controls.Add(this.btnPesquisarAnalitico);
            this.Controls.Add(this.btnPesquisarSintetico);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnEmprestar);
            this.Controls.Add(this.btnAdicionarExemplar);
            this.Controls.Add(this.btnAdicionarLivro);
            this.Controls.Add(this.txtTombo);
            this.Controls.Add(this.txtEditora);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtIsbn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtEditora;
        private System.Windows.Forms.TextBox txtTombo;
        private System.Windows.Forms.Button btnAdicionarLivro;
        private System.Windows.Forms.Button btnAdicionarExemplar;
        private System.Windows.Forms.Button btnEmprestar;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnPesquisarSintetico;
        private System.Windows.Forms.Button btnPesquisarAnalitico;
        private System.Windows.Forms.ListBox lstResultados;
    }
}

