using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Model
{
    public class Disciplina
    {
        public string CodigoDisciplina { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public int Termo { get; set; }

        public Disciplina(){}

        public Disciplina(string codigoDisciplina, string nome, int termo)
        {
            CodigoDisciplina = codigoDisciplina;
            Nome = nome;
            Termo = termo;
        }
    }
}