using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PROJEKAT.models
{
    public class Prodavnica
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public List<Proizvod> Proizvodi { get; set; }
    }
}