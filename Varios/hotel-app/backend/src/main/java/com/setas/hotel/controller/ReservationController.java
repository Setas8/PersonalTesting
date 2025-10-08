package main.java.com.setas.hotel.controller;
@RestController
@RequestMapping("/api/reservations")
public class ReservationController {
    private final ReservationRepository repo;
    private final ReservationService service;

    public ReservationController(ReservationRepository r, ReservationService s){ this.repo=r; this.service=s; }

    @GetMapping public List<Reservation> all(){ return repo.findAll(); }

    @PostMapping
    public ResponseEntity<?> create(@RequestBody Map<String,Object> payload){
        try {
            long clienteId = ((Number)payload.get("clienteId")).longValue();
            long habitacionId = ((Number)payload.get("habitacionId")).longValue();
            java.sql.Date inicio = java.sql.Date.valueOf(payload.get("fechaInicio").toString());
            java.sql.Date fin = java.sql.Date.valueOf(payload.get("fechaFin").toString());
            long id = service.createReservation(clienteId, habitacionId, inicio, fin);
            return ResponseEntity.ok(Map.of("reservaId", id));
        } catch(Exception e){
            return ResponseEntity.badRequest().body(Map.of("error", e.getMessage()));
        }
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> cancel(@PathVariable Long id){
        service.cancelReservation(id);
        return ResponseEntity.ok().build();
    }
}