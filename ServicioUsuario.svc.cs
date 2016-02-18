using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Lab487Mod5WService.Modelo;
using Lab487Mod5WService.Modelo.DTO;

namespace Lab487Mod5WService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioUsuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioUsuario.svc or ServicioUsuario.svc.cs at the Solution Explorer and start debugging.
    public class ServicioUsuario : IServicioUsuario
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public UsuarioDTO GetUsuario(int id)
        {
            using (var db = new RedContactosEntities())
            {
                var us = db.Usuario.Find(id);
                var usDTO = UsuarioDTO.FromUsuario(us);
                return usDTO;
            }
        }

        public List<UsuarioDTO> GetAllUsuario()
        {
            using (var db = new RedContactosEntities())
            {
                var usDTO = UsuarioDTO.FromListUsuario(db.Usuario.ToList());
                return usDTO;
            }
        }

        public void AddUsuario(UsuarioDTO usuario)
        {
            var us = usuario.ToUsuario();
            using (var db = new RedContactosEntities())
            {
                db.Usuario.Add(us);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
