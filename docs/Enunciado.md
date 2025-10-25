# Taller Célula – Sistema de Gestión de Clientes y Pedidos

---

# 🧩 Proyecto: API RESTful de Clientes y Pedidos (.NET 8)

## 🎯 **Objetivo General**

Desarrollar una **API RESTful completa** utilizando **.NET 8**, aplicando **arquitectura por capas (DDD)** y **Entity Framework Core**, que permita **gestionar clientes y los pedidos que estos realizan**.

---

## 🏢 **Contexto**

Una empresa necesita un sistema básico para **administrar sus clientes y los pedidos que estos hacen**.
Cada pedido puede tener **varios productos**, una **fecha de creación** y un **estado** que indique su progreso (por ejemplo: `Pendiente`, `Enviado` o `Cancelado`).

Tu tarea será crear la base de este sistema, **estructurada de forma limpia y mantenible**, aplicando buenas prácticas de desarrollo.

---

## ⚙️ **1️⃣ Requisitos Técnicos**

### 🧱 Arquitectura por Capas (DDD)

El proyecto debe estar dividido en **4 capas principales**:

| Capa               | Descripción                                                                           |
| ------------------ | ------------------------------------------------------------------------------------- |
| **Api**            | Contendrá los controladores y endpoints.                                              |
| **Application**    | Contendrá los servicios (lógica de negocio).                                          |
| **Domain**         | Contendrá las entidades (modelos del dominio).                                        |
| **Infrastructure** | Contendrá la configuración de Entity Framework Core, el DbContext y los repositorios. |

---

## 🗄️ **2️⃣ Base de Datos**

* Se debe utilizar **Entity Framework Core**.
* Puede usarse **SQLite** o **SQL Server LocalDB**.
* Debe existir una **migración inicial** con:

  ```bash
  dotnet ef migrations add InitialCreate
  ```
* La base de datos debe generarse con:

  ```bash
  dotnet ef database update
  ```

---

## 🧩 **3️⃣ Entidades Mínimas**

Implementa al menos las siguientes entidades:

### 🧍‍♂️ Customer

* `Id` (int)
* `Name` (string)
* `Email` (string)

### 📦 Order

* `Id` (int)
* `CustomerId` (int)
* `OrderDate` (DateTime)
* `Status` (string) → valores posibles: `Pendiente`, `Enviado`, `Cancelado`

### 🧾 OrderDetail

* `Id` (int)
* `OrderId` (int)
* `ProductName` (string)
* `Quantity` (int)
* `UnitPrice` (double)

> 💡 **Opcional:** puedes agregar la entidad `Product` para ampliar la práctica.

---

## 🌐 **4️⃣ Controladores RESTful**

Debes crear los siguientes **controladores** y definir sus **endpoints**.
Cada método representa una **operación CRUD** sobre las entidades principales.

---

### 👤 **CustomersController**

| Método   | Endpoint              | Descripción                     |
| -------- | --------------------- | ------------------------------- |
| **GET**  | `/api/customers`      | Listar todos los clientes       |
| **GET**  | `/api/customers/{id}` | Obtener un cliente por ID       |
| **POST** | `/api/customers`      | Crear un nuevo cliente          |
| **PUT**  | `/api/customers/{id}` | Actualizar un cliente existente |

🪶 **Paso a paso sugerido**

1. Crear el controlador `CustomersController` dentro de la capa `Api`.
2. Inyectar el servicio `CustomerService` mediante **inyección de dependencias**.
3. Implementar cada método con su respectivo verbo HTTP (`GET`, `POST`, `PUT`).
4. Validar que los datos recibidos sean correctos antes de llamar al servicio.

---

### 📦 **OrdersController**

| Método   | Endpoint           | Descripción                             |
| -------- | ------------------ | --------------------------------------- |
| **GET**  | `/api/orders`      | Listar todos los pedidos                |
| **GET**  | `/api/orders/{id}` | Obtener un pedido con sus detalles      |
| **POST** | `/api/orders`      | Crear un nuevo pedido con sus productos |
| **PUT**  | `/api/orders/{id}` | Actualizar el estado de un pedido       |

🪶 **Paso a paso sugerido**

1. Crear el controlador `OrdersController` dentro de la capa `Api`.
2. Inyectar el servicio `OrderService`.
3. Crear los endpoints necesarios para manejar los pedidos.
4. Asegurar que el pedido esté correctamente relacionado con su cliente.
5. Probar los endpoints con Postman.

---

## 🧠 **5️⃣ Buenas Prácticas y Evaluación**

✅ El código debe seguir los **principios de arquitectura limpia**.
✅ Los **controladores no deben tener lógica de negocio**, solo deben **delegar a los servicios**.
✅ Los **servicios** deben interactuar con los **repositorios** definidos en la capa `Infrastructure`.
✅ La base de datos debe ser **persistente y funcional**.
✅ Los **endpoints deben probarse correctamente con Postman**.

---

## 💡 **Recomendaciones Finales**

* Usa nombres claros y consistentes para tus clases y métodos (`CustomerService`, `OrderRepository`, etc.).
* Mantén las responsabilidades separadas:

    * Controladores → reciben peticiones y devuelven respuestas.
    * Servicios → contienen la lógica del negocio.
    * Repositorios → se encargan de acceder a la base de datos.
* Realiza pruebas de tus endpoints con ejemplos reales (clientes, pedidos y productos).
* Evita duplicar código entre controladores.
* Usa `DTOs` (Data Transfer Objects) si deseas mejorar la organización entre la capa `Api` y `Application`.

---
