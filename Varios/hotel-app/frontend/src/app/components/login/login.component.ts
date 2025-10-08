import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  username = '';
  password = '';
  constructor(private auth: AuthService) {}
  login() {
    this.auth.login(this.username, this.password).subscribe(res => {
      this.auth.saveToken(res.token);
      alert("Login correcto");
    }, err => alert("Credenciales incorrectas"));
  }
}
