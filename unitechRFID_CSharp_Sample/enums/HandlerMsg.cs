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
    public enum HandlerMsg
    {
        Toast = 0,
        Dialog,
        Unknown = 255,
    }
}