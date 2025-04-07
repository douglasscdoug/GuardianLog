using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class EmpresaService(
    IEmpresaRepository _empresaRepository,
    IGeralRepository _geralRepository,
    IMapper _mapper,
    ICepService _cepService
) : IEmpresaService
{
    public IEmpresaRepository EmpresaRepository { get; } = _empresaRepository;
    public IGeralRepository GeralRepository { get; } = _geralRepository;
    public IMapper Mapper { get; } = _mapper;
    public ICepService CepService { get; } = _cepService;

    public async Task<EmpresaDto[]?> GetAllEmpresasAsync()
    {
        try
        {
            var empresas = await EmpresaRepository.GetAllEmpresasAsync();

            if(empresas == null) return null;

            return Mapper.Map<EmpresaDto[]>(empresas);
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
    }

    public async Task<EmpresaDto[]?> GetEmpresasByNomeAsync(string nomeEmpresa)
    {
        try
        {
            var empresas = await EmpresaRepository.GetEmpresasByNomeAsync(nomeEmpresa);

            if(empresas == null) return null;

            return Mapper.Map<EmpresaDto[]>(empresas);
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
    }

    public async Task<EmpresaDto?> GetEmpresaByIdAsync(int empresaId)
    {
        try
        {
            var empresa = await EmpresaRepository.GetEmpresaByIdAsync(empresaId);

            if(empresa == null) return null;

            return Mapper.Map<EmpresaDto>(empresa);
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> AddEmpresaAsync(EmpresaRequestDto model)
    {
        try
        {
            var cepExiste = await CepService.GetCepByIdAsync(model.Endereco.IdCep)?? throw new Exception("CEP inválido!");
            
            var endereco = new Endereco
            {
                IdCep = model.Endereco.IdCep,
                Numero = model.Endereco.Numero,
                Complemento = model.Endereco.Complemento
            };
            endereco = await EmpresaRepository.SalvarEnderecoAsync(endereco);

            var contato = new Contato
            {
                Telefone = model.Contato.Telefone,
                Email = model.Contato.Email
            };

            var empresa = Mapper.Map<Empresa>(model);
            empresa.IdEndereco = endereco.Id;
            empresa.Endereco = endereco;
            empresa.Contato = contato;
        
            GeralRepository.Add(empresa);

            return await GeralRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
    }

    public async Task<EmpresaDto?> UpdateEmpresaAsync(EmpresaRequestDto model)
    {
        try
        {
            var empresa = await EmpresaRepository.GetEmpresaByIdAsync(model.Id);

            if(empresa == null) return null;

            empresa = Mapper.Map<Empresa>(model);
            GeralRepository.Update(empresa);

            if(await GeralRepository.SaveChangesAsync())
            {
                return Mapper.Map<EmpresaDto>(await EmpresaRepository.GetEmpresaByIdAsync(model.Id));
            }
            return null;
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
    }
}
