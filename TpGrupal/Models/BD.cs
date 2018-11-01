using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TpGrupal.Models;
using System.IO;

namespace TpGrupal.Models
{
    public static class BD
    {
        //private static string conexion = "Server=.;Database=QEQB06;Trusted_Connection=true;";
        private static string conexion = "Server=10.128.8.16;Database=QEQB06;User Id=QEQB06;Password=QEQB06;";
        private static SqlConnection Conectar()
        {
            SqlConnection conector = new SqlConnection(conexion);
            conector.Open();
            return conector;
        }
        private static void Desconectar(SqlConnection conector)
        {
            conector.Close();
        }

        public static int LoginUsuario(Usuarios x)
        {
            int Devolver = 0;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_LoginUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            consulta.Parameters.AddWithValue("@pMail", x.Mail);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                Devolver = Convert.ToInt32(dataReader["IDUsuario"]);
            }
                Desconectar(conexion);
            
            return Devolver;
        }
        public static void LogOut()
        {
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "Logout";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.ExecuteNonQuery();
            Desconectar(conexion);
        }

        public static bool VerSiEsAdmin()
        {
            bool Admin = false;
            string ver = "";
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_VerificarAdmin";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                ver = dataReader["Tipo"].ToString();
            }
            if (ver == "Admin")
            {
                Admin = true;
            }

            Desconectar(conexion);
            return Admin;
        }

        public static int VerSesion()
        {
            int retorno = 0;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "VerificarSesion";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                retorno = Convert.ToInt32(dataReader["IDUsuario"]);
            }
            Desconectar(conexion);

            return retorno;
        }
       ////////////////////ABM///CATEGORIA///////////////////////////////////////
        public static bool RegistrarCategoria(string tipo)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_RegistrarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pTipo", tipo);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool ModificarCategoria(string tipo, int idcateg)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pTipo", tipo);
            consulta.Parameters.AddWithValue("@pIdCategoria", idcateg);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarCategoria(int idcateg)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdCategoria", idcateg);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        ////////////////////ABM///USUARIOS///////////////////////////////////////

        public static bool RegistarUsuario(Usuarios x)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_RegistrarUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            consulta.Parameters.AddWithValue("@pMail", x.Mail);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }

        public static bool ModificarUsuario(int idusuario, string Nombre, string Mail, string contraseña)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificarUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdusuario", idusuario);
            consulta.Parameters.AddWithValue("@pNombre", Nombre);
            consulta.Parameters.AddWithValue("@pContraseña", contraseña);
            consulta.Parameters.AddWithValue("@pMail", Mail);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarUsuario(int idusuario)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdusuario", idusuario);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        ////////////////////ABM///PREGUNTAS//////////////////////////////////////
        public static bool RegistrarPregunta(string Descripcion)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;            
            consulta.Parameters.AddWithValue("@pDescripcion", Descripcion);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool ModificarPregunta(int idatri, string Descripcion)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdAtributo", idatri);
            consulta.Parameters.AddWithValue("@pDescripcion", Descripcion);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarPregunta(int idatri)
        {
            bool a = false;
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarPregunta";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIdAtributo", idatri);
            int regsAfectados = consulta.ExecuteNonQuery();
            Desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }

        public static string VerUsuarioMail(string Mail)
        {
            string retorno = "";
            //sp_VerUsuarioMail
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_VerUsuarioMail";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pMail", Mail);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                retorno = dataReader["Mail"].ToString();
            }
            Desconectar(conexion);
            return retorno;
        }
    }
}