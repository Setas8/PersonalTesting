package main.java.com.setas.hotel.service;

import org.springframework.stereotype.Service;
import javax.sql.DataSource;
import java.sql.*;

@Service
public class ReservationService {
    private final DataSource dataSource;

    public ReservationService(DataSource ds) { this.dataSource = ds; }

    public long createReservation(long clienteId, long habitacionId, Date inicio, Date fin) {
        try (Connection conn = dataSource.getConnection();
             CallableStatement cs = conn.prepareCall("{ call crear_reserva(?, ?, ?, ?, ?) }")) {
            cs.setLong(1, clienteId);
            cs.setLong(2, habitacionId);
            cs.setDate(3, inicio);
            cs.setDate(4, fin);
            cs.registerOutParameter(5, Types.NUMERIC);

            cs.execute();
            return cs.getLong(5);
        } catch (SQLException ex) {
            int code = ex.getErrorCode();
            // Mapear errores controlados (-20001 etc.) a excepciones/HTTP apropiadas
            throw new RuntimeException(ex);
        }
    }

    public void cancelReservation(long reservaId) {
        try (Connection conn = dataSource.getConnection();
             CallableStatement cs = conn.prepareCall("{ call cancelar_reserva(?) }")) {
            cs.setLong(1, reservaId);
            cs.execute();
        } catch (SQLException ex) {
            throw new RuntimeException(ex);
        }
    }
}
