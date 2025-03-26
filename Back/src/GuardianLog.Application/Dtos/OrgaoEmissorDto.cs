namespace GuardianLog.Application.Dtos;

public class OrgaoEmissorDto
{
   public int Id { get; set; }
   public required string Sigla { get; set; }
   public required string NomeInstituicao { get; set; }
   public int TipoOrgao { get; set; }
}
