using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;
using Microsoft.Extensions.Logging;

namespace GuardianLog.Application;

public class VeiculoService(
   IVeiculoRepository _veiculoRepository,
   IGeralRepository _geralRepository,
   IMapper _mapper,
   ILogger<VeiculoService> _logger
   ) : IVeiculoService
{
   public IVeiculoRepository VeiculoRepository { get; } = _veiculoRepository;
   public IGeralRepository GeralRepository { get; } = _geralRepository;
   public IMapper Mapper { get; } = _mapper;
    public ILogger<VeiculoService> Logger { get; } = _logger;

    public async Task<VeiculoResponseDto[]?> GetAllVeiculosAsync()
   {
      try
      {
         var veiculos = await VeiculoRepository.GetAllVeiculos();

         if (veiculos == null)
            return null;

         var retorno = Mapper.Map<VeiculoResponseDto[]>(veiculos);

         return retorno;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoResponseDto?> GetVeiculoByIdAsync(int veiculoId)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoById(veiculoId);

         if (veiculo == null)
            return null;

         var retorno = Mapper.Map<VeiculoResponseDto>(veiculo);

         return retorno;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoResponseDto?> GetVeiculoByPlacaAsync(string placa)
   {
      try
      {
         var veiculo = await VeiculoRepository.GetVeiculoByPlaca(placa);

         if (veiculo == null)
            return null;

         var retorno = Mapper.Map<VeiculoResponseDto>(veiculo);

         return retorno;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoResponseDto?> AddVeiculoAsync(VeiculoRequestDto veiculoModel)
   {
      try
      {
         var veiculo = Mapper.Map<Veiculo>(veiculoModel);
         GeralRepository.Add(veiculo);
         if(await GeralRepository.SaveChangesAsync())
         {
            var veiculoResponse = await VeiculoRepository.GetVeiculoById(veiculo.Id);
            return Mapper.Map<VeiculoResponseDto>(veiculoResponse);
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<VeiculoResponseDto?> UpdateVeiculoAsync(VeiculoRequestDto veiculoModel)
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
            var retorno = Mapper.Map<VeiculoResponseDto>(await VeiculoRepository.GetVeiculoById(veiculo.Id));
            return retorno;
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   //Cor
   public async Task<CorDto[]?> GetAllCoresAsync()
   {
      try
      {
         var cores = await VeiculoRepository.GetAllCoresAsync();

         if (cores == null) return null;

         return Mapper.Map<CorDto[]>(cores);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<CorDto?> SalvarCorAsync(CorDto model)
   {
      try
      {
         var cor = Mapper.Map<Cor>(model);
         GeralRepository.Update(cor);

         if (await GeralRepository.SaveChangesAsync())
         {
            var corResponse = await VeiculoRepository.GetCorByIdAsync(cor.Id);
            return Mapper.Map<CorDto>(corResponse);
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   //Marca
   public async Task<MarcaVeiculoDto[]?> GetAllMarcasVeiculosAsync()
   {
      try
      {
         var marcas = await VeiculoRepository.GetAllMarcasVeiculosAsync();

         if (marcas == null) return null;

         return Mapper.Map<MarcaVeiculoDto[]>(marcas);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<MarcaVeiculoDto?> SalvarMarcaVeiculoAsync(MarcaVeiculoDto model)
   {
      try
      {
         var marca = Mapper.Map<MarcaVeiculo>(model);

         GeralRepository.Update(marca);

         if(await GeralRepository.SaveChangesAsync())
         {
            var marcaResponse = await VeiculoRepository.GetMarcaVeiculoByIdAsync(marca.Id);
            return Mapper.Map<MarcaVeiculoDto>(marcaResponse);
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   //Modelo
   public async Task<ModeloVeiculoDto[]?> GetModelosVeiculoByMarcaIdAsync(int marcaId)
   {
      try
      {
         var modelos = await VeiculoRepository.GetModelosVeiculoByMarcaIdAsync(marcaId);

         if (modelos == null) return null;

         return Mapper.Map<ModeloVeiculoDto[]>(modelos);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<ModeloVeiculoDto?> SalvarModeloAsync(ModeloVeiculoDto model)
   {
      try
      {
         var modelo = Mapper.Map<ModeloVeiculo>(model);
         GeralRepository.Update(modelo);

         if(await GeralRepository.SaveChangesAsync())
         {
            var modeloResponse = await VeiculoRepository.GetModeloVeiculoByIdAsync(modelo.Id);
            return Mapper.Map<ModeloVeiculoDto>(modeloResponse);
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   //Tecnologia
   public async Task<TecnologiaRastreamentoDto[]?> GetAllTecnologiasAsync()
   {
      try
      {
         var tecnologias = await VeiculoRepository.GetAllTecnologiasAsync();

         if (tecnologias == null) return null;

         return Mapper.Map<TecnologiaRastreamentoDto[]>(tecnologias);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<TecnologiaRastreamentoDto?> SalvarTecnologiaAsync(TecnologiaRastreamentoDto model)
   {
      try
      {
         var tecnologia = Mapper.Map<TecnologiaRastreamento>(model);
         GeralRepository.Update(tecnologia);

         if(await GeralRepository.SaveChangesAsync())
         {
            var tecnologiaResponse = await VeiculoRepository.GetTecnologiaByIdAsync(tecnologia.Id);
            return Mapper.Map<TecnologiaRastreamentoDto>(tecnologiaResponse);
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   //Tipo Carreta
   public async Task<TipoCarretaDto[]?> GetAllTiposCarretaAsync()
   {
      try
      {
         var tpsCarreta = await VeiculoRepository.GetAllTiposCarretaAsync();

         if(tpsCarreta == null) return null;

         return Mapper.Map<TipoCarretaDto[]>(tpsCarreta);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<TipoCarretaDto?> SalvarTipoCarretaAsync(TipoCarretaDto model)
   {
      try
      {
         var tpCarreta = Mapper.Map<TipoCarreta>(model);

         GeralRepository.Update(tpCarreta);

         if(await GeralRepository.SaveChangesAsync())
         {
            var tpCarretaResponse = await VeiculoRepository.GetTipoCarretaByIdAsync(tpCarreta.Id);
            return Mapper.Map<TipoCarretaDto>(tpCarretaResponse);
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   //Tipo Veiculo
   public async Task<TipoVeiculoDto[]?> GetAllTiposVeiculoAsync()
   {
      try
      {
         var tpsVeiculo = await VeiculoRepository.GetAllTiposVeiculoAsync();

         if (tpsVeiculo == null) return null;

         return Mapper.Map<TipoVeiculoDto[]>(tpsVeiculo);
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }

   public async Task<TipoVeiculoDto?> SalvarTipoVeiculoAsync(TipoVeiculoDto model)
   {
      try
      {
         var tpVeiculo = Mapper.Map<TipoVeiculo>(model);

         GeralRepository.Update(tpVeiculo);

         if(await GeralRepository.SaveChangesAsync())
         {
            var tpVeiculoResponse = await VeiculoRepository.GetTipoVeiculoByIdAsync(tpVeiculo.Id);
            return Mapper.Map<TipoVeiculoDto>(tpVeiculoResponse);
         }

         return null;
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
   }
}