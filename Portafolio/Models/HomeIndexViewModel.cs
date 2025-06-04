namespace Portafolio.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Proyecto> Proyectos { get; set; }
        //IEnumerable -> Para recorrer colecciones
        //List -> Cuando necesitamos modificar esas colecciones agregando y eliminando elementos en tiempo de ejecución
    }
}