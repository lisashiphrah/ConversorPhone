using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
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
    /// Classe contendo métodos a respeito das conversões de bases
    /// </summary>
    public class ConversaoBases
    {
        #region Propriedades
  
        public static int De { get; set; }

        public static int Para { get; set; }

        public static string Valor { get; set; }

        #endregion


        /// <summary>
        /// Determina qual o tipo de conversão a ser efetuada e chama o método principal
        /// </summary>
        /// <param name="de">Base a ser convertida</param>
        /// <param name="para">Base destino</param>
        /// <param name="valor">Valor a ser convertido</param>
        /// <returns>Resultado da conversão</returns>
        public static string Converte(int de, int para, string valor)
        {
            ConversaoBases.Valor = valor;

            switch (de)
            {
                case (1): //decimal
                    ConversaoBases.De = 10;
                    break;
                case (2): //binário
                    ConversaoBases.De = 2;
                    break;
                case (3): //octal
                    ConversaoBases.De = 8;
                    break;
                case (0): //hexa
                    ConversaoBases.De = 16;
                    break;
            }
            switch (para)
            {
                case (1): //decimal
                    ConversaoBases.Para = 10;
                    break;
                case (2): //binário
                    ConversaoBases.Para = 2;
                    break;
                case (3): //octal
                    ConversaoBases.Para = 8;
                    break;
                case (0): //hexa
                    ConversaoBases.Para = 16;
                    break;
            }
            try
            {
                var result = ConversaoBases.EfetuaConversao();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Efetua a conversão solicitada
        /// </summary>
        /// <returns>Resultado da conversão</returns>
        private static string EfetuaConversao()
        {
            string caracteres = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ", numDigitado, resFinal, numAux, baseValida;
            int qtdCaracteres, numAux2, restoMod, resParcial;

            baseValida = "1";
            resParcial = 0;
            resFinal = null;

            qtdCaracteres = ConversaoBases.Valor.Trim().Length;
            numDigitado = ConversaoBases.Valor.ToUpper();

            for (int a = 0; a < qtdCaracteres; a++)
            {
                if (baseValida == "1")
                {
                    for (int x = ConversaoBases.De; x < caracteres.Length; x++)
                    {

                        if (!numDigitado.Contains(caracteres[x]))
                        {
                            baseValida = "1";
                        }
                        else
                        {
                            baseValida = caracteres[x].ToString();
                            break;
                        }
                    }
                }
            }

            if (baseValida == "1")
            {

                for (int i = 1; i <= qtdCaracteres; i++)
                {
                    numAux = numDigitado[qtdCaracteres - i].ToString();
                    numAux2 = caracteres.IndexOf(numAux);
                    resParcial = resParcial + numAux2 * int.Parse(Math.Pow((double)ConversaoBases.De, double.Parse((i - 1).ToString())).ToString());
                }

                while (resParcial >= (double)ConversaoBases.Para)
                {
                    restoMod = resParcial % ConversaoBases.Para;
                    resParcial = resParcial / ConversaoBases.Para;
                    resFinal = caracteres.Substring(restoMod, 1) + resFinal;
                }
                resFinal = caracteres[int.Parse(resParcial.ToString())].ToString() + resFinal;
                return resFinal;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
