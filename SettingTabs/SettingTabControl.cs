using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace SettingTabs
{
    [Designer(typeof(ControllerDesignerMain))]
    public partial class SettingTabControl : UserControl
    {
        public SettingTabControl()
        {
            tabPanels ??= new ObservableCollection<PanelWithText>();
            bindingSource.DataSource = tabPanels;
            tabPanels.CollectionChanged += TabPanels_CollectionChanged;
            InitializeComponent();
            listBoxTabs.DataSource = bindingSource;
            listBoxTabs.DisplayMember = "Text";
            listBoxTabs.ValueMember = "Text";
            if (tabPanels.Count > 0)
            {
                listBoxTabs.SelectedIndex = 0;
                lastSelectedIndex = 0;
                for (int i = 0; i < tabPanels.Count; i++)
                {
                    var panel = tabPanels[i];   
                    tableLayoutPanelMain.Controls.Add(panel, 1, 0);
                    panel.Dock = DockStyle.Fill;
                }
            }
            else
            {
                lastSelectedIndex = -1;
            }
        }

        private void TabPanels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newItems = e.NewItems;
                if (newItems != null && newItems.Count > 0)
                {
                    foreach (var item in newItems)
                    {
                        var panelItem = item as PanelWithText;
                        panelItem.Dock = DockStyle.Fill;
                        //panelItem
                    }
                    bindingSource.ResetBindings(false);
                }
            }
        }

        private int lastSelectedIndex;

        private BindingSource bindingSource = new BindingSource();

        public Padding TabListMargin
        {
            get
            {
                return listBoxTabs.Margin;
            }
            set
            {
                listBoxTabs.Margin = value;
            }
        }

        public float TabWidth
        {
            get
            {
                return tableLayoutPanelMain.ColumnStyles[0].Width;
            }
            set
            {
                tableLayoutPanelMain.ColumnStyles[0].Width = value;
            }
        }

        public SizeType TabWidthType
        {
            get
            {
                return tableLayoutPanelMain.ColumnStyles[0].SizeType;
            }
            set
            {
                tableLayoutPanelMain.ColumnStyles[0].SizeType = value;
            }
        }

        [Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ListBox ListBoxTabs
        {
            get
            {
                return listBoxTabs;
            }
        }

        private ObservableCollection<PanelWithText> tabPanels;

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public ObservableCollection<PanelWithText> TabPanels
        {
            get
            {
                return tabPanels;
            }
            set
            {
                tabPanels = value;
            }
        }

        private void listBoxTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTabs.SelectedIndex != lastSelectedIndex)
            {
                lastSelectedIndex = listBoxTabs.SelectedIndex;
                for (int i = 0; i < tabPanels.Count; i++)
                {
                    if (i != lastSelectedIndex)
                    {
                        tabPanels[i].Visible = false;
                    }
                    else
                    {
                        tabPanels[i].Visible = true;
                    }
                }
            }
        }
    }
}
