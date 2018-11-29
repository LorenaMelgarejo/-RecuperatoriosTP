using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto // la clase esta declarada como abstract en el diagrama , public sealed class Producto
	{
        public enum EMarca // debe ser de visibilidad publica
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

		//Se agrego la visibilidad de los atributos

		private EMarca _marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias // solo retorna y la visibilidad es protected
        {
            get;
        }

		public Producto(string patente, EMarca marca, ConsoleColor color)// se agrego el constructor Producto con 3 parametros
		{
			this._marca = marca;
			this.colorPrimarioEmpaque = color;
            this.codigoDeBarras = patente;
		}

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()//public
        {
            return (string)this;
        }

        public static explicit operator string(Producto p) // publico
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("CODIGO DE BARRAS:{0}\r\n", p.codigoDeBarras));     
            sb.AppendLine(string.Format("MARCA          :{0}\r\n", p._marca.ToString()));    
            sb.AppendLine(string.Format("COLOR EMPAQUE  :{0}\r\n", p.colorPrimarioEmpaque.ToString()));
            sb.AppendLine("---------------------");

            return sb.ToString();// falto el ToString
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1.codigoDeBarras == v2.codigoDeBarras);
        }
    }
}
