import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { EmpresaService } from '../../../services/empresa.service';
import { Empresa } from '../../../models/Empresa';
import { ToastrService } from 'ngx-toastr';
import { Estado } from '../../../models/Estado';
import { EstadoService } from '../../../services/estado.service';
import { Cidade } from '../../../models/Cidade';
import { CidadeService } from '../../../services/cidade.service';
import { filter } from 'rxjs';

@Component({
  selector: 'app-empresa-detalhe',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './empresa-detalhe.component.html',
  styleUrl: './empresa-detalhe.component.scss'
})
export class EmpresaDetalheComponent {
  public empresaForm: FormGroup;
  public httpMetodo = 'post';
  public empresaId!: number;
  public empresa = {} as Empresa;
  public estados: Estado[] = [];
  public cidades: Cidade[] = [];

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private empresaService: EmpresaService,
    private toastr: ToastrService,
    private estadoService: EstadoService,
    private cidadeService: CidadeService,
    private router: Router
  ) {
    this.empresaForm = this.fb.group({
      cnpj: [''],
      razaoSocial: [''],
      nomeFantasia: [''],
      tipoEmpresa: [''],
      ehCliente: [''],
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

    this.carregarEmpresa();
    this.carregarEstados();
    this.carregarCidades();
  }

  public get modoEditar(): boolean {
    return this.httpMetodo === 'put';
  }

  public carregarEmpresa(): void{
    this.empresaId = +this.activatedRoute.snapshot.paramMap.get('id')!;

    if(this.empresaId != null && this.empresaId != 0) {
      this.spinner.show();

      this.httpMetodo = 'put';

      this.empresaService.getEmpresaById(this.empresaId).subscribe({
        next: (empresaResponse: Empresa) => {
          this.empresa = { ...empresaResponse};
          this.empresaForm.patchValue(this.empresa);
        },
        error: (error: any) => {
          this.toastr.error('Erro ao tentar carregar empresa', 'Erro!');
          console.error(error);
        }
      }).add(() => this.spinner.hide());
    }
  }

  public carregarEstados(): void {
    this.estadoService.getEstadosByPaisId(1).subscribe({
      next: (estadosResponse: Estado[]) => {
        this.estados = estadosResponse;
      },
      error: (error: any) => {console.error('Erro ao carregar estados:', error)}
    }).add(() => this.spinner.hide());
  }

  public carregarCidades(): void {
    this.empresaForm.get('endereco.idEstado')?.valueChanges.pipe(filter((estadoId: number) => !!estadoId)).subscribe((estadoId: number) => {
        this.cidadeService.getCidadesByEstadoId(estadoId).subscribe({
          next: (cidadesResponse: Cidade[]) => {
            this.cidades = cidadesResponse;
            this.empresaForm.get('endereco.cidade')?.setValue('');
          },
          error: (error: any) => console.error('Erro ao carregar cidades!', error)
        });
    });
  }

  public salvarEmpresa(): void {
    if(this.empresaForm.valid) {
      this.spinner.show();

      const {cidade, estado, idEstado, ...enderecoLimpo} = this.empresaForm.value.endereco;
      
      const empresaPayload: Empresa = (this.httpMetodo === 'post')
        ? {
            ... this.empresaForm.value,
            endereco: enderecoLimpo
          }
        : {
            id: this.empresaId, 
            ... this.empresaForm.value,
            endereco: {id: this.empresa.endereco.id, ...enderecoLimpo},
            contato: {id: this.empresa.contato.id, ...this.empresaForm.value.contato}
          };

      if(this.httpMetodo == 'post' || this.httpMetodo == 'put'){
        this.empresaService[this.httpMetodo](empresaPayload).subscribe({
          next: (empresaResponse: Empresa) => {
            this.toastr.success('Empresa salva com sucesso!', 'Sucesso!');
            this.router.navigate([`empresas/detalhe/${empresaResponse.id}`]);
          },
          error: (error: any) => {
            console.error('Erro ao salvar empresa!', error);
            this.spinner.hide();
            this.toastr.error('Erro ao salvar empresa!', 'Erro');
          }
        }).add(() => this.spinner.hide());
      }
    }
  }
}
