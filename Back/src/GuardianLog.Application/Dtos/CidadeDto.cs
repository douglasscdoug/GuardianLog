using System;

namespace GuardianLog.Application.Dtos;

public class CidadeDto
{
   public int Id { get; set; }
   public int CodCidadeIBGE { get; set; }
   public required string NomeCidade { get; set; }
   public int IdEstado { get; set; }
}
