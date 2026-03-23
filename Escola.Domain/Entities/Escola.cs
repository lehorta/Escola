using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Entities
{
    public class Escola
    {

        public Escola()
        {
            NomeEscola = String.Empty;
        }
        public int Id { get; set; }

        public Guid EscolaId { get; set; }

        public string NomeEscola { get; set; }
    

    }
}
