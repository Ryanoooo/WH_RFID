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
using System.Collections;
using Java.Lang.Reflect;
using Org.Apache.Http.Protocol;
using Newtonsoft.Json.Linq;
using unitechRFID_CSharp_Sample.Model;

namespace unitechRFID_CSharp_Sample.fragment
{
    [Obsolete]
    public class SampleFragment : BaseFragment, IReaderEventListener, IRfidUhfEventListener
    {
        static string TAG = typeof(SampleFragment).Name;

        public int MAX_MASK = 2;
        private int NIBLE_SIZE = 4;

        bool accessTagResult;

        #region Button
        private Button buttonInfo;
        private Button buttonSettings;
        private Button buttonInventory;
        private Button buttonRead;
        private Button buttonWrite;
        private Button buttonLock;
        private Button buttonUnlock;
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

        #region ListView
        ListView listView;
        #endregion

        List<string> eidlist = new List<string>();

        [Obsolete]
        public SampleFragment(MainActivity activity)
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
            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

        [Obsolete]
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            FindViewById(view);

            SetButtonClick();

            Task.Run(ConnectTask);
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

        public void OnReaderActionChanged(BaseReader reader, ResultCode retCode, ActionState state, Java.Lang.Object @params)
        {
            try
            {
                if (state == ActionState.Inventory6c)
                {
                    UpdateText(IDType.Inventory, GetString(Resource.String.stop));
                }
                else if (state == ActionState.Stop)
                {
                    UpdateText(IDType.Inventory, GetString(Resource.String.inventory));
                }
            }
            catch (Exception e)
            {
                Log.Error(TAG, e.Message);
            }
        }

        public void OnReaderBatteryState(BaseReader reader, int batteryState, Java.Lang.Object @params)
        {
            UpdateText(IDType.Battery, batteryState.ToString());
        }

        public void OnReaderKeyChanged(BaseReader reader, KeyType type, KeyState state, Java.Lang.Object @params)
        {
            Console.WriteLine(state.ToString());
        }

        public void OnReaderStateChanged(BaseReader reader, ConnectState state, Java.Lang.Object @params)
        {
            UpdateText(IDType.ConnectState, state.ToString());

            if (state == ConnectState.Connected)
            {
                if (_activity.baseReader.RfidUhf != null)
                {
                    _activity.baseReader.RfidUhf.AddListener(this);
                }
            }
        }

        public void OnReaderTemperatureState(BaseReader reader, double temperatureState, Java.Lang.Object @params)
        {
            UpdateText(IDType.Temperature, temperatureState.ToString());
        }

        public void OnRfidUhfAccessResult(BaseUHF uhf, ResultCode code, ActionState action, string epc, string data, Java.Lang.Object @params)
        {
            if (code == ResultCode.NoError)
            {
                UpdateText(IDType.AccessResult, "Success");
            }
            else
            {
                UpdateText(IDType.AccessResult, code.ToString());
            }

            if (StringUtil.IsNullOrEmpty(data))
            {
                UpdateText(IDType.Data, "");
            }
            else
            {
                UpdateText(IDType.Data, data);
            }
            accessTagResult = (code == ResultCode.NoError);
        }


        public List<string> eidList(string tag)
        {

            eidlist.Add(tag);
            HashSet<string> uniqueNumbers = new HashSet<string>(eidlist);
            eidlist = new List<string>(uniqueNumbers);
            return eidlist;
        }

        public async Task GetMethod(string tag)
        {
            List<string> newList = eidList(tag);

            foreach (var number in newList)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://140.124.39.131:8000/get_eid");

                    string jsonData = @"{""eid"": " + GetString(Resource.String.inventory) + "}";

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.GetAsync("?eid=" + number);

                    // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                    var result = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(number);
                    Console.WriteLine(result.ToString());
                }
            }
        }


        public async void OnRfidUhfReadTag(BaseUHF uhf, string tag, Java.Lang.Object @params)
        {
            if (StringUtil.IsNullOrEmpty(tag))
            {
                return;
            }

            float rssi = 0;
            if (@params != null)
            {
                TagExtParam param = (TagExtParam)@params;
                rssi = param.Rssi;
            }




            UpdateText(IDType.TagEPC, tag);
            eidList(tag);




            UpdateText(IDType.TagRSSI, rssi.ToString());
        }

        /// <summary>
        /// Initial UI controler
        /// </summary>
        /// <param name="view"></param>
        private void FindViewById(View view)
        {
            #region Button
            buttonInfo = view.FindViewById<Button>(Resource.Id.button_info);
            buttonSettings = view.FindViewById<Button>(Resource.Id.button_settings);
            buttonInventory = view.FindViewById<Button>(Resource.Id.button_inventory);
            buttonRead = view.FindViewById<Button>(Resource.Id.button_read);
            buttonWrite = view.FindViewById<Button>(Resource.Id.button_write);
            buttonLock = view.FindViewById<Button>(Resource.Id.button_lock);
            buttonUnlock = view.FindViewById<Button>(Resource.Id.button_unlock);
            #endregion

            #region TextView
            connectState = view.FindViewById<TextView>(Resource.Id.connectState);
            temperature = view.FindViewById<TextView>(Resource.Id.temperature);
            result = view.FindViewById<TextView>(Resource.Id.result);
            tagEPC = view.FindViewById<TextView>(Resource.Id.tagEPC);
            tagRSSI = view.FindViewById<TextView>(Resource.Id.tagRSSI);
            battery = view.FindViewById<TextView>(Resource.Id.battery);
            tagData = view.FindViewById<TextView>(Resource.Id.tagData);
            #endregion

            #region ListView
            listView = view.FindViewById<ListView>(Resource.Id.listView);
            #endregion

        }

        private void SetButtonClick()
        {
            buttonInfo.Click += delegate
            {
                try
                {
                    AssertReader();
                }
                catch (System.Exception e)
                {
                    MainActivity.ShowToast(e.Message);
                    return;
                }

                StringBuilder data = new StringBuilder();

                try
                {
                    data.Append(GetString(Resource.String.deviceName)).Append(_activity.baseReader.DeviceName).Append("\n");
                    data.Append(GetString(Resource.String.sku)).Append(_activity.baseReader.SKU.ToString()).Append("\n");
                    data.Append(GetString(Resource.String.region)).Append(_activity.baseReader.RfidUhf.GlobalBand.ToString()).Append("\n");
                    data.Append(GetString(Resource.String.version)).Append(_activity.baseReader.Version).Append("\n");

                    data.Append(GetString(Resource.String.temperature)).Append(_activity.baseReader.Temperature).Append("\n");

                    if (_activity.mainModel.deviceType == DeviceType.Rp902)
                    {
                        data.Append(GetString(Resource.String.time)).Append(_activity.baseReader.Time.ToString()).Append("\n");
                        data.Append(GetString(Resource.String.readMode)).Append(_activity.baseReader.ReadMode.ToString()).Append("\n");
                        data.Append(GetString(Resource.String.operatingMode)).Append(_activity.baseReader.OperatingMode.ToString()).Append("\n");
                    }
                }
                catch (Com.Unitech.Lib.Diagnositics.ReaderException e)
                {
                    Log.Error(TAG, e.Message);
                }

                MainActivity.ShowDialog("Info", data.ToString());
            };

            buttonSettings.Click += delegate
            {
                try
                {
                    AssertReader();
                }
                catch (Exception e)
                {
                    MainActivity.ShowToast(e.Message);
                    return;
                }

                StringBuilder data = new StringBuilder();

                try
                {
                    PowerRange powerRange = _activity.baseReader.RfidUhf.PowerRange;
                    data.Append(GetString(Resource.String.power)).Append(_activity.baseReader.RfidUhf.Power).Append(string.Format(" ({0} - {1})", powerRange.Min, powerRange.Max)).Append("\n");

                    data.Append(GetString(Resource.String.inventoryTime)).Append(_activity.baseReader.RfidUhf.InventoryTime).Append("\n");
                    data.Append(GetString(Resource.String.idleTime)).Append(_activity.baseReader.RfidUhf.IdleTime).Append("\n");

                    data.Append(GetString(Resource.String.algorithm)).Append(_activity.baseReader.RfidUhf.AlgorithmType.ToString()).Append("\n");
                    data.Append(GetString(Resource.String.qValue));
                    data.Append(GetString(Resource.String.startQ)).Append(_activity.baseReader.RfidUhf.StartQ).Append(", ");
                    data.Append(GetString(Resource.String.minQ)).Append(_activity.baseReader.RfidUhf.MinQ).Append(", ");
                    data.Append(GetString(Resource.String.maxQ)).Append(_activity.baseReader.RfidUhf.MaxQ).Append("\n");

                    data.Append(GetString(Resource.String.session)).Append(_activity.baseReader.RfidUhf.Session.ToString()).Append(", ");
                    data.Append(GetString(Resource.String.target)).Append(_activity.baseReader.RfidUhf.Target.ToString()).Append("\n");

                    data.Append(GetString(Resource.String.toggleTarget)).Append(_activity.baseReader.RfidUhf.ToggleTarget).Append("\n");

                    data.Append(GetString(Resource.String.continuousMode)).Append(_activity.baseReader.RfidUhf.ContinuousMode).Append("\n");

                    if (_activity.mainModel.deviceType == DeviceType.Rp902)
                    {
                        data.Append(GetString(Resource.String.autoOffTime)).Append(_activity.baseReader.AutoOffTime).Append(_activity.baseReader.GetAutoOffTimeList().ToString()).Append("\n");

                        data.Append(GetString(Resource.String.beep)).Append(_activity.baseReader.Beeper.ToString()).Append(", ");
                        data.Append(GetString(Resource.String.vibrator)).Append(_activity.baseReader.Vibrator.ToString()).Append("\n");

                        data.Append(GetString(Resource.String.tari)).Append(_activity.baseReader.RfidUhf.TARI.ToString()).Append(", ");
                        data.Append(GetString(Resource.String.blf)).Append(_activity.baseReader.RfidUhf.BLF.ToString()).Append("\n");
                        data.Append(GetString(Resource.String.fastMode)).Append(_activity.baseReader.RfidUhf.FastMode).Append("\n");
                    }
                    else if (_activity.mainModel.deviceType == DeviceType.Ht730)
                    {

                        data.Append(GetString(Resource.String.profile)).Append(_activity.baseReader.RfidUhf.ModuleProfile).Append("\n");
                        data.Append(GetString(Resource.String.powerMode)).Append(_activity.baseReader.RfidUhf.PowerMode.ToString()).Append("\n");

                    }
                }
                catch (ReaderException e)
                {
                    Log.Error(TAG, e.Message);
                }

                MainActivity.ShowDialog("Settings", data.ToString());
            };

            buttonInventory.Click += delegate
            {
                try
                {
                    AssertReader();
                }
                catch (Exception e)
                {
                    MainActivity.ShowToast(e.Message);
                    return;
                }

                if (_activity.baseReader.Action == ActionState.Stop)
                {
                    DoInventory();
                }
                else if (_activity.baseReader.Action == ActionState.Inventory6c)
                {
                    DoStop();
                }
            };

            buttonRead.Click += delegate
            {
                try
                {
                    AssertReader();
                }
                catch (Exception e)
                {
                    MainActivity.ShowToast(e.Message);
                    return;
                }

                if (_activity.baseReader.Action == ActionState.Stop)
                {
                    ClearResult();
                    DoRead();
                }
            };

            buttonWrite.Click += delegate
            {
                try
                {
                    AssertReader();
                }
                catch (Exception e)
                {
                    MainActivity.ShowToast(e.Message);
                    return;
                }

                if (_activity.baseReader.Action == ActionState.Stop)
                {
                    ClearResult();
                    DoWrite();
                }
            };

            buttonLock.Click += delegate
            {
                try
                {
                    AssertReader();
                }
                catch (Exception e)
                {
                    MainActivity.ShowToast(e.Message);
                    return;
                }

                if (_activity.baseReader.Action == ActionState.Stop)
                {
                    ClearResult();
                    _ = LockUnlockProc(true);
                }
            };

            buttonUnlock.Click += delegate
            {
                try
                {
                    AssertReader();
                }
                catch (Exception e)
                {
                    MainActivity.ShowToast(e.Message);
                    return;
                }

                if (_activity.baseReader.Action == ActionState.Stop)
                {
                    ClearResult();
                    _ = LockUnlockProc(false);
                }
            };
        }

        public override void ReceiveHandler(Bundle bundle)
        {
            UpdateUIType updateUIType = (UpdateUIType)bundle.GetInt(ExtraName.Type);

            switch (updateUIType)
            {
                case UpdateUIType.Text:
                    {
                        string data = bundle.GetString(ExtraName.Text);
                        IDType idType = (IDType)bundle.GetInt(ExtraName.TargetID);

                        switch (idType)
                        {
                            case IDType.ConnectState:
                                connectState.Text = data;
                                break;
                            case IDType.Temperature:
                                temperature.Text = data;
                                break;
                            case IDType.AccessResult:
                                result.Text = data;
                                break;
                            case IDType.TagEPC:
                                tagEPC.Text = data;
                                break;
                            case IDType.TagRSSI:
                                tagRSSI.Text = data;
                                break;
                            case IDType.Battery:
                                battery.Text = data;
                                break;
                            case IDType.Inventory:
                                buttonInventory.Text = data;
                                break;
                            case IDType.Data:
                                tagData.Text = data;
                                break;
                        }
                    }
                    break;
            }
        }

        private void AssertReader()
        {
            _activity.AssertReader();
        }

        private void AssertTagEPC(string epc)
        {
            if (StringUtil.IsNullOrEmpty(epc))
            {
                Log.Error(TAG, "EPC is empty");
                throw new Exception("EPC is empty");
            }
        }

        private void DoInventory()
        {
            try
            {
                InitSetting();

                ClearSelectMask();

                _activity.baseReader.RfidUhf.Inventory6c();

            }
            catch (ReaderException e)
            {
                MainActivity.ShowToast(e.Message);
            }
        }


        private void DoStop()
        {
            _activity.baseReader.RfidUhf.Stop();
        }

        public async Task PostMethod()
        {


            var client = new HttpClient();

            client.BaseAddress = new Uri("http://140.124.39.131:8000/get_eid");

            //string jsonData = @"{""eid"": " + GetString(Resource.String.inventory) + "}";

            string listpostdata = JsonConvert.SerializeObject(eidlist);
            var jsondata = new StringContent(listpostdata, Encoding.UTF8, "application/json");

            //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("", jsondata);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();

            UpdateText(IDType.listView, result);


            Console.WriteLine(result);

        }

        //private void UpdateListView( string data)
        //{
        //    // 在活動或片段中的某個方法中
        //    string jsonResponse = data;
        //    var productList = JsonConvert.DeserializeObject<ProductList>(jsonResponse).Products;

        //    var adapter = new ArrayAdapter<Product>(this, Android.Resource.Layout.SimpleListItem1, productList);
        //    listView.Adapter = adapter;
        //}

        public class ProductList
        {
            [JsonProperty("product")]
            public List<Product> Products { get; set; }
        }




        private async void DoRead()
        {
            string targetTag = tagEPC.Text;


            try
            {
                AssertTagEPC(targetTag);
            }
            catch (Exception e)
            {
                MainActivity.ShowToast(e.Message);
                return;
            }

            if (SetSelectMask(targetTag))
            {
                string accessPassword = "00000000";
                int offset = 2;
                int length = 6;

                await PostMethod();

                //var client = new HttpClient();
                //client.BaseAddress = new Uri("http://140.124.39.131:8000/get_eid");

                ////string jsonData = @"{""eid"" : " + GetString(Resource.String.inventory) + "}";

                //var requestData = new Dictionary<string, string>
                //{
                //    { "eid",targetTag },
                //    { "name" , "F椒" }
                //};


                //var formContent = new FormUrlEncodedContent(requestData);

                ////string jsonData = JsonConvert.SerializeObject(requestData);
                ////string requestUrl = "/SendEid";
                ////string queryParamters = "?eid" + targetTag + "&Name=A椒";
                ////requestUrl +=  queryParamters;


                ////var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                ////HttpResponseMessage response = await client.PostAsync("/SendEid" + "?eid=" + targetTag,content);
                //HttpResponseMessage response = await client.PostAsync("", formContent);

                //// this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                //var result = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(result.ToString());

                if (!ReadTag(BankType.Epc, offset, length, accessPassword))
                {
                    MainActivity.ShowToast("Failed to read memory");
                }
            }
        }

        private void DoWrite()
        {
            string targetTag = tagEPC.Text;

            try
            {
                AssertTagEPC(targetTag);
            }
            catch (Exception e)
            {
                MainActivity.ShowToast(e.Message);
                return;
            }

            if (SetSelectMask(targetTag))
            {
                string accessPassword = "00000000";
                BankType bank = BankType.Epc;
                int offset = 2;

                //region Change the data for test
                if (targetTag.StartsWith("1234"))
                {
                    targetTag = "4321" + targetTag.Substring(4);
                }
                else
                {
                    targetTag = "1234" + targetTag.Substring(4);
                }
                //endregion

                if (!WriteTag(BankType.Epc, offset, accessPassword, targetTag))
                {
                    MainActivity.ShowToast("Failed to write memory");
                }
            }
        }

        async Task LockUnlockProc(bool locked)
        {
            string targetTag = tagEPC.Text;

            try
            {
                AssertTagEPC(targetTag);
            }
            catch (Exception e)
            {
                MainActivity.ShowToast(e.Message);
                return;
            }

            if (SetSelectMask(targetTag))
            {
                string accessPassword = "00000000";
                string data = "12345678";
                int offset = 2;

                //region Write the password for lock/unlock test
                accessTagResult = false;

                if (!WriteTag(BankType.Reserved, offset, accessPassword, data))
                {
                    MainActivity.ShowToast("Write password fail");
                    return;
                }

                long startTime = JavaSystem.CurrentTimeMillis();
                bool timeout = false;

                while (_activity.baseReader.Action != ActionState.Stop)
                {
                    if (JavaSystem.CurrentTimeMillis() - startTime > 3000)
                    {
                        timeout = true;
                        break;
                    }
                    Thread.Sleep(10);
                }

                if (timeout)
                {
                    MainActivity.ShowToast("Write password timeout");
                    return;
                }

                if (!accessTagResult)
                {
                    MainActivity.ShowToast("Write password fail from access result");
                    return;
                }
                //endregion

                accessPassword = data;

                Lock6cParam lockParam = new Lock6cParam();
                lockParam.Epc = locked ? LockState.Lock : LockState.Unlock;

                ResultCode res = _activity.baseReader.RfidUhf.Lock6c(lockParam, accessPassword);

                if (res != ResultCode.NoError)
                {
                    Log.Error(TAG, "Failed to lock/unlock tag - " + res);
                }
            }
        }

        /// <summary>
        /// Read tag's memory
        /// </summary>
        /// <param name="bank">The BankType enumeration that specifies the Bank for reading memory.</param>
        /// <param name="offset">An integer specifying the starting address to start reading from the specified
        /// bank. Unit is WORD unit.</param>
        /// <param name="length">An integer that specifies the length of data to read from the specified start
        /// address. Unit is WORD unit.</param>
        /// <param name="password">If the tag is locked, it is a hex string specifying the Access Password set
        /// in the tag. Up to 8 characters (2 words) can be input.</param>
        /// <returns></returns>
        public bool ReadTag(BankType bank, int offset, int length, string password)
        {
            ResultCode res = _activity.baseReader.RfidUhf.ReadMemory6c(
                    bank, offset, length, password);

            if (res != ResultCode.NoError)
            {
                Log.Error(TAG, "Failed to read memory - " + res);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Write data to tag's memory
        /// </summary>
        /// <param name="bank">BankType enumeration that specifies the Bank for writing memory.</param>
        /// <param name="offset">An integer specifying the starting address to start writing from the specified
        /// bank. Unit is WORD unit.</param>
        /// <param name="password">If the tag is locked, it is a hex string specifying the Access Password set
        /// in the tag. Up to 8 characters (2 words) can be input.</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool WriteTag(BankType bank, int offset, string password, string data)
        {
            ResultCode res = _activity.baseReader.RfidUhf.WriteMemory6c(
                    bank, offset, data, password);
            if (res != ResultCode.NoError)
            {
                Log.Error(TAG, "Failed to write memory - " + res);
                return false;
            }
            return true;
        }

        void InitSetting()
        {
            try
            {
                _activity.baseReader.RfidUhf.Session = Session.S0;
                _activity.baseReader.RfidUhf.ContinuousMode = true;
                _activity.baseReader.RfidUhf.InventoryTime = 200;
                _activity.baseReader.RfidUhf.IdleTime = 20;


                _activity.baseReader.RfidUhf.AlgorithmType = AlgorithmType.DynamicQ;

                _activity.baseReader.RfidUhf.StartQ = 4;
                _activity.baseReader.RfidUhf.MaxQ = 15;
                _activity.baseReader.RfidUhf.MinQ = 0;

                _activity.baseReader.RfidUhf.Target = Target.A;

                _activity.baseReader.RfidUhf.ToggleTarget = true;

                if (_activity.mainModel.deviceType == DeviceType.Rp902)
                {
                    _activity.baseReader.RfidUhf.Power = 22;

                    _activity.baseReader.AutoOffTime = 2;

                    _activity.baseReader.Beeper = BeeperState.Off;
                    _activity.baseReader.Vibrator = VibratorState.On;

                    _activity.baseReader.RfidUhf.TARI = TARIType.T2500;
                    _activity.baseReader.RfidUhf.BLF = BLFType.Blf256;
                    _activity.baseReader.RfidUhf.FastMode = true;

                    Date currentTime = Calendar.Instance.Time;
                    _activity.baseReader.Time = currentTime;
                }
                else if (_activity.mainModel.deviceType == DeviceType.Ht730)
                {
                    _activity.baseReader.RfidUhf.Power = 30;
                    _activity.baseReader.RfidUhf.ModuleProfile = 0;
                    _activity.baseReader.RfidUhf.PowerMode = PowerMode.Optimized;
                }
            }
            catch (ReaderException e)
            {
                Log.Error(TAG, e.Message);
            }
        }

        private async Task ConnectTask()
        {
            try
            {
                if (_activity.mainModel.deviceType == DeviceType.Rp902)
                {
                    TransportBluetooth tb = new TransportBluetooth(DeviceType.Rp902, "RP902", _activity.mainModel.bluetoothMACAddress);
                    _activity.baseReader = new RP902Reader(tb);
                    _activity.baseReader.AddListener(this);
                    _activity.baseReader.Connect();

                }
                else if (_activity.mainModel.deviceType == DeviceType.Ht730)
                {
                    _activity.baseReader = new HT730Reader(_activity.ApplicationContext);
                    _activity.baseReader.AddListener(this);
                    _activity.baseReader.Connect();
                }
            }
            catch (Exception e)
            {
                Log.Error(TAG, e.ToString());
                MainActivity.ShowToast("Connect exception: " + e.Message);
            }
        }

        /// <summary>
        /// Select the target tag to access
        /// </summary>
        /// <param name="maskEpc">The tag's EPC value</param>
        /// <returns>True for success, false for fail</returns>
        public bool SetSelectMask(string maskEpc)
        {
            SelectMask6cParam param = new SelectMask6cParam(
                    true,
                    Mask6cTarget.Sl,
                    Mask6cAction.Ab,
                    BankType.Epc,
                    0,
                    maskEpc,
                    maskEpc.Length * NIBLE_SIZE);
            try
            {
                for (int i = 0; i < MAX_MASK; i++)
                {
                    _activity.baseReader.RfidUhf.SetSelectMask6cEnabled(i, false);
                }
                _activity.baseReader.RfidUhf.SetSelectMask6c(0, param);
                Log.Debug(TAG, "setSelectMask success: " + param.ToString());
            }
            catch (ReaderException e)
            {
                Log.Error(TAG, "setSelectMask failed: \n" + e.Code.Message);
                MainActivity.ShowToast("setSelectMask failed");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Clear selected tag
        /// </summary>
        public void ClearSelectMask()
        {
            for (int i = 0; i < MAX_MASK; i++)
            {
                try
                {
                    _activity.baseReader.RfidUhf.SetSelectMask6cEnabled(i, false);
                    Log.Debug(TAG, "ClearSelectMask successful");
                }
                catch (ReaderException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Update the UI text view
        /// </summary>
        /// <param name="id">The ID to update</param>
        /// <param name="data">The string to show</param>
        private void UpdateText(IDType id, string data)
        {
            Utilities.UpdateUIText(FragmentType.Sample, (int)id, data);
        }

        void ClearResult()
        {
            UpdateText(IDType.AccessResult, "");
            UpdateText(IDType.Data, "");
        }
    }
}