using System;
using System.Collections.Generic;
using System.Linq;

public class Emprestimo
{
    public DateTime DtEmprestimo { get; private set; }
    public DateTime DtDevolucao { get; set; }

    public Emprestimo(DateTime dtEmprestimo)
    {
        DtEmprestimo = dtEmprestimo;
        DtDevolucao = DateTime.MinValue; // MinValue indica que não foi devolvido
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

    public Livro(int isbn, string titulo, string autor, string editora)
    {
        Isbn = isbn;
        Titulo = titulo;
        Autor = autor;
        Editora = editora;
        Exemplares = new List<Exemplar>();
    }

    // Construtor auxiliar para pesquisa
    public Livro(int isbn)
    {
        Isbn = isbn;
        Exemplares = new List<Exemplar>();
    }

    public void adicionarExemplar(Exemplar exemplar)
    {
        Exemplares.Add(exemplar);
    }

    public int qtdeExemplares() => Exemplares.Count;
    public int qtdeDisponiveis() => Exemplares.Count(e => e.disponivel());
    public int qtdeEmprestimos() => Exemplares.Sum(e => e.qtdeEmprestimos());

    public double percDisponibilidade()
    {
        if (qtdeExemplares() == 0) return 0;
        return ((double)qtdeDisponiveis() / qtdeExemplares()) * 100;
    }

    public override bool Equals(object obj)
    {
        if (obj is Livro outroLivro)
            return this.Isbn == outroLivro.Isbn;
        return false;
    }
}

public class Livros
{
    private List<Livro> acervo;
    public Livros() { acervo = new List<Livro>(); }

    public void adicionar(Livro livro)
    {
        if (pesquisar(livro) == null) acervo.Add(livro);
        else throw new Exception("Livro com este ISBN já existe.");
    }

    public Livro pesquisar(Livro livro)
    {
        return acervo.FirstOrDefault(l => l.Equals(livro));
    }
}