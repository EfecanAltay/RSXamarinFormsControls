using System;
using System.Collections.Generic;
using System.IO;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.MessagingModels;
using RSXamarinFormsControls.UWP.CustomRenderer;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomMapView), typeof(CustomMapRenderer))]
namespace RSXamarinFormsControls.UWP.CustomRenderer
{
    public class CustomMapRenderer : MapRenderer
    {
        Map map;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                map = e.NewElement;
                Control.ActualCameraChanging += Control_ActualCameraChanging;
                foreach (var circle in map.Circles)
                {
                    BasicGeoposition s = new BasicGeoposition();
                    s.Latitude = circle.Center.Latitude;
                    s.Longitude = circle.Center.Longitude;
                    MapPolygon mapPolygon = GetCircleMapPolygon(s, circle.Radius.Meters);
                    var MyHighlights = new List<MapElement>();
                    MyHighlights.Add(mapPolygon);
                    var HighlightsLayer = new MapElementsLayer
                    {
                        ZIndex = 1,
                        MapElements = MyHighlights
                    };
                    Control.Layers.Add(HighlightsLayer);
                }
            }
        }

        private void Control_ActualCameraChanging(MapControl sender, MapActualCameraChangingEventArgs args)
        {
            MessagingCenter.Send(new CameraPositionUpdatingMessage() { zoom = sender.ZoomLevel }, "Map_CameraPositionUpdating");
        }

        /// <summary>
        /// We couldn't draw Circle for uwp and used this method 
        /// See: https://social.msdn.microsoft.com/Forums/ie/en-US/25988fae-4a57-4027-8e47-ed3b5f362f1d/uwpchow-to-show-geofence-on-map-with-circle-for-every-geofence-have-radius?forum=wpdevelop
        /// </summary>
        public MapPolygon GetCircleMapPolygon(BasicGeoposition originalLocation, double radius)
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
            retVal.FillColor = Windows.UI.Color.FromArgb(0x40, 0x10, 0x10, 0x80);
            retVal.StrokeColor = Windows.UI.Colors.Blue;
            retVal.StrokeThickness = 2;

            return retVal;
        }
    }
}
