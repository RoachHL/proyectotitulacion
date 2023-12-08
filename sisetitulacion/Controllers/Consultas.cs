using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sisetitulacion.Models;

namespace sisetitulacion.Controllers
{
    public class Consultas
    {
        public string ExtraerDatosString(string cadena, int posicion, string nombreInicio, string nombreFin, StringComparison reglaComparacion = StringComparison.Ordinal)
        {
            string Resultado = "";
            try
            {
                int posicionInicio = cadena.IndexOf(nombreInicio, posicion, reglaComparacion);
                if (posicionInicio > -1)
                {
                    posicionInicio += nombreInicio.Length;
                    if (nombreFin == null || nombreFin == "")
                    {
                        Resultado = cadena.Substring(posicionInicio, cadena.Length - posicionInicio);
                    }
                    else
                    {
                        int posicionFin = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion);
                        if (posicionFin > -1)
                        {
                            Resultado = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message + " en ExtraerDatosString");
            }
            return Resultado;
        }

        public string[] ExtraerDatosTag(string cadena, int posicion, string nombreInicio, string nombreFin, StringComparison reglaComparacion = StringComparison.Ordinal)
        {
            string[] Resultado = null;
            try
            {
                int posicionInicio = cadena.IndexOf(nombreInicio, posicion, reglaComparacion);
                if (posicionInicio > -1)
                {
                    posicionInicio += nombreInicio.Length;
                    if (nombreFin == null || nombreFin == "")
                    {
                        Resultado = new string[2];
                        Resultado[0] = cadena.Length.ToString();
                        Resultado[1] = cadena.Substring(posicionInicio, cadena.Length - posicionInicio);
                    }
                    else
                    {
                        int posicionFin = cadena.IndexOf(nombreFin, posicionInicio, reglaComparacion);
                        if (posicionFin > -1)
                        {
                            posicion = posicionFin + nombreFin.Length;
                            Resultado = new string[2];
                            Resultado[0] = posicion.ToString();
                            Resultado[1] = cadena.Substring(posicionInicio, posicionFin - posicionInicio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error en: " + ex.Message + " string cadena, int posicion, string nombreInicio, string nombreFin, StringComparison reglaComparacion = StringComparison.Ordinal");
            }
            return Resultado;
        }

    }
}