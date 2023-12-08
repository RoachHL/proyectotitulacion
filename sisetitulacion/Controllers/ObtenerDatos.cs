using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sisetitulacion.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace sisetitulacion.Controllers
{
    public class ObtenerDatos
    {
        public async Task<string> ObtenerNombre(string dninumero)
        {
            string Snombre = "";
            //

            string mensajeRespuesta = "";
            string nombre = ""; string apellidopat = ""; string apellidomat = "";
            string numdni = dninumero;

            Consultas Obj_consultas = new Consultas();
           

            CookieContainer cokies = new CookieContainer();
            HttpClientHandler controlmensaje = new HttpClientHandler();
            controlmensaje.UseCookies = true;
            using (HttpClient cliente = new HttpClient(controlmensaje))
            {
                cliente.DefaultRequestHeaders.Add("Host", "eldni.com");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"90\", \"Google Chrome\";v=\"90\"");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                cliente.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                cliente.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                string url = "https://eldni.com/pe/buscar-por-dni";

                using (HttpResponseMessage ResultadoToken = await cliente.GetAsync(new Uri(url)))
                {
                    if (ResultadoToken.IsSuccessStatusCode)
                    {
                        mensajeRespuesta = await ResultadoToken.Content.ReadAsStringAsync();
                        string Token = Obj_consultas.ExtraerDatosString(mensajeRespuesta, 0, "name=\"_token\" value=\"", "\">");

                        cliente.DefaultRequestHeaders.Remove("Sec-Fetch-Site");

                        cliente.DefaultRequestHeaders.Add("Origin", "https://eldni.com");
                        cliente.DefaultRequestHeaders.Add("Referer", "https://eldni.com/pe/buscar-por-dni");
                        cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");

                        EDNI OBJ_dni = new EDNI();

                        OBJ_dni._token = Token;
                        OBJ_dni.dni = numdni;

                        using (HttpResponseMessage ConsultaDato = await cliente.PostAsJsonAsync(url, OBJ_dni))
                        {
                            if (ConsultaDato.IsSuccessStatusCode)
                            {
                                string contenidoHTML = await ConsultaDato.Content.ReadAsStringAsync();
                                string nombreInicio = "<table class=\"table table-striped table-scroll\">";
                                string nombreFin = "</table>";
                                string ContenidoDni = Obj_consultas.ExtraerDatosString(contenidoHTML, 0, nombreInicio, nombreFin);

                                if (ContenidoDni == "")
                                {
                                    nombreInicio = "<h3 class=\"text-error\">";
                                    nombreFin = "</h3>";
                                    mensajeRespuesta = Obj_consultas.ExtraerDatosString(contenidoHTML, 0, nombreInicio, nombreFin);
                                    mensajeRespuesta = mensajeRespuesta == "" ? string.Format("No se pudo realizar la consulta del número de DNI {0}.", numdni) : string.Format("No se pudo realizar la consulta del número de DNI {0}.\r\nDetalle: {1}", numdni, mensajeRespuesta);
                                }
                                else
                                {
                                    nombreInicio = "<td>";
                                    nombreFin = "</td>";
                                    string[] Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, 0, nombreInicio, nombreFin);
                                    if (Respuesta != null)
                                    {
                                        Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, Convert.ToInt32(Respuesta[0]), nombreInicio, nombreFin);
                                        if (Respuesta != null)
                                        {
                                            //sale el nombre
                                            Snombre = Respuesta[1];


                                            Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, Convert.ToInt32(Respuesta[0]), nombreInicio, nombreFin);
                                            if (Respuesta != null)
                                            {
                                                //ontienes apellido paterno
                                                apellidopat = Respuesta[1];

                                                Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, Convert.ToInt32(Respuesta[0]), nombreInicio, nombreFin);
                                                if (Respuesta != null)
                                                {
                                                    apellidomat = Respuesta[1];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Snombre = "Error al obtener los datos del dni {0}";
                            }
                        }
                    }
                    else
                    {
                        Snombre = "Error al buscar el dni {0}";
                    }
                }
                
            }
            //
            return Snombre;

        }
        public async Task<string> Obtenerapellidopaterno(string dninumero)
        {
            string Sapellidopat = "";
            //

            string mensajeRespuesta = "";
            string nombre = ""; string apellidopat = ""; string apellidomat = "";
            string numdni = dninumero;

            Consultas Obj_consultas = new Consultas();
           

            CookieContainer cokies = new CookieContainer();
            HttpClientHandler controlmensaje = new HttpClientHandler();
            controlmensaje.UseCookies = true;
            using (HttpClient cliente = new HttpClient(controlmensaje))
            {
                cliente.DefaultRequestHeaders.Add("Host", "eldni.com");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"90\", \"Google Chrome\";v=\"90\"");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                cliente.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                cliente.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                string url = "https://eldni.com/pe/buscar-por-dni";

                using (HttpResponseMessage ResultadoToken = await cliente.GetAsync(new Uri(url)))
                {
                    if (ResultadoToken.IsSuccessStatusCode)
                    {
                        mensajeRespuesta = await ResultadoToken.Content.ReadAsStringAsync();
                        string Token = Obj_consultas.ExtraerDatosString(mensajeRespuesta, 0, "name=\"_token\" value=\"", "\">");

                        cliente.DefaultRequestHeaders.Remove("Sec-Fetch-Site");

                        cliente.DefaultRequestHeaders.Add("Origin", "https://eldni.com");
                        cliente.DefaultRequestHeaders.Add("Referer", "https://eldni.com/pe/buscar-por-dni");
                        cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");

                        EDNI OBJ_dni = new EDNI();

                        OBJ_dni._token = Token;
                        OBJ_dni.dni = numdni;

                        using (HttpResponseMessage ConsultaDato = await cliente.PostAsJsonAsync(url, OBJ_dni))
                        {
                            if (ConsultaDato.IsSuccessStatusCode)
                            {
                                string contenidoHTML = await ConsultaDato.Content.ReadAsStringAsync();
                                string nombreInicio = "<table class=\"table table-striped table-scroll\">";
                                string nombreFin = "</table>";
                                string ContenidoDni = Obj_consultas.ExtraerDatosString(contenidoHTML, 0, nombreInicio, nombreFin);

                                if (ContenidoDni == "")
                                {
                                    nombreInicio = "<h3 class=\"text-error\">";
                                    nombreFin = "</h3>";
                                    mensajeRespuesta = Obj_consultas.ExtraerDatosString(contenidoHTML, 0, nombreInicio, nombreFin);
                                    mensajeRespuesta = mensajeRespuesta == "" ? string.Format("No se pudo realizar la consulta del número de DNI {0}.", numdni) : string.Format("No se pudo realizar la consulta del número de DNI {0}.\r\nDetalle: {1}", numdni, mensajeRespuesta);
                                }
                                else
                                {
                                    nombreInicio = "<td>";
                                    nombreFin = "</td>";
                                    string[] Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, 0, nombreInicio, nombreFin);
                                    if (Respuesta != null)
                                    {
                                        Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, Convert.ToInt32(Respuesta[0]), nombreInicio, nombreFin);
                                        if (Respuesta != null)
                                        {
                                            //sale el nombre
                                            nombre = Respuesta[1];


                                            Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, Convert.ToInt32(Respuesta[0]), nombreInicio, nombreFin);
                                            if (Respuesta != null)
                                            {
                                                //ontienes apellido paterno
                                                Sapellidopat = Respuesta[1];

                                                Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, Convert.ToInt32(Respuesta[0]), nombreInicio, nombreFin);
                                                if (Respuesta != null)
                                                {
                                                    apellidomat = Respuesta[1];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Sapellidopat = "Error al obtener los datos del dni {0}";
                            }
                        }
                    }
                    else
                    {
                        Sapellidopat = "Error al buscar el dni {0}";
                    }
                }
                
            }
            //
            return Sapellidopat;

        }

        public async Task <string> Obtenerapellidomaterno(string dninumero)
        {
            string Sapellidomat = "";
            //

            string mensajeRespuesta = "";
            string nombre = ""; string apellidopat = ""; string apellidomat = "";
            string numdni = dninumero;

            Consultas Obj_consultas = new Consultas();
            

            CookieContainer cokies = new CookieContainer();
            HttpClientHandler controlmensaje = new HttpClientHandler();
            controlmensaje.UseCookies = true;
            using (HttpClient cliente = new HttpClient(controlmensaje))
            {
                cliente.DefaultRequestHeaders.Add("Host", "eldni.com");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"90\", \"Google Chrome\";v=\"90\"");
                cliente.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                cliente.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                cliente.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                cliente.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                string url = "https://eldni.com/pe/buscar-por-dni";

                using (HttpResponseMessage ResultadoToken = await cliente.GetAsync(new Uri(url)))
                {
                    if (ResultadoToken.IsSuccessStatusCode)
                    {
                        mensajeRespuesta = await ResultadoToken.Content.ReadAsStringAsync();
                        string Token = Obj_consultas.ExtraerDatosString(mensajeRespuesta, 0, "name=\"_token\" value=\"", "\">");

                        cliente.DefaultRequestHeaders.Remove("Sec-Fetch-Site");

                        cliente.DefaultRequestHeaders.Add("Origin", "https://eldni.com");
                        cliente.DefaultRequestHeaders.Add("Referer", "https://eldni.com/pe/buscar-por-dni");
                        cliente.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");

                        EDNI OBJ_dni = new EDNI();

                        OBJ_dni._token = Token;
                        OBJ_dni.dni = numdni;

                        using (HttpResponseMessage ConsultaDato = await cliente.PostAsJsonAsync(url, OBJ_dni))
                        {
                            if (ConsultaDato.IsSuccessStatusCode)
                            {
                                string contenidoHTML = await ConsultaDato.Content.ReadAsStringAsync();
                                string nombreInicio = "<table class=\"table table-striped table-scroll\">";
                                string nombreFin = "</table>";
                                string ContenidoDni = Obj_consultas.ExtraerDatosString(contenidoHTML, 0, nombreInicio, nombreFin);

                                if (ContenidoDni == "")
                                {
                                    nombreInicio = "<h3 class=\"text-error\">";
                                    nombreFin = "</h3>";
                                    mensajeRespuesta = Obj_consultas.ExtraerDatosString(contenidoHTML, 0, nombreInicio, nombreFin);
                                    mensajeRespuesta = mensajeRespuesta == "" ? string.Format("No se pudo realizar la consulta del número de DNI {0}.", numdni) : string.Format("No se pudo realizar la consulta del número de DNI {0}.\r\nDetalle: {1}", numdni, mensajeRespuesta);
                                }
                                else
                                {
                                    nombreInicio = "<td>";
                                    nombreFin = "</td>";
                                    string[] Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, 0, nombreInicio, nombreFin);
                                    if (Respuesta != null)
                                    {
                                        Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, Convert.ToInt32(Respuesta[0]), nombreInicio, nombreFin);
                                        if (Respuesta != null)
                                        {
                                            //sale el nombre
                                            nombre = Respuesta[1];


                                            Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, Convert.ToInt32(Respuesta[0]), nombreInicio, nombreFin);
                                            if (Respuesta != null)
                                            {
                                                //ontienes apellido paterno
                                                apellidopat = Respuesta[1];

                                                Respuesta = Obj_consultas.ExtraerDatosTag(ContenidoDni, Convert.ToInt32(Respuesta[0]), nombreInicio, nombreFin);
                                                if (Respuesta != null)
                                                {
                                                    Sapellidomat = Respuesta[1];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Sapellidomat = "Error al obtener los datos del dni {0}";
                            }
                        }
                    }
                    else
                    {
                        Sapellidomat = "Error al buscar el dni {0}";
                    }
                }
                
            }
            //
            return Sapellidomat;

        }
    }
}