import { Contato } from "./Contato";
import { Endereco } from "./Endereco";

export interface Motorista {
    id: number;
    nome: string;
    sobrenome: string;
    dataNascimento: Date;
    numeroCPF: string;
    numeroRG: string;
    idOrgaoEmissor: number;
    dataEmissaoRG: Date;
    idEstadoRG: number;
    endereco: Endereco;
    idEndereco: number;
    contato: Contato;
    idContato: number;
    numeroCNH: string;
    numeroRegistroCNH: string;
    dataEmissaoCNH: Date;
    dataVencimentoCNH: Date;
    categoriaCNH: number;
    tipoVinculo: number;
}
