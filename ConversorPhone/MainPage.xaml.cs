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
using System.Windows.Media.Imaging;
using Microsoft.Phone.Shell;

namespace ConversorPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        App thisApp = App.Current as App;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        #region Eventos

        /// <summary>
        /// Evento disparado no clique do botão de conversão de temperatura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConversaoTemperatura_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/TemperaturaPage.xaml?NavigatedFrom=Main Page", UriKind.Relative));
        }

        /// <summary>
        /// Evento disparado no clique do botão de conversão de medidas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConversaoMedidas_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MedidasPage.xaml?NavigatedFrom=Main Page", UriKind.Relative));
        }

        /// <summary>
        /// Evento disparado no clique do botão de conversão de bases
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConversaoBases_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/BasesPage.xaml?NavigatedFrom=Main Page", UriKind.Relative));
        }

        /// <summary>
        /// Evento disparado no clique do botão de conversão de tempo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConversaoTempo_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/TempoPage.xaml?NavigatedFrom=Main Page", UriKind.Relative));
        }

        /// <summary>
        /// Evento disparado no clique do botão de conversão de massa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConversaoMassa_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MassaPage.xaml?NavigatedFrom=Main Page", UriKind.Relative));
        }

        /// <summary>
        /// Evento disparado no clique do botão de conversão de velocidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConversaoVelocidade_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/VelocidadePage.xaml?NavigatedFrom=Main Page", UriKind.Relative));
        }

        #endregion
    }
}