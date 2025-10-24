# README

## Cadena de conexión a BD y migraciones
Cada desarrollador deberá borrar su cadena de conexión en (appsettings.json) a la base de datos antes de realizar un commit.
Tu cadena de conexion antes de cada commit deberá ser:
```
"server=localhost;database=apiRestFulDataBase;user=TU_USUARIO-BORRARLO;password=TU_CONTRASEÑA_BORRARLA;"
```


Comandos para efectuar la migración:
```
// Migracion:

dotnet ef migrations add InitialCreate \
  --project ApiRestFul.Infrastructure \
  --startup-project ApiRestFul.Api
  
 
// Creacion de la BD en MySql:
 
 dotnet ef database update \
  --project ApiRestFul.Infrastructure \
  --startup-project ApiRestFul.Api
```

