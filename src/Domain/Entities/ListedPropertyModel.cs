using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Domain.Entities
{
    public class ListedPropertyModel
    {
        public int AccountStatus { get; set; }
        public bool EmailNotConfirmed { get; set; }
        public bool ValidationFailed { get; set; }
        public object? ValidationReport { get; set; }
        public int Website { get; set; }
        public Metadata? Metadata { get; set; }
        public List<PropertyDataModel>? Objects { get; set; }
        public Paging? Paging { get; set; }
        public int TotaalAantalObjecten { get; set; }
    }

    public class Metadata
    {
        public string? ObjectType { get; set; }
        public string? Omschrijving { get; set; }
        public string? Titel { get; set; }
    }
}