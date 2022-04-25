using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Domain.Entities
{
    public class ListedPropertyByAgentModel
    {
        public int MakelaarId { get; set; }
        public string? MakelaarNaam { get; set; }
        public List<PropertyDataModel>? Objects { get; set; }
    }
}