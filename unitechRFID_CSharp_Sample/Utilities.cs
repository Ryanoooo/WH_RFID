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
using unitechRFID_CSharp_Sample.enums;

namespace unitechRFID_CSharp_Sample
{
    public class Utilities
    {
        public static void UpdateUIText(FragmentType fragmentType, int id, string data)
        {
            UpdateUI(fragmentType, id, UpdateUIType.Text, data);
        }

        /// <summary>
        /// Update the fragment's UI via handle 
        /// </summary>
        /// <param name="fragmentType">The fragment type</param>
        /// <param name="id">The target view's ID, it defined in each fragment</param>
        /// <param name="uiType">The update type, for fragment. Ex: text, enable, number</param>
        /// <param name="obj">The update information</param>
        [Obsolete]
        public static void UpdateUI(FragmentType fragmentType, int id, UpdateUIType uiType, Object obj)
        {
            Bundle bundle = new Bundle();

            bundle.PutInt(ExtraName.Type, (int)uiType);
            bundle.PutInt(ExtraName.TargetID, id);

            if (obj is string) {
                bundle.PutString(ExtraName.Text, (string)obj);
            } else if (obj is bool) {
                bundle.PutBoolean(ExtraName.Enable, (bool)obj);
            } else if (obj is int) {
                bundle.PutInt(ExtraName.Number, (int)obj);
            }

            MainActivity.TriggerHandler(fragmentType, bundle);
        }
    }
}