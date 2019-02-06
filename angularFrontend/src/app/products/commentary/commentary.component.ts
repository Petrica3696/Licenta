import { Component, OnInit, Input } from '@angular/core';
import { Comment, User } from 'src/app/_models';
import { UserService } from 'src/app/_services';

@Component({
  selector: 'app-commentary',
  templateUrl: './commentary.component.html',
  styleUrls: ['./commentary.component.scss']
})
export class CommentaryComponent implements OnInit {

  @Input() comment: Comment;
  user: User = new User();
  username: string;
  userDetails: User = new User();

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getById(this.comment.userId).subscribe(user => {
      this.user = user;
      this.userService.getUserCredentials().subscribe(
        userDetails => {
          this.userDetails = userDetails;
          if(userDetails.username == user.username) {
            this.username = "You";
          }
        }
      );
    });
  }

}
