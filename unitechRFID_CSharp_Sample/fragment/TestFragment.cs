using Android.App;
using Android.Content;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Unitech.Lib.Diagnositics;
using Com.Unitech.Lib.Htx;
using Com.Unitech.Lib.Reader;
using Com.Unitech.Lib.Reader.Event;
using Com.Unitech.Lib.Reader.Types;
using Com.Unitech.Lib.Rpx;
using Com.Unitech.Lib.Transport;
using Com.Unitech.Lib.Transport.Types;
using Com.Unitech.Lib.Types;
using Com.Unitech.Lib.Uhf;
using Com.Unitech.Lib.Uhf.Event;
using Com.Unitech.Lib.Uhf.Params;
using Com.Unitech.Lib.Uhf.Types;
using Com.Unitech.Lib.Util.Diagnotics;
using Java.Lang;
using Java.Util;
using Org.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using unitechRFID_CSharp_Sample.enums;
using Newtonsoft.Json;
using static Java.Interop.JniEnvironment;
using Encoding = System.Text.Encoding;
using Exception = System.Exception;
using StringBuilder = System.Text.StringBuilder;
using Thread = System.Threading.Thread;
using Java.Security;

namespace unitechRFID_CSharp_Sample.fragment
{
    [Obsolete]
    public class TestFragment : BaseFragment
    {

        public int MAX_MASK = 2;

        #region Button
        private Button buttonInfo;
        private Button buttonSettings;
        private Button buttonInventory;
        private Button buttonRead;
        private Button buttonWrite;
        private Button buttonLock;
        private Button buttonUnlock;
        private Button buttonfind;
        #endregion

        #region TextView
        TextView connectState;
        TextView temperature;
        TextView result;
        TextView tagEPC;
        TextView tagRSSI;
        TextView battery;
        TextView tagData;
        #endregion

        [Obsolete]
        public TestFragment(MainActivity activity)
        {
            initFragment(activity);
        }

        [Obsolete]
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        [Obsolete]
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.fragment_test, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void ReceiveHandler(Bundle bundle)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
      
        }

        public override void OnPause()
        {
            if (_activity.baseReader != null)
            {
                if (_activity.baseReader.Action != ActionState.Stop)
                {
                    _activity.baseReader.RfidUhf.Stop();
                }
            }

            base.OnPause();
        }

        public void OnNotificationState(NotificationState state, Java.Lang.Object @params)
        {
        }





    }
}