using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class TipoVeiculoService(
   ITipoVeiculoRepository _tipoVeiculoRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper
) : ITipoVeiculoService
{
   public ITipoVeiculoRepository TipoVeiculoRepository { get; } = _tipoVeiculoRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<TipoVeiculoDto[]?> GetAllTiposVeiculoAsync()
   {
      try
      {
         var tpsVeiculo = await TipoVeiculoRepository.GetAllTiposVeiculoAsync();

         if (tpsVeiculo == null) return null;

         return Mapper.Map<TipoVeiculoDto[]>(tpsVeiculo);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<TipoVeiculoDto?> GetTipoVeiculoByIdAsync(int tpVeiculoId)
   {
      try
      {
         var tpVeiculo = await TipoVeiculoRepository.GetTipoVeiculoByIdAsync(tpVeiculoId);

         if (tpVeiculo == null) return null;

         return Mapper.Map<TipoVeiculoDto>(tpVeiculo);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> SalvarTipoVeiculoAsync(TipoVeiculoDto model)
   {
      try
      {
         var tpVeiculo = Mapper.Map<TipoVeiculo>(model);

         GeralRepository.Update(tpVeiculo);

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }
}