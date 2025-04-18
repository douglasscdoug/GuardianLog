import { Contato } from "./Contato";
import { Endereco } from "./Endereco";

export interface Empresa {
    id: number;
    cnpj: string;
    razaoSocial: string;
    nomeFantasia: string;
    endereco: Endereco;
    contato: Contato;
    tipoEmpresa: number;
    ehCliente: boolean;
}
