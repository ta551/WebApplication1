using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.DATA;
using WebApplication1.DTOS;

namespace WebApplication1.Services
{
    public class HeroeService
    {

        private readonly HeroeDB _context;
        private readonly IMapper _mapper;

        public HeroeService(IConfiguration configuration, IMapper mapper, HeroeDB context)
        {
            _context = context;

            _mapper = mapper;

        }
        public async Task<IEnumerable<PersonajeHeroeDTO>> ListarHeroes()
        {
            // Realiza una consulta a la base de datos para devolver todos los heroes
            var heroes = await _context.Heroe
                .Include(h => h.habilidad)
                .ToListAsync();

            var heroesdto = _mapper.Map<List<PersonajeHeroeDTO>>(heroes);

            // Devuelve la lista de heroes
            return heroesdto;



        }

        public async Task<PersonajeHeroeDTO> BuscarHeroe(string nombre)
        { 
        
             var heroe = await _context.Heroe
                .Include(h => h.habilidad)
                .FirstOrDefaultAsync();

            var heroedto = _mapper.Map<PersonajeHeroeDTO>(heroe);

            // Devuelve heroe supuestamente xD
            return heroedto;
        
        }


    }
}
