#region

using System;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using ComputerGraphics.Windows;

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

        public BaseModel GetModel => DataContext as BaseModel;

        private void Oscillogram_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is not BaseModel model) throw new ArgumentException("Model is null");

            WindowController.AddOscillogram(model.Id);
        }

        public void Dispose() => GetModel?.Values.Dispose();

        private void SF_OnClick(object sender, RoutedEventArgs e)
        {
            var begin = Convert.ToInt32(WindowController.ChartModels.From);
            var end = Convert.ToInt32(WindowController.ChartModels.To);

            var model = GetModel;
            var degree = Math.Ceiling(Math.Log(end - begin, 2));


            var len = Convert.ToInt32(Math.Pow(2, degree));

            var values = new Complex[len];
            for (var i = 0; i < len && i + begin < end; i++) values[i] = model.Values[i + begin];

            var ft = FFT.FFT.fft(values);

            //SamplesCount = ft.Length / 2;

            len = ft.Length / 2;
            var asd = new double[len];
            for (var i = 0; i < len; i++) asd[i] = WindowController.ChartModels.DeltaTime * Complex.Abs(ft[i]);

            var oscillogramModel = new OscillogramModel("asd", "Моделирование", asd);

            var psd = new double[len];
            for (var i = 0; i < len; i++) psd[i] = Math.Pow(asd[i], 2);

            var oscillogramModel2 = new OscillogramModel("psd", "Моделирование", psd);

            var models = new ChartModels(len, WindowController.ChartModels.SamplingRate);
            models.Add(oscillogramModel);
            models.Add(oscillogramModel2);

            WindowController.FFTShow(models);
        }
    }
}