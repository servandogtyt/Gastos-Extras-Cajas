Imports System.ComponentModel
Imports System.Drawing.Printing
Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try


            'TODO: esta línea de código carga datos en la tabla 'GASTOS_EXTRASDataSet.x_solicitud_IMPRESION' Puede moverla o quitarla según sea necesario.
            'Me.x_solicitud_IMPRESIONTableAdapter.Fill(Me.GASTOS_EXTRASDataSet.x_solicitud_IMPRESION)
            'TODO: esta línea de código carga datos en la tabla 'GASTOS_EXTRASDataSet1.x_solicitud_IMPRESION_1' Puede moverla o quitarla según sea necesario.
            'Me.x_solicitud_IMPRESION_1TableAdapter.Fill(Me.GASTOS_EXTRASDataSet1.x_solicitud_IMPRESION_1)
            ''TODO: esta línea de código carga datos en la tabla 'GASTOS_EXTRASDataSet.x_solicitud_IMPRESION' Puede moverla o quitarla según sea necesario.
            Me.x_solicitud_IMPRESIONTableAdapter.Fill(Me.GASTOS_EXTRASDataSet.x_solicitud_IMPRESION, solicitud_, nombre, "", 1, "")
            ''TODO: esta línea de código carga datos en la tabla 'GASTOS_EXTRASDataSet1.x_solicitud_IMPRESION_1' Puede moverla o quitarla según sea necesario.
            Me.x_solicitud_IMPRESION_1TableAdapter.Fill(Me.GASTOS_EXTRASDataSet1.x_solicitud_IMPRESION_1, solicitud_)


            Dim pg As PageSettings = New PageSettings
            'pg.Margins.Left = 40
            'pg.Margins.Right = 40
            'pg.Margins.Top = 40
            'pg.Margins.Bottom = 40
            'Me.ReportViewer1.SetPageSettings(pg)
            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Form4_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form2.actualizar_numeroregistros()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class