# Diseño de tablas para sistema EDFC #

## Tablas:
  
- **CursosDisponibles**  
  Catalogo de cursos de los cuales se formarán grupos.  
  Ejemplo: `Curso básico Semestre 1 - La fé`
- **Maestros**  
  Catálogo de maestros.
- **CursosImpartidos**  
  Un curso del cual se formarán grupos, está ligado a CursoDisponibles.
  Tiene una fecha de inicio y fin y una frecuencia 
- **Grupos**  
  Un grupo al que se le ha asignado maestro, días hábiles y estudiantes 
- **GrupoEstudiantes**
  Estudiantes que pertenecen a un grupo	  
- **Estudiantes**  
  Datos de cada estudiante.
- **Kardexpagos**  
  Registro de los pagos que debe hacer el estudiante durante el curso
- **Pagos**  
  Registro de cada uno de los pagos realizados por cada estudiante
- **DiasInhabiles**  
  Dias feriados a nivel general y específicos por curso.

---
### Tabla : CursosDisponibles ###

**Campos:**  

- Id
- Nombre			- `varchar(100)`
- Duracion			- `int`
- DuracionUnidad	- `varchar(15)`
- Activo			- `char(1)`

---
### Tabla: Maestros ###

**Campos:**

- Id
- Nombre		- `varchar(15)`
- Activo		- `char(1)`


---
### Tabla: CursosImpartidos ###

**Campos:**

- Id
- CursoDisponibleId	- `int`
- Inicio			- `date`
- Fin				- `date`
- Inauguracion		- `datetime`
- Clausura			- `datetime`
- Activo			- `char(1)`

---
### Tabla: Grupos ###

**Campos:**

- Id
- CursoImpartidoId	- `int`
- DiasHabiles		- `varchar(7)`
- Maestro			- `varchar(50)`
- Aula				- `varchar(150)`

---
### Tabla: Estudiantes ###

**Campos:**

- id
- Apellidos		- `varchar(50)`
- Nombre		- `varchar(50)`
- Nacimiento	- `date`
- Parroquia		- `varchar(50)`

---
### Tabla: GrupoEstudiantes ###

**Campos:**

- Id
- GrupoId		- `int`
- EstudianteId	- `int`

---
### Tabla: DiasInhabiles ###

**Campos:**

- id
- CursoId		- `int`
- Fecha			- `date`
- Motivo		- `varchar(100)`

---
### Tabla: KardexPagos ###

**Campos:**

- Id
- EstudianteId	- `int`
- GrupoId		- `int`
- Periodo		- `int`
- Importe		- `decimal(18,2)`
- MontoPagado	- `decimal(18,2)`
- Vencimiento	- `date`

---
### Tabla: Pagos ###

**Campos:**

- Id
- EstudianteId	- `int`
- GrupoId		- `int`
- Fecha			- `date`
- Monto			- `decimal(18,2)`

---



