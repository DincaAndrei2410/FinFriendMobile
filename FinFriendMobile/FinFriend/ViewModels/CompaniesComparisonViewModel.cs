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
using Models.Models;

namespace FinFriend.ViewModels
{
    public class CompaniesComparisonViewModel : BaseViewModel
    {
        private IStocksApiService _stocksService => DependencyService.Get<IStocksApiService>();

        private List<string> _companiesSymbols;

        public IEnumerable<StockHistoricalData> _firstCompanyHistoricalData;
        public IEnumerable<StockHistoricalData> _secondCompanykHistoricalData;

        private PlotModel _historicalPricesModel;
        public PlotModel HistoricalPricesModel
        {
            get => _historicalPricesModel;
            set
            {
                SetProperty(ref _historicalPricesModel, value);
                HistoricalPricesModel.InvalidatePlot(false);
            }
        }

        public CompaniesComparisonViewModel(IEnumerable<Company> companies)
        {
            _companiesSymbols = new List<string>();

            foreach (var company in companies)
            {
                _companiesSymbols.Add(company.CompanySymbol);
            }

            FireAndForgetSafeAsync(LoadHistoricalData());
        }

        private async Task LoadHistoricalData()
        {
            _firstCompanyHistoricalData = await _stocksService.GetStockHistoricalData(_companiesSymbols[0]);
            _secondCompanykHistoricalData = await _stocksService.GetStockHistoricalData(_companiesSymbols[1]);

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
                Minimum = 0,
                Maximum = _firstCompanyHistoricalData.Max(data => data.CumulativeReturn),
                TickStyle = TickStyle.Inside,
                IsPanEnabled = false,
            });

            historicalPricesModel.Axes.Add(new DateTimeAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = _firstCompanyHistoricalData.Min(data => DateTimeAxis.ToDouble(data.Date)),
                Maximum = _firstCompanyHistoricalData.Max(data => DateTimeAxis.ToDouble(data.Date)) + 1,
                TickStyle = TickStyle.Inside,
                IsPanEnabled = false,
            });

            historicalPricesModel.Series.Add(CreateLineSeries(_firstCompanyHistoricalData));
            historicalPricesModel.Series.Add(CreateLineSeries(_secondCompanykHistoricalData));

            HistoricalPricesModel = historicalPricesModel;

            //var model = new PlotModel { Title = "DateTimeAxis", PlotMargins = new OxyThickness(40, double.NaN, 40, double.NaN) };
            //model.Axes.Add(new DateTimeAxis
            //{
            //    Position = AxisPosition.Bottom,
            //    Minimum = DateTimeAxis.ToDouble(new DateTime(2015, 1, 1)),
            //    Maximum = DateTimeAxis.ToDouble(new DateTime(2016, 1, 1)),
            //    Title = "DateTimeAxis"
            //});
            //model.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
            //HistoricalPricesModel = model;
        }

        private LineSeries CreateLineSeries(IEnumerable<StockHistoricalData> stockHistoricalDatas)
        {
            var ls = new LineSeries();

            foreach (var data in stockHistoricalDatas)
            {
                ls.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.Date), data.CumulativeReturn));
            }

            return ls;
        }

        private double GetMinimumValue()
        {
            var firstMin = _firstCompanyHistoricalData.Min(data => data.CumulativeReturn);
            var secondMin = _secondCompanykHistoricalData.Min(data => data.CumulativeReturn);
            return Math.Min(firstMin, secondMin);
        }

        private double GetMaximumValue()
        {
            var firstMax = _firstCompanyHistoricalData.Max(data => data.CumulativeReturn);
            var secondMax = _secondCompanykHistoricalData.Max(data => data.CumulativeReturn);
            return Math.Min(firstMax, secondMax);
        }
    }

}
