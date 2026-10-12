using System;
using System.Windows.Forms;

namespace ProjetoBibliotecaForms
{
    public partial class Form1 : Form
    {
        private Livros biblioteca;

        public Form1()
        {
            InitializeComponent();
            biblioteca = new Livros();
        }

        private void btnAdicionarLivro_Click(object sender, EventArgs e)
        {
            try
            {
                int isbn = int.Parse(txtIsbn.Text);
                Livro novoLivro = new Livro(isbn, txtTitulo.Text, txtAutor.Text, txtEditora.Text);
                biblioteca.adicionar(novoLivro);
                MessageBox.Show("Livro adicionado ao acervo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message + " (Verifique se o ISBN é um número).");
            }
        }

        private void btnAdicionarExemplar_Click(object sender, EventArgs e)
        {
            try
            {
                int isbn = int.Parse(txtIsbn.Text);
                Livro livro = biblioteca.pesquisar(new Livro(isbn));

                if (livro != null)
                {
                    int tombo = int.Parse(txtTombo.Text);
                    livro.adicionarExemplar(new Exemplar(tombo));
                    MessageBox.Show("Exemplar adicionado com sucesso!");
                }
                else { MessageBox.Show("Livro não encontrado pelo ISBN."); }
            }
            catch { MessageBox.Show("Verifique se ISBN e Tombo são números válidos."); }
        }

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            try
            {
                int isbn = int.Parse(txtIsbn.Text);
                Livro livro = biblioteca.pesquisar(new Livro(isbn));

                if (livro != null)
                {
                    var exDisponivel = livro.Exemplares.Find(ex => ex.disponivel());
                    if (exDisponivel != null)
                    {
                        exDisponivel.emprestar();
                        MessageBox.Show($"Empréstimo realizado no exemplar Tombo {exDisponivel.Tombo}!");
                    }
                    else { MessageBox.Show("Não há exemplares disponíveis no momento."); }
                }
                else { MessageBox.Show("Livro não encontrado."); }
            }
            catch { MessageBox.Show("Verifique se o ISBN é válido."); }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                int isbn = int.Parse(txtIsbn.Text);
                Livro livro = biblioteca.pesquisar(new Livro(isbn));

                if (livro != null)
                {
                    int tombo = int.Parse(txtTombo.Text);
                    var exDev = livro.Exemplares.Find(ex => ex.Tombo == tombo);
                    if (exDev != null)
                    {
                        if (exDev.devolver()) MessageBox.Show("Devolução registada com sucesso!");
                        else MessageBox.Show("Este exemplar não consta como emprestado.");
                    }
                    else { MessageBox.Show("Tombo não encontrado para este livro."); }
                }
                else { MessageBox.Show("Livro não encontrado."); }
            }
            catch { MessageBox.Show("Verifique se ISBN e Tombo são válidos."); }
        }

        private void btnPesquisarSintetico_Click(object sender, EventArgs e)
        {
            try
            {
                int isbn = int.Parse(txtIsbn.Text);
                Livro livro = biblioteca.pesquisar(new Livro(isbn));
                lstResultados.Items.Clear();

                if (livro != null)
                {
                    lstResultados.Items.Add($"Título: {livro.Titulo} | Autor: {livro.Autor}");
                    lstResultados.Items.Add($"Total Exemplares: {livro.qtdeExemplares()}");
                    lstResultados.Items.Add($"Exemplares Disponíveis: {livro.qtdeDisponiveis()}");
                    lstResultados.Items.Add($"Total Empréstimos: {livro.qtdeEmprestimos()}");
                    lstResultados.Items.Add($"Disponibilidade: {livro.percDisponibilidade():F2}%");
                }
                else { MessageBox.Show("Livro não encontrado."); }
            }
            catch { MessageBox.Show("ISBN inválido."); }
        }

        private void btnPesquisarAnalitico_Click(object sender, EventArgs e)
        {
            btnPesquisarSintetico_Click(sender, e); // Mostra os dados gerais primeiro

            try
            {
                int isbn = int.Parse(txtIsbn.Text);
                Livro livro = biblioteca.pesquisar(new Livro(isbn));

                if (livro != null)
                {
                    lstResultados.Items.Add("--- Detalhes dos Exemplares ---");
                    foreach (var ex in livro.Exemplares)
                    {
                        string status = ex.disponivel() ? "Disponível" : "Emprestado";
                        lstResultados.Items.Add($"Tombo: {ex.Tombo} | Status: {status} | Nº de Empréstimos: {ex.qtdeEmprestimos()}");

                        foreach (var emp in ex.Emprestimos)
                        {
                            string dev = emp.DtDevolucao == DateTime.MinValue ? "Pendente" : emp.DtDevolucao.ToString("dd/MM/yyyy HH:mm");
                            lstResultados.Items.Add($"   -> Emp: {emp.DtEmprestimo:dd/MM/yyyy HH:mm} | Dev: {dev}");
                        }
                    }
                }
            }
            catch { }
        }
    }
}