Imports System.Data.SqlClient
Public Class catalogo
    Dim CONXcatalogo As SqlConnection
    Dim catalogosqlda As SqlDataAdapter
    Private Sub catalogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            sql = "SELECT CLAVE, DESCRIP FROM VARIOS ORDER BY CLAVE"

            CONXcatalogo = New SqlConnection(CONEXION_GASTOS)
            CONXcatalogo.Open()

            catalogosqlda = New SqlDataAdapter(sql, CONXcatalogo)
            Dim catalogods As DataSet = New DataSet()
            catalogosqlda.Fill(catalogods)
            DataGridView1.DataSource = catalogods.Tables(0)

            sql = ""
            CONXcatalogo.Close()
            catalogosqlda.Dispose()
            catalogods.Dispose()

        Catch ex As Exception
            sql = ""
            CONXcatalogo.Close()
            catalogosqlda.Dispose()
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub catalogo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Hide()
        Form2.Refresh()

    End Sub
End Class