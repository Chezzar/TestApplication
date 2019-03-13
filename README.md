# TestApplication
TestApplication


Conexion a una base de datos sql server usando mvc asp

datos de la cadena de conexion ejemplo

data source = ServidorSQL; initial catalog = BaseDatos; user id = Usuario; password = Contraseña

para mysql

Hay que hacer referencia a:

using MySql.Data.MySqlClient;
Código de ejemplo en C#:

MySqlConnection conexion = new MySqlConnection();
conexion.ConnectionString = "Server=Servidor;Database=Nombre_de_la_base_de_datos; Uid=Nombre_de_usuario;Pwd=contraseña;";
conexion.Open();
