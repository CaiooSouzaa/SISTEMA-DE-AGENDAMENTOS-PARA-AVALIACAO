using System;
using System.Collections.Generic;
using System.Linq;
using SISTEMA_DE_AGENDAMENTO_CSHARP.Model;

namespace SISTEMA_DE_AGENDAMENTO_CSHARP.Repository
{
    public class DisciplinaRepository
    {
        private readonly List<Disciplina> _listaDisciplinas = new List<Disciplina>();

        public DisciplinaRepository()
        {
            SeedDadosTeste();
        }

        private void SeedDadosTeste()
        {
            _listaDisciplinas.AddRange(new List<Disciplina>
            {
                new Disciplina("MAT001", "Matemática Básica", 1),
                new Disciplina("POR001", "Português Instrumental", 1),
                new Disciplina("HIS001", "História do Brasil", 1),
                new Disciplina("FIS001", "Física I", 2),
                new Disciplina("QUI001", "Química Geral", 2),
                new Disciplina("MAT002", "Matemática Avançada", 2),
                new Disciplina("ING001", "Inglês Técnico", 1),
                new Disciplina("PROG001", "Introdução à Programação", 3),
                new Disciplina("BD001", "Banco de Dados", 4),
                new Disciplina("REDES001", "Redes de Computadores", 5),
                new Disciplina("ENG001", "Engenharia de Software", 6)
            });
        }

        public List<Disciplina> ListarDisciplinas()
        {
            return _listaDisciplinas.ToList();
        }

        public List<Disciplina> BuscarPorTermo(int termo)
        {
            if (termo <= 0)
                return new List<Disciplina>();

            return _listaDisciplinas
                        .Where(x => x.Termo == termo)
                        .ToList();
        }

        /// <summary>
        /// Busca disciplina pelo código (ex: "MAT001")
        /// </summary>
        public Disciplina? BuscarPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            return _listaDisciplinas.FirstOrDefault(x => 
                x.CodigoDisciplina.Equals(codigo.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public void AdicionarDisciplina(Disciplina disciplina)
        {
            if (disciplina == null)
                throw new ArgumentNullException(nameof(disciplina));

            _listaDisciplinas.Add(disciplina);
        }
    }
}