using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using TextBox = System.Windows.Controls.TextBox;
using ListViewItem = System.Windows.Controls.ListViewItem;
using System.Collections.ObjectModel;
using MessageBox = System.Windows.MessageBox;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;

namespace Batch_Rename
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            
            InitializeComponent();
            ReadPreset();          
        }

        /*public ObservableCollection<FileSelected> fileSelecteds = new ObservableCollection<FileSelected>();
        List<FolderSelected> folderSelecteds = new List<FolderSelected>(); //danh sách chứa folder
        List<Method> methods = new List<Method>(); //danh sách chứa các method
        public ObservableCollection<string> presets = new ObservableCollection<string>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListFileSelected.ItemsSource = fileSelecteds;
            ListFolderSelected.ItemsSource = folderSelecteds;
          ListViewMethod.ItemsSource = methods;}*/


        //Hàm đọc các tập phương thức ra combobox
        private void ReadPreset()
        {                     
            string relativePath = "..\\..\\..\\Batch Methods\\";
            string path = Path.GetFullPath(relativePath);
            string[] files = Directory.GetFiles(path, "*.brn");

            foreach (string file in files)
            {
                ComboboxPreset.Items.Add(Path.GetFileNameWithoutExtension(file));
            }           
        }

        //Hàm cài đặt buttton refresh
        private void bnt_Refresh_Click(object sender, RoutedEventArgs e)
        {
            RemoveItemCombobox();  
            ReadPreset();
        }

        //Hàm xóa các item trong combobox
        private void RemoveItemCombobox()
        {
            while (ComboboxPreset.Items.Count > 0)
            {
                ComboboxPreset.Items.RemoveAt(0);
            }
        }

        //Hàm xử lý sự kiện khi một item trong combobox được chọn
        private void ComboboxPreset_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //xóa danh sách phương thức
            while (ListViewMethod.Items.Count > 0)
            {
                ListViewMethod.Items.RemoveAt(0);
            }

            //đọc tập phương thức mới
            string name = ComboboxPreset.SelectedItem as string;
            if (name != null)
            {
                string relativePath = "..\\..\\..\\Batch Methods\\" + name + ".brn";
                string path = Path.GetFullPath(relativePath);
                ReadFile(path);
            }
           
        }       

        // Hàm xử lý sự kiện click button chọn file
        private void Files_Click(object sender, RoutedEventArgs e)
        {
            //mở hộp thoại dialog
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All file (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                //đọc file vào danh sách
                foreach (string filename in openFileDialog.FileNames)
                {
                    ListFileSelected.Items.Add(new FileSelected()
                    {
                        Filename = Path.GetFileName(filename),
                        Newname = Path.GetFileNameWithoutExtension(filename),
                        Oldname = Path.GetFileNameWithoutExtension(filename),
                        Path = filename,
                        Error = " ",
                        IsGroovy = true,
                        Extension = Path.GetExtension(filename)

                    });
                }
            }
        }


        // Hàm xử lý sự kiện click button chọn tất cả file trong một thư mục
        private void Directories_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            browserDialog.ShowNewFolderButton = false;
            browserDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sPath = browserDialog.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(sPath);
                if (directoryInfo.Exists)
                {
                    foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                    {
                        ListFileSelected.Items.Add(new FileSelected()
                        {
                            Filename = Path.GetFileName(fileInfo.Name),
                            Newname = Path.GetFileNameWithoutExtension(fileInfo.Name),
                            Oldname = Path.GetFileNameWithoutExtension(fileInfo.Name),
                            Path = fileInfo.FullName,
                            Error = " ",
                            IsGroovy = true,
                            Extension = Path.GetExtension(fileInfo.Name)
                        });
                    }
                }
            }
        }

        // Hàm xử lý sự kiện click button chọn thư mục
        private void Directories1_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            browserDialog.ShowNewFolderButton = false;
            browserDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sPath = browserDialog.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(sPath);
                ListFolderSelected.Items.Add(new FolderSelected()
                {
                    Foldername = directoryInfo.Name,
                    NewFoldername = directoryInfo.Name,
                    Oldname= directoryInfo.Name,
                    PathFolder = directoryInfo.FullName,
                    ErrorFolder = " ",
                    IsGroovyDir = true
                });

            }
        }

        // Hàm xử lý sự kiện click button chọn tất cả thư mục trong một thư mục lớn hơn
        private void SubDirectories_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            browserDialog.ShowNewFolderButton = false;
            browserDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sPath = browserDialog.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(sPath);
                if (directoryInfo.Exists)
                {
                    foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                    {
                        ListFolderSelected.Items.Add(new FolderSelected()
                        {
                            Foldername = directory.Name,
                            NewFoldername = directory.Name,
                            Oldname = directoryInfo.Name,
                            PathFolder = directory.FullName,
                            ErrorFolder = " ",
                            IsGroovyDir = true
                        });
                    }
                }
            }

        }


        //hàm xử lý lưu các tập phương thức của người dùng
        private void SavePresets()
        {

            string relativePath = "..\\..\\..\\Batch Methods\\"; //lưu tệp vào thư mục Batch Methods
            string path = Path.GetFullPath(relativePath);

            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.InitialDirectory = path;
            saveFileDialog.Filter = "Batch Rename file (*.brn)|*.brn";
           
            if(saveFileDialog.ShowDialog()==true)
            {

                FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                using (StreamWriter streamWriter=new StreamWriter(file))
                {
                    try
                    {                       
                         foreach (Method method in ListViewMethod.Items)
                        {
                            //ghi phương thức vào tệp
                            streamWriter.WriteLine(string.Format("{0}, {1}",method.NameMethod, method.IsCheckMethod));
                        }
                        streamWriter.Close();
                    }
                    catch(Exception msg)
                    {
                        MessageBox.Show("" + msg);
                    }
                    finally
                    {
                        file.Close();
                    }
                }
            }

        }


        //Hàm đọc các phương thức ra từ một tệp đã lưu trong thư mục Batch Methods
        private void ReadFile(string namefile)
        {
            FileStream file = new FileStream(namefile, FileMode.Open, FileAccess.Read);
            if (file.CanRead)
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader(file))
                    {
                        string Line;
                        string[] Token;
                        while (!streamReader.EndOfStream)
                        {

                            Line = streamReader.ReadLine();
                            Token = Line.Split(',');
                            Method method = new Method();

                            switch (Token[0])
                            {
                                case "New name":
                                    method.NameMethod = "New name";
                                    var page = new NewNameFrame();
                                    page.textBlockMouseDown += NewNameOperation;
                                    method.PageMethod = page;
                                    break;

                                case "New case":
                                    method.NameMethod = "New case";
                                    var page1 = new NewCaseFrame();
                                    page1.RadioButtonChanged += NewCaseOperation;
                                    method.PageMethod = page1;
                                    break;

                                case "Move":
                                    method.NameMethod = "Move";
                                    var page2 = new MoveFrame();
                                    page2.DataChanged += MoveOperation;
                                    method.PageMethod = page2;
                                    break;

                                case "Remove":
                                    method.NameMethod = "Remove";
                                    var page3 = new RemoveFrame();
                                    page3.RemoveChanged += RemoveOperation;
                                    method.PageMethod = page3;
                                    break;

                                case "Replace":
                                    method.NameMethod = "Replace";
                                    var page4 = new ReplaceFrame();
                                    page4.TextBoxChanged += ReplaceOperation;
                                    method.PageMethod = page4;
                                    break;

                                case "Trim":
                                    method.NameMethod = "Trim";
                                    var page5 = new TrimFrame();
                                    page5.TrimStringChanged += TrimOperation;
                                    method.PageMethod = page5;
                                    break;
                                case "Extension":
                                    method.NameMethod = "Extension";
                                    var page6 = new ExtensionFrame();
                                    page6.DataChanged += ExtensionOperation;
                                    method.PageMethod = page6;
                                    break;
                                default:
                                    break;
                            }
                            method.IsCheckMethod = Convert.ToBoolean(Token[1]);

                            ListViewMethod.Items.Add(method);

                        }

                        streamReader.Close();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("" + exc);
                }
                finally
                {
                    file.Close();
                }
            }
            else
            {
                MessageBox.Show("Can't read this file");
            }
        }


        //hàm xử lý chọn các tập phương thức đã lưu của người dùng
        private void OpenPresets()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            path = System.IO.Path.GetDirectoryName(path);
            path = path + @"\Batch Rename\Batch Methods";

            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "Batch Rename file (*.brn)|*.brn";            
           
            if (openFileDialog.ShowDialog() == true)
            {
                ReadFile(openFileDialog.FileName);
            }
                    

        }


        //hàm xử lý button mở các tập phương thức 
        private void bnt_AddPreset_Click(object sender, RoutedEventArgs e)
        {
             OpenPresets();
        }

        //hàm xử lý button lưu các tập phương thức
        private void bnt_SavePreset_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.Items.Count != -1)
            {
                SavePresets();
            }
            
        }

        //-------------- Các hàm xử lý sự kiện click nhóm button di chuyển file trong list----------------------------
        //hàm xử lý sự kiện click button  di chuyển file lên đầu danh sách
        private void bnt_MoveFirstFile_Click(object sender, RoutedEventArgs e)
        {
            if (ListFileSelected.SelectedIndex > 0)
            {
                var item = (FileSelected)ListFileSelected.SelectedItem;
                var index = ListFileSelected.SelectedIndex;
                ListFileSelected.Items.RemoveAt(index);
                ListFileSelected.Items.Insert(0, item);
                ListFileSelected.SelectedItem = ListFileSelected.Items[0];
            }
        }

        //hàm xử lý sự kiện click button di chuyển file lên trên file trước file được chọn
        private void bnt_MoveUpFile_Click(object sender, RoutedEventArgs e)
        {
            if (ListFileSelected.SelectedIndex > 0 )
            {
                var item = (FileSelected)ListFileSelected.SelectedItem;
                var index = ListFileSelected.SelectedIndex;
                ListFileSelected.Items.RemoveAt(index);
                ListFileSelected.Items.Insert(index - 1, item);
                ListFileSelected.SelectedItem = ListFileSelected.Items[index-1];
            }
        }

        //hàm xử lý sự kiện click button di chuyển file xuống dưới file sau file được chọn
        private void bnt_MoveDownFile_Click(object sender, RoutedEventArgs e)
        {
            if (ListFileSelected.SelectedIndex >= 0 && ListFileSelected.SelectedIndex < ListFileSelected.Items.Count-1)
            {

                var item = (FileSelected)ListFileSelected.SelectedItem;
                var index = ListFileSelected.SelectedIndex;
                ListFileSelected.Items.RemoveAt(index);
                ListFileSelected.Items.Insert(index + 1, item);
                ListFileSelected.SelectedItem = ListFileSelected.Items[index + 1];
            }
        }

        //hàm xử lý sự kiện click button di chuyển file về cuối danh sách
        private void bnt_MoveLastFile_Click(object sender, RoutedEventArgs e)
        {
            if (ListFileSelected.SelectedIndex >=0 && ListFileSelected.SelectedIndex < ListFileSelected.Items.Count)
            {

                var item = (FileSelected)ListFileSelected.SelectedItem;
                var index = ListFileSelected.SelectedIndex;
                ListFileSelected.Items.RemoveAt(index);
                ListFileSelected.Items.Insert(ListFileSelected.Items.Count, item);
                ListFileSelected.SelectedItem = ListFileSelected.Items[ListFileSelected.Items.Count-1];

            }
        }

        //----------------------------------------------------------------------------------------------------------

        //-------------- Các hàm xử lý sự kiện click nhóm button di chuyển folder trong list----------------------------
        //hàm xử lý sự kiện click button  di chuyển folder lên đầu danh sách
        private void bnt_MoveFirstFolder_Click(object sender, RoutedEventArgs e)
        {
            if (ListFolderSelected.SelectedIndex >0)
            {

                var item = (FolderSelected)ListFolderSelected.SelectedItem;
                var index = ListFolderSelected.SelectedIndex;
                ListFolderSelected.Items.RemoveAt(index);
                ListFolderSelected.Items.Insert(0, item);
                ListFolderSelected.SelectedItem = ListFolderSelected.Items[0];
            }
        }
        private void bnt_MoveUpFolder_Click(object sender, RoutedEventArgs e)
        {
            if (ListFolderSelected.SelectedIndex >0)
            {
                var item = (FolderSelected)ListFolderSelected.SelectedItem;
                var index = ListFolderSelected.SelectedIndex;
                ListFolderSelected.Items.RemoveAt(index);
                ListFolderSelected.Items.Insert(index - 1, item);
                ListFolderSelected.SelectedItem = ListFolderSelected.Items[index-1];
            }
        }

        private void bnt_MoveDownFolder_Click(object sender, RoutedEventArgs e)
        {
            if (ListFolderSelected.SelectedIndex >= 0 && ListFolderSelected.SelectedIndex < ListFolderSelected.Items.Count-1)
            {
                var item = (FolderSelected)ListFolderSelected.SelectedItem;
                var index = ListFolderSelected.SelectedIndex;
                ListFolderSelected.Items.RemoveAt(index);
                ListFolderSelected.Items.Insert(index + 1, item);
                ListFolderSelected.SelectedItem = ListFolderSelected.Items[index+1];
            }
        }

        private void bnt_MoveLastFolder_Click(object sender, RoutedEventArgs e)
        {
            if (ListFolderSelected.SelectedIndex >=0 && ListFolderSelected.SelectedIndex < ListFolderSelected.Items.Count)
            {
                var item = (FolderSelected)ListFolderSelected.SelectedItem;
                var index = ListFolderSelected.SelectedIndex;
                ListFolderSelected.Items.RemoveAt(index);
                ListFolderSelected.Items.Insert(ListFolderSelected.Items.Count, item);
                ListFolderSelected.SelectedItem = ListFolderSelected.Items[ListFolderSelected.Items.Count-1];
            }
        }


        //----------------------------------Nhóm hàm xử lý các button di chuyển phương thức-------------------------------
        private void bnt_First_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.SelectedIndex > 0)
            {

                var item = ListViewMethod.SelectedItem as Method;
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
                ListViewMethod.Items.Insert(0, item);
                ListViewMethod.SelectedItem = ListViewMethod.Items[0];

            }
        }

        private void bnt_Top_Click(object sender, RoutedEventArgs e)
        {

            if (ListViewMethod.SelectedIndex > 0 )
            {

                var item = ListViewMethod.SelectedItem as Method;
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
                ListViewMethod.Items.Insert(index - 1, item);
                ListViewMethod.SelectedItem = ListViewMethod.Items[index-1];
            }
        }

        private void bnt_Down_Click(object sender, RoutedEventArgs e)
        {

            if (ListViewMethod.SelectedIndex >=0 && ListViewMethod.SelectedIndex < ListViewMethod.Items.Count-1)
            {

                var item = ListViewMethod.SelectedItem as Method;
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
                ListViewMethod.Items.Insert(index + 1, item);
                ListViewMethod.SelectedItem = ListViewMethod.Items[index+1];
            }
        }

        private void bnt_Last_Click(object sender, RoutedEventArgs e)
        {

            if (ListViewMethod.SelectedIndex >=0 && ListViewMethod.SelectedIndex < ListViewMethod.Items.Count)
            {

                var item = ListViewMethod.SelectedItem as Method;
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
                ListViewMethod.Items.Insert(ListViewMethod.Items.Count, item);
                ListViewMethod.SelectedItem = ListViewMethod.Items[ListViewMethod.Items.Count-1];
            }
        }
        //---------------------------------------------------------------------------------------------
        //Hàm xử lý phương thức NewCase
        public void NewCaseOperation(int number)
        {
            //xử lý danh sách file
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy) // kiểm tra những file được check 
                {
                    fileSelected.Newname = fileSelected.Oldname;
                    string temp = fileSelected.Newname;
                    switch (number)
                    {
                       
                        case 1:
                            fileSelected.Newname = temp.ToLower();
                            break;
                        case 2:
                            fileSelected.Newname = temp.ToUpper();
                            break;
                        case 3:
                            fileSelected.Newname = temp.Substring(0, 1).ToLower() + temp.Substring(1).ToUpper();
                            break;
                        case 4:
                            fileSelected.Newname = temp.Substring(0, 1).ToUpper() + temp.Substring(1).ToLower();
                            break;
                 
                        default:
                            fileSelected.Newname = temp;
                            break;                      
                    }

                }
            }

            //xử lý danh sách folder
            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {
                    folderSelected.NewFoldername = folderSelected.Oldname;
                    string temp = folderSelected.NewFoldername;
                    switch (number)
                    {
                        case 1:
                            folderSelected.NewFoldername = temp.ToLower();
                            break;
                        case 2:
                            folderSelected.NewFoldername = temp.ToUpper();
                            break;
                        case 3:
                            folderSelected.NewFoldername = temp.Substring(0, 1).ToLower() + temp.Substring(1).ToUpper();
                            break;
                        case 4:
                            folderSelected.NewFoldername = temp.Substring(0, 1).ToUpper() + temp.Substring(1).ToLower();
                            break;
                        default:
                            folderSelected.NewFoldername = temp;
                            break;
                    }
                }
            }
        }

        //Hàm cài đặt sự kiện click button
        private void NewCase_Click(object sender, RoutedEventArgs e)
        {
            NewCaseFrame newCaseFrame = new NewCaseFrame();
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.Oldname = fileSelected.Newname;
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.Oldname = folderSelected.NewFoldername;
            }

            newCaseFrame.RadioButtonChanged += NewCaseOperation;
           
            ListViewMethod.Items.Add(new Method() { PageMethod=newCaseFrame, NameMethod = "New case", IsCheckMethod = true});           
                      
        }

        
        //hàm chuẩn hóa tên 
        public string NormalizeFullName(string origin)
        {
            string result = origin.Trim();
            int i = 0;
            int n = result.Length;
            while(i<n)
            {
                while(result[i]==' '&& result[i+1]==' ')
                {
                    result= result.Remove(i+1, 1);
                    --n;
                }
                i++;
            }

            result = result.ToLower();

            result = result.Substring(0, 1).ToUpper() + result.Substring(1);

            for ( i=1;i<result.Length;i++)
            {
                if(result[i]==' ')
                {
                    result = result.Substring(0,i+1)+result.Substring(i+1, 1).ToUpper() + result.Substring(i+2);
                }
            }
            return result;
        }


        //Hàm xử lý phương thức NewName
        public void NewNameOperation(int number)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {
                    
                    string temp = fileSelected.Newname;
                    switch (number)
                    {
                        case 1://tạo tên duy nhất
                            Guid guid = Guid.NewGuid();
                            fileSelected.Newname = guid.ToString();
                            break;
                        case 2://thêm số phía sau tên
                            int index = ListFileSelected.Items.IndexOf(fileSelected);
                            fileSelected.Newname = temp + Convert.ToString(index+1);
                            break;
                        case 3://thêm kí tự phía sau tên
                            int index1 = ListFileSelected.Items.IndexOf(fileSelected);
                            fileSelected.Newname = temp + Convert.ToChar(index1%24 +65);
                            break;
                        case 4://chuẩn hóa họ tên
                               
                            fileSelected.Newname = NormalizeFullName(temp);                
                            break;
                        default:
                            fileSelected.Newname = fileSelected.Oldname;                            
                                break;
                    }
                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {
                    string temp = folderSelected.NewFoldername;
                    switch (number)
                    {
                        case 1:
                            Guid guid = Guid.NewGuid();
                            folderSelected.NewFoldername = guid.ToString();
                            break;
                        case 2:
                            int index = ListFolderSelected.Items.IndexOf(folderSelected);
                            folderSelected.NewFoldername = temp +Convert.ToString(index+1);
                            break;
                        case 3:
                            int index1 = ListFolderSelected.Items.IndexOf(folderSelected);
                            folderSelected.NewFoldername = temp + Convert.ToChar(index1 % 24 + 65);
                            break;
                        case 4:
                            
                            folderSelected.NewFoldername = NormalizeFullName(temp);
                            break;
                       
                        default:                           
                            folderSelected.NewFoldername = folderSelected.Oldname;                           
                            break;
                    }

                }
            }

        }

        //Hàm xử lý sự kiện Click vào NewName trong menu AddMethod
        private void NewName_Click(object sender, RoutedEventArgs e)
        {

            NewNameFrame newNameFrame = new NewNameFrame();
            newNameFrame.textBlockMouseDown += NewNameOperation;
            ListViewMethod.Items.Add(new Method() {PageMethod=newNameFrame , NameMethod = "New name", IsCheckMethod = true });
           
        }

        //Hàm xử lý phương thức Move
        public void MoveOperation(string from, string count, string to)
        {
           
            int _from, _count, _to;
            var a = int.TryParse(from, out _from);
            var b = int.TryParse(count, out _count);
            var c = int.TryParse(to, out _to);
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {
                    fileSelected.Newname = fileSelected.Oldname;
                    string temp = fileSelected.Newname;
                    if (from.Length > 0 && to.Length > 0 && count.Length > 0)
                    {
                        if (a & b & c & _from > 0 & _from <= temp.Length && _count > 0 && _count + _from <= temp.Length && _to > 0)
                        {

                            string str1 = temp.Substring(_from - 1, _count);
                            string str2 = temp.Remove(_from - 1, _count);
                            if (_to - 1 >= 0 && _to - 1 < str2.Length - 1)
                                fileSelected.Newname = str2.Insert(_to - 1, str1);
                            else if (_to >= str2.Length)
                                fileSelected.Newname = str2.Insert(str2.Length - 1, str1);

                        }
                    }
                    else
                    {
                        fileSelected.Newname = temp;
                    }


                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {

                    folderSelected.NewFoldername = folderSelected.Oldname;
                    string temp = folderSelected.NewFoldername;

                    if (from.Length > 0 && to.Length > 0 && count.Length > 0)
                    {
                        if (a & b & c & _from > 0 & _from <= temp.Length && _count > 0 && _count + _from <= temp.Length && _to > 0)
                        {

                            string str1 = temp.Substring(_from - 1, _count);
                            string str2 = temp.Remove(_from - 1, _count);
                            if (_to - 1 >= 0 && _to - 1 < str2.Length - 1)
                                folderSelected.NewFoldername = str2.Insert(_to - 1, str1);
                            else if (_to >= str2.Length)
                                folderSelected.NewFoldername = str2.Insert(str2.Length - 1, str1);
                        }
                    }
                    else
                    {
                        folderSelected.NewFoldername = temp;
                    }

                }
            }


        }

        //Hàm xử lý sự kiện click vào Move trong MenuItem
        private void Move_Click(object sender, RoutedEventArgs e)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.Oldname = fileSelected.Newname;
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.Oldname = folderSelected.NewFoldername;
            }
            MoveFrame moveFrame = new MoveFrame();
            moveFrame.DataChanged += MoveOperation;
            ListViewMethod.Items.Add(new Method() { PageMethod=moveFrame, NameMethod = "Move", IsCheckMethod = true });           
        }


        //Hàm xử lý phương thức Remove
        public void RemoveOperation(string startIndex, string count)
        {
                
               int start, end;           
                foreach (FileSelected fileSelected in ListFileSelected.Items)
                {
                    if (fileSelected.IsGroovy)
                    {
                    
                    fileSelected.Newname= fileSelected.Oldname;
                    string temp = fileSelected.Newname;
                    if (startIndex.Length > 0 && count.Length > 0)
                    {
                        bool a = Int32.TryParse(startIndex, out start);
                        bool b = Int32.TryParse(count, out end);
                        if (a & b & start > 0 && start <= temp.Length && end > 0 && start + end <= temp.Length)
                        {
                           
                            fileSelected.Newname = temp.Remove(start-1, end);
                        }

                    }
                    else
                    {
                        fileSelected.Newname = temp;
                    }                                    
                    }

                }


                foreach (FolderSelected folderSelected in ListFolderSelected.Items)
                {
                    if (folderSelected.IsGroovyDir)
                    {

                    folderSelected.NewFoldername = folderSelected.Oldname;
                    string temp = folderSelected.NewFoldername;
                    if (startIndex.Length > 0 && count.Length > 0)
                    {
                        bool a = Int32.TryParse(startIndex, out start);
                        bool b = Int32.TryParse(count, out end);
                        if (a & b & start > 0 && start <=temp.Length && end > 0 && start + end <= temp.Length)
                        {
                          
                            folderSelected.NewFoldername = temp.Remove(start-1, end);                           
                        }

                    }
                    else
                    {
                        folderSelected.NewFoldername = temp;
                    }
                   
                    }
                }           
        }
    
            
        //Hàm xử lý sự kiện click vào Remove trong MenuItem AddMethod       
        private void Remove_Click(object sender, RoutedEventArgs e)
        {

            RemoveFrame removeFrame = new RemoveFrame();
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.Oldname = fileSelected.Newname;
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.Oldname = folderSelected.NewFoldername;
            }

            removeFrame.RemoveChanged += RemoveOperation;
            ListViewMethod.Items.Add(new Method() { PageMethod=removeFrame,  NameMethod = "Remove", IsCheckMethod = true });
           
        }
        

        //Hàm xử lý phương thức Replace
        public void ReplaceOperation(string from, string to)
        {
            foreach(FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {

                   fileSelected.Newname= fileSelected.Oldname;
                    string temp = fileSelected.Newname;
                    if (from.Length > 0)
                    {
                        
                        fileSelected.Newname = temp.Replace(from, to);

                    }
                    else
                    {
                        fileSelected.Newname = temp;
                    }
                   
                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {

                    folderSelected.NewFoldername = folderSelected.Oldname;
                    string temp = folderSelected.NewFoldername;
                    if (from.Length > 0)
                    {
                        
                        folderSelected.NewFoldername = temp.Replace(from, to);
                    }
                    else
                    {
                        folderSelected.NewFoldername = temp;
                    }
                   
                }
            }
        }
       
        //Hàm xử lý sự kiện khi nhấn vào Replace trong AddMethod
        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            ReplaceFrame replaceFrame = new ReplaceFrame();
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.Oldname = fileSelected.Newname;
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.Oldname = folderSelected.NewFoldername;
            }

            replaceFrame.TextBoxChanged += ReplaceOperation;
           ListViewMethod.Items.Add(new Method() {PageMethod=replaceFrame , NameMethod = "Replace", IsCheckMethod = true });
           
        }

        
        //Hàm xử lý phương thức Trim 
        public void TrimOperation(string data)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {
                   
                    fileSelected.Newname = fileSelected.Oldname;
                    string temp = fileSelected.Newname;
                    if (data.Length > 0 )
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (data[i] != ',')
                            {                               
                                fileSelected.Newname = temp.Trim(data[i]);
                            }
                        }
                    }
                    else
                    {
                        fileSelected.Newname = temp;
                    }
                   
                  
                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {
                    folderSelected.NewFoldername = folderSelected.Oldname;
                    string temp = folderSelected.NewFoldername;
                    if (data.Length > 0)
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (data[i] != ',')
                            {
                                folderSelected.NewFoldername = temp.Trim(data[i]);
                            }
                        }
                    }
                    else
                    {
                        folderSelected.NewFoldername = temp;
                    }
                
                }
            }
        }

       
        //Hàm xử lý sự kiện click vào Trim trong AddMethod
        private void Trim_Click(object sender, RoutedEventArgs e)
        {
            TrimFrame trimFrame = new TrimFrame();
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.Oldname = fileSelected.Newname;
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.Oldname = folderSelected.NewFoldername;
            }

            trimFrame.TrimStringChanged += TrimOperation;
            ListViewMethod.Items.Add(new Method() { PageMethod=trimFrame, NameMethod = "Trim", IsCheckMethod = true });           
        }


        //Hàm xử lý phương thức đổi tên đuôi mở rộng
        public void ExtensionOperation(string convert, string to)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {                   
                    string temp = Path.GetExtension(fileSelected.Filename);
                    if (convert.Length > 0)
                    {
                        fileSelected.Extension = temp.Replace(convert, to);

                    }
                    else
                    {
                        fileSelected.Extension = temp;
                    }

                }
            }



        }

        //Hàm xử lý sự kiện click vào Extension trong AddMethod
        private void Extension_Click(object sender, RoutedEventArgs e)
        {
            ExtensionFrame extensionFrame = new ExtensionFrame();
            extensionFrame.DataChanged += ExtensionOperation;
            ListViewMethod.Items.Add(new Method() { PageMethod = extensionFrame, NameMethod = "Extension", IsCheckMethod = true });

        }


        //Hàm xử lý button xóa phương thức
        private void RemoveMethod_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.SelectedIndex != -1)
            {
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
            }
        }

       //Hàm xóa danh sách phương thức
        private void bnt_Clear_Click(object sender, RoutedEventArgs e)
        {
            while(ListViewMethod.Items.Count>0)
            {
                ListViewMethod.Items.RemoveAt(0);
            }

           foreach(FileSelected fileSelected in ListFileSelected.Items)
            {
                if(fileSelected.IsGroovy)
                {
                    fileSelected.Newname = fileSelected.Filename;
                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {
                    folderSelected.NewFoldername = folderSelected.Foldername;
                }
            }
        }
        
        //Hàm xóa một phương thức trong danh sách
        private void IconLeftClear_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.SelectedIndex != -1 && ListViewMethod.Items.Count >= 0)
            {
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
            }
        }

        

        //hàm xử lý checked column checkbox file
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.IsGroovy = true;
            }
        }

        //hàm xử lý unchecked column checkbox file
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.IsGroovy = false;
            }
        }

        //hàm xử lý checked column checkbox folder
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.IsGroovyDir = true;
            }
        }

        //hàm xử lý unchecked column checkbox folder
        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.IsGroovyDir = false;
            }
        }

        //Hàm thực hiện đổi tên file và folder - sự kiện nhấn vào button Start Batch
        private void StartBatch_Click(object sender, RoutedEventArgs e)
        {
           foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if(fileSelected.IsGroovy)
                {
                    FileInfo fileInfo = new FileInfo(fileSelected.Path);
                    try
                    {
                        if (fileSelected.Newname + fileSelected.Extension != fileSelected.Filename)
                        {
                            //trường hợp tên trống đặt lại tên cũ
                            if (fileSelected.Newname.Length <= 0)
                                fileSelected.Newname = Path.GetFileNameWithoutExtension(fileSelected.Filename);
                            //trường hợp tên mở rộng trống đặt lại tên mở rộng cũ
                            if (fileSelected.Extension == "." || fileSelected.Extension == "")
                                fileSelected.Extension = Path.GetExtension(fileSelected.Filename);

                            //trường hợp thiếu '.' trong tên mở rộng
                            if (fileSelected.Extension[0] != '.')
                                fileSelected.Extension = "." + fileSelected.Extension;

                            //đổi tên mới 
                            fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + fileSelected.Newname + fileSelected.Extension);
                            fileSelected.Filename = fileSelected.Newname + fileSelected.Extension;
                            fileSelected.Path = fileInfo.Directory.FullName + "\\" + fileSelected.Newname + fileSelected.Extension;
                            fileSelected.Error = "Success Rename";
                            fileSelected.Oldname = fileSelected.Newname;
                            
                        }
                        
                       
                    }
                    catch(Exception exception)
                    {
                        fileSelected.Error = "Can't rename file :" + fileSelected.Filename + "\n Error: " + exception;                       
                    }
                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {
                    FileInfo fileInfo = new FileInfo(folderSelected.PathFolder);
                    try
                    {


                        if (folderSelected.NewFoldername != folderSelected.Foldername)
                        {
                            if (folderSelected.NewFoldername.Length <= 0)
                                folderSelected.NewFoldername = folderSelected.Foldername;

                            fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + folderSelected.NewFoldername);
                            folderSelected.Foldername = folderSelected.NewFoldername;
                            folderSelected.PathFolder = fileInfo.Directory.FullName + "\\" + folderSelected.NewFoldername;
                            folderSelected.ErrorFolder = "Success Rename";
                            folderSelected.Oldname = folderSelected.Foldername;

                        }                        
                    
                    }
                    catch(Exception exception)
                    {

                        folderSelected.ErrorFolder = "Can't rename folder :" + folderSelected.Foldername + "\n Error: " + exception;

                    }
                }
            }
        }

       
    }



    //Class Method

    public class Method : INotifyPropertyChanged
    {
      
        private Page page;        
        private string nameMethod;
        private bool isCheckMethod;
      
        public Page PageMethod
        {
            get { return page; }
            set
            {
                page = value;
                OnPropertyChanged("PageMethod");
            }
        }
      
        public string NameMethod
        {
            get { return nameMethod; }
            set
            {
                nameMethod = value;
                OnPropertyChanged("NameMethod");
            }

        }

        public bool IsCheckMethod
        {
            get { return isCheckMethod; }
            set
            {
                isCheckMethod = value;
                OnPropertyChanged("IsCheckMethod");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }

    }

    //Class File
    public class FileSelected:INotifyPropertyChanged
    {

        private string _oldname;

        public string Oldname
        {
            get { return _oldname; }
            set
            {
                _oldname = value;
                OnPropertyChanged("Oldname");
            }
        }
        private string _filename;
        public string Filename
        {
            get { return _filename; }
            set
            {
                _filename = value;
                OnPropertyChanged("Filename");
            }
        }

        private string newname;
        public string Newname
        {
            get { return newname; }
            set
            {
                newname = value;
                OnPropertyChanged("Newname");
            }
        }


        private string path;
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }

        private string error;
        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged("Error");
            }
        }

        private bool isgroovy;
        public bool IsGroovy
        {
            get { return isgroovy; }
            set
            {
                isgroovy = value;
                OnPropertyChanged("IsGroovy");
            }
        }

        private string extension;
        public string Extension
        {
            get { return extension;  }
            set
            {
                extension = value;
                OnPropertyChanged("Extension");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }


   //Class Folder
    public class FolderSelected:INotifyPropertyChanged
    {

        private string _oldname;

        public string Oldname
        {
            get { return _oldname; }
            set
            {
                _oldname = value;
                OnFolderChanged("Oldname");
            }
        }

        private string _foldername;
        public string Foldername
        {
            get { return _foldername; }
            set
            {
                _foldername = value;
                OnFolderChanged("Foldername");
            }
        }

        private string newfoldername;
        public string NewFoldername
        {
            get { return newfoldername; }
            set
            {
                newfoldername = value;
                OnFolderChanged("NewFoldername");
            }
        }


        private string pathfolder;
        public string PathFolder
        {
            get { return pathfolder; }
            set
            {
                pathfolder = value;
                OnFolderChanged("PathFolder");
            }
        }

        private string errorfolder;
        public string ErrorFolder
        {
            get { return errorfolder; }
            set
            {
                errorfolder = value;
                OnFolderChanged("ErrorFolder");
            }
        }


        private bool isgroovydir;
        public bool IsGroovyDir
        {
            get { return isgroovydir; }
            set
            {
                isgroovydir = value;
                OnFolderChanged("IsGroovyDir");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnFolderChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}



       
    


