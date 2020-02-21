using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RS_Controls.Controls
{
    [TemplatePart(Name = ShortcutKeyName_TextBox, Type = typeof(TextBox))]
    [TemplatePart(Name = ShortcutKeyPathLoad_Button, Type = typeof(Button))]
    [TemplatePart(Name = ShortcutKeyPath_TextBox, Type = typeof(TextBox))]
    public class ShortcutKeySettingBox : Control
    {
        const string ShortcutKeyName_TextBox = "ShortcutKeyName_TextBox";
        const string ShortcutKeyPathLoad_Button = "ShortcutKeyPathLoad_Button";
        const string ShortcutKeyPath_TextBox = "ShortcutKeyPath_TextBox";

        #region Dependency Property
        public static readonly DependencyProperty ShortcutKeyProperty = DependencyProperty.Register("ShortcutKey", typeof(string), typeof(ShortcutKeySettingBox),
            new PropertyMetadata(null, null));
        public static readonly DependencyProperty ShortcutKeyPathProperty = DependencyProperty.Register("ShortcutKeyPath", typeof(string), typeof(ShortcutKeySettingBox),
            new PropertyMetadata(null, null));
        public static readonly DependencyProperty ISFolderProperty = DependencyProperty.Register("ISFolder", typeof(bool), typeof(ShortcutKeySettingBox),
            new PropertyMetadata(false, null));
        public static readonly DependencyProperty SetExtenSionProperty = DependencyProperty.Register("SetExtensions", typeof(ObservableCollection<string>), typeof(ShortcutKeySettingBox),
            new PropertyMetadata(null, null));
        public static readonly DependencyProperty ShortcutKeyDicProperty = DependencyProperty.Register("ShortcutKeyDic", typeof(Dictionary<Key, string>), typeof(ShortcutKeySettingBox),
            new PropertyMetadata(new Dictionary<Key, string>(), null));
        #endregion

        #region
        protected TextBox keyTextBox = null;
        protected Button button = null;
        protected TextBox pathTextBox = null;
        #endregion

        #region Properties
        public string ShortcutKey
        {
            get { return (string)GetValue(ShortcutKeyProperty); }
            set { SetValue(ShortcutKeyProperty, value); }
        }
        public string ShortcutKeyPath
        {
            get { return (string)GetValue(ShortcutKeyPathProperty); }
            set { SetValue(ShortcutKeyPathProperty, value); }
        }
        public bool ISFolder
        {
            get { return (bool)GetValue(ISFolderProperty); }
            set { SetValue(ISFolderProperty, value); }
        }
        public ObservableCollection<string> SetExtensions
        {
            get { return (ObservableCollection<string>)GetValue(SetExtenSionProperty); }
            set { SetValue(SetExtenSionProperty, value); }
        }
        public Dictionary<Key, string> ShortcutKeyDic
        {
            get { return (Dictionary<Key, string>)GetValue(ShortcutKeyDicProperty); }
            set { SetValue(ShortcutKeyDicProperty, value); }
        }
        #endregion

        #region Public Mathod
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            button = Template.FindName(ShortcutKeyPathLoad_Button, this) as Button;
            if (button != null)
            {
                button.Click += Button_Click;
            }
            pathTextBox = Template.FindName(ShortcutKeyPath_TextBox, this) as TextBox;
            if (pathTextBox != null)
            {
                pathTextBox.PreviewDragOver += TextBox_PreviewDragOver;
                pathTextBox.Drop += TextBox_Drop;
            }
            keyTextBox = Template.FindName(ShortcutKeyName_TextBox, this) as TextBox;
            if (keyTextBox != null)
            {
                keyTextBox.KeyDown += TextBox_PreviewKeyDown;
            }
        }
        #endregion

        #region Private Method

        private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Handled = true;
            }
        }

        private void TextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files[0] == null)
                    return;

                if(ISFolder == true)
                {
                    if (IsFolder(files[0]) == true)
                        ShortcutKeyPath = files[0];
                }
                else
                {
                    if (SetExtensions == null)
                    {
                        ShortcutKeyPath = files[0];
                    }
                    else
                    {
                        foreach(string extenstion in SetExtensions)
                        {
                            if (Path.GetExtension(files[0]).ToLower() == extenstion.ToLower())
                                ShortcutKeyPath = files[0];
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            if (ISFolder == true)
            {
                dialog.IsFolderPicker = true;
            }
            else
            {
                dialog.IsFolderPicker = false;
                if (SetExtensions != null)
                {
                    foreach (string extenstion in SetExtensions)
                    {
                        dialog.Filters.Add(new CommonFileDialogFilter("Available Extention", $"*.{extenstion}"));
                    }
                }
            }

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ShortcutKeyPath = dialog.FileName;
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (ShortcutKeyDic.ContainsKey(e.Key))
            {
                MessageBox.Show("중복된 단축키입니다.");
                return;
            }

            ShortcutKey = e.Key.ToString();
            ShortcutKeyDic.Add(e.Key, ShortcutKeyPath);
        }

        private bool IsFolder(string FullPath)
        {
            FileAttributes attr = File.GetAttributes(FullPath);
            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }
        #endregion
    }
}
