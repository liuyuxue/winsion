using CommonDB;
using CommonLib.Function;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMain.Db;

namespace WpfAppMain.Db
{
    public  class DbBiz
    {
        public static List<Organization> GetAllOrganization(  )
        {
            string sql = "select organizationid,organizationcode,organizationname,organizationtype from organizations where organizationtype=1" ;
            DataSet ds = MySqlHelper.GetDataSet(System.Data.CommandType.Text, sql);
            List<Organization> us = Dt2List.ConvertTo<Organization>(ds.Tables[0]);
            return us;
        }

        public static List<DevType> GetAllDevType()
        {
            string sql = "select devicetypeid,devicetypecode,devicetypename  from devicetype where parentid is null";
            DataSet ds = MySqlHelper.GetDataSet(System.Data.CommandType.Text, sql);
            List<DevType> us = Dt2List.ConvertTo<DevType>(ds.Tables[0]);
            return us;
        }

        public static List<BaseDev> GetAllBaseDev()
        {
            string sql = "select basedeviceid,basedevicecode,devicename,devicetypeid from basedevices";
            DataSet ds = MySqlHelper.GetDataSet(System.Data.CommandType.Text, sql);
            List<BaseDev> us = Dt2List.ConvertTo<BaseDev>(ds.Tables[0]);
            return us;
        }

        public static List<Device> GetAllDevice(string basedevicecode,int pageindex,int pagesize)
        {
            int pageindex2 = pageindex - 1;
            int start = pageindex2 * pagesize;
            string sql = string.Format("select deviceid,devicecode,devicename,devicemodel,position,devicestate,approvalstate from devices where   devicestate!=-10 and basedevicecode='{0}' limit {1},{2}",
                basedevicecode, start, pagesize);
            DataSet ds = MySqlHelper.GetDataSet(System.Data.CommandType.Text, sql);
            List<Device> us = Dt2List.ConvertTo<Device>(ds.Tables[0]);
            return us;
        }

        public static int GetAllDeviceCount(string basedevicecode)
        {
            string sql = "select count(deviceid)  from devices where devicestate!=-10 and  basedevicecode='" + basedevicecode+"'";
            var ds = MySqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql);
            int us =  Convert.ToInt32(ds );
            return us;
        }

        public static List<Device> GetAllDeviceByCode(string  devicecode )
        {
            if (devicecode == null || devicecode.Trim() == "")
                return new List<Device>();

           
            string sql = string.Format("select deviceid,devicecode,devicename,devicemodel,position,devicestate,approvalstate from devices where devicecode='{0}' and devicestate!=-10 ",
                devicecode );
            DataSet ds = MySqlHelper.GetDataSet(System.Data.CommandType.Text, sql);
            List<Device> us = Dt2List.ConvertTo<Device>(ds.Tables[0]);
            return us;
        }

    }
}
