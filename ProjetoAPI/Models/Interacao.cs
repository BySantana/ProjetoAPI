using ProjetoAPI.Models.Identity;

namespace ProjetoAPI.Models
{
    public class Interacao
    {
        public int InteracaoId { get; set; }
        public string InteracaoTexto { get; set; }
        public string DataInteracao { get; set; }
        public int ComentarioId { get; set; }
        public Comentario Comentario { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
