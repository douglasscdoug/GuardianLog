import { Component } from '@angular/core';
import { Empresa } from '../../../models/Empresa';
import { EmpresaService } from '../../../services/empresa.service';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-empresa-lista',
  imports: [CommonModule, NgxSpinnerModule, RouterLink, FormsModule],
  templateUrl: './empresa-lista.component.html',
  styleUrl: './empresa-lista.component.scss'
})
export class EmpresaListaComponent {

  public empresas: Empresa[] = [];
  public empresasFiltradas: Empresa[] = [];
  private filtro = '';

  public get filtroLista() {
    return this.filtro;
  }

  public set filtroLista(value: string) {
    this.filtro = value;
    this.empresasFiltradas = this.filtroLista ? this.filtrarEmpresas(this.filtroLista) : this.empresas;
  }

  constructor(
    private empresaService: EmpresaService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private router: Router
  ) {
    this.carregarEmpresas();
  }

  public carregarEmpresas(): void {
    this.empresaService.getEmpresas().subscribe({
      next: (empresasResp: Empresa[]) => {
        this.spinner.show();
        this.empresas = empresasResp;
        this.empresasFiltradas = this.empresas;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar empresas', 'Erro');
      }
    }).add(() => this.spinner.hide());
  }

  public detalheEmpresa(id: number): void {
    this.router.navigate([`empresas/detalhe/${id}`]);
  }

  public filtrarEmpresas(filtrarPor: string): Empresa[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.empresas.filter(
      (empresa: {cnpj: string, razaoSocial: string, nomeFantasia: string;}) => 
        empresa.cnpj.indexOf(filtrarPor) !== -1 ||
        empresa.razaoSocial.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        empresa.nomeFantasia.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
}