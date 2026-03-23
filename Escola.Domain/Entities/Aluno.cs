using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Entities
{
    public class Aluno
    {

        public Aluno()
        {
            AlunoId = Guid.NewGuid();
            NomeAluno = String.Empty;
            Email = String.Empty;
        }

        public int Id { get; set; }
        public Guid AlunoId { get; set; }
        public string NomeAluno { get; set; }

        public string Email { get; set; }

        public Escola Escola { get; set; }  
    }
}
