-- USE db_sp;
USE db_sp;

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


-- Preguntas para el puesto de "Vendedor"
INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Tiene experiencia en ventas?', 1, 1),
    ('¿Puede trabajar en equipo?', 1, 1),
    ('¿Cómo abordaría a un cliente indeciso?', 1, 1),
    ('¿Qué técnicas de persuasión de ventas utiliza?', 1, 1),
    ('¿Cómo maneja el rechazo o las objeciones de los clientes?', 1, 1);

-- Respuestas para las preguntas del puesto de "Vendedor"
-- Pregunta 1
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí', 1, 1, 1),
    ('No', 2, 1, 1),
    ('A veces', 3, 1, 1);

-- Pregunta 2
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí', 1, 2, 1),
    ('No', 2, 2, 1),
    ('Depende de la situación', 3, 2, 1);

-- Pregunta 3
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Abordaría sus necesidades con amabilidad', 1, 3, 1),
    ('Utilizaría técnicas de persuasión efectivas', 2, 3, 1),
    ('Escucharía sus necesidades y ofrecería soluciones', 3, 3, 1);

-- Pregunta 4
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Utilizo técnicas de persuasión efectivas', 1, 4, 1),
    ('Soy empático y ofrezco soluciones', 2, 4, 1),
    ('Destaco los beneficios del producto', 3, 4, 1);

-- Pregunta 5
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Manejo objeciones de manera profesional', 1, 5, 1),
    ('Sigo vendiendo con paciencia', 2, 5, 1),
    ('Ofrezco alternativas cuando hay objeciones', 3, 5, 1);

-- Preguntas para el puesto de "Encargado de Producto Pequeño"
INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Cómo gestionaría el inventario de productos pequeños?', 2, 1),
    ('Hábleme sobre su experiencia en la organización de productos en espacios reducidos.', 2, 1),
    ('¿Cómo se aseguraría de que los productos pequeños estén siempre disponibles para los clientes?', 2, 1),
    ('¿Tiene experiencia en el manejo de productos perecederos?', 2, 1),
    ('¿Cómo optimizaría el espacio de almacenamiento para productos pequeños?', 2, 1);

-- Respuestas para las preguntas del puesto de "Encargado de Producto Pequeño"
-- Pregunta 6
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí', 1, 6, 1),
    ('No', 2, 6, 1),
    ('A veces', 3, 6, 1);

-- Pregunta 7
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Tengo experiencia en organización de espacios reducidos', 1, 7, 1),
    ('Siempre mantengo productos disponibles', 2, 7, 1),
    ('Soy meticuloso en la organización', 3, 7, 1);

-- Pregunta 8
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Productos siempre disponibles y accesibles', 1, 8, 1),
    ('Sé cómo anticipar la demanda de productos pequeños', 2, 8, 1),
    ('Garantizo un flujo constante de productos pequeños', 3, 8, 1);

-- Pregunta 9
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí, experiencia con productos perecederos', 1, 9, 1),
    ('Gestiono productos perecederos de manera eficiente', 2, 9, 1),
    ('Conozco las medidas de conservación de productos perecederos', 3, 9, 1);

-- Pregunta 10
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Optimizo el espacio con estanterías', 1, 10, 1),
    ('Utilizo sistemas de almacenamiento eficientes', 2, 10, 1),
    ('Maximizo el uso del espacio disponible', 3, 10, 1);

-- Preguntas para el puesto de "Encargado de Bodega"
INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Cómo gestionaría el inventario en una bodega?', 3, 1),
    ('Hábleme sobre su experiencia en la supervisión de operaciones de bodega.', 3, 1),
    ('¿Cómo se aseguraría de que los productos estén correctamente almacenados y etiquetados en la bodega?', 3, 1),
    ('¿Tiene experiencia en la gestión de personal de bodega?', 3, 1),
    ('¿Cómo manejaría el flujo de entrada y salida de productos en la bodega?', 3, 1);

-- Respuestas para las preguntas del puesto de "Encargado de Bodega"
-- Pregunta 11
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí', 1, 11, 1),
    ('No', 2, 11, 1),
    ('A veces', 3, 11, 1);

-- Pregunta 12
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('He supervisado operaciones de bodega con éxito', 1, 12, 1),
    ('Tengo experiencia en la gestión de personal de bodega', 2, 12, 1),
    ('Soy meticuloso en la organización de productos', 3, 12, 1);

-- Pregunta 13
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Productos correctamente etiquetados y almacenados', 1, 13, 1),
    ('Utilizo sistemas de gestión de inventario', 2, 13, 1),
    ('Sigo protocolos de almacenamiento precisos', 3, 13, 1);

-- Pregunta 14
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('He gestionado equipos de bodega', 1, 14, 1),
    ('Tengo experiencia en la capacitación de personal de bodega', 2, 14, 1),
    ('Fomento un ambiente de trabajo eficiente', 3, 14, 1);

-- Pregunta 15
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Optimizo el flujo de productos en la bodega', 1, 15, 1),
    ('Utilizo sistemas de seguimiento de inventario', 2, 15, 1),
    ('Minimizo el tiempo de almacenamiento de productos', 3, 15, 1);

-- Preguntas para el puesto de "Asistente de Bodega Administrativo"
INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Cómo apoyaría las operaciones administrativas en una bodega?', 4, 1),
    ('Hábleme sobre su experiencia en la documentación y seguimiento de inventarios.', 4, 1),
    ('¿Cómo gestionaría los registros de entrada y salida de productos en una bodega?', 4, 1),
    ('¿Tiene experiencia en la generación de informes de inventario?', 4, 1),
    ('¿Cómo se aseguraría de que los productos estén correctamente registrados y organizados?', 4, 1);

-- Respuestas para las preguntas del puesto de "Asistente de Bodega Administrativo"
-- Pregunta 16
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Apoyaría con documentación y registro', 1, 16, 1),
    ('Tengo experiencia en documentación de bodega', 2, 16, 1),
    ('Utilizo sistemas de seguimiento de inventario', 3, 16, 1);

-- Pregunta 17
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Registro y seguimiento precisos de productos', 1, 17, 1),
    ('Genero informes de inventario detallados', 2, 17, 1),
    ('Documentación y registro meticuloso', 3, 17, 1);

-- Pregunta 18
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Gestiono registros de entrada y salida', 1, 18, 1),
    ('Utilizo sistemas de seguimiento en tiempo real', 2, 18, 1),
    ('Mantengo registros actualizados de productos', 3, 18, 1);

-- Pregunta 19
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Sí, genero informes de inventario', 1, 19, 1),
    ('Tengo experiencia en la presentación de informes', 2, 19, 1),
    ('Informes precisos y oportunos', 3, 19, 1);

-- Pregunta 20
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Productos siempre registrados y organizados', 1, 20, 1),
    ('Mantengo registros meticulosos', 2, 20, 1),
    ('Utilizo software de gestión de inventario', 3, 20, 1);


-- Preguntas para el puesto de "Asistente de Bodega"
INSERT INTO PREGUNTAS (PREGUNTA, ID_PUESTO, ID_ESTADO) VALUES
    ('¿Cómo apoyaría las operaciones en una bodega?', 5, 1),
    ('Hábleme sobre su experiencia en la organización y mantenimiento de un área de bodega.', 5, 1),
    ('¿Cómo se aseguraría de que los productos estén siempre disponibles y accesibles?', 5, 1),
    ('¿Tiene experiencia en el manejo de equipos y maquinaria de bodega?', 5, 1),
    ('¿Cómo manejaría la recepción y despacho de productos en una bodega?', 5, 1);

-- Respuestas para las preguntas del puesto de "Asistente de Bodega"
-- Pregunta 21
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Colaboro en operaciones de bodega', 1, 21, 1),
    ('Tengo experiencia en organización de bodega', 2, 21, 1),
    ('Maximizo la disponibilidad de productos', 3, 21, 1);

-- Pregunta 22
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Mantengo orden y limpieza en el área de bodega', 1, 22, 1),
    ('Cuido la organización de productos en la bodega', 2, 22, 1),
    ('Experiencia en mantenimiento de áreas de almacenamiento', 3, 22, 1);

-- Pregunta 23
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Siempre disponibles y accesibles para el equipo', 1, 23, 1),
    ('Optimizo el espacio de almacenamiento', 2, 23, 1),
    ('Uso de sistemas de acceso rápido', 3, 23, 1);

-- Pregunta 24
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Manejo equipos y maquinaria de bodega', 1, 24, 1),
    ('Experiencia en operación de equipos de bodega', 2, 24, 1),
    ('Conozco el funcionamiento de maquinaria de bodega', 3, 24, 1);

-- Pregunta 25
INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES
    ('Optimizo la recepción y despacho de productos', 1, 25, 1),
    ('Velocidad en la entrega de productos', 2, 25, 1),
    ('Sigo procedimientos precisos de recepción y despacho', 3, 25, 1);


-- Postulación 1
INSERT INTO POSTULACIONES (ID_CONVOCATORIA, ID_POSTULANTE, ID_USUARIO, ID_ESTADO, ID_ESTADO_ENTREVISTA) VALUES
    (1, 1, 'usuario1', 1, 1);
-- Postulación 2
INSERT INTO POSTULACIONES (ID_CONVOCATORIA, ID_POSTULANTE, ID_USUARIO, ID_ESTADO, ID_ESTADO_ENTREVISTA) VALUES
    (2, 2, 'usuario2', 1, 1);


