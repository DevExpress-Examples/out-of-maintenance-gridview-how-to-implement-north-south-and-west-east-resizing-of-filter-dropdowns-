using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using System.Drawing;
using System.Windows.Forms;

namespace DXApplication2
{
    internal class CustomComboBoxPopupListBoxForm : ComboBoxPopupListBoxForm
    {
        public CustomComboBoxPopupListBoxForm(ComboBoxEdit ownerEdit) : base(ownerEdit) { }
        protected new CustomPopupBaseSizeableFormViewInfo ViewInfo
        {
            get { return base.ViewInfo as CustomPopupBaseSizeableFormViewInfo; }
        }
        internal int GripThickness { get { return ViewInfo.gripThickness; } }
        protected override SizablePopupHelper CreateSizablePopupHelper()
        {
            return new CustomSizablePopupHelper(this);
        }
        protected override PopupBaseFormViewInfo CreateViewInfo()
        {
            return new CustomPopupBaseSizeableFormViewInfo(this);
        }
        protected override int CalcFormWidth(Size desiredSize, Size minSize)
        {
            return base.CalcFormWidth(desiredSize, minSize) + GripThickness;
        }
        internal static SizeGripPosition InvertGripPosition(SizeGripPosition gripPos)
        {
            switch (gripPos)
            {
                case SizeGripPosition.LeftBottom:
                    return SizeGripPosition.RightBottom;
                case SizeGripPosition.RightTop:
                    return SizeGripPosition.LeftTop;
                case SizeGripPosition.LeftTop:
                    return SizeGripPosition.RightTop;
                case SizeGripPosition.RightBottom:
                    return SizeGripPosition.LeftBottom;
            }
            return gripPos;
        }
        internal bool IsSizePoint(Point pt)
        {
            return IsGripPoint(pt) || IsSizeNSPoint(pt) || IsSizeWEPoint(pt);
        }
        internal bool IsGripPoint(Point pt)
        {
            if (!ViewInfo.ShowSizeGrip) return false;
            var rect = ViewInfo.SizeGripRect;
            return ((ViewInfo.IsLeftSizeGrip ? pt.X < rect.Right : pt.X > rect.Left)
                && (ViewInfo.IsTopSizeBar ? pt.Y < rect.Bottom : pt.Y > rect.Top));
        }
        internal bool IsSizeNSPoint(Point pt)
        {
            if (ViewInfo.IsTopSizeBar) return pt.Y < GripThickness;
            else return pt.Y > ClientRectangle.Height - GripThickness;
        }
        internal bool IsSizeWEPoint(Point pt)
        {
            if (ViewInfo.IsLeftSizeGrip) return pt.X < GripThickness;
            else return pt.X > ClientRectangle.Width - GripThickness;
        }
        internal Cursor GetGripCursor(Point pt)
        {
            if (IsGripPoint(pt))
                return Cursors.Default;
            else if (IsSizeNSPoint(pt))
                return Cursors.SizeNS;
            else if (IsSizeWEPoint(pt))
                return Cursors.SizeWE;
            else return Cursors.Default;
        }
    }

    internal class CustomPopupBaseSizeableFormViewInfo : PopupBaseSizeableFormViewInfo
    {
        internal readonly int gripThickness = 6;
        public CustomPopupBaseSizeableFormViewInfo(SimplePopupBaseForm form) : base(form as PopupBaseForm) { }
        internal new bool IsLeftSizeGrip { get { return base.IsLeftSizeGrip; } }
        protected override void UpdateSizeGripInfo()
        {
            var rect = SizeGripRect;
            rect.Offset(IsLeftSizeGrip ? -gripThickness : gripThickness, 0);
            SizeGripRect = rect;
            base.UpdateSizeGripInfo();
        }
        protected override void CalcContentRect(Rectangle bounds)
        {
            if (IsLeftSizeGrip) bounds.X += gripThickness;
            bounds.Width -= gripThickness;
            base.CalcContentRect(bounds);
        }
    }
}
