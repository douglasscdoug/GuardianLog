/* tslint:disable:no-unused-variable */

import { TestBed, inject } from '@angular/core/testing';
import { OrgaoEmissorService } from './orgaoEmissor.service';

describe('Service: OrgaoEmissor', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OrgaoEmissorService]
    });
  });

  it('should ...', inject([OrgaoEmissorService], (service: OrgaoEmissorService) => {
    expect(service).toBeTruthy();
  }));
});
