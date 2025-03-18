using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class VeiculoService(
   IVeiculoRepository _veiculoRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper) : IVeiculoService
{
   public IVeiculoRepository VeiculoRepository { get; } = _veiculoRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;

   public async Task<VeiculoDto[]?> GetAllVeiculosAsync()
   {
      try
      {
         var veiculos = await VeiculoRepository.GetAllVeiculos();

         if (veiculos == null)
            return null;

         var retorno = Mapper.Map<VeiculoDto[]>(veiculos);

         return retorno;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoDto?> GetVeiculoByIdAsync(int veiculoId)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoById(veiculoId);

         if (veiculo == null)
            return null;

         var retorno = Mapper.Map<VeiculoDto>(veiculo);

         return retorno;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoDto?> GetVeiculoByPlacaAsync(string placa)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoByPlaca(placa);

         if (veiculo == null)
            return null;

         var retorno = Mapper.Map<VeiculoDto>(veiculo);

         return retorno;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> AddVeiculoAsync(VeiculoDto veiculoModel)
   {
      try
      {
         var veiculo = Mapper.Map<Veiculo>(veiculoModel);
         GeralRepository.Add<Veiculo>(veiculo);
         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoDto?> UpdateVeiculoAsync(VeiculoDto veiculoModel)
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
            var retorno = Mapper.Map<VeiculoDto>(await VeiculoRepository.GetVeiculoById(veiculo.Id));
            return retorno;
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> DeleteVeiculoAsync(int veiculoId)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoById(veiculoId);

         if (veiculo == null)
         {
            new Exception("Veículo não encontrado");
         }
         else
         {
            GeralRepository.Delete<Veiculo>(veiculo);
         }

         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }
}