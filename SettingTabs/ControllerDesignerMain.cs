using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SettingTabs
{
    public class ControllerDesignerMain : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            var listBoxTab = ((SettingTabControl)Control).ListBoxTabs;
            EnableDesignMode(listBoxTab, "ListBoxTabs");
        }
        public override bool CanParent(Control control)
        {
            return false;
        }
        protected override void OnDragOver(DragEventArgs de)
        {
            de.Effect = DragDropEffects.None;
        }
        protected override IComponent[] CreateToolCore(ToolboxItem tool, int x, int y, int width, int height, bool hasLocation, bool hasSize)
        {
            return null;
        }
    }
}
