using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WinForms = System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Input;

namespace EncoderDecoder
{

    public partial class MainWindow : Window
    {
        #region Private Veriables

            private string ButtonTextPreset1 = "Encrypt";
            private string ButtonTextPreset2 = "Decrypt";

            private string Label1TextPreset1 = "Usual file :";
            private string Label1TextPreset2 = "File to Encrypt :";
            private string Label2TextPreset1 = "File to decrypt:";
            private string Label2TextPreset2 = "Result file :";

            private byte Key;

        #endregion

        #region Private Methods

        private void WriteFile(byte[] _byteArr)
        {
            Dispatcher.Invoke(() =>
            {
                using (FileStream _fileStream = new FileStream(TextBox2.Text, FileMode.OpenOrCreate))
                {
                    _fileStream.Write(_byteArr, 0, _byteArr.Length);
                }
            });
        }

        private byte[] ReadFile()
        {
            byte[] _resultArr = default(byte[]);
            Dispatcher.Invoke(() =>
            {
                using (FileStream _fileStream = new FileStream(TextBox1.Text, FileMode.OpenOrCreate))
                {
                    byte[] _byteArr = new byte[_fileStream.Length];
                    _fileStream.Read(_byteArr, 0, _byteArr.Length);
                    _resultArr = _byteArr;
                }
            });

            return _resultArr;
        }

        private byte GetByteFromKey(string _key)
        {
            int _resultInt = 0;

            if (_key.Length > 1)
                _resultInt = BitConverter.ToInt16(Encoding.ASCII.GetBytes(_key), 0);
            else
                _resultInt = Char.Parse(_key);

            return Convert.ToByte(_resultInt % 255);
        }

        private ActionType GetActionType()
        {
            if (DecryptRadioBtn.IsChecked != false)
                return ActionType.Decrypt;
            else
                return ActionType.Encrypt;
        }

        private void ShowMessage(string _message, string _title)
        {
            System.Windows.MessageBox.Show(_message, _title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region Windows Events

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ComboBox1.Items.Add("Bitwise Exclusive OR (XOR)");
            ComboBox1.Items.Add("Bitwise AND");
            ComboBox1.Items.Add("Bitwise OR");
            ComboBox1.Items.Add("Bitwise Complement");

            ComboBox1.SelectedIndex = 0;
        }

        private async void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            string _txtBox1Text = TextBox1.Text;
            string _txtBox2TExt = TextBox2.Text;
            string _passwordBox = PasswordBox.Password;
            

            if (String.IsNullOrEmpty(_txtBox1Text) || String.IsNullOrEmpty(_txtBox2TExt) || String.IsNullOrEmpty(_passwordBox))
            {
                ShowMessage("File necessary fields is empty", "Somethong Wrong!");
                return;
            }

            Key = await GetByteFromKeyAsync(_passwordBox);

            switch (ComboBox1.SelectedIndex)
            {
                case 0: { Action_XOR(); } break;
                case 1: { Action_And(); } break;
                case 2: { Action_OR(); } break;
                case 3: { Action_BitwiseComplement(); } break;
                default: break;
            }
        }

        private void DecryptFileOpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                TextBox1.Text = openFileDialog.FileName;
            }
        }

        private void EncryptFileOpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                TextBox2.Text = openFileDialog.FileName;
            }
        }

        private void DecryptRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            ActionButton.Content = ButtonTextPreset2;
            Label1.Content = Label1TextPreset2;
            Label2.Content = Label2TextPreset2;
        }

        private void EncryptRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            ActionButton.Content = ButtonTextPreset1;
            Label1.Content = Label1TextPreset1;
            Label2.Content = Label2TextPreset1;
        }

        #endregion


        #region Private Async Methods

        private async Task<byte> GetByteFromKeyAsync(string _key)
        {
            return await Task.Run(() => GetByteFromKey(_key));
        }

        private async Task<byte[]> ReadFileAsync()
        {
            return await Task.Run(() => ReadFile());
        }

        private async void WriteFileAsync(byte[] _byteArr)
        {
            await Task.Run(() => WriteFile(_byteArr));
        }

        private async void Action_XOR()
        {
            byte[] _arrToEncrypt = await ReadFileAsync();

            for (int i = 0; i < _arrToEncrypt.Length; i++)
            {
                _arrToEncrypt[i] = (byte)(_arrToEncrypt[i] ^ Key);
            }

            WriteFileAsync(_arrToEncrypt);
        }

        private async void Action_And()
        {
            byte[] _arrToEncrypt = await ReadFileAsync();

            for (int i = 0; i < _arrToEncrypt.Length; i++)
            {
                _arrToEncrypt[i] = (byte)(_arrToEncrypt[i] & Key);
            }

            WriteFileAsync(_arrToEncrypt);
        }

        private async void Action_OR()
        {
            byte[] _arrToEncrypt = await ReadFileAsync();

            for (int i = 0; i < _arrToEncrypt.Length; i++)
            {
                _arrToEncrypt[i] = (byte)(_arrToEncrypt[i] | Key);
            }

            WriteFileAsync(_arrToEncrypt);
        }

        private async void Action_BitwiseComplement()
        {
            byte[] _arrToEncrypt = await ReadFileAsync();

            for (int i = 0; i < _arrToEncrypt.Length; i++)
            {
                _arrToEncrypt[i] = (byte)(~_arrToEncrypt[i]);
            }

            WriteFileAsync(_arrToEncrypt);
        }

        #endregion


        public enum ActionType
        {
            Encrypt = 0,
            Decrypt = 1
        }
        
    }
}