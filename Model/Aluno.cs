using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Enums;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Model
{
    public class Aluno
    {
        public string Ra { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public int Termo { get; set; }
        public Polo Polo { get; set; }

        public Aluno(){}

        public Aluno(string ra, string nome, int termo, Polo polo)
        {
            Ra = ra ;
            Nome = nome;
            Termo = termo;
            Polo = polo;
        }
    }
}