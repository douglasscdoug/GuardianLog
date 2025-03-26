namespace GuardianLog.Domain;

public class Endereco
{
   public int Id { get; set; }
   public required CEP Cep { get; set; }
   public int IdCep { get; set; }
   public int Numero { get; set; }
   public string ? Complemento { get; set; }
   public Empresa ? Empresa { get; set; }
   public int ? IdEmpresa { get; set; }
   public PessoaFisica ? PessoaFisica { get; set; }
   public int ? IdPessoaFisica { get; set; }
}
