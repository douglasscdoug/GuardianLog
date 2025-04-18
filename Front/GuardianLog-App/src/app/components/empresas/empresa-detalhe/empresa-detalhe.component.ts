import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { EmpresaService } from '../../../services/empresa.service';
import { Empresa } from '../../../models/Empresa';
import { ToastrService } from 'ngx-toastr';
import { Estado } from '../../../models/Estado';
import { EstadoService } from '../../../services/estado.service';

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

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private empresaService: EmpresaService,
    private toastr: ToastrService,
    private estadoService: EstadoService
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
        estado: ['']
      }),
      contato: this.fb.group({
        telefone: [''],
        email: ['']
      })
    });

    this.carregarEmpresa();
    this.carregarEstados();
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

  public carregarEstados(): void{
    this.estadoService.getEstadosByPaisId(1).subscribe({
      next: (estadoResponse: Estado[]) => {
        this.estados = estadoResponse;
      },
      error: () => {}
    }).add(() => this.spinner.hide());
  }
}
