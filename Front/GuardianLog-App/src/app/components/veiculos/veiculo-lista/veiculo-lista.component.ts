import { Component } from '@angular/core';
import { Veiculo } from '../../../models/Veiculo';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { VeiculoService } from '../../../services/veiculo.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-veiculo-lista',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './veiculo-lista.component.html',
  styleUrl: './veiculo-lista.component.scss'
})
export class VeiculoListaComponent {
  private filtro = '';
  public veiculos: Veiculo[] = [];
  public veiculosFiltrados: Veiculo[] = [];

  public get filtroLista() {
    return this.filtro;
  }

  public set filtroLista(value: string) {
    this.filtro = value;
    this.veiculosFiltrados = this.filtroLista ? this.filtrarVeiculos(this.filtroLista) : this.veiculos;
  }

  constructor(
    private router: Router,
    private veiculoService: VeiculoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService
  ) {
    this.carregarVeiculos();
  }

  public carregarVeiculos(): void {
    this.spinner.show();

    this.veiculoService.getVeiculos().subscribe({
      next: (veiculosResponse: Veiculo[]) => {
        this.veiculos = veiculosResponse;
        this.veiculosFiltrados = this.veiculos;
      },
      error: (error: any) => {
        console.error(error);
        this.toastr.error('Erro ao carregar veiculos', 'Erro!');
      }
    }).add(() => this.spinner.hide());
  }

  public detalheVeiculo(id: number): void {
    this.router.navigate([`veiculos/detalhe/${id}`]);
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

  public filtrarVeiculos(filtrarPor: string): Veiculo[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.veiculos.filter(
      (veiculo: {placa: string}) => 
        veiculo.placa.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
}
