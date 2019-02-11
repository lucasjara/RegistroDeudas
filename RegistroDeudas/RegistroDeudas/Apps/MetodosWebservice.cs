using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace RegistroDeudas.Apps
{
    class MetodosWebservice
    {
        /*
         * Metodo para Validar el Acceso al Sistema.
         */
        public string RegistroDeudas(string descripcion, string monto, string usuario, string categoria, string tipo_movimiento)
        {
            string respuestaString = "";
            try
            {
                WebClient cliente = new WebClient();
                Uri uri = new Uri("http://www.infest.cl/servicios_registro/api/varios/registro_deudas/");
                NameValueCollection parametros = new NameValueCollection
                    {
                        { "descripcion", descripcion },
                        { "monto", monto },
                        { "usuario", usuario },
                        { "categoria", categoria },
                        { "tipo_movimiento", tipo_movimiento }
                    };
                byte[] respuestaByte = cliente.UploadValues(uri, "POST", parametros);
                respuestaString = Encoding.UTF8.GetString(respuestaByte);
            }
            catch (Exception)
            {
                respuestaString = "[\"N\",\"Error al Enviar la petición.\"]";
            }
            return respuestaString;
        }
    }
}
