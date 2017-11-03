select idusuario from usuario where ci = "8333482"
union
select idcliente from cliente where ci="8333482"
union
select idreferenciausuario from referenciausuario where ci="8333482";
