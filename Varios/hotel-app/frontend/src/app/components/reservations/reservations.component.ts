import { Component } from '@angular/core';
import { ReservationService } from '../../services/reservation.service';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html'
})
export class ReservationsComponent {
  reservas: any[] = [];
  constructor(private rs: ReservationService) {}
  load() { this.rs.list().subscribe(d => this.reservas = d); }
  cancel(id: number) { this.rs.cancel(id).subscribe(() => this.load()); }
}
