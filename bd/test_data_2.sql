USE db_sp;
--DROP DATABASE db_sp;

INSERT INTO ESTADOS (ESTADO) VALUES
    ('Activo'),
    ('Inactivo'),
    ('Pendiente');

INSERT INTO ROLES (ROL) VALUES
    ('Administrador'),
    ('Secretaria');

INSERT INTO GENEROS (GENERO) VALUES
    ('Masculino'),
    ('Femenino');

INSERT INTO ESTADOS_ENTREVISTA (ESTADO_ENTREVISTA) VALUES
    ('Pendiente'),
    ('Realizada'),
    ('No Realizada');


-- Usuario 1
INSERT INTO USUARIOS (ID_USUARIO, NOMBRES, APELLIDOS, TELEFONO, DIRECCION, CORREO, FECHA_NACIMIENTO, PASSWORD, ID_GENERO, ID_ROL, ID_ESTADO) VALUES
    ('usuario1', 'Juan', 'Pérez', '12345678', 'Calle 123', 'juan@example.com', '1990-01-15', 'password1', 1, 1, 1);
-- Usuario 2
INSERT INTO USUARIOS (ID_USUARIO, NOMBRES, APELLIDOS, TELEFONO, DIRECCION, CORREO, FECHA_NACIMIENTO, PASSWORD, ID_GENERO, ID_ROL, ID_ESTADO) VALUES
    ('usuario2', 'María', 'Gómez', '98765432', 'Avenida 456', 'maria@example.com', '1985-05-20', 'password2', 2, 2, 1);


INSERT INTO PUESTOS (TITULO, DESCRIPCION, PERFIL, ID_ESTADO) VALUES
    ('Vendedor', 'Venta de productos', 'Perfil del vendedor', 1),
    ('Encargado de Producto Pequeño', 'Supervisión de productos pequeños', 'Perfil del encargado de producto pequeño', 1),
    ('Encargado de Bodega', 'Responsable de la bodega', 'Perfil del encargado de bodega', 1),
    ('Asistente de Bodega Administrativo', 'Asistencia administrativa en bodega', 'Perfil del asistente de bodega administrativo', 1),
    ('Asistente de Bodega', 'Ayudante en la bodega', 'Perfil del asistente de bodega', 1);


-- Postulante 1
INSERT INTO POSTULANTES (NOMBRES, APELLIDOS, FECHA_NACIMIENTO, DIRECCION, TELEFONO, CORREO, ID_GENERO, ID_ESTADO) VALUES
    ('Luis', 'Martínez', '1992-08-10', 'Calle 789', '56781234', 'luis@example.com', 1, 1);
-- Postulante 2
INSERT INTO POSTULANTES (NOMBRES, APELLIDOS, FECHA_NACIMIENTO, DIRECCION, TELEFONO, CORREO, ID_GENERO, ID_ESTADO) VALUES
    ('Ana', 'Rodríguez', '1988-03-25', 'Avenida 987', '43219876', 'ana@example.com', 2, 1);


-- Convocatoria 1
INSERT INTO CONVOCATORIAS (FECHA_INICIO, FECHA_FIN, OBSERVACIONES, ID_PUESTO, ID_USUARIO, ID_ESTADO) VALUES
    ('2023-09-01', '2023-09-15', 'Convocatoria para puesto de Vendedor', 1, 'usuario1', 1);
-- Convocatoria 2
INSERT INTO CONVOCATORIAS (FECHA_INICIO, FECHA_FIN, OBSERVACIONES, ID_PUESTO, ID_USUARIO, ID_ESTADO) VALUES
    ('2023-08-15', '2023-08-30', 'Convocatoria para puesto de Encargado de Bodega', 3, 'usuario2', 1);


-- Pregunta 1
INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Tiene experiencia en ventas?', 1, 1);
-- Pregunta 2
INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Puede trabajar en equipo?', 1, 1);
-- Pregunta 3
INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Tiene experiencia en gestión de inventarios?', 3, 1);
-- Pregunta 4
INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Puede liderar un equipo de trabajo?', 3, 1);


-- Respuestas para Pregunta 1
INSERT INTO RESPUESTAS (RESPUESTA, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí', 1, 1),
    ('No', 1, 1),
    ('A veces', 1, 1);
-- Respuestas para Pregunta 2
INSERT INTO RESPUESTAS (RESPUESTA, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí', 2, 1),
    ('No', 2, 1),
    ('Depende de la situación', 2, 1);
-- Respuestas para Pregunta 3
INSERT INTO RESPUESTAS (RESPUESTA, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí', 3, 1),
    ('No', 3, 1),
    ('Poco', 3, 1);
-- Respuestas para Pregunta 4
INSERT INTO RESPUESTAS (RESPUESTA, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí', 4, 1),
    ('No', 4, 1),
    ('Necesita más experiencia', 4, 1);


-- Postulación 1
INSERT INTO POSTULACIONES (ID_CONVOCATORIA, ID_POSTULANTE, ID_USUARIO, ID_ESTADO, ID_ESTADO_ENTREVISTA) VALUES
    (1, 1, 'usuario1', 1, 1);
-- Postulación 2
INSERT INTO POSTULACIONES (ID_CONVOCATORIA, ID_POSTULANTE, ID_USUARIO, ID_ESTADO, ID_ESTADO_ENTREVISTA) VALUES
    (2, 2, 'usuario2', 1, 1);


-- Resultado 1
INSERT INTO RESULTADOS (ID_POSTULACION, ID_RESPUESTA, ID_ESTADO) VALUES
    (1, 1, 1),
    (1, 7, 1);
-- Resultado 2
INSERT INTO RESULTADOS (ID_POSTULACION, ID_RESPUESTA, ID_ESTADO) VALUES
    (2, 2, 1),
    (2, 8, 1);
