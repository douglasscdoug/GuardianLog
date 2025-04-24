namespace GuardianLog.Application.Dtos;

public class PessoaFisicaRequestDto
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public required string Sobrenome { get; set; }
   public DateTime DataNascimento { get; set; }
   public required string NumeroCPF { get; set; }
   public required string NumeroRG { get; set; }
   public int IdOrgaoEmissor { get; set; }
   public DateTime DataEmissaoRG { get; set; }
   public int IdEstadoRG { get; set; }
   public required EnderecoRequestDto Endereco { get; set; }
   public int IdEndereco { get; set; }
   public required ContatoDto Contato { get; set; }
   public int IdContato { get; set; }
}
