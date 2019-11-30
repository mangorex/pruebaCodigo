# Proyecto: pruebaCodigo

Este proyecto es una prueba de código para que se pueda observar o intuir mi nivel, claridad de código, de pensamiento, y lo más importante, de ganas de comerse el donut

## Comenzando 🚀

_Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas._

### Pre-requisitos 📋

Se necesita tener instalado .Net Core 3, git y Visual Studio Code... Puede que se pueda desplegar y probar de otra manera, pero solo digo lo que yo usé :)

## Construido con 🛠️

_Estas son las herramientas que decidí usar_

* [.Net Core 3.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/sdk-for-vs-code?utm_source=vs-code&amp;utm_medium=referral&amp;utm_campaign=sdk-install) - El kit de desarrollo de software usado de .Net
* [Visual Studio Code](https://code.visualstudio.com/) - IDE
* [Git](https://git-scm.com/book/es/v2/Fundamentos-de-Git-Obteniendo-un-repositorio-Git) - Usado como sistema de gestión de versiones

### Instalación 🔧

* _Instalar .NET Core 3.0 SDK_
* _Instalar Visual Studio Code_
* _Instalar Git_
* _Instalar Newtonsoft.Json desde NuGet_

_dotnet add package Newtonsoft.Json_

_git clone https://github.com/mangorex/pruebaCodigo.git_

## Ejecutando las pruebas ⚙️

* _Ejecutar dotnet run en el directorio pruebaCodigo, que incluye el json (el nombre debe ser datos-json)_
* _Pulsar tecla y si necesita ver el estado inicial en json_
* _Pulsar una tecla para meter en la carcel a Jhon y ver por pantalla el organigrama (por consola)_
* _Pulsar una tecla para liberar a Jhon y ver por pantalla el organigrama (por consola)_
* _Pulsar una tecla para imprimir por pantalla al más alto cargo de la banda (seniorMember)_
* _Pulsar una tecla para encarcelar al más alto cargo de la banda (seniorMember) y ver por pantalla el organigrama (por consola)_
* _Pulsar una tecla para establecer como más alto cargo de la banda (seniorMember) a Francis y ver por pantalla el organigrama (por consola). NOTA: Este punto no sé si había que hacerlo así, pero lo entendí así (PARTE PLUS. PUNTO 2)_
* _Pulsar una tecla para liberar al antiguo más alto cargo de la banda (oldSeniorMember) y ver por pantalla el organigrama (por consola)_

### Analice las pruebas end-to-end 🔩

_Estas pruebas tratan de verificar si se ha desarrollado correctamente el programa pedido_

```
Entiendo que cumple, al menos a nivel técnico con lo prometido, ya que se puede observar
como va cambiando el listado de miembros, cuando se encarcela a un miembro y cuando se libera. 

Por ejemplo, antes de encarcelar a Jhon (segundo punto), se muestra lo siguiente:

Name: Jhon, seniority: 4, boss: Andy, subordinates:     
    Francis
    Pascual
Name: Francis, seniority: 1, boss: Jhon, subordinates:  
    NOBODY
Name: Pascual, seniority: 3, boss: Jhon, subordinates:  
    NOBODY
Name: Andy, seniority: 5, boss: NOBODY, subordinates:   
    Jhon
    Carl
    
Y después:

Name: Francis, seniority: 1, boss: Andy, subordinates:
    NOBODY
Name: Pascual, seniority: 3, boss: Andy, subordinates:
    NOBODY
Name: Andy, seniority: 5, boss: NOBODY, subordinates:
    Carl
    Francis
    Pascual
```

### Y las pruebas de estilo de codificación ⌨️

_Las pruebas de estilo de codificación, serviría para ver si el estilo de código es limpio y si sigue cierto estándar_

```
Por desgracia no he encontrado ninguna prueba automática. Me quedé sin tiempo, así que la prueba que
he hecho es echarle ojo, corazón y ganas, para realizar el mejor trabajo posible.
```

### Sugerencias de mejora
* Realizar de una manera más automática el deserializado del JSON, de forma que no haga falta la función readFromFile, que se encarga de leer el JSON, de procesarlo y de establecer los miembros y el listado de miembros. He tenido que desarrollar dicha función yo, porque no he averiguado como se hace la deserialización automática total, sin que se vulnere la protección de los atributos de las clases
* Mejorar todavía más la simplicidad del código. Creo que está bastante bien, pero siempre se puede mejorar, ¿no?... Al menos si hay tiempo jeje
* Realizar el organigrama visualmente, tal vez con OrgChart, un plugin accesible para .Net
* Limpiar quizás lo del listado de prisioneros, que tal vez no haga falta. Aún así, he de decir que me quedé sin tiempo y no es nada muy "guarro" (perdón por la expresión)


## Autor ✒️

* **Manuel Antonio Gómez Angulo** - *Proyecto y documentación* - [mangorex](https://github.com/mangorex/pruebaCodigo)

## Expresiones de Gratitud 🎁

* Agradezco David por hacerme partícipe de esta prueba 📢
* Doy las gracias a Jennie por pasarme el enunciado de la prueba 🤓
* Invito a una cerveza 🍺 o un café ☕ a las personas que me han hecho partícipe

---
⌨️ con ❤️ por [mangorex](https://github.com/mangorex) 😊
