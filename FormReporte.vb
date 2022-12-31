Imports wFcLibrary1_REPORTE_GASTOS_EXTRAS
Imports System.Data.SqlClient
Imports Microsoft.ReportingServices.Rendering.ExcelRenderer
Imports Microsoft
Imports Microsoft.Office.Interop.Excel
Imports System.Data

Public Class FormReporte
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim data As String
            Label5.Text = "PROCESANDO............................"
            Me.Refresh()
            If VALIDAR_DATOS() = False Then
                Label5.Text = ""
                Me.Refresh()
                Exit Sub
            End If

            If ComboBox1.Text = "PAGADOS Y NO PAGADOS" Then
                'pagynopag(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)
                PRUEBAS_PAGADO_NOPAGADO(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)

            ElseIf ComboBox1.Text = "PAGADOS" Then
                'pagados_O_NOPAGADOS(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)
                PRUEBAS_PAGADO_NOPAGADO(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)

            ElseIf ComboBox1.Text = "NO PAGADOS" Then
                'pagados_O_NOPAGADOS(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)
                PRUEBAS_PAGADO_NOPAGADO(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)

            ElseIf ComboBox1.Text = "REPORTES" Then
                MULTASEINFRACCCIONES_NUEVO(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)

            ElseIf ComboBox1.Text = "PRUEBA PAGADO" Then
                'pagados_O_NOPAGADOS(cbporpatio.Text, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)
                'MULTASEINFRACCCIONES_NUEVO(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)
                'PRUEBAS_PAGADO_NOPAGADO(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)

            ElseIf ComboBox1.Text = "PRUEBA NO PAGADO" Then
                'pagados_O_NOPAGADOS(cbporpatio.Text, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)
                'MULTASEINFRACCCIONES_NUEVO(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)
                'PRUEBAS_PAGADO_NOPAGADO(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)

            ElseIf ComboBox1.Text = "GASTOS EXTRAS PAGADOS" Then
                ordenado(cbporpatio.Text, cbporgasto.SelectedValue, cbporgasto1.SelectedValue, cbporchofer.SelectedValue, cbporchofer1.SelectedValue, DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"), DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"), ComboBox1.Text)
                Dim reporte As Form1DLL = New Form1DLL With {
                .tipo = ComboBox1.Text,
                .PATIO = cbporpatio.Text,
                .f_ini = DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000"),
                .f_fin = DateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00.000"),
                .sql_query = sql,
                .ordenar = cbordenar.Text
            }

                reporte.Show()
                reporte.WindowState = FormWindowState.Maximized

            Else
                MsgBox("DEBE SELECCIONAR TIPO DE REPORTE")
            End If

            Label5.Text = ""
            'Me.Hide()

        Catch ex As Exception
            Label5.Text = ""
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub FormReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try


            Dim conexsql_SUTRANSPORTE = New SqlConnection(CONEXION_DB)
            Dim conexsql_REPORT_PAGADO = New SqlConnection(CONEXION_GASTOS)
            conexsql_REPORT_PAGADO.Open()
            conexsql_SUTRANSPORTE.Open()

            Dim sqlda_REPORT_PAGADO As SqlDataAdapter
            Dim ds_REPORT_PAGADO As DataSet = New DataSet
            Dim ds_CHOFERES As DataSet = New DataSet
            Dim ds_CHOFERES1 As DataSet = New DataSet
            Dim ds_gastos As DataSet = New DataSet
            Dim ds_gastos1 As DataSet = New DataSet

            'Dim sql_REPORT_PAGADO = "SELECT * FROM (SELECT TC.nombre ciudad FROM trafico_cliente TC INNER JOIN desp_cliente_sucursal DCS ON TC.id_cliente = DCS.id_cliente " &
            '                           "UNION ALL SELECT 'TODO')D1 ORDER BY D1.ciudad DESC"

            Dim sql_REPORT_PAGADO = "select patio from patios_lis where encargado<>'' union all SELECT 'TODOS' "

            sqlda_REPORT_PAGADO = New SqlDataAdapter(sql_REPORT_PAGADO, conexsql_REPORT_PAGADO)
            sqlda_REPORT_PAGADO.Fill(ds_REPORT_PAGADO)

            cbporpatio.DataSource = ds_REPORT_PAGADO.Tables(0)
            cbporpatio.DisplayMember = "patio"
            cbporpatio.ValueMember = "patio"
            cbporpatio.Text = "SELECCIONE ......"
            ComboBox1.Text = "SELECCIONE ......"

            Dim CHOFERES = " select pp.id_personal, CONCAT(pp.id_personal, ' ', pp.nombre) as NOMBRE from trafico_guia as tg 
                            inner join personal_personal as pp on pp.id_personal = tg.id_personal UNION select '', 
                            'TODOS' order by pp.id_personal"

            'Dim CHOFERES = "SELECT * FROM (SELECT  pp.id_personal, pp.Nombre FROM trafico_guia tg " &
            '    "INNER JOIN personal_personal pp ON tg.id_personal = pp.id_personal " &
            '    "WHERE  status_guia<>'C' GROUP BY pp.id_personal,pp.nombre " &
            '    " UNION ALL SELECT '','TODOS') D1 ORDER BY D1.nOMBRE"

            sqlda_REPORT_PAGADO = New SqlDataAdapter(CHOFERES, conexsql_SUTRANSPORTE)
            sqlda_REPORT_PAGADO.Fill(ds_CHOFERES)
            sqlda_REPORT_PAGADO.Fill(ds_CHOFERES1)

            cbporchofer.DataSource = ds_CHOFERES.Tables(0)
            cbporchofer.DisplayMember = "NOMBRE"
            cbporchofer.ValueMember = "id_personal"
            cbporchofer.Text = "SELECCIONE ......"

            cbporchofer1.DataSource = ds_CHOFERES1.Tables(0)
            cbporchofer1.DisplayMember = "NOMBRE"
            cbporchofer1.ValueMember = "id_personal"
            cbporchofer1.Text = "SELECCIONE ......"

            Dim gastos = "SELECT CLAVE,DESCRIP  FROM (SELECT CLAVE,cast(CLAVE as varchar) + ' '+ DESCRIP 'DESCRIP' FROM VARIOS union all select '','TODOS' ) D1 ORDER BY D1.clave"
            sqlda_REPORT_PAGADO = New SqlDataAdapter(gastos, CONEXION_GASTOS)
            sqlda_REPORT_PAGADO.Fill(ds_gastos)
            sqlda_REPORT_PAGADO.Fill(ds_gastos1)

            cbporgasto.DataSource = ds_gastos.Tables(0)
            cbporgasto.DisplayMember = "DESCRIP"
            cbporgasto.ValueMember = "CLAVE"
            cbporgasto.Text = "SELECCIONE ......"

            cbporgasto1.DataSource = ds_gastos1.Tables(0)
            cbporgasto1.DisplayMember = "DESCRIP"
            cbporgasto1.ValueMember = "CLAVE"
            cbporgasto1.Text = "SELECCIONE ......"


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "PAGADOS" Then
            GroupBox1.Text = "FECHA EMISION"
            'lblporpatio.Visible = True
            'cbporpatio.Visible = True
            'lblporgasto.Visible = False
            'cbporgasto.Visible = False
            'lblporchofer.Visible = False
            'cbporchofer.Visible = False

        ElseIf ComboBox1.Text = "NO PAGADOS" Or ComboBox1.Text = "PAGADOS Y NO PAGADOS" Then
            GroupBox1.Text = "FECHA EMISION"
            'lblporpatio.Visible = True
            'cbporpatio.Visible = True
            'lblporgasto.Visible = False
            'cbporgasto.Visible = False
            'lblporchofer.Visible = False
            'cbporchofer.Visible = False

        ElseIf ComboBox1.Text = "REPORTES" Then
            'lblporgasto.Visible = True
            'cbporgasto.Visible = True
            'lblporchofer.Visible = False
            'cbporchofer.Visible = False
            'lblporpatio.Visible = False
            'cbporpatio.Visible = False
            GroupBox1.Text = "FECHA EMISION"

        ElseIf ComboBox1.Text = "GASTOS EXTRAS PAGADOS" Then
            'lblporgasto.Visible = True
            'cbporgasto.Visible = True
            'lblporchofer.Visible = False
            'cbporchofer.Visible = False
            'lblporpatio.Visible = False
            'cbporpatio.Visible = False
            GroupBox1.Text = "FECHA PAGO"

        ElseIf ComboBox1.Text = "PRUEBA PAGADO" Then
            GroupBox1.Text = "FECHA EMISION"

        Else
            MsgBox("SELECCIONE UNA OPCION")
            Exit Sub

        End If

    End Sub
    Sub pagynopag(PATIO As String, GASTO As String, GASTO1 As String, CHOFER As String, CHOFER1 As String, FINI As String, FFIN As String, TIPO As String)
        Dim logconex = New SqlConnection(CONEXION_GASTOS)
        logconex.Open()

        'If PATIO = "TODOS" Then
        '    sql = "REPORTES_PAGADOYNOPAGADO '" + FINI + "','" + FFIN + "' "

        'Else
        '    sql = "REPORTES_PAGADOYNOPAGADOxPATIO '" + FINI + "','" + FFIN + "','" + PATIO + "'"

        'End If


        Dim unionsql = " UNION ALL "

        sql = "DECLARE @FINI AS VARCHAR(25) DECLARE @FFIN AS VARCHAR(25) DECLARE @CHOFER AS VARCHAR(200) DECLARE @CHOFER1 AS VARCHAR(200) " &
            "DECLARE @PATIO AS VARCHAR(200) DECLARE @GASTOS AS VARCHAR(200) DECLARE @GASTOS1 AS VARCHAR(200) " &
            "SET @FINI='" & FINI & "' SET @FFIN='" & FFIN & "' 	SET @CHOFER='" & CHOFER & "' 	SET @CHOFER1='" & CHOFER1 & "' SET @PATIO='" & PATIO &
            "' SET @GASTOS ='" & GASTO & "' SET @GASTOS1='" & GASTO1 & "' " &
            "SELECT * FROM (SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE1 CLAVE	,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE1) DESCRIP,TALON,FACTURA1	," &
            "FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
            ",VERIFICA	,MONTO1 MONTO,CAUSA1,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI 	AND @FFIN 	AND MONTO1 > 0 	" &
            "AND ESTATUS NOT LIKE '%ELIMINADO%' "

        Dim sql1 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE2 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE2) DESCRIP,TALON2,FACTURA2,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO2 MONTO	,CAUSA2,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN AND MONTO2 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

        Dim sql2 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE3 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE3) DESCRIP,TALON3,FACTURA3,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO3 MONTO,CAUSA3,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO3 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

        Dim sql3 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE4 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE4) DESCRIP,TALON4,FACTURA4,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO4 MONTO,CAUSA4,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO4 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

        Dim sql4 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE5 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE5) DESCRIP,TALON5,FACTURA5,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO5 MONTO,CAUSA5,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO5 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

        Dim sql5 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR	,NOMBRE,CLAVE6 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE6) DESCRIP,TALON6,FACTURA6	,FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO6 MONTO,CAUSA6,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO6 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

        Dim sql6 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE7 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE7) DESCRIP,TALON7,FACTURA7,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO7 MONTO,CAUSA7,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO7 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

        Dim sql7 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE8 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE8) DESCRIP,TALON8,FACTURA8,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO8 MONTO,CAUSA8,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO8 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

        Dim gastossql = "", gastossql1 = "", gastossql2 = "", gastossql3 = "", gastossql4 = "", gastossql5 = "", gastossql6 = "", gastossql7 = ""
        Dim chofersql = ""
        Dim patiosql = ""
        Dim ordenar = ""

        If cbporgasto.Text <> "TODOS" Or cbporgasto1.Text <> "TODOS" Then
            gastossql = "AND CLAVE1 BETWEEN @GASTOS AND @GASTOS1	"
            gastossql1 = "AND CLAVE2 BETWEEN @GASTOS AND @GASTOS1 "
            gastossql2 = "AND CLAVE3 BETWEEN @GASTOS AND @GASTOS1 "
            gastossql3 = "AND CLAVE4 BETWEEN @GASTOS AND @GASTOS1 "
            gastossql4 = "AND CLAVE5 BETWEEN @GASTOS AND @GASTOS1 "
            gastossql5 = "AND CLAVE6 BETWEEN @GASTOS AND @GASTOS1 "
            gastossql6 = "AND CLAVE7 BETWEEN @GASTOS AND @GASTOS1 "
            gastossql7 = "AND CLAVE8 BETWEEN @GASTOS AND @GASTOS1 "

        End If
        If cbporchofer.Text <> "TODOS" Or cbporchofer1.Text <> "TODOS" Then
            chofersql = "AND OPERADOR BETWEEN @CHOFER AND @CHOFER1 "

        End If
        If PATIO <> "TODOS" Then
            patiosql = "AND BASE_PAGO = @PATIO "

        End If

        If cbordenar.Text = "GASTO" Then
            ordenar = " ORDER BY D1.CLAVE,D1.SOLICITUD,D1.OPERADOR "
        ElseIf cbordenar.Text = "OPERADOR" Then
            ordenar = " ORDER BY D1.OPERADOR,D1.CLAVE,D1.SOLICITUD "
        ElseIf cbordenar.Text = "SOLICITUD" Then
            ordenar = " ORDER BY D1.SOLICITUD,D1.CLAVE,D1.OPERADOR "
        ElseIf cbordenar.Text = "CAUSA" Then
            ordenar = " ORDER BY D1.CAUSA,D1.SOLICITUD,D1.CLAVE, D1.OPERADOR "
        End If

        sql = sql + patiosql + chofersql + gastossql + unionsql
        sql1 = sql1 + patiosql + chofersql + gastossql1 + unionsql
        sql2 = sql2 + patiosql + chofersql + gastossql2 + unionsql
        sql3 = sql3 + patiosql + chofersql + gastossql3 + unionsql
        sql4 = sql4 + patiosql + chofersql + gastossql4 + unionsql
        sql5 = sql5 + patiosql + chofersql + gastossql5 + unionsql
        sql6 = sql6 + patiosql + chofersql + gastossql6 + unionsql
        sql7 = sql7 + patiosql + chofersql + gastossql7

        sql = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7
        sql = sql + ")D1 " + ordenar

        Dim logdr As SqlDataAdapter = New SqlDataAdapter(sql, logconex)
        Dim dt_reporte As New Data.DataTable
        logdr.Fill(dt_reporte)
        If dt_reporte.Rows.Count = 0 Then
            MsgBox("NO SE ENCONTRARON DATOS")

        Else
            DatatableToExcel(dt_reporte, "C:\", DateTimePicker1.Value.ToString("yyyy-MMM-dd"), DateTimePicker2.Value.ToString("yyyy-MMM-dd"))

        End If

    End Sub
    Sub pagados_O_NOPAGADOS(PATIO As String, GASTO As String, GASTO1 As String, CHOFER As String, CHOFER1 As String, FINI As String, FFIN As String, TIPO As String)
        Dim logconex = New SqlConnection(CONEXION_GASTOS)
        logconex.Open()

        If TIPO.Equals("PAGADOS") Then

            Dim unionsql = " UNION ALL "

            sql = "DECLARE @FINI AS VARCHAR(25) DECLARE @FFIN AS VARCHAR(25) DECLARE @CHOFER AS VARCHAR(200) DECLARE @CHOFER1 AS VARCHAR(200) " &
            "DECLARE @PATIO AS VARCHAR(200) DECLARE @GASTOS AS VARCHAR(200) DECLARE @GASTOS1 AS VARCHAR(200) " &
            "SET @FINI='" & FINI & "' SET @FFIN='" & FFIN & "' 	SET @CHOFER='" & CHOFER & "' 	SET @CHOFER1='" & CHOFER1 & "' SET @PATIO='" & PATIO &
            "' SET @GASTOS ='" & GASTO & "' SET @GASTOS1='" & GASTO1 & "' " &
            "SELECT D1.SOLICITUD,D1.TALON,D1.NUM_ECO,D1.OPERADOR,D1.NOMBRE,D1.CLAVE,D1.DESCRIP,D1.MONTO,D1.CAUSA,D1.DESTINO,D1.FECHA_CONS,D1.BASE_PAGO," &
            "D1.FECHA_PAGO " &
            "FROM(SELECT SOLICITUD, BASE_PAGO, DESTINO, NUM_ECO, OPERADOR, nombre, CLAVE1 CLAVE	, (SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE1) DESCRIP,TALON,FACTURA1	," &
            "FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
            ",VERIFICA	,MONTO1 MONTO,CAUSA1 CAUSA,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_PAGO BETWEEN @FINI And @FFIN And MONTO1 > 0 	" &
            "And ESTATUS Not Like '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql1 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE2 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE2) DESCRIP,TALON2,FACTURA2,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO2 MONTO	,CAUSA2,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_PAGO BETWEEN @FINI AND @FFIN AND MONTO2 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql2 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE3 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE3) DESCRIP,TALON3,FACTURA3,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO3 MONTO,CAUSA3,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_PAGO BETWEEN @FINI AND @FFIN 	AND MONTO3 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql3 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE4 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE4) DESCRIP,TALON4,FACTURA4,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO4 MONTO,CAUSA4,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_PAGO BETWEEN @FINI AND @FFIN 	AND MONTO4 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql4 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE5 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE5) DESCRIP,TALON5,FACTURA5,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO5 MONTO,CAUSA5,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_PAGO BETWEEN @FINI AND @FFIN 	AND MONTO5 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql5 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR	,NOMBRE,CLAVE6 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE6) DESCRIP,TALON6,FACTURA6	,FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO6 MONTO,CAUSA6,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_PAGO BETWEEN @FINI AND @FFIN 	AND MONTO6 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql6 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE7 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE7) DESCRIP,TALON7,FACTURA7,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO7 MONTO,CAUSA7,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_PAGO BETWEEN @FINI AND @FFIN 	AND MONTO7 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql7 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE8 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE8) DESCRIP,TALON8,FACTURA8,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO8 MONTO,CAUSA8,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_PAGO BETWEEN @FINI AND @FFIN 	AND MONTO8 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim gastossql = "", gastossql1 = "", gastossql2 = "", gastossql3 = "", gastossql4 = "", gastossql5 = "", gastossql6 = "", gastossql7 = ""
            Dim chofersql = ""
            Dim patiosql = ""
            Dim ordenar = ""

            If cbporgasto.Text <> "TODOS" Or cbporgasto1.Text <> "TODOS" Then
                gastossql = "AND CLAVE1 BETWEEN @GASTOS AND @GASTOS1	"
                gastossql1 = "AND CLAVE2 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql2 = "AND CLAVE3 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql3 = "AND CLAVE4 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql4 = "AND CLAVE5 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql5 = "AND CLAVE6 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql6 = "AND CLAVE7 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql7 = "AND CLAVE8 BETWEEN @GASTOS AND @GASTOS1 "

            End If
            If cbporchofer.Text <> "TODOS" Or cbporchofer1.Text <> "TODOS" Then
                chofersql = "AND OPERADOR BETWEEN @CHOFER AND @CHOFER1 "

            End If
            If PATIO <> "TODOS" Then
                patiosql = "AND BASE_PAGO = @PATIO "

            End If

            If cbordenar.Text = "GASTO" Then
                ordenar = " ORDER BY D1.CLAVE,D1.SOLICITUD,D1.OPERADOR "
            ElseIf cbordenar.Text = "OPERADOR" Then
                ordenar = " ORDER BY D1.OPERADOR,D1.CLAVE,D1.SOLICITUD "
            ElseIf cbordenar.Text = "SOLICITUD" Then
                ordenar = " ORDER BY D1.SOLICITUD,D1.CLAVE,D1.OPERADOR "
            ElseIf cbordenar.Text = "CAUSA" Then
                ordenar = " ORDER BY D1.CAUSA,D1.SOLICITUD,D1.CLAVE, D1.OPERADOR "
            End If

            sql = sql + patiosql + chofersql + gastossql + unionsql
            sql1 = sql1 + patiosql + chofersql + gastossql1 + unionsql
            sql2 = sql2 + patiosql + chofersql + gastossql2 + unionsql
            sql3 = sql3 + patiosql + chofersql + gastossql3 + unionsql
            sql4 = sql4 + patiosql + chofersql + gastossql4 + unionsql
            sql5 = sql5 + patiosql + chofersql + gastossql5 + unionsql
            sql6 = sql6 + patiosql + chofersql + gastossql6 + unionsql
            sql7 = sql7 + patiosql + chofersql + gastossql7

            sql = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7
            sql = sql + ")D1 " + ordenar

            'If patio = "TODOS" Then
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS '" + FiNI + "','" + FFIN + "','PAGADOS' "

            'Else
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS_patio '" + FiNI + "','" + FFIN + "','PAGADOS' ,'" + patio + "'"

            'End If

        ElseIf TIPO.Equals("NO PAGADOS") Then
            Dim unionsql = " UNION ALL "

            sql = "DECLARE @FINI AS VARCHAR(25) DECLARE @FFIN AS VARCHAR(25) DECLARE @CHOFER AS VARCHAR(200) DECLARE @CHOFER1 AS VARCHAR(200) " &
            "DECLARE @PATIO AS VARCHAR(200) DECLARE @GASTOS AS VARCHAR(200) DECLARE @GASTOS1 AS VARCHAR(200) " &
            "SET @FINI='" & FINI & "' SET @FFIN='" & FFIN & "' 	SET @CHOFER='" & CHOFER & "' 	SET @CHOFER1='" & CHOFER1 & "' SET @PATIO='" & PATIO &
            "' SET @GASTOS ='" & GASTO & "' SET @GASTOS1='" & GASTO1 & "' " &
            "SELECT D1.SOLICITUD,D1.TALON,D1.NUM_ECO,D1.OPERADOR,D1.NOMBRE,D1.CLAVE,D1.DESCRIP,D1.MONTO,D1.CAUSA,D1.DESTINO,D1.FECHA_CONS,D1.BASE_PAGO," &
            "D1.FECHA_PAGO " &
            "FROM (SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE1 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE1) DESCRIP,TALON,FACTURA1	," &
            "FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
            ",VERIFICA,MONTO1 MONTO,CAUSA1 CAUSA,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI 	And @FFIN 	And MONTO1 > 0 	" &
            "And ESTATUS Not Like '%ELIMINADO%'  AND FECHA_PAGO IS NULL "

            Dim sql1 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE2 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE2) DESCRIP,TALON2,FACTURA2,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO2 MONTO	,CAUSA2,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN AND MONTO2 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'   AND FECHA_PAGO IS NULL "

            Dim sql2 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE3 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE3) DESCRIP,TALON3,FACTURA3,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO3 MONTO,CAUSA3,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO3 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'   AND FECHA_PAGO IS NULL "

            Dim sql3 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE4 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE4) DESCRIP,TALON4,FACTURA4,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO4 MONTO,CAUSA4,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO4 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'   AND FECHA_PAGO IS NULL "

            Dim sql4 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE5 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE5) DESCRIP,TALON5,FACTURA5,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO5 MONTO,CAUSA5,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO5 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'   AND FECHA_PAGO IS NULL "

            Dim sql5 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR	,NOMBRE,CLAVE6 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE6) DESCRIP,TALON6,FACTURA6	,FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO6 MONTO,CAUSA6,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO6 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'   AND FECHA_PAGO IS NULL "

            Dim sql6 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE7 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE7) DESCRIP,TALON7,FACTURA7,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO7 MONTO,CAUSA7,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO7 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'   AND FECHA_PAGO IS NULL "

            Dim sql7 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE8 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE8) DESCRIP,TALON8,FACTURA8,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO8 MONTO,CAUSA8,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO8 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'   AND FECHA_PAGO IS NULL "

            Dim gastossql = "", gastossql1 = "", gastossql2 = "", gastossql3 = "", gastossql4 = "", gastossql5 = "", gastossql6 = "", gastossql7 = ""
            Dim chofersql = ""
            Dim patiosql = ""
            Dim ordenar = ""
            If cbporgasto.Text <> "TODOS" Or cbporgasto1.Text <> "TODOS" Then
                gastossql = "AND CLAVE1 BETWEEN @GASTOS AND @GASTOS1	"
                gastossql1 = "AND CLAVE2 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql2 = "AND CLAVE3 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql3 = "AND CLAVE4 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql4 = "AND CLAVE5 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql5 = "AND CLAVE6 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql6 = "AND CLAVE7 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql7 = "AND CLAVE8 BETWEEN @GASTOS AND @GASTOS1 "

            End If
            If cbporchofer.Text <> "TODOS" Or cbporchofer1.Text <> "TODOS" Then
                chofersql = "AND OPERADOR BETWEEN @CHOFER AND @CHOFER1 "

            End If
            If PATIO <> "TODOS" Then
                patiosql = "AND BASE_PAGO = @PATIO "

            End If

            If cbordenar.Text = "GASTO" Then
                ordenar = " ORDER BY D1.CLAVE,D1.SOLICITUD,D1.OPERADOR "
            ElseIf cbordenar.Text = "OPERADOR" Then
                ordenar = " ORDER BY D1.OPERADOR,D1.CLAVE,D1.SOLICITUD "
            ElseIf cbordenar.Text = "SOLICITUD" Then
                ordenar = " ORDER BY D1.SOLICITUD,D1.CLAVE,D1.OPERADOR "
            ElseIf cbordenar.Text = "CAUSA" Then
                ordenar = " ORDER BY D1.CAUSA,D1.SOLICITUD,D1.CLAVE, D1.OPERADOR "
            End If

            sql = sql + patiosql + chofersql + gastossql + unionsql
            sql1 = sql1 + patiosql + chofersql + gastossql1 + unionsql
            sql2 = sql2 + patiosql + chofersql + gastossql2 + unionsql
            sql3 = sql3 + patiosql + chofersql + gastossql3 + unionsql
            sql4 = sql4 + patiosql + chofersql + gastossql4 + unionsql
            sql5 = sql5 + patiosql + chofersql + gastossql5 + unionsql
            sql6 = sql6 + patiosql + chofersql + gastossql6 + unionsql
            sql7 = sql7 + patiosql + chofersql + gastossql7

            sql = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7
            sql = sql + ")D1 " + ordenar

            'If PATIO = "TODOS" Then
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS '" + FINI + "','" + FFIN + "','NO PAGADOS' "

            'Else
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS_patio '" + FINI + "','" + FFIN + "','NO PAGADOS' ,'" + PATIO + "'"

            'End If

        End If

        Dim logdr As SqlDataAdapter = New SqlDataAdapter(sql, logconex)
        Dim dt_reporte As New Data.DataTable
        logdr.Fill(dt_reporte)
        If dt_reporte.Rows.Count = 0 Then
            MsgBox("NO SE ENCONTRARON DATOS")

        Else
            DatatableToExcel(dt_reporte, "C:\", DateTimePicker1.Value.ToString("yyyy-MMM-dd"), DateTimePicker2.Value.ToString("yyyy-MMM-dd"))

        End If

    End Sub

    Sub ordenado(PATIO As String, GASTO As String, GASTO1 As String, CHOFER As String, CHOFER1 As String, FINI As String, FFIN As String, TIPO As String)
        Try

            Dim unionsql = " UNION ALL "

            sql = "DECLARE @FINI AS DATE DECLARE @FFIN AS DATE DECLARE @CHOFER AS VARCHAR(200) DECLARE @CHOFER1 AS VARCHAR(200) " &
            "DECLARE @PATIO AS VARCHAR(200) DECLARE @GASTOS AS VARCHAR(200) DECLARE @GASTOS1 AS VARCHAR(200) " &
            "SET @FINI='" & FINI & "' SET @FFIN='" & FFIN & "' 	SET @CHOFER='" & CHOFER & "' 	SET @CHOFER1='" & CHOFER1 & "' SET @PATIO='" & PATIO &
            "' SET @GASTOS ='" & GASTO & "' SET @GASTOS1='" & GASTO1 & "' " &
            "SELECT SOLICITUD,BASE_PAGO,DESTINO	,NUM_ECO,cast(OPERADOR as integer) OPERADOR,NOMBRE,cast(CLAVE as integer) CLAVE,DESCRIP,TALON,FACTURA1,CONVERT(varchar,FECHA_EMI,6) FECHA_EMI " &
            ",CONVERT(varchar,FECHA_CONS,6) FECHA_CONS	,CONVERT(varchar,FECHA_PAGO,6) FECHA_PAGO	,VERIFICA	,MONTO,CAUSA,OBSERVA " &
            ",CONVERT(VARCHAR,@FINI, 106) FINI,CONVERT(VARCHAR,@FFIN, 106) FFIN " &
            "FROM (SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE1 CLAVE	,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE1) DESCRIP,TALON,FACTURA1	," &
            "FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
            ",VERIFICA	,MONTO1 MONTO,CAUSA1 CAUSA,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE /*FECHA_EMI BETWEEN @FINI 	And @FFIN	And*/ MONTO1 > 0 	" &
            "And ESTATUS Not Like '%ELIMINADO%' AND FECHA_PAGO BETWEEN @FINI 	And @FFIN "

            Dim sql1 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE2 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE2) DESCRIP,TALON2,FACTURA2,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO2 MONTO	,CAUSA2,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE /*FECHA_EMI BETWEEN @FINI AND @FFIN AND*/ MONTO2 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO BETWEEN @FINI 	And @FFIN "

            Dim sql2 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE3 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE3) DESCRIP,TALON3,FACTURA3,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO3 MONTO,CAUSA3,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE /*FECHA_EMI BETWEEN @FINI AND @FFIN 	AND*/ MONTO3 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO BETWEEN @FINI 	And @FFIN "

            Dim sql3 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE4 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE4) DESCRIP,TALON4,FACTURA4,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO4 MONTO,CAUSA4,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE /*FECHA_EMI BETWEEN @FINI AND @FFIN 	AND*/ MONTO4 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO BETWEEN @FINI 	And @FFIN "

            Dim sql4 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE5 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE5) DESCRIP,TALON5,FACTURA5,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO5 MONTO,CAUSA5,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE /*FECHA_EMI BETWEEN @FINI AND @FFIN 	AND*/ MONTO5 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO BETWEEN @FINI 	And @FFIN "

            Dim sql5 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR	,NOMBRE,CLAVE6 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE6) DESCRIP,TALON6,FACTURA6	,FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO6 MONTO,CAUSA6,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE /*FECHA_EMI BETWEEN @FINI AND @FFIN 	AND*/ MONTO6 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO BETWEEN @FINI 	And @FFIN "

            Dim sql6 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE7 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE7) DESCRIP,TALON7,FACTURA7,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO7 MONTO,CAUSA7,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE /*FECHA_EMI BETWEEN @FINI AND @FFIN 	AND*/ MONTO7 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO BETWEEN @FINI 	And @FFIN "

            Dim sql7 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE8 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE8) DESCRIP,TALON8,FACTURA8,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO8 MONTO,CAUSA8,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE /*FECHA_EMI BETWEEN @FINI AND @FFIN 	AND*/ MONTO8 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO BETWEEN @FINI 	And @FFIN "

            Dim gastossql = "", gastossql1 = "", gastossql2 = "", gastossql3 = "", gastossql4 = "", gastossql5 = "", gastossql6 = "", gastossql7 = ""
            Dim chofersql = ""
            Dim patiosql = ""
            Dim ordenar = ""

            If cbporgasto.Text <> "TODOS" Or cbporgasto1.Text <> "TODOS" Then
                gastossql = "AND CLAVE1 BETWEEN @GASTOS AND @GASTOS1	"
                gastossql1 = "AND CLAVE2 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql2 = "AND CLAVE3 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql3 = "AND CLAVE4 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql4 = "AND CLAVE5 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql5 = "AND CLAVE6 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql6 = "AND CLAVE7 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql7 = "AND CLAVE8 BETWEEN @GASTOS AND @GASTOS1 "

            End If
            If cbporchofer.Text <> "TODOS" Or cbporchofer1.Text <> "TODOS" Then
                chofersql = "AND OPERADOR BETWEEN @CHOFER AND @CHOFER1 "

            End If
            If PATIO <> "TODOS" Then
                patiosql = "AND BASE_PAGO = @PATIO "

            End If

            If cbordenar.Text = "GASTO" Then
                ordenar = " ORDER BY D1.CLAVE,D1.SOLICITUD,D1.OPERADOR "
            ElseIf cbordenar.Text = "OPERADOR" Then
                ordenar = " ORDER BY D1.OPERADOR,D1.CLAVE,D1.SOLICITUD "
            ElseIf cbordenar.Text = "SOLICITUD" Then
                'Exit Sub
                'ordenar = " ORDER BY D1.SOLICITUD,D1.CLAVE,D1.OPERADOR "
            ElseIf cbordenar.Text = "CAUSA" Then
                'Exit Sub
                'ordenar = " ORDER BY D1.CAUSA,D1.SOLICITUD,D1.CLAVE, D1.OPERADOR "
            End If

            sql = sql + patiosql + chofersql + gastossql + unionsql
            sql1 = sql1 + patiosql + chofersql + gastossql1 + unionsql
            sql2 = sql2 + patiosql + chofersql + gastossql2 + unionsql
            sql3 = sql3 + patiosql + chofersql + gastossql3 + unionsql
            sql4 = sql4 + patiosql + chofersql + gastossql4 + unionsql
            sql5 = sql5 + patiosql + chofersql + gastossql5 + unionsql
            sql6 = sql6 + patiosql + chofersql + gastossql6 + unionsql
            sql7 = sql7 + patiosql + chofersql + gastossql7

            sql = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7
            sql = sql + ")D1 " + ordenar

            'Dim logconex = New SqlConnection(CONEXION_GASTOS)
            'Dim logdr As SqlDataAdapter = New SqlDataAdapter(sql, logconex)
            'Dim dt_reporte As New Data.DataTable
            'logdr.Fill(dt_reporte)
            ''DataGridView1.DataSource = dt_reporte
            'If dt_reporte.Rows.Count = 0 Then
            '    MsgBox("NO SE ENCONTRARON DATOS")

            'Else
            '    DatatableToExcel(dt_reporte, "C:\", DateTimePicker1.Value.ToString("yyyy-MMM-dd"), DateTimePicker2.Value.ToString("yyyy-MMM-dd"))
            '    'datagridview_a_excel(dt_reporte, "C:\", DateTimePicker1.Value.ToString("yyyy-MMM-dd"), DateTimePicker2.Value.ToString("yyyy-MMM-dd"))

            'End If
        Catch ex As Exception

        End Try

    End Sub

    Sub PRUEBAS_PAGADO_NOPAGADO(PATIO As String, GASTO As String, GASTO1 As String, CHOFER As String, CHOFER1 As String, FINI As String, FFIN As String, TIPO As String)
        Dim logconex = New SqlConnection(CONEXION_GASTOS)
        logconex.Open()

        If TIPO.Equals("PAGADOS") Then

            Dim unionsql = " UNION ALL "

            sql = "DECLARE @FINI AS VARCHAR(25) DECLARE @FFIN AS VARCHAR(25) DECLARE @CHOFER AS VARCHAR(200) DECLARE @CHOFER1 AS VARCHAR(200) " &
            "DECLARE @PATIO AS VARCHAR(200) DECLARE @GASTOS AS VARCHAR(200) DECLARE @GASTOS1 AS VARCHAR(200) " &
            "SET @FINI='" & FINI & "' SET @FFIN='" & FFIN & "' 	SET @CHOFER='" & CHOFER & "' 	SET @CHOFER1='" & CHOFER1 & "' SET @PATIO='" & PATIO &
            "' SET @GASTOS ='" & GASTO & "' SET @GASTOS1='" & GASTO1 & "' " &
            "SELECT D1.SOLICITUD,D1.OPERADOR,D1.NOMBRE,D1.DESCRIP,D1.TALON,D1.FECHA_EMI,D1.FECHA_PAGO,D1.NUM_ECO,D1.VERIFICA,D1.MONTO " &
            "FROM(SELECT SOLICITUD, BASE_PAGO, DESTINO, NUM_ECO, OPERADOR, nombre, CLAVE1 CLAVE	, (SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE1) DESCRIP,TALON,FACTURA1	," &
            "FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
            ",VERIFICA	,MONTO1 MONTO,CAUSA1,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI And @FFIN And MONTO1 > 0 	" &
            "And ESTATUS Not Like '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql1 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE2 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE2) DESCRIP,TALON2,FACTURA2,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO2 MONTO	,CAUSA2,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN AND MONTO2 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql2 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE3 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE3) DESCRIP,TALON3,FACTURA3,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO3 MONTO,CAUSA3,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO3 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql3 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE4 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE4) DESCRIP,TALON4,FACTURA4,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO4 MONTO,CAUSA4,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO4 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql4 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE5 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE5) DESCRIP,TALON5,FACTURA5,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO5 MONTO,CAUSA5,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO5 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql5 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR	,NOMBRE,CLAVE6 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE6) DESCRIP,TALON6,FACTURA6	,FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO6 MONTO,CAUSA6,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO6 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql6 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE7 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE7) DESCRIP,TALON7,FACTURA7,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO7 MONTO,CAUSA7,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO7 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim sql7 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE8 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE8) DESCRIP,TALON8,FACTURA8,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO8 MONTO,CAUSA8,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO8 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' AND FECHA_PAGO IS NOT NULL "

            Dim gastossql = "", gastossql1 = "", gastossql2 = "", gastossql3 = "", gastossql4 = "", gastossql5 = "", gastossql6 = "", gastossql7 = ""
            Dim chofersql = ""
            Dim patiosql = ""
            Dim ordenar = ""

            If cbporgasto.Text <> "TODOS" Or cbporgasto1.Text <> "TODOS" Then
                gastossql = "AND CLAVE1 BETWEEN @GASTOS AND @GASTOS1	"
                gastossql1 = "AND CLAVE2 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql2 = "AND CLAVE3 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql3 = "AND CLAVE4 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql4 = "AND CLAVE5 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql5 = "AND CLAVE6 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql6 = "AND CLAVE7 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql7 = "AND CLAVE8 BETWEEN @GASTOS AND @GASTOS1 "

            End If
            If cbporchofer.Text <> "TODOS" Or cbporchofer1.Text <> "TODOS" Then
                chofersql = "AND OPERADOR BETWEEN @CHOFER AND @CHOFER1 "

            End If
            If PATIO <> "TODOS" Then
                patiosql = "AND BASE_PAGO = @PATIO "

            End If

            If cbordenar.Text = "GASTO" Then
                ordenar = " ORDER BY D1.CLAVE,D1.SOLICITUD,D1.OPERADOR "
            ElseIf cbordenar.Text = "OPERADOR" Then
                ordenar = " ORDER BY D1.OPERADOR,D1.CLAVE,D1.SOLICITUD "
            ElseIf cbordenar.Text = "SOLICITUD" Then
                ordenar = " ORDER BY D1.SOLICITUD,D1.CLAVE,D1.OPERADOR "
            ElseIf cbordenar.Text = "CAUSA" Then
                Exit Sub
                'ordenar = " ORDER BY D1.CAUSA,D1.SOLICITUD,D1.CLAVE, D1.OPERADOR "
            End If

            sql = sql + patiosql + chofersql + gastossql + unionsql
            sql1 = sql1 + patiosql + chofersql + gastossql1 + unionsql
            sql2 = sql2 + patiosql + chofersql + gastossql2 + unionsql
            sql3 = sql3 + patiosql + chofersql + gastossql3 + unionsql
            sql4 = sql4 + patiosql + chofersql + gastossql4 + unionsql
            sql5 = sql5 + patiosql + chofersql + gastossql5 + unionsql
            sql6 = sql6 + patiosql + chofersql + gastossql6 + unionsql
            sql7 = sql7 + patiosql + chofersql + gastossql7

            sql = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7
            sql = sql + ")D1 " + ordenar

            'If patio = "TODOS" Then
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS '" + FiNI + "','" + FFIN + "','PAGADOS' "

            'Else
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS_patio '" + FiNI + "','" + FFIN + "','PAGADOS' ,'" + patio + "'"

            'End If

        ElseIf TIPO.Equals("NO PAGADOS") Then
            Dim unionsql = " UNION ALL "

            sql = "DECLARE @FINI AS VARCHAR(25) DECLARE @FFIN AS VARCHAR(25) DECLARE @CHOFER AS VARCHAR(200) DECLARE @CHOFER1 AS VARCHAR(200) " &
            "DECLARE @PATIO AS VARCHAR(200) DECLARE @GASTOS AS VARCHAR(200) DECLARE @GASTOS1 AS VARCHAR(200) " &
            "SET @FINI='" & FINI & "' SET @FFIN='" & FFIN & "' 	SET @CHOFER='" & CHOFER & "' 	SET @CHOFER1='" & CHOFER1 & "' SET @PATIO='" & PATIO &
            "' SET @GASTOS ='" & GASTO & "' SET @GASTOS1='" & GASTO1 & "' " &
            "SELECT  D1.SOLICITUD,D1.OPERADOR,D1.NOMBRE,D1.DESCRIP,D1.TALON,D1.FECHA_EMI,D1.FECHA_PAGO,D1.NUM_ECO,D1.VERIFICA,D1.MONTO " &
            "FROM (SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE1 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE1) DESCRIP,TALON,FACTURA1	," &
            "FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
            ",VERIFICA,MONTO1 MONTO,CAUSA1 CAUSA,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI 	And @FFIN 	And MONTO1 > 0 	" &
            "And ESTATUS Not Like '%ELIMINADO%' AND FECHA_PAGO IS NULL "

            Dim sql1 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE2 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE2) DESCRIP,TALON2,FACTURA2,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO2 MONTO	,CAUSA2,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN AND MONTO2 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  AND FECHA_PAGO IS NULL "

            Dim sql2 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE3 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE3) DESCRIP,TALON3,FACTURA3,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO3 MONTO,CAUSA3,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO3 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  AND FECHA_PAGO IS NULL "

            Dim sql3 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE4 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE4) DESCRIP,TALON4,FACTURA4,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO4 MONTO,CAUSA4,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO4 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  AND FECHA_PAGO IS NULL "

            Dim sql4 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE5 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE5) DESCRIP,TALON5,FACTURA5,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO5 MONTO,CAUSA5,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO5 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  AND FECHA_PAGO IS NULL "

            Dim sql5 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR	,NOMBRE,CLAVE6 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE6) DESCRIP,TALON6,FACTURA6	,FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO6 MONTO,CAUSA6,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO6 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  AND FECHA_PAGO IS NULL "

            Dim sql6 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE7 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE7) DESCRIP,TALON7,FACTURA7,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO7 MONTO,CAUSA7,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO7 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  AND FECHA_PAGO IS NULL "

            Dim sql7 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE8 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE8) DESCRIP,TALON8,FACTURA8,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO8 MONTO,CAUSA8,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO8 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  AND FECHA_PAGO IS NULL "

            Dim gastossql = "", gastossql1 = "", gastossql2 = "", gastossql3 = "", gastossql4 = "", gastossql5 = "", gastossql6 = "", gastossql7 = ""
            Dim chofersql = ""
            Dim patiosql = ""
            Dim ordenar = ""
            If cbporgasto.Text <> "TODOS" Or cbporgasto1.Text <> "TODOS" Then
                gastossql = "AND CLAVE1 BETWEEN @GASTOS AND @GASTOS1	"
                gastossql1 = "AND CLAVE2 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql2 = "AND CLAVE3 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql3 = "AND CLAVE4 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql4 = "AND CLAVE5 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql5 = "AND CLAVE6 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql6 = "AND CLAVE7 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql7 = "AND CLAVE8 BETWEEN @GASTOS AND @GASTOS1 "

            End If
            If cbporchofer.Text <> "TODOS" Or cbporchofer1.Text <> "TODOS" Then
                chofersql = "AND OPERADOR BETWEEN @CHOFER AND @CHOFER1 "

            End If
            If PATIO <> "TODOS" Then
                patiosql = "AND BASE_PAGO = @PATIO "

            End If

            If cbordenar.Text = "GASTO" Then
                ordenar = " ORDER BY D1.CLAVE,D1.SOLICITUD,D1.OPERADOR "
            ElseIf cbordenar.Text = "OPERADOR" Then
                ordenar = " ORDER BY D1.OPERADOR,D1.CLAVE,D1.SOLICITUD "
            ElseIf cbordenar.Text = "SOLICITUD" Then
                ordenar = " ORDER BY D1.SOLICITUD,D1.CLAVE,D1.OPERADOR "
            ElseIf cbordenar.Text = "CAUSA" Then
                Exit Sub
                'ordenar = " ORDER BY D1.CAUSA,D1.SOLICITUD,D1.CLAVE, D1.OPERADOR "
            End If

            sql = sql + patiosql + chofersql + gastossql + unionsql
            sql1 = sql1 + patiosql + chofersql + gastossql1 + unionsql
            sql2 = sql2 + patiosql + chofersql + gastossql2 + unionsql
            sql3 = sql3 + patiosql + chofersql + gastossql3 + unionsql
            sql4 = sql4 + patiosql + chofersql + gastossql4 + unionsql
            sql5 = sql5 + patiosql + chofersql + gastossql5 + unionsql
            sql6 = sql6 + patiosql + chofersql + gastossql6 + unionsql
            sql7 = sql7 + patiosql + chofersql + gastossql7

            sql = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7
            sql = sql + ")D1 " + ordenar

            'If PATIO = "TODOS" Then
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS '" + FINI + "','" + FFIN + "','NO PAGADOS' "

            'Else
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS_patio '" + FINI + "','" + FFIN + "','NO PAGADOS' ,'" + PATIO + "'"

            'End If

        ElseIf TIPO.Equals("PAGADOS Y NO PAGADOS") Then
            Dim unionsql = " UNION ALL "

            sql = "DECLARE @FINI AS VARCHAR(25) DECLARE @FFIN AS VARCHAR(25) DECLARE @CHOFER AS VARCHAR(200) DECLARE @CHOFER1 AS VARCHAR(200) " &
            "DECLARE @PATIO AS VARCHAR(200) DECLARE @GASTOS AS VARCHAR(200) DECLARE @GASTOS1 AS VARCHAR(200) " &
            "SET @FINI='" & FINI & "' SET @FFIN='" & FFIN & "' 	SET @CHOFER='" & CHOFER & "' 	SET @CHOFER1='" & CHOFER1 & "' SET @PATIO='" & PATIO &
            "' SET @GASTOS ='" & GASTO & "' SET @GASTOS1='" & GASTO1 & "' " &
            "SELECT  D1.SOLICITUD,D1.OPERADOR,D1.NOMBRE,D1.DESCRIP,D1.TALON,D1.FECHA_EMI,D1.FECHA_PAGO,D1.NUM_ECO,D1.VERIFICA,D1.MONTO " &
            "FROM (SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE1 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE1) DESCRIP,TALON,FACTURA1	," &
            "FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
            ",VERIFICA,MONTO1 MONTO,CAUSA1 CAUSA,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI 	And @FFIN 	And MONTO1 > 0 	" &
            "And ESTATUS Not Like '%ELIMINADO%'  "

            Dim sql1 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE2 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE2) DESCRIP,TALON2,FACTURA2,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO2 MONTO	,CAUSA2,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN AND MONTO2 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  "

            Dim sql2 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE3 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE3) DESCRIP,TALON3,FACTURA3,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO3 MONTO,CAUSA3,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO3 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  "

            Dim sql3 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE4 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE4) DESCRIP,TALON4,FACTURA4,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO4 MONTO,CAUSA4,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO4 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  "

            Dim sql4 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE5 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE5) DESCRIP,TALON5,FACTURA5,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO5 MONTO,CAUSA5,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO5 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  "

            Dim sql5 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR	,NOMBRE,CLAVE6 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE6) DESCRIP,TALON6,FACTURA6	,FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO6 MONTO,CAUSA6,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO6 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  "

            Dim sql6 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE7 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE7) DESCRIP,TALON7,FACTURA7,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO7 MONTO,CAUSA7,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO7 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  "

            Dim sql7 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE8 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE8) DESCRIP,TALON8,FACTURA8,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO8 MONTO,CAUSA8,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO8 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%'  "

            Dim gastossql = "", gastossql1 = "", gastossql2 = "", gastossql3 = "", gastossql4 = "", gastossql5 = "", gastossql6 = "", gastossql7 = ""
            Dim chofersql = ""
            Dim patiosql = ""
            Dim ordenar = ""
            If cbporgasto.Text <> "TODOS" Or cbporgasto1.Text <> "TODOS" Then
                gastossql = "AND CLAVE1 BETWEEN @GASTOS AND @GASTOS1	"
                gastossql1 = "AND CLAVE2 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql2 = "AND CLAVE3 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql3 = "AND CLAVE4 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql4 = "AND CLAVE5 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql5 = "AND CLAVE6 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql6 = "AND CLAVE7 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql7 = "AND CLAVE8 BETWEEN @GASTOS AND @GASTOS1 "

            End If
            If cbporchofer.Text <> "TODOS" Or cbporchofer1.Text <> "TODOS" Then
                chofersql = "AND OPERADOR BETWEEN @CHOFER AND @CHOFER1 "

            End If
            If PATIO <> "TODOS" Then
                patiosql = "AND BASE_PAGO = @PATIO "

            End If

            If cbordenar.Text = "GASTO" Then
                ordenar = " ORDER BY D1.CLAVE,D1.SOLICITUD,D1.OPERADOR "
            ElseIf cbordenar.Text = "OPERADOR" Then
                ordenar = " ORDER BY D1.OPERADOR,D1.CLAVE,D1.SOLICITUD "
            ElseIf cbordenar.Text = "SOLICITUD" Then
                ordenar = " ORDER BY D1.SOLICITUD,D1.CLAVE,D1.OPERADOR "
            ElseIf cbordenar.Text = "CAUSA" Then
                Exit Sub
                'ordenar = " ORDER BY D1.CAUSA,D1.SOLICITUD,D1.CLAVE, D1.OPERADOR "
            End If

            sql = sql + patiosql + chofersql + gastossql + unionsql
            sql1 = sql1 + patiosql + chofersql + gastossql1 + unionsql
            sql2 = sql2 + patiosql + chofersql + gastossql2 + unionsql
            sql3 = sql3 + patiosql + chofersql + gastossql3 + unionsql
            sql4 = sql4 + patiosql + chofersql + gastossql4 + unionsql
            sql5 = sql5 + patiosql + chofersql + gastossql5 + unionsql
            sql6 = sql6 + patiosql + chofersql + gastossql6 + unionsql
            sql7 = sql7 + patiosql + chofersql + gastossql7

            sql = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7
            sql = sql + ")D1 " + ordenar

            'If PATIO = "TODOS" Then
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS '" + FINI + "','" + FFIN + "','NO PAGADOS' "

            'Else
            '    sql = "REPORTES_1_PAGADO_NOPAGADO_AMBOS_patio '" + FINI + "','" + FFIN + "','NO PAGADOS' ,'" + PATIO + "'"

            'End If

        End If

        Dim logdr As SqlDataAdapter = New SqlDataAdapter(sql, logconex)
        Dim dt_reporte As New Data.DataTable
        logdr.Fill(dt_reporte)
        If dt_reporte.Rows.Count = 0 Then
            MsgBox("NO SE ENCONTRARON DATOS")

        Else
            DatatableToExcel(dt_reporte, "C:\", DateTimePicker1.Value.ToString("yyyy-MMM-dd"), DateTimePicker2.Value.ToString("yyyy-MMM-dd"))

        End If

    End Sub

    Sub MULTASEINFRACCIONES(PATIO As String, GASTO As String, GASTO1 As String, CHOFER As String, CHOFER1 As String, FINI As String, FFIN As String, TIPO As String)

        sql = "DECLARE @FINI AS VARCHAR(25) DECLARE @FFIN AS VARCHAR(25) DECLARE @CHOFER AS VARCHAR(200) DECLARE @CHOFER1 AS VARCHAR(200) " &
            "DECLARE @PATIO AS VARCHAR(200) DECLARE @GASTOS AS VARCHAR(200) DECLARE @GASTOS1 AS VARCHAR(200) " &
            "SET @FINI='" & FINI & "' SET @FFIN='" & FFIN & "' 	SET @CHOFER='" & CHOFER & "' 	SET @CHOFER1='" & CHOFER1 & "' SET @PATIO='" & PATIO &
            "' SET @GASTOS ='" & GASTO & "' SET @GASTOS1='" & GASTO1 & "' " &
            "SELECT [SOLICITUD],[FACTURA1]	,[FACTURA2]	,[FACTURA3]	,[FACTURA4]	,[FACTURA5]	,[FACTURA6]	,[FACTURA7]	,[FACTURA8]	,[TALON],[TALON2],[TALON3],[TALON4],[TALON5] " &
            ",[TALON6]	,[TALON7],[TALON8]	,[VERIFICA]	,[OPERADOR],[NOMBRE],[CLAVE]	,[DESCRIP],[CLAVE1],[MONTO1],[CAUSA1],[CLAVE2],[MONTO2],[CAUSA2],[CLAVE3],[MONTO3]" &
            ",[CAUSA3],[CLAVE4],[MONTO4],[CAUSA4],[CLAVE5],[MONTO5],[CAUSA5],[CLAVE6]	,[MONTO6],[CAUSA6],[CLAVE7],[MONTO7],[CAUSA7],[CLAVE8],[MONTO8],[CAUSA8]" &
            ",[FECHA_EMI],[MONTO],[CAJA]	,[CLAVE_TRAF]	,[FECHAREG],[HORAREG],[FECHA_PAG],[CLAVE_CAJ],[FECHAREGCA],[HORAREGCAJ],[FECHA_CONS],[FECHA_PAGO]	,[BASE_PAGO]" &
            ",[DESTINO],[OBSERVA]	,[NUM_ECO],[PAGADO] FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO1 > 0 " &
            "AND ESTATUS NOT LIKE '%ELIMINADO%' "

        If cbporgasto.Text <> "TODOS" Or cbporgasto1.Text <> "TODOS" Then
            sql = sql + "AND (CLAVE1 BETWEEN @GASTOS AND @GASTOS1	OR CLAVE2 BETWEEN @GASTOS AND @GASTOS1 OR CLAVE3 BETWEEN @GASTOS AND @GASTOS1 " &
                "OR CLAVE4 BETWEEN @GASTOS AND @GASTOS1 	OR CLAVE5 BETWEEN @GASTOS AND @GASTOS1 OR CLAVE6 BETWEEN @GASTOS AND @GASTOS1 " &
                "OR CLAVE7 BETWEEN @GASTOS AND @GASTOS1 	OR CLAVE8 BETWEEN @GASTOS AND @GASTOS1) "
        End If
        If cbporchofer.Text <> "TODOS" Or cbporchofer1.Text <> "TODOS" Then
            sql = sql + "AND OPERADOR BETWEEN @CHOFER AND @CHOFER1 "
        End If
        If PATIO <> "TODOS" Then
            sql = sql + "AND BASE_PAGO = @PATIO "
        End If

        sql = sql + " ORDER BY SOLICITUD"

        Dim logconex = New SqlConnection(CONEXION_GASTOS)
        Dim logdr As SqlDataAdapter = New SqlDataAdapter(sql, logconex)
        Dim dt_reporte As New Data.DataTable
        logdr.Fill(dt_reporte)
        If dt_reporte.Rows.Count = 0 Then
            MsgBox("NO SE ENCONTRARON DATOS")

        Else
            DatatableToExcel(dt_reporte, "C:\", DateTimePicker1.Value.ToString("yyyy-MMM-dd"), DateTimePicker2.Value.ToString("yyyy-MMM-dd"))

        End If


    End Sub
    Sub MULTASEINFRACCCIONES_NUEVO(PATIO As String, GASTO As String, GASTO1 As String, CHOFER As String, CHOFER1 As String, FINI As String, FFIN As String, TIPO As String)

        Try

            Dim unionsql = " UNION ALL "

            sql = "DECLARE @FINI AS VARCHAR(25) DECLARE @FFIN AS VARCHAR(25) DECLARE @CHOFER AS VARCHAR(200) DECLARE @CHOFER1 AS VARCHAR(200) " &
            "DECLARE @PATIO AS VARCHAR(200) DECLARE @GASTOS AS VARCHAR(200) DECLARE @GASTOS1 AS VARCHAR(200) " &
            "SET @FINI='" & FINI & "' SET @FFIN='" & FFIN & "' 	SET @CHOFER='" & CHOFER & "' 	SET @CHOFER1='" & CHOFER1 & "' SET @PATIO='" & PATIO &
            "' SET @GASTOS ='" & GASTO & "' SET @GASTOS1='" & GASTO1 & "' " &
            "SELECT D1.SOLICITUD,D1.TALON,D1.NUM_ECO,D1.OPERADOR,D1.NOMBRE,D1.CLAVE,D1.DESCRIP,D1.MONTO,D1.CAUSA,D1.DESTINO,D1.FECHA_CONS,D1.BASE_PAGO," &
            "D1.FECHA_PAGO " &
            "FROM (SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE1 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE1) DESCRIP,TALON,FACTURA1	," &
            "FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
            ",VERIFICA,MONTO1 MONTO,CAUSA1 CAUSA,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI 	And @FFIN 	And MONTO1 > 0 	" &
            "And ESTATUS Not Like '%ELIMINADO%' "

            Dim sql1 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE2 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE2) DESCRIP,TALON2,FACTURA2,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO2 MONTO	,CAUSA2,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN AND MONTO2 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

            Dim sql2 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE3 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE3) DESCRIP,TALON3,FACTURA3,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO3 MONTO,CAUSA3,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO3 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

            Dim sql3 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE4 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE4) DESCRIP,TALON4,FACTURA4,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO4 MONTO,CAUSA4,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO4 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

            Dim sql4 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE5 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE5) DESCRIP,TALON5,FACTURA5,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO5 MONTO,CAUSA5,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO5 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

            Dim sql5 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR	,NOMBRE,CLAVE6 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE6) DESCRIP,TALON6,FACTURA6	,FECHA_EMI	,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO6 MONTO,CAUSA6,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO6 > 0  " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

            Dim sql6 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE7 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE7) DESCRIP,TALON7,FACTURA7,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA	,MONTO7 MONTO,CAUSA7,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO7 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

            Dim sql7 = "SELECT SOLICITUD,BASE_PAGO,DESTINO,NUM_ECO,OPERADOR,NOMBRE,CLAVE8 CLAVE,(SELECT DESCRIP FROM VARIOS WHERE CLAVE=CLAVE8) DESCRIP,TALON8,FACTURA8,FECHA_EMI,FECHA_CONS,FECHA_PAGO " &
                ",VERIFICA,MONTO8 MONTO,CAUSA8,OBSERVA FROM [Gastos_extras].[dbo].[EXCEDE] WHERE FECHA_EMI BETWEEN @FINI AND @FFIN 	AND MONTO8 > 0 " &
                "AND ESTATUS NOT LIKE '%ELIMINADO%' "

            Dim gastossql = "", gastossql1 = "", gastossql2 = "", gastossql3 = "", gastossql4 = "", gastossql5 = "", gastossql6 = "", gastossql7 = ""
            Dim chofersql = ""
            Dim patiosql = ""
            Dim ordenar = ""

            If cbporgasto.Text <> "TODOS" Or cbporgasto1.Text <> "TODOS" Then
                gastossql = "AND CLAVE1 BETWEEN @GASTOS AND @GASTOS1	"
                gastossql1 = "AND CLAVE2 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql2 = "AND CLAVE3 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql3 = "AND CLAVE4 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql4 = "AND CLAVE5 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql5 = "AND CLAVE6 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql6 = "AND CLAVE7 BETWEEN @GASTOS AND @GASTOS1 "
                gastossql7 = "AND CLAVE8 BETWEEN @GASTOS AND @GASTOS1 "

            End If
            If cbporchofer.Text <> "TODOS" Or cbporchofer1.Text <> "TODOS" Then
                chofersql = "AND OPERADOR BETWEEN @CHOFER AND @CHOFER1 "

            End If
            If PATIO <> "TODOS" Then
                patiosql = "AND BASE_PAGO = @PATIO "

            End If

            If cbordenar.Text = "GASTO" Then
                ordenar = " ORDER BY D1.CLAVE,D1.SOLICITUD,D1.OPERADOR "
            ElseIf cbordenar.Text = "OPERADOR" Then
                ordenar = " ORDER BY D1.OPERADOR,D1.CLAVE,D1.SOLICITUD "
            ElseIf cbordenar.Text = "SOLICITUD" Then
                ordenar = " ORDER BY D1.SOLICITUD,D1.CLAVE,D1.OPERADOR "
            ElseIf cbordenar.Text = "CAUSA" Then
                ordenar = " ORDER BY D1.CAUSA,D1.SOLICITUD,D1.CLAVE, D1.OPERADOR "
            End If

            sql = sql + patiosql + chofersql + gastossql + unionsql
            sql1 = sql1 + patiosql + chofersql + gastossql1 + unionsql
            sql2 = sql2 + patiosql + chofersql + gastossql2 + unionsql
            sql3 = sql3 + patiosql + chofersql + gastossql3 + unionsql
            sql4 = sql4 + patiosql + chofersql + gastossql4 + unionsql
            sql5 = sql5 + patiosql + chofersql + gastossql5 + unionsql
            sql6 = sql6 + patiosql + chofersql + gastossql6 + unionsql
            sql7 = sql7 + patiosql + chofersql + gastossql7

            sql = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7
            sql = sql + ")D1 " + ordenar

            Dim logconex = New SqlConnection(CONEXION_GASTOS)
            Dim logdr As SqlDataAdapter = New SqlDataAdapter(sql, logconex)
            Dim dt_reporte As New Data.DataTable
            logdr.Fill(dt_reporte)
            'DataGridView1.DataSource = dt_reporte
            If dt_reporte.Rows.Count = 0 Then
                MsgBox("NO SE ENCONTRARON DATOS")

            Else
                DatatableToExcel(dt_reporte, "C:\", DateTimePicker1.Value.ToString("yyyy-MMM-dd"), DateTimePicker2.Value.ToString("yyyy-MMM-dd"))
                'datagridview_a_excel(dt_reporte, "C:\", DateTimePicker1.Value.ToString("yyyy-MMM-dd"), DateTimePicker2.Value.ToString("yyyy-MMM-dd"))

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub DatatableToExcel(ByVal dtTemp As Data.DataTable, ByVal StrPath As String, F_INI As String, F_FIN As String)
        Dim _excel As New Microsoft.Office.Interop.Excel.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        _excel.Cells(2, 1) = "REPORTE: " & ComboBox1.Text
        _excel.Cells(3, 1) = " PATIO: " & cbporpatio.Text
        _excel.Cells(4, 1) = GroupBox1.Text & " DEL: " & F_INI & " AL: " & F_FIN
        If cbporgasto.Text = cbporgasto1.Text Then
            _excel.Cells(5, 1) = "GASTO: " & cbporgasto.Text
        Else
            _excel.Cells(5, 1) = "GASTOS DEL: " & cbporgasto.Text & " AL: " & cbporgasto1.Text
        End If

        If cbporchofer.Text = cbporchofer1.Text Then
            _excel.Cells(6, 1) = "CHOFER: " & cbporchofer.Text

        Else
            _excel.Cells(6, 1) = "CHOFER DEL: " & cbporchofer.Text & " AL: " & cbporchofer1.Text

        End If


        ' oSheet.Range("El rango de celdas").Merge(true)

        _excel.Range("A2:BJ2").Merge(True)
        _excel.Range("A3:BJ3").Merge(True)
        _excel.Range("A4:BJ4").Merge(True)
        _excel.Range("A5:BJ5").Merge(True)
        _excel.Range("A6:BJ6").Merge(True)

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            _excel.Cells(8, colIndex) = dc.ColumnName
        Next

        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                _excel.Cells(rowIndex + 8, colIndex) = dr(dc.ColumnName)
            Next
        Next

        Dim CELDASUMATORIA As String
        Dim SUMATORIA As String

        If ComboBox1.Text = "REPORTES" Then
            CELDASUMATORIA = "H" & rowIndex + 10 & ":H" & rowIndex + 10
            SUMATORIA = "=SUM(H9:h" & rowIndex + 8 & ")"
            _excel.Range(CELDASUMATORIA).Formula = SUMATORIA
            _excel.Cells(rowIndex + 10, 7) = "TOTAL MONTO"
            _excel.Range("H9:H" & rowIndex + 10).NumberFormat = "#,##0.00"

        ElseIf ComboBox1.Text = "PAGADOS Y NO PAGADOS" Or ComboBox1.Text = "PAGADOS" Or ComboBox1.Text = "NO PAGADOS" Then
            CELDASUMATORIA = "J" & rowIndex + 10 & ":J" & rowIndex + 10
            SUMATORIA = "=SUM(J9:J" & rowIndex + 8 & ")"
            _excel.Range(CELDASUMATORIA).Formula = SUMATORIA
            _excel.Cells(rowIndex + 10, 9) = "GRAN TOTAL"
            _excel.Range("J9:J" & rowIndex + 10).NumberFormat = "#,##0.00"


        End If

        'Dim CELDAFORMATONUMERO As String
        'CELDAFORMATONUMERO = "O9:O" & rowIndex + 10
        '_excel.Range(CELDAFORMATONUMERO).NumberFormat = "#,###.00_"

        wSheet.Columns.AutoFit()
        'Dim strFileName As String = StrPath & "datatable.xlsx"
        'If System.IO.File.Exists(strFileName) Then
        '    System.IO.File.Delete(strFileName)
        'End If

        'wBook.SaveAs(strFileName)
        'wBook.Close()
        '_excel.Quit()

        _excel.Visible = True

        'releaseObject(_excel)
        'releaseObject(wBook)
        'releaseObject(wSheet)

    End Sub

    Sub datagridview_a_excel(ByVal dtTemp As Data.DataTable, ByVal StrPath As String, F_INI As String, F_FIN As String)
        'Dim columnsCount As Integer = DataGridView1.Columns.Count
        'For Each column In DataGridView1.Columns
        '    Worksheet.Cells(1, column.Index + 1).Value = column.Name
        'Next
        'For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '    Dim columnIndex As Integer = 0
        '    Do Until columnIndex = columnsCount
        '        Worksheet.Cells(i + 2, columnIndex + 1).Value = DataGridView1.Item(columnIndex, i).Value.ToString
        '        columnIndex += 1
        '    Loop
        'Next

        Dim _excel As New Microsoft.Office.Interop.Excel.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        'Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        _excel.Cells(2, 1) = "REPORTE: " & ComboBox1.Text
        _excel.Cells(3, 1) = " PATIO: " & cbporpatio.Text
        _excel.Cells(4, 1) = GroupBox1.Text & " DEL: " & F_INI & " AL: " & F_FIN
        If cbporgasto.Text = cbporgasto1.Text Then
            _excel.Cells(5, 1) = "GASTO: " & cbporgasto.Text
        Else
            _excel.Cells(5, 1) = "GASTOS DEL: " & cbporgasto.Text & " AL: " & cbporgasto1.Text
        End If

        If cbporchofer.Text = cbporchofer1.Text Then
            _excel.Cells(6, 1) = "CHOFER: " & cbporchofer.Text

        Else
            _excel.Cells(6, 1) = "CHOFER DEL: " & cbporchofer.Text & " AL: " & cbporchofer1.Text

        End If


        ' oSheet.Range("El rango de celdas").Merge(true)

        _excel.Range("A2:BJ2").Merge(True)
        _excel.Range("A3:BJ3").Merge(True)
        _excel.Range("A4:BJ4").Merge(True)
        _excel.Range("A5:BJ5").Merge(True)
        _excel.Range("A6:BJ6").Merge(True)

        Dim columnsCount As Integer = DataGridView1.Columns.Count
        For Each column In DataGridView1.Columns
            _excel.Cells(8, column.Index + 1).Value = column.Name
        Next
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim columnIndex As Integer = 0
            Do Until columnIndex = columnsCount
                _excel.Cells(i + 8, columnIndex + 1).Value = DataGridView1.Item(columnIndex, i).Value.ToString
                columnIndex += 1
            Loop
        Next

        'For Each dc In dt.Columns
        '    colIndex = colIndex + 1
        '    _excel.Cells(8, colIndex) = dc.ColumnName
        'Next

        'For Each dr In dt.Rows
        '    rowIndex = rowIndex + 1
        '    colIndex = 0
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        _excel.Cells(rowIndex + 8, colIndex) = dr(dc.ColumnName)
        '    Next
        'Next

        If ComboBox1.Text <> "MULTAS E INFRACCIONES" Then
            Dim CELDASUMATORIA As String
            Dim SUMATORIA As String

            CELDASUMATORIA = "O" & rowIndex + 10 & ":O" & rowIndex + 10
            SUMATORIA = "=SUM(O9:O" & rowIndex + 8 & ")"

            _excel.Range(CELDASUMATORIA).Formula = SUMATORIA
            _excel.Cells(rowIndex + 10, 2) = "TOTAL MONTO"
        End If

        If cbordenar.Text <> "" Then

        End If


        'Dim CELDAFORMATONUMERO As String
        'CELDAFORMATONUMERO = "O9:O" & rowIndex + 10
        '_excel.Range(CELDAFORMATONUMERO).NumberFormat = "#,###.00_"

        wSheet.Columns.AutoFit()
        'Dim strFileName As String = StrPath & "datatable.xlsx"
        'If System.IO.File.Exists(strFileName) Then
        '    System.IO.File.Delete(strFileName)
        'End If

        'wBook.SaveAs(strFileName)
        'wBook.Close()
        '_excel.Quit()

        _excel.Visible = True

        'releaseObject(_excel)
        'releaseObject(wBook)
        'releaseObject(wSheet)
    End Sub


    Private Sub releaseObject(excel As Application)
        Throw New NotImplementedException()
    End Sub

    Function VALIDAR_DATOS() As Boolean

        Dim FALLA As Boolean = True
        If ComboBox1.Text = "SELECCIONE ......" Then
            MsgBox("SELECCIONE UN TIPO DE REPORTE")
            FALLA = False
        ElseIf cbporgasto.Text = "SELECCIONE ......" Or cbporgasto1.Text = "SELECCIONE ......" Then
            MsgBox("SELECCIONE UN GASTO ")
            FALLA = False

        ElseIf cbporgasto.SelectedValue > cbporgasto1.SelectedValue Then
            MsgBox("SELECCIONE GASTOS CON RANGO DE CODIGOS DE MENOR A MAYOR  ")
            FALLA = False

        ElseIf cbporgasto.Text = "TODOS" And cbporgasto1.Text <> "TODOS" Then
            MsgBox("VERIFIQUE RANGO DE CODIGOS DE MENOR A MAYOR  ")
            FALLA = False

        ElseIf cbporgasto.Text <> "TODOS" And cbporgasto1.Text = "TODOS" Then
            MsgBox("VERIFIQUE RANGO DE CODIGOS DE MENOR A MAYOR  ")
            FALLA = False

        ElseIf cbporchofer.Text = "SELECCIONE ......" Or cbporchofer1.Text = "SELECCIONE ......" Then
            MsgBox("SELECCIONE UN CHOFER")
            FALLA = False

        ElseIf cbporchofer.SelectedValue > cbporchofer1.SelectedValue Then
            MsgBox("SELECCIONE GASTOS CON RANGO DE CODIGOS DE MENOR A MAYOR  ")
            FALLA = False

        ElseIf cbporchofer.Text = "TODOS" And cbporchofer1.Text <> "TODOS" Then
            MsgBox("VERIFIQUE RANGO DE CODIGOS DE MENOR A MAYOR  ")
            FALLA = False

        ElseIf cbporchofer.Text <> "TODOS" And cbporchofer1.Text = "TODOS" Then
            MsgBox("VERIFIQUE RANGO DE CODIGOS DE MENOR A MAYOR  ")
            FALLA = False

        ElseIf cbporpatio.Text = "SELECCIONE ......" Then
            MsgBox("SELECCIONE UN PATIO")
            FALLA = False
        End If
        Return FALLA

    End Function

    Private Sub cbporgasto_Leave(sender As Object, e As EventArgs) Handles cbporgasto.Leave
        If cbporgasto.Text = "TODOS" Then
            cbporgasto1.Text = "TODOS"
        End If
    End Sub

    Private Sub cbporgasto1_Leave(sender As Object, e As EventArgs) Handles cbporgasto1.Leave
        If cbporgasto1.Text = "TODOS" Then
            cbporgasto.Text = "TODOS"
        End If

    End Sub

    Private Sub cbporchofer_Leave(sender As Object, e As EventArgs) Handles cbporchofer.Leave
        If cbporchofer.Text = "TODOS" Then
            cbporchofer1.Text = "TODOS"
        End If
    End Sub

    Private Sub cbporchofer1_Leave(sender As Object, e As EventArgs) Handles cbporchofer1.Leave
        If cbporchofer1.Text = "TODOS" Then
            cbporchofer.Text = "TODOS"
        End If
    End Sub

    Private Sub cbporchofer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbporchofer.SelectedIndexChanged

    End Sub
End Class