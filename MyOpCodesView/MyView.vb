Imports System.IO
Imports System.Reflection.Emit
Imports Telerik.WinControls
Imports Newtonsoft.Json
Imports System.Windows.Forms
Imports System.Text

Public Class Myform
    Inherits Telerik.WinControls.UI.RadForm

    Private ReadOnly CachePath As String = Path.GetDirectoryName(Application.ExecutablePath) & "\ListofOpCodes.json"
    Private DictofOpCodes As New Dictionary(Of OpCode, String)
    Private ListofOpCodes As New List(Of MyOpcode)
    Public Sub New()
        InitializeComponent()
        ThemeResolutionService.ApplicationThemeName = "FluentDark"
    End Sub

    Public Sub New(ByVal Dark As Boolean)
        InitializeComponent()
        ThemeResolutionService.ApplicationThemeName = IIf(Dark, "FluentDark", "Fluent")
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.My_Icons
        Cursor = Cursors.WaitCursor
        If Not File.Exists(CachePath) Then
            DictofOpCodes = OpCodes.Xor.GetAll
            LoadtoDataGrid(0)
        Else
            ListofOpCodes = (Function() JsonConvert.DeserializeObject(Of List(Of MyOpcode))(File.ReadAllText(CachePath))).Invoke
            LoadtoDataGrid(1)
            RadGridView.Columns("Name").Sort(UI.RadSortOrder.Ascending, False)
        End If
        Cursor = Cursors.Default
        RadGridView.Rows(0).IsCurrent = True
    End Sub
    Private Sub LoadtoDataGrid(input As Integer)
        If input = 0 Then
            RadGridView.BeginUpdate()
            For Each item In DictofOpCodes
                Dim hex As New StringBuilder
                RadGridView.Rows.Add(item.Key.Name.ToString, hex.AppendFormat("{0:x2}", item.Key.Value), item.Key.Size.ToString, item.Value,
                                          item.Key.OpCodeType.ToString, item.Key.FlowControl.ToString, item.Key.OperandType.ToString, item.Key.StackBehaviourPush.ToString, item.Key.StackBehaviourPop.ToString)
            Next
            RadGridView.EndUpdate()
        ElseIf input = 1 Then
            RadGridView.BeginUpdate()
            For Each item As MyOpcode In ListofOpCodes
                RadGridView.Rows.Add(item.Name, item.Value, item.Size, item.Info, item.OpCodeType, item.FlowControl, item.OperandType, item.StackBehaviourPush, item.StackBehaviourPop)
            Next
            RadGridView.EndUpdate()
        End If
        For Each cell In RadGridView.Rows
            Dim rowi As UI.GridViewRowInfo = RadGridView.Rows(cell.Index)
            Parallel.For(0, 8, Sub(i)
                                   SyncLock cell
                                       If i <> 3 Then
                                           rowi.Cells(i).ReadOnly = True
                                       End If
                                   End SyncLock
                               End Sub)
        Next
    End Sub
    Private Overloads Sub radGridView_CreateRow(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCreateRowEventArgs) Handles RadGridView.CreateRow
        e.RowInfo.MinHeight = 28
    End Sub
    Private Sub saveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Cursor = Cursors.WaitCursor
        ListofOpCodes.Clear()
        Clear(CachePath)
        Parallel.ForEach(RadGridView.Rows, Sub(cell)
                                               SyncLock ListofOpCodes
                                                   Dim rowi As UI.GridViewRowInfo = RadGridView.Rows(cell.Index)
                                                   Dim temp As New MyOpcode With {.Name = rowi.Cells(0).Value.ToString(), .Value = rowi.Cells(1).Value.ToString().ToString,
                                                                                           .Size = rowi.Cells(2).Value.ToString(), .Info = rowi.Cells(3).Value.ToString(), .OpCodeType = rowi.Cells(4).Value.ToString(),
                                                                                           .FlowControl = rowi.Cells(5).Value.ToString(), .OperandType = rowi.Cells(6).Value.ToString(), .StackBehaviourPush = rowi.Cells(7).Value.ToString(),
                                                                                           .StackBehaviourPop = rowi.Cells(8).Value.ToString()}
                                                   ListofOpCodes.Add(temp)
                                               End SyncLock
                                           End Sub)
        Parallel.Invoke(Sub() File.WriteAllText(CachePath, JsonConvert.SerializeObject(ListofOpCodes, Formatting.Indented)))
        Cursor = Cursors.Default
    End Sub
    Private Sub LightToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ThemeResolutionService.ApplicationThemeName = "Fluent"
    End Sub

    Private Sub DarkToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ThemeResolutionService.ApplicationThemeName = "FluentDark"
    End Sub

    Private Sub LoadDefaultsMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Cursor = Cursors.WaitCursor
        DictofOpCodes.Clear()
        DictofOpCodes = OpCodes.Xor.GetAll
        Clear(CachePath)
        RadGridView.Rows.Clear()
        LoadtoDataGrid(0)
        Cursor = Cursors.Default
    End Sub
    Private Sub RadGridView_ContextMenuOpening(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.ContextMenuOpeningEventArgs) Handles RadGridView.ContextMenuOpening

        Dim LoadDefaultsMenuItem As New UI.RadMenuItem("Load Defaults")
        AddHandler LoadDefaultsMenuItem.Click, AddressOf LoadDefaultsMenuItem_Click
        e.ContextMenu.Items.Add(LoadDefaultsMenuItem)

        Dim SaveAllMenuItem As New UI.RadMenuItem("Save All")
        AddHandler SaveAllMenuItem.Click, AddressOf saveToolStripMenuItem_Click
        e.ContextMenu.Items.Add(SaveAllMenuItem)
        e.ContextMenu.Items.Add(New UI.RadMenuSeparatorItem())

        If ThemeResolutionService.ApplicationThemeName.Contains("FluentDark") Then
            Dim LightMenuItem As New UI.RadMenuItem("Light Theme")
            e.ContextMenu.Items.Add(LightMenuItem)
            AddHandler LightMenuItem.Click, AddressOf LightToolStripMenuItem_Click
        Else
            Dim DarkMenuItem As New UI.RadMenuItem("Dark Theme")
            e.ContextMenu.Items.Add(DarkMenuItem)
            AddHandler DarkMenuItem.Click, AddressOf DarkToolStripMenuItem_Click
        End If
    End Sub
    Private Sub Clear(Path As String)
        If File.Exists(Path) Then
            Try
                File.Delete(Path)
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim FilterDescriptor1 As Telerik.WinControls.Data.FilterDescriptor = New Telerik.WinControls.Data.FilterDescriptor()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.RadGridView = New Telerik.WinControls.UI.RadGridView()
        Me.FluentDarkTheme = New Telerik.WinControls.Themes.FluentDarkTheme()
        Me.FluentTheme = New Telerik.WinControls.Themes.FluentTheme()
        CType(Me.RadGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGridView
        '
        Me.RadGridView.AutoSizeRows = True
        Me.RadGridView.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.RadGridView.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGridView.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.RadGridView.ForeColor = System.Drawing.Color.White
        Me.RadGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.RadGridView.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        Me.RadGridView.MasterTemplate.AllowDragToGroup = False
        Me.RadGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "Name"
        GridViewTextBoxColumn1.HeaderText = "Name"
        GridViewTextBoxColumn1.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewTextBoxColumn1.MaxWidth = 115
        GridViewTextBoxColumn1.MinWidth = 85
        GridViewTextBoxColumn1.Name = "Name"
        GridViewTextBoxColumn1.Width = 110
        GridViewTextBoxColumn1.WrapText = True
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "Value"
        GridViewTextBoxColumn2.HeaderText = "Value"
        GridViewTextBoxColumn2.MaxWidth = 115
        GridViewTextBoxColumn2.MinWidth = 85
        GridViewTextBoxColumn2.Name = "Value"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn2.Width = 110
        GridViewTextBoxColumn2.WrapText = True
        GridViewTextBoxColumn3.AllowFiltering = False
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "Size"
        GridViewTextBoxColumn3.HeaderText = "Size"
        GridViewTextBoxColumn3.MaxWidth = 35
        GridViewTextBoxColumn3.MinWidth = 35
        GridViewTextBoxColumn3.Name = "Size"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn3.Width = 35
        GridViewTextBoxColumn3.WrapText = True
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "Info"
        GridViewTextBoxColumn4.HeaderText = "  Information (What is this operation code doing)"
        GridViewTextBoxColumn4.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewTextBoxColumn4.MinWidth = 150
        GridViewTextBoxColumn4.Name = "Info"
        GridViewTextBoxColumn4.Width = 439
        GridViewTextBoxColumn4.WrapText = True
        GridViewTextBoxColumn5.AllowFiltering = False
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "Type"
        GridViewTextBoxColumn5.HeaderText = "Type"
        GridViewTextBoxColumn5.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewTextBoxColumn5.MaxWidth = 80
        GridViewTextBoxColumn5.MinWidth = 80
        GridViewTextBoxColumn5.Name = "Type"
        GridViewTextBoxColumn5.Width = 80
        GridViewTextBoxColumn5.WrapText = True
        GridViewTextBoxColumn6.AllowFiltering = False
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "FlowControl"
        GridViewTextBoxColumn6.HeaderText = "FlowControl"
        GridViewTextBoxColumn6.MaxWidth = 90
        GridViewTextBoxColumn6.MinWidth = 90
        GridViewTextBoxColumn6.Name = "Flow Control"
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn6.WrapText = True
        GridViewTextBoxColumn7.AllowFiltering = False
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "OperandType"
        GridViewTextBoxColumn7.HeaderText = "OperandType"
        GridViewTextBoxColumn7.MaxWidth = 115
        GridViewTextBoxColumn7.MinWidth = 115
        GridViewTextBoxColumn7.Name = "Operand Type"
        GridViewTextBoxColumn7.Width = 115
        GridViewTextBoxColumn7.WrapText = True
        GridViewTextBoxColumn8.AllowFiltering = False
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "StackBehaviourPush"
        GridViewTextBoxColumn8.HeaderText = "Stack Behaviour Push"
        GridViewTextBoxColumn8.MaxWidth = 115
        GridViewTextBoxColumn8.MinWidth = 115
        GridViewTextBoxColumn8.Name = "StackBehaviourPush"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn8.Width = 115
        GridViewTextBoxColumn8.WrapText = True
        GridViewTextBoxColumn9.AllowFiltering = False
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "StackBehaviourPop"
        GridViewTextBoxColumn9.HeaderText = "Stack Behaviour Pop"
        GridViewTextBoxColumn9.MaxWidth = 115
        GridViewTextBoxColumn9.MinWidth = 115
        GridViewTextBoxColumn9.Name = "StackBehaviourPop"
        GridViewTextBoxColumn9.Width = 115
        GridViewTextBoxColumn9.WrapText = True
        Me.RadGridView.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9})
        Me.RadGridView.MasterTemplate.EnableAlternatingRowColor = True
        Me.RadGridView.MasterTemplate.EnableFiltering = True
        Me.RadGridView.MasterTemplate.EnableGrouping = False
        Me.RadGridView.MasterTemplate.FilterDescriptors.AddRange(New Telerik.WinControls.Data.FilterDescriptor() {FilterDescriptor1})
        Me.RadGridView.MasterTemplate.ShowFilterCellOperatorText = False
        Me.RadGridView.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.RadGridView.Name = "RadGridView"
        Me.RadGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView.ShowGroupPanel = False
        Me.RadGridView.Size = New System.Drawing.Size(1222, 436)
        Me.RadGridView.TabIndex = 0
        '
        'Myform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 436)
        Me.Controls.Add(Me.RadGridView)
        Me.Name = "Myform"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = ".Net All Opcodes"
        CType(Me.RadGridView.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadGridView As Telerik.WinControls.UI.RadGridView
    Friend WithEvents FluentDarkTheme As Telerik.WinControls.Themes.FluentDarkTheme
    Friend WithEvents FluentTheme As Telerik.WinControls.Themes.FluentTheme

End Class
