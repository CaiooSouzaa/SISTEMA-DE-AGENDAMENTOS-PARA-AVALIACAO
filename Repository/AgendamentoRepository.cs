using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Enums;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Model;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Repository
{
    public class AgendamentoRepository
    {
        private readonly List<Agendamento> _listaAgendamento = new List<Agendamento>();

        public List<Agendamento> listarAgendamentos()
        {
            return _listaAgendamento.ToList();
        }

        public Agendamento? BuscaDetalhadaAgendamentos(Aluno aluno, DateTime data, Periodo periodo)
        {
            if(aluno == null || data == null || periodo == null)
            {
                throw new InvalidOperationException($"Digite os dados");
            }
            return _listaAgendamento.Find(x => x.Aluno == aluno && x.Slot.Data == data && x.Slot.Periodo == periodo);
        }

        public void Adicionar(Agendamento agendamento)
        {
            _listaAgendamento.Add(agendamento);
        }
    }
}