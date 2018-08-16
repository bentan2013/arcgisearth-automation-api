﻿// Copyright 2017 Esri
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using ArcGIS.Desktop.Framework.Contracts;
using EarthAPIUtils;

namespace ToArcGISEarth
{
    internal class ConnectToArcGISEarthButton : Button
    {
        public static EarthNamedpipeAPIUtils Utils { get; set; }
        public static bool IsConnectSuccessful { get; set; } // Record the status of connecting ArcGIS Earth
        public static Dictionary<string, string[]> IdNameDic { get; set; } // Record the layer id, layer name and layer MapLayerType

        public ConnectToArcGISEarthButton()
        {
            Utils = new EarthNamedpipeAPIUtils();
            IdNameDic = new Dictionary<string, string[]>();
            IsConnectSuccessful = false;
        }

        protected override async void OnClick()
        {
            if (this.IsChecked)
            {
                Utils.CloseConnect();
                this.IsChecked = false;
                this.Caption = "Connect";
                IdNameDic.Clear();
                IsConnectSuccessful = false;
            }
            else
            {
                string result = await Utils.Connect();
                if (result != "Success")
                {
                    ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show("Please start ArcGIS Earth with automation API opened then connect to it");
                    return;
                }
                else
                {
                    this.IsChecked = true;
                    this.Caption = "Disconnect";
                    IsConnectSuccessful = true;
                }
            }
        }
    }
}