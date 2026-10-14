using System;
using System.Collections.Generic;
using System.Text;

namespace Assiment6.Net.OOP05.SmartDeliveryManagement
{
    internal partial class Shipment
    {
        private string trackingStatus;

        public string TrackingStatus
        {
            get { return trackingStatus; }
            set { trackingStatus = value; }
        }
        public string GetTrackingStatus()
        {
            return TrackingStatus;
        }
        public string UpdateTrackingStatus( string newStatus )
        {
        
           return OnTrackingStatusChanged(newStatus);
        }
        public partial string OnTrackingStatusChanged(string newStatus);



    }
}
