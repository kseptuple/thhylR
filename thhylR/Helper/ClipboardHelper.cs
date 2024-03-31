using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thhylR.Helper
{
    public static class ClipboardHelper
    {
        public static void FileToClipboard(string[] filePath, bool cut)
        {
            if (filePath != null && filePath.Length > 0)
            {
                Clipboard.Clear();
                byte[] bytes = new byte[] { (byte)(cut ? 2 : 1), 0, 0, 0 };
                MemoryStream dropEffect = new MemoryStream();
                dropEffect.Write(bytes, 0, bytes.Length);

                IDataObject data = new DataObject(DataFormats.FileDrop, filePath);
                data.SetData("Preferred DropEffect", dropEffect);
                Clipboard.SetDataObject(data);
            }
        }

        public static void TextToClipboard(string text)
        {
            Clipboard.SetText(text, TextDataFormat.UnicodeText);
        }
    }
}
