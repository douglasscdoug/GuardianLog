namespace GuardianLog.Application.Dtos;

public class EmpresaRequestDto
{
    public int Id { get; set; }
    public required string CNPJ { get; set; }
    public required string RazaoSocial { get; set; }
    public required string NomeFantasia { get; set; }
    public required EnderecoRequestDto Endereco { get; set; }
    public required ContatoDto Contato { get; set; }
    public int TipoEmpresa { get; set; }
    public bool EhCliente { get; set; }
}