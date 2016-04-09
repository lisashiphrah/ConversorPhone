using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MeasuresConverter.Enum;
using MeasuresConverter.Helpers;

namespace MeasuresConverter
{
    public partial class BasesPage : PhoneApplicationPage
    {
        public BasesPage()
        {
            InitializeComponent();
            this.borderResultado.Visibility = Visibility.Collapsed;
            this.borderErro.Visibility = Visibility.Collapsed;
        }

        private void Converter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var valor = this.textBoxQuantidade.Text;
                var de = (BasesEnum)System.Enum.Parse(typeof(BasesEnum), this.comboBoxDe.SelectionBoxItem.ToString(), true);
                var para = (BasesEnum)System.Enum.Parse(typeof(BasesEnum), this.comboBoxPara.SelectionBoxItem.ToString(), true);

                var resultado = ConversaoBases.Converte((int)de, (int)para, valor);
                this.textBoxResultado.Text = resultado.ToString();

                this.borderResultado.Visibility = Visibility.Visible;
                this.borderErro.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                this.borderResultado.Visibility = Visibility.Collapsed;
                this.borderErro.Visibility = Visibility.Visible;
            }
        }
    }
}