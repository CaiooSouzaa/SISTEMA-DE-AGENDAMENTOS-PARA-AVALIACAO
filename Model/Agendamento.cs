using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Enums;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Model
{
    public class Agendamento 
    {
        public Aluno Aluno { get; private set; }
        public Disciplina Disciplina { get; private set; }
        public Slot Slot { get; private set; }
        public TipoAvaliacao TipoAvaliacao { get; set; }
        public Polo Polo { get; set; }

        public Agendamento(Aluno aluno, Disciplina disciplina, Slot slot, TipoAvaliacao tipoAvaliacao, Polo polo)
        {
            Aluno = aluno ?? throw new ArgumentNullException(nameof(aluno));
            Disciplina = disciplina ?? throw new ArgumentNullException(nameof(disciplina));
            Slot = slot ?? throw new ArgumentNullException(nameof(slot));
            TipoAvaliacao = tipoAvaliacao;
            Polo = polo;
        }
    }
}