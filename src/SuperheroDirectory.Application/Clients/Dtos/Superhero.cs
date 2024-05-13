namespace SuperheroDirectory.Application.Clients.Dtos
{
    public class Superhero : SuperheroBase
    {
        public Powerstats Powerstats { set; get; }

        public Biography Biography { set; get; }

        public Appearance Appearance { set; get; }

        public Work Work { set; get; }

        public Connections Connections { set; get; }

        public Image Image { set; get; }
    }
}
