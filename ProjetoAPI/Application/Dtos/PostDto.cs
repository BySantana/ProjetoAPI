using System;
using System.Collections.Generic;

namespace ProjetoAPI.Application.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public string ImagemURL { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string DataPergunta { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public IEnumerable<ComentarioDto> Comentarios { get; set; }
    }
}
