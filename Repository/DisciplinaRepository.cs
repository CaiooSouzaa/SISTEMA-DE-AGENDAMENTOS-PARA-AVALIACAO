using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Model;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Repository
{
    public class DisciplinaRepository
    {
        private readonly List<Disciplina> _listaDisciplina = new List<Disciplina>();
        public List<Disciplina> ListarDisciplinas()
        {
            return _listaDisciplina.ToList();
        }

            public List<Disciplina>? BuscarPorTermo(int termo)
        {
            if(termo <= 0)
            {
                return new List<Disciplina>();
            }

            return _listaDisciplina.Where(x => x.Termo == termo).ToList();
        }
    }
}