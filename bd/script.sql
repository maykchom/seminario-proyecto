CREATE DATABASE db_sp;
USE db_sp;
-- DROP DATABASE db_sp;

-- TABLAS INDEPENDIENTES
CREATE TABLE ESTADOS(
    ID_ESTADO INT NOT NULL AUTO_INCREMENT,
    ESTADO VARCHAR(25) NOT NULL,
    CONSTRAINT PK_ESTADO PRIMARY KEY(ID_ESTADO)
);

CREATE TABLE ROLES(
    ID_ROL INT NOT NULL AUTO_INCREMENT,
    ROL VARCHAR(25) NOT NULL,
    CONSTRAINT PK_ROLES PRIMARY KEY(ID_ROL)
);

CREATE TABLE GENEROS(
    ID_GENERO INT NOT NULL AUTO_INCREMENT,
    GENERO VARCHAR(25) NOT NULL,
    CONSTRAINT PK_GENERO PRIMARY KEY(ID_GENERO)
);

-- TABLAS DEPENDIENTES DE 1ER. GRADO
CREATE TABLE USUARIOS(
    ID_USUARIO VARCHAR(15) NOT NULL,
    NOMBRES VARCHAR(100) NOT NULL,
    APELLIDOS VARCHAR(50) NOT NULL,
    TELEFONO VARCHAR(8) NOT NULL,
    DIRECCION VARCHAR(255) NOT NULL,
    CORREO VARCHAR(100) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL,
    PASSWORD VARCHAR(100) NOT NULL,
    ID_GENERO INT NOT NULL,
    ID_ROL INT NOT NULL,
    ID_ESTADO INT NOT NULL,    
    CONSTRAINT PK_USUARIO PRIMARY KEY(ID_USUARIO),
    CONSTRAINT FK_USUARIO_GENERO FOREIGN KEY(ID_GENERO) REFERENCES GENEROS(ID_GENERO),
    CONSTRAINT FK_USUARIO_ROL FOREIGN KEY(ID_ROL) REFERENCES ROLES(ID_ROL),
    CONSTRAINT FK_USUARIO_ESTADO FOREIGN KEY(ID_ESTADO) REFERENCES ESTADOS(ID_ESTADO)
);


CREATE TABLE PUESTOS(
    ID_PUESTO INT NOT NULL AUTO_INCREMENT,
    TITULO VARCHAR(255) NOT NULL,
    DESCRIPCION TEXT NOT NULL,
    PERFIL TEXT,
    ID_ESTADO INT NOT NULL,   
    CONSTRAINT PK_PUESTO PRIMARY KEY(ID_PUESTO),
    CONSTRAINT FK_PUESTO_ESTADO FOREIGN KEY(ID_ESTADO) REFERENCES ESTADOS(ID_ESTADO)
);

CREATE TABLE POSTULANTES(
    ID_POSTULANTE INT NOT NULL AUTO_INCREMENT,
    NOMBRES VARCHAR(100) NOT NULL,
    APELLIDOS VARCHAR(50) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL,
    DIRECCION VARCHAR(255) NOT NULL,
    TELEFONO VARCHAR(8) NOT NULL,
    CORREO VARCHAR(100) NOT NULL,
    ID_GENERO INT NOT NULL,    
    ID_ESTADO INT NOT NULL,    
    CONSTRAINT PK_POSTULANTE PRIMARY KEY(ID_POSTULANTE),
    CONSTRAINT FK_POSTULANTE_GENERO FOREIGN KEY(ID_GENERO) REFERENCES GENEROS(ID_GENERO),    
    CONSTRAINT FK_POSTULANTE_ESTADO FOREIGN KEY(ID_ESTADO) REFERENCES ESTADOS(ID_ESTADO)
);

-- TABLAS DEPENDIENTES DE 2DO. GRADO
CREATE TABLE CONVOCATORIAS(
    ID_CONVOCATORIA INT NOT NULL AUTO_INCREMENT,
    FECHA_INICIO DATE NOT NULL,
    FECHA_FIN DATE NOT NULL,
    OBSERVACIONES TEXT,
    ID_PUESTO INT NOT NULL,   
    ID_USUARIO VARCHAR(15) NOT NULL,   
    ID_ESTADO INT NOT NULL,   
    CONSTRAINT PK_CONVOCATORIA PRIMARY KEY(ID_CONVOCATORIA),
    CONSTRAINT FK_CONVOCATORIA_USUARIO FOREIGN KEY(ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO),
    CONSTRAINT FK_CONVOCATORIA_ESTADO FOREIGN KEY(ID_ESTADO) REFERENCES ESTADOS(ID_ESTADO)
);

CREATE TABLE PREGUNTAS(
    ID_PREGUNTA INT NOT NULL AUTO_INCREMENT,
    PREGUNTA VARCHAR(255) NOT NULL,
    ID_PUESTO INT NOT NULL,
    ID_ESTADO INT NOT NULL,   
    CONSTRAINT PK_PREGUNTA PRIMARY KEY(ID_PREGUNTA),
    CONSTRAINT FK_PREGUNTA_PUESTO FOREIGN KEY(ID_PUESTO) REFERENCES PUESTOS(ID_PUESTO),
    CONSTRAINT FK_PREGUNTA_ESTADO FOREIGN KEY(ID_ESTADO) REFERENCES ESTADOS(ID_ESTADO)
);

-- TABLAS DEPENDIENTES DE 3ER. GRADO
CREATE TABLE RESPUESTAS(
    ID_RESPUESTA INT NOT NULL AUTO_INCREMENT,
    RESPUESTA VARCHAR(255) NOT NULL,    
    ID_PREGUNTA INT NOT NULL,   
    ID_ESTADO INT NOT NULL,   
    CONSTRAINT PK_RESPUESTA PRIMARY KEY(ID_RESPUESTA),    
    CONSTRAINT FK_RESPUESTA_PREGUNTA FOREIGN KEY(ID_PREGUNTA) REFERENCES PREGUNTAS(ID_PREGUNTA),
    CONSTRAINT FK_RESPUESTA_ESTADO FOREIGN KEY(ID_ESTADO) REFERENCES ESTADOS(ID_ESTADO)
);

CREATE TABLE POSTULACIONES(
    ID_POSTULACION INT NOT NULL AUTO_INCREMENT,
    FECHA_POSTULACION TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ID_CONVOCATORIA INT NOT NULL,   
    ID_POSTULANTE INT NOT NULL,   
    ID_USUARIO VARCHAR(25) NOT NULL,       
    ID_ESTADO INT NOT NULL,   
    CONSTRAINT PK_POSTULACION PRIMARY KEY(ID_POSTULACION),    
    CONSTRAINT FK_POSTULACION_CONVOCATORIA FOREIGN KEY(ID_CONVOCATORIA) REFERENCES CONVOCATORIAS(ID_CONVOCATORIA),
    CONSTRAINT FK_POSTULACION_POSTULANTE FOREIGN KEY(ID_POSTULANTE) REFERENCES POSTULANTES(ID_POSTULANTE),
    CONSTRAINT FK_POSTULACION_USUARIO FOREIGN KEY(ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO),
    CONSTRAINT FK_POSTULACION_ESTADO FOREIGN KEY(ID_ESTADO) REFERENCES ESTADOS(ID_ESTADO)
);

-- TABLAS DEPENDIENTES DE 4TO. GRADO
CREATE TABLE RESULTADOS(
    ID_POSTULACION INT NOT NULL,   
    ID_RESPUESTA INT NOT NULL, 
    ID_ESTADO INT NOT NULL,   
    CONSTRAINT PK_RES_POSTULACION PRIMARY KEY(ID_POSTULACION, ID_RESPUESTA),    
    CONSTRAINT FK_RES_POSTULACION FOREIGN KEY(ID_POSTULACION) REFERENCES POSTULACIONES(ID_POSTULACION),
    CONSTRAINT FK_RES_RESPUESTA FOREIGN KEY(ID_RESPUESTA) REFERENCES RESPUESTAS(ID_RESPUESTA),
    CONSTRAINT FK_RES_ESTADO FOREIGN KEY(ID_ESTADO) REFERENCES ESTADOS(ID_ESTADO)
);