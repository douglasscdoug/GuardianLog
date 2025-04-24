import { Pipe, PipeTransform } from '@angular/core';
import { Constants } from '../../util/Constants';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'dataPtBr'
})
export class DataPtBrPipe implements PipeTransform {
  private datePipe = new DatePipe('pt-BR');

  transform(value: any, comHora: boolean = false): string | null {
    const formato = comHora ? Constants.DATE_TIME_FMT : Constants.DATE_FMT;
    return this.datePipe.transform(value, formato);
  }
}
