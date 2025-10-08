package main.java.com.setas.hotel.controller;
@RestController
@RequestMapping("/api/clients")
public class ClientController {
    private final ClientRepository repo;
    public ClientController(ClientRepository r){ this.repo=r; }

    @GetMapping public List<Client> all(){ return repo.findAll(); }
    @PostMapping public Client add(@RequestBody Client c){ return repo.save(c); }
    @GetMapping("/{id}") public ResponseEntity<Client> one(@PathVariable Long id){
        return repo.findById(id).map(ResponseEntity::ok).orElse(ResponseEntity.notFound().build());
    }
}