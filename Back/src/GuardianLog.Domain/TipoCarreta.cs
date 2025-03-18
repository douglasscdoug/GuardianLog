using System;

namespace GuardianLog.Domain;

public class TipoCarreta
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public DateTime DataCadastro { get; set; }
   public DateTime ? DataAlteracao { get; set; }
   public List<Veiculo> Veiculos { get; set; } = [];
}
