using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TopAgentsModel
    {
        public int MakelaarId { get; set; }
        public string? MakelaarNaam { get; set; }
        public int NumberOfProperties { get; set; }
    }
}