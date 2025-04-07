using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class CepService(
    ICepRepository _cepRepository,
    IGeralRepository _geralRepository,
    IMapper _mapper
) : ICepService
{
    public ICepRepository CepRepository { get; } = _cepRepository;
    public IGeralRepository GeralRepository { get; } = _geralRepository;
    public IMapper Mapper { get; } = _mapper;

    public async Task<CEPResponseDto?> GetCepAsync(string numeroCep)
    {
        try
        {
            var cep = await CepRepository.GetCepAsync(numeroCep);
            if(cep == null) return null;

            return Mapper.Map<CEPResponseDto>(cep);
        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

    public async Task<CEPResponseDto?> GetCepByIdAsync(int cepId)
    {
        try
        {
            var cep = await CepRepository.GetCepByIdAsync(cepId);
            if(cep == null) return null;

            return Mapper.Map<CEPResponseDto>(cep);
        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> AddCepAsync(CEPRequestDto model)
    {
        try
        {
            var cep = Mapper.Map<CEP>(model);
            GeralRepository.Add(cep);

            return await GeralRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
