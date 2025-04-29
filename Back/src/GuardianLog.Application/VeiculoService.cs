using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;
using Microsoft.Extensions.Logging;

namespace GuardianLog.Application;

public class VeiculoService(
   IVeiculoRepository _veiculoRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper,
   ILogger<VeiculoService> _logger
   ) : IVeiculoService
{
   public IVeiculoRepository VeiculoRepository { get; } = _veiculoRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;
    public ILogger<VeiculoService> Logger { get; } = _logger;

    public async Task<VeiculoResponseDto[]?> GetAllVeiculosAsync()
   {
      try
      {
         var veiculos = await VeiculoRepository.GetAllVeiculos();

         if (veiculos == null)
            return null;

         var retorno = Mapper.Map<VeiculoResponseDto[]>(veiculos);

         return retorno;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoResponseDto?> GetVeiculoByIdAsync(int veiculoId)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoById(veiculoId);

         if (veiculo == null)
            return null;

         var retorno = Mapper.Map<VeiculoResponseDto>(veiculo);

         return retorno;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoResponseDto?> GetVeiculoByPlacaAsync(string placa)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoByPlaca(placa);

         if (veiculo == null)
            return null;

         var retorno = Mapper.Map<VeiculoResponseDto>(veiculo);

         return retorno;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoResponseDto?> AddVeiculoAsync(VeiculoRequestDto veiculoModel)
   {
      try
      {
         var veiculo = Mapper.Map<Veiculo>(veiculoModel);
         GeralRepository.Add(veiculo);
         if(await GeralRepository.SaveChangesAsync())
         {
            var veiculoResponse = await VeiculoRepository.GetVeiculoById(veiculo.Id);
            return Mapper.Map<VeiculoResponseDto>(veiculoResponse);
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoResponseDto?> UpdateVeiculoAsync(VeiculoRequestDto veiculoModel)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoById(veiculoModel.Id);

         if (veiculo == null)
            return null;

         veiculo = Mapper.Map<Veiculo>(veiculoModel);
         GeralRepository.Update(veiculo);

         if (await GeralRepository.SaveChangesAsync())
         {
            var retorno = Mapper.Map<VeiculoResponseDto>(await VeiculoRepository.GetVeiculoById(veiculo.Id));
            return retorno;
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }
}