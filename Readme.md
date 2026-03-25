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

### 3. Ejecutar el Cliente Web (Blazor)

**La API debe estar corriendo antes de iniciar el cliente.**

1. Abrir una terminal en la carpeta `CitasMedicas_Blazor/CitasMedicas_Blazor/`
2. Ejecutar:


3. El cliente estara disponible en `https://localhost:7005`
