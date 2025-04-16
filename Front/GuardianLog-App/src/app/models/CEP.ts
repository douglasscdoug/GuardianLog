import { Cidade } from "./Cidade";

export interface CEP {
    id: number;
    cep: string;
    logradouro: string;
    localidade: string;
    idCidade: number;
    cidade: Cidade;
}
