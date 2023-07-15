﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unitechRFID_CSharp_Sample.enums
{
    public enum IDType
    {
        ConnectState = 0,
        Temperature = 1,
        TagEPC = 12,
        AccessResult = 13,
        TagRSSI = 18,
        Battery = 20,
        Inventory = 21,
        Data = 22,
        listView = 23,
    }
}