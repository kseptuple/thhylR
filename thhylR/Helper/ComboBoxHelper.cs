using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thhylR.Helper
{
    public static class ComboBoxHelper
    {
        public static void SetSelectedValue(this ComboBox comboBox, object value)
        {
            if (comboBox.Items.Count > 0)
            {
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    object item = comboBox.Items[i];
                    object thisValue = item.GetType().GetProperty(comboBox.ValueMember).GetValue(item);
                    if (thisValue != null && thisValue.Equals(value))
                    {
                        comboBox.SelectedIndex = i;
                        return;
                    }
                }
                comboBox.SelectedIndex = 0;
            }
        }

        public static object GetSelectedValue(this ComboBox comboBox)
        {
            if (comboBox.SelectedIndex != -1)
            {
                object item = comboBox.Items[comboBox.SelectedIndex];
                return item.GetType().GetProperty(comboBox.ValueMember).GetValue(item);
            }
            else
            {
                return null;
            }
        }
    }
}
