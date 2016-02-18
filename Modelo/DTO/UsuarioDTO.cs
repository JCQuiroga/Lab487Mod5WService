using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.SessionState;

namespace Lab487Mod5WService.Modelo.DTO
{
    [DataContract]
    public class UsuarioDTO
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string login { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellidos { get; set; }
        [DataMember]
        public string foto { get; set; }

        public Usuario ToUsuario()
        {
            var user = new Usuario()
            {
                id = id,
                login = login,
                password = password,
                nombre = nombre,
                apellidos = apellidos,
                foto = foto
            };
            return user;
        }

        public static UsuarioDTO FromUsuario(Usuario usuario)
        {
            var us = new UsuarioDTO();
            us.id = usuario.id;
            us.login = usuario.login;
            us.password = usuario.password;
            us.nombre = usuario.nombre;
            us.apellidos = usuario.apellidos;
            us.foto = usuario.foto;

            return us;
        }

        public static List<UsuarioDTO> FromListUsuario(List<Usuario> lista)
        {
            var l = new List<UsuarioDTO>();
            foreach (var item in lista)
            {
                l.Add(UsuarioDTO.FromUsuario(item));
            }
            return l;
        }

    }
}