using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class TecnologiaService(
   ITecnologiaRepository _tecnologiaRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper
) : ITecnologiaService
{
   public ITecnologiaRepository TecnologiaRepository { get; } = _tecnologiaRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<TecnologiaRastreamentoDto[]?> GetAllTecnologiasAsync()
   {
      try
      {
         var tecnologias = await TecnologiaRepository.GetAllTecnologiasAsync();

         if (tecnologias == null) return null;

         return Mapper.Map<TecnologiaRastreamentoDto[]>(tecnologias);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<TecnologiaRastreamentoDto?> GetTecnologiaByIdAsync(int tecnologiaId)
   {
      try
      {
         var tecnologia = await TecnologiaRepository.GetTecnologiaByIdAsync(tecnologiaId);

         if (tecnologia == null) return null;

         return Mapper.Map<TecnologiaRastreamentoDto>(tecnologia);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> AddTecnologiaAsync(TecnologiaRastreamentoDto model)
   {
      try
      {
         var tecnologia = Mapper.Map<TecnologiaRastreamento>(model);
         GeralRepository.Add(tecnologia);

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<TecnologiaRastreamentoDto?> UpdateTecnologiaAsync(TecnologiaRastreamentoDto model)
   {
      try
      {
         var tecnologia = await TecnologiaRepository.GetTecnologiaByIdAsync(model.Id);

         if (tecnologia == null) return null;

         GeralRepository.Update(Mapper.Map<TecnologiaRastreamento>(model));

         if (await GeralRepository.SaveChangesAsync())
         {
            var retorno = Mapper.Map<TecnologiaRastreamentoDto>(await TecnologiaRepository.GetTecnologiaByIdAsync(model.Id));
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