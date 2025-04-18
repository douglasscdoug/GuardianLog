import { Component } from '@angular/core';
import { Empresa } from '../../../models/Empresa';
import { EmpresaService } from '../../../services/empresa.service';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-empresa-lista',
  imports: [CommonModule, NgxSpinnerModule, RouterLink],
  templateUrl: './empresa-lista.component.html',
  styleUrl: './empresa-lista.component.scss'
})
export class EmpresaListaComponent {

  public empresas: Empresa[] = [];

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
}