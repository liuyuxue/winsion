using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4netHelp.config", Watch = true)]
namespace CommonLib.Function
{
    public class CommonTools
    {
        /// <summary>
        /// 查找父控件
        /// </summary>
        /// <typeparam name="T">父控件的类型</typeparam>
        /// <param name="obj">要找的是obj的父控件</param>
        /// <param name="name">想找的父控件的Name属性</param>
        /// <returns>目标父控件</returns>
        public static T GetParentObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);

            while (parent != null)
            {
                if (parent is T && (((T)parent).Name == name | string.IsNullOrEmpty(name)))
                {
                    return (T)parent;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }


        /// <summary>
        /// 查找子控件
        /// </summary>
        /// <typeparam name="T">子控件的类型</typeparam>
        /// <param name="obj">要找的是obj的子控件</param>
        /// <param name="name">想找的子控件的Name属性</param>
        /// <returns>目标子控件</returns>
        public static T GetChildObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject child = null;
            T grandChild = null;

            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);

                if (child is T && (((T)child).Name == name | string.IsNullOrEmpty(name)))
                {
                    return (T)child;
                }
                else
                {
                    grandChild = GetChildObject<T>(child, name);
                    if (grandChild != null)
                        return grandChild;
                }
            }
            return null;


        }

        public static List<T> GetChildObjects<T>(DependencyObject obj, string controlname) where T : FrameworkElement
        {
            DependencyObject child = null;
            List<T> childList = new List<T>();

            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);

                if (child is T && (((T)child).Name == controlname | string.IsNullOrEmpty(controlname)))
                {
                    childList.Add((T)child);
                }
                childList.AddRange(GetChildObjects<T>(child, controlname));
            }
            return childList;
        }


        /// <summary>
        /// 深度克隆对象
        /// </summary>
        public static T CloneObject<T>(object o)
        {
            if (o == null)
                return default(T);
            Type newT = typeof(T);
            Type t = o.GetType();
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            System.Reflection.PropertyInfo[] properties2 = newT.GetProperties();
            Object p = newT.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, o, null);
            foreach (System.Reflection.PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    foreach (System.Reflection.PropertyInfo pi2 in properties2)
                    {
                        if (pi2.ToString() == pi.ToString())
                        {
                            object value = pi.GetValue(o, null);
                            pi2.SetValue(p, value, null);
                        }
                    }
                }
            }
            return (T)p;
        }


        public static T DeserializeObject<T>(string json)
        {

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        public static string SerializeObject(object obj)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return json;
        }

        public static System.Windows.Media.Imaging.RenderTargetBitmap RenderVisaulToBitmap(Visual vsual, int width, int height)
        {
            var rtb = new System.Windows.Media.Imaging.RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            rtb.Render(vsual);
            return rtb;
        }

        public static void GenerateImage(System.Windows.Media.Imaging.BitmapSource bitmap, string jpgFilename)
        {
            System.IO.Stream destStream = System.IO.File.Create(jpgFilename);
            System.Windows.Media.Imaging.BitmapEncoder encoder = null;
            encoder = new System.Windows.Media.Imaging.JpegBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bitmap));
            encoder.Save(destStream);
            destStream.Close();
        }

        public byte[] StreamToBytes(System.IO.Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            return bytes;

        }

        /// 将 byte[] 转成 Stream
        public System.IO.Stream BytesToStream(byte[] bytes)
        {
            System.IO.Stream stream = new System.IO.MemoryStream(bytes);
            return stream;

        }



        //将 Stream 写入文件 
        public static void StreamToFile(Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[] 
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始 
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            // 把 byte[] 写入文件 
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        //从文件读取 Stream

        public static Stream FileToStream(string fileName)
        {
            // 打开文件 
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[] 
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // 把 byte[] 转换成 Stream 
            Stream stream = new MemoryStream(bytes);
            return stream;

        }

        public static byte[] BitmapImageToByteArray(System.Windows.Media.Imaging.BitmapSource bitmapSource)
        {
            System.Windows.Media.Imaging.JpegBitmapEncoder encoder = new System.Windows.Media.Imaging.JpegBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            encoder.QualityLevel = 100;
            // byte[] bit = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bitmapSource));
                encoder.Save(stream);
                byte[] bit = stream.ToArray();
                stream.Close();
                return bit;
            }
        }

        public static System.Drawing.Bitmap Bytes2Bitmap(byte[] bytelist)
        {
            MemoryStream ms1 = new MemoryStream(bytelist);
            System.Drawing.Bitmap bm = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(ms1);
            ms1.Close();
            return bm;
        }

    }
}
