using System;
using AutoMapper;
using GuardianLog.Application.Dtos;
using GuardianLog.Domain;
using GuardianLog.Domain.Enum;
using Microsoft.CodeAnalysis;

namespace GuardianLog.Application.Helpers;

public class GuardianLogProfile : Profile
{
   public GuardianLogProfile()
   {
      CreateMap<Cidade, CidadeDto>().ReverseMap();
      CreateMap<Cidade, EnderecoCompletoDto>()
         .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.NomeCidade))
         .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.NomeEstado));
      CreateMap<Cor, CorDto>().ReverseMap();
      CreateMap<Contato, ContatoDto>().ReverseMap();
      CreateMap<Empresa, EmpresaDto>().ReverseMap();
      CreateMap<Empresa, EmpresaDto>()
            .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
      CreateMap<Empresa, EmpresaRequestDto>()
         .ForMember(dest => dest.TipoEmpresa, opt => opt.MapFrom(src => (int)src.TipoEmpresa));
      CreateMap<EmpresaRequestDto, Empresa>()
         .ForMember(dest => dest.TipoEmpresa, opt => opt.MapFrom(src => (TipoEmpresa)src.TipoEmpresa));
      CreateMap<Endereco, EnderecoDto>()
         .ForSourceMember(src => src.Empresa, opt => opt.DoNotValidate())
         .ForSourceMember(src => src.PessoaFisica, opt => opt.DoNotValidate());
      CreateMap<Endereco, EnderecoCompletoDto>()
            .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
            .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
            .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
            .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
            .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento))
            .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade!.NomeCidade))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Cidade!.Estado.NomeEstado)); 
      CreateMap<Estado, EstadoDto>().ReverseMap();
      CreateMap<Motorista, MotoristaDto>()
         .ForMember(dest => dest.CategoriaCNH, opt => opt.MapFrom(src => (int)src.CategoriaCNH))
         .ForMember(dest => dest.TipoVinculo, opt => opt.MapFrom(src => (int)src.TipoVinculo));
      CreateMap<MotoristaDto, Motorista>()
         .ForMember(dest => dest.CategoriaCNH, opt => opt.MapFrom(src => (CategoriaCNH)src.CategoriaCNH))
         .ForMember(dest => dest.TipoVinculo, opt => opt.MapFrom(src => (TipoVinculo)src.TipoVinculo));
      CreateMap<MarcaVeiculo, MarcaVeiculoDto>().ReverseMap();
      CreateMap<ModeloVeiculo, ModeloVeiculoDto>().ReverseMap();
      CreateMap<Pais, PaisDto>().ReverseMap();
      CreateMap<PessoaFisica, PessoaFisicaRequestDto>().ReverseMap();
      CreateMap<OrgaoEmissor, OrgaoEmissorDto>().ReverseMap();
      CreateMap<TecnologiaRastreamento, TecnologiaRastreamentoDto>().ReverseMap();
      CreateMap<TipoCarreta, TipoCarretaDto>().ReverseMap();
      CreateMap<TipoVeiculo, TipoVeiculoDto>().ReverseMap();
      CreateMap<Veiculo, VeiculoDto>()
         .ForMember(dest => dest.TipoVinculo, opt => opt.MapFrom(src => (int)src.TipoVinculo));
      CreateMap<VeiculoDto, Veiculo>()
         .ForMember(dest => dest.TipoVinculo, opt => opt.MapFrom(src => (TipoVinculo)src.TipoVinculo));
   }
}
