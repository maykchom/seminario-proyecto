USE db_sp;

INSERT INTO ESTADOS (ESTADO) VALUES
    ('Activo'),
    ('Inactivo'),
    ('Pendiente');

INSERT INTO ROLES (ROL) VALUES
    ('Administración'),
    ('Secretaria');


INSERT INTO GENEROS (GENERO) VALUES
    ('Masculino'),
    ('Femenino');


INSERT INTO USUARIOS (ID_USUARIO, NOMBRES, APELLIDOS, TELEFONO, DIRECCION, CORREO, FECHA_NACIMIENTO, PASSWORD, ID_GENERO, ID_ROL, ID_ESTADO) VALUES
    ('usuario1', 'Juan', 'Pérez', '12345678', 'Calle 123', 'juan@example.com', '1990-01-15', 'password1', 1, 1, 1),
    ('usuario2', 'María', 'Gómez', '98765432', 'Avenida 456', 'maria@example.com', '1985-05-20', 'password2', 2, 2, 1);


INSERT INTO PUESTOS (TITULO, DESCRIPCION, PERFIL, ID_ESTADO) VALUES
    ('Bodega', 'Encargado de la bodega', 'Perfil del encargado de la bodega', 1),
    ('Auxiliar de Bodega', 'Ayudante en la bodega', 'Perfil del auxiliar de bodega', 1),
    ('Caja', 'Cajero de la empresa', 'Perfil del cajero', 1),
    ('Secretaria', 'Asistente administrativa', 'Perfil de la secretaria', 1);


INSERT INTO POSTULANTES (NOMBRES, APELLIDOS, FECHA_NACIMIENTO, DIRECCION, TELEFONO, CORREO, ID_GENERO, ID_ESTADO) VALUES
    ('Luis', 'Martínez', '1992-08-10', 'Calle 789', '56781234', 'luis@example.com', 1, 1),
    ('Ana', 'Rodríguez', '1988-03-25', 'Avenida 987', '43219876', 'ana@example.com', 2, 1);


INSERT INTO CONVOCATORIAS (FECHA_INICIO, FECHA_FIN, OBSERVACIONES, ID_PUESTO, ID_USUARIO, ID_ESTADO) VALUES
    ('2023-09-01', '2023-09-15', 'Convocatoria para puesto de Bodega', 1, 'usuario1', 1),
    ('2023-08-15', '2023-08-30', 'Convocatoria para puesto de Caja', 3, 'usuario2', 1);

INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Tiene experiencia en la gestión de inventarios?', 1, 1),
    ('¿Puede levantar objetos pesados?', 1, 1),
    ('¿Tiene experiencia en caja?', 3, 1),
    ('¿Tiene experiencia en atención al cliente?', 3, 1);

INSERT INTO RESPUESTAS (RESPUESTA, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí', 1, 1),
    ('No', 1, 1),
    ('Sí', 2, 1),
    ('No', 2, 1),
    ('Sí', 3, 1),
    ('No', 3, 1),
    ('Sí', 4, 1),
    ('No', 4, 1);

INSERT INTO POSTULACIONES (ID_CONVOCATORIA, ID_POSTULANTE, ID_USUARIO, ID_ESTADO) VALUES
    (1, 1, 'usuario1', 1),
    (2, 2, 'usuario2', 1);

INSERT INTO RESULTADOS (ID_POSTULACION, ID_RESPUESTA, ID_ESTADO) VALUES
    (1, 1, 1),
    (1, 3, 1),
    (2, 5, 1),
    (2, 7, 1);
