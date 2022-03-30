using System;
using System.Collections.Generic;

namespace dbFirst.Models
{
    public partial class Sadrzaj
    {
        public int Id { get; set; }
        public int IdTicketing { get; set; }
        public string Sadrzaj1 { get; set; } = null!;

        public virtual Ticketing IdTicketingNavigation { get; set; } = null!;
    }
}
