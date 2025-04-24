using AutoMapper;
using AutoMapper.QueryableExtensions;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Application;

public class EmpresaService(
    IEmpresaRepository _empresaRepository,
    IGeralRepository _geralRepository,
    IMapper _mapper
) : IEmpresaService
{
    public IEmpresaRepository EmpresaRepository { get; } = _empresaRepository;
    public IGeralRepository GeralRepository { get; } = _geralRepository;
    public IMapper Mapper { get; } = _mapper;

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
            var query = EmpresaRepository.QueryEmpresaById(empresaId);
            var empresa = await query.ProjectTo<EmpresaDto>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();

            if(empresa == null) return null;

            return Mapper.Map<EmpresaDto>(empresa);
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
    }

    public async Task<EmpresaDto?> AddEmpresaAsync(EmpresaRequestDto model)
    {
        try
        {
            var endereco = Mapper.Map<Endereco>(model.Endereco);

            endereco = await EmpresaRepository.SalvarEnderecoAsync(endereco);

            var contato = new Contato
            {
                Telefone = model.Contato.Telefone,
                Email = model.Contato.Email
            };

            contato = await EmpresaRepository.SalvarContatoAsync(contato);

            var empresa = Mapper.Map<Empresa>(model);
            empresa.IdContato = contato.Id;
            empresa.Contato = contato;
            empresa.Endereco = endereco;
            empresa.IdEndereco = endereco.Id;
        
            GeralRepository.Add(empresa);

            if(await GeralRepository.SaveChangesAsync())
            {
                var empresaResponse = await EmpresaRepository.GetEmpresaByIdAsync(empresa.Id);
                return Mapper.Map<EmpresaDto>(empresaResponse);
            }

            return null;
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
                var empresaResponse = await EmpresaRepository.GetEmpresaByIdAsync(model.Id);
                return Mapper.Map<EmpresaDto>(empresaResponse);
            }
            return null;
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message);
        }
    }
}
