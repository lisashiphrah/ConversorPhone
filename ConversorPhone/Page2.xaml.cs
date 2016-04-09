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
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using MeasuresConverter.Helpers;

namespace ConversorPhone
{
    public partial class Page2 : PhoneApplicationPage
    {
        string[] listaCombo;

        /// <summary>
        /// Construtuor padrão
        /// </summary>
        public Page2()
        {
            InitializeComponent();
            RenderizaComponentes();
        }

        /// <summary>
        /// Renderiza a página com o tipo de conversão solicitado
        /// </summary>
        private void RenderizaComponentes()
        {
            var thisApp = App.Current as App;
            var conversao = (ConversoesEnum)Enum.Parse(typeof(ConversoesEnum), thisApp.TypeConvertion, true);
            switch (conversao)
            {
                case ConversoesEnum.BASES:
                    this.listaCombo = ConversaoBases.LoadBases();
                    break;
                case ConversoesEnum.MEDIDAS:
                    this.listaCombo = ConversaoMedidas.LoadMedidas();
                    break;
                case ConversoesEnum.TEMPERATURA:
                    this.listaCombo = ConversaoTemperatura.LoadTemperatura();
                    this.PageTitle.Text = "temperature";
                    break;
                case ConversoesEnum.TEMPO:
                    this.listaCombo = ConversaoTempo.LoadTempo();
                    this.PageTitle.Text = "time";
                    break;
                case ConversoesEnum.MASSA:
                    this.listaCombo = ConversaoMassa.LoadMassa();
                    this.PageTitle.Text = "weight";
                    break;
                case ConversoesEnum.VELOCIDADE:
                    this.listaCombo = ConversaoVelocidade.LoadVelocidade();
                    this.PageTitle.Text = "speed";
                    break;
            }
            this.comboBoxDe.ItemsSource = listaCombo;
            this.comboBoxPara.ItemsSource = listaCombo;
            this.comboBoxDe.SelectedIndex = 0;
            this.comboBoxPara.SelectedIndex = 0;
        }

        
        private void Converter_Click(object sender, RoutedEventArgs e)
        {
            textBlockErro.Visibility = Visibility.Collapsed;
            int de = comboBoxDe.SelectedIndex;
            int para = comboBoxPara.SelectedIndex;

            try
            {
                switch (MainPage.conversao)
                {
                    //Conversão de Bases
                    #region Bases
                    case (ConversoesEnum.BASES):
                        ConversaoBases.Converte(de, para, textBoxQuantidade.Text);
                        break;
                    #endregion

                    //Conversão de Medidas
                    #region Medidas
                    case (ConversoesEnum.MEDIDAS):

                        

                        break;
                    #endregion

                    //Conversão de Tempo
                    #region Tempo
                    case (ConversoesEnum.TEMPO):

                        try
                        {
                            double valorEntrada = Double.Parse(textBoxQuantidade.Text);
                            double resultado = 0.0;
                            switch (de)
                            {
                                //Anos
                                case (1):
                                    resultado = caculaDias(para, valorEntrada * 365);
                                    break;

                                //Dias
                                case (2):
                                    resultado = caculaDias(para, valorEntrada);
                                    break;

                                //Horas
                                case (3):
                                    resultado = caculaDias(para, valorEntrada / 24);
                                    break;

                                //Mês
                                case (4):
                                    resultado = caculaDias(para, valorEntrada * 30);
                                    break;

                                //Minutos
                                case (5):
                                    resultado = caculaDias(para, ((valorEntrada / 24) / 60));
                                    break;

                                //Segundos
                                case (6):
                                    resultado = caculaDias(para, (valorEntrada / 86400));
                                    break;

                                //Semanas
                                case (7):
                                    resultado = caculaDias(para, valorEntrada / 7);
                                    break;
                            }

                            textBoxResultado.Text = resultado.ToString();
                        }
                        catch (Exception ex)
                        {
                            textBlockErro.Visibility = Visibility.Visible;
                            return;
                        }
                        break;
                    #endregion

                }
            }
            catch (Exception)
            {
                textBlockErro.Visibility = Visibility.Visible;
            }
        }

       
        private double caculaDias(int para, double dias)
        {
            double resultado = 0.0;

            switch (para)
            {
                //Anos
                case (1):
                    resultado = dias / 365;
                    break;

                //Dias
                case (2):
                    resultado = dias;
                    break;

                //Horas
                case (3):
                    resultado = dias * 24;
                    break;

                //Mês
                case (4):
                    resultado = dias / 30;
                    break;

                //Minutos
                case (5):
                    resultado = (dias * 24) * 60;
                    break;

                //Segundos
                case (6):
                    resultado = (dias * 24) * 3600;
                    break;

                //Semanas
                case (7):
                    resultado = dias / 7;
                    break;
            }
            return resultado;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            App thisApp = App.Current as App;

            if ((thisApp.ConvertFrom != null) && (thisApp.ConvertFrom != ""))
                comboBoxDe.SelectedItem = thisApp.ConvertFrom;

            if ((thisApp.ConvertTo != null) && (thisApp.ConvertTo != ""))
                comboBoxPara.SelectedItem = thisApp.ConvertTo;

            textBoxResultado.Text = thisApp.OutputValue;
            textBoxQuantidade.Text = thisApp.InputValue;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
          
            App thisApp = App.Current as App;

            thisApp.ConvertFrom = comboBoxDe.SelectedItem.ToString();
            thisApp.ConvertTo = comboBoxPara.SelectedItem.ToString();
            thisApp.OutputValue = textBoxResultado.Text;
            thisApp.InputValue = textBoxQuantidade.Text;
        }
    }
}