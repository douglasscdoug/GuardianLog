using System;
using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class MotoristaService(
    IMotoristaRepository _motoristaRepository,
    IGeralRepository _geralRepository,
    IMapper _mapper
) : IMotoristaService
{
    public IMotoristaRepository MotoristaRepository { get; } = _motoristaRepository;
    public IGeralRepository GeralRepository { get; } = _geralRepository;
    public IMapper Mapper { get; } = _mapper;

    public async Task<MotoristaDto[]?> GetAllMotoristasAsync()
    {
        try
        {
            var motoristas = await MotoristaRepository.GetAllMotoristasAsync();

            if(motoristas == null) return null;

            return Mapper.Map<MotoristaDto[]>(motoristas);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<MotoristaDto[]?> GetMotoristasByNomeAsync(string nomeMotorista)
    {
        try
        {
            var motoristas = await MotoristaRepository.GetMotoristasByNomeAsync(nomeMotorista);

            if(motoristas == null) return null;

            return Mapper.Map<MotoristaDto[]>(motoristas);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<MotoristaDto?> GetMotoristaByIdAsync(int motoristaId)
    {
        try
        {
            var motorista = await MotoristaRepository.GetMotoristaByIdAsync(motoristaId);

            if(motorista == null) return null;

            return Mapper.Map<MotoristaDto>(motorista);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> AddMotoristaAsync(MotoristaDto model)
    {
        try
        {
            var motorista = Mapper.Map<Motorista>(model);

            var contato = Mapper.Map<Contato>(model.Contato);
            contato = await MotoristaRepository.SalvarContatoAsync(contato);

            var endereco = Mapper.Map<Endereco>(model.Endereco);
            endereco = await MotoristaRepository.SalvarEnderecoAsync(endereco);

            motorista.Contato = contato;
            motorista.IdContato = contato.Id;
            motorista.Endereco = endereco;
            motorista.IdEndereco = endereco.Id;

            GeralRepository.Add(motorista);

            return await GeralRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<MotoristaDto?> UpdateMotoristaAsync(MotoristaDto model)
    {
        try
        {
            var motorista = await MotoristaRepository.GetMotoristaByIdAsync(model.Id);

            if(motorista == null) return null;

            motorista = Mapper.Map<Motorista>(model);
            GeralRepository.Update(motorista);

            if(await GeralRepository.SaveChangesAsync())
            {
                var motoristaRetorno = await MotoristaRepository.GetMotoristaByIdAsync(motorista.Id);
                return Mapper.Map<MotoristaDto>(motoristaRetorno);
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeletemotoristaAsync(int motoristaId)
    {
        try
        {
            var result = await MotoristaRepository.DeleteMotoristaAsync(motoristaId);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
