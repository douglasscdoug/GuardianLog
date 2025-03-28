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
      CreateMap<Estado, EstadoDto>().ReverseMap();
      CreateMap<MarcaVeiculo, MarcaVeiculoDto>().ReverseMap();
      CreateMap<ModeloVeiculo, ModeloVeiculoDto>().ReverseMap();
      CreateMap<Pais, PaisDto>().ReverseMap();
      CreateMap<TecnologiaRastreamento, TecnologiaRastreamentoDto>().ReverseMap();
      CreateMap<TipoCarreta, TipoCarretaDto>().ReverseMap();
      CreateMap<TipoVeiculo, TipoVeiculoDto>().ReverseMap();
   }
}
