using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Model;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Repository
{
    public class AlunoRepository
    {
        private readonly List<Aluno> _listaAlunos = new List<Aluno>();

        public void InserirAluno(Aluno aluno)
        {
            if (aluno == null)
                throw new ArgumentNullException(nameof(aluno));

            if (string.IsNullOrWhiteSpace(aluno.Ra) || string.IsNullOrWhiteSpace(aluno.Nome))
            {
                throw new ArgumentException("RA e Nome são obrigatórios.");
            }

            if (aluno.Termo <= 0)
            {
                throw new ArgumentException("Termo deve ser maior que zero.");
            }

            if (aluno.Polo == null) 
            {
                throw new ArgumentException("Polo é obrigatório.");
            }

            if (_listaAlunos.Any(a => a.Ra.Equals(aluno.Ra, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Já existe um aluno com o RA {aluno.Ra}.");
            }

            _listaAlunos.Add(aluno);
        }

        public Aluno? BuscarAlunoPorRa(string ra)
        {
            if (string.IsNullOrWhiteSpace(ra))
                return null;

            return _listaAlunos.Find(x => x.Ra.Equals(ra, StringComparison.OrdinalIgnoreCase));
        }

        public List<Aluno> ListarTodos()
        {
            return _listaAlunos.ToList();
        }
    }
}