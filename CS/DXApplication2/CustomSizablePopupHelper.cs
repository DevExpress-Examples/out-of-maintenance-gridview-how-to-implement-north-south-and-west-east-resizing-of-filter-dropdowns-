using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Popup;
using System.Drawing;
using System.Windows.Forms;

namespace DXApplication2
{
    internal class CustomSizablePopupHelper : SizablePopupHelper
    {
        protected Point pointOffset;
        protected Cursor cursor = Cursors.Default;
        protected CustomComboBoxPopupListBoxForm popupListBoxForm
        {
            get { return Owner as CustomComboBoxPopupListBoxForm; }
        }
        public CustomSizablePopupHelper(IPopupSizeableForm owner) : base(owner) { }
        public override DXMouseEventArgs OnMouseMove(MouseEventArgs e)
        {
            DXMouseEventArgs ee = DXMouseEventArgs.GetMouseArgs(e);
            bool changeCursor = false;
            if (!ee.Handled)
            {
                if (Sizing)
                {
                    DoSizing(new Point(e.X, e.Y));
                    changeCursor = true;
                    ee.Handled = true;
                }
                else if (e.Button == MouseButtons.None && popupListBoxForm.IsSizePoint(e.Location))
                {
                    cursor = popupListBoxForm.GetGripCursor(e.Location);
                    changeCursor = true;
                    ee.Handled = true;
                }
                UpdateCursor(changeCursor);
            }
            return ee;
        }
        public override DXMouseEventArgs OnMouseDown(MouseEventArgs e)
        {
            DXMouseEventArgs ee = DXMouseEventArgs.GetMouseArgs(e);
            if (!ee.Handled)
            {
                if (ee.Button == MouseButtons.Left && e.Clicks == 1 && popupListBoxForm.IsSizePoint(e.Location))
                {
                    cursor = popupListBoxForm.GetGripCursor(e.Location);
                    ee.Handled = true;
                    StartSizing();
                }
            }
            return ee;
        }
        protected override void UpdateCursor(bool setSizing)
        {
            if (setSizing)
            {
                if (cursor == Cursors.Default)
                    Cursor.Current = Owner.CalcGripCursor(Owner.GripPosition);
                else
                    Cursor.Current = cursor;
            }
            else
                Cursor.Current = Owner.Form.Cursor;
        }
        protected override void StartSizing()
        {
            base.StartSizing();
            CalcPointOffset();
        }
        protected new void CalcPointOffset()
        {
            Point SizingCornerLocation = GetSizingCornerLocation();
            pointOffset = SizingCornerLocation;
            pointOffset.Offset(-Control.MousePosition.X, -Control.MousePosition.Y);
        }
        public override void DoSizing(Point p)
        {
            SizeGripPosition gp = Owner.GripPosition;
            if (Owner.Form.RightToLeftLayout)
                gp = CustomComboBoxPopupListBoxForm.InvertGripPosition(gp);
            if (cursor == Cursors.SizeNS)
            {
                if (gp == SizeGripPosition.LeftBottom || gp == SizeGripPosition.LeftTop)
                    p.X = SizingBounds.X;
                else
                    p.X = SizingBounds.Right;
                p.X = PointToClient(p).X;
            }
            else if (cursor == Cursors.SizeWE)
            {
                if (gp == SizeGripPosition.LeftBottom || gp == SizeGripPosition.RightBottom)
                    p.Y = SizingBounds.Bottom;
                else
                    p.Y = SizingBounds.Y;
                p.Y = PointToClient(p).Y;
            }
            base.DoSizing(p);
        }
        protected Point PointToClient(Point p)
        {
            if (!GetIsRightToLeftLayout())
            {
                p.Offset(-pointOffset.X, -pointOffset.Y);
                p = Owner.Form.PointToClient(p);
                return p;
            }
            p.Y -= SizingBounds.Y;
            p.X -= SizingBounds.X;
            p.X = SizingBounds.Width - p.X;
            return p;
        }
    }
}