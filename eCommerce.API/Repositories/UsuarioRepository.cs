using eCommerce.API.Database;
using eCommerce.Models;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /*
         * A implementação automática sugerida pelo VS,
         * com base na interface, faz a implementação
         * dos métodos em ordem alfabética
         * 
         */

        private readonly eCommerceContext _db;

        public UsuarioRepository(eCommerceContext db)
        {
            _db = db;
        }

        public void Add(Usuario usuario)
        {
            // Unit of Works

            // Memory - EF Core
            _db.Add(usuario);

            // Memory > SGBD
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Remove(Get(id));
            _db.SaveChanges();
        }

        public List<Usuario> Get()
        {
            return _db.Usuarios.OrderBy(user => user.Id).ToList();
        }

        public Usuario Get(int id)
        {
            /* 
             * O "!" é um recurso que pode ser utilizado pelo DEV,
             * pra afirmar que aquela propriedade nunca será nula,
             * que sempre existirá um valor nela.
             * 
             * Existem melhores formas de garantir isso, 
             * mas por enquanto irá servir.
             */
            return _db.Usuarios.Find(id)!;
        }

        public void Update(Usuario usuario)
        {
            /*
             * Removendo o elemento (antigo) da lista, e adiciona o novo (atualizado)
             */
            
            _db.Update(usuario);
            _db.SaveChanges();
        }
    }
}
