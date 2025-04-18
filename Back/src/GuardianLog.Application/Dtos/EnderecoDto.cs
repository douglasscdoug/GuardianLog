namespace GuardianLog.Application.Dtos;

public class EnderecoDto
{
   public int Id { get; set; }
   public required string Cep { get; set; }
   public required string Logradouro { get; set; }
   public required string Bairro { get; set; }
   public int Numero { get; set; }
   public string ? Complemento { get; set; }
   public CidadeDto ? Cidade { get; set; } 
   public int IdCidade { get; set; }
   public int ? IdEmpresa { get; set; }
   public int ? IdPessoaFisica { get; set; }
}
