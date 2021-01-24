using System.Text.Json.Serialization;

namespace PROJEKAT.models
{
    public class Proizvod
    {
        public int ID { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public int Cena { get; set; }
        public int Kolicina { get; set;}

        [JsonIgnore]
        public Prodavnica Prodavnica { get; set; }

        [JsonIgnore]
        public Dobavljac Dobavljac { get; set; }
        
    }
}