using System;
using System.Collections.Generic;

namespace dbFirst.Models
{
    public partial class Ticketing
    {
        public Ticketing()
        {
            Sadrzajs = new HashSet<Sadrzaj>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Opis { get; set; }

        public virtual ICollection<Sadrzaj> Sadrzajs { get; set; }
    }
}
