using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMain.Db
{
    public class Organization
    {
        public int organizationid { get; set; }

        public string organizationcode { get; set; }

        public string organizationname { get; set; }

        public int organizationtype { get; set; }
    }

    public class DevType
    {
        public int devicetypeid { get; set; }
        
        public string devicetypecode { get; set; }

        public string devicetypename { get; set; }

    }

    public class BaseDev
    {
        public int basedeviceid { get; set; }

        public string basedevicecode { get; set; }

        public string devicename { get; set; }

        public int devicetypeid { get; set; }

    }

    public class Device
    {
        public int deviceid { get; set; }

        public string devicecode { get; set; }

        public string devicename { get; set; }

        public string devicemodel { get; set; }
        public string position { get; set; }
        public int devicestate { get; set; }

        public int approvalstate { get; set; }

    }

}
