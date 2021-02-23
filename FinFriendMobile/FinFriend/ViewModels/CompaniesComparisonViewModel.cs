using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Models;
using OxyPlot;
using OxyPlot.Axes;
using Xamarin.Forms;
using System.Linq;
using OxyPlot.Series;

namespace FinFriend.ViewModels
{
    public class CompaniesComparisonViewModel : BaseViewModel
    {
        private IStocksApiService _stocksService => DependencyService.Get<IStocksApiService>();

        private List<string> companiesSymbols;

        public IEnumerable<StockHistoricalData> _firstCompanyHistoricalData;
        public IEnumerable<StockHistoricalData> _secondCompanykHistoricalData;

        private PlotModel _historicalPricesModel;
        public PlotModel HistoricalPricesModel
        {
            get => _historicalPricesModel;
            set => SetProperty(ref _historicalPricesModel, value);
        }

        public CompaniesComparisonViewModel()
        {
            companiesSymbols = new List<string> { "TSLA", "AAPL" };
            FireAndForgetSafeAsync(LoadHistoricalData());
        }

        private async Task LoadHistoricalData()
        {
            _firstCompanyHistoricalData = await _stocksService.GetStockHistoricalData(companiesSymbols[0]);
            _secondCompanykHistoricalData = await _stocksService.GetStockHistoricalData(companiesSymbols[1]);

            InitializeHistoricalPricesModel();
        }

        private void InitializeHistoricalPricesModel()
        {
            var historicalPricesModel = new PlotModel()
            {
                Title = "Randamentele zilnice",
                PlotType = PlotType.XY,
            };

            historicalPricesModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = _firstCompanyHistoricalData.Min(data => data.CumulativeReturn),
                Maximum = _firstCompanyHistoricalData.Max(data => data.CumulativeReturn),
                TickStyle = TickStyle.Inside,
            });

            historicalPricesModel.Axes.Add(new DateTimeAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = _firstCompanyHistoricalData.Min(data => DateTimeAxis.ToDouble(data.Date)),
                Maximum = _firstCompanyHistoricalData.Max(data => DateTimeAxis.ToDouble(data.Date)),
                TickStyle = TickStyle.Inside,
            });

            historicalPricesModel.Series.Add(CreateLineSeries());
            HistoricalPricesModel = historicalPricesModel;
        }

        private LineSeries CreateLineSeries()
        {
            var ls = new LineSeries();

            foreach (var data in _firstCompanyHistoricalData)
            {
                ls.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.Date), data.CumulativeReturn));
            }

            return ls;
        }
    }

}
