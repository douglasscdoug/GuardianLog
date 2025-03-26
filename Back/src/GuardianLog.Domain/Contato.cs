namespace GuardianLog.Domain;

public class Contato
{
   public int Id { get; set; }
   public required string Telefone { get; set; }
   public required string Email { get; set; }
   public Empresa ? Empresa { get; set; }
   public int ? IdEmpresa { get; set; }
   public PessoaFisica ? PessoaFisica { get; set; }
   public int ? IdPessoaFisica { get; set; }
}
