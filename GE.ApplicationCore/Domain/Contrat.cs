using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE.ApplicationCore.Domain
{
    
    public class Contrat
    {
        
        
        public virtual Equipe Equipe { get; set; }
        [ForeignKey("Equipe")]
        public int EquipeFK { get; set; }
        

        public virtual Membre Member { get; set; }
        [ForeignKey("Member")]
        public int MembreFK { get; set; }
        
        [Key]
        public DateTime DateContrat { get; set; }
        [Range(0,24)]
        [Display(Name = "Duree de contrat")]
        public Int16 DureeMMois { get; set; }
        public double Salaire { get; set; }


    }
    
}
