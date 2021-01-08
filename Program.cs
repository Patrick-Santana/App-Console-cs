using System;

namespace Rev
{
    class Program
    {
        static void Main(string[] args)
        {
            Livro[] livros = new Livro[7];

            var indiceLivro = 0;
 
           // ObterOpcao();

            String opcaouser = ObterOpcao();

            while (opcaouser.ToUpper() != "X")
            {
                switch (opcaouser)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do livro");
                        Livro livro = new Livro();
                        livro.Titulo =  Console.ReadLine();

                        Console.WriteLine("Informe a nota do Livro");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            livro.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal!");
                        }

                        livros[indiceLivro] = livro;
                        
                        indiceLivro++;
                        break;
                    case "2":
                        foreach (var books in livros)
                        {   
                            if (!string.IsNullOrEmpty(books.Titulo))
                            {
                            
                            Console.WriteLine($"Livros: {books.Titulo} - Notas: {books.Nota}");
                                
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrLivros = 0;

                        for (var i = 0; i < livros.Length; i++)
                        {
                           if (!string.IsNullOrEmpty(livros[i].Titulo))
                           {
                               notaTotal = notaTotal + livros[i].Nota;
                               nrLivros++;
                           }
                        }

                        var mediaGeral = notaTotal / nrLivros;
                        Console.WriteLine($"Média Geral de Avaliação dos livros {mediaGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaouser = ObterOpcao();
            }
        }

        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a Opção desejada");
            Console.WriteLine("1- Informe um livro");
            Console.WriteLine("2- Listar os Livros");
            Console.WriteLine("3- Média Geral da Nota de livro");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            
            string opcaouser = Console.ReadLine();
            Console.WriteLine();
            return opcaouser;
        }
    }
}
