using System;

namespace GuardianLog.Application.Dtos;

public class EmpresaDetalheDto
{
    public int Id { get; set; }
    public required string Cnpj  { get; set; }
    public required string NomeFantasia { get; set; }
    public bool EhCliente { get; set; }
    public int TipoEmpresa { get; set; }
    public EnderecoResponseDto ? Endereco { get; set; }
    public ContatoDto ? Contato { get; set; }
}
