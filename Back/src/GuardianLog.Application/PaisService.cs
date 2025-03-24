using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class PaisService(
   IPaisRepository _paisRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper
) : IPaisService
{
   public IPaisRepository PaisRepository { get; } = _paisRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<PaisDto[]?> GetAllPaisesAsync()
   {
      try
      {
         var paises = await PaisRepository.GetAllPaisesAsync();

         if(paises == null) return null;

         return Mapper.Map<PaisDto[]>(paises);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> AddPaisAsync(PaisDto paisModel)
   {
      try
      {
         var pais = Mapper.Map<Pais>(paisModel);
         GeralRepository.Add(pais);

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }
}