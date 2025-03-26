using System;

namespace GuardianLog.Application.Dtos;

public class MarcaVeiculoDto
{
   public int Id { get; set; }
   public required string Nome { get; set; }
   public List<ModeloVeiculoDto> Modelos { get; set; } = [];
}
