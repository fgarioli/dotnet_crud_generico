using NomeDoProjeto.Models;
using NomeDoProjeto.Services;

namespace NomeDoProjeto.Controllers
{
    public class UsuarioController : AbstractController<Usuario>
    {
        public UsuarioController(ICrudService<Usuario> service) : base(service)
        {
        }
    }
}