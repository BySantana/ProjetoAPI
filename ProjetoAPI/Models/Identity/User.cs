using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjetoAPI.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string NivelExperiencia { get; set; }
        public string Descricao { get; set; }
        public string ImagemURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
        public IEnumerable<Interacao> Interacoes { get; set; }

    }
}
