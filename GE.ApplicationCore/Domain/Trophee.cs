using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GE.ApplicationCore.Domain
{
    public class Trophee
    {
        [DataType(DataType.Date)]
        public DateTime DateTrophee { get; set; }
        [DataType(DataType.Currency)]
        public Double Recompense { get; set; }
        public int TropheeId { get; set; }
        public virtual Equipe Equipe { get; set; }
        public int EquipeFK { get; set; }
    }
}
