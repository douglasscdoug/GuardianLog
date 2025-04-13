namespace GuardianLog.Domain;

public class Estado
{
   public int Id { get; set; }
   public int CodUFIBGE { get; set; }
   public required string UF { get; set; }
   public required string NomeEstado { get; set; }
   public required Pais Pais { get; set; }
   public int IdPais { get; set; }
   public List<Cidade> Cidades { get; set; } = [];
   public List<PessoaFisica> PessoasFisicas { get; set; } = [];
}
