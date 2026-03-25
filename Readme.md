# CitaMedica API

**DEV:** Pedro Gamiño

**Fecha:** 26 de marzo de 2026


---

## Instrucciones para ejecutar el proyecto

### 1. Base de datos

1. Abrir SQL Server Management Studio (SSMS)
2. Ejecutar los archivos `.sql` incluidos en el proyecto contra la base de datos `CitaMedicaDB`
3. Verificar que las tablas y stored procedures se hayan creado correctamente

### 2. Ejecutar la API (.NET Core)

1. Abrir una terminal en la carpeta `CitaMedica_API/CitaMedica_API/`
2. Ajustar la cadena de conexion en `appsettings.json` a tu instancia de SQL Server
3. Ejecutar:

4. La API estara disponible en `https://localhost:7158`
5. Swagger UI: `https://localhost:7158/swagger`

#### Endpoints de la API

**Medicos** - `api/medico`
- `GET /api/medico` - Listar todos los medicos
- `GET /api/medico/{id}` - Obtener medico por Id
- `POST /api/medico` - Crear medico
- `PUT /api/medico/{id}` - Actualizar medico
- `DELETE /api/medico/{id}` - Eliminar medico
- `POST /api/medico/horario` - Agregar horario de consulta

**Pacientes** - `api/paciente`
- `GET /api/paciente` - Listar todos los pacientes
- `GET /api/paciente/{id}` - Obtener paciente por Id
- `POST /api/paciente` - Crear paciente
- `PUT /api/paciente/{id}` - Actualizar paciente
- `DELETE /api/paciente/{id}` - Eliminar paciente

**Citas** - `api/cita`
- `GET /api/cita` - Listar todas las citas
- `GET /api/cita/{id}` - Obtener cita por Id
- `POST /api/cita/agendar` - Agendar nueva cita
- `PUT /api/cita/cancelar/{id}` - Cancelar cita con motivo

**Agenda** - `api/agenda`
- `POST /api/agenda/citasdeldia` - Citas del dia de un medico
- `GET /api/agenda/historialcitas/{id}` - Historial de citas de un paciente
- `POST /api/agenda/horariosdisponibles` - Horarios disponibles de un medico

### 3. Ejecutar el Cliente Web (Blazor)

**La API debe estar corriendo antes de iniciar el cliente.**

1. Abrir una terminal en la carpeta `CitasMedicas_Blazor/CitasMedicas_Blazor/`
2. Ejecutar:

3. El cliente estara disponible en `https://localhost:7005`

#### Paginas del Cliente

- `/medicos` - CRUD de medicos y asignacion de horarios de consulta
- `/pacientes` - CRUD de pacientes
- `/citas` - Agendar y cancelar citas medicas
