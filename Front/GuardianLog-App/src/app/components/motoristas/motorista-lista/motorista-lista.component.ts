import { CommonModule } from '@angular/common';
import { Component, TemplateRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Motorista } from '../../../models/Motorista';
import { MotoristaService } from '../../../services/motorista.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterLink } from '@angular/router';
import { DataPtBrPipe } from "../../../helpers/pipes/data-pt-br.pipe";
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

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
  public modalRef?: BsModalRef;
  public motoristaId: number = 0;

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
    private router: Router,
    private modalService: BsModalService
  ) {
    this.carregarMotoristas();
  }

  public carregarMotoristas(): void {
    this.spinner.show();
    
    this.motoristaService.getMotoristas().subscribe({
      next: (motoristasResponse: Motorista[]) => {
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

  public openModal(template: TemplateRef<void>, motoristaId: number) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
    this.motoristaId = motoristaId;
  }

  public confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();

    this.motoristaService.deleteMotorista(this.motoristaId).subscribe({
      next: (result: any) => {
        if(result.message === 'Deletado') {
          this.toastr.success(`Motorista id: ${this.motoristaId} deletado com sucesso`, 'sucesso');
          this.carregarMotoristas();
        }
      },
      error: (error: any) => {
        this.toastr.error(`Erro ao tentar deletar motorista Id: ${this.motoristaId}`, 'Erro');
        console.error(error);
      }
    }).add(() => this.spinner.hide());
  }

  public decline(): void {
    this.modalRef?.hide();
  }
}
