import { UpperCasePipe } from '@angular/common';
import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { take } from 'rxjs/operators';
import { Member, UpdateMember } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
member: Member
user: User
@ViewChild('editF') editForm: NgForm
@HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
  if(this.editForm.dirty){
    $event.returValue = true;
  }
}

  constructor(private accountService:AccountService, private memberService: MembersService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user=>this.user = user);
   }

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember(){
    this.memberService.getMember(this.user.username).subscribe(member => {     
      this.member = member;
    })
  }

  updateMember()
  {
    console.log(this.member);
    this.memberService.updateMember(this.member).subscribe(  () => {
        this.editForm.reset(this.member)
      }
    )
  }


  onSubmit(form:NgForm){
   
    console.log(this.member);
    const updateMember: UpdateMember =  form.value; 
    // console.log(JSON.stringify(updateMember));
    this.updateMember();
    this.editForm.reset();
  }
}
