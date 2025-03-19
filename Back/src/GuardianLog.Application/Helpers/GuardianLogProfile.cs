using System;
using AutoMapper;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;

namespace GuardianLog.Application.Helpers;

public class GuardianLogProfile : Profile
{
   public GuardianLogProfile()
   {
      CreateMap<Veiculo, VeiculoDto>().ReverseMap();
      CreateMap<Cidade, CidadeDto>().ReverseMap();
      CreateMap<Cor, CorDto>().ReverseMap();
   }
}
