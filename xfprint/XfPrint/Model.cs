using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XfPrint
{
    public  class DeviceModel : Prism.Mvvm.BindableBase
    {
        private int _deviceid ;
        public int deviceid
        {
            get { return _deviceid; }
            set { SetProperty(ref _deviceid, value); }
        }

        private string _devicecode = null;
        public string devicecode
        {
            get { return _devicecode; }
            set { SetProperty(ref _devicecode, value); }
        }


        private string _jiamistr = null;
        public string jiamistr
        {
            get { return _jiamistr; }
            set { SetProperty(ref _jiamistr, value); }
        }

        private string _devicename = null;
        public string devicename
        {
            get { return _devicename; }
            set { SetProperty(ref _devicename, value); }
        }

       


        private string _tel = null;
        public string tel
        {
            get { return _tel; }
            set { SetProperty(ref _tel, value); }
        }

        private string _proprietor = null;
        public string proprietor
        {
            get { return _proprietor; }
            set { SetProperty(ref _proprietor, value); }
        }


        private byte[] _devcodeBytes = null;
        public byte[] erweimaBytes
        {
            get { return _devcodeBytes; }
            set { SetProperty(ref _devcodeBytes, value); }
        }

        private bool _check = false;
        public bool check
        {
            get { return _check; }
            set { SetProperty(ref _check, value); }
        }

        public Prism.Commands.DelegateCommand<object> ItemClickCommand {get;set;}

    }








    public class AreaModel : Prism.Mvvm.BindableBase
    {
        private int _areaid;
        public int areaid
        {
            get { return _areaid; }
            set { SetProperty(ref _areaid, value); }
        }

        private string _areacode = null;
        public string areacode
        {
            get { return _areacode; }
            set { SetProperty(ref _areacode, value); }
        }

        private string _areaname = null;
        public string areaname
        {
            get { return _areaname; }
            set { SetProperty(ref _areaname, value); }
        }


        private int _parentareaid;
        public int parentareaid
        {
            get { return _parentareaid; }
            set { SetProperty(ref _parentareaid, value); }
        }


        private byte[] _erweimaBytes = null;
        public byte[] erweimaBytes
        {
            get { return _erweimaBytes; }
            set { SetProperty(ref _erweimaBytes, value); }
        }

        private bool _check = false;
        public bool check
        {
            get { return _check; }
            set { SetProperty(ref _check, value); }
        }

        public Prism.Commands.DelegateCommand<object> ItemClickCommand { get; set; }

    }
}


 

 

 
 