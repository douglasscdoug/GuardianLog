import { Component, OnInit } from '@angular/core';
import { TituloComponent } from "../../shared/titulo/titulo.component";
import { Empresa } from '../../models/empresa';
import { EmpresaService } from '../../services/empresa.service';
import { NgxSpinnerModule, NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-empresas',
  imports: [CommonModule, TituloComponent, NgxSpinnerModule],
  templateUrl: './empresas.component.html',
  styleUrl: './empresas.component.scss'
})
export class EmpresasComponent{
  public empresas: Empresa[] = [];

  constructor(
    private empresaService: EmpresaService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
  ) {
    this.carregarEmpresas();
  }

  public carregarEmpresas(): void{
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
}
