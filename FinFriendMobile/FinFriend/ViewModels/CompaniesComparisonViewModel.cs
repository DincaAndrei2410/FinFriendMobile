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
        private IFinancialApiService _financialService => DependencyService.Get<IFinancialApiService>();
        private ISentimentApiService _sentimentService => DependencyService.Get<ISentimentApiService>();

        private List<string> _companiesSymbols;

        public IEnumerable<StockHistoricalData> _firstCompanyHistoricalData;
        public IEnumerable<StockHistoricalData> _secondCompanykHistoricalData;

        private PlotModel _dailyRatesModel;
        public PlotModel DailyRatesModel
        {
            get => _dailyRatesModel;
            set
            {
                SetProperty(ref _dailyRatesModel, value);
                DailyRatesModel.InvalidatePlot(false);
            }
        }

        private PlotModel _cumulativeRatesModel;
        public PlotModel CumulativeRatesModel
        {
            get => _cumulativeRatesModel;
            set
            {
                SetProperty(ref _cumulativeRatesModel, value);
                CumulativeRatesModel.InvalidatePlot(false);
            }
        }

        private PlotModel _perModel;
        public PlotModel PerModel
        {
            get => _perModel;
            set
            {
                SetProperty(ref _perModel, value);
                PerModel.InvalidatePlot(false);
            }
        }

        private PlotModel _firstCompanySentimentModel;
        public PlotModel FirstCompanySentimentModel
        {
            get => _firstCompanySentimentModel;
            set
            {
                SetProperty(ref _firstCompanySentimentModel, value);
                FirstCompanySentimentModel.InvalidatePlot(false);
            }
        }

        private PlotModel _secondCompanySentimentModel;
        public PlotModel SecondCompanySentimentModel
        {
            get => _secondCompanySentimentModel;
            set
            {
                SetProperty(ref _secondCompanySentimentModel, value);
                SecondCompanySentimentModel.InvalidatePlot(false);
            }
        }

        public CompaniesComparisonViewModel(IEnumerable<Company> companies)
        {
            IsBusy = true;
            _companiesSymbols = new List<string>();

            foreach (var company in companies)
            {
                _companiesSymbols.Add(company.CompanySymbol);
            }

            FireAndForgetSafeAsync(LoadData());
        }

        private async Task LoadData()
        {
            await Task.WhenAll(LoadHistoricalData(), LoadFinancialData(), LoadSentimentData(), Task.Delay(2000));
            IsBusy = false;
        }

        private async Task LoadHistoricalData()
        {
            _firstCompanyHistoricalData = await _stocksService.GetStockHistoricalData(_companiesSymbols[0]);
            _secondCompanykHistoricalData = await _stocksService.GetStockHistoricalData(_companiesSymbols[1]);

            InitializeDailyRatesModel();
            InitializeCumulativeRatesModel();
        }

        private async Task LoadFinancialData()
        {
            var _firstCompanyFinancialData = await _financialService.GetFinancialData(_companiesSymbols[0]);
            var _secondCompanyFinancialData = await _financialService.GetFinancialData(_companiesSymbols[1]);

            InitializePERModel(_firstCompanyFinancialData.SummaryDetail.PER, _secondCompanyFinancialData.SummaryDetail.PER);
        }

        private async Task LoadSentimentData()
        {
            var _firstCompanySentimentData = await _sentimentService.GetSentiment(_companiesSymbols[0]);
            var _secondCompanySentimentData = await _sentimentService.GetSentiment(_companiesSymbols[1]);

            FirstCompanySentimentModel = InitializeSentimentModel(_firstCompanySentimentData, _companiesSymbols[0]);
            SecondCompanySentimentModel = InitializeSentimentModel(_secondCompanySentimentData, _companiesSymbols[1]);
        }

        private PlotModel InitializeSentimentModel(SentimentData sentimentData, string title)
        {
            var sentimentModel = new PlotModel { Title = $"{title}", TitleFont = "MontserratBold", TitleFontSize = 16};

            var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.7, AngleSpan = 360, StartAngle = 0 };

            seriesP1.Slices.Add(new PieSlice(nameof(SentimentData.Positive), (double)sentimentData.Positive) { IsExploded = false });
            seriesP1.Slices.Add(new PieSlice(nameof(SentimentData.Neutral), (double)sentimentData.Neutral) { IsExploded = false });
            seriesP1.Slices.Add(new PieSlice(nameof(SentimentData.Negative), (double)sentimentData.Negative) { IsExploded = false });

            sentimentModel.Series.Add(seriesP1);

            return sentimentModel;
        }

        private void InitializePERModel(decimal firstCompanyPER, decimal secondCompanyPER)
        {
            var perModel = new PlotModel();

            var barSeries = new ColumnSeries()
            {
                ItemsSource = new List<ColumnItem>()
                {
                    new ColumnItem() { Value = (double)firstCompanyPER },
                    new ColumnItem() { Value = (double)secondCompanyPER },
                },
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:.00}",
                Font = "MontserratBold",
                FontSize = 16,
            };

            perModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                ItemsSource = new[]
                {
                    _companiesSymbols[0],
                    _companiesSymbols[1],
                },
                IsZoomEnabled = false,
                IsPanEnabled = false,
            });

            foreach (var axis in perModel.Axes)
            {
                axis.IsZoomEnabled = false;
                axis.IsPanEnabled = false;
            }
            
            perModel.Series.Add(barSeries);

            PerModel = perModel;
        }

        private void InitializeDailyRatesModel()
        {
            var historicalPricesModel = new PlotModel()
            {
                PlotType = PlotType.XY,
            };

            historicalPricesModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                //Minimum = GetMinimumValue(false),
                //Maximum = GetMaximumValue(false),
                TickStyle = TickStyle.Inside,
                IsPanEnabled = false,
                Title = "Indice"
            });

            historicalPricesModel.Axes.Add(new DateTimeAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = _firstCompanyHistoricalData.Min(data => DateTimeAxis.ToDouble(data.Date)),
                Maximum = _firstCompanyHistoricalData.Max(data => DateTimeAxis.ToDouble(data.Date)),
                TickStyle = TickStyle.Inside,
                IsPanEnabled = false,
                Title = "Orizont de timp",
            });

            historicalPricesModel.Series.Add(CreateLineSeries(_firstCompanyHistoricalData, false));
            historicalPricesModel.Series.Add(CreateLineSeries(_secondCompanykHistoricalData, false));

            DailyRatesModel = historicalPricesModel;
        }

        private void InitializeCumulativeRatesModel()
        {
            var historicalPricesModel = new PlotModel()
            {
                PlotType = PlotType.XY,
            };

            historicalPricesModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = 0.5,
                //Maximum = GetMaximumValue(true),
                TickStyle = TickStyle.Inside,
                IsPanEnabled = false,
                Title = "Indice",
            });

            historicalPricesModel.Axes.Add(new DateTimeAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = _firstCompanyHistoricalData.Min(data => DateTimeAxis.ToDouble(data.Date)),
                Maximum = _firstCompanyHistoricalData.Max(data => DateTimeAxis.ToDouble(data.Date)),
                TickStyle = TickStyle.Inside,
                IsPanEnabled = false,
                Title = "Orizont de timp",
            });

            historicalPricesModel.Series.Add(CreateLineSeries(_firstCompanyHistoricalData, true));
            historicalPricesModel.Series.Add(CreateLineSeries(_secondCompanykHistoricalData, true));

            CumulativeRatesModel = historicalPricesModel;

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

        private LineSeries CreateLineSeries(IEnumerable<StockHistoricalData> stockHistoricalDatas, bool isCumulative)
        {
            var ls = new LineSeries();

            foreach (var data in stockHistoricalDatas)
            {
                ls.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.Date), isCumulative ? data.CumulativeReturn : data.DailyPercentageChange));
            }

            return ls;
        }

        private double GetMinimumValue(bool isCumulative)
        {
            if (isCumulative)
            {
                var firstMin = _firstCompanyHistoricalData.Min(data => data.CumulativeReturn);
                var secondMin = _secondCompanykHistoricalData.Min(data => data.CumulativeReturn);
                return Math.Min(firstMin, secondMin);
            }
            else
            {
                var firstMin = _firstCompanyHistoricalData.Min(data => data.DailyPercentageChange);
                var secondMin = _secondCompanykHistoricalData.Min(data => data.DailyPercentageChange);
                return Math.Min(firstMin, secondMin);
            }
        }

        private double GetMaximumValue(bool isCumulative)
        {
            if (isCumulative)
            {
                var firstMax = _firstCompanyHistoricalData.Max(data => data.CumulativeReturn);
                var secondMax = _secondCompanykHistoricalData.Max(data => data.CumulativeReturn);
                return Math.Max(firstMax, secondMax);
            }
            else
            {
                var firstMax = _firstCompanyHistoricalData.Max(data => data.DailyPercentageChange);
                var secondMax = _secondCompanykHistoricalData.Max(data => data.DailyPercentageChange);
                return Math.Max(firstMax, secondMax);
            }
        }
    }

}
