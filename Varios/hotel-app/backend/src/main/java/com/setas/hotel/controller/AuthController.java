package main.java.com.setas.hotel.controller;

import com.setas.hotel.security.JwtUtils;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Map;

@RestController
@RequestMapping("/auth")
public class AuthController {

    private final JwtUtils jwtUtils;

    public AuthController(JwtUtils jwtUtils) {
        this.jwtUtils = jwtUtils;
    }

    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody Map<String,String> body) {
        String user = body.get("username");
        String pass = body.get("password");
        // DEMO: autenticación hardcoded — reemplaza por DB / LDAP en real
        // en producción se usa almacenamiento seguro (BCrypt + DB).
        if ("user".equals(user) && "Pass123".equals(pass)) {
            String token = jwtUtils.generateToken(user);
            return ResponseEntity.ok(Map.of("token", token));
        }
        return ResponseEntity.status(401).body(Map.of("error", "Invalid credentials"));
    }
}
