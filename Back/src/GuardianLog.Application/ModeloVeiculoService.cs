using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class ModeloVeiculoService(
   IModeloVeiculoRepository _modeloVeiculoRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper
) : IModeloVeiculoService
{
   public IModeloVeiculoRepository ModeloVeiculoRepository { get; } = _modeloVeiculoRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<ModeloVeiculoDto[]?> GetModelosVeiculoByMarcaIdAsync(int marcaId)
   {
      try
      {
         var modelos = await ModeloVeiculoRepository.GetModelosVeiculoByMarcaIdAsync(marcaId);

         if (modelos == null) return null;

         return Mapper.Map<ModeloVeiculoDto[]>(modelos);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<ModeloVeiculoDto?> GetModeloVeiculoByIdAsync(int modeloId)
   {
      try
      {
         var modelo = await ModeloVeiculoRepository.GetModeloVeiculoByIdAsync(modeloId);

         if (modelo == null) return null;

         return Mapper.Map<ModeloVeiculoDto>(modelo);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }


   public async Task<bool> AddModeloAsync(ModeloVeiculoDto model)
   {
      try
      {
         var modelo = Mapper.Map<ModeloVeiculo>(model);
         GeralRepository.Add(modelo);

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<ModeloVeiculoDto?> UpdateModeloAsync(ModeloVeiculoDto model)
   {
      try
      {
         var modelo = await ModeloVeiculoRepository.GetModeloVeiculoByIdAsync(model.Id);

         if (modelo == null) return null;

         GeralRepository.Update(Mapper.Map<ModeloVeiculo>(model));

         if (await GeralRepository.SaveChangesAsync())
         {
            var retorno = Mapper.Map<ModeloVeiculoDto>(await ModeloVeiculoRepository.GetModeloVeiculoByIdAsync(model.Id));
            return retorno;
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> DeleteModeloAsync(int modeloId)
   {
      try
      {
         var modelo = await ModeloVeiculoRepository.GetModeloVeiculoByIdAsync(modeloId);

         if (modelo == null)
         {
            new Exception("Modelo não encontrado");
         }
         else
         {
            GeralRepository.Delete(modelo);
         }
         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }
}