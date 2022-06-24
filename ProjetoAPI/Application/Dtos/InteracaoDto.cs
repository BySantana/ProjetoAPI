namespace ProjetoAPI.Application.Dtos
{
    public class InteracaoDto
    {
        public int InteracaoId { get; set; }
        public string InteracaoTexto { get; set; }
        public string DataInteracao { get; set; }
        public int ComentarioId { get; set; }
        public ComentarioDto Comentario { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
