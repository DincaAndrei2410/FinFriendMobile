using System;
using OxyPlot.Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Platform.iOS;

namespace FinFriend.iOS.Controls
{
    public class MyPlotViewRenderer : PlotViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<OxyPlot.Xamarin.Forms.PlotView> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
