using System;
using System.ComponentModel;
using System.Diagnostics;
using GoogleApi.Entities.Common;
using RSXamarinFormsControls.CustomControls.CustomMapViews;
using RSXamarinFormsControls.Utility.HelperModels.MessagingModels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace RSXamarinFormsControls.CustomControls
{
    public class CustomMapView : Map
    {

        public static readonly BindableProperty ZoomLevelProperty =
        BindableProperty.Create(nameof(ZoomLevel), typeof(Distance), typeof(CustomMapView), new Distance());
        public Distance ZoomLevel
        {
            get { return (Distance)GetValue(ZoomLevelProperty); }
            set { SetValue(ZoomLevelProperty, value); }
        }

        public event EventHandler<EventArgs> PinsAddedEvent;
        public event EventHandler<EventArgs> CircleAddedEvent;
        public Pin _selectedPin = null;
        public Location myLocation = null;
        public bool selectablePinOption = true;

        public CustomMapView()
        {
            this.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                CustomMapView map = sender as CustomMapView;
                if (map.VisibleRegion != null)
                {
                    this.ZoomLevel = map.VisibleRegion.Radius;
                }
            };
            PinClicked += CustomMapView_PinClicked;
        }

        private void CustomMapView_PinClicked(object sender, PinClickedEventArgs e)
        {
            e.Handled = true;
            if (e.Pin != _selectedPin)
            {
                SelectPin(e.Pin);
                SelectedPin = null;
            }
        }

        public void CameraZoomChanged()
        {
            ControlPinVisable(ZoomLevel);
        }

        public void ControlPinVisable(Distance zoomLevel)
        {
            if (zoomLevel.Kilometers < 500)
            {
                SetVisableAllPins(true);
            }
            else
            {
                SetVisableAllPins(false);
            }
        }

        public void AddCircle(Circle circle)
        {
            Circles.Add(circle);
        }

        public void DrawCircles()
        {
            CircleAddedEvent?.Invoke(this, new EventArgs());
        }

        public void PinAdd(Pin pin)
        {
            pin.Type = PinType.SavedPin;
            if(((PinData)pin.Tag) != null)
                pin.Icon = BitmapDescriptorFactory.FromView(new BindingPinView((PinData)pin.Tag));
            pin.Anchor = new Point(0, 0);
            pin.IsVisible = IsInMyArea(pin, 10000);
            Pins.Add(pin);
        }

        public void DrawPins()
        {
            PinsAddedEvent?.Invoke(this,new EventArgs());
        }

        public bool IsInMyArea(Pin pin , float areaMeterRadius)
        {
            if(myLocation != null)
            {
                var x = myLocation.Latitude - pin.Position.Latitude;
                var y = myLocation.Longitude - pin.Position.Longitude;
                var distance = TwoPointBetweenDistance(myLocation.Latitude, myLocation.Longitude, pin.Position.Latitude, pin.Position.Longitude);
                return distance <= areaMeterRadius;
            }
            return true;
        }

        public double TwoPointBetweenDistance(double lat1, double lon1, double lat2, double lon2)
        {  // generally used geo measurement function
            var R = 6378.137; // Radius of earth in KM
            var dLat = lat2 * Math.PI / 180 - lat1 * Math.PI / 180;
            var dLon = lon2 * Math.PI / 180 - lon1 * Math.PI / 180;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
            Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
            Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return d * 1000; // meters
        }

        public void SelectPin(Pin pin)
        {
            if (selectablePinOption)
            {
                if (_selectedPin != null)
                {
                    PinData _data = (PinData)_selectedPin.Tag;
                    _data.IsActive = false;
                    _selectedPin.Icon = BitmapDescriptorFactory.FromView(new BindingPinView(_data));
                }
                PinData data = (PinData)pin.Tag;
                data.IsActive = true;
                _selectedPin = pin;
                _selectedPin.Icon = BitmapDescriptorFactory.FromView(new BindingPinView(data));
            }
        }

        public void OnPinDragging(Pin pin)
        {
            if (pin != null)
            {
                PinData _data = (PinData)pin.Tag;
                var newPinView = new BindingPinView(_data);
                newPinView.SetDraging();
                pin.Icon = BitmapDescriptorFactory.FromView(newPinView);
            }
        }

        public void OnPinDropping(Pin pin)
        {
            if (pin != null)
            {
                PinData _data = (PinData)pin.Tag;
                var newPinView = new BindingPinView(_data);
                newPinView.SetDropping();
                pin.Icon = BitmapDescriptorFactory.FromView(newPinView);
            }
        }

        public void SetVisableAllPins(bool isVisable)
        {
            foreach (var pin in Pins)
            {
                pin.IsVisible = isVisable;
            }
            DrawPins();
        }

        public void ClearPins()
        {
            Pins.Clear();
        }
    }
}
