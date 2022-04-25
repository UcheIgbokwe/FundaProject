using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Domain.Entities
{
    public class PropertyDataModel
    {
        public string? Id { get; set; }
        public int GlobalId { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsVerhuurd { get; set; }
        public bool IsVerkocht { get; set; }
        public bool IsVerkochtOfVerhuurd { get; set; }
        public int MakelaarId { get; set; }
        public string? MakelaarNaam { get; set; }
    }
}