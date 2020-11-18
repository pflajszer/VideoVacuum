import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MetadataEditFormComponent } from './metadata-edit-form.component';

describe('MetadataEditFormComponent', () => {
  let component: MetadataEditFormComponent;
  let fixture: ComponentFixture<MetadataEditFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MetadataEditFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MetadataEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
