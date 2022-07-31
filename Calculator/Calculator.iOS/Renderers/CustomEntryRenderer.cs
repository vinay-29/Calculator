using Calculator.CustomControls;
using Calculator.iOS.Renderers;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Calculator.iOS.Renderers
{
    public class CustomEntryRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            this.Control.InputView = new UIView();

            if (Control != null)
            {
                Control.Layer.CornerRadius = 10;
                
            }
        }
    }
}