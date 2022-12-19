using System.ComponentModel.Composition;
using System.Threading.Tasks;
using dnSpy.Contracts.Images;
using dnSpy.Contracts.Themes;
using dnSpy.Contracts.ToolBars;
using MyOpCodeTable.Shared;

// Adds a toolbar button and combobox between the asm editor and debugger toolbar items

namespace MyOpCodeTable.Extension
{
    static class TBConstants
    {
        //TODO: Use your own guid
        // Place it between the asm editor and debugger, see dnSpy.Contracts.ToolBars.ToolBarConstants:
        //		GROUP_APP_TB_MAIN_ASMED_UNDO = "4000,6351DBFC-6D8D-4847-B3F2-BC376912B9C2"
        //		GROUP_APP_TB_MAIN_DEBUG = "5000,A0AFBC69-B6D1-46FE-96C8-EC380DEBE9AA"
        public const string GROUP_APP_TB_EXTENSION = "4500,AF461C50-6E91-41B8-9771-0BAE9B77BC69";
    }

    [ExportToolBarButton(Icon = DsImagesAttribute.Assembly, ToolTip = "Open .Net OpCodes", Group = TBConstants.GROUP_APP_TB_EXTENSION, Order = 0)]
    sealed class TBCommand1 : ToolBarButtonBase
    {
        [Import] public IThemeService CurrentThemeService;
        public override void Execute(IToolBarItemContext context)
        {
            Parallel.Invoke(() =>
            {
                new MainWindow(CurrentThemeService.Theme.IsDark).Show();
            });
        }
    }
}