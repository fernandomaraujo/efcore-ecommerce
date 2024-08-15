using eCommerce.Models;

namespace eCommerce.RewritingAPI.Repositories
{
    public interface IUsuarioRepository
    {
        /*
         * CRUD - Create, Read/Retrieve, Update e Delete.
         */
        List<Usuario> Get();
        Usuario Get(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}
