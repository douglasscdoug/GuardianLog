using GuardianLog.Domain.Enum;

namespace GuardianLog.Domain;

public class Empresa
{
   public int Id { get; set; }
   public required string CNPJ { get; set; }
   public required string RazaoSocial { get; set; }
   public required string NomeFantasia { get; set; }
   public required Endereco Endereco { get; set; }
   public int IdEndereco { get; set; }
   public required Contato Contato { get; set; }
   public int IdContato { get; set; }
   public TipoEmpresa TipoEmpresa { get; set; }
   public bool EhCliente { get; set; }
}
