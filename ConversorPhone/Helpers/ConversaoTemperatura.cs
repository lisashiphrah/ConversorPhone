using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MeasuresConverter.Enum;

namespace MeasuresConverter.Helpers
{
    /// <summary>
    /// Classe contendo métodos a respeito das conversões de temperatura
    /// </summary>
    public class ConversaoTemperatura
    {
        /// <summary>
        /// Recebe a temperatura origem e destino e retorna o resultado convertido
        /// </summary>
        /// <param name="de">Temperatura origem</param>  
        /// <param name="para">Temperatura destino</param>
        /// <param name="valor">Valor a ser convertido</param>
        /// <returns>Conversão efetuada</returns>
        public static double ConverteTemperatura(TemperaturaEnum de, TemperaturaEnum para, double valor)
        {
            var resultado = 0.0;
            var valorCelcius = ConversaoTemperatura.ConverteParaCelcius(de, valor);
            switch (para)
            {
                case TemperaturaEnum.Celsius:
                    return valorCelcius;
                case TemperaturaEnum.Fahrenheit:
                    resultado = valorCelcius * 1.8 + 32;
                    break;
                case TemperaturaEnum.Kelvin:
                    resultado = valorCelcius + 274.15;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Converte para celcius o valor solicitado
        /// </summary>
        /// <param name="de">O tipo de conversão a ser efetuada</param>
        /// <param name="valor">O valor para conversão</param>
        /// <returns>O valor convertido</returns>
        private static double ConverteParaCelcius(TemperaturaEnum de, double valor)
        {
            var resultado = 0.0;
            switch (de)
            {
                case TemperaturaEnum.Celsius:
                    resultado = valor;
                    break;
                case TemperaturaEnum.Fahrenheit:
                    resultado = (valor - 32) / 1.8;
                    break;
                case TemperaturaEnum.Kelvin:
                    resultado = valor - 273.15;
                    break;
            }
            return resultado;
        }
    }
}
