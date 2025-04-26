import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Motorista } from '../../../models/Motorista';
import { CommonModule } from '@angular/common';
import { Estado } from '../../../models/Estado';
import { Cidade } from '../../../models/Cidade';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MotoristaService } from '../../../services/motorista.service';
import { ToastrService } from 'ngx-toastr';
import { EstadoService } from '../../../services/estado.service';
import { CidadeService } from '../../../services/cidade.service';
import { filter } from 'rxjs';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { OrgaoEmissorService } from '../../../services/orgaoEmissor.service';
import { OrgaoEmissor } from '../../../models/OrgaoEmissor';

@Component({
  selector: 'app-motorista-detalhe',
  imports: [CommonModule, ReactiveFormsModule, BsDatepickerModule],
  templateUrl: './motorista-detalhe.component.html',
  styleUrl: './motorista-detalhe.component.scss'
})
export class MotoristaDetalheComponent {
  public motoristaForm: FormGroup;
  public httpMetodo = 'post';
  public motoristaId!: number;
  public motorista = {} as Motorista;
  public estados: Estado[] = [];
  public cidades: Cidade[] = [];
  public orgaos: OrgaoEmissor[] = [];

  public get bsConfig(): any{
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      containerClass: 'theme-default',
      showWeekNumbers: false
    }
  }

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private motoristaService: MotoristaService,
    private toastr: ToastrService,
    private estadoService: EstadoService,
    private cidadeService: CidadeService,
    private orgaoService: OrgaoEmissorService,
    private router: Router
  ) {
    this.motoristaForm = this.fb.group({
      nome: [''],
      sobrenome: [''],
      dataNascimento: [''],
      numeroCPF: [''],
      numeroRG: [''],
      idOrgaoEmissor: [''],
      dataEmissaoRG: [''],
      idEstadoRG: [''],
      numeroCNH: [''],
      numeroRegistroCNH: [''],
      dataEmissaoCNH: [''],
      dataVencimentoCNH: [''],
      categoriaCNH: [''],
      tipoVinculo: [''],
      endereco: this.fb.group({
        cep: [''],
        logradouro: [''],
        numero: [''],
        complemento: [''],
        bairro: [''],
        cidade: [''],
        idCidade: [''],
        estado: [''],
        idEstado: ['']
      }),
      contato: this.fb.group({
        telefone: [''],
        email: ['']
      })
    });

    this.carregarMotorista();
    this.carregarEstados();
    this.carregarCidades();
    this.carregarOrgaos();
  }

  public carregarMotorista(): void {
    this.motoristaId = +this.activatedRoute.snapshot.paramMap.get('id')!;

    if (this.motoristaId !== null && this.motoristaId !== 0) {
      this.spinner.show();

      this.httpMetodo = 'put';

      this.motoristaService.getMotoristaById(this.motoristaId).subscribe({
        next: (motoristaResponse: Motorista) => {
          this.motorista = { ...motoristaResponse };

          this.motorista.dataNascimento = new Date(this.motorista.dataNascimento);
          this.motorista.dataEmissaoRG = new Date(this.motorista.dataEmissaoRG);
          this.motorista.dataEmissaoCNH = new Date(this.motorista.dataEmissaoCNH);
          this.motorista.dataVencimentoCNH = new Date(this.motorista.dataVencimentoCNH);

          this.motoristaForm.patchValue(this.motorista);
        },
        error: (error: any) => {
          console.error(error);
          this.toastr.error('Erro ao tentar carregar motorista', 'Erro');
        }
      }).add(() => this.spinner.hide());
    }
  }

  public carregarEstados(): void {
    this.estadoService.getEstadosByPaisId(1).subscribe({
      next: (estadosResponse: Estado[]) => {
        this.estados = estadosResponse;
      },
      error: (error: any) => { console.error('Erro ao carregar estados:', error) }
    }).add(() => this.spinner.hide());
  }

  public carregarCidades(): void {
    this.motoristaForm.get('endereco.idEstado')?.valueChanges.pipe(filter((estadoId: number) => !!estadoId)).subscribe((estadoId: number) => {
      this.cidadeService.getCidadesByEstadoId(estadoId).subscribe({
        next: (cidadesResponse: Cidade[]) => {
          this.cidades = cidadesResponse;
          this.motoristaForm.get('endereco.cidade')?.setValue('');
        },
        error: (error: any) => console.error('Erro ao carregar cidades!', error)
      });
    });
  }

  public carregarOrgaos(): void {
    this.orgaoService.getOrgaos().subscribe({
      next: (orgaosResponse: OrgaoEmissor[]) => this.orgaos = orgaosResponse,
      error: (error: any) => console.error('Erro ao carregar orgãos: ', error)
    });
  }

  public salvarMotorista(): void {
    if(this.motoristaForm.valid) {
      this.spinner.show();

      const {cidade, estado, idEstado, ...enderecoLimpo} = this.motoristaForm.value.endereco;

      const motoristaPayload: Motorista = (this.httpMetodo === 'post')
        ? {
            ...this.motoristaForm.value,
            endereco: enderecoLimpo
          }
        : {
            id: this.motoristaId,
            ... this.motoristaForm.value,
            endereco: {id: this.motorista.endereco.id, ...enderecoLimpo},
            contato: {id: this.motorista.contato.id, ...this.motoristaForm.value.contato}
          };

      if(this.httpMetodo === 'post' || this.httpMetodo === 'put'){
        this.motoristaService[this.httpMetodo](motoristaPayload).subscribe({
          next: (motoristaResponse: Motorista) => {
            this.toastr.success('Motorista salvo com sucesso!', 'Sucesso"');
            this.router.navigate([`motoristas/detalhe/${motoristaResponse.id}`]);
          },
          error: (error: any) => {
            console.error('Erro ao salvar motorista', error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar motorista', 'Erro');
          }
        }).add(() => this.spinner.hide());
      }
    }
  }
}
