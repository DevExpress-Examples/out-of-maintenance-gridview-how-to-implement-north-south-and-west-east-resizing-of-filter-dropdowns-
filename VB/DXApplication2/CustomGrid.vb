Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace DXApplication2
    <ToolboxItem(True)> _
    Public Class CustomGrid
        Inherits GridControl

        Protected Overrides Function CreateDefaultView() As BaseView
            Return CreateView("CustomGridView")
        End Function

        Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
            MyBase.RegisterAvailableViewsCore(collection)
            collection.Add(New CustomGridViewInfoRegistrator())
        End Sub
    End Class

    Public Class CustomGridViewInfoRegistrator
        Inherits GridInfoRegistrator

        Public Overrides ReadOnly Property ViewName() As String
            Get
                Return "CustomGridView"
            End Get
        End Property

        Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
            Return New CustomGridView(grid)
        End Function
    End Class

    Public Class CustomGridView
        Inherits DevExpress.XtraGrid.Views.Grid.GridView

        Public Sub New()
        End Sub

        Public Sub New(ByVal grid As GridControl)
            MyBase.New(grid)
        End Sub

        Protected Overrides ReadOnly Property ViewName() As String
            Get
                Return "CustomGridView"
            End Get
        End Property

        Protected Friend Shadows ReadOnly Property ElementsLookAndFeel() As GridEmbeddedLookAndFeel
            Get
                Return MyBase.ElementsLookAndFeel
            End Get
        End Property

        Protected Overrides Function CreateFilterPopup(ByVal column As GridColumn, ByVal ownerControl As Control, ByVal creator As Object) As ColumnFilterPopup
            Return New CustomColumnFilterPopup(Me, column, ownerControl, creator)
        End Function
    End Class

    Friend Class CustomColumnFilterPopup
        Inherits ColumnFilterPopup

        Public Sub New(ByVal view As ColumnView, ByVal column As GridColumn, ByVal owner As Control, ByVal creator As Object)
            MyBase.New(view, column, owner, creator)
        End Sub
        Public Shadows ReadOnly Property View() As CustomGridView
            Get
                Return TryCast(MyBase.View, CustomGridView)
            End Get
        End Property
        Protected Overrides Function CreateRepositoryItem() As RepositoryItemPopupBase
            Dim comboBox As RepositoryItemFilterComboBox = New CustomRepositoryItemFilterComboBox(Me)
            comboBox.LookAndFeel.Assign(View.ElementsLookAndFeel)
            comboBox.PopupSizeable = True
            comboBox.DropDownRows = Math.Max(2, View.OptionsFilter.ColumnFilterPopupRowCount)
            Return comboBox
        End Function
    End Class

    Friend Class CustomRepositoryItemFilterComboBox
        Inherits ColumnFilterPopup.RepositoryItemFilterComboBox

        Private columnFilter As ColumnFilterPopup
        Public Sub New(ByVal columnFilter As ColumnFilterPopup)
            MyBase.New(columnFilter)
            Me.columnFilter = columnFilter
        End Sub
        Public Overrides Function CreateEditor() As BaseEdit
            Return New CustomFilterComboBox(columnFilter)
        End Function
    End Class

    Friend Class CustomFilterComboBox
        Inherits ColumnFilterPopup.FilterComboBox

        Public Sub New(ByVal columnFilter As ColumnFilterPopup)
            MyBase.New(columnFilter)
        End Sub
        Protected Overrides Function CreatePopupForm() As PopupBaseForm
            Return New CustomComboBoxPopupListBoxForm(Me)
        End Function
    End Class
End Namespace
