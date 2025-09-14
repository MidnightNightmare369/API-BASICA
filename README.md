
# API-BASICA 

API correspondiente al taller #1 de la asignatura aplicaciones y servicios web. 
# Enunciado
Basado en el siguiente modelo para empleados (Employee):  

-   ID - entero
-   FristName - cadena, obligatorio, máximo 30 caracteres.
-   LastName - cadena, obligatorio, máximo 30 caracteres.
-   IsActive - booelano
-   HireDate - fecha/hora
-   Salary - Decimal, obligatorio, mínimo $1,000,000.

  
  
Cree una API restfull con las operaciones básicas:  

-   GET - Todos
-   GET - Por ID
-   GET - Por nombres o apellidos, es decir este GET debe recibir como parámetro una cadena de letras por ejemplo: “ju” y traes todos los empleados cuyos nombres o apellidos contenga esta cadena, por ejemplo, nombres como: “Juan”, “Julian”, “Ana Julia” o apellidos “Juarez”, “San Juan”, ETC
-   POST - creación
-   PUT - edición
-   DELETE - borrado

**Notas**

-   Cree un NUEVO repositorio con su cuenta de GIT (no reuse el ejemplo de clase).
-   Cree una solución en blanco NUEVA (no cree esta nueva API en el jemplo de clase), con su biblioteca de clases aparte (Shared), del proyecto de API.
-   Debe implementar el patrón Repository - Unit of work y utilizar genéricos.
-   Debe adicionar un alimentador a la base de datos que cree al menos 10 registros.