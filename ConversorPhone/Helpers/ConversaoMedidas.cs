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
    /// Classe contendo métodos a respeito das conversões de medidas
    /// </summary>
    public class ConversaoMedidas
    {
        /// <summary>
        /// Recebe a medida origem e destino e retorna o resultado convertido
        /// </summary>
        /// <param name="de">Medida origem</param>
        /// <param name="para">Medida destino</param>
        /// <param name="valor">Valor a ser convertido</param>
        /// <returns>Conversão efetuada</returns>
        public static double ConverteMedidas(MedidasEnum de, MedidasEnum para, double valor)
        {
            var metros = ConversaoMedidas.ConverteParaMetros(de, valor);

            switch (para)
            {
                case MedidasEnum.Centimetros:
                    return metros * 100;
                case MedidasEnum.Decimetros:
                    return metros * 10;
                case MedidasEnum.Jardas:
                    return metros / 0.9144;
                case MedidasEnum.Kilometros:
                    return metros / 1000;
                case MedidasEnum.Leguas:
                    return metros / 6172.4;
                case MedidasEnum.Metros:
                    return metros;
                case MedidasEnum.Milhas:
                    return metros / 1603.3;
                case MedidasEnum.Milimetros:
                    return metros * 1000;
                case MedidasEnum.Pes:
                    return metros / 0.3048;
                case MedidasEnum.Polegadas:
                    return (metros * 100) / 2.54;
                default:
                    return 0.0;
            }
        }

        /// <summary>
        /// Converte para metros o valor solicitado
        /// </summary>
        /// <param name="de">O tipo de conversão a ser efetuada</param>
        /// <param name="valor">O valor para conversão</param>
        /// <returns>O valor convertido</returns>
        private static double ConverteParaMetros(MedidasEnum de, double valor)
        {
            switch (de)
            {
                case MedidasEnum.Centimetros:
                    return valor / 100;
                case MedidasEnum.Decimetros:
                    return valor / 10;
                case MedidasEnum.Jardas:
                    return valor * 0.9144;
                case MedidasEnum.Kilometros:
                    return valor * 1000;
                case MedidasEnum.Leguas:
                    return valor * 6172.4;
                case MedidasEnum.Metros:
                    return valor;
                case MedidasEnum.Milhas:
                    return valor * 1603.3;
                case MedidasEnum.Milimetros:
                    return valor / 1000;
                case MedidasEnum.Pes:
                    return valor * 0.3048;
                case MedidasEnum.Polegadas:
                    var centimentros = valor * 2.54;
                    return centimentros / 100;
                default:
                    return 0.0;
            }
        }
    }

}
