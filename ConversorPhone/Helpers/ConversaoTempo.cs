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
    /// Classe contendo métodos a respeito das conversões de tempo
    /// </summary>
    public class ConversaoTempo  
    {
        /// <summary>
        /// Recebe a medida origem e destino e retorna o resultado convertido
        /// </summary>
        /// <param name="de">Medida origem</param>
        /// <param name="para">Medida destino</param>
        /// <param name="valor">Valor a ser convertido</param>
        /// <returns>Conversão efetuada</returns>
        public static double ConverteTempo(TempoEnum de, TempoEnum para, double valor)
        {
            switch (de)
            {
                case TempoEnum.Anos:
                    return ConversaoTempo.CalculaDias(para, valor * 365);

                case TempoEnum.Dias:
                    return ConversaoTempo.CalculaDias(para, valor);

                case TempoEnum.Horas:
                    return ConversaoTempo.CalculaDias(para, valor / 24);

                case TempoEnum.Meses:
                    return ConversaoTempo.CalculaDias(para, valor * 30);

                case TempoEnum.Minutos:
                    return ConversaoTempo.CalculaDias(para, ((valor / 24) / 60));

                case TempoEnum.Segundos:
                    return ConversaoTempo.CalculaDias(para, (valor / 86400));

                case TempoEnum.Semanas:
                    return ConversaoTempo.CalculaDias(para, valor / 7);

                default:
                    return 0.0;
            }
        }

        /// <summary>
        /// Converte o valor de dias recebido no valor solicitado para conversão
        /// </summary>
        /// <param name="para">Conversão destinada</param>
        /// <param name="dias"></param>
        /// <returns></returns>
        private static double CalculaDias(TempoEnum para, double dias)
        {
            switch (para)
            {
                case TempoEnum.Anos:
                    return dias / 365;

                case TempoEnum.Dias:
                    return dias;

                case TempoEnum.Horas:
                    return dias * 24;

                case TempoEnum.Meses:
                    return dias / 30;

                case TempoEnum.Minutos:
                    return (dias * 24) * 60;

                case TempoEnum.Segundos:
                    return (dias * 24) * 3600;

                case TempoEnum.Semanas:
                    return dias / 7;

                default:
                    return 0.0;
            }

        }

    }
}
