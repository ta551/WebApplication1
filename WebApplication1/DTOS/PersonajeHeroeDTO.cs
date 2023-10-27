using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOS
{
    public class PersonajeHeroeDTO
    {
        //info que devuelvo sin pasar directamente por mi clase

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public string habilidad { get; set; }



    


    }
}
