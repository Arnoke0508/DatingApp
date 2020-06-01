import { Component, Input } from '@angular/core';
import { User } from '../../_models/user';
import { AuthService } from '../../_services/auth.service';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})

export class MemberCardComponent {
  @Input() user: User;
  constructor(private authserveice: AuthService, private userService: UserService, private alertify: AlertifyService) {
  }

  ngOnInit() {
  }

  sendLike(id: number) {
    this.userService.sendLike(this.authserveice.decodedToken.nameid, id).subscribe(data => {
      this.alertify.succes('you have liked: ' + this.user.knownAs);
    }, error => {
      this.alertify.error(error);
    }
    );
  }
}
