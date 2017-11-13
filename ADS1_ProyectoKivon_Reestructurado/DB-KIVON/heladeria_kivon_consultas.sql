-- 1. enlistar los usuarios con sus garantes
select concat(u.primerNombre," ", u.apellidoPaterno) as 'Nombre', concat(ru.primerNombre," ", ru.apellidoPaterno) as 'Garante'
from usuario u, referencia_usuario ru
where u.ID_usuario = ru.ID_usuario;

-- 2. dado el tipo de rol, enlistar todos los usuarios que pertenecen a ese rol
select *
from usuario
where ID_rol = 3;
