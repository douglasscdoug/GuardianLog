using System;
using AutoMapper;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Domain.Enum;

namespace GuardianLog.Application.Helpers;

public class GuardianLogProfile : Profile
{
   public GuardianLogProfile()
   {
      CreateMap<CEP, CEPRequestDto>().ReverseMap();
      CreateMap<CEP, CEPResponseDto>().ReverseMap();
      CreateMap<Cidade, CidadeDto>().ReverseMap();
      CreateMap<Cor, CorDto>().ReverseMap();
      CreateMap<Contato, ContatoDto>().ReverseMap();
      CreateMap<Empresa, EmpresaDto>().ReverseMap();
      CreateMap<Empresa, EmpresaRequestDto>().ReverseMap();
      CreateMap<Empresa, EmpresaRequestDto>()
         .ForMember(dest => dest.TipoEmpresa, opt => opt.MapFrom(src => (int)src.TipoEmpresa));

      CreateMap<EmpresaRequestDto, Empresa>()
         .ForMember(dest => dest.TipoEmpresa, opt => opt.MapFrom(src => (TipoEmpresa)src.TipoEmpresa));
      CreateMap<Endereco, EnderecoDto>().ReverseMap();
      CreateMap<Estado, EstadoDto>().ReverseMap();
      CreateMap<MarcaVeiculo, MarcaVeiculoDto>().ReverseMap();
      CreateMap<ModeloVeiculo, ModeloVeiculoDto>().ReverseMap();
      CreateMap<Pais, PaisDto>().ReverseMap();
      CreateMap<TecnologiaRastreamento, TecnologiaRastreamentoDto>().ReverseMap();
      CreateMap<TipoCarreta, TipoCarretaDto>().ReverseMap();
      CreateMap<TipoVeiculo, TipoVeiculoDto>().ReverseMap();
      CreateMap<Veiculo, VeiculoDto>().ReverseMap();
   }
}
