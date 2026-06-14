namespace Abstracciones.Modelos
{
    public class PostalBase
    {
        public int Numero { get; set; }
        public string Posicion { get; set; }
        public bool Tengo { get; set; }
        public string Notas { get; set; }
        public DateTime FechaAgregada { get; set; }
    }

    public class PostalRequest : PostalBase
    {
        public Guid IdPais { get; set; }
        public Guid IdGrupo { get; set; }
    }

    public class PostalResponse : PostalBase
    {
        public Guid Id { get; set; }
        public string Pais { get; set; }
        public string Grupo { get; set; }
    }
}
