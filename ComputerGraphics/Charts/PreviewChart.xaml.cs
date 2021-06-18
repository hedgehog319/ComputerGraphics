#region

using System;
using System.Windows;
using System.Windows.Controls;
using ComputerGraphics.Windows;
using System.Numerics;
using FFT;

#endregion

namespace ComputerGraphics.Charts
{
    public partial class PreviewChart : UserControl
    {
        public PreviewChart(BaseModel model)
        {
            InitializeComponent();
            DataContext = model;
        }

        private void Oscillogram_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not BaseModel model) throw new ArgumentException("Model is null");

            WindowController.AddOscillogram(model.Id);
        }
        
        public BaseModel GetModel => DataContext as BaseModel;

        public void Dispose() => GetModel?.Values.Dispose();

        private void SF_OnClick(object sender, RoutedEventArgs e)
        {
            var begin = Convert.ToInt32(WindowController.ChartModels.From);
            var end = Convert.ToInt32(WindowController.ChartModels.To);
            if (end > WindowController.ChartModels.SamplesNumber/2)
            {
                end = WindowController.ChartModels.SamplesNumber / 2;
            }
            var modele = GetModel;
            var degree = Math.Floor(Math.Log(end - begin,2));
            

            var len = Convert.ToInt32(Math.Pow(2, degree));
            
            var values = new Complex[len];
            for (int i = 0; i < len; i++)
            {
                values[i] = modele.Values[i + begin];
            }

            var ft = FFT.FFT.fft(values);
           
            //SamplesCount = ft.Length / 2;

            var asd = new double[ft.Length];
            for (int i = 0; i < ft.Length; i++)
            {
                asd[i] = WindowController.ChartModels.DeltaTime * Complex.Abs(ft[i]);
            }
            
            var oscillogramModel = new OscillogramModel("asd", "Моделирование", asd);
            WindowController.AddSimulation(oscillogramModel);
            
            var psd = new double[ft.Length];
            for (int i = 0; i < ft.Length; i++)
            {
                psd[i] = Math.Pow(asd[i], 2);
            }
            
            var oscillogramModel2 = new OscillogramModel("psd", "Моделирование", psd);
            WindowController.AddSimulation(oscillogramModel2);
           
        }

        
    }
}