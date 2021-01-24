using System.Text.Json.Serialization;
using System.Collections.Generic;


namespace PROJEKAT.models
{
    public class Dobavljac
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float Rating { get; set; }
        public List<Proizvod> Proizvodi { get; set; }
    }
}