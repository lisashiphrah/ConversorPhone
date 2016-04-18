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
  
namespace MeasuresConverter.Helpers
{
    /// <summary>
    /// Classe contendo métodos a respeito das conversões de massas
    /// </summary>
    public class ConversaoMassa
    {
        /// <summary>
        /// Retorna uma lista com os tipos de conversões de massas disponíveis
        /// </summary>
        /// <returns>Lista com os tipos de conversões de massas</returns>
        public static string[] LoadMassa()
        {
            string[] strArray =
            {
               "Select..."
            };
            return strArray;
        }
    }
}
