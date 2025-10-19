package com.example.setas.setas_example.controller;

import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.GetMapping;


@RestController
public class CostumerController {
    @GetMapping("/customer")
    public String getCostumerInfo() {
        return "Hello Spring";
    }
    
}
