using Portfolio.Models;

namespace Portfolio.Services
{

    public interface IRepositorioProyectos
    {
        List<ProyectoViewModel> ObtenerProyectos();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectoViewModel> ObtenerProyectos()
        {
            return new List<ProyectoViewModel>() { new ProyectoViewModel
            {
                Titulo = "Google",
                Descripcion = "Descripción de Google",
                Link = "https://www.google.com",
                ImagenURL = "/images/googleLogo.png"
            },
            new ProyectoViewModel
            {
                Titulo = "Facebook",
                Descripcion = "Descripción de Facebook",
                Link = "https://www.facebook.com",
                ImagenURL = "/images/facebookLogo.png"
            },
            new ProyectoViewModel
            {
                Titulo = "Instagram",
                Descripcion = "Descripción de Instagram",
                Link = "https://www.instagram.com",
                ImagenURL = "/images/instagramLogo.png"
            },
            new ProyectoViewModel
            {
                Titulo = "Youtube",
                Descripcion = "Descripción de Youtube",
                Link = "https://www.youtube.com",
                ImagenURL = "/images/youtubeLogo.png"
            },
            };
        }
    }
}
