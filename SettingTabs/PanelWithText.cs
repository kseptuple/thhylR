using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingTabs
{
    public class PanelWithText : Panel
    {
        [Browsable(true)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }
    }
}
