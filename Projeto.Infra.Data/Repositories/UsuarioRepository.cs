using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private DataContext dataContext;

        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Usuario Get(string email)
        {
            return dataContext.Usuario
                .FirstOrDefault(u=>u.Email.Equals(email));
        }

        public Usuario Get(string email, string senha)
        {
            return dataContext.Usuario
                .FirstOrDefault(u => u.Email.Equals(email)
                                        && u.Senha.Equals(senha));
        }
    }
}
