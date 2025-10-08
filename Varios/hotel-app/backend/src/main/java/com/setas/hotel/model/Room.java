package main.java.com.setas.hotel.model;

import jakarta.persistence.*;
import lombok.*;

@Entity
@Table(name="habitaciones")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Room {
    @Id
    private Long id;

    private String numero;
    private String tipo;
    private Double precioPorNoche;
    private String estado;
}

