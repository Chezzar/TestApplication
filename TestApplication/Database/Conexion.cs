using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
    public class Conexion
    {
        #region configuraciones
        private SqlConnection con = new SqlConnection();

        private string stringDB = "Data Source=CÉSAR-PC\\SQLEXPRESS;Initial Catalog=UsersBD;Integrated Security=True";

        public string StringDB {

            get { return stringDB; }

            set { stringDB = value; }
        }

        public Conexion()
        {
            con.ConnectionString = stringDB;
        }

        private void openCon() {

            try {
                con.Open();
                Console.WriteLine("conecion abierta");
            }
            catch (Exception ex) {
                Console.WriteLine("conexion fallida   " + ex.Message);
            }
        }

        private void closeCon()
        {

            con.Close();
        }

        #endregion configuraciones

        #region consultas
        private List<Persona> query(string consulta) {

            //abrimos la conexion
            openCon();

            //creamos el comando para la consulta
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            //hacemos la consulta
            SqlDataAdapter info = new SqlDataAdapter(cmd);
            //creamos una tabla para guaradar el resultado
            DataTable table = new DataTable();
            //llenamos la tabla
            info.Fill(table);

            //cerramos la conexion
            closeCon();

            List<Persona> personas = new List<Persona>();

            personas = llenarLista(table);

            return personas;
        }

        public List<Persona> Query(string consulta) {

            List<Persona> personas = new List<Persona>();

            personas = query(consulta);

            return personas;
        }

        public List<Persona> Query(string consulta, int id)
        {

            List<Persona> personas = new List<Persona>();

            personas = query(consulta, id);

            return personas;
        }

        private List<Persona> query(string procedure, int id)
        {
            SqlDataAdapter info = new SqlDataAdapter(procedure, con);

            openCon();

            info.SelectCommand.CommandType = CommandType.StoredProcedure;

            info.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            DataTable table = new DataTable();

            info.Fill(table);

            //cerramos la conexion
            closeCon();

            List<Persona> personas = new List<Persona>();

            personas = llenarLista(table);

            return personas;

        }

        private List<Persona> llenarLista(DataTable table) {

            List<Persona> personas = new List<Persona>();

            foreach (DataRow row in table.Rows)
            {

                int ID = 1;
                string nm = row["nombre"].ToString();

                Persona nuevo = new Persona()
                {
                    Id = ID,
                    Nombre = nm,
                };

                personas.Add(nuevo);
            }

            return personas;
        }

        #endregion consultas

        #region inserts


        private void insert(string procedure, int id, string nombre) {


            SqlCommand cmd = new SqlCommand(procedure, con);

            openCon();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;

            cmd.ExecuteNonQuery();

            //cerramos la conexion
            closeCon();

        }


        public void Insert(string procedure, int id, string nombre) {

            insert(procedure,id,nombre);

        }


        #endregion inserts
    }
}