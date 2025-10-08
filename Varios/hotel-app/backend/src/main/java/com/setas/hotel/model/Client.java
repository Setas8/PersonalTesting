package main.java.com.setas.hotel.model;

import jakarta.persistence.*;
import lombok.*;

@Entity
@Table(name="clientes")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Client {
    @Id
    private Long id;

    private String nombre;
    private String email;
    private String telefono;
}
