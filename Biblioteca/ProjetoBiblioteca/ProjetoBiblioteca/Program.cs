using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBiblioteca
{
    // --- CLASSES DE NEGÓCIO ---

    public class Emprestimo
    {
        public DateTime DtEmprestimo { get; private set; }
        public DateTime DtDevolucao { get; set; }

        public Emprestimo(DateTime dtEmprestimo)
        {
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = DateTime.MinValue; // MinValue indica que ainda não foi devolvido
        }
    }

    public class Exemplar
    {
        public int Tombo { get; private set; }
        public List<Emprestimo> Emprestimos { get; private set; }

        public Exemplar(int tombo)
        {
            Tombo = tombo;
            Emprestimos = new List<Emprestimo>();
        }

        public bool emprestar()
        {
            if (disponivel())
            {
                Emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }
            return false;
        }

        public bool devolver()
        {
            if (!disponivel())
            {
                Emprestimos.Last().DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool disponivel()
        {
            if (Emprestimos.Count == 0) return true;

            // Se o último empréstimo tem data de devolução preenchida (diferente de MinValue), está disponível
            return Emprestimos.Last().DtDevolucao != DateTime.MinValue;
        }

        public int qtdeEmprestimos()
        {
            return Emprestimos.Count;
        }
    }

    public class Livro
    {
        public int Isbn { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Editora { get; private set; }
        public List<Exemplar> Exemplares { get; private set; }

        // Construtor completo para adicionar ao acervo
        public Livro(int isbn, string titulo, string autor, string editora)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Exemplares = new List<Exemplar>();
        }

        // Construtor auxiliar para pesquisa por ISBN (usado no método Equals)
        public Livro(int isbn)
        {
            Isbn = isbn;
            Exemplares = new List<Exemplar>();
        }

        public void adicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int qtdeDisponiveis()
        {
            return Exemplares.Count(e => e.disponivel());
        }

        public int qtdeEmprestimos()
        {
            return Exemplares.Sum(e => e.qtdeEmprestimos());
        }

        public double percDisponibilidade()
        {
            if (qtdeExemplares() == 0) return 0;
            return ((double)qtdeDisponiveis() / qtdeExemplares()) * 100;
        }

        public override bool Equals(object obj)
        {
            if (obj is Livro outroLivro)
            {
                return this.Isbn == outroLivro.Isbn;
            }
            return false;
        }
    }

    public class Livros
    {
        private List<Livro> acervo;

        public Livros()
        {
            acervo = new List<Livro>();
        }

        public void adicionar(Livro livro)
        {
            if (pesquisar(livro) == null)
            {
                acervo.Add(livro);
            }
            else
            {
                Console.WriteLine("Livro com este ISBN já cadastrado.");
            }
        }

        public Livro pesquisar(Livro livro)
        {
            return acervo.FirstOrDefault(l => l.Equals(livro));
        }
    }

    // --- PROGRAMA PRINCIPAL (INTERFACE CONSOLE) ---

    class Program
    {
        static void Main(string[] args)
        {
            Livros biblioteca = new Livros();
            string opcao = "";

            while (opcao != "0")
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.Write("Escolha uma opção: ");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("ISBN: ");
                        int isbn = int.Parse(Console.ReadLine());
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Editora: ");
                        string editora = Console.ReadLine();

                        biblioteca.adicionar(new Livro(isbn, titulo, autor, editora));
                        Console.WriteLine("Livro adicionado com sucesso!");
                        break;

                    case "2":
                        Console.Write("Digite o ISBN do livro: ");
                        isbn = int.Parse(Console.ReadLine());
                        Livro livroSintetico = biblioteca.pesquisar(new Livro(isbn));

                        if (livroSintetico != null)
                        {
                            Console.WriteLine($"\nTítulo: {livroSintetico.Titulo} | Autor: {livroSintetico.Autor}");
                            Console.WriteLine($"Total de Exemplares: {livroSintetico.qtdeExemplares()}");
                            Console.WriteLine($"Exemplares Disponíveis: {livroSintetico.qtdeDisponiveis()}");
                            Console.WriteLine($"Total de Empréstimos: {livroSintetico.qtdeEmprestimos()}");
                            Console.WriteLine($"Disponibilidade: {livroSintetico.percDisponibilidade():F2}%");
                        }
                        else { Console.WriteLine("Livro não encontrado."); }
                        break;

                    case "3":
                        Console.Write("Digite o ISBN do livro: ");
                        isbn = int.Parse(Console.ReadLine());
                        Livro livroAnalitico = biblioteca.pesquisar(new Livro(isbn));

                        if (livroAnalitico != null)
                        {
                            Console.WriteLine($"\nTítulo: {livroAnalitico.Titulo} | Autor: {livroAnalitico.Autor}");
                            Console.WriteLine($"Total de Exemplares: {livroAnalitico.qtdeExemplares()}");
                            Console.WriteLine($"Exemplares Disponíveis: {livroAnalitico.qtdeDisponiveis()}");
                            Console.WriteLine($"Total de Empréstimos: {livroAnalitico.qtdeEmprestimos()}");
                            Console.WriteLine($"Disponibilidade: {livroAnalitico.percDisponibilidade():F2}%");

                            Console.WriteLine("\n--- Detalhes dos Exemplares ---");
                            foreach (var ex in livroAnalitico.Exemplares)
                            {
                                string status = ex.disponivel() ? "Disponível" : "Emprestado";
                                Console.WriteLine($"Tombo: {ex.Tombo} | Status: {status} | Empréstimos realizados: {ex.qtdeEmprestimos()}");

                                foreach (var emp in ex.Emprestimos)
                                {
                                    string dtDev = emp.DtDevolucao == DateTime.MinValue ? "Pendente" : emp.DtDevolucao.ToString("dd/MM/yyyy HH:mm");
                                    Console.WriteLine($"   -> Emprestado em: {emp.DtEmprestimo:dd/MM/yyyy HH:mm} | Devolvido em: {dtDev}");
                                }
                            }
                        }
                        else { Console.WriteLine("Livro não encontrado."); }
                        break;

                    case "4":
                        Console.Write("Digite o ISBN do livro para receber o exemplar: ");
                        isbn = int.Parse(Console.ReadLine());
                        Livro livroParaExemplar = biblioteca.pesquisar(new Livro(isbn));

                        if (livroParaExemplar != null)
                        {
                            Console.Write("Digite o número de Tombo do novo exemplar: ");
                            int tombo = int.Parse(Console.ReadLine());

                            // Verifica se o tombo já existe neste livro
                            if (livroParaExemplar.Exemplares.Any(e => e.Tombo == tombo))
                            {
                                Console.WriteLine("Erro: Este tombo já está cadastrado para este livro.");
                            }
                            else
                            {
                                livroParaExemplar.adicionarExemplar(new Exemplar(tombo));
                                Console.WriteLine("Exemplar adicionado com sucesso!");
                            }
                        }
                        else { Console.WriteLine("Livro não encontrado."); }
                        break;

                    case "5":
                        Console.Write("Digite o ISBN do livro solicitado: ");
                        isbn = int.Parse(Console.ReadLine());
                        Livro livroEmp = biblioteca.pesquisar(new Livro(isbn));

                        if (livroEmp != null)
                        {
                            Exemplar exDisponivel = livroEmp.Exemplares.FirstOrDefault(e => e.disponivel());
                            if (exDisponivel != null)
                            {
                                exDisponivel.emprestar();
                                Console.WriteLine($"Empréstimo registrado no exemplar Tombo: {exDisponivel.Tombo}.");
                            }
                            else { Console.WriteLine("Não há exemplares disponíveis para este livro no momento."); }
                        }
                        else { Console.WriteLine("Livro não encontrado."); }
                        break;

                    case "6":
                        Console.Write("Digite o ISBN do livro a ser devolvido: ");
                        isbn = int.Parse(Console.ReadLine());
                        Livro livroDev = biblioteca.pesquisar(new Livro(isbn));

                        if (livroDev != null)
                        {
                            Console.Write("Digite o número do Tombo do exemplar sendo devolvido: ");
                            int tomboDev = int.Parse(Console.ReadLine());

                            Exemplar exDev = livroDev.Exemplares.FirstOrDefault(e => e.Tombo == tomboDev);
                            if (exDev != null)
                            {
                                if (exDev.devolver())
                                {
                                    Console.WriteLine("Devolução registrada com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Este exemplar não consta como emprestado.");
                                }
                            }
                            else { Console.WriteLine("Tombo não encontrado para este livro."); }
                        }
                        else { Console.WriteLine("Livro não encontrado."); }
                        break;

                    case "0":
                        Console.WriteLine("Encerrando sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != "0")
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}