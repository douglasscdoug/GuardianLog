namespace GuardianLog.Application.Dtos;

public class EnderecoDto
{
   public int Id { get; set; }
   public required CEPDto Cep { get; set; }
   public int IdCep { get; set; }
   public int Numero { get; set; }
   public string ? Complemento { get; set; }
   public int ? IdEmpresa { get; set; }
   public int ? IdPessoaFisica { get; set; }
}
