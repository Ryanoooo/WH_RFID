using Android.App;
using Android.OS;
using System;

namespace unitechRFID_CSharp_Sample.fragment
{
    [Obsolete]
    public abstract class BaseFragment : Fragment
    {
        protected MainActivity _activity;

        protected void initFragment(MainActivity activity)
        {
            this._activity = activity;
        }
        
        /// <summary>
        /// Receive request from handler
        /// </summary>
        /// <param name="bundle">The request bundle</param>
        public abstract void ReceiveHandler(Bundle bundle);

        [Obsolete]
        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}