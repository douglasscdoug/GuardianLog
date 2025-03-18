namespace GuardianLog.Application.Dtos;

public class PaisDto
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public List<EstadoDto> Estados { get; set; } = [];
}
