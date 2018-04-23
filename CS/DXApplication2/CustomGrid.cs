using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DXApplication2
{
    [ToolboxItem(true)]
    public class CustomGrid : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            return CreateView("CustomGridView");
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CustomGridViewInfoRegistrator());
        }
    }

    public class CustomGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName
        {
            get
            {
                return "CustomGridView";
            }
        }

        public override BaseView CreateView(GridControl grid)
        {
            return new CustomGridView(grid);
        }
    }

    public class CustomGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        public CustomGridView()
        {
        }

        public CustomGridView(GridControl grid) : base(grid)
        {
        }

        protected override string ViewName
        {
            get
            {
                return "CustomGridView";
            }
        }

        protected internal new GridEmbeddedLookAndFeel ElementsLookAndFeel { get { return base.ElementsLookAndFeel; } }

        protected override ColumnFilterPopup CreateFilterPopup(GridColumn column, Control ownerControl, object creator)
        {
            return new CustomColumnFilterPopup(this, column, ownerControl, creator);
        }
    }

    internal class CustomColumnFilterPopup : ColumnFilterPopup
    {
        public CustomColumnFilterPopup(ColumnView view, GridColumn column, Control owner, object creator) : base(view, column, owner, creator)
        {
        }
        public new CustomGridView View
        {
            get { return base.View as CustomGridView; }
        }
        protected override RepositoryItemPopupBase CreateRepositoryItem()
        {
            RepositoryItemFilterComboBox comboBox = new CustomRepositoryItemFilterComboBox(this);
            comboBox.LookAndFeel.Assign(View.ElementsLookAndFeel);
            comboBox.PopupSizeable = true;
            comboBox.DropDownRows = Math.Max(2, View.OptionsFilter.ColumnFilterPopupRowCount);
            return comboBox;
        }
    }

    internal class CustomRepositoryItemFilterComboBox : ColumnFilterPopup.RepositoryItemFilterComboBox
    {
        ColumnFilterPopup columnFilter;
        public CustomRepositoryItemFilterComboBox(ColumnFilterPopup columnFilter) : base(columnFilter)
        {
            this.columnFilter = columnFilter;
        }
        public override BaseEdit CreateEditor()
        {
            return new CustomFilterComboBox(columnFilter);
        }
    }

    internal class CustomFilterComboBox : ColumnFilterPopup.FilterComboBox
    {
        public CustomFilterComboBox(ColumnFilterPopup columnFilter) : base(columnFilter)
        {
        }
        protected override PopupBaseForm CreatePopupForm()
        {
            return new CustomComboBoxPopupListBoxForm(this);
        }
    }
}
