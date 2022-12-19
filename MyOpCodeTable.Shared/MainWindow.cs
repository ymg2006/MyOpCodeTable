#if NET48
using AsyncIO.FileSystem;
#endif
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace MyOpCodeTable.Shared
{
    public partial class MainWindow : Telerik.WinControls.UI.RadForm
    {
        private static string dataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "Data\\ListofOpCodes.json").Replace("file:\\", string.Empty);
        private EventHandler<EventArgs> dataLoadedEventHandler;
        private bool isDark;

        public MainWindow(bool isDark = false)
        {
            Cursor = Cursors.WaitCursor;
            this.isDark = isDark;
            ThemeResolutionService.ApplicationThemeName = isDark ? "FluentDark" : "Fluent";
            InitializeComponent();
            dataLoadedEventHandler += onDataLoadedEventHandler;
            PopulateOpCodes();
            Cursor = Cursors.Default;
        }

        private void onDataLoadedEventHandler(object sender, EventArgs e)
        {
            opCodesGridView.Rows[0].IsCurrent = true;
        }

        public async Task PopulateOpCodes()
        {
#if NET48
            var fileString = await AsyncFile.ReadAllTextAsync(dataPath);
#else
            var fileString = await File.ReadAllTextAsync(dataPath);
#endif
            OpCodes = await fileString.DeserializeAsync<ObservableCollection<OpCode>>();
            opCodesGridView.DataSource = OpCodes;
            dataLoadedEventHandler?.Invoke(this, EventArgs.Empty);
            SetExtraSettingGridView();
        }

        public void SetExtraSettingGridView()
        {
            for (int i = 0; i <= opCodesGridView.Columns.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        opCodesGridView.Columns[i].Width = 108;
                        opCodesGridView.Columns[i].MinWidth = 85;
                        opCodesGridView.Columns[i].MaxWidth = 85;
                        opCodesGridView.Columns[i].HeaderTextAlignment = ContentAlignment.MiddleLeft;
                        break;
                    case 1:
                        opCodesGridView.Columns[i].MinWidth = 50;
                        opCodesGridView.Columns[i].MaxWidth = 50;
                        break;
                    case 2:
                        opCodesGridView.Columns[i].MinWidth = 50;
                        opCodesGridView.Columns[i].MaxWidth = 50;
                        opCodesGridView.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                        break;
                    case 3:
                        opCodesGridView.Columns[i].Width = 400;
                        opCodesGridView.Columns[i].MinWidth = 180;
                        opCodesGridView.Columns[i].HeaderTextAlignment = ContentAlignment.MiddleLeft;
                        break;
                    case 7:
                        opCodesGridView.Columns[i].HeaderText = "Push Behavior";
                        opCodesGridView.Columns[i].MinWidth = 115;
                        opCodesGridView.Columns[i].MaxWidth = 115;
                        break;
                    case 8:
                        opCodesGridView.Columns[i].HeaderText = "Pop Behavior";
                        opCodesGridView.Columns[i].MinWidth = 115;
                        opCodesGridView.Columns[i].MaxWidth = 115;
                        break;
                    default:
                        opCodesGridView.Columns[i].MinWidth = 115;
                        opCodesGridView.Columns[i].MaxWidth = 115;
                        break;
                }
            }
        }

        public ObservableCollection<OpCode> OpCodes { get; set; }

        private void opCodesGridView_OnContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (e.ContextMenuProvider.ToString().Contains("GridDataCellElement"))
            {
                var loadDefaultsMenuItem = new Telerik.WinControls.UI.RadMenuItem("Load Defaults");
                loadDefaultsMenuItem.Click += loadDefaultsMenuItem_Click;
                e.ContextMenu.Items.Add(loadDefaultsMenuItem);

                var saveAllMenuItem = new Telerik.WinControls.UI.RadMenuItem("Save All");
                saveAllMenuItem.Click += saveToolStripMenuItem_Click;
                e.ContextMenu.Items.Add(saveAllMenuItem);
                e.ContextMenu.Items.Add(new Telerik.WinControls.UI.RadMenuSeparatorItem());

                if (isDark)
                {
                    var lightMenuItem = new Telerik.WinControls.UI.RadMenuItem("Light Theme");
                    e.ContextMenu.Items.Add(lightMenuItem);
                    lightMenuItem.Click += lightToolStripMenuItem_Click;
                }
                else
                {
                    var darkMenuItem = new Telerik.WinControls.UI.RadMenuItem("Dark Theme");
                    e.ContextMenu.Items.Add(darkMenuItem);
                    darkMenuItem.Click += darkToolStripMenuItem_Click;
                }
            }
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            File.Delete(dataPath);
            using (var stream = File.Create(dataPath))
            {
               await OpCodes.SerializeAsync(stream, new JsonSerializerSettings()
               {
                   Formatting = Formatting.Indented
               });
            }
            Cursor = Cursors.Default;
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "Fluent";
            isDark = false;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemeResolutionService.ApplicationThemeName = "FluentDark";
            isDark = true;
        }

        private async void loadDefaultsMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            OpCodes.Clear();
            OpCodes = await Properties.Resources.OpCodes.DeserializeAsync<ObservableCollection<OpCode>>();
            opCodesGridView.DataSource = OpCodes;
            Cursor = Cursors.Default;
        }
    }
}
