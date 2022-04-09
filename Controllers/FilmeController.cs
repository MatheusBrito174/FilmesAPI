using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController
    {
        private static List<Filme> _filmes = new List<Filme>();
        
        [HttpGet(Name = "GetFilmes")]
        public IEnumerable<Filme> Get()
        {
            return _filmes;
        }

        [HttpPost(Name = "PostFilme")]
        public void cadastrarFilme([FromBody] Filme filme)
        {
            _filmes.Add(filme);
        }
    }
}
