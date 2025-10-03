-- Crear esquema (si la imagen no lo hizo, el contenedor createAppUser ya puede haber creado hotel_user)
-- Tablas: clientes, habitaciones, reservas, auditoria
CREATE TABLE clientes (
  id            NUMBER PRIMARY KEY,
  nombre        VARCHAR2(100) NOT NULL,
  email         VARCHAR2(150) UNIQUE NOT NULL,
  telefono      VARCHAR2(20),
  notas         CLOB,
  creado_en     TIMESTAMP DEFAULT SYSTIMESTAMP
);

CREATE TABLE habitaciones (
  id               NUMBER PRIMARY KEY,
  numero           VARCHAR2(10) UNIQUE NOT NULL,
  tipo             VARCHAR2(30),
  precio_por_noche NUMBER(10,2),
  estado           VARCHAR2(20) DEFAULT 'DISPONIBLE'
);

CREATE TABLE reservas (
  id            NUMBER PRIMARY KEY,
  cliente_id    NUMBER NOT NULL,
  habitacion_id NUMBER NOT NULL,
  fecha_inicio  DATE NOT NULL,
  fecha_fin     DATE NOT NULL,
  total         NUMBER(10,2),
  estado        VARCHAR2(20) DEFAULT 'ACTIVO',
  creado_en     TIMESTAMP DEFAULT SYSTIMESTAMP,
  CONSTRAINT fk_cliente FOREIGN KEY(cliente_id) REFERENCES clientes(id),
  CONSTRAINT fk_habitacion FOREIGN KEY(habitacion_id) REFERENCES habitaciones(id)
);

CREATE TABLE reservas_auditoria (
  id          NUMBER PRIMARY KEY,
  reserva_id  NUMBER,
  accion      VARCHAR2(20),
  fecha       TIMESTAMP DEFAULT SYSTIMESTAMP,
  usuario     VARCHAR2(50)
);

-- Secuencias
CREATE SEQUENCE seq_clientes START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seq_habitaciones START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seq_reservas START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seq_reservas_auditoria START WITH 1 INCREMENT BY 1;

-- Datos de ejemplo
INSERT INTO clientes (id, nombre, email, telefono) VALUES (seq_clientes.NEXTVAL, 'Ana García', 'ana@setas.com', '600111222');
INSERT INTO clientes (id, nombre, email, telefono) VALUES (seq_clientes.NEXTVAL, 'Luis Martínez', 'luis@setas.com', '600333444');

INSERT INTO habitaciones (id, numero, tipo, precio_por_noche) VALUES (seq_habitaciones.NEXTVAL, '101', 'SIMPLE', 70);
INSERT INTO habitaciones (id, numero, tipo, precio_por_noche) VALUES (seq_habitaciones.NEXTVAL, '102', 'DOBLE', 120);

COMMIT;

-- PROCEDIMIENTO: crear_reserva (usa secuencia y valida solapamiento)
CREATE OR REPLACE PROCEDURE crear_reserva(
  p_cliente_id     IN NUMBER,
  p_habitacion_id  IN NUMBER,
  p_fecha_inicio   IN DATE,
  p_fecha_fin      IN DATE,
  p_reserva_id     OUT NUMBER
) IS
  v_conflict NUMBER;
  v_precio   NUMBER;
BEGIN
  IF p_fecha_inicio >= p_fecha_fin THEN
    RAISE_APPLICATION_ERROR(-20002, 'Fecha inicio debe ser anterior a fecha fin');
  END IF;

  SELECT COUNT(*) INTO v_conflict
  FROM reservas
  WHERE habitacion_id = p_habitacion_id
    AND estado = 'ACTIVO'
    AND NOT (p_fecha_fin <= fecha_inicio OR p_fecha_inicio >= fecha_fin);

  IF v_conflict > 0 THEN
    RAISE_APPLICATION_ERROR(-20001, 'Habitación no disponible');
  END IF;

  SELECT precio_por_noche INTO v_precio FROM habitaciones WHERE id = p_habitacion_id;

  SELECT seq_reservas.NEXTVAL INTO p_reserva_id FROM dual;
  INSERT INTO reservas(id, cliente_id, habitacion_id, fecha_inicio, fecha_fin, total, estado, creado_en)
  VALUES (p_reserva_id, p_cliente_id, p_habitacion_id, p_fecha_inicio, p_fecha_fin,
          (p_fecha_fin - p_fecha_inicio) * v_precio, 'ACTIVO', SYSTIMESTAMP);

  COMMIT;
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    RAISE_APPLICATION_ERROR(-20003, 'Cliente o habitación no encontrado');
  WHEN OTHERS THEN
    ROLLBACK;
    RAISE;
END crear_reserva;
/

-- PROCEDIMIENTO: cancelar_reserva
CREATE OR REPLACE PROCEDURE cancelar_reserva(p_reserva_id IN NUMBER) IS
  v_exists NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_exists FROM reservas WHERE id = p_reserva_id;
  IF v_exists = 0 THEN
    RAISE_APPLICATION_ERROR(-20004, 'Reserva no existe');
  END IF;
  UPDATE reservas SET estado = 'CANCELADO' WHERE id = p_reserva_id;
  COMMIT;
END cancelar_reserva;
/

-- TRIGGER auditoría
CREATE OR REPLACE TRIGGER trg_auditoria_reservas
AFTER INSERT OR UPDATE OR DELETE ON reservas
FOR EACH ROW
BEGIN
  IF INSERTING THEN
    INSERT INTO reservas_auditoria(id, reserva_id, accion, usuario)
    VALUES (seq_reservas_auditoria.NEXTVAL, :NEW.id, 'INSERT', USER);
  ELSIF UPDATING THEN
    INSERT INTO reservas_auditoria(id, reserva_id, accion, usuario)
    VALUES (seq_reservas_auditoria.NEXTVAL, :NEW.id, 'UPDATE', USER);
  ELSIF DELETING THEN
    INSERT INTO reservas_auditoria(id, reserva_id, accion, usuario)
    VALUES (seq_reservas_auditoria.NEXTVAL, :OLD.id, 'DELETE', USER);
  END IF;
END;
/

-- VISTA: reservas activas simplificada
CREATE OR REPLACE VIEW vista_reservas_activas AS
SELECT r.id, c.nombre cliente, h.numero habitacion, r.fecha_inicio, r.fecha_fin, r.total
FROM reservas r
JOIN clientes c ON c.id = r.cliente_id
JOIN habitaciones h ON h.id = r.habitacion_id
WHERE r.estado = 'ACTIVO';
/
