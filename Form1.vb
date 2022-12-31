
Imports System.Data.SqlClient
Public Class Form1

    Dim logconex As SqlConnection

    Private Sub txtpassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpassword.KeyDown
        Try



            Select Case e.KeyData
                Case Keys.Enter
                    Label3.Text = "PROCESANDO..............."
                    Me.Refresh()
                    'Aqui tu codigo a ejecutar
                    logconex = New SqlConnection(CONEXION_DB)
                    logconex.Open()
                    sql = "select su.id_area,tc.nombre 'base_pago'	,rtrim(ltrim(su.nombre)) 'nombre'	,su.id_usuario,su.password,su.id_grupo from seguridad_usuarios su inner join  " &
                        "general_area ga on su.id_area = ga.id_area inner join desp_cliente_sucursal dcs on ga.id_area = dcs.id_area " &
                        "inner join trafico_cliente tc on dcs.id_cliente = tc.id_cliente where su.id_usuario ='" & txtusuario.Text & "' " &
                        "and su.password='" & txtpassword.Text & "' " &
                        "and (su.nombre COLLATE SQL_Latin1_General_CP1_CI_AS in (select usuario COLLATE SQL_Latin1_General_CP1_CI_AS from Gastos_extras.dbo.USUARIOS) " &
                        "or su.id_grupo like '%caja%')  and su.status='A' "

                    Dim logcom As SqlCommand
                    logcom = New SqlCommand
                    logcom.CommandText = sql
                    logcom.Connection = logconex
                    Dim logdr As SqlDataReader
                    logdr = logcom.ExecuteReader

                    If logdr.Read Then
                        usuario = logdr(3).ToString
                        nombre = logdr(2).ToString
                        moduio = logdr(5).ToString
                        usuario_basepago = logdr(1).ToString
                        Form2.PATIO = logdr(1).ToString
                        Form2.Show()
                        'Form2_LIS.PATIO = logdr(1).ToString
                        'Form2_LIS.Show()
                        Me.Hide()

                    Else
                        MsgBox("ACCESO DENAGADO....")
                    End If
                    logconex.Close()

                    Label3.Text = ""
                    Me.Refresh()

            End Select

        Catch ex As Exception
            Label3.Text = ""
            logconex.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtpassword_TextChanged(sender As Object, e As EventArgs) Handles txtpassword.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
