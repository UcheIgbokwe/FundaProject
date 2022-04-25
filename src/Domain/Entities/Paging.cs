using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Domain.Entities
{
    public class Paging
    {
        public int AantalPaginas { get; set; }
        public int HuidigePagina { get; set; }
        public string? VolgendeUrl { get; set; }
        public object? VorigeUrl { get; set; }
    }
}