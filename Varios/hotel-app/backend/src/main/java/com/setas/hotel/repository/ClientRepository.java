package main.java.com.setas.hotel.repository;

import com.riu.hotel.model.Client;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ClientRepository extends JpaRepository<Client, Long> {}
