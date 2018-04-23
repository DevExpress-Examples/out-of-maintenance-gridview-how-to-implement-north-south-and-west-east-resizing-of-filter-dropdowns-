Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Popup
Imports System.Drawing
Imports System.Windows.Forms

Namespace DXApplication2
    Friend Class CustomComboBoxPopupListBoxForm
        Inherits ComboBoxPopupListBoxForm

        Public Sub New(ByVal ownerEdit As ComboBoxEdit)
            MyBase.New(ownerEdit)
        End Sub
        Protected Shadows ReadOnly Property ViewInfo() As CustomPopupBaseSizeableFormViewInfo
            Get
                Return TryCast(MyBase.ViewInfo, CustomPopupBaseSizeableFormViewInfo)
            End Get
        End Property
        Friend ReadOnly Property GripThickness() As Integer
            Get
                Return ViewInfo.gripThickness
            End Get
        End Property
        Protected Overrides Function CreateSizablePopupHelper() As SizablePopupHelper
            Return New CustomSizablePopupHelper(Me)
        End Function
        Protected Overrides Function CreateViewInfo() As PopupBaseFormViewInfo
            Return New CustomPopupBaseSizeableFormViewInfo(Me)
        End Function
        Protected Overrides Function CalcFormWidth(ByVal desiredSize As Size, ByVal minSize As Size) As Integer
            Return MyBase.CalcFormWidth(desiredSize, minSize) + GripThickness
        End Function
        Friend Shared Function InvertGripPosition(ByVal gripPos As SizeGripPosition) As SizeGripPosition
            Select Case gripPos
                Case SizeGripPosition.LeftBottom
                    Return SizeGripPosition.RightBottom
                Case SizeGripPosition.RightTop
                    Return SizeGripPosition.LeftTop
                Case SizeGripPosition.LeftTop
                    Return SizeGripPosition.RightTop
                Case SizeGripPosition.RightBottom
                    Return SizeGripPosition.LeftBottom
            End Select
            Return gripPos
        End Function
        Friend Function IsSizePoint(ByVal pt As Point) As Boolean
            Return IsGripPoint(pt) OrElse IsSizeNSPoint(pt) OrElse IsSizeWEPoint(pt)
        End Function
        Friend Function IsGripPoint(ByVal pt As Point) As Boolean
            If Not ViewInfo.ShowSizeGrip Then
                Return False
            End If
            Dim rect = ViewInfo.SizeGripRect
            Return ((If(ViewInfo.IsLeftSizeGrip, pt.X < rect.Right, pt.X > rect.Left)) AndAlso (If(ViewInfo.IsTopSizeBar, pt.Y < rect.Bottom, pt.Y > rect.Top)))
        End Function
        Friend Function IsSizeNSPoint(ByVal pt As Point) As Boolean
            If ViewInfo.IsTopSizeBar Then
                Return pt.Y < GripThickness
            Else
                Return pt.Y > ClientRectangle.Height - GripThickness
            End If
        End Function
        Friend Function IsSizeWEPoint(ByVal pt As Point) As Boolean
            If ViewInfo.IsLeftSizeGrip Then
                Return pt.X < GripThickness
            Else
                Return pt.X > ClientRectangle.Width - GripThickness
            End If
        End Function
        Friend Function GetGripCursor(ByVal pt As Point) As Cursor
            If IsGripPoint(pt) Then
                Return Cursors.Default
            ElseIf IsSizeNSPoint(pt) Then
                Return Cursors.SizeNS
            ElseIf IsSizeWEPoint(pt) Then
                Return Cursors.SizeWE
            Else
                Return Cursors.Default
            End If
        End Function
    End Class

    Friend Class CustomPopupBaseSizeableFormViewInfo
        Inherits PopupBaseSizeableFormViewInfo

        Friend ReadOnly gripThickness As Integer = 6
        Public Sub New(ByVal form As SimplePopupBaseForm)
            MyBase.New(TryCast(form, PopupBaseForm))
        End Sub
        Friend Shadows ReadOnly Property IsLeftSizeGrip() As Boolean
            Get
                Return MyBase.IsLeftSizeGrip
            End Get
        End Property
        Protected Overrides Sub UpdateSizeGripInfo()
            Dim rect = SizeGripRect
            rect.Offset(If(IsLeftSizeGrip, -gripThickness, gripThickness), 0)
            SizeGripRect = rect
            MyBase.UpdateSizeGripInfo()
        End Sub
        Protected Overrides Sub CalcContentRect(ByVal bounds As Rectangle)
            If IsLeftSizeGrip Then
                bounds.X += gripThickness
            End If
            bounds.Width -= gripThickness
            MyBase.CalcContentRect(bounds)
        End Sub
    End Class
End Namespace
