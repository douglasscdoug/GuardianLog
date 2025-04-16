import { CEP } from "./CEP";

export interface Endereco {
     id: number;
     cep: CEP;
     idCep: number;
     numero: number;
     complemento: string;
     idEmpresa: number;
     idPessoaFisica: number;
}
