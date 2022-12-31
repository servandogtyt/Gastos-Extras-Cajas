Imports System.Data.SqlClient
Public Class liquidaciones
    Public NUM_OPERADOR_LIQUIDACION = ""

    Dim DA_LIQUIDACION As SqlDataAdapter
    Dim SQL_LIQUIDACION As String
    Dim TABLE_LIQUIDACION As DataTable
    Dim CONEX_LIQUIDACION As SqlConnection
    Dim comentarios As String = ""
    Private Sub liquidaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        CONEX_LIQUIDACION = New SqlConnection(CONEXION_DB)
        CONEX_LIQUIDACION.Open()

        SQL_LIQUIDACION =
            "SELECT trafico_liquidacion.id_area,(SELECT NOMBRE	FROM general_area WHERE id_area = trafico_liquidacion.id_area) PATIO,trafico_liquidacion.no_liquidacion LIQUIDACION,trafico_liquidacion.fecha_liquidacion 'FECHA LIQUIDACION' " &
            ",trafico_liquidacion.comentarios FROM trafico_liquidacion	,personal_personal " &
            "WHERE (trafico_liquidacion.id_personal = personal_personal.id_personal)	" &
            "AND (year(trafico_liquidacion.fecha_liquidacion) = YEAR(GETDATE())OR year(trafico_liquidacion.fecha_liquidacion) = YEAR(GETDATE()) - 1)	    " &
            "AND personal_personal.id_personal = " & NUM_OPERADOR_LIQUIDACION & " 	AND trafico_liquidacion.status_liq <> 'C' " &
            "ORDER BY trafico_liquidacion.fecha_liquidacion DESC"

        DA_LIQUIDACION = New SqlDataAdapter(SQL_LIQUIDACION, CONEX_LIQUIDACION)
        TABLE_LIQUIDACION = New DataTable
        DA_LIQUIDACION.Fill(TABLE_LIQUIDACION)
        If TABLE_LIQUIDACION.Rows.Count = 0 Then
            Me.Close()
        End If

        DataGridView1.DataSource = TABLE_LIQUIDACION
        CONEX_LIQUIDACION.Close()



    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim GASTO_LIQUIDACION = 0
        Dim AREA_liquidaciones = 0

        If Not IsDBNull(DataGridView1.Rows(e.RowIndex).Cells(2).Value) Then
            GASTO_LIQUIDACION = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        Else
            GASTO_LIQUIDACION = 0
        End If
        If Not IsDBNull(DataGridView1.Rows(e.RowIndex).Cells(0).Value) Then
            AREA_liquidaciones = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        Else
            AREA_liquidaciones = 0
        End If
        If Not IsDBNull(DataGridView1.Rows(e.RowIndex).Cells(4).Value) Then
            comentarios = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        Else
            comentarios = ""
        End If

        CONEX_LIQUIDACION = New SqlConnection(CONEXION_DB)
        CONEX_LIQUIDACION.Open()

        SQL_LIQUIDACION =
            "SELECT trafico_renglon_liquidacion.no_liquidacion	,trafico_renglon_liquidacion.id_concepto,trafico_renglon_liquidacion.desc_concepto	,trafico_renglon_liquidacion.monto_concepto" &
            ",trafico_renglon_liquidacion.iva_concepto	,trafico_renglon_liquidacion.monto_concepto + trafico_renglon_liquidacion.iva_concepto total_concepto,trafico_renglon_liquidacion.cantidad" &
            ",trafico_concepto.iva_concepto	,trafico_renglon_liquidacion.no_viaje	,(SELECT nombre FROM GENERAL_AREA WHERE ID_AREA=trafico_renglon_liquidacion.id_area) area	,trafico_renglon_liquidacion.imp_concepto	,trafico_renglon_liquidacion.id_areaviaje" &
            ",trafico_renglon_liquidacion.factura	,trafico_renglon_liquidacion.factura_iave	FROM trafico_renglon_liquidacion	,trafico_concepto " &
            "WHERE (trafico_renglon_liquidacion.id_concepto = trafico_concepto.id_concepto) 	AND ((trafico_renglon_liquidacion.id_area = " & AREA_liquidaciones & ") 	AND 	(trafico_renglon_liquidacion.no_liquidacion = " & GASTO_LIQUIDACION & ")	)" &
            "ORDER BY trafico_renglon_liquidacion.consecutivo ASC"

        DA_LIQUIDACION = New SqlDataAdapter(SQL_LIQUIDACION, CONEX_LIQUIDACION)
        TABLE_LIQUIDACION = New DataTable
        DA_LIQUIDACION.Fill(TABLE_LIQUIDACION)
        DataGridView2.DataSource = TABLE_LIQUIDACION
        CONEX_LIQUIDACION.Close()
    End Sub

    Private Sub DataGridView2_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Dim AREA_liquidaciones_gasto = ""
        Dim num_liquidaciones_gasto = 0
        Dim descripciongasto = ""
        Dim txtmonto As Double = 0
        Dim factura = ""

        If IsDBNull(DataGridView2.Rows(e.RowIndex).Cells(2).Value) Then
            descripciongasto = ""
        Else
            descripciongasto = DataGridView2.Rows(e.RowIndex).Cells(2).Value
        End If
        If IsDBNull(DataGridView2.Rows(e.RowIndex).Cells(9).Value) Then
            AREA_liquidaciones_gasto = ""
        Else
            AREA_liquidaciones_gasto = DataGridView2.Rows(e.RowIndex).Cells(9).Value
        End If
        If IsDBNull(DataGridView2.Rows(e.RowIndex).Cells(0).Value) Then
            num_liquidaciones_gasto = 0
        Else
            num_liquidaciones_gasto = DataGridView2.Rows(e.RowIndex).Cells(0).Value
        End If
        If IsDBNull(DataGridView2.Rows(e.RowIndex).Cells(5).Value) Then
            txtmonto = 0
        Else
            txtmonto = DataGridView2.Rows(e.RowIndex).Cells(5).Value
        End If

        If Form2_LIS.cbdescripciongastos1.Text = "LIQUIDACION" Then
            Form2_LIS.cbdescripciongastos1.Text = descripciongasto
            Form2_LIS.txtmonto1.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
            Form2_LIS.txtliquidacion1.Text = num_liquidaciones_gasto
            Form2_LIS.txtarealiq1.Text = AREA_liquidaciones_gasto
            Form2_LIS.txtcausa1.Text = comentarios

        ElseIf Form2_LIS.cbdescripciongastos2.Text = "LIQUIDACION" Then
            Form2_LIS.cbdescripciongastos2.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            Form2_LIS.txtmonto2.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
            Form2_LIS.txtcausa2.Text = "LIQUIDACION:" & num_liquidaciones_gasto & " " & comentarios

        ElseIf Form2_LIS.cbdescripciongastos3.Text = "LIQUIDACION" Then
            Form2_LIS.cbdescripciongastos3.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            Form2_LIS.txtmonto3.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
            Form2_LIS.txtcausa3.Text = "LIQUIDACION:" & num_liquidaciones_gasto & " " & comentarios

        ElseIf Form2_LIS.cbdescripciongastos4.Text = "LIQUIDACION" Then

            Form2_LIS.cbdescripciongastos4.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            Form2_LIS.txtmonto4.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
            Form2_LIS.txtcausa4.Text = "LIQUIDACION:" & num_liquidaciones_gasto & " " & comentarios

        ElseIf Form2_LIS.cbdescripciongastos5.Text = "LIQUIDACION" Then
            Form2_LIS.cbdescripciongastos5.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            Form2_LIS.txtmonto5.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
            Form2_LIS.txtcausa5.Text = "LIQUIDACION:" & num_liquidaciones_gasto & " " & comentarios

        ElseIf Form2_LIS.cbdescripciongastos6.Text = "LIQUIDACION" Then
            Form2_LIS.cbdescripciongastos6.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            Form2_LIS.txtmonto6.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
            Form2_LIS.txtcausa6.Text = "LIQUIDACION:" & num_liquidaciones_gasto & " " & comentarios

        ElseIf Form2_LIS.cbdescripciongastos7.Text = "LIQUIDACION" Then
            Form2_LIS.cbdescripciongastos7.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            Form2_LIS.txtmonto7.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
            Form2_LIS.txtcausa7.Text = "LIQUIDACION:" & num_liquidaciones_gasto & " " & comentarios

        ElseIf Form2_LIS.cbdescripciongastos8.Text = "LIQUIDACION" Then
            Form2_LIS.cbdescripciongastos8.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            Form2_LIS.txtmonto8.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
            Form2_LIS.txtcausa8.Text = "LIQUIDACION:" & num_liquidaciones_gasto & " " & comentarios

        End If

        Me.Close()

    End Sub
End Class