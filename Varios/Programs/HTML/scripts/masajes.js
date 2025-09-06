function calcularTurno() {
    const viajeros = parseInt(document.getElementById("viajeros").value);
    const masajes = parseInt(document.getElementById("masajes").value);
    const posicion = parseInt(document.getElementById("posicion").value);
    let anfitrion = 1;
    let masajistas = 0;

    // Determinar anfitrión y masajistas según reglas
    if (viajeros >= 1 && viajeros <= 3) {
    if (masajes >= 1 && masajes <= 4) {
        anfitrion = 1; masajistas = 0;
    } else if (masajes >= 5 && masajes <= 10) {
        anfitrion = 1; masajistas = 1;
    } else if (masajes >= 11 && masajes <= 12) {
        anfitrion = 1; masajistas = 2;
    }
    } else if (viajeros >= 4 && viajeros <= 10) {
    if (masajes >= 0 && masajes <= 6) {
        anfitrion = 1; masajistas = 1;
    } else if (masajes >= 7 && masajes <= 12) {
        anfitrion = 1; masajistas = 2;
    } else if (masajes >= 13 && masajes <= 18) {
        anfitrion = 1; masajistas = 3;
    } else if (masajes >= 19 && masajes <= 24) {
        anfitrion = 1; masajistas = 4;
    } else if (masajes >= 25 && masajes <= 30) {
        anfitrion = 1; masajistas = 5;
    } else if (masajes > 30) {
        anfitrion = 1; masajistas = 6;
    }
    } else {
    anfitrion = 0; masajistas = 0;
    }

    const total = anfitrion + masajistas;

    // Evaluar si entras a trabajar o no
    let mensaje = `Resultado: ${anfitrion} Anfitrión + ${masajistas} Masajista(s) = ${total} en lista. `;
    if (!isNaN(posicion)) {
    if (posicion <= total && total > 0) {
        mensaje += `✅ Estás en la posición ${posicion}. Entras, apúntate en el cuadrante.`;
        document.getElementById("resultado").className = "resultado entra";
    } else {
        mensaje += `❌ Estás en la posición ${posicion}. No entras, no te apuntes en el cuadrante.`;
        document.getElementById("resultado").className = "resultado no-entra";
    }
    } else {
    document.getElementById("resultado").className = "resultado";
    }

    document.getElementById("resultado").innerText = mensaje;
}