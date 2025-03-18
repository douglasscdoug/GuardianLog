using GuardianLog.Application.Contratos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class VeiculoService(IVeiculoRepository _veiculoRepository, IGeralRepository _geralRepository) : IVeiculoService
{
   public IVeiculoRepository VeiculoRepository { get; } = _veiculoRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;

   public async Task<Veiculo[]?> GetAllVeiculosAsync()
   {
      try
      {
         var veiculos = await VeiculoRepository.GetAllVeiculos();

         if (veiculos == null)
            return null;

         return veiculos;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<Veiculo?> GetVeiculoByIdAsync(int veiculoId)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoById(veiculoId);

         if (veiculo == null)
            return null;

         return veiculo;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<Veiculo?> GetVeiculoByPlaca(string placa)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoByPlaca(placa);

         if (veiculo == null)
            return null;

         return veiculo;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<bool> AddVeiculoAsync(Veiculo veiculo)
   {
      try
      {
         GeralRepository.Add<Veiculo>(veiculo);
         return await GeralRepository.SaveChangesAsync();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<Veiculo?> UpdateVeiculoAsync(Veiculo veiculoNovo)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoById(veiculoNovo.Id);

         if (veiculo == null)
            return null;

         GeralRepository.Update(veiculoNovo);

         if (await GeralRepository.SaveChangesAsync())
            return await VeiculoRepository.GetVeiculoById(veiculoNovo.Id);

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