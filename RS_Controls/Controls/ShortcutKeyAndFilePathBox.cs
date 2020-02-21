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
    public class ShortcutKeyAndFilePathBox : Control
    {
        const string ShortcutKeyName_TextBox = "ShortcutKeyName_TextBox";

        #region Dependency Property
        public static readonly DependencyProperty ShortcutKeyProperty = DependencyProperty.Register("ShortcutKey", typeof(string), typeof(ShortcutKeyAndFilePathBox),
            new PropertyMetadata(null, null));
        public static readonly DependencyProperty ShortcutKeyListProperty = DependencyProperty.Register("ShortcutKeyList", typeof(List<Key>), typeof(ShortcutKeyAndFilePathBox),
            new PropertyMetadata(new List<Key>(), null));
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
        public List<Key> ShortcutKeyList
        {
            get { return (List<Key>)GetValue(ShortcutKeyListProperty); }
            set { SetValue(ShortcutKeyListProperty, value); }
        }
        #endregion

        #region Public Mathod
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            keyTextBox = Template.FindName(ShortcutKeyName_TextBox, this) as TextBox;
            if (keyTextBox != null)
            {
                keyTextBox.KeyDown += TextBox_PreviewKeyDown;
            }
        }
        #endregion

        #region Private Method

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (ShortcutKeyList.Contains(e.Key))
            {
                MessageBox.Show("중복된 단축키입니다.");
                return;
            }

            ShortcutKey = e.Key.ToString();
            ShortcutKeyList.Add(e.Key);

        }

        private bool IsFolder(string FullPath)
        {
            FileAttributes attr = File.GetAttributes(FullPath);
            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }
        #endregion
    }
}
