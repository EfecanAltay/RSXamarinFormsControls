using Xamarin.Forms.Platform.UWP;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.UWP.CustomRenderer;
using Xamarin.Forms.GoogleMaps.UWP;
using System.ComponentModel;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using System.Collections.Generic;
using System;
using System.Drawing;
using Xamarin.Forms.GoogleMaps;
using System.IO;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;

[assembly: ExportRenderer(typeof(CustomMapView), typeof(CustomMapViewRenderer))]
namespace RSXamarinFormsControls.UWP.CustomRenderer
{
    public class CustomMapViewRenderer : ViewRenderer<CustomMapView, MapRenderer>
    {
        MapElementsLayer MyCircleLayoutLayer;
        MapElementsLayer PinsLayoutLayer;
        CustomMapView customMapView;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomMapView> e)
        {
            base.OnElementChanged(e);

            // if disposing, NewElement is null. In that case just return
            if (e.NewElement == null)
                return;

            if (Control == null)
            {
                SetNativeControl(new MapRenderer());
            }

            if (e.OldElement != null)
            {
                //
            }

            if (e.NewElement != null)
            {
                customMapView = e.NewElement;
                customMapView.CircleAddedEvent += CustomMapView_CircleAddedEvent;
                Control.SetElement(customMapView);
                Control.Control.MapServiceToken = "AidW-gaCLAQfzCIyGY55kr4a_xFQn81E9ovFNXUMxEBSvZdN_Mt0irKBXcPsWHfX";
                Control.Element.PinClicked += Element_PinClicked;
                Control.Control.CanDrag = true;
            }
        }

        private void CustomMapView_CircleAddedEvent(object sender, EventArgs e)
        {
            if (Control?.Control != null)
            {
                if (MyCircleLayoutLayer != null)
                    Control.Control.Layers.Remove(MyCircleLayoutLayer);
                var MyCircleLayout = new List<MapElement>();
                foreach (var circle in customMapView.Circles)
                {
                    BasicGeoposition s = new BasicGeoposition();
                    s.Latitude = circle.Center.Latitude;
                    s.Longitude = circle.Center.Longitude;
                    MapPolygon mapPolygon = GetCircleMapPolygon(s, circle.Radius.Meters, circle.FillColor, circle.StrokeColor, circle.StrokeWidth);
                    MyCircleLayout.Add(mapPolygon);
                }
                MyCircleLayoutLayer = new MapElementsLayer
                {
                    ZIndex = 1,
                    MapElements = MyCircleLayout
                };
                Control.Control.Layers.Add(MyCircleLayoutLayer);
            }
        }

        private void Control_ZoomLevelChanged(MapControl sender, object args)
        {
            if (customMapView != null)
            {
                customMapView.CameraZoomChanged();
            }
        }

        private void Element_PinClicked(object sender, Xamarin.Forms.GoogleMaps.PinClickedEventArgs e)
        {
            //..
            var root = ((Windows.UI.Xaml.Controls.ContentControl)e.Pin.NativeObject).ContentTemplateRoot as Windows.UI.Xaml.Controls.StackPanel;
            ((Windows.UI.Xaml.Controls.StackPanel)root.Children[0]).Opacity = 0;
        }

        /// <summary> 
        /// We couldn't draw Circle for uwp and used this method  
        /// See: https://social.msdn.microsoft.com/Forums/ie/en-US/25988fae-4a57-4027-8e47-ed3b5f362f1d/uwpchow-to-show-geofence-on-map-with-circle-for-every-geofence-have-radius?forum=wpdevelop 
        /// </summary> 
        public MapPolygon GetCircleMapPolygon(BasicGeoposition originalLocation, double radius, Color fillColor, Color strokeColor, double strokeThickness)
        {
            MapPolygon retVal = new MapPolygon();

            List<BasicGeoposition> locations = new List<BasicGeoposition>();
            double latitude = originalLocation.Latitude * Math.PI / 180.0;
            double longitude = originalLocation.Longitude * Math.PI / 180.0;
            // double x = radius / 3956; // Miles 
            double x = radius / 6371000; // Meters  
            for (int i = 0; i <= 360; i += 10) // <-- you can modify this incremental to adjust the polygon. 
            {
                double aRads = i * Math.PI / 180.0;
                double latRadians = Math.Asin(Math.Sin(latitude) * Math.Cos(x) + Math.Cos(latitude) * Math.Sin(x) * Math.Cos(aRads));
                double lngRadians = longitude + Math.Atan2(Math.Sin(aRads) * Math.Sin(x) * Math.Cos(latitude), Math.Cos(x) - Math.Sin(latitude) * Math.Sin(latRadians));

                BasicGeoposition loc = new BasicGeoposition() { Latitude = 180.0 * latRadians / Math.PI, Longitude = 180.0 * lngRadians / Math.PI };
                locations.Add(loc);
            }

            retVal.Path = new Geopath(locations);
            retVal.FillColor = Windows.UI.Color.FromArgb(fillColor.A, fillColor.R, fillColor.G, fillColor.B);
            retVal.StrokeColor = Windows.UI.Color.FromArgb(strokeColor.A, strokeColor.R, strokeColor.G, strokeColor.B);
            retVal.StrokeThickness = strokeThickness;

            return retVal;
        }

    }
}
