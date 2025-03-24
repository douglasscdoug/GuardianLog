using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class MarcaVeiculoService(
   IMarcaVeiculoRepository _marcaVeiculoRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper
) : IMarcaVeiculoService
{
   public IMarcaVeiculoRepository MarcaVeiculoRepository { get; } = _marcaVeiculoRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<MarcaVeiculoDto[]?> GetAllMarcasVeiculosAsync()
   {
      try
      {
         var marcas = await MarcaVeiculoRepository.GetAllMarcasVeiculosAsync();

         if (marcas == null) return null;

         return Mapper.Map<MarcaVeiculoDto[]>(marcas);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<MarcaVeiculoDto[]?> GetMarcasVeiculosByNomeAsync(string nomeMarca)
   {
      try
      {
         var marcas = await MarcaVeiculoRepository.GetMarcasVeiculosByNomeAsync(nomeMarca);

         if (marcas == null) return null;

         return Mapper.Map<MarcaVeiculoDto[]>(marcas);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<MarcaVeiculoDto?> GetMarcaVeiculoByIdAsync(int marcaId)
   {
      try
      {
         var marca = await MarcaVeiculoRepository.GetMarcaVeiculoByIdAsync(marcaId);

         if (marca == null) return null;

         return Mapper.Map<MarcaVeiculoDto>(marca);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> AddMarcaVeiculoAsync(MarcaVeiculoDto marcaVeiculoModel)
   {
      try
      {
         var marca = Mapper.Map<MarcaVeiculo>(marcaVeiculoModel);

         GeralRepository.Add(marca);

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<MarcaVeiculoDto?> UpdateMarcaVeiculoAsync(MarcaVeiculoDto marcaVeiculoModel)
   {
      try
      {
         var marca = await MarcaVeiculoRepository.GetMarcaVeiculoByIdAsync(marcaVeiculoModel.Id);

         if (marca == null) return null;

         GeralRepository.Update(Mapper.Map<MarcaVeiculo>(marcaVeiculoModel));

         if (await GeralRepository.SaveChangesAsync())
         {
            var retorno = await MarcaVeiculoRepository.GetMarcaVeiculoByIdAsync(marcaVeiculoModel.Id);
            return Mapper.Map<MarcaVeiculoDto>(retorno);
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> DeleteMarcaVeiculoAsync(int marcaId)
   {
      try
      {
         var marca = await MarcaVeiculoRepository.GetMarcaVeiculoByIdAsync(marcaId);

         if (marca == null)
         {
            new Exception("Marca não encontrada");
         }
         else
         {
            GeralRepository.Delete(marca);
         }

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }
}