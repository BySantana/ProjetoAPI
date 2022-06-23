using ProjetoAPI.Models.Identity;
using System;
using System.Collections.Generic;

namespace ProjetoAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public string ImageUrl { get; set; }
        //public IEnumerable<string> Tags { get; set; }
        public DateTime DataPergunta { get; set; } = new DateTime();
        public bool Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
        
    }
}
