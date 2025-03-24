using System;
using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class TipoCarretaService(
   ITipoCarretaRepository _tipoCarretaRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper
) : ITipoCarretaService
{
   public ITipoCarretaRepository TipoCarretaRepository { get; } = _tipoCarretaRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<TipoCarretaDto[]?> GetAllTiposCarretaAsync()
   {
      try
      {
         var tpsCarreta = await TipoCarretaRepository.GetAllTiposCarretaAsync();

         if(tpsCarreta == null) return null;

         return Mapper.Map<TipoCarretaDto[]>(tpsCarreta);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<TipoCarretaDto?> GetTipoCarretaByIdAsync(int tpCarretaId)
   {
      try
      {
         var tpCarreta = await TipoCarretaRepository.GetTipoCarretaByIdAsync(tpCarretaId);

         if(tpCarreta == null) return null;

         return Mapper.Map<TipoCarretaDto>(tpCarreta);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> SalvarTipoCarretaAsync(TipoCarretaDto model)
   {
      try
      {
         var tpCarreta = Mapper.Map<TipoCarreta>(model);

         GeralRepository.Update(tpCarreta);

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }
}