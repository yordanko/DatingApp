import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

@Injectable({
  providedIn: 'root'
})
export class EditProfileCanDeactivateGuard implements CanDeactivate<MemberEditComponent> {
  canDeactivate(component: MemberEditComponent):  boolean {
    if(component.editForm.dirty)
    {
      return confirm('Are you want to abondan changes?')
    }
    return true;
  }
  
}
