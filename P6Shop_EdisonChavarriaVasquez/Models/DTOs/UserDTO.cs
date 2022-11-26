namespace P6Shop_API_EdisonChavarriaVasquez.Models.DTOs
{
    public class UserDTO
    {

        // UN DTO  es el metodo mas usado para pasar estructuras entre
        //un api y una app. se hace principalmente por 3 razones:
       
        //1 para el quipo de desarrolladores (ingenieria inversa)
        // no entienda la estructura de los models en la api
        //2 simplificar objetos muy complejos , pasando la menor cantidad
        // de datos requerida 
        // si es necesario volver a generar los modelos con el scafoll - f
        //(porque hubo un cambio en la estructura )

        //nombres en español para demostrar



        public int IDUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string Contrasennia { get; set; } = null!;
        public string CorreoRespaldo { get; set; } = null!;
       
        public string  NumeroTelefono{ get; set; } = null!;
   
        public int IDRol{ get; set; }
        public int IDPais { get; set; }

        public string RolDescripcion { get; set; } = null!;

        public string PaisNombre { get; set; } = null!;
        // no es necesario en todos los casos hacer todas las relaciones





    }
}
