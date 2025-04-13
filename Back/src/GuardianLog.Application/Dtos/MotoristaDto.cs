namespace GuardianLog.Application.Dtos;

public class MotoristaDto : PessoaFisicaRequestDto
{
   public required string NumeroCNH { get; set; }
   public required string NumeroRegistroCNH { get; set; }
   public DateTime DataEmissaoCNH { get; set; }
   public DateTime DataVencimentoCNH { get; set; }
   public int CategoriaCNH { get; set; }
   public int TipoVinculo { get; set; }
}
