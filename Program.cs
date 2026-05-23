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
        var alunoRepository = new AlunoRepository();
        var disciplinaRepository = new DisciplinaRepository();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("=========================================");
            Console.WriteLine(" SISTEMA DE AGENDAMENTO DE AVALIAÇÕES");
            Console.WriteLine("=========================================");
            Console.WriteLine();

            Console.WriteLine("[1] Cadastrar aluno");
            Console.WriteLine("[2] Agendar prova");
            Console.WriteLine("[3] Listar agendamentos");
            Console.WriteLine("[0] Sair");

            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out int opt))
            {
                Console.WriteLine();
                Console.WriteLine("Opção inválida.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            Console.Clear();

            switch (opt)
            {
                case 1:
                    Console.WriteLine("=========================================");
                    Console.WriteLine(" CADASTRO DE ALUNO");
                    Console.WriteLine("=========================================");
                    Console.WriteLine();

                    Console.Write("Digite o RA do aluno: ");
                    string ra = Console.ReadLine();

                    Console.Write("Digite o nome do aluno: ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite o termo do aluno: ");
                    int termo = int.Parse(Console.ReadLine());

                    Console.Write("Digite o polo (BAURU/BOTUCATU): ");
                    Polo polo = Enum.Parse<Polo>(Console.ReadLine().ToUpper());

                    Aluno aluno = new Aluno(ra, nome, termo, polo);

                    alunoRepository.InserirAluno(aluno);

                    Console.WriteLine();
                    Console.WriteLine("Aluno cadastrado com sucesso!");

                    break;

                case 2:
                    try
                    {
                        Console.WriteLine("=========================================");
                        Console.WriteLine(" AGENDAMENTO DE PROVA");
                        Console.WriteLine("=========================================");
                        Console.WriteLine();

                        Console.Write("Digite o RA do aluno: ");
                        string raAluno = Console.ReadLine();

                        Console.Write("Digite o código da disciplina: ");
                        string disciplina = Console.ReadLine();

                        Console.Write("Digite a data da prova (dd/MM/yyyy): ");
                        DateTime data = DateTime.Parse(Console.ReadLine());

                        Console.Write("Digite o período (MANHA/TARDE/NOITE): ");
                        Periodo periodo = Enum.Parse<Periodo>(Console.ReadLine().ToUpper());

                        Console.Write("Digite o tipo da avaliação (P1/SUBSTITUTIVA/EXAME): ");
                        TipoAvaliacao tP = Enum.Parse<TipoAvaliacao>(Console.ReadLine().ToUpper());

                        Console.Write("Digite o polo (BAURU/BOTUCATU): ");
                        Polo p = Enum.Parse<Polo>(Console.ReadLine().ToUpper());

                        Console.Write("Digite o horário (HH:mm): ");
                        TimeOnly horario = TimeOnly.Parse(Console.ReadLine());

                        var alunoEncontrado = alunoRepository.BuscarAlunoPorRa(raAluno);

                        if (alunoEncontrado == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Aluno não encontrado.");
                            break;
                        }

                        var disciplinaEncontrada = disciplinaRepository.BuscarPorCodigo(disciplina);

                        if (disciplinaEncontrada == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Disciplina não encontrada.");
                            break;
                        }

                        service.Agendar(
                            alunoEncontrado,
                            disciplinaEncontrada,
                            data,
                            periodo,
                            tP,
                            p,
                            horario
                        );

                        Console.WriteLine();
                        Console.WriteLine("Agendamento realizado com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Erro ao realizar agendamento: {e.Message}");
                    }

                    break;

                case 3:

                    Console.WriteLine("=========================================");
                    Console.WriteLine(" LISTA DE AGENDAMENTOS");
                    Console.WriteLine("=========================================");
                    Console.WriteLine();

                    var agendamentos = repository.listarAgendamentos();

                    if (!agendamentos.Any())
                    {
                        Console.WriteLine("Nenhum agendamento encontrado.");
                        break;
                    }

                    foreach (Agendamento ag in agendamentos)
                    {
                        Console.WriteLine("-----------------------------------------");

                        Console.WriteLine($"Aluno...........: {ag.Aluno.Nome}");
                        Console.WriteLine($"RA...............: {ag.Aluno.Ra}");
                        Console.WriteLine($"Disciplina.......: {ag.Disciplina.Nome}");
                        Console.WriteLine($"Data.............: {ag.Slot.Data:dd/MM/yyyy}");
                        Console.WriteLine($"Horário..........: {ag.Slot.Horario}");
                        Console.WriteLine($"Período..........: {ag.Slot.Periodo}");
                        Console.WriteLine($"Tipo Avaliação...: {ag.TipoAvaliacao}");
                        Console.WriteLine($"Polo.............: {ag.Polo}");
                    }

                    Console.WriteLine("-----------------------------------------");

                    break;

                case 0:

                    Console.WriteLine("Encerrando sistema...");
                    return;

                default:

                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}