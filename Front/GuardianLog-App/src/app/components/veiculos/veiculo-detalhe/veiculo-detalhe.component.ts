import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Veiculo } from '../../../models/Veiculo';
import { VeiculoService } from '../../../services/veiculo.service';
import { Cor } from '../../../models/Cor';
import { NgxSpinnerService } from 'ngx-spinner';
import { MarcaVeiculo } from '../../../models/MarcaVeiculo';
import { ModeloVeiculo } from '../../../models/ModeloVeiculo';
import { filter } from 'rxjs';
import { Tecnologia } from '../../../models/Tecnologia';
import { TipoCarreta } from '../../../models/TipoCarreta';
import { TipoVeiculo } from '../../../models/TipoVeiculo';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-veiculo-detalhe',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './veiculo-detalhe.component.html',
  styleUrl: './veiculo-detalhe.component.scss'
})
export class VeiculoDetalheComponent {
  public veiculoForm: FormGroup;
  public httpMetodo = 'post';
  public veiculoId!: number;
  public veiculo = {} as Veiculo;
  public cores: Cor[] = [];
  public marcas: MarcaVeiculo[] = [];
  public modelos: ModeloVeiculo[] = [];
  public tecnologias: Tecnologia[] = [];
  public tiposCarreta: TipoCarreta[] = [];
  public tiposVeiculo: TipoVeiculo[] = [];

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private veiculoService: VeiculoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
  ) {
    this.veiculoForm = fb.group({
      placa: [''],
      veiculoInternacional: [''],
      idTipoVeiculo: [''],
      idTipoCarreta: [''],
      chassi: [''],
      renavam: [''],
      idCor: [''],
      tipoVinculo: [''],
      anoFabricacao: [''],
      idTecnologia: [''],
      idEquipamento: [''],
      idMarcaVeiculo: [''],
      idModeloVeiculo: ['']
    });

    this.carregarMarcas(() => this.carregarVeiculo());
    this.carregarCores();
    this.monitorarMudancaMarca();
    this.carregarTecnologias();
    this.carregarTiposCarreta();
    this.carregarTiposVeiculo();
  }

  public carregarVeiculo(): void {
    this.veiculoId = +this.activatedRoute.snapshot.paramMap.get('id')!;

    if(this.veiculoId != null && this.veiculoId != 0) {
      this.spinner.show();

      this.httpMetodo = 'put';

      this.veiculoService.getVeiculoById(this.veiculoId).subscribe({
        next: (veiculoResponse: Veiculo) => {
          this.veiculo = veiculoResponse;
          this.veiculoForm.patchValue(this.veiculo);
          this.veiculoForm.patchValue({
            idMarcaVeiculo: this.veiculo?.modeloVeiculo?.idMarcaVeiculo || '',
            idModeloVeiculo: this.veiculo?.modeloVeiculo?.id || ''
          });
        },
        error: (error: any) => {
          this.toastr.error('Erro ao carregar veículo', 'Erro!');
          console.error(error);
        }
      }).add(() => this.spinner.hide());
    }
  }

  public carregarCores(): void {
    this.spinner.show();
    this.veiculoService.getCores().subscribe({
      next: (coresResponse: Cor[]) => this.cores = coresResponse,
      error: (error: any) => console.error(error)
    }).add(() => this.spinner.hide());
  }

  public carregarMarcas(callback?: () => void): void {
    this.spinner.show();
    this.veiculoService.getMarcas().subscribe({
      next: (marcasResponse: MarcaVeiculo[]) => {
        this.marcas = marcasResponse;
        if(callback) callback();
      },
      error: (error: any) => console.error(error)
    }).add(() => this.spinner.show());
  }

  public carregarModelos(marcaId?: number): void{

    if(marcaId) {
      this.spinner.show();

      this.veiculoService.getModeloByMarcaId(marcaId).subscribe({
        next: (modelosResponse: ModeloVeiculo[]) => {
          this.modelos = modelosResponse;
        },
        error: (error: any) => console.error(error)
      }).add(() => this.spinner.hide());
    }
  }

  public monitorarMudancaMarca(): void {
    this.veiculoForm.get('idMarcaVeiculo')?.valueChanges.pipe(
      filter((marcarId: number) => !!marcarId)
    ).subscribe((marcaId: number) => {
      this.carregarModelos(marcaId)
    })
  }

  public carregarTecnologias(): void {
    this.spinner.show();
    this.veiculoService.getTecnologias().subscribe({
      next: (tecnologiasResponse: Tecnologia[]) => this.tecnologias = tecnologiasResponse,
      error: (error: any) => console.error(error)
    }).add(() => this.spinner.hide());
  }

  public carregarTiposCarreta(): void {
    this.spinner.show();
    this.veiculoService.getTiposCarreta().subscribe({
      next: (resp: TipoCarreta[]) => this.tiposCarreta = resp,
      error: (error: any) => console.error(error)
    }).add(() => this.spinner.hide());
  }

  public carregarTiposVeiculo(): void {
    this.spinner.show();
    this.veiculoService.getTiposVeiculo().subscribe({
      next: (resp: TipoVeiculo[]) => this.tiposVeiculo = resp,
      error: (error: any) => console.error(error)
    }).add(() => this.spinner.hide());
  }

  public salvarVeiculo(): void {

  }
}
