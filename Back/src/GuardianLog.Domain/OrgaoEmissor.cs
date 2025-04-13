using GuardianLog.Domain.Enum;

namespace GuardianLog.Domain;

public class OrgaoEmissor
{
   public int Id { get; set; }
   public required string Sigla { get; set; }
   public required string NomeInstituicao { get; set; }
   public TipoOrgao TipoOrgao { get; set; }
   public List<PessoaFisica> PessoasFisicas { get; set; } = [];
}
