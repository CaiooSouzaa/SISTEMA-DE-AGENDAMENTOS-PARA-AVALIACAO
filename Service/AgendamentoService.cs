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

        public void ValidarCapacidadeDaSala(Aluno aluno, DateTime data, Periodo perido)
        {
            if (aluno == null)
            {
                throw new ArgumentNullException(nameof(aluno), "O aluno é obrigatório.");
            }

            var todosOsAgendamentos = _agendamentoRepository.listarAgendamentos();
        }

    }

}