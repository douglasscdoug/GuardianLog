namespace GuardianLog.Application.Dtos;

public class MotoristaDto
{
   public required string NumeroCNH { get; set; }
   public required string NumeroRegistroCNH { get; set; }
   public DateTime DataEmissaoCNH { get; set; }
   public DateTime DataVencimentoCNH { get; set; }
   public required CategoriaCNHDto CategoriaCNH { get; set; }
   public required TipoVinculoDto TipoVinculo { get; set; }
}
