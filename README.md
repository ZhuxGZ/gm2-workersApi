### Consigna:
**Crear API para manejar una BD de la gente que labura en GM.**
  1. Necesitamos almacenar Nombre, Dirección (Calle, número, código postal, provincia), fecha de ingreso, departamento, seniority, sueldo, proyecto actual (si es dev).
  2. Deb de People nos dijo que porfavor necesita poder filtrar a la gente (fijate que filtros consideras necesarios) y también le gustaría poder ordenar por fecha de ingreso y por sueldo.
  3. Obviamente necesitamos poder agregar nuevos proyectos (únicamente necesitamos el nombre y la gente que esta asignada)
  4. Necesitamos un endpoint para mostrar los empleados en la página de GM pero no queremos que se sepa el sueldo ya que lo consideramos un dato personal
  5. En el front vamos a mostrar directamente los mensajes proporcionados desde el BE, ya sea para procesos satisfactorios como para errores.
  6. Para la lista de Empleados nos gustaría contar con un páginado para poder limitar la cantidad de resultados y asi mejorar el rendimiento
