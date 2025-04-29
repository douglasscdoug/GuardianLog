using GuardianLog.Domain;
using GuardianLog.Repo.Contexts;
using GuardianLog.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GuardianLog.Repo;

public class VeiculoRepository(Context _context) : IVeiculoRepository
{
    public Context Context { get; } = _context;

    public async Task<Veiculo[]?> GetAllVeiculos()
    {
        IQueryable<Veiculo> query = Context.Veiculos
            .Include(v => v.Cor)
            .Include(v => v.ModeloVeiculo!).ThenInclude(m => m.MarcaVeiculo)
            .Include(v => v.TipoVeiculo)
            .Include(v => v.Tecnologia);

        return await query.ToArrayAsync();
    }

    public async Task<Veiculo?> GetVeiculoById(int veiculoId)
    {
        IQueryable<Veiculo> query = Context.Veiculos
            .Include(v => v.Cor)
            .Include(v => v.ModeloVeiculo!).ThenInclude(m => m.MarcaVeiculo)
            .Include(v => v.TipoVeiculo)
            .Include(v => v.Tecnologia);

        query = query.AsNoTracking().OrderBy(v => v.Id).Where(v => v.Id == veiculoId);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<Veiculo?> GetVeiculoByPlaca(string placa)
    {
        IQueryable<Veiculo> query = Context.Veiculos
            .Include(v => v.Cor)
            .Include(v => v.ModeloVeiculo!).ThenInclude(m => m.MarcaVeiculo)
            .Include(v => v.TipoVeiculo)
            .Include(v => v.Tecnologia);

        query = query.AsNoTracking().OrderBy(v => v.Id).Where(v => v.Placa.ToLower().Contains(placa.ToLower()));

        return await query.FirstOrDefaultAsync();
    }

    //cores
    public async Task<Cor[]?> GetAllCoresAsync()
    {
        return await Context.Cores.OrderBy(c => c.Nome).ToArrayAsync();
    }

    public async Task<Cor?> GetCorByIdAsync(int corId)
    {
        IQueryable<Cor> query = Context.Cores;

        query = query.AsNoTracking().OrderBy(c => c.Nome).Where(c => c.Id == corId);

        return await query.FirstOrDefaultAsync();
    }

    //Marcas
    public async Task<MarcaVeiculo[]> GetAllMarcasVeiculosAsync()
    {
        return await Context.MarcasVeiculos.OrderBy(m => m.Nome).ToArrayAsync();
    }

    public async Task<MarcaVeiculo?> GetMarcaVeiculoByIdAsync(int marcaId)
    {
        IQueryable<MarcaVeiculo> query = Context.MarcasVeiculos;

        query = query.Include(m => m.Modelos);

        query = query.AsNoTracking().Where(m => m.Id == marcaId);

        return await query.FirstOrDefaultAsync();
    }

    //Modelos
    public async Task<ModeloVeiculo[]?> GetModelosVeiculoByMarcaIdAsync(int marcaId)
    {
        IQueryable<ModeloVeiculo> query = Context.ModelosVeiculos;

        query = query.AsNoTracking().OrderBy(m => m.NomeModelo).Where(m => m.IdMarcaVeiculo == marcaId);

        return await query.ToArrayAsync();
    }

    public async Task<ModeloVeiculo?> GetModeloVeiculoByIdAsync(int modeloId)
    {
        IQueryable<ModeloVeiculo> query = Context.ModelosVeiculos;

        query = query.AsNoTracking().Where(m => m.Id == modeloId);

        return await query.FirstOrDefaultAsync();
    }

    // Tecnologias
    public async Task<TecnologiaRastreamento[]?> GetAllTecnologiasAsync()
    {
        return await Context.TecnologiasRastreamento.OrderBy(t => t.Nome).ToArrayAsync();
    }

    public async Task<TecnologiaRastreamento?> GetTecnologiaByIdAsync(int tecnologiaId)
    {
        IQueryable<TecnologiaRastreamento> query = Context.TecnologiasRastreamento;

        query = query.AsNoTracking().Where(t => t.Id == tecnologiaId);

        return await query.FirstOrDefaultAsync();
    }

    //Tipos veículo
    public async Task<TipoVeiculo[]?> GetAllTiposVeiculoAsync()
    {
        return await Context.TiposVeiculo.OrderBy(tv => tv.Nome).ToArrayAsync();
    }

    public async Task<TipoCarreta?> GetTipoCarretaByIdAsync(int tpCarretaId)
    {
        IQueryable<TipoCarreta> query = Context.TiposCarreta;

        query = query.AsNoTracking().Where(t => t.Id == tpCarretaId);

        return await query.FirstOrDefaultAsync();
    }

    //Tipos Carretas

    public async Task<TipoCarreta[]?> GetAllTiposCarretaAsync()
    {
        return await Context.TiposCarreta.OrderBy(t => t.Nome).ToArrayAsync();
    }

    public async Task<TipoVeiculo?> GetTipoVeiculoByIdAsync(int tpVeiculoId)
    {
        IQueryable<TipoVeiculo> query = Context.TiposVeiculo;

        query = query.AsNoTracking().Where(t => t.Id == tpVeiculoId);

        return await query.FirstOrDefaultAsync();
    }
}