using SISTEMA_DE_AGENDAMENTO_CSHARP.Enums;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Model;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Repository;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        var repository = new AgendamentoRepository();
        var service = new AgendamentoService(repository);
        var AlunoRepository = new AlunoRepository();

        while (true)
        {

            Console.WriteLine("Escolha uma das opções abaixo");

            Console.WriteLine("[1] Cadastrar aluno");

            Console.WriteLine("[2] Agenda prova");

            Console.WriteLine("[3] Listar agendamento");

            Console.WriteLine("[0] Sair");

            int opt = int.Parse(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    Console.Write("RA do aluno: ");
                    string ra = Console.ReadLine();
                    Console.Write("Nome do aluno: ");
                    string nome = Console.ReadLine();
                    Console.Write("Termo: ");
                    int termo = int.Parse(Console.ReadLine());
                    Console.Write("Digite o periodo (Ex: BAURU ou BOTUCATU): ");
                    Polo polo = Enum.Parse<Polo>(Console.ReadLine());

                    Aluno aluno = new Aluno(ra, nome, termo, polo);


                    break;
            }
        }
    }
}