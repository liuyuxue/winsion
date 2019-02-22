
using CommonLib;
using CommonLib.Function;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
 
//using System.Windows.Controls;
using WpfAppMain;
using WpfAppMain.Db;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace XfPrint
{
    //public class MainWindowViewModel : Prism.Mvvm.BindableBase, CommonViewControl.IPage
    //{
        
    //    int pagesize = 6;
    //    System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
    //    //string EncryptKey = "04B8AED0F3FADB81F20FD5EFED55627F";
    //    String key = "7A02000085A39CA49785CAB1D16BD240C453C7772479E00080A1EC8990961142EE8E724F55670BC4";

    //    public MainWindowViewModel()
    //    {
    //        this.printDialog.UseEXDialog = true;
    //    //  key = Util.EncryptAndDecrypt.Encrypt(EncryptKey, "hlztxfwgyhb6932");
    //        InitData();
    //    }

    //    #region datas
    //    private List<Organization> _organizations = null;
    //    public List<Organization> Organizations
    //    {
    //        get { return _organizations; }
    //        set { SetProperty(ref _organizations, value); }
    //    }

    //    private List<DevType> _devTypes = null;
    //    public List<DevType> DevTypes
    //    {
    //        get { return _devTypes; }
    //        set { SetProperty(ref _devTypes, value); }
    //    }

    //    private List<BaseDev> _baseDevs = null;
    //    public List<BaseDev> BaseDevs
    //    {
    //        get { return _baseDevs; }
    //        set { SetProperty(ref _baseDevs, value); }
    //    }

    //    private List<BaseDev> _baseDevs2 = null;
    //    public List<BaseDev> BaseDevs2
    //    {
    //        get { return _baseDevs2; }
    //        set { SetProperty(ref _baseDevs2, value); }
    //    }


    //    private BaseDev _baseDevCurrent = null;
    //    public BaseDev BaseDevCurrent
    //    {
    //        get { return _baseDevCurrent; }
    //        set { SetProperty(ref _baseDevCurrent, value); }
    //    }

    //    private Organization _orgCurrent = null;
    //    public Organization OrgCurrent
    //    {
    //        get { return _orgCurrent; }
    //        set { SetProperty(ref _orgCurrent, value); }
    //    }

    //    private String _tel = null;
    //    public String Tel
    //    {
    //        get { return _tel; }
    //        set { SetProperty(ref _tel, value); }
    //    }

    //    private ObservableCollection<DeviceModel> _devmodels = new ObservableCollection<DeviceModel>();
    //    public ObservableCollection<DeviceModel> DevModels
    //    {
    //        get { return _devmodels; }
    //        set { SetProperty(ref _devmodels, value); }
    //    }

    //    private int _selectItemCount = 0;
    //    public int SelectItemCount
    //    {
    //        get { return _selectItemCount; }
    //        set { SetProperty(ref _selectItemCount, value); }
    //    }

    //    public System.Windows.Controls.ListView ListViewControl { get; set; }


    //    int pageCount = 0;
    //    public int PageCount
    //    {
    //        get
    //        {
    //            return pageCount;
    //        }
    //        set { SetProperty(ref pageCount, value); }
    //    }

    //    int currentPageIndex = 1;
    //    public int CurrentPageIndex
    //    {
    //        get
    //        {
    //            return currentPageIndex;
    //        }
    //        set { SetProperty(ref currentPageIndex, value); }
    //    }
    //    #endregion

    //    #region cmd
    //    DelegateCommand<object> selectionDevtypeChangedCommand;
    //    public DelegateCommand<object> SelectionDevtypeChangedCommand
    //    {
    //        get
    //        {
    //            return selectionDevtypeChangedCommand;
    //        }
    //    }
    //    DelegateCommand<object> selectDevDataCommand;
    //    public DelegateCommand<object> SelectDevDataCommand
    //    {
    //        get
    //        {
    //            return selectDevDataCommand;
    //        }
    //    }
    //    DelegateCommand<object> printCommand;
    //    public DelegateCommand<object> PrintCommand
    //    {
    //        get
    //        {
    //            return printCommand;
    //        }
    //    }

    //    DelegateCommand<object> selectAllItemCommand;
    //    public DelegateCommand<object> SelectAllItemCommand
    //    {
    //        get
    //        {
    //            return selectAllItemCommand;
    //        }
    //    }
    //    DelegateCommand<object> unselectAllItemCommand;
    //    public DelegateCommand<object> UnSelectAllItemCommand
    //    {
    //        get
    //        {
    //            return unselectAllItemCommand;
    //        }
    //    }
    //    DelegateCommand<object> telTextChangedCommand;
    //    public DelegateCommand<object> TelTextChangedCommand
    //    {
    //        get
    //        {
    //            return telTextChangedCommand;
    //        }
    //    }


    //    public DelegateCommand FirstPageCmd { get; set; }

    //    public DelegateCommand LastPageCmd { get; set; }

    //    public DelegateCommand DownPageCmd { get; set; }

    //    public DelegateCommand UpPageCmd { get; set; }

    //    public DelegateCommand<object> GoToPageCmd { get; set; }

    //    #endregion

    //    void InitData()
    //    {
    //        try
    //        {
    //            selectionDevtypeChangedCommand = new DelegateCommand<object>(SelectionDevtypeChanged);
    //            selectDevDataCommand = new DelegateCommand<object>(SelectDevData);
    //            printCommand = new DelegateCommand<object>(PrintData);
    //            unselectAllItemCommand = new DelegateCommand<object>(UnselectAllItem);
    //            selectAllItemCommand = new DelegateCommand<object>(SelectAllItem);
    //            telTextChangedCommand = new DelegateCommand<object>(TelTextChanged);

    //            FirstPageCmd = new DelegateCommand(GotoFirstPage);
    //            LastPageCmd = new DelegateCommand(GotoLastPage);
    //            UpPageCmd = new DelegateCommand(GotoPrePage);
    //            DownPageCmd = new DelegateCommand(GotoNextPage);
    //            GoToPageCmd = new DelegateCommand<object>(GotoThePage);

    //            Task.Factory.StartNew(() =>
    //            {
    //                try
    //                {
    //                    Organizations = DbBiz.GetAllOrganization();
    //                    DevTypes = DbBiz.GetAllDevType();
    //                    BaseDevs = DbBiz.GetAllBaseDev();

    //                    if (Organizations == null || Organizations.Count == 0)
    //                        OrgCurrent = null;
    //                    else
    //                        OrgCurrent = Organizations[0];
    //                }
    //                catch (Exception ex)
    //                {
    //                    MessageBox.Show("2:" + ex.Message);
    //                }

    //            });

    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("1:" + ex.Message);
    //        }
    //    }

    //    void SelectionDevtypeChanged(object obj)
    //    {
    //        try
    //        {
    //            DevType dtype = obj as DevType;
    //            if (dtype == null || BaseDevs==null)
    //                return;
    //            BaseDevs2 = BaseDevs.Where(t => t.devicetypeid == dtype.devicetypeid).ToList();
    //            if (BaseDevs2 == null || BaseDevs2.Count == 0)
    //                BaseDevCurrent = null;
    //            else
    //                BaseDevCurrent = BaseDevs2[0];
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("3:" + ex.StackTrace);
    //        }
    //    }

    //    void SelectDevData(object obj)
    //    {
    //        if (BaseDevCurrent == null)
    //            return;
    //        if (OrgCurrent == null)
    //            return;
    //        Task.Factory.StartNew(() =>
    //        {
    //            int tmpPageIndex = 1;
    //            if (obj != null)
    //                tmpPageIndex = Convert.ToInt32(obj);

    //            var allrowcount = DbBiz.GetAllDeviceCount(BaseDevCurrent.basedevicecode);
    //            var pagecount = allrowcount / pagesize;
    //            if ((allrowcount % pagesize) != 0)
    //                pagecount++;
    //            PageCount = pagecount;

    //            var datas = DbBiz.GetAllDevice(BaseDevCurrent.basedevicecode, tmpPageIndex, pagesize);
    //            CurrentPageIndex = tmpPageIndex;

    //            App.Current.Dispatcher.Invoke(() =>
    //            {
    //                DevModels.Clear();
    //                foreach (var data in datas)
    //                {
    //                    DeviceModel model = new DeviceModel();
    //                    model.devicecode = data.devicecode;
    //                    model.deviceid = data.deviceid;
    //                    model.devicename = BaseDevCurrent.devicename;
    //                    model.proprietor = OrgCurrent.organizationname;
    //                    model.tel = Tel;
    //                    model.ItemClickCommand = new DelegateCommand<object>(ItemClickFun);
    //                    DevModels.Add(model);

    //                    try
    //                    {
    //                        if (model.devicecode != null && model.devicecode.Trim() != "")
    //                        {
    //                            string code2 = Util.EncryptAndDecrypt.Encrypt(model.devicecode, key);

    //                            System.Drawing.Bitmap b = GenerateQR(200, 200, model.devicecode);
    //                            //   System.Drawing.Bitmap b = GenerateQR(200, 200, code2);
    //                            string code3 = Util.EncryptAndDecrypt.Decrypt(code2, key);
    //                            MemoryStream ms = new MemoryStream();
    //                            b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
    //                            byte[] bytes = ms.GetBuffer();
    //                            ms.Close();
    //                            model.devcodeBytes = bytes;
    //                        }
    //                    }
    //                    catch (Exception ex)
    //                    {
    //                    }

    //                }
    //            });

    //        });

    //    }

    //    void UnselectAllItem(object obj)
    //    {
    //        foreach (var data in DevModels)
    //            data.check = false;
    //        SelectItemCount = DevModels.Where(t => t.check == true).Count();
    //    }

    //    void SelectAllItem(object obj)
    //    {
    //        foreach (var data in DevModels)
    //            data.check = true;
    //        SelectItemCount = DevModels.Where(t => t.check == true).Count();
    //    }

    //    void TelTextChanged(object obj)
    //    {
    //        foreach (var data in DevModels)
    //            data.tel = Tel;
    //    }

    //    void PrintData(object obj)
    //    {
    //        try
    //        {
    //            string dir2 = System.IO.Directory.GetCurrentDirectory() + "\\imgs\\";
    //            if (Directory.Exists(dir2))
    //            {
    //                foreach (string d in Directory.GetFileSystemEntries(dir2))
    //                {
    //                    if (File.Exists(d))
    //                    {
    //                        FileInfo fi = new FileInfo(d);
    //                        File.Delete(d);//直接删除其中的文件  
    //                    }
    //                }
    //            }
    //        }
    //        catch { }


    //        var girds = CommonTools.GetChildObjects<System.Windows.Controls.Grid>(this.ListViewControl, "grid_print");
    //        bool flag = false;
    //        foreach (var g in girds)
    //        {
    //            if (g.DataContext is DeviceModel && (g.DataContext as DeviceModel).check == true)
    //            {
    //                flag = true;
    //                break;
    //            }
    //        }
    //        if (!flag)
    //            return;

    //        this.printDialog.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
    //        if (this.printDialog.ShowDialog().Equals(System.Windows.Forms.DialogResult.OK))
    //        {
    //            try
    //            {
    //                foreach (var grid in girds)
    //                {
    //                    if (grid.DataContext is DeviceModel)
    //                    {
    //                        if ((grid.DataContext as DeviceModel).check)
    //                        {
    //                            string dir = System.IO.Directory.GetCurrentDirectory() + "\\imgs\\";
    //                            if (!Directory.Exists(dir))
    //                                Directory.CreateDirectory(dir);
    //                            string filename = dir + Guid.NewGuid().ToString() + ".jpg";
    //                            var width = (int)grid.ActualWidth;
    //                            var height = (int)grid.ActualHeight;

    //                            var bitmapsource = CommonTools.RenderVisaulToBitmap(grid, (int)width, (int)height);
    //                            CommonTools.GenerateImage(bitmapsource, filename);

    //                            //byte[] bs = File.ReadAllBytes(filename);
    //                            //System.Drawing.Bitmap img = CommonTools.Bytes2Bitmap(bs);

    //                            System.Drawing.Image original = this.GraphicsQrCode(grid.DataContext as DeviceModel);
    //                            System.Drawing.Bitmap img = new System.Drawing.Bitmap(original);

    //                            string str = this.ConvertImageToCode(img);
    //                            int num = ((width / 8) + (((width % 8) == 0) ? 0 : 1)) * height;
    //                            string str2 = ((int)num).ToString();
    //                            string str3 = ((width / 8) + (((width % 8) == 0) ? 0 : 1)).ToString();

    //                            string str4 = string.Format("~DGR:imgName.GRF,{0},{1},{2}^FS", str2, str3, str);
    //                            StringBuilder builder = new StringBuilder();
    //                            builder.Append(str4);
    //                            builder.Append("^XA");
    //                            builder.Append("^LH0,0");
    //                            builder.Append("^FO30,5");
    //                            builder.Append("^XGR:imgName.GRF,1,1^FS");
    //                            builder.Append("^XZ");

    //                            Util.RawPrinterHelper.SendStringToPrinter(this.printDialog.PrinterSettings.PrinterName, builder.ToString());
    //                        }
    //                    }
    //                }
    //                System.Windows.MessageBox.Show("完毕!");
    //            }
    //            catch (Exception ex)
    //            {
    //                System.Windows.MessageBox.Show(ex.Message);
    //            }
    //        }

    //    }


         

    //    private System.Drawing.Image GraphicsQrCode(DeviceModel temp)
    //    {
    //        System.Drawing.Image image = System.Drawing.Image.FromFile("platform.png").Clone() as System.Drawing.Image;
    //        System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(image);
    //        System.Drawing.Bitmap bitmap = this.GenerateQR(0xd5, 0xd5, temp.devicecode);
    //        graphics.FillRectangle(System.Drawing.Brushes.White, 11, 11, 0xd5, 0xd5);
    //        graphics.DrawImage(bitmap, 11, 11, 0xd5, 0xd5);
    //        System.Drawing.Font font = new System.Drawing.Font("黑体", 7f);
    //        System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0));
    //        System.Drawing.StringFormat format = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoWrap)
    //        {
    //            LineAlignment = System.Drawing.StringAlignment.Center,
    //            Alignment = System.Drawing.StringAlignment.Center
    //        };
    //        string s = "消防设施维护管理标签";
    //        int num = 0x2d;
    //        graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(240f, 25f, 340f, (float)num), format);
    //        s = temp.devicename;
    //        font = new System.Drawing.Font("仿宋", (s.Length > 14) ? ((float)4) : ((s.Length > 11) ? ((float)5) : ((float)6)));
    //        graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(240f, 60f, 340f, (float)num), format);
    //        s = temp.devicecode;
    //        font = new System.Drawing.Font("仿宋", 6f);
    //        graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(195f, 90f, 440f, (float)num), format);
    //        s = temp.proprietor;
    //        font = new System.Drawing.Font("宋体", (s.Length > 12) ? ((float)5) : ((float)6));
    //        if (s.Length > 15)
    //        {
    //            graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(240f, 125f, 340f, (float)(10 + num)), format);
    //        }
    //        else
    //        {
    //            graphics.DrawString(s, font, brush, new System.Drawing.RectangleF(240f, 135f, 340f, (float)num), format);
    //        }
    //        font = new System.Drawing.Font("黑体", 7f);
    //        graphics.DrawString("电话：" + temp.tel, font, brush, new System.Drawing.RectangleF(240f, 170f, 340f, (float)num), format);
    //        return image;
    //    }

    //    void ItemClickFun(object obj)
    //    {
    //        SelectItemCount = DevModels.Where(t => t.check == true).Count();
    //    }

    //    private System.Drawing.Bitmap GenerateQR(int width, int height, string text)
    //    {
    //        BarcodeWriter writer = new BarcodeWriter();
    //        EncodingOptions options = new EncodingOptions
    //        {
    //            Width = width,
    //            Height = height,
    //            Margin = 0,
    //            PureBarcode = false
    //        };
    //        options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
    //        options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
    //        writer.Renderer = new BitmapRenderer();
    //        writer.Options = options;
    //        writer.Format = BarcodeFormat.QR_CODE;
    //        System.Drawing.Bitmap image = writer.Write(text);
    //        System.Drawing.Bitmap bitmap2 = new System.Drawing.Bitmap(System.Drawing.Image.FromFile("logo.png"), 0x55, 0x55);
    //        int num = image.Height - bitmap2.Height;
    //        int num2 = image.Width - bitmap2.Width;
    //        System.Drawing.Graphics.FromImage(image).DrawImage(bitmap2, new System.Drawing.Point(num2 / 2, num / 2));
    //        return image;
    //    }


    //    private string ConvertImageToCode(System.Drawing.Bitmap img)
    //    {
    //        StringBuilder builder = new StringBuilder();
    //        long num2 = 0L;
    //        int num3 = 0;
    //        for (int i = 0; i < img.Size.Height; i++)
    //        {
    //            for (int j = 0; j < img.Size.Width; j++)
    //            {
    //                num3 *= 2;
    //                string str = ((long)img.GetPixel(j, i).ToArgb()).ToString("X");
    //                if (str.Substring(str.Length - 6, 6).CompareTo("BBBBBB") < 0)
    //                {
    //                    num3++;
    //                }
    //                num2 += 1L;
    //                if ((j == (img.Size.Width - 1)) && (num2 < 8L))
    //                {
    //                    num3 *= 2 ^ (8 - ((int)num2));
    //                    builder.Append(num3.ToString("X").PadLeft(2, '0'));
    //                    num3 = 0;
    //                    num2 = 0L;
    //                }
    //                if (num2 >= 8L)
    //                {
    //                    builder.Append(num3.ToString("X").PadLeft(2, '0'));
    //                    num3 = 0;
    //                    num2 = 0L;
    //                }
    //            }
    //            builder.Append(Environment.NewLine);
    //        }
    //        return builder.ToString();
    //    }

    //    #region 分页
    //    void GotoFirstPage()
    //    {
    //        if (CurrentPageIndex != 1)
    //        {
    //            SelectDevData(1);
    //        }
    //    }
    //    void GotoLastPage()
    //    {
    //        if (CurrentPageIndex != PageCount)
    //        {
    //            SelectDevData(PageCount);
    //        }

    //    }
    //    void GotoNextPage()
    //    {
    //        if (CurrentPageIndex != PageCount)
    //        {
    //            SelectDevData(CurrentPageIndex + 1);
    //        }

    //    }
    //    void GotoPrePage()
    //    {
    //        if (CurrentPageIndex != 1)
    //        {
    //            SelectDevData(CurrentPageIndex - 1);
    //        }
    //    }

    //    void GotoThePage(object index)
    //    {
    //        try
    //        {
    //            int tmp = Convert.ToInt32(index);
    //            if (tmp > 0 && tmp <= PageCount)
    //                SelectDevData(tmp);
    //        }
    //        catch { }
    //    }
    //    #endregion








    //}












     
}
