namespace GuardianLog.Application.Dtos;

public class EmpresaDto
{
   public int Id { get; set; }
   public required string CNPJ { get; set; }
   public required string RazaoSocial { get; set; }
   public required string NomeFantasia { get; set; }
   public required EnderecoDto Endereco { get; set; }
   public int IdEndereco { get; set; }
   public required ContatoDto Contato { get; set; }
   public int IdContato { get; set; }
   public required TipoEmpresaDto TipoEmpresa { get; set; }
   public bool EhCliente { get; set; }
}
