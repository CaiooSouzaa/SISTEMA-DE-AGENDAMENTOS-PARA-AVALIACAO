using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Enums;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Model;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Repository;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Service
{
    public class AgendamentoService
    {
        private readonly AgendamentoRepository _agendamentoRepository;

        public AgendamentoService(AgendamentoRepository _agendamentoRepository)
        {
            this._agendamentoRepository = _agendamentoRepository;
        }

        public void ValidarLimiteDeProvasPorPeriodo(Aluno aluno, DateTime data, Periodo periodo)
        {
            if (aluno == null)
            {
                throw new ArgumentNullException(nameof(aluno), "O aluno é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(aluno.Ra))
            {
                throw new InvalidOperationException("O RA do aluno é obrigatório.");
            }

            var todosOsAgendamentos = _agendamentoRepository.listarAgendamentos();

            int quantidadeAgendamentos = todosOsAgendamentos.Count(x =>
                x.Aluno != null &&
                x.Slot != null &&
                x.Aluno.Ra == aluno.Ra &&
                x.Slot.Data.Date == data.Date &&
                x.Slot.Periodo == periodo
            );

            if (quantidadeAgendamentos >= 2)
            {
                throw new InvalidOperationException(
                    $"O aluno {aluno.Nome} não pode ser agendado, pois já possui 2 agendamentos na data {data:dd/MM/yyyy} no período {periodo}."
                );
            }
        }

        public void ValidarCapacidadeDaSala(DateTime data, Periodo periodo)
        {

            var todosOsAgendamentos = _agendamentoRepository.listarAgendamentos();

            int quantidadeAgendadosDataEPeriodo = todosOsAgendamentos.Count(x => x.Slot.Data == data.Date && x.Slot.Periodo == periodo);

            if (quantidadeAgendadosDataEPeriodo >= 20) //se o aluno querer agendar mais 2 provas no mesmo periodo do mesmo dia, não aparece para ele ou mostra a mensagem de erro
            {
                throw new InvalidOperationException(
                    $"O aluno não pode ser agendado..."
                );
            }
        }

        public void ValidarElegibilidadeExame(Aluno aluno, Disciplina disciplina, TipoAvaliacao tipoAvaliacao)
        {
            if (tipoAvaliacao != TipoAvaliacao.EXAME)
                return;

            if (aluno == null)
                throw new ArgumentNullException(nameof(aluno));

            if (disciplina == null)
                throw new ArgumentNullException(nameof(disciplina));

            var todosOsAgendamentos = _agendamentoRepository.listarAgendamentos();

            int quantidadeProvasFeitas = todosOsAgendamentos.Count(x =>
                x.Aluno.Ra == aluno.Ra &&
                x.Disciplina.CodigoDisciplina == disciplina.CodigoDisciplina &&
                (x.TipoAvaliacao == TipoAvaliacao.P1 || x.TipoAvaliacao == TipoAvaliacao.SUBSTITUTIVA));

            if (quantidadeProvasFeitas == 0)
            {
                throw new InvalidOperationException(
                    $"O aluno {aluno.Nome} não pode agendar o Exame desta disciplina. " +
                    "É necessário ter realizado pelo menos uma P1 ou Substitutiva anteriormente.");
            }
        }

    }

}