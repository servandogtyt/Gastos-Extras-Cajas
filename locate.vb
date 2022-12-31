Imports System.Data.SqlClient
Public Class locate
    Dim CONXLOCATE As SqlConnection
    Dim locatesqlda As SqlDataAdapter
    Private Sub locate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            If moduio.Equals("CAJA Y NOMINA") Or moduio.Equals("CAJA") Then

                sql = "select  Solicitud,Operador,Nombre,fecha_emi 'Fecha Emision',fECHA_PAGO 'Fecha Pago',BASE_PAGO 'Patio', VERIFICA 'AUTORIZA' from EXCEDE WHERE (ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL)" &
                "and base_pago='" & usuario_basepago & "'  AND VERIFICA IS NOT NULL   AND FECHA_EMI BETWEEN '" & Format(CDate(DateTimePicker1.Value), "yyyyMMdd") & "' AND '" & Format(CDate(DateTimePicker2.Value), "yyyyMMdd") & "' " &
                "group by Solicitud,Operador,Nombre,fecha_emi,fECHA_PAGO,BASE_PAGO,VERIFICA order by solicitud desc "

            Else

                sql = "select  Solicitud,Operador,Nombre,fecha_emi 'Fecha Emision',fECHA_PAGO 'Fecha Pago',BASE_PAGO 'Patio', VERIFICA 'AUTORIZA' from EXCEDE WHERE (ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL) " &
                    "AND FECHA_EMI BETWEEN '" & Format(CDate(DateTimePicker1.Value), "yyyyMMdd") & "' AND '" & Format(CDate(DateTimePicker2.Value), "yyyyMMdd") & "' " &
                    " group by Solicitud,Operador,Nombre,fecha_emi,fECHA_PAGO,BASE_PAGO,VERIFICA order by solicitud desc "

            End If


            CONXLOCATE = New SqlConnection(CONEXION_GASTOS)
            CONXLOCATE.Open()

            locatesqlda = New SqlDataAdapter(sql, CONXLOCATE)
            Dim locateds As DataSet = New DataSet()
            locatesqlda.Fill(locateds)
            DataGridView1.DataSource = locateds.Tables(0)

            sql = ""
            CONXLOCATE.Close()
            locatesqlda.Dispose()
            locateds.Dispose()

        Catch ex As Exception
            sql = ""
            CONXLOCATE.Close()
            locatesqlda.Dispose()
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub locate_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Hide()
        Form2.Refresh()
        Form2.Show()

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Form3.buscar(Convert.ToString(DataGridView1.CurrentRow.Cells(0).Value))
        Form2.actualizar_numeroregistros()

        If Form2.ultima_solicitud = Convert.ToString(DataGridView1.CurrentRow.Cells(0).Value) Then
            Form2.btnultimasol.Enabled = False
            Form2.btnsigsol.Enabled = False
        Else
            Form2.btnultimasol.Enabled = True
            Form2.btnsigsol.Enabled = True

        End If

        If Form2.primera_solicitud = Convert.ToString(DataGridView1.CurrentRow.Cells(0).Value) Then
            Form2.btnprimersol.Enabled = False
            Form2.btnantsol.Enabled = False

        Else
            Form2.btnprimersol.Enabled = True
            Form2.btnantsol.Enabled = True

        End If

        Form2.monto_total = CDbl(Form2.txtmonto1.Text) + CDbl(Form2.txtmonto2.Text) + CDbl(Form2.txtmonto3.Text) +
                CDbl(Form2.txtmonto4.Text) + CDbl(Form2.txtmonto5.Text) + CDbl(Form2.txtmonto6.Text) + CDbl(Form2.txtmonto7.Text) +
                CDbl(Form2.txtmonto8.Text)

        Form2.Label16.Text = "TOTAL PAGINA " & Format(Val(Form2.monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(Form2.SUMA_SOLICITUD), "###,###,##0.00")

        Me.Hide()
        Form2.Refresh()
        Form2.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Label4.Text = "PROCESANDO........................."

            If moduio.Equals("CAJA Y NOMINA") Or moduio.Equals("CAJA") Then
                sql = "select  Solicitud,Operador,Nombre,fecha_emi 'Fecha Emision',fECHA_PAGO 'Fecha Pago',BASE_PAGO 'Patio', VERIFICA 'AUTORIZA' from EXCEDE WHERE (ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL)" &
                "and base_pago='" & usuario_basepago & "'  AND VERIFICA IS NOT NULL  AND FECHA_EMI BETWEEN '" & Format(CDate(DateTimePicker1.Value), "yyyyMMdd") & "' AND '" & Format(CDate(DateTimePicker2.Value), "yyyyMMdd") & "' " &
                "group by Solicitud,Operador,Nombre,fecha_emi,fECHA_PAGO,BASE_PAGO,VERIFICA order by solicitud desc "

            Else

                sql = "select  Solicitud,Operador,Nombre,fecha_emi 'Fecha Emision',fECHA_PAGO 'Fecha Pago',BASE_PAGO 'Patio', VERIFICA 'AUTORIZA' from EXCEDE WHERE (ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL) " &
                    "AND FECHA_EMI BETWEEN '" & Format(CDate(DateTimePicker1.Value), "yyyyMMdd") & "' AND '" & Format(CDate(DateTimePicker2.Value), "yyyyMMdd") & "' " &
                    " group by Solicitud,Operador,Nombre,fecha_emi,fECHA_PAGO,BASE_PAGO,VERIFICA order by solicitud desc "

            End If

            CONXLOCATE = New SqlConnection(CONEXION_GASTOS)
            CONXLOCATE.Open()

            locatesqlda = New SqlDataAdapter(sql, CONXLOCATE)
            Dim locateds As DataSet = New DataSet()
            locatesqlda.Fill(locateds)
            DataGridView1.DataSource = locateds.Tables(0)

            sql = ""
            CONXLOCATE.Close()
            locatesqlda.Dispose()
            locateds.Dispose()
            Label4.Text = ""

        Catch ex As Exception
            sql = ""
            CONXLOCATE.Close()
            locatesqlda.Dispose()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class