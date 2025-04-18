using System.Text.Json.Serialization;

namespace GuardianLog.Domain;

public class Endereco
{
   public int Id { get; set; }
   public required string Cep { get; set; }
   public required string Logradouro { get; set; }
   public required string Bairro { get; set; }
   public int Numero { get; set; }
   public string ? Complemento { get; set; }
   public Cidade ? Cidade { get; set; }
   public int IdCidade { get; set; }

   [JsonIgnore]
   public Empresa ? Empresa { get; set; }
   public int ? IdEmpresa { get; set; }

   [JsonIgnore]
   public PessoaFisica ? PessoaFisica { get; set; }
   public int ? IdPessoaFisica { get; set; }
}
