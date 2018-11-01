using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TpGrupal.Models
{
    public class Usuarios
    {
        private int _IdUsuario;
        private string _Mail;
        private string _Nombre;
        private string _Contraseña;
        private string _Tipo;
        private int _Bitcoins;

        public int IdUsuario
        {
            get
            {
                return _IdUsuario;
            }

            set
            {
                _IdUsuario = value;
            }
        }
        [Required(ErrorMessage ="Complete el campo Mail")]
        public string Mail
        {
            get
            {
                return _Mail;
            }

            set
            {
                _Mail = value;
            }
        }
        [Required(ErrorMessage = "Complete el campo Nombre")]
        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }
        [Required(ErrorMessage = "Complete el campo Contraseña")]
        [StringLength(15, ErrorMessage = "Más de 6 letras y menos de 15 ", MinimumLength = 6)]
        public string Contraseña
        {
            get
            {
                return _Contraseña;
            }

            set
            {
                _Contraseña = value;
            }
        }
        public string Tipo
        {
            get
            {
                return _Tipo;
            }

            set
            {
                _Tipo = value;
            }
        }
        public int Bitcoins
        {
            get
            {
                return _Bitcoins;
            }

            set
            {
                _Bitcoins = value;
            }
        }
        public Usuarios(int _IdUsuario, string _Mail, string _Nombre, string _Contraseña, string _Tipo, int _Bitcoins)
        {
            this._IdUsuario = _IdUsuario;
            this._Mail = _Mail;
            this._Nombre = _Nombre;
            this._Contraseña = _Contraseña;
            this._Tipo = _Tipo;
            this._Bitcoins = _Bitcoins;
        }
        public Usuarios()
        {

        }
    }
}