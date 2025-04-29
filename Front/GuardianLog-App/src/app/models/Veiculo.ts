import { Cor } from "./Cor";
import { ModeloVeiculo } from "./ModeloVeiculo";
import { Tecnologia } from "./Tecnologia";
import { TipoCarreta } from "./TipoCarreta";
import { TipoVeiculo } from "./TipoVeiculo";

export interface Veiculo {
    id: number;
    placa: string;
    veiculoInternacional: boolean;
    tipoVeiculo: TipoVeiculo;
    idTipoVeiculo: number;
    tipoCarreta?: TipoCarreta;
    idTipoCarreta: number;
    chassi: string;
    idModeloVeiculo: number;
    modeloVeiculo: ModeloVeiculo;
    anoFabricacao: number;
    idCor: number;
    cor: Cor;
    renavam: string;
    idCidade: number;
    tipoVinculo: number;
    idTecnologia: number;
    tecnologia: Tecnologia;
    idEquipamento: number;
}
