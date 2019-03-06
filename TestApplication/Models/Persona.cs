using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
    public class Persona
    {

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<Persona> todas()
        {

            Conexion con = new Conexion();

            List<Persona> personas = new List<Persona>();

            personas = con.Query("select * from dbo.Persona");

            return personas;
        }

        public List<Persona> porid(int id)
        {

            Conexion con = new Conexion();

            List<Persona> personas = new List<Persona>();

            personas = con.Query("sp_consultar_cliente", id);

            return personas;
        }


        public void insertar(int id, string nombre)
        {

            Conexion con = new Conexion();

            con.Insert("sp_insertar_cliente", id, nombre);

        }
    }
}