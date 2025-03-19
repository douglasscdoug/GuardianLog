using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class CidadeService(
   ICidadeRepository _cidadeRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper
) : ICidadeService
{
   public ICidadeRepository CidadeRepository { get; } = _cidadeRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<CidadeDto[]?> GetCidadesByEstadoIdAsync(int estadoId)
   {
      try
      {
         var cidades = await CidadeRepository.GetCidadesByEstadoIdAsync(estadoId);

         if (cidades == null) return null;

         return Mapper.Map<CidadeDto[]>(cidades);
      }
      catch (Exception ex)
      {

         throw new Exception(ex.Message);
      }
   }

   public async Task<CidadeDto[]?> GetCidadesByNome(string nomeCidade)
   {
      try
      {
         var cidades = await CidadeRepository.GetCidadesByNomeAsync(nomeCidade);

         if (cidades == null) return null;

         return Mapper.Map<CidadeDto[]>(cidades);
      }
      catch (Exception ex)
      {

         throw new Exception(ex.Message);
      }
   }

   public async Task<CidadeDto?> GetCidadeByCodIBGEAsync(int codIBGE)
   {
      try
      {
         var cidade = await CidadeRepository.GetCidadeByCodIBGEAsync(codIBGE);

         if (cidade == null) return null;

         return Mapper.Map<CidadeDto>(cidade);
      }
      catch (Exception ex)
      {

         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> AddCidadeAsync(CidadeDto cidadeModel)
   {
      try
      {
         var cidade = Mapper.Map<Cidade>(cidadeModel);
         GeralRepository.Add(cidade);

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {

         throw new Exception(ex.Message);
      }
   }

   public async Task<CidadeDto?> UpdateCidadeAsync(CidadeDto cidadeModel)
   {
      var cidade = await CidadeRepository.GetCidadeByIdAsync(cidadeModel.Id);

      if (cidade == null) return null;

      cidade = Mapper.Map<Cidade>(cidadeModel);

      GeralRepository.Update(cidade);

      if (await GeralRepository.SaveChangesAsync())
      {
         var retorno = Mapper.Map<CidadeDto>(await CidadeRepository.GetCidadeByIdAsync(cidade.Id));

         return retorno;
      }

      return null;
   }

   public async Task<bool> DeleteCidadeAsync(int cidadeId)
   {
      var cidade = await CidadeRepository.GetCidadeByIdAsync(cidadeId);

      if (cidade == null)
      {
         new Exception("Cidade não encontrada");
      }
      else
      {
         GeralRepository.Delete<Cidade>(cidade);
      }

      return await GeralRepository.SaveChangesAsync();
   }
}