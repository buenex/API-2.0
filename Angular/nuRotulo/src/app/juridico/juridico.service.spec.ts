import { TestBed } from '@angular/core/testing';

import { JuridicoService } from './juridico.service';

describe('JuridicoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: JuridicoService = TestBed.get(JuridicoService);
    expect(service).toBeTruthy();
  });
});
