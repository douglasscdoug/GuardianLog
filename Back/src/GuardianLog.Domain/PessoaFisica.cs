namespace GuardianLog.Domain;

public class PessoaFisica
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public required string Sobrenome { get; set; }
   public DateTime DataNascimento { get; set; }
   public required string NumeroCPF { get; set; }
   public required string NumeroRG { get; set; }
   public required OrgaoEmissor OrgaoEmissor { get; set; }
   public int IdOrgaoEmissor { get; set; }
   public DateTime DataEmissaoRG { get; set; }
   public required Estado Estado { get; set; }
   public int IdEstadoRG { get; set; }
   public required Endereco Endereco { get; set; }
   public int IdEndereco { get; set; }
   public required Contato Contato { get; set; }
   public int IdContato { get; set; }
}
