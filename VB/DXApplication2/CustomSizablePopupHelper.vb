Imports DevExpress.Utils
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.Popup
Imports System.Drawing
Imports System.Windows.Forms

Namespace DXApplication2
    Friend Class CustomSizablePopupHelper
        Inherits SizablePopupHelper

        Protected pointOffset As Point
        Protected cursor As Cursor = Cursors.Default
        Protected ReadOnly Property popupListBoxForm() As CustomComboBoxPopupListBoxForm
            Get
                Return TryCast(Owner, CustomComboBoxPopupListBoxForm)
            End Get
        End Property
        Public Sub New(ByVal owner As IPopupSizeableForm)
            MyBase.New(owner)
        End Sub
        Public Overrides Function OnMouseMove(ByVal e As MouseEventArgs) As DXMouseEventArgs
            Dim ee As DXMouseEventArgs = DXMouseEventArgs.GetMouseArgs(e)
            Dim changeCursor As Boolean = False
            If Not ee.Handled Then
                If Sizing Then
                    DoSizing(New Point(e.X, e.Y))
                    changeCursor = True
                    ee.Handled = True
                ElseIf e.Button = MouseButtons.None AndAlso popupListBoxForm.IsSizePoint(e.Location) Then
                    cursor = popupListBoxForm.GetGripCursor(e.Location)
                    changeCursor = True
                    ee.Handled = True
                End If
                UpdateCursor(changeCursor)
            End If
            Return ee
        End Function
        Public Overrides Function OnMouseDown(ByVal e As MouseEventArgs) As DXMouseEventArgs
            Dim ee As DXMouseEventArgs = DXMouseEventArgs.GetMouseArgs(e)
            If Not ee.Handled Then
                If ee.Button = MouseButtons.Left AndAlso e.Clicks = 1 AndAlso popupListBoxForm.IsSizePoint(e.Location) Then
                    cursor = popupListBoxForm.GetGripCursor(e.Location)
                    ee.Handled = True
                    StartSizing()
                End If
            End If
            Return ee
        End Function
        Protected Overrides Sub UpdateCursor(ByVal setSizing As Boolean)
            If setSizing Then
                If cursor = Cursors.Default Then
                    System.Windows.Forms.Cursor.Current = Owner.CalcGripCursor(Owner.GripPosition)
                Else
                    System.Windows.Forms.Cursor.Current = cursor
                End If
            Else
                System.Windows.Forms.Cursor.Current = Owner.Form.Cursor
            End If
        End Sub
        Protected Overrides Sub StartSizing()
            MyBase.StartSizing()
            CalcPointOffset()
        End Sub
        Protected Shadows Sub CalcPointOffset()
            Dim SizingCornerLocation As Point = GetSizingCornerLocation()
            pointOffset = SizingCornerLocation
            pointOffset.Offset(-Control.MousePosition.X, -Control.MousePosition.Y)
        End Sub
        Public Overrides Sub DoSizing(ByVal p As Point)
            Dim gp As SizeGripPosition = Owner.GripPosition
            If Owner.Form.RightToLeftLayout Then
                gp = CustomComboBoxPopupListBoxForm.InvertGripPosition(gp)
            End If
            If cursor = Cursors.SizeNS Then
                If gp = SizeGripPosition.LeftBottom OrElse gp = SizeGripPosition.LeftTop Then
                    p.X = SizingBounds.X
                Else
                    p.X = SizingBounds.Right
                End If
                p.X = PointToClient(p).X
            ElseIf cursor = Cursors.SizeWE Then
                If gp = SizeGripPosition.LeftBottom OrElse gp = SizeGripPosition.RightBottom Then
                    p.Y = SizingBounds.Bottom
                Else
                    p.Y = SizingBounds.Y
                End If
                p.Y = PointToClient(p).Y
            End If
            MyBase.DoSizing(p)
        End Sub
        Protected Function PointToClient(ByVal p As Point) As Point
            If Not GetIsRightToLeftLayout() Then
                p.Offset(-pointOffset.X, -pointOffset.Y)
                p = Owner.Form.PointToClient(p)
                Return p
            End If
            p.Y -= SizingBounds.Y
            p.X -= SizingBounds.X
            p.X = SizingBounds.Width - p.X
            Return p
        End Function
    End Class
End Namespace