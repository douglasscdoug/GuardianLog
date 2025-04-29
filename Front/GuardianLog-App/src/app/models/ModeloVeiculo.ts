import { MarcaVeiculo } from "./MarcaVeiculo";

export interface ModeloVeiculo {
    id: number;
    nomeModelo: string;
    idMarcaVeiculo: number;
    marcaVeiculo: MarcaVeiculo;
}
