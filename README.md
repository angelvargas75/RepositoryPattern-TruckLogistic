# Patrón Repositorio - Repository Pattern
<p align="justify">
El propósito esencial de este proyecto radica en brindar una comprensión detallada y concreta de cómo el Patrón Repositorio cobra vida en un contexto real. Esta exploración se lleva a cabo mediante una demostración práctica en el ámbito de una lógica de negocio ampliamente reconocida: la gestión de transporte de carga pesada en el sector logístico.
</p>
<p align="justify">
Dentro de esta implementación, el corazón del proceso es el repositorio. Actuando como el enlace central, este componente permite extraer datos desde distintas fuentes de almacenamiento. Lo que resulta aún más interesante es que la aplicación cliente, que consume y utiliza estos datos, permanece completamente ajena a las complejidades relacionadas con el origen y el procesamiento de la información.
</p>
<a href="https://www.linkedin.com/feed/update/urn:li:activity:7098011063845019648/">Demo</a>
<br>
<br>

## Tecnologías utilizadas
|Tecnología|Versión  |
|--|--|
| ASP.NET WebApplication WebForms | NET Framework 4.8 |
| C# | 7.3 |
| Entity Framework | 6.4.4 |
| Bootstrap | 5.2.3 |
| Swiper | 10.1.0 |
| AutoMapper | 10.1.1 |
| SQL Server Management Studio | 2019 Express |
| MongoDB | 2.19.0 |

<br>

## Introducción 
<p align="justify">
El patrón repositorio se utiliza para crear una capa de abstracción entre la aplicación y el almacenamiento de datos, permitiendo que la aplicación interactúe con el almacenamiento de datos de forma estandarizada sin tener que conocer los detalles de cómo se almacenan los datos. Esto hace que el código sea modular, comprobable y mantenible.
</p>

<p align="center">
  <img src="https://i.ibb.co/3c5SyKm/rp01.png" alt="img01">
</p>

<p align="justify">
El cliente o consumidor no tiene por qué saber sobre el acceso a los datos, solamente que los puede recuperar y modificar. También nos permite desacoplar y testear de una forma más sencilla nuestro código, ya que al estar desacoplado podemos generar pruebas unitarias con mayor facilidad.
</p>
<p align="justify">
Este patrón nos brinda la posibilidad de cambiar la tecnología de almacenamiento de datos sin afectar el código de la aplicación, lo que puede ser útil cuando necesite reemplazar o escalar su almacenamiento de datos. Uno de los casos más comunes es cuando se necesita tener varias fuentes de datos o tecnologías de almacenamiento en una aplicación. Al crear un contenedor de repositorio, podemos consolidar toda la lógica del repositorio en un solo lugar, lo que puede ayudar a reducir la duplicación y hacer que el código sea más fácil de mantener.
</p>

<p align="center">
  <img src="https://i.ibb.co/dmXjmgb/rp02.png" alt="img02">
</p>
<br>

## Construcción 
<p align="justify">
Para este caso modificamos la estructura del proyecto adaptándolo a nuestra lógica de negocio el cual es una Logística de transporte de carga pesada que se encarga de registrar a un conductor y su respectivo tipo de camión, al conductor se le asignara un trabajo. Asimismo, creamos la estructura de repositorios que nos permitan conectarnos a tres fuentes de datos distintas; SQL Server a través de Entity Framework para la entidad Conductor, MongoDB para la entidad Trabajo, y un Servicio WCF que mediante ADO.NET se conecta a otra base de datos SQL Server para la entidad Camión.
</p>
<p align="justify">
En nuestro proyecto Dominio se encuentran las clases Camion, Conductor y Trabajo el cual representan las entidades de dominio en la aplicación.
</p>
<p align="center">
  <img src="https://i.ibb.co/WP8Z622/1.png" alt="img03">
</p>
<br>

<p align="justify">
En la carpeta <i>Repositorios</i> se encuentra un proyecto repositorio para cada fuente de datos, ya que cada uno se maneja de forma distinta, adicionalmente un proyecto Contrato que contendrá las Interfaces que se deberán usar para cada entidad de dominio. Finalmente, en la carpeta <i>Cliente Web</i> contendrá la aplicación cliente ASP.NET WebForms que contendrá las reglas de negocio especificas del proyecto web.
</p>
<p align="justify">
La implementación de nuestros repositorios tendrá un repo para SQL Server, otro para MongoDB y otro para un Servicio WCF.
</p>
<p align="center">
  <img src="https://i.ibb.co/1R0xrG8/2.png" alt="img04">
</p>
<br>

<p align="justify">
El proyecto de <b>Contrato</b> contiene las interfaces para cada repositorio, que definirán el contrato a implementar por los repositorios que vamos a crear o nuevos repos que puedan surgir en el futuro y que usen nuestras entidades de dominio.
</p>
<p align="justify">
El proyecto <b>SQLRepository</b> contiene una clase para representar el contexto de Entity Framework que interactúa con una base de datos SQL Server llamada TruckDriver, usando el enfoque de EF Code First. Adicionalmente tenemos una clase BaseRepository, la cual contiene todas las operaciones básicas que pueden aplicar para cualquier entidad que se tenga que interactuar con la base de datos. En el interior de la carpeta Conductor, la clase Conductor se encarga de mapear la tabla Conductor de la tabla Conductor de la base de datos y su configuración a través de “DataAnnotations” y ConductorRepository es el repositorio específico para realizar operaciones con la tabla Conductor que a su vez hereda de nuestro repositorio base para implementar las operaciones que este expone. En este caso usamos la biblioteca “AutoMapper” para mapear la entidad <i>Conductor</i> de CodeFirst a nuestra entidad de domino Conductor, que se encuentra en el proyecto de dominio, y es la entidad devuelta por el repositorio y usada por los clientes que consuman el repo, esto con el fin de que todos los clientes hablen en términos del domino y todo quede centralizado en estas entidades.
</p>
<p align="center">
  <img src="https://i.ibb.co/QchbfF9/3.png" alt="img05">
</p>
<br>

<p align="justify">
En el proyecto <b>MongoRepository</b> utilizamos la entidad <i>Trabajo</i> y también tenemos un repositorio base que nos permite conectarnos a una base de datos MongoDB y realizar operaciones sobre esa colección. En el interior de la carpeta Trabajo encontramos una clase Trabajo que representa la tabla en la base de datos y que a su vez será mapeado por Automapper a nuestra entidad de dominio Trabajo. Finalmente, el repositorio especifico TrabajoRepository realizara las operaciones que heredan del repo base.
</p>
<p align="center">
  <img src="https://i.ibb.co/PggpVsb/4.png" alt="img06">
</p>
<br>

<p align="justify">
Y la última implementación de los repositorios, el proyecto <b>ServicioRepository</b> que manejara la entidad <i>Camion</i>. En este caso usaremos directamente la entidad de dominio Camion, por lo que no necesitaremos del uso de AutoMapper, tendremos un repositorio base el cual se encarga de consumir el servicio WCF. Dentro de la solución se implementó una carpeta <i>Servicios Externos</i> para la creación del servicio WCF el cual realiza operaciones mediante ADO.NET conectado a otra base de datos SQL Server llamada Truck, este contiene una tabla Camion para guardar los datos del dominio Camion. En el interior de la carpeta Camion se encuentra nuestro repo especifico CamionRepository que a su vez hereda del repo base para realizar las operaciones sobre la entidad domino Camion. 
</p>
<p align="center">
  <img src="https://i.ibb.co/HXzFxdH/5.png" alt="img07">
</p>
<br>

<p align="justify">
Para consumir estos repositorios usaremos un ASP.NET WebForms como aplicación cliente. Dentro contiene un módulo <i>Mantenimiento</i> para administrar la página Conductor y Trabajo. Para poder comunicarnos con los repositorios debemos referenciar a nuestro proyecto, de esta forma obtenemos acceso a las diferentes fuentes de datos (SQL Server, MongoDB, Servicio WCF) y nuestra aplicación no sabrá de donde provienen los datos y por ende estará desacoplada del acceso a datos.
</p>
<p align="center">
  <img src="https://i.ibb.co/mv28C59/6.png" alt="img08">
</p>
<br>

<p align="justify">
Para las páginas del módulo Mantenimiento se implementó el patrón <i>Repository Wrapper (envoltorio de repositorio)</i>, el cual es un patrón de diseño que proporciona una interfaz simplificada para acceder a uno o más repositorios de manera consistente. Definimos las propiedades de tipo interfaz para cada repo especifico que vamos a usar, lo que ayudara a reducir la instanciación innecesaria de repositorios. 
</p>
<p align="justify">
En la página Conductor se encuentra una tabla con el listado de los conductores disponibles, y cada registro contiene un botón para editar o eliminar el conductor. El botón Nuevo redirecciona a la página EditarConductor para crear un nuevo conductor y su respectivo tipo de camión. Cuando seleccionamos un registro que queramos editar nos redirige a la página EditarConductor, el cual enviara mediante la URL el id de ese conductor para poder cargar los datos del conductor y los datos del camión.  Por el contrario, si queremos eliminar ese registro, pulsamos sobre el botón Eliminar y nos aparecerá una ventana modal para confirmar la eliminación. 
</p>
<p align="justify">
En la página Trabajo se encuentra un control textbox para ingresar el nombre del conductor el cual será previamente cargado mediante Ajax y también un control de tipo carrusel el cual contiene una imagen, una tabla con información del tipo de trabajo y un botón para seleccionar ese trabajo. Al dar clic en el botón seleccionar, redirige a la página ConfirmarTrabajo para confirmar todos los datos del trabajo antes de ser enviado. Mediante State Maintenance de ASP.NET se guarda el id del trabajo seleccionado en una variable de Session para que la página de confirmación lo reciba y pueda cargar los datos del trabajo y conductor.
</p>
<br>


## Desafíos
<ul align="justify">
 <li>
  Con el fin de eliminar redundancias en los datos, se implementó una validación de controles en ASP.NET mediante el uso de los validadores RequiredFieldValidator y RegularExpressionValidator. Estos validadores garantizan, en el lado del servidor, que los controles cumplan con las restricciones específicas establecidas, contribuyendo así a la integridad y coherencia de los datos.
 </li>
<li>
En la sección "Trabajo", se implementaron controles de Ajax con el propósito de lograr una carga de datos instantánea al aplicar filtros al nombre del conductor. Esta solución evita la necesidad de efectuar un "postback" al servidor y, en su lugar, permite una experiencia más ágil al usuario al cargar los datos de manera rápida y eficiente.
</li>
 <li>
Para la elección de un diseño, el cliente solicitó la implementación de un control de carrusel. El control de carrusel (Carousel / Slideshow) se utiliza específicamente para presentar diapositivas de imágenes y desplazar elementos. Sin embargo, en el contexto de Bootstrap, esta elección resultó problemática debido al comportamiento predeterminado del código JavaScript, que realiza un renderizado de página y dificulta la obtención del ID del elemento seleccionado. Como alternativa, se tomó la decisión de emplear la biblioteca Swiper, una herramienta en JavaScript diseñada con un enfoque especial en la personalización y la usabilidad táctil, especialmente apta para la creación de carruseles altamente adaptables y responsivos. Para superar el desafío, se aprovechó la opción de configurar tanto el código JavaScript como el CSS. De esta manera, fue posible incorporar elementos diversos, como imágenes, tablas y botones, en las diapositivas del carrusel. Además, se logró obtener con éxito el ID del elemento seleccionado, lo que permitió el envío de esta información al backend y la posterior conservación de los trabajos realizados por el cliente.
</li>
 <li>
Con el fin de administrar el estado en las páginas de ASP.NET y permitir una interacción continua entre el usuario y el servidor durante las solicitudes y respuestas, se emplearon diversas estrategias. Se recurrió al mecanismo de ASP.NET denominado "State Maintenance" para asegurar la continuidad de la información. Además, se aprovechó el "Session State" para obtener el id del conductor a lo largo de su sesión en el sitio web. De manera adicional, se empleó el "Query String" para obtener identificadores de objetos y transmitirlos a otras páginas, garantizando así la carga precisa de los datos.
</li>
 <li>
En la sección Conductor, en la tabla que muestra el listado de conductores, el botón Eliminar se considera un control potencialmente riesgoso. Por lo tanto, se tomó la decisión de implementar una ventana modal de confirmación como medida de precaución. Esta ventana modal se basa en una función JavaScript simple denominada "confirm", con el propósito de evitar cualquier eliminación accidental por parte del usuario.
</li>
</ul>

<br>

## Enlaces de referencia
- http://www.eltavo.net/2014/08/patrones-implementando-patron.html
- https://github.com/Eltavo/PatronesDisenoC-Sharp
- https://www.code-review.tech/repository-pattern-for-modular-code/#what-is-the-repository-pattern
- https://www.mongodb.com/docs/manual/
- https://play.google.com/store/apps/details?id=com.WandaSoftware.TruckersofEurope3&hl=en_US&pli=1
- https://getbootstrap.com/docs/5.3/getting-started/introduction/
- https://swiperjs.com/demos

<br>


## Agradecimiento
<p align="justify">
El impacto de este proyecto trasciende sus límites, convirtiéndose en una contribución significativa al ámbito del código abierto. Su influencia se enlaza con la destacada serie dedicada al Patrón Repositorio en C#, alojada en el blog "El Tavo". Quiero expresar mi más sincero agradecimiento a "El Tavo" por compartir su experiencia en el desarrollo de software, un factor fundamental en la génesis de este proyecto.
</p>
<p align="justify">
Asimismo, este proyecto se enriqueció con la inspiración proveniente de la aplicación "Truckers of Europe 3", desarrollada por Wanda Software. Esta dimensión adicional agrega una profundidad única a su relevancia y alcance.
</p>
<p align="justify">
Es importante reconocer también el papel esencial que desempeñan las bibliotecas y herramientas de código abierto que empleamos en este proyecto. Su contribución no pasa desapercibida y ha sido esencial para llevar a cabo esta visión.
</p>
<p align="justify">
En última instancia, es el eco colectivo de todos estos esfuerzos lo que da vida a este proyecto y lo transforma en un recurso valioso para la comunidad en su conjunto.
</p>

<br>

## Licencia
MIT License

Copyright (c) 2023 Angel Vargas

<p align="justify">
Se concede permiso, de forma gratuita, a cualquier persona que obtenga una copia de este software y los archivos de documentación asociados (el "Software"), para utilizar el Software sin restricciones, incluyendo, entre otras, las de copiar, modificar, fusionar, publicar, distribuir, sublicenciar y/o vender copias del Software, y permitir a las personas a las que se les proporcione el Software hacer lo mismo, sujeto a las siguientes condiciones:
</p>

El aviso de copyright anterior y este aviso de permiso se incluirán en todas las copias o partes sustanciales del Software.

Para más detalles, consulta la [Licencia MIT](https://opensource.org/licenses/MIT).

<p align="justify">
EL SOFTWARE SE PROPORCIONA "TAL CUAL", SIN GARANTÍA DE NINGÚN TIPO, EXPRESA O IMPLÍCITA, INCLUYENDO PERO NO LIMITADO A GARANTÍAS DE COMERCIABILIDAD, APTITUD PARA UN PROPÓSITO PARTICULAR Y NO INFRACCIÓN. EN NINGÚN CASO, LOS AUTORES O TITULARES DE LOS DERECHOS DE AUTOR SERÁN RESPONSABLES POR CUALQUIER RECLAMO, DAÑO U OTRA RESPONSABILIDAD, YA SEA EN UNA ACCIÓN DE CONTRATO, AGRAVIO O CUALQUIER OTRO MOTIVO, QUE SURJA DE O EN RELACIÓN CON EL SOFTWARE O EL USO U OTROS TRATOS EN EL SOFTWARE.
</p>
