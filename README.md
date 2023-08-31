# API Simple de la Tienda

Esta es una API simple para gestionar productos en una tienda virtual. Los productos se caracterizan por su descripción y precio. Esta API permite realizar operaciones básicas de creación, lectura, actualización y eliminación (CRUD) de productos.

# Endpoints

## `GET /api/productos`

Obtiene una lista de todos los productos disponibles en la tienda.

### Respuesta

- Código de estado: 200 (OK)
- Cuerpo de respuesta:
  ```json
  [
    {
      "description": "Producto 1",
      "price": 19.99
    },
    {
      "description": "Producto 2",
      "price": 29.99
    },
    // ...
  ]

## `GET /api/productos/{id}`
Obtiene los detalles de un producto específico en función de su ID.

- Parámetros de URL
id (string): El ID único del producto.
### Respuesta
- Código de estado: 200 (OK)
- Cuerpo de respuesta:
```json
{
  "description": "Producto 1",
  "price": 19.99
}
```
- Código de estado: 404 (No encontrado)
```json
{
  "message": "Producto no encontrado"
}
```

## `POST /api/productos`
Agrega un nuevo producto a la tienda.

- Datos de solicitud
Cuerpo de solicitud (JSON):
```json
{
  "description": "Nuevo producto",
  "price": 9.99
}
```
## Respuesta
Código de estado: 201 (Creado)
- Cuerpo de respuesta:
```json

{
  "id": "nuevo-id-generado",
  "description": "Nuevo producto",
  "price": 9.99
}
```

## `PUT /api/productos/{id}`
Actualiza los detalles de un producto existente.

- Parámetros de URL
id (string): El ID único del producto.
- Datos de solicitud
- Cuerpo de solicitud (JSON):
```json

{
  "description": "Producto actualizado",
  "price": 14.99
}
```
### Respuesta
- Código de estado: 200 (OK)
- Cuerpo de respuesta:
```json
{
  "id": "id-del-producto",
  "description": "Producto actualizado",
  "price": 14.99
}
```
## `DELETE /api/productos/{id}`
Elimina un producto de la tienda.

- Parámetros de URL
- id (string): El ID único del producto.
### Respuesta
- Código de estado: 204 (Sin contenido)
- 
# Errores
La API devuelve los siguientes códigos de estado en caso de error:

- 400 (Solicitud incorrecta): Cuando la solicitud no es válida o falta algún parámetro.
- 404 (No encontrado): Cuando un recurso solicitado no existe.
- 500 (Error interno del servidor): En caso de un error en el servidor.

