import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Motorista } from '../../../models/Motorista';
import { MotoristaService } from '../../../services/motorista.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterLink } from '@angular/router';
import { DataPtBrPipe } from "../../../helpers/pipes/data-pt-br.pipe";

@Component({
  selector: 'app-motorista-lista',
  imports: [CommonModule, FormsModule, RouterLink, DataPtBrPipe],
  templateUrl: './motorista-lista.component.html',
  styleUrl: './motorista-lista.component.scss'
})
export class MotoristaListaComponent {
  private filtro = '';
  public motoristas: Motorista[] = [];
  public motoristasFiltrados: Motorista[] = [];

  public get filtroLista() {
    return this.filtro;
  }

  public set filtroLista(value: string) {
    this.filtro = value;
    this.motoristasFiltrados = this.filtroLista ? this.filtrarMotoristas(this.filtroLista) : this.motoristas;
  }

  constructor(
    private motoristaService: MotoristaService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private router: Router
  ) {
    this.carregarMotoristas();
  }

  public carregarMotoristas(): void {
    this.motoristaService.getMotoristas().subscribe({
      next: (motoristasResponse: Motorista[]) => {
        this.spinner.show();
        this.motoristas = motoristasResponse;
        this.motoristasFiltrados = this.motoristas;
      },
      error: (error: any) => {
        this.spinner.hide();
        console.error(error);
        this.toastr.error('Erro ao carregar motoristas', 'Erro');
      }
    }).add(() => this.spinner.hide());
  }

  public detalheMotorista(id: number): void {
    this.router.navigate([`motoristas/detalhe/${id}`]);
  }

  public tipoVinculo(tipo: number): string {
    switch(tipo) {
      case 1:
        return 'Agregado';
      case 2:
        return 'Frota';
      case 3:
        return 'Terceito';
    }

    return '';
  }

  public filtrarMotoristas(filtrarPor: string): Motorista[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.motoristas.filter(
      (motorista: {nome: string, sobrenome: string, numeroCPF: string, numeroRG: string, numeroCNH: string}) =>
        motorista.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        motorista.sobrenome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        motorista.numeroCPF.indexOf(filtrarPor) !== -1 ||
        motorista.numeroRG.indexOf(filtrarPor) !== -1 ||
        motorista.numeroCNH.indexOf(filtrarPor) !== -1
    );
  }
}
