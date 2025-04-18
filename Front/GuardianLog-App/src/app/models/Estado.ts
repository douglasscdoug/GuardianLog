import { Cidade } from "./Cidade";

export interface Estado {
    id: number;
    codUFIBGE: number;
    uf: string;
    nomeEstado: string;
    idPais: number;
    cidades: Cidade[];
}
