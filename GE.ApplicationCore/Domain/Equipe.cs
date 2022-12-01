using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE.ApplicationCore.Domain
{
    public class Equipe
    {
        public String AdresseLocal { get; set; }
        [Key]
        public int EquipeId { get; set; }
        public String Logo { get; set; }
        public String NomEquipe { get; set; }
        public virtual List<Trophee> Trophees { get; set; }

        public virtual List<Contrat> Contrats { get; set; }

    }
}
