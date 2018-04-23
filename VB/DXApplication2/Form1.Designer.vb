Namespace DXApplication2
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.customGrid1 = New DXApplication2.CustomGrid()
            Me.productsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.nWindDataSet = New DXApplication2.NWindDataSet()
            Me.customGridView1 = New DXApplication2.CustomGridView()
            Me.colProductID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colProductName = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colSupplierID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colCategoryID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colQuantityPerUnit = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colUnitsInStock = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colUnitsOnOrder = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colReorderLevel = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colDiscontinued = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.productsTableAdapter = New DXApplication2.NWindDataSetTableAdapters.ProductsTableAdapter()
            DirectCast(Me.customGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.productsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.nWindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.customGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' customGrid1
            ' 
            Me.customGrid1.DataSource = Me.productsBindingSource
            Me.customGrid1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.customGrid1.Location = New System.Drawing.Point(0, 0)
            Me.customGrid1.MainView = Me.customGridView1
            Me.customGrid1.Name = "customGrid1"
            Me.customGrid1.Size = New System.Drawing.Size(632, 278)
            Me.customGrid1.TabIndex = 0
            Me.customGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.customGridView1})
            ' 
            ' productsBindingSource
            ' 
            Me.productsBindingSource.DataMember = "Products"
            Me.productsBindingSource.DataSource = Me.nWindDataSet
            ' 
            ' nWindDataSet
            ' 
            Me.nWindDataSet.DataSetName = "NWindDataSet"
            Me.nWindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' customGridView1
            ' 
            Me.customGridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colProductID, Me.colProductName, Me.colSupplierID, Me.colCategoryID, Me.colQuantityPerUnit, Me.colUnitPrice, Me.colUnitsInStock, Me.colUnitsOnOrder, Me.colReorderLevel, Me.colDiscontinued})
            Me.customGridView1.GridControl = Me.customGrid1
            Me.customGridView1.Name = "customGridView1"
            ' 
            ' colProductID
            ' 
            Me.colProductID.FieldName = "ProductID"
            Me.colProductID.Name = "colProductID"
            Me.colProductID.Visible = True
            Me.colProductID.VisibleIndex = 0
            ' 
            ' colProductName
            ' 
            Me.colProductName.FieldName = "ProductName"
            Me.colProductName.Name = "colProductName"
            Me.colProductName.Visible = True
            Me.colProductName.VisibleIndex = 1
            ' 
            ' colSupplierID
            ' 
            Me.colSupplierID.FieldName = "SupplierID"
            Me.colSupplierID.Name = "colSupplierID"
            Me.colSupplierID.Visible = True
            Me.colSupplierID.VisibleIndex = 2
            ' 
            ' colCategoryID
            ' 
            Me.colCategoryID.FieldName = "CategoryID"
            Me.colCategoryID.Name = "colCategoryID"
            Me.colCategoryID.Visible = True
            Me.colCategoryID.VisibleIndex = 3
            ' 
            ' colQuantityPerUnit
            ' 
            Me.colQuantityPerUnit.FieldName = "QuantityPerUnit"
            Me.colQuantityPerUnit.Name = "colQuantityPerUnit"
            Me.colQuantityPerUnit.Visible = True
            Me.colQuantityPerUnit.VisibleIndex = 4
            ' 
            ' colUnitPrice
            ' 
            Me.colUnitPrice.FieldName = "UnitPrice"
            Me.colUnitPrice.Name = "colUnitPrice"
            Me.colUnitPrice.Visible = True
            Me.colUnitPrice.VisibleIndex = 5
            ' 
            ' colUnitsInStock
            ' 
            Me.colUnitsInStock.FieldName = "UnitsInStock"
            Me.colUnitsInStock.Name = "colUnitsInStock"
            Me.colUnitsInStock.Visible = True
            Me.colUnitsInStock.VisibleIndex = 6
            ' 
            ' colUnitsOnOrder
            ' 
            Me.colUnitsOnOrder.FieldName = "UnitsOnOrder"
            Me.colUnitsOnOrder.Name = "colUnitsOnOrder"
            Me.colUnitsOnOrder.Visible = True
            Me.colUnitsOnOrder.VisibleIndex = 7
            ' 
            ' colReorderLevel
            ' 
            Me.colReorderLevel.FieldName = "ReorderLevel"
            Me.colReorderLevel.Name = "colReorderLevel"
            Me.colReorderLevel.Visible = True
            Me.colReorderLevel.VisibleIndex = 8
            ' 
            ' colDiscontinued
            ' 
            Me.colDiscontinued.FieldName = "Discontinued"
            Me.colDiscontinued.Name = "colDiscontinued"
            Me.colDiscontinued.Visible = True
            Me.colDiscontinued.VisibleIndex = 9
            ' 
            ' productsTableAdapter
            ' 
            Me.productsTableAdapter.ClearBeforeFill = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(632, 278)
            Me.Controls.Add(Me.customGrid1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.customGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.productsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.nWindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.customGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private customGrid1 As CustomGrid
        Private customGridView1 As CustomGridView
        Private nWindDataSet As NWindDataSet
        Private productsBindingSource As System.Windows.Forms.BindingSource
        Private productsTableAdapter As NWindDataSetTableAdapters.ProductsTableAdapter
        Private colProductID As DevExpress.XtraGrid.Columns.GridColumn
        Private colProductName As DevExpress.XtraGrid.Columns.GridColumn
        Private colSupplierID As DevExpress.XtraGrid.Columns.GridColumn
        Private colCategoryID As DevExpress.XtraGrid.Columns.GridColumn
        Private colQuantityPerUnit As DevExpress.XtraGrid.Columns.GridColumn
        Private colUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
        Private colUnitsInStock As DevExpress.XtraGrid.Columns.GridColumn
        Private colUnitsOnOrder As DevExpress.XtraGrid.Columns.GridColumn
        Private colReorderLevel As DevExpress.XtraGrid.Columns.GridColumn
        Private colDiscontinued As DevExpress.XtraGrid.Columns.GridColumn
    End Class
End Namespace

