package main.java.com.setas.hotel.model;

import jakarta.persistence.*;
import lombok.*;
import java.time.LocalDateTime;
import java.util.Date;

@Entity
@Table(name="reservas")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Reservation {
    @Id
    private Long id;

    @Column(name="cliente_id")
    private Long clienteId;

    @Column(name="habitacion_id")
    private Long habitacionId;

    @Temporal(TemporalType.DATE)
    private Date fechaInicio;

    @Temporal(TemporalType.DATE)
    private Date fechaFin;

    private Double total;
    private String estado;
    private LocalDateTime creadoEn;
}

