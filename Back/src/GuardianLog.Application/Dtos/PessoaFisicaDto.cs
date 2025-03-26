namespace GuardianLog.Application.Dtos;

public class PessoaFisicaDto
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public required string Sobrenome { get; set; }
   public DateTime DataNascimento { get; set; }
   public required string NumeroCPF { get; set; }
   public required string NumeroRG { get; set; }
   public required OrgaoEmissorDto OrgaoEmissor { get; set; }
   public int IdOrgaoEmissor { get; set; }
   public DateTime DataEmissaoRG { get; set; }
   public required EstadoDto Estado { get; set; }
   public int IdEstadoRG { get; set; }
   public required EnderecoDto Endereco { get; set; }
   public int IdEndereco { get; set; }
   public required ContatoDto Contato { get; set; }
   public int IdContato { get; set; }
}
