using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController: Controller
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost(Name = "CadastrarFilme")]
        public IActionResult CadastrarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarFilmes), new { Id = filme.Id }, filme);
        }

        [HttpGet("{id?}", Name = "BuscarFilmes")]
        public IActionResult BuscarFilmes(int? id)
        {
            if (id == null)
            {
                var filmes = _context.Filmes;
                var filmesRetorno = _mapper.Map<IEnumerable<ReadFilmeDto>>(filmes);

                return Ok(filmesRetorno);
            }

            Filme? filmeBuscado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filmeBuscado != null)
            {
                return Ok(filmeBuscado);
            }

            return NotFound();
        }

        [HttpPut("{id}", Name = "AtualizarFilme")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme? filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if(filme ==  null)
            {
                return NotFound();
            }

            filme = _mapper.Map(filmeDto, filme);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}", Name = "RemoverFilme")]
        public IActionResult RemoverFilme(int id)
        {
            Filme? filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            _context.Filmes.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
