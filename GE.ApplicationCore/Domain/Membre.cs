using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE.ApplicationCore.Domain
{
    public class Membre 
    {
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        [Key]
        public int Identifiant { get; set; }
        [MaxLength(10 , ErrorMessage = "Le nom doit contenir au max 15 caractères")]
        [MinLength(3, ErrorMessage = "le nom doit contenir au min 3 caractères")]
        public String Nom { get; set; }
        [MaxLength(10, ErrorMessage = "Le prénom doit contenir au max 15 caractères")]
        [MinLength(3, ErrorMessage = "le prénom doit contenir au min 3 caractères")]
        public String Prenom {get; set;}
        
        public virtual List<Contrat> Contrats { get; set; }
        
        
        
        

    }
}
