import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
member: Member
  constructor(private membersService: MembersService, private activatedRouter: ActivatedRoute) { }

  ngOnInit(): void {    
    this.getMember(this.activatedRouter.snapshot.params['username'].toLowerCase())
  }

  getMember( username:string){
    this.membersService.getMember(username).subscribe(member =>{     
      this.member = member;
    })
  }
}
