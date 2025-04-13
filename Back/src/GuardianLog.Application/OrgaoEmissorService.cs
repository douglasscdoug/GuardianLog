using AutoMapper;
using GuardianLog.Application.Contratos;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Repo.Contratos;

namespace GuardianLog.Application;

public class OrgaoEmissorService(
    IOrgaoEmissorRepository _orgaoRepository,
    IGeralRepository _geralRepository,
    IMapper _mapper
) : IOrgaoEmissorService
{
    public IOrgaoEmissorRepository OrgaoRepository { get; } = _orgaoRepository;
    public IGeralRepository GeralRepository { get; } = _geralRepository;
    public IMapper Mapper { get; } = _mapper;

    public async Task<OrgaoEmissorDto[]?> GetAllOrgaosEmissoresAsync()
    {
        try
        {
            var orgaos = await OrgaoRepository.GetAllOrgaosEmissoresAsync();

            if(orgaos == null) return null;

            return Mapper.Map<OrgaoEmissorDto[]>(orgaos);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<OrgaoEmissorDto?> GetOrgaoEmissorByIdAsync(int orgaoId)
    {
        try
        {
            var orgao = await OrgaoRepository.GetOrgaoEmissorByIdAsync(orgaoId);

            if(orgao == null) return null;

            return Mapper.Map<OrgaoEmissorDto>(orgao);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<OrgaoEmissorDto?> SalvarOrgaoEmissorAsync(OrgaoEmissorDto model)
    {
        try
        {
            var orgao = await OrgaoRepository.GetOrgaoEmissorByIdAsync(model.Id);

            if(orgao == null)
            {
                var inserirOrgao = Mapper.Map<OrgaoEmissor>(model);
                GeralRepository.Add(inserirOrgao);

                if(await GeralRepository.SaveChangesAsync())
                {
                    return Mapper.Map<OrgaoEmissorDto>(await OrgaoRepository.GetOrgaoEmissorByIdAsync(inserirOrgao.Id));
                }

                return null;
            }

            orgao = Mapper.Map<OrgaoEmissor>(model);
            GeralRepository.Update(orgao);

            if(await GeralRepository.SaveChangesAsync())
            {
                var retorno = await OrgaoRepository.GetOrgaoEmissorByIdAsync(orgao.Id);
                return Mapper.Map<OrgaoEmissorDto>(retorno);
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
