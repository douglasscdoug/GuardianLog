using GuardianLog.Domain.Enum;

namespace GuardianLog.Domain;

public class Motorista : PessoaFisica
{
   public required string NumeroCNH { get; set; }
   public required string NumeroRegistroCNH { get; set; }
   public DateTime DataEmissaoCNH { get; set; }
   public DateTime DataVencimentoCNH { get; set; }
   public CategoriaCNH CategoriaCNH { get; set; }
   public TipoVinculo TipoVinculo { get; set; }
}
