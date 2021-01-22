using System.Text.Json.Serialization;

namespace PROJEKAT.models
{
    public class Dobavljac
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float Rating { get; set; }
    }
}