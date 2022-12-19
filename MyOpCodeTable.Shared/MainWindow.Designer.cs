using Telerik.WinControls.UI;

namespace MyOpCodeTable.Shared
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            FluentDarkTheme = new Telerik.WinControls.Themes.FluentDarkTheme();
            FluentTheme = new Telerik.WinControls.Themes.FluentTheme();
            this.opCodesGridView = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.opCodesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opCodesGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // opCodesGridView
            // 
            this.opCodesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opCodesGridView.Location = new System.Drawing.Point(0, 0);
            this.opCodesGridView.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            // 
            // 
            // 
            this.opCodesGridView.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.opCodesGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.opCodesGridView.MasterTemplate.EnableFiltering = true;
            this.opCodesGridView.MasterTemplate.EnableGrouping = false;
            this.opCodesGridView.MasterTemplate.ShowFilterCellOperatorText = false;
            this.opCodesGridView.MasterTemplate.ShowRowHeaderColumn = false;
            this.opCodesGridView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.opCodesGridView.Name = "opCodesGridView";
            this.opCodesGridView.ShowGroupPanel = false;
            this.opCodesGridView.Size = new System.Drawing.Size(1000, 500);
            this.opCodesGridView.TabIndex = 0;
            this.opCodesGridView.ContextMenuOpening += new Telerik.WinControls.UI.ContextMenuOpeningEventHandler(this.opCodesGridView_OnContextMenuOpening);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.opCodesGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = ".Net All Opcodes";
            this.ThemeName = "Fluent";
            ((System.ComponentModel.ISupportInitialize)(this.opCodesGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opCodesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView opCodesGridView;
        private Telerik.WinControls.Themes.FluentDarkTheme FluentDarkTheme;
        private Telerik.WinControls.Themes.FluentTheme FluentTheme;
    }
}