using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMain.Db;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace XfPrint
{
 
    public class TabAreaViewModel : Prism.Mvvm.BindableBase 
    {

        
      
        String key = "7A020000";

        public TabAreaViewModel()
        {
            
            InitData();
        }

        #region datas
         
        
        

        private String _devcode = null;
        public String Devcode
        {
            get { return _devcode; }
            set { SetProperty(ref _devcode, value); }
        }

        private ObservableCollection<DeviceModel> _devmodels = new ObservableCollection<DeviceModel>();
        public ObservableCollection<DeviceModel> DevModels
        {
            get { return _devmodels; }
            set { SetProperty(ref _devmodels, value); }
        }

        


       
        #endregion

        #region cmd
       
        DelegateCommand<object> selectDevDataCommand;
        public DelegateCommand<object> SelectDevDataCommand
        {
            get
            {
                return selectDevDataCommand;
            }
        }
        
       


       

        #endregion

        void InitData()
        {
            try
            {
               
                selectDevDataCommand = new DelegateCommand<object>(SelectDevData);
               

               

                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                        //  string s34 = ex.Message;
                        //  MessageBox.Show("2:" + ex.StackTrace);
                    }

                });

            }
            catch (Exception ex)
            {
                // MessageBox.Show("1:" + ex.Message);
            }
        }

         

        void SelectDevData(object obj)
        {
           
            Task.Factory.StartNew(() =>
            {
                 
                var devs = DbBiz.GetAllDeviceByCode(Devcode);
                
                

                App.Current.Dispatcher.Invoke(() =>
                {
                    DevModels.Clear();
                    foreach (var data in devs)
                    {
                        DeviceModel model = new DeviceModel();
                        model.devicecode = data.devicecode;
                        model.deviceid = data.deviceid;
                        model.devicename = data.devicename;
                        model.tel = "第"+ (devs.IndexOf(data)+1)+"个";
                      //  model.tel = Tel;
                       // model.ItemClickCommand = new DelegateCommand<object>(ItemClickFun);
                        DevModels.Add(model);
                       
                        try
                        {
                            if (model.devicecode != null && model.devicecode.Trim() != "")
                            {
                                string code2 = Util.EncryptAndDecrypt.Encrypt(model.devicecode, key);
                                //   string code3 = Util.EncryptAndDecrypt.Decrypt(code2, key);
                                System.Drawing.Bitmap b = GenerateQR(0xd5, 0xd5, code2);
                                model.jiamistr = code2;
                                MemoryStream ms = new MemoryStream();
                                b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                byte[] bytes = ms.GetBuffer();
                                ms.Close();
                                model.erweimaBytes = bytes;
                            }
                        }
                        catch (Exception ex)
                        {
                        }

                    }
                });

            });

        }














        #region  打印条码用到的辅助函数
        private System.Drawing.Bitmap GenerateQR(int width, int height, string text)
        {
            BarcodeWriter writer = new BarcodeWriter();
            EncodingOptions options = new EncodingOptions
            {
                Width = width,
                Height = height,
                Margin = 0,
                PureBarcode = false
            };
            options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            writer.Renderer = new BitmapRenderer();
            writer.Options = options;
            writer.Format = BarcodeFormat.QR_CODE;
            System.Drawing.Bitmap image = writer.Write(text);
            System.Drawing.Bitmap bitmap2 = new System.Drawing.Bitmap(System.Drawing.Image.FromFile("logo.png"), 0x44, 0x44);
            int num = image.Height - bitmap2.Height;
            int num2 = image.Width - bitmap2.Width;
            System.Drawing.Graphics.FromImage(image).DrawImage(bitmap2, new System.Drawing.Point(num2 / 2, num / 2));
            return image;
        }
        private System.Drawing.Image GraphicsQrCode(DeviceModel temp)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile("platform.png").Clone() as System.Drawing.Image;
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(image);
            //    System.Drawing.Bitmap bitmap = this.GenerateQR(0xd5, 0xd5, temp.devicecode);
            System.Drawing.Bitmap bitmap = this.GenerateQR(0xd5, 0xd5, temp.jiamistr);
            graphics.FillRectangle(System.Drawing.Brushes.White, 11, 11, 0xd5, 0xd5);
            graphics.DrawImage(bitmap, 11, 11, 0xd5, 0xd5);
            System.Drawing.Font font = new System.Drawing.Font("黑体", 7f);
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0));
            System.Drawing.StringFormat format = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoWrap)
            {
                LineAlignment = System.Drawing.StringAlignment.Center,
                Alignment = System.Drawing.StringAlignment.Center
            };
            string s = "消防设施维护管理标签";
            int num = 0x2d;
            graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(240f, 25f, 340f, (float)num), format);
            s = temp.devicename;
            font = new System.Drawing.Font("仿宋", (s.Length > 14) ? ((float)4) : ((s.Length > 11) ? ((float)5) : ((float)6)));
            graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(240f, 60f, 340f, (float)num), format);
            s = temp.devicecode;

            font = new System.Drawing.Font("仿宋", 6f);
            graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(195f, 90f, 440f, (float)num), format);
            s = temp.proprietor;
            font = new System.Drawing.Font("宋体", (s.Length > 12) ? ((float)5) : ((float)6));
            if (s.Length > 15)
            {
                graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(240f, 125f, 340f, (float)(10 + num)), format);
            }
            else
            {
                graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(240f, 135f, 340f, (float)num), format);
            }
            font = new System.Drawing.Font("黑体", 7f);
            graphics.DrawString("电话：" + temp.tel, font, brush, new System.Drawing.RectangleF(240f, 170f, 340f, (float)num), format);
            return image;
        }
        private string ConvertImageToCode(System.Drawing.Bitmap img)
        {
            StringBuilder builder = new StringBuilder();
            long num2 = 0L;
            int num3 = 0;
            for (int i = 0; i < img.Size.Height; i++)
            {
                for (int j = 0; j < img.Size.Width; j++)
                {
                    num3 *= 2;
                    string str = ((long)img.GetPixel(j, i).ToArgb()).ToString("X");
                    if (str.Substring(str.Length - 6, 6).CompareTo("BBBBBB") < 0)
                    {
                        num3++;
                    }
                    num2 += 1L;
                    if ((j == (img.Size.Width - 1)) && (num2 < 8L))
                    {
                        num3 *= 2 ^ (8 - ((int)num2));
                        builder.Append(num3.ToString("X").PadLeft(2, '0'));
                        num3 = 0;
                        num2 = 0L;
                    }
                    if (num2 >= 8L)
                    {
                        builder.Append(num3.ToString("X").PadLeft(2, '0'));
                        num3 = 0;
                        num2 = 0L;
                    }
                }
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }

        #endregion





    }
}
