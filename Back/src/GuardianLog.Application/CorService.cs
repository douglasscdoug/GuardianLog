using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class CorService(
   ICorRepository _corRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper
) : ICorService
{
   public ICorRepository CorRepository { get; } = _corRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<CorDto[]?> GetAllCoresAsync()
   {
      try
      {
         var cores = await CorRepository.GetAllCoresAsync();

         if (cores == null) return null;

         return Mapper.Map<CorDto[]>(cores);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<CorDto?> GetCorByIdAsync(int corId)
   {
      try
      {
         var cor = await CorRepository.GetCorByIdAsync(corId);

         if (cor == null) return null;

         return Mapper.Map<CorDto>(cor);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<CorDto[]?> GetCoresByNomeAsync(string nomeCor)
   {
      try
      {
         var cor = await CorRepository.GetCoresByNomeAsync(nomeCor);

         if (cor == null) return null;

         return Mapper.Map<CorDto[]>(cor);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> AddCorAsync(CorDto corModel)
   {
      try
      {
         var cor = Mapper.Map<Cor>(corModel);
         GeralRepository.Add(cor);

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<CorDto?> UpdateCorAsync(CorDto corModel)
   {
      try
      {
         var cor = await CorRepository.GetCorByIdAsync(corModel.Id);

         if (cor == null) return null;

         cor = Mapper.Map<Cor>(corModel);

         GeralRepository.Update(cor);

         if (await GeralRepository.SaveChangesAsync())
            return Mapper.Map<CorDto>(await CorRepository.GetCorByIdAsync(cor.Id));

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> DeleteCorAsync(int corId)
   {
      try
      {
         var cor = await CorRepository.GetCorByIdAsync(corId);

         if (cor == null)
         {
            new Exception("Cor não encontrada");
         }
         else
         {
            GeralRepository.Delete(cor);
         }

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {

         throw new Exception(ex.Message);
      }
   }
}