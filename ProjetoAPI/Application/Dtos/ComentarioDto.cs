using System;

namespace ProjetoAPI.Application.Dtos
{
    public class ComentarioDto
    {
        public int ComentarioId { get; set; }
        public string ComentarioTexto { get; set; }
        public int Like { get; set; }
        public DateTime DataComentario { get; set; }
        public int PostId { get; set; }
        public PostDto Post { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
