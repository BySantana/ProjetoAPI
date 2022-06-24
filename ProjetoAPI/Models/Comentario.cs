using ProjetoAPI.Models.Identity;
using System;
using System.Collections.Generic;

namespace ProjetoAPI.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string ComentarioTexto { get; set; }
        public int Like { get; set; }
        public string DataComentario { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public IEnumerable<Interacao> Interacoes { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
