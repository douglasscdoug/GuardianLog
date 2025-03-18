namespace GuardianLog.Application.Dtos;

public class EstadoDto
{
   public int Id { get; set; }
   public int CodUFIBGE { get; set; }
   public required string UF { get; set; }
   public required string NomeEstado { get; set; }
   public int IdPais { get; set; }
   public List<CidadeDto> Cidades { get; set; } = [];
}
