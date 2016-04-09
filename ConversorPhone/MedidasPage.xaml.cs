﻿using System;
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
    public partial class MedidasPage : PhoneApplicationPage
    {
        public MedidasPage()
        {
            InitializeComponent();
            this.borderResultado.Visibility = Visibility.Collapsed;
            this.borderErro.Visibility = Visibility.Collapsed;
        }

        private void Converter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var valor = Convert.ToDouble(this.textBoxQuantidade.Text);
                var de = (MedidasEnum)System.Enum.Parse(typeof(MedidasEnum), this.comboBoxDe.SelectionBoxItem.ToString(), true);
                var para = (MedidasEnum)System.Enum.Parse(typeof(MedidasEnum), this.comboBoxPara.SelectionBoxItem.ToString(), true);

                var resultado = ConversaoMedidas.ConverteMedidas(de, para, valor);
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