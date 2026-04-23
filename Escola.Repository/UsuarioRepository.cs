using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.Entities;
using Escola.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Escola.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {

        private readonly EscolaDbContext _db;

        public UsuarioRepository(EscolaDbContext escolaDbContext)
        {
            _db = escolaDbContext;
        }





        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            
            var usuarioExiste = await _db.Usuarios.FirstOrDefaultAsync(a => a.Email == usuario.Email);

            if (usuarioExiste != null)
            {
                throw new Exception("Usuário já existe com esse email.");
            }

            

            await _db.Usuarios.AddAsync(usuario);
            
            await _db.SaveChangesAsync();

            return usuario;



        }




        public async Task<Usuario> ObterPorEmailESenha(string email, string senha)
        {

            var usuario = await _db.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);


          
            return usuario;

        }


        public async Task<Usuario> ObterUsuario(string email)
        {
           

            var usuario = await _db.Usuarios.FirstOrDefaultAsync(u => u.Email == email);



            return usuario;

        }




    }
}
