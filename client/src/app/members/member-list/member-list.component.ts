import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
members: Member[];

  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
    this.getMembers()
  }

  getMembers(){
    this.memberService.getMembers().subscribe(members=>{
      members.forEach(member=>{
        member.username = member.username[0].toUpperCase()+ member.username.substring(1)
      })
      this.members = members;
    });
  }
}
