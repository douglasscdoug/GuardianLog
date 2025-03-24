using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class EstadoService(
   IEstadoRepository _estadoRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper
) : IEstadoService
{
   public IEstadoRepository EstadoRepository { get; } = _estadoRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<EstadoDto?> GetEstadoByIdAsync(int estadoId)
   {
      try
      {
         var estado = await EstadoRepository.GetEstadoByIdAsync(estadoId);

         if (estado == null) return null;

         return Mapper.Map<EstadoDto>(estado);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<EstadoDto[]?> GetEstadosBYPaisIdAsync(int paisId)
   {
      try
      {
         var estados = await EstadoRepository.GetEstadosBYPaisIdAsync(paisId);

         if(estados == null) return null;

         return Mapper.Map<EstadoDto[]>(estados);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> AddEstadoAsync(EstadoDto estadoModel)
   {
      try
      {
         var estado = Mapper.Map<Estado>(estadoModel);

         GeralRepository.Add(estado);

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<EstadoDto?> UpdateEstadoAsync(EstadoDto estadoModel)
   {
      try
      {
         var estado = await EstadoRepository.GetEstadoByIdAsync(estadoModel.Id);

         if(estado == null) return null;

         GeralRepository.Update(Mapper.Map<Estado>(estadoModel));

         if(await GeralRepository.SaveChangesAsync())
         {
            var retorno = Mapper.Map<EstadoDto>(await EstadoRepository.GetEstadoByIdAsync(estadoModel.Id));
            return retorno;
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> DeleteEstadoAsync(int estadoId)
   {
      try
      {
         var estado = await EstadoRepository.GetEstadoByIdAsync(estadoId);

         if(estado == null)
         {
            new Exception("Estado não encontrado");
         }
         else
         {
            GeralRepository.Delete(estado);
         }
         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }
}