using System;

namespace GuardianLog.Application.Dtos;

public class EnderecoResponseDto
{
    public int Id { get; set; }
    public required string Cep { get; set; }
    public required string Logradouro { get; set; }
    public required string Bairro { get; set; }
    public int Numero { get; set; }
    public string ? Complemento { get; set; }
    public required string Cidade { get; set; }
    public int IdCidade { get; set; }
    public required string Estado { get; set; }
    public int IdEstado { get; set; }
}
