using System;

namespace GuardianLog.Application.Dtos;

public class ContatoDto
{
   public int Id { get; set; }
   public required string Telefone { get; set; }
   public required string Email { get; set; }
   public int ? IdEmpresa { get; set; }
   public int ? IdPessoaFisica { get; set; }
}
