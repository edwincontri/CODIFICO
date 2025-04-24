# CODIFICO
StoreSample

(En caso de inconvenientes con la carpeta Front, se comprimieron los proyectos en CODIFICO.rar)

.NET Core
Cadena de coneccion a base de datos en "CODIFICO\SalesDatePrediction\Sales Date Prediction/appsettings.json"
Puerto configurado proyecto "https://localhost:7049" (Abre Swagger automaticamente)
API Rest, Arquitectura en capas, inyeccion de dependencias, principios SOLID

Angular 17
Angular Material
"https://localhost:4200"

```bash
Clonar el repositorio:
- git clone https://github.com/edwincontri/CODIFICO.git

Instala las dependencias: (se elimino carpeta "node_modules" por peso del proyecto en Angular)
- npm install

- Levantar la API (backend) 
Se ejecuta el proyecto de backend desarrollado en .NET Core. 
Esto expone una API REST con endpoints GET, POST 
Se ejecuta en el entorno de desarrollo Visual Studio, en el puerto https://localhost:7049.

- Levantar el frontend (Angular) 
Se ejecuta el proyecto Angular con ng serve. 
El frontend se inicia en http://localhost:4200. 
Este proyecto consume la API a través de servicios HTTP configurados para comunicarse con el backend. 
El frontend realiza peticiones HTTP (GET, POST) hacia los endpoints de la API. 
Se prueba que los datos se consulten y que se cree una orden de manera correcta 

Prueba manual/local 
Ambas aplicaciones se ejecutan localmente y se prueban de forma integrada. 
Se verifica que no haya errores de CORS, problemas de conexión, ni fallos en los datos. 
Se adjunta pantallazos de pruebas realizadas (adicional pruebas unitarias) 



