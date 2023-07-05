using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class VideojuegoController : ApiController
    {
        static List<VideojuegoModel> datos = new List<VideojuegoModel>();

        [Route("api/videojuego")]
        public VideojuegoModel Post([FromBody]VideojuegoModel juego)
        {
            VideojuegoModel videojuego = new VideojuegoModel();
            videojuego.Id = juego.Id;
            videojuego.Nombre = juego.Nombre;
            videojuego.FechaDeLanzamiento = juego.FechaDeLanzamiento;
            videojuego.Genero = juego.Genero;

            datos.Add(videojuego);
            return juego;

        }

        [Route("api/videojuego/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            VideojuegoModel resultado = datos.Find(x => x.Id == id);
            if (resultado == null) return NotFound();
            datos.Remove(resultado);
            return Ok("{ 'resultado' : 'Videojuego eliminado'");

        }
        [Route("api/videojuego/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            VideojuegoModel resultado = datos.Find(x => x.Id == id);
            if (resultado == null) return NotFound();
            return Ok(resultado);

        }

        [Route("api/videojuego")]
        public List<VideojuegoModel> Get()
        {
            return datos;
        }
    }
}