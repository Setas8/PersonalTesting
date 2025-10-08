package main.java.com.setas.hotel.controller;
@RestController
@RequestMapping("/api/rooms")
public class RoomController {
    private final RoomRepository repo;
    public RoomController(RoomRepository r){ this.repo=r; }

    @GetMapping public List<Room> all(){ return repo.findAll(); }
    @PostMapping public Room add(@RequestBody Room r){ return repo.save(r); }
}