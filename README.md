## DIAGRAMA DDD
![Dibujo diagrama DDD](Diagramas/Diagrama.png)



### Vueling App
### Descripci�n y contexto
---
Aplicaci�n con arquitectura de capas DDD. Variables en App.Config y Resources.resx. Errores Generados en Log.Error y tratados con VuelingException personalizada.

####Base de Datos
Generamos la Base de Datos con los archivos SQL y FlyWayDB, configurando su archivo conf y con el comando flyway migrate.
Nos crear� 2 tablas. Client y Policy. Esta segunda tendr� una refer�ncia For�nea hacia la primera.


####Capa de Infraestructura
Tenemos separados, cumpliendo con el principio SRP, los proyectos en 2: Repositorio y contratos.
En los contratos encontramos 3 interfaces, incorporando as� el principio ISP:
1 para Client con sus m�todos propios.
Otra para Policy con los suyos.
Y otra con m�todos comunes como pueden ser Operaciones CRUD.

En la capa de Repositorio encontramos separados (SRP) DataModels y los Repositorios.
Los DataModels son generados con una clase ADO, la cual mapear� ambas tablas estableciendo la conexi�n previamente en el instalador.
En los Repositorios encontraremos 2 clases. Uno para Client y otro para Policy, los cuales se encargar�n de persistir y de gestionar los m�todos que requieran uso de la Base de datos con Entity Framework.


####Capa de Dominio
En esta encontraremos las entidades ClientEntity y PolicyEntity, las cuales son pr�cticamente id�nticas a sus versiones DataModels, pero he preferido tenerlas separadas para una mayor escalabilidad en el futuro y acostumbrarme as� a trabajar de maneras m�s enfocadas a proyectos de gran envergadura.
A esta capa acceder�n las capas de Aplicaci�n e Infraestructura.

####Capa de Applicaci�n
En esta encontraremos 3 proyectos: Contratos, Servicios y Dto.
En Contratos, encontraremos pr�cticamente lo mismo que en el de Contratos de Repositorio. Pero vuelvo a hacer incapi� enl a escalabilidad y la separaci�n de responsabilidades.
En Dto encontraremos las clases ClientDto y PolicyDto, los objetos "puente" podr�amos llamarlos. En este caso no se ped�an diferentes atributos a nivel de capa, pero conviene trabajar con un modelo por capa para mayor reusabilidad modificando lo menos posible o nada el c�digo actual (OCP).
En Servicios, tenemos uno por cada modelo: ClientService y PolicyService.
Estos son los encargados de la l�gica de negocio. Se encargar� de transmitir los m�todos que requieran persistencia a la capa de Infraestructura y viceversa.
Una vez resuelvan la demanda junto a la capa inferior, le pasar� los datos a la WebApi para que pueda dar la respuesta.

####Web Api
La Api act�a de Facade, como bien dice este patr�n de dise�o concreto, para que de ah� para abajo, el usuario no sepa nada.
Mediante los controladores ClientApiController y PolicyApiController, esta WebApi REST se encarga de gestionar las peticiones que le entren mediante URL espec�ficas, y seg�n demanden datos sobre Clientes o P�lizas, ser�n sus controladores los encargados de gestionar las peticiones y las respuestas, comunic�ndose con los Modelos Dto y la capa de Aplicacion.
Los TokenControllers, son los encargados de gestionar la autenticaci�n cada vez que alguien intenta consumir nuestra api. Mediante el username y el id, obtendr�n un Token JWT. Este Token, almacenar� al crearse, el rol de dicho usuario para que seg�n que m�todos, tengan permisos o no.(Esta comprobaci�n de permisos a�n no est� implementada).
El HTTPApiController, es el encargado de, nada m�s iniciarse la aplicaci�n, hacer 2 llamadas al Web Service, proporcion�ndonos todos los Clientes y todas las Polizas, guard�ndolas en la base de datos. De esta manera, estar� cargada nada m�s iniciarse.
(Faltar�a por implementar el Temporizador para que ataque al WebService cada hora, con Quartz).
En la carpeta ViewModels he creado los ViewModels, aunque no los hemos necesitado por ahora es una buena opci�n tenerlos hechos por si quisi�ramos a�adir la parte visual m�s adelante y tener mayor escalabilidad de nuevo.

####Capa Com�n
Aqu� he creado la VuelingException para personalizar y controlar todos los errores, a la vez que los guardamos en Error.log con Serilog.


####Capa de Testing
En esta capa hemos hecho 1 o 2 Tests Unitarios con mocks y de Integraci�n, ya que he priorizado el resto de la Aplicaci�n que es m�s importante, para por lo menos ver la presencia y el uso de los mismos. Me hubiera gustado poder a�adir un test funcional tambi�n.




### Gu�a de usuario
---
He priorizado Clean Code, SOLID y terminar todas las funcionalidades que pudiera, antes que a�adir documentaci�n. Prefiero un c�digo l�mpio de primeras y cuidado desde el minuto 1, que hecho r�pido con malas pr�cticas y documentado.
Soy m�s de los de pensar que un buen c�digo, legible, escalable y reutilizable, no necesita documentaci�n.

####GET  http://localhost:57896/api/ClientApi 
Devuelve todos los clientes
####GET  http://localhost:57896/api/ClientApi/id
Devuelve un cliente mediante su id
####GET  http://localhost:57896/api/ClientApi/name/nombre
Devuelve un cliente mediante su nombre
####GET  http://localhost:57896/api/ClientApi/policy/idPoliza
Devuelve un cliente mediante el id de una poliza contratada

####GET  http://localhost:57896/api/PolicyApi
Devuelve todas la polizas
####GET  http://localhost:57896/api/PolicyApi/idPoliza
Devuelve una Poliza mediante su id
####GET  http://localhost:57896/api/PolicyApi/policies/nombre
Devuelve la lista de polizas de un cliente por su nombre




####POST  http://localhost:57896/api/ClientApi
Inserta un cliente

####POST  http://localhost:57896/api/PolicyApi
Inserta una poliza

 	
### Gu�a de instalaci�n
---
## SOFTWARE UTILIZADO
Windows 10 Pro 64 bits

Microsoft .NET Framework V.4.7.02556

Microsoft Visual Studio Enterprise 2017 V.15.7.4

SQL Server 2017 Developer Edition


## FRAMEWORKS
-EntityFramework, EntityFramework.SQL.Compact

-FlyWayDB

-Automapper

-Serilog

-Microsoft.IdentityModel.Tokens version 5.2.1
-Microsoft.IdentityModel.Tokens.Jwt version 5.2.1
-Microsoft.IdentityModel.Logging version 5.2.1

-MSTest

-Moq v4.9.0


### Autor/es
---
Carlos L�pez Santamar�a


### Principios SOLID utilizados
---
Single Responsability
Open Close
Interface Segregation


### Otros principios y patrones utilizados
---
YAGNI - 'You Aren't Gonna Need It'. 
-ResverseMap en automapper �nicamente cuando era necesario y no siempre "por si acaso en el futuro". No instanciar variables que solo necesitar�a una vez.

DRY 
He intentado en general no repetir c�digo tontamente y aplicar DRY desde el inicio del proyecto.


### Ejemplos Clean Code
---
Variables con nombres entendibles (clientDto, listClientDto, listClientEntity, clientEntityAdded, etc)
Separaci�n entre l�neas que no est�n relacionadas entre s�.
Todos los par�metros de configuraci�n y textos en archivos .resx y .config.
Legibilidad en general.
No comentarios intentando que el c�digo ya se entienda de por si.
Y otras cosas que probablemente las aplique sin darme cuenta porque me han ense�ado a programar de manera bastante legible y entendible.


