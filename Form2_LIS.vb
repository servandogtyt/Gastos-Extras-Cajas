Imports System.Data.SqlClient
Imports System.Globalization

Public Class Form2_LIS

    Public conexsql As SqlConnection
    Public fcons, fpago, femision As String
    Public PATIO As String
    Public buscardt As DataTable
    Public buscardt_SUMA As DataTable
    Public registro As Integer
    Public registrodt As Integer
    Public solicitud As String
    Dim buscar_nuevosgastos_conec As SqlConnection
    Public SOLICITUDES_ENVIAR As DataTable = New DataTable
    Public monto_total As Double = 0
    Public monto_total_SOLICITUD As Double = 0
    Public SUMA_SOLICITUD As String
    Public ultima_solicitud As Integer
    Public primera_solicitud As Integer
    Public SOLICDT As DataTable
    Public OPERADOR As String
    Public CAJA As String
    Public TEXTO = ""
    Public TEXTO1 = ""
    Public SQL1 = ""
    Public AUTORIZA = ""
    Public NUM_OPERADOR As String = ""

    Public dATOS_REPETIDOS As New Data.DataTable
    Private Sub Form2_LIS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Label17.Text = "PROCESANDO................"
            Me.Refresh()

            SOLICITUDES_ENVIAR.Columns.Add("Solicitud")

            lblsesion.Text = "NOMBRE DE USUARIO;  " & nombre & "    " & DateTime.Today.ToString("D") & "  " & usuario_basepago


            'sql = "select patio from patios UNION ALL SELECT 'SELECCIONE ......' "
            conexsql = New SqlConnection(CONEXION_GASTOS)
            conexsql.Open()
            Dim sqlda As SqlDataAdapter
            Dim ds As DataSet = New DataSet
            Dim ds1 As DataSet = New DataSet

            'sql = "SELECT * FROM (SELECT TC.nombre ciudad FROM trafico_cliente TC INNER JOIN desp_cliente_sucursal DCS ON TC.id_cliente = DCS.id_cliente  " &
            '                        "WHERE TC.nombre LIKE '%SU TRANSPORTE %' " &
            '                       "UNION ALL SELECT 'SELECCIONE ......')D1 ORDER BY D1.ciudad "
            sql = "select patio from patios_lis where encargado<>'' union all SELECT 'SELECCIONE ......' "

            sqlda = New SqlDataAdapter(sql, conexsql)
            sqlda.Fill(ds)
            cbpatio.DataSource = ds.Tables(0)
            cbpatio.DisplayMember = "patio"
            cbpatio.ValueMember = "patio"
            'cbpatio.Text = "SELECCIONE ......"
            cbpatio.Text = usuario_basepago

            sqlda.Dispose()
            conexsql.Close()

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "SELECT D1.desc_plaza FROM (select tp.desc_plaza from trafico_plaza tp union all select 'SELECCIONE.....')D1 ORDER BY D1.desc_plaza asc"
            sqlda = New SqlDataAdapter(sql, conexsql)
            sqlda.Fill(ds1)
            cbdestino.DataSource = ds1.Tables(0)
            cbdestino.DisplayMember = "desc_plaza"
            cbdestino.ValueMember = "desc_plaza"
            cbdestino.Text = "SELECCIONE ......"
            sqlda.Dispose()
            conexsql.Close()

            conexsql = New SqlConnection(CONEXION_GASTOS)
            conexsql.Open()
            sql = "SELECT * FROM (SELECT 1 CLAVE,'LIQUIDACION' DESCRIP UNION ALL SELECT '', '' UNION ALL SELECT CLAVE, DESCRIP FROM VARIOS ) D1 "

            sqlda = New SqlDataAdapter(sql, conexsql)
            Dim dsvarios1 = New DataSet
            Dim dsvarios2 = New DataSet
            Dim dsvarios3 = New DataSet
            Dim dsvarios4 = New DataSet
            Dim dsvarios5 = New DataSet
            Dim dsvarios6 = New DataSet
            Dim dsvarios7 = New DataSet
            Dim dsvarios8 = New DataSet

            sqlda.Fill(dsvarios1)
            sqlda.Fill(dsvarios2)
            sqlda.Fill(dsvarios3)
            sqlda.Fill(dsvarios4)
            sqlda.Fill(dsvarios5)
            sqlda.Fill(dsvarios6)
            sqlda.Fill(dsvarios7)
            sqlda.Fill(dsvarios8)

            cbdescripciongastos1.DataSource = dsvarios1.Tables(0)
            cbdescripciongastos1.DisplayMember = "DESCRIP"
            cbdescripciongastos1.ValueMember = "CLAVE"
            cbdescripciongastos1.Text = "SELECCIONE ......"
            cbdescripciongastos2.DataSource = dsvarios2.Tables(0)
            cbdescripciongastos2.DisplayMember = "DESCRIP"
            cbdescripciongastos2.ValueMember = "CLAVE"
            cbdescripciongastos2.Text = "SELECCIONE ......"
            cbdescripciongastos3.DataSource = dsvarios3.Tables(0)
            cbdescripciongastos3.DisplayMember = "DESCRIP"
            cbdescripciongastos3.ValueMember = "CLAVE"
            cbdescripciongastos3.Text = "SELECCIONE ......"
            cbdescripciongastos4.DataSource = dsvarios4.Tables(0)
            cbdescripciongastos4.DisplayMember = "DESCRIP"
            cbdescripciongastos4.ValueMember = "CLAVE"
            cbdescripciongastos4.Text = "SELECCIONE ......"
            cbdescripciongastos5.DataSource = dsvarios5.Tables(0)
            cbdescripciongastos5.DisplayMember = "DESCRIP"
            cbdescripciongastos5.ValueMember = "CLAVE"
            cbdescripciongastos5.Text = "SELECCIONE ......"
            cbdescripciongastos6.DataSource = dsvarios6.Tables(0)
            cbdescripciongastos6.DisplayMember = "DESCRIP"
            cbdescripciongastos6.ValueMember = "CLAVE"
            cbdescripciongastos6.Text = "SELECCIONE ......"
            cbdescripciongastos7.DataSource = dsvarios7.Tables(0)
            cbdescripciongastos7.DisplayMember = "DESCRIP"
            cbdescripciongastos7.ValueMember = "CLAVE"
            cbdescripciongastos7.Text = "SELECCIONE ......"
            cbdescripciongastos8.DataSource = dsvarios8.Tables(0)
            cbdescripciongastos8.DisplayMember = "DESCRIP"
            cbdescripciongastos8.ValueMember = "CLAVE"
            cbdescripciongastos8.Text = "SELECCIONE ......"

            'txtfemision.Text = Format(CDate(dtpemision.Value), "dd MMMM yyyy")
            sqlda.Dispose()
            conexsql.Close()

            btnadd.Enabled = True

            If moduio.Equals("CAJA Y NOMINA") Or moduio.Equals("CAJA") Then
                btnadd.Enabled = False
                btndelete.Enabled = False
                btncancelar.Enabled = False
                btncatalogo.Enabled = False
                btnadd.Enabled = False
                Label17.Text = ""
                inhabilitar_Textbox(Me)
                CAJA = usuario
                usuario = ""
                btnagregargastossol.Enabled = False
                btnanterior.Enabled = False
                btnantsol.Enabled = False
                btnprimero.Enabled = False
                btnprimersol.Enabled = False
                btnsigsol.Enabled = False
                btnsiguiente.Enabled = False
                btnultimasol.Enabled = False
                btnultimo.Enabled = False
                btnimpresion.Enabled = True
                'btnlocate.Enabled = False
                btnreportes.Enabled = False
                dtpcons.Enabled = False
                dtpemision.Enabled = False
                ChckAUTORIZA.Enabled = False

            Else
                actualizar_ultimasolicitud()

            End If

            Label17.Text = ""

        Catch ex As Exception
            'conexsql.Close()
            MsgBox(ex.ToString)

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnlocate.Click
        locate.Show()
        Me.Hide()

    End Sub
    Private Sub dtpemision_CloseUp(sender As Object, e As EventArgs) Handles dtpemision.CloseUp
        txtfemision.Text = Format(CDate(dtpemision.Value), "dd MMMM yyyy")
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btncatalogo.Click
        catalogo.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Dim sqlcom As SqlCommand
        Dim sqldr As SqlDataReader

        Try
            Label17.Text = "PROCESANDO........................."

            If btnadd.Text = "GUARDAR" Then
                conexsql = New SqlConnection(CONEXION_GASTOS)
                conexsql.Open()

                'If btnadd.Text = "GUARDAR(ADD)" Then

                Select Case MsgBox("¿GUARDAR SOLICITUD?", MsgBoxStyle.YesNo, "GUARDAR")
                    Case MsgBoxResult.Yes

                        sql = "select max(solicitud)+1 from excede WHERE ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL"
                        sqlcom = New SqlCommand
                        sqlcom.CommandText = sql
                        sqlcom.Connection = conexsql
                        sqldr = sqlcom.ExecuteReader
                        If sqldr.Read Then
                            txtsolicitud.Text = sqldr(0)
                        End If
                        sqldr.Close()

                        sql = "select solicitud from excede where solicitud='" & txtsolicitud.Text & "' AND (ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL)"
                        'sql = "select solicitud from excede where solicitud='411832' AND (ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL)"
                        sqlcom = New SqlCommand
                        sqlcom.CommandText = sql
                        sqlcom.Connection = conexsql
                        sqldr = sqlcom.ExecuteReader

                        If sqldr.Read Then
                            sqldr.Close()
                            MsgBox("EL NUMERO DE SOLICTUD YA EXISTE FAVOR DE VERIFICAR.....")
                            btnadd.Text = "ADD"
                            btncancelar.PerformClick()
                            Exit Sub
                        End If
                        sqldr.Close()

                        If VALIDAR_DATOS() = False Then
                            Exit Sub
                        End If

                        If txtfcons.Text = "" Then
                            fcons = "NULL"
                        Else
                            fcons = "'" & Format(CDate(dtpcons.Value), "yyyyMMdd") & "'"
                        End If

                        If txtfpago.Text = "" Then
                            fpago = "NULL"
                        Else
                            fpago = "'" & Format(CDate(dtppago.Value), "yyyyMMdd") & "'"
                        End If

                        If ChckAUTORIZA.Checked <> True Then
                            AUTORIZA = "NULL"
                        Else
                            AUTORIZA = "'" & usuario & "'"
                        End If


                        sql = " GUARDA_SOLICITUD " & txtsolicitud.Text & ",'" & txtFactura1.Text & "','" & txtFactura2.Text & "','" & txtFactura3.Text & "','" & txtFactura4.Text &
                       "','" & txtFactura5.Text & "','" & txtFactura6.Text & "','" & txtFactura7.Text & "','" & txtFactura8.Text & "','" & txtTalon1.Text & "','" & txtTalon2.Text & "','" & txtTalon3.Text &
                       "','" & txtTalon4.Text & "','" & txtTalon5.Text & "','" & txtTalon6.Text & "','" & txtTalon7.Text & "','" & txtTalon8.Text & "'," & AUTORIZA & "," & txtOperador.Text & ",'" & txtNombreOperador.Text &
                       "',0,NULL," & cbdescripciongastos1.SelectedValue & "," & CDbl(txtmonto1.Text) & ",'" & txtcausa1.Text & "'," & cbdescripciongastos2.SelectedValue & "," & CDbl(txtmonto2.Text) & ",'" &
                       txtcausa2.Text & "'," & cbdescripciongastos3.SelectedValue & "," & CDbl(txtmonto3.Text) & ",'" & txtcausa3.Text & "'," & cbdescripciongastos4.SelectedValue & "," & CDbl(txtmonto4.Text) & ",'" &
                       txtcausa4.Text & "'," & cbdescripciongastos5.SelectedValue & "," & CDbl(txtmonto5.Text) & ",'" & txtcausa5.Text & "'," & cbdescripciongastos6.SelectedValue & "," & CDbl(txtmonto6.Text) & ",'" &
                       txtcausa6.Text & "'," & cbdescripciongastos7.SelectedValue & "," & CDbl(txtmonto7.Text) & ",'" & txtcausa7.Text & "'," & cbdescripciongastos8.SelectedValue & "," & CDbl(txtmonto8.Text) & ",'" &
                       txtcausa8.Text & "','" & DateTime.Now.ToString("yyyyMMdd") & "',0,NULL,NULL,'" & DateTime.Now.ToString("yyyyMMdd") & "','" & DateTime.Now.ToString("HH:mm:ss") &
                       "',NULL,NULL,NULL,NULL," & fcons &
                       "," & fpago & ",'" & cbpatio.Text & "','" & cbdestino.Text &
                       "','" & txtobservaciones.Text & "','" & txtequipo.Text & "',NULL,'AGREGADO POR: " & usuario & " " &
                    DateTime.Now.ToString("dd MMM yyy HH:mm:ss") & "'"



                        sqlcom = New SqlCommand
                        sqlcom.CommandText = sql
                        sqlcom.Connection = conexsql
                        sqlcom.ExecuteNonQuery()
                        conexsql.Close()

                        MsgBox("DATOS GUARDADOS, SOLICITUD: " & txtsolicitud.Text)
                        btnadd.Enabled = True
                        btnadd.Text = "ADD"
                        btnlocate.Enabled = True
                        btnedit.Enabled = True
                        btndelete.Enabled = True
                        btncatalogo.Enabled = True
                        btnimpresion.Enabled = False
                        btnbuscar.Enabled = True

                        actualizar_ultimasolicitud()

                    Case MsgBoxResult.No
                        Exit Sub

                End Select


            ElseIf btnadd.Text = "ADD" Then
                btnadd.Text = "GUARDAR"
                Limpiar_TextBox(Me)
                btnedit.Enabled = False
                btndelete.Enabled = False
                btnimpresion.Enabled = False
                btnlocate.Enabled = False
                btnbuscar.Enabled = False
                btnsigsol.Enabled = False
                btnantsol.Enabled = False
                btnultimasol.Enabled = False
                btnprimersol.Enabled = False
                cbdestino.Text = "SELECCIONE ......"
                cbpatio.Text = "SELECCIONE ......"
                'cbpatio.Text = PATIO
                Label16.Text = ""
                SUMA_SOLICITUD = 0
                btnprimero.Enabled = False
                btnanterior.Enabled = False
                btnsiguiente.Enabled = False
                btnultimo.Enabled = False
                btnagregargastossol.Enabled = False
                lblregistros.Text = ""
                OPERADOR = ""
                registrodt = 0
                txtTalon1.Select()
                ChckAUTORIZA.Checked = False

            End If

            conexsql.Close()

            Label17.Text = ""
            Me.Refresh()

        Catch ex As Exception
            conexsql.Close()
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        Label17.Text = "PROCESANDO........................."
        Form3.Show()
        Label17.Text = ""

    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        btnlocate.Enabled = True

        btnadd.Enabled = True
        btnadd.Text = "ADD"
        btnedit.Enabled = True
        btndelete.Enabled = True
        btncatalogo.Enabled = True
        btnimpresion.Enabled = False
        btnreportes.Enabled = True
        btnbuscar.Enabled = True
        btnantsol.Enabled = True
        btnprimersol.Enabled = True
        btnsigsol.Enabled = False
        btnultimasol.Enabled = False
        'Limpiar_TextBox(Me)
        registro = 0
        lblregistros.Text = ""
        Label16.Text = ""
        ChckAUTORIZA.Checked = False
        actualizar_ultimasolicitud()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        End
    End Sub

    Sub Limpiar_TextBox(ByVal formulario As Form)
        For Each controlText As Windows.Forms.Control In Me.TableLayoutPanel1.Controls
            If TypeOf controlText Is TextBox Then
                CType(controlText, TextBox).Clear()
            End If
            If TypeOf controlText Is ComboBox Then
                CType(controlText, ComboBox).Text = "SELECCIONE ......"
            End If
        Next

        For Each controlText As Windows.Forms.Control In Me.Panel1.Controls
            If TypeOf controlText Is TextBox Then
                CType(controlText, TextBox).Clear()
            End If

        Next

        txtmonto1.Text = "0.00"
        txtmonto2.Text = "0.00"
        txtmonto3.Text = "0.00"
        txtmonto4.Text = "0.00"
        txtmonto5.Text = "0.00"
        txtmonto6.Text = "0.00"
        txtmonto7.Text = "0.00"
        txtmonto8.Text = "0.00"

    End Sub

    Sub inhabilitar_Textbox(ByVal formulario As Form)
        For Each controlText As Windows.Forms.Control In Me.TableLayoutPanel1.Controls
            If TypeOf controlText Is TextBox Then
                CType(controlText, TextBox).Enabled = False
            End If
            If TypeOf controlText Is ComboBox Then
                CType(controlText, ComboBox).Enabled = False
            End If
        Next

        For Each controlText As Windows.Forms.Control In Me.Panel1.Controls
            If TypeOf controlText Is TextBox Then
                CType(controlText, TextBox).Enabled = False
            End If
            If TypeOf controlText Is ComboBox Then
                CType(controlText, ComboBox).Enabled = False
            End If
        Next

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnimpresion.Click
        Form4.Show()
    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub


    Private Sub dtpcons_CloseUp(sender As Object, e As EventArgs) Handles dtpcons.CloseUp
        txtfcons.Text = Format(CDate(dtpcons.Value), "dd MMMM yyyy")

    End Sub


    Private Sub dtppago_CloseUp(sender As Object, e As EventArgs) Handles dtppago.CloseUp
        txtfpago.Text = Format(CDate(dtppago.Value), "dd MMMM yyyy")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        Try

            Label17.Text = "PROCESANDO........................."

            Dim sqlcom_EDIT As SqlCommand
            Dim SQLDR As SqlDataReader
            Dim RESPUESTA_PROCEDIMIENTO As String = ""

            ' If btnedit.Text = "GUARDAR(EDIT)" Then
            Select Case MsgBox("¿ACTUALIZAR REGISTRO?", MsgBoxStyle.YesNo, "ACTUALIZAR")
                Case MsgBoxResult.Yes

                    If VALIDAR_DATOS() = False Then
                        Exit Sub
                    End If

                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()

                    If txtfemision.Text = "-" Or txtfemision.Text = "" Then
                        femision = "NULL"
                    Else
                        femision = "'" & Format(CDate(txtfemision.Text), "yyyyMMdd") & "'"
                    End If
                    If txtfcons.Text = "-" Or txtfcons.Text = "" Then
                        fcons = "NULL"
                    Else
                        'fcons = "'" & Format(CDate(dtpcons.Value), "dd/MM/yyyy") & "'"
                        fcons = "'" & Format(CDate(txtfcons.Text), "yyyyMMdd") & "'"
                    End If

                    If txtfpago.Text = "-" Or txtfpago.Text = "" Then
                        If moduio = "CAJA Y NOMINA" Then
                            MsgBox("FALTA FECHA DE PAGO")
                            Label17.Text = ""
                            Exit Sub
                        Else
                            fpago = "NULL"
                        End If
                    Else
                        'fpago = "'" & Format(CDate(dtppago.Value), "dd/MM/yyyy") & "'"
                        fpago = "'" & Format(CDate(txtfpago.Text), "yyyyMMdd") & "'"
                    End If
                    If txtOperador.Text = "" Or txtOperador.Text = "-" Then
                        txtOperador.Text = 0
                    End If
                    If txtequipo.Text = "" Or txtequipo.Text = "-" Then
                        txtequipo.Text = ""
                    End If

                    If ChckAUTORIZA.Checked <> True Then
                        AUTORIZA = "NULL"
                    Else
                        AUTORIZA = "'" & usuario & "'"
                    End If


                    If moduio.Equals("CAJA Y NOMINA") Or moduio.Equals("CAJA") Then

                        sql = " ACTUALIZAR_SOLICITUD " & txtsolicitud.Text & ",'" & txtFactura1.Text & "','" & txtFactura2.Text & "','" & txtFactura3.Text & "','" & txtFactura4.Text &
                   "','" & txtFactura5.Text & "','" & txtFactura6.Text & "','" & txtFactura7.Text & "','" & txtFactura8.Text & "','" & txtTalon1.Text & "','" & txtTalon2.Text & "','" & txtTalon3.Text &
                   "','" & txtTalon4.Text & "','" & txtTalon5.Text & "','" & txtTalon6.Text & "','" & txtTalon7.Text & "','" & txtTalon8.Text & "'," & txtOperador.Text & "," & AUTORIZA & ",'" & txtNombreOperador.Text &
                   "',0,NULL," & cbdescripciongastos1.SelectedValue & "," & CDbl(txtmonto1.Text) & ",'" & txtcausa1.Text & "'," & cbdescripciongastos2.SelectedValue & "," & CDbl(txtmonto2.Text) & ",'" &
                   txtcausa2.Text & "'," & cbdescripciongastos3.SelectedValue & "," & CDbl(txtmonto3.Text) & ",'" & txtcausa3.Text & "'," & cbdescripciongastos4.SelectedValue & "," & CDbl(txtmonto4.Text) & ",'" &
                   txtcausa4.Text & "'," & cbdescripciongastos5.SelectedValue & "," & CDbl(txtmonto5.Text) & ",'" & txtcausa5.Text & "'," & cbdescripciongastos6.SelectedValue & "," & CDbl(txtmonto6.Text) & ",'" &
                   txtcausa6.Text & "'," & cbdescripciongastos7.SelectedValue & "," & CDbl(txtmonto7.Text) & ",'" & txtcausa7.Text & "'," & cbdescripciongastos8.SelectedValue & "," & CDbl(txtmonto8.Text) & ",'" &
                   txtcausa8.Text & "'," & femision & ",0,NULL,NULL,'" & DateTime.Now.ToString("yyyyMMdd") & "','" & DateTime.Now.ToString("HH:mm:ss") &
                   "',NULL,'" & CAJA & "','" & DateTime.Now.ToString("yyyy-MM-dd") & "','" & DateTime.Now.ToString("HH:mm:ss") &
                   "'," & fcons & "," & fpago & ",'" & cbpatio.Text & "','" & cbdestino.Text &
                   "','" & txtobservaciones.Text & "','" & txtequipo.Text & "','SI','PAGADO A CAJERA: " & CAJA & " " & DateTime.Now.ToString("dd MMM yyy HH:mm:ss") & "'," & ID_SOLICITUD & ",'1' "



                    Else

                        sql = " ACTUALIZAR_SOLICITUD " & txtsolicitud.Text & ",'" & txtFactura1.Text & "','" & txtFactura2.Text & "','" & txtFactura3.Text & "','" & txtFactura4.Text &
                   "','" & txtFactura5.Text & "','" & txtFactura6.Text & "','" & txtFactura7.Text & "','" & txtFactura8.Text & "','" & txtTalon1.Text & "','" & txtTalon2.Text & "','" & txtTalon3.Text &
                   "','" & txtTalon4.Text & "','" & txtTalon5.Text & "','" & txtTalon6.Text & "','" & txtTalon7.Text & "','" & txtTalon8.Text & "'," & txtOperador.Text & "," & AUTORIZA & ",'" & txtNombreOperador.Text &
                   "',0,NULL," & cbdescripciongastos1.SelectedValue & "," & CDbl(txtmonto1.Text) & ",'" & txtcausa1.Text & "'," & cbdescripciongastos2.SelectedValue & "," & CDbl(txtmonto2.Text) & ",'" &
                   txtcausa2.Text & "'," & cbdescripciongastos3.SelectedValue & "," & CDbl(txtmonto3.Text) & ",'" & txtcausa3.Text & "'," & cbdescripciongastos4.SelectedValue & "," & CDbl(txtmonto4.Text) & ",'" &
                   txtcausa4.Text & "'," & cbdescripciongastos5.SelectedValue & "," & CDbl(txtmonto5.Text) & ",'" & txtcausa5.Text & "'," & cbdescripciongastos6.SelectedValue & "," & CDbl(txtmonto6.Text) & ",'" &
                   txtcausa6.Text & "'," & cbdescripciongastos7.SelectedValue & "," & CDbl(txtmonto7.Text) & ",'" & txtcausa7.Text & "'," & cbdescripciongastos8.SelectedValue & "," & CDbl(txtmonto8.Text) & ",'" &
                   txtcausa8.Text & "'," & femision & ",0,NULL,NULL,'" & DateTime.Now.ToString("yyyyMMdd") & "','" & DateTime.Now.ToString("HH:mm:ss") &
                   "',NULL,'" & CAJA & "',NULL,NULL," & fcons & "," & fpago & ",'" & cbpatio.Text & "','" & cbdestino.Text &
                   "','" & txtobservaciones.Text & "','" & txtequipo.Text & "','','MODIFICADO POR: " & usuario & " " & DateTime.Now.ToString("dd MMM yyy HH:mm:ss") & "'," & ID_SOLICITUD & ",'0' "


                        SQL1 = "UPDATE EXCEDE SET VERIFICA=" & AUTORIZA & " WHERE SOLICITUD=" & txtsolicitud.Text

                        sqlcom_EDIT = New SqlCommand
                        sqlcom_EDIT.CommandText = SQL1
                        sqlcom_EDIT.Connection = conexsql
                        SQLDR = sqlcom_EDIT.ExecuteReader()
                        SQLDR.Close()


                    End If

                    sqlcom_EDIT = New SqlCommand
                    sqlcom_EDIT.CommandText = sql
                    sqlcom_EDIT.Connection = conexsql
                    SQLDR = sqlcom_EDIT.ExecuteReader()


                    If SQLDR.Read Then
                        RESPUESTA_PROCEDIMIENTO = SQLDR(0).ToString()
                    End If
                    SQLDR.Close()
                    conexsql.Close()

                    If moduio = "CAJA Y NOMINA" Or moduio.Equals("CAJA") Then

                    Else

                        If RESPUESTA_PROCEDIMIENTO = "DATOS ACTUALIZADOS" Then

                            btnlocate.Enabled = True
                            'btnadd.Text = "ADD"
                            'btnedit.Text = "EDIT"
                            'btnadd.Enabled = True
                            'btnedit.Enabled = False
                            'btndelete.Enabled = False
                            'btncatalogo.Enabled = True
                            'btnimpresion.Enabled = False
                            'btnlimpiar.Enabled = True
                            'btnbuscar.Enabled = True
                            'btncancelar.Visible = False
                            'Limpiar_TextBox(Me)
                            MsgBox(RESPUESTA_PROCEDIMIENTO & " SOLICITUD: " & txtsolicitud.Text)

                        Else
                            MsgBox(RESPUESTA_PROCEDIMIENTO & " SOLICITUD: " & txtsolicitud.Text)

                        End If
                        actualizar_ultimasolicitud()

                    End If



                Case MsgBoxResult.No
                    conexsql.Close()

            End Select

            Label17.Text = ""
            Me.Refresh()

            'Else
            '    btnedit.Text = "GUARDAR(EDIT)"
            '    btncancelar.Visible = True
            '    btnadd.Enabled = False
            '    btnbuscar.Enabled = False
            '    btndelete.Enabled = False
            '    btnimpresion.Enabled = False
            '    btnlocate.Enabled = False


            'End If

        Catch ex As Exception
            Label17.Text = ""
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try


            Dim sqlcom_delete As SqlCommand

            Select Case MsgBox("¿ELIMINAR SOLICITUD: " & txtsolicitud.Text & " ?", MsgBoxStyle.YesNo, "caption")
                Case MsgBoxResult.Yes

                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()

                    sql = " ELIMINA_SOLICITUD " & txtsolicitud.Text & ",'ELIMINADO POR: " & usuario & " " &
                    DateTime.Now.ToString("dd MMM yyy HH:mm:ss") & "'"

                    'sql = "delete excede where solicitud=" & txtsolicitud.Text

                    sqlcom_delete = New SqlCommand
                    sqlcom_delete.CommandText = sql
                    sqlcom_delete.Connection = conexsql
                    sqlcom_delete.ExecuteNonQuery()
                    conexsql.Close()

                    MsgBox("REGISTRO ELIMINADO")
                    'btnlocate.Enabled = True
                    'btnadd.Text = "ADD"
                    'btnedit.Text = "EDIT"
                    'btnadd.Enabled = True
                    'btnedit.Enabled = False
                    'btndelete.Enabled = False
                    'btncatalogo.Enabled = True
                    'btnimpresion.Enabled = False
                    'btnlimpiar.Enabled = True
                    'btnbuscar.Enabled = True
                    'btncancelar.Visible = False
                    'Limpiar_TextBox(Me)

                    actualizar_ultimasolicitud()

                Case MsgBoxResult.No
                    conexsql.Close()

                    conexsql.Close()

            End Select

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Function VALIDAR_DATOS()
        Dim CORRECTO As Boolean = True

        If txtsolicitud.Text = "" Then
            MsgBox("SIN POLIZA")
            CORRECTO = False
            Label17.Text = ""
            txtsolicitud.Text = ""
        End If

        If txtOperador.Text = "" Then
            txtOperador.Text = 0
        End If
        If txtequipo.Text = "" Then
            txtequipo.Text = 0
        End If
        If txtmonto1.Text = "" Then
            txtmonto1.Text = 0
        End If
        If txtmonto2.Text = "" Then
            txtmonto2.Text = 0
        End If
        If txtmonto3.Text = "" Then
            txtmonto3.Text = 0
        End If
        If txtmonto4.Text = "" Then
            txtmonto4.Text = 0
        End If
        If txtmonto5.Text = "" Then
            txtmonto5.Text = 0
        End If
        If txtmonto6.Text = "" Then
            txtmonto6.Text = 0
        End If
        If txtmonto7.Text = "" Then
            txtmonto7.Text = 0
        End If
        If txtmonto8.Text = "" Then
            txtmonto8.Text = 0
        End If

        If cbpatio.Text = "SELECCIONE ......" Or cbdestino.Text = "SELECCIONE ......" Then
            MsgBox("SELECCIONE PATIO Y DESTINO")
            CORRECTO = False
            Label17.Text = ""
            txtsolicitud.Text = ""
        End If
        'If cbdescripciongastos1.Text = "SELECCIONE ......" Or cbdescripciongastos2.Text = "SELECCIONE ......" Or cbdescripciongastos3.Text = "SELECCIONE ......" Or cbdescripciongastos4.Text = "SELECCIONE ......" _
        '    Or cbdescripciongastos5.Text = "SELECCIONE ......" Or cbdescripciongastos6.Text = "SELECCIONE ......" Or cbdescripciongastos7.Text = "SELECCIONE ......" Or cbdescripciongastos8.Text = "SELECCIONE ......" Then
        '    MsgBox("SELECCIONE GASTO")
        '    CORRECTO = False
        '    Label17.Text = ""
        '    txtsolicitud.Text = ""
        'End If

        Return CORRECTO

    End Function


    Private Sub txtOperador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOperador.KeyDown

        'Try

        '    Dim SQLCOM_OPERADOR As SqlCommand
        '    Dim SQLDR_OPERADOR As SqlDataReader

        '    Select Case e.KeyData
        '        Case Keys.Enter

        '            If txtOperador.Text = "" Then
        '                txtOperador.Text = 0
        '                Exit Sub
        '            End If

        '            conexsql = New SqlConnection(CONEXION_GASTOS)
        '            conexsql.Open()
        '            sql = "Select NOMBRE FROM CHOFERES WHERE NUMERO=" & txtOperador.Text
        '            SQLCOM_OPERADOR = New SqlCommand
        '            SQLCOM_OPERADOR.CommandText = sql
        '            SQLCOM_OPERADOR.Connection = conexsql
        '            SQLDR_OPERADOR = SQLCOM_OPERADOR.ExecuteReader
        '            If SQLDR_OPERADOR.Read Then
        '                txtNombreOperador.Text = SQLDR_OPERADOR(0)
        '            End If
        '            SQLDR_OPERADOR.Close()
        '            conexsql.Close()

        '    End Select

        'Catch ex As Exception
        '    conexsql.Close()
        '    MsgBox(ex.ToString)
        'End Try

    End Sub

    Private Sub txtTalon1_Leave(sender As Object, e As EventArgs) Handles txtTalon1.Leave
        Try


            Dim SQLCOM_TALON1 As SqlCommand
            Dim SQLDR_TALON1 As SqlDataReader
            Dim texto_msgbox As String

            If txtTalon1.Text = "" Then
                MsgBox("ESCRIBA UN TALON O SOLICITUD DE PAGO VALIDO")
                Exit Sub
            End If

            Dim TALON As String
            TALON = txtTalon1.Text
            OPERADOR = txtOperador.Text
            'Limpiar_TextBox(Me)

            Label16.Text = ""
            SUMA_SOLICITUD = 0
            Me.Refresh()

            txtTalon1.Text = TALON

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "Select tg.num_guia, pp.id_personal No_Operador, pp.nombre,tg.id_unidad from trafico_guia tg inner join " &
                "personal_personal pp On tg.id_personal = pp.id_personal " &
                "where tg.num_guia = '" & txtTalon1.Text & "'"

            SQLCOM_TALON1 = New SqlCommand
            SQLCOM_TALON1.CommandText = sql
            SQLCOM_TALON1.Connection = conexsql
            SQLDR_TALON1 = SQLCOM_TALON1.ExecuteReader
            If SQLDR_TALON1.Read Then
                txtNombreOperador.Text = SQLDR_TALON1(2)
                txtOperador.Text = SQLDR_TALON1(1)
                txtTalon1.Text = SQLDR_TALON1(0)
                NUM_OPERADOR = SQLDR_TALON1(1)
                txtequipo.Text = SQLDR_TALON1(3)
                btnadd.Enabled = True
                txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                btnsiguiente.Enabled = False
                btnanterior.Enabled = False
                btnprimero.Enabled = False
                btnultimo.Enabled = False

            Else
                'btnadd.Enabled = False
                texto_msgbox = "TALON "
                SQLDR_TALON1.Close()
                'conexsql.Close()

                If Not IsNumeric(txtTalon1.Text) Then
                    MsgBox("NO ES UNA SOLICTUD DE RH NI UN TALON")
                    Exit Sub
                End If

                sql =
                "SELECT TOP 1 rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto,tg.id_unidad,RSP.fecha_solicitud,tg.fecha_guia,tg.num_guia," &
                     "TG.status_guia,RSP.status FROM rho_solicitud_pago RSP  " &
                     "INNER JOIN rho_solicitud_pago_det rspd ON rsp.id_solicitud = rspd.id_solicitud " &
                     "INNER JOIN personal_personal pp ON rsp.id_personal = pp.id_personal INNER JOIN trafico_guia tg ON tg.id_personal = rsp.id_personal " &
                     "WHERE rsp.id_solicitud = " & txtTalon1.Text & " AND TG.status_guia<>'C' AND RSP.status <> 'C' " &
                     "GROUP BY rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto	,tg.id_unidad	,RSP.fecha_solicitud	,tg.fecha_guia," &
                     "tg.num_guia,TG.status_guia,RSP.status ORDER BY tg.fecha_guia DESC"

                SQLCOM_TALON1 = New SqlCommand
                SQLCOM_TALON1.CommandText = sql
                SQLCOM_TALON1.Connection = conexsql
                SQLDR_TALON1 = SQLCOM_TALON1.ExecuteReader
                If SQLDR_TALON1.Read Then
                    txtNombreOperador.Text = SQLDR_TALON1(2)
                    txtOperador.Text = SQLDR_TALON1(1)
                    txtTalon1.Text = "LIS " & SQLDR_TALON1(0)
                    txtequipo.Text = SQLDR_TALON1(5)
                    txtmonto1.Text = Format(CDbl(SQLDR_TALON1(3)), "###,###,##0.00")
                    txtcausa1.Text = SQLDR_TALON1(4)
                    btnadd.Enabled = True
                    txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                    btnsiguiente.Enabled = False
                    btnanterior.Enabled = False
                    btnprimero.Enabled = False
                    btnultimo.Enabled = False

                Else
                    'btnadd.Enabled = False
                    MsgBox(" Y SOLICITUD NO ENCONTRADO FAVOR DE VERIFICAR")

                End If

            End If

            SQLDR_TALON1.Close()
            conexsql.Close()

            'conexsql.Close()
            If registrodt > 0 Then
                If txtOperador.Text <> OPERADOR Then
                    MsgBox("EL OPERADOR A CAMBIADO VERIFICAR")
                    Exit Sub
                End If
            End If



        Catch ex As Exception
            conexsql.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnprimero_Click(sender As Object, e As EventArgs) Handles btnprimero.Click
        Try

            primer_registro()
            monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

            Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                    Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
            Me.Refresh()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtmonto1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto1.KeyPress
        Try

            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsPunctuation(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
                MessageBox.Show("Solo numeros", "validacion numero", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnsiguiente_Click(sender As Object, e As EventArgs) Handles btnsiguiente.Click
        Try

            registro_siguiente()
            monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

            Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                    Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
            Me.Refresh()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Sub primer_registro()

        registro = 1
        lblregistros.Text = registro & " DE " & buscardt.Rows.Count

        registrodt = registro - 1
        For i = registrodt To registrodt

            ' Write value of first Integer.
            ' Console.WriteLine(row.Field(Of Integer)(0))
            txtsolicitud.Text = buscardt.Rows(i).Item("SOLICITUD")
            If IsDBNull(buscardt.Rows(i).Item("FACTURA1")) Or buscardt.Rows(i).Item("FACTURA1").Equals("") Then
                txtFactura1.Text = ""
            Else
                txtFactura1.Text = buscardt.Rows(i).Item("FACTURA1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA2")) Or buscardt.Rows(i).Item("FACTURA2").Equals("") Then
                txtFactura2.Text = ""
            Else
                txtFactura2.Text = buscardt.Rows(i).Item("FACTURA2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA3")) Or buscardt.Rows(i).Item("FACTURA3").Equals("") Then
                txtFactura3.Text = ""
            Else
                txtFactura3.Text = buscardt.Rows(i).Item("FACTURA3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA4")) Or buscardt.Rows(i).Item("FACTURA4").Equals("") Then
                txtFactura4.Text = ""
            Else
                txtFactura4.Text = buscardt.Rows(i).Item("FACTURA4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA5")) Or buscardt.Rows(i).Item("FACTURA5").Equals("") Then
                txtFactura5.Text = ""
            Else
                txtFactura5.Text = buscardt.Rows(i).Item("FACTURA5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA6")) Or buscardt.Rows(i).Item("FACTURA6").Equals("") Then
                txtFactura6.Text = ""
            Else
                txtFactura6.Text = buscardt.Rows(i).Item("FACTURA6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA7")) Or buscardt.Rows(i).Item("FACTURA7").Equals("") Then
                txtFactura7.Text = ""
            Else
                txtFactura7.Text = buscardt.Rows(i).Item("FACTURA7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA8")) Or buscardt.Rows(i).Item("FACTURA8").Equals("") Then
                txtFactura8.Text = ""
            Else
                txtFactura8.Text = buscardt.Rows(i).Item("FACTURA8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON")) Or buscardt.Rows(i).Item("TALON").Equals("") Then
                txtTalon1.Text = ""
            Else
                txtTalon1.Text = buscardt.Rows(i).Item("TALON")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON2")) Or buscardt.Rows(i).Item("TALON2").Equals("") Then
                txtTalon2.Text = ""
            Else
                txtTalon2.Text = buscardt.Rows(i).Item("TALON2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON3")) Or buscardt.Rows(i).Item("TALON3").Equals("") Then
                txtTalon3.Text = ""
            Else
                txtTalon3.Text = buscardt.Rows(i).Item("TALON3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON4")) Or buscardt.Rows(i).Item("TALON4").Equals("") Then
                txtTalon4.Text = ""
            Else
                txtTalon4.Text = buscardt.Rows(i).Item("TALON4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON5")) Or buscardt.Rows(i).Item("TALON5").Equals("") Then
                txtTalon5.Text = ""
            Else
                txtTalon5.Text = buscardt.Rows(i).Item("TALON5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON6")) Or buscardt.Rows(i).Item("TALON6").Equals("") Then
                txtTalon6.Text = ""
            Else
                txtTalon6.Text = buscardt.Rows(i).Item("TALON6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON7")) Or buscardt.Rows(i).Item("TALON7").Equals("") Then
                txtTalon7.Text = ""
            Else
                txtTalon7.Text = buscardt.Rows(i).Item("TALON7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON8")) Or buscardt.Rows(i).Item("TALON8").Equals("") Then
                txtTalon8.Text = ""
            Else
                txtTalon8.Text = buscardt.Rows(i).Item("TALON8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("OPERADOR")) Or buscardt.Rows(i).Item("OPERADOR").Equals(0) Then
                txtOperador.Text = ""
            Else
                txtOperador.Text = buscardt.Rows(i).Item("OPERADOR")
            End If
            If IsDBNull(buscardt.Rows(i).Item("NOMBRE")) Or buscardt.Rows(i).Item("NOMBRE").Equals("") Then
                txtNombreOperador.Text = ""
            Else
                txtNombreOperador.Text = buscardt.Rows(i).Item("NOMBRE")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE1")) Or buscardt.Rows(i).Item("CLAVE1").Equals("") Then
                cbdescripciongastos1.Text = ""
            Else
                cbdescripciongastos1.Text = buscardt.Rows(i).Item("CLAVE1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO1")) Or buscardt.Rows(i).Item("MONTO1").Equals(0) Then
                txtmonto1.Text = "0.00"
            Else
                txtmonto1.Text = Format(Val(buscardt.Rows(i).Item("MONTO1")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA1")) Or buscardt.Rows(i).Item("CAUSA1").Equals("") Then
                txtcausa1.Text = ""
            Else
                txtcausa1.Text = buscardt.Rows(i).Item("CAUSA1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE2")) Or buscardt.Rows(i).Item("CLAVE2").Equals("") Then
                cbdescripciongastos2.Text = ""
            Else
                cbdescripciongastos2.Text = buscardt.Rows(i).Item("CLAVE2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO2")) Or buscardt.Rows(i).Item("MONTO2").Equals(0) Then
                txtmonto2.Text = "0.00"
            Else
                txtmonto2.Text = Format(Val(buscardt.Rows(i).Item("MONTO2")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA2")) Or buscardt.Rows(i).Item("CAUSA2").Equals("") Then
                txtcausa2.Text = ""
            Else
                txtcausa2.Text = buscardt.Rows(i).Item("CAUSA2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE3")) Or buscardt.Rows(i).Item("CLAVE3").Equals("") Then
                cbdescripciongastos3.Text = ""
            Else
                cbdescripciongastos3.Text = buscardt.Rows(i).Item("CLAVE3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO3")) Or buscardt.Rows(i).Item("MONTO3").Equals(0) Then
                txtmonto3.Text = "0.00"
            Else
                txtmonto3.Text = Format(Val(buscardt.Rows(i).Item("MONTO3")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA3")) Or buscardt.Rows(i).Item("CAUSA3").Equals("") Then
                txtcausa3.Text = ""
            Else
                txtcausa3.Text = buscardt.Rows(i).Item("CAUSA3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE4")) Or buscardt.Rows(i).Item("CLAVE4").Equals("") Then
                cbdescripciongastos4.Text = ""
            Else
                cbdescripciongastos4.Text = buscardt.Rows(i).Item("CLAVE4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO4")) Or buscardt.Rows(i).Item("MONTO4").Equals(0) Then
                txtmonto4.Text = "0.00"
            Else
                txtmonto4.Text = Format(Val(buscardt.Rows(i).Item("MONTO4")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA4")) Or buscardt.Rows(i).Item("CAUSA4").Equals("") Then
                txtcausa4.Text = ""
            Else
                txtcausa4.Text = buscardt.Rows(i).Item("CAUSA4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE5")) Or buscardt.Rows(i).Item("CLAVE5").Equals("") Then
                cbdescripciongastos5.Text = ""
            Else
                cbdescripciongastos5.Text = buscardt.Rows(i).Item("CLAVE5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO5")) Or buscardt.Rows(i).Item("MONTO5").Equals(0) Then
                txtmonto5.Text = "0.00"
            Else
                txtmonto5.Text = Format(Val(buscardt.Rows(i).Item("MONTO5")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA5")) Or buscardt.Rows(i).Item("CAUSA5").Equals("") Then
                txtcausa5.Text = ""
            Else
                txtcausa5.Text = buscardt.Rows(i).Item("CAUSA5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE6")) Or buscardt.Rows(i).Item("CLAVE6").Equals("") Then
                cbdescripciongastos6.Text = ""
            Else
                cbdescripciongastos6.Text = buscardt.Rows(i).Item("CLAVE6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO6")) Or buscardt.Rows(i).Item("MONTO6").Equals(0) Then
                txtmonto6.Text = "0.00"
            Else
                txtmonto6.Text = Format(Val(buscardt.Rows(i).Item("MONTO6")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA6")) Or buscardt.Rows(i).Item("CAUSA6").Equals("") Then
                txtcausa6.Text = ""
            Else
                txtcausa6.Text = buscardt.Rows(i).Item("CAUSA6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE7")) Or buscardt.Rows(i).Item("CLAVE7").Equals("") Then
                cbdescripciongastos7.Text = ""
            Else
                cbdescripciongastos7.Text = buscardt.Rows(i).Item("CLAVE7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO7")) Or buscardt.Rows(i).Item("MONTO7").Equals(0) Then
                txtmonto7.Text = "0.00"
            Else
                txtmonto7.Text = Format(Val(buscardt.Rows(i).Item("MONTO7")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA7")) Or buscardt.Rows(i).Item("CAUSA7").Equals("") Then
                txtcausa7.Text = ""
            Else
                txtcausa7.Text = buscardt.Rows(i).Item("CAUSA7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE8")) Or buscardt.Rows(i).Item("CLAVE8").Equals("") Then
                cbdescripciongastos8.Text = ""
            Else
                cbdescripciongastos8.Text = buscardt.Rows(i).Item("CLAVE8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO8")) Or buscardt.Rows(i).Item("MONTO8").Equals(0) Then
                txtmonto8.Text = "0.00"
            Else
                txtmonto8.Text = Format(Val(buscardt.Rows(i).Item("MONTO8")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA8")) Or buscardt.Rows(i).Item("CAUSA8").Equals("") Then
                txtcausa8.Text = ""
            Else
                txtcausa8.Text = buscardt.Rows(i).Item("CAUSA8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_EMI")) Then
                txtfemision.Text = ""
            Else
                txtfemision.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_EMI")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_CONS")) Then
                txtfcons.Text = ""
            Else
                txtfcons.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_CONS")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_PAGO")) Then
                txtfpago.Text = ""
            Else
                txtfpago.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_PAGO")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("BASE_PAGO")) Or buscardt.Rows(i).Item("BASE_PAGO").Equals("") Then
                cbpatio.Text = ""
            Else
                cbpatio.Text = buscardt.Rows(i).Item("BASE_PAGO")
            End If
            If IsDBNull(buscardt.Rows(i).Item("DESTINO")) Or buscardt.Rows(i).Item("DESTINO").Equals("") Then
                cbdestino.Text = ""
            Else
                cbdestino.Text = buscardt.Rows(i).Item("DESTINO")
            End If
            If IsDBNull(buscardt.Rows(i).Item("OBSERVA")) Or buscardt.Rows(i).Item("OBSERVA").Equals("") Then
                txtobservaciones.Text = ""
            Else
                txtobservaciones.Text = buscardt.Rows(i).Item("OBSERVA")
            End If
            If IsDBNull(buscardt.Rows(i).Item("NUM_ECO")) Or buscardt.Rows(i).Item("NUM_ECO").Equals("") Then
                txtequipo.Text = ""
            Else
                txtequipo.Text = buscardt.Rows(i).Item("NUM_ECO")
            End If
            ID_SOLICITUD = buscardt.Rows(i).Item("ID_SOLICITUD")
        Next

        btnprimero.Enabled = False
        btnanterior.Enabled = False
        btnsiguiente.Enabled = True
        btnultimo.Enabled = True

    End Sub

    Private Sub btnultimo_Click(sender As Object, e As EventArgs) Handles btnultimo.Click
        Try


            ultimo_registro()
            monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

            Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                    Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
            Me.Refresh()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Sub registro_siguiente()

        Dim TALON = txtTalon8.Text

        Dim sqlcom_masgastossol As SqlCommand
        Dim sqldr_masgastossol As SqlDataReader
        conexsql = New SqlConnection(CONEXION_GASTOS)
        conexsql.Open()

        registro = registro + 1
        lblregistros.Text = registro & " DE " & buscardt.Rows.Count

        btnprimero.Enabled = True
        btnanterior.Enabled = True
        btnsiguiente.Enabled = True
        btnultimo.Enabled = True

        sql = "select * from excede where (talon='' or TALON is null or TALON2='' or TALON2 is null or TALON3='' or TALON3 is null  or talon4='' or TALON4 is null or talon5='' or TALON5 is null or talon6='' " &
                "or talon6 is null or talon7='' or talon7 is null or talon8=''  or TALON8 is null) and solicitud=" & txtsolicitud.Text & " order by id_solicitud desc "

        sqlcom_masgastossol = New SqlCommand
        sqlcom_masgastossol.CommandText = sql
        sqlcom_masgastossol.Connection = conexsql
        sqldr_masgastossol = sqlcom_masgastossol.ExecuteReader

        If sqldr_masgastossol.Read Then
            btnagregargastossol.Enabled = False
        Else
            btnagregargastossol.Enabled = True
        End If

        sqldr_masgastossol.Close()

        If registro = buscardt.Rows.Count Then
            btnsiguiente.Enabled = False
            btnultimo.Enabled = False

        End If

        conexsql.Close()

        registrodt = registro - 1

        If registrodt > buscardt.Rows.Count - 1 Then
            Form3.buscar(txtsolicitud.Text)
            Exit Sub
        End If


        For i = registrodt To registrodt

            txtsolicitud.Text = buscardt.Rows(i).Item("SOLICITUD")
            If IsDBNull(buscardt.Rows(i).Item("FACTURA1")) Or buscardt.Rows(i).Item("FACTURA1").Equals("") Then
                txtFactura1.Text = ""
            Else
                txtFactura1.Text = buscardt.Rows(i).Item("FACTURA1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA2")) Or buscardt.Rows(i).Item("FACTURA2").Equals("") Then
                txtFactura2.Text = ""
            Else
                txtFactura2.Text = buscardt.Rows(i).Item("FACTURA2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA3")) Or buscardt.Rows(i).Item("FACTURA3").Equals("") Then
                txtFactura3.Text = ""
            Else
                txtFactura3.Text = buscardt.Rows(i).Item("FACTURA3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA4")) Or buscardt.Rows(i).Item("FACTURA4").Equals("") Then
                txtFactura4.Text = ""
            Else
                txtFactura4.Text = buscardt.Rows(i).Item("FACTURA4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA5")) Or buscardt.Rows(i).Item("FACTURA5").Equals("") Then
                txtFactura5.Text = ""
            Else
                txtFactura5.Text = buscardt.Rows(i).Item("FACTURA5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA6")) Or buscardt.Rows(i).Item("FACTURA6").Equals("") Then
                txtFactura6.Text = ""
            Else
                txtFactura6.Text = buscardt.Rows(i).Item("FACTURA6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA7")) Or buscardt.Rows(i).Item("FACTURA7").Equals("") Then
                txtFactura7.Text = ""
            Else
                txtFactura7.Text = buscardt.Rows(i).Item("FACTURA7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA8")) Or buscardt.Rows(i).Item("FACTURA8").Equals("") Then
                txtFactura8.Text = ""
            Else
                txtFactura8.Text = buscardt.Rows(i).Item("FACTURA8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON")) Or buscardt.Rows(i).Item("TALON").Equals("") Then
                txtTalon1.Text = ""
            Else
                txtTalon1.Text = buscardt.Rows(i).Item("TALON")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON2")) Or buscardt.Rows(i).Item("TALON2").Equals("") Then
                txtTalon2.Text = ""
            Else
                txtTalon2.Text = buscardt.Rows(i).Item("TALON2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON3")) Or buscardt.Rows(i).Item("TALON3").Equals("") Then
                txtTalon3.Text = ""
            Else
                txtTalon3.Text = buscardt.Rows(i).Item("TALON3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON4")) Or buscardt.Rows(i).Item("TALON4").Equals("") Then
                txtTalon4.Text = ""
            Else
                txtTalon4.Text = buscardt.Rows(i).Item("TALON4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON5")) Or buscardt.Rows(i).Item("TALON5").Equals("") Then
                txtTalon5.Text = ""
            Else
                txtTalon5.Text = buscardt.Rows(i).Item("TALON5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON6")) Or buscardt.Rows(i).Item("TALON6").Equals("") Then
                txtTalon6.Text = ""
            Else
                txtTalon6.Text = buscardt.Rows(i).Item("TALON6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON7")) Or buscardt.Rows(i).Item("TALON7").Equals("") Then
                txtTalon7.Text = ""
            Else
                txtTalon7.Text = buscardt.Rows(i).Item("TALON7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON8")) Or buscardt.Rows(i).Item("TALON8").Equals("") Then
                txtTalon8.Text = ""
            Else
                txtTalon8.Text = buscardt.Rows(i).Item("TALON8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("OPERADOR")) Or buscardt.Rows(i).Item("OPERADOR").Equals(0) Then
                txtOperador.Text = ""
            Else
                txtOperador.Text = buscardt.Rows(i).Item("OPERADOR")
            End If
            If IsDBNull(buscardt.Rows(i).Item("NOMBRE")) Or buscardt.Rows(i).Item("NOMBRE").Equals("") Then
                txtNombreOperador.Text = ""
            Else
                txtNombreOperador.Text = buscardt.Rows(i).Item("NOMBRE")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE1")) Or buscardt.Rows(i).Item("CLAVE1").Equals("") Then
                cbdescripciongastos1.Text = ""
                cbdescripciongastos1.SelectedValue = 0
            Else
                cbdescripciongastos1.Text = buscardt.Rows(i).Item("CLAVE1")

            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO1")) Or buscardt.Rows(i).Item("MONTO1").Equals(0) Then
                txtmonto1.Text = "0.00"
            Else
                txtmonto1.Text = Format(Val(buscardt.Rows(i).Item("MONTO1")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA1")) Or buscardt.Rows(i).Item("CAUSA1").Equals("") Then
                txtcausa1.Text = ""
            Else
                txtcausa1.Text = buscardt.Rows(i).Item("CAUSA1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE2")) Or buscardt.Rows(i).Item("CLAVE2").Equals("") Then
                cbdescripciongastos2.Text = ""
                cbdescripciongastos2.SelectedValue = 0
            Else
                cbdescripciongastos2.Text = buscardt.Rows(i).Item("CLAVE2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO2")) Or buscardt.Rows(i).Item("MONTO2").Equals(0) Then
                txtmonto2.Text = "0.00"
            Else
                txtmonto2.Text = Format(Val(buscardt.Rows(i).Item("MONTO2")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA2")) Or buscardt.Rows(i).Item("CAUSA2").Equals("") Then
                txtcausa2.Text = ""
            Else
                txtcausa2.Text = buscardt.Rows(i).Item("CAUSA2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE3")) Or buscardt.Rows(i).Item("CLAVE3").Equals("") Then
                cbdescripciongastos3.Text = ""
                cbdescripciongastos3.SelectedValue = 0
            Else
                cbdescripciongastos3.Text = buscardt.Rows(i).Item("CLAVE3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO3")) Or buscardt.Rows(i).Item("MONTO3").Equals(0) Then
                txtmonto3.Text = "0.00"
            Else
                txtmonto3.Text = Format(Val(buscardt.Rows(i).Item("MONTO3")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA3")) Or buscardt.Rows(i).Item("CAUSA3").Equals("") Then
                txtcausa3.Text = ""
            Else
                txtcausa3.Text = buscardt.Rows(i).Item("CAUSA3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE4")) Or buscardt.Rows(i).Item("CLAVE4").Equals("") Then
                cbdescripciongastos4.Text = ""
                cbdescripciongastos4.SelectedValue = 0
            Else
                cbdescripciongastos4.Text = buscardt.Rows(i).Item("CLAVE4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO4")) Or buscardt.Rows(i).Item("MONTO4").Equals(0) Then
                txtmonto4.Text = "0.00"
            Else
                txtmonto4.Text = Format(Val(buscardt.Rows(i).Item("MONTO4")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA4")) Or buscardt.Rows(i).Item("CAUSA4").Equals("") Then
                txtcausa4.Text = ""
            Else
                txtcausa4.Text = buscardt.Rows(i).Item("CAUSA4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE5")) Or buscardt.Rows(i).Item("CLAVE5").Equals("") Then
                cbdescripciongastos5.Text = ""
                cbdescripciongastos5.SelectedValue = 0
            Else
                cbdescripciongastos5.Text = buscardt.Rows(i).Item("CLAVE5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO5")) Or buscardt.Rows(i).Item("MONTO5").Equals(0) Then
                txtmonto5.Text = "0.00"
            Else
                txtmonto5.Text = Format(Val(buscardt.Rows(i).Item("MONTO5")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA5")) Or buscardt.Rows(i).Item("CAUSA5").Equals("") Then
                txtcausa5.Text = ""
            Else
                txtcausa5.Text = buscardt.Rows(i).Item("CAUSA5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE6")) Or buscardt.Rows(i).Item("CLAVE6").Equals("") Then
                cbdescripciongastos6.Text = ""
                cbdescripciongastos6.SelectedValue = 0
            Else
                cbdescripciongastos6.Text = buscardt.Rows(i).Item("CLAVE6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO6")) Or buscardt.Rows(i).Item("MONTO6").Equals(0) Then
                txtmonto6.Text = "0.00"
            Else
                txtmonto6.Text = Format(Val(buscardt.Rows(i).Item("MONTO6")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA6")) Or buscardt.Rows(i).Item("CAUSA6").Equals("") Then
                txtcausa6.Text = ""
            Else
                txtcausa6.Text = buscardt.Rows(i).Item("CAUSA6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE7")) Or buscardt.Rows(i).Item("CLAVE7").Equals("") Then
                cbdescripciongastos7.Text = ""
                cbdescripciongastos7.SelectedValue = 0
            Else
                cbdescripciongastos7.Text = buscardt.Rows(i).Item("CLAVE7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO7")) Or buscardt.Rows(i).Item("MONTO7").Equals(0) Then
                txtmonto7.Text = "0.00"
            Else
                txtmonto7.Text = Format(Val(buscardt.Rows(i).Item("MONTO7")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA7")) Or buscardt.Rows(i).Item("CAUSA7").Equals("") Then
                txtcausa7.Text = ""
            Else
                txtcausa7.Text = buscardt.Rows(i).Item("CAUSA7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE8")) Or buscardt.Rows(i).Item("CLAVE8").Equals("") Then
                cbdescripciongastos8.Text = ""
                cbdescripciongastos8.SelectedValue = 0
            Else
                cbdescripciongastos8.Text = buscardt.Rows(i).Item("CLAVE8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO8")) Or buscardt.Rows(i).Item("MONTO8").Equals(0) Then
                txtmonto8.Text = "0.00"
            Else
                txtmonto8.Text = Format(Val(buscardt.Rows(i).Item("MONTO8")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA8")) Or buscardt.Rows(i).Item("CAUSA8").Equals("") Then
                txtcausa8.Text = ""
            Else
                txtcausa8.Text = buscardt.Rows(i).Item("CAUSA8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_EMI")) Then
                txtfemision.Text = ""
            Else
                txtfemision.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_EMI")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_CONS")) Then
                txtfcons.Text = ""
            Else
                txtfcons.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_CONS")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_PAGO")) Then
                txtfpago.Text = ""
            Else
                txtfpago.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_PAGO")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("BASE_PAGO")) Or buscardt.Rows(i).Item("BASE_PAGO").Equals("") Then
                cbpatio.Text = ""
            Else
                cbpatio.Text = buscardt.Rows(i).Item("BASE_PAGO")
            End If
            If IsDBNull(buscardt.Rows(i).Item("DESTINO")) Or buscardt.Rows(i).Item("DESTINO").Equals("") Then
                cbdestino.Text = ""
            Else
                cbdestino.Text = buscardt.Rows(i).Item("DESTINO")
            End If
            If IsDBNull(buscardt.Rows(i).Item("OBSERVA")) Or buscardt.Rows(i).Item("OBSERVA").Equals("") Then
                txtobservaciones.Text = ""
            Else
                txtobservaciones.Text = buscardt.Rows(i).Item("OBSERVA")
            End If
            If IsDBNull(buscardt.Rows(i).Item("NUM_ECO")) Or buscardt.Rows(i).Item("NUM_ECO").Equals("") Then
                txtequipo.Text = ""
            Else
                txtequipo.Text = buscardt.Rows(i).Item("NUM_ECO")
            End If
            ID_SOLICITUD = buscardt.Rows(i).Item("ID_SOLICITUD")
        Next

        If txtTalon1.Text = "" Then
            txtTalon1.Text = TALON

        End If


    End Sub

    Sub ultimo_registro()


        Dim sqlcom_masgastossol As SqlCommand
        Dim sqldr_masgastossol As SqlDataReader
        conexsql = New SqlConnection(CONEXION_GASTOS)
        conexsql.Open()

        sql = "select * from excede where (talon='' or TALON is null or TALON2='' or TALON2 is null or TALON3='' or TALON3 is null  or talon4='' or TALON4 is null or talon5='' or TALON5 is null or talon6=''  " &
                "or talon6 is null or talon7='' or talon7 is null or talon8=''  or TALON8 is null) and solicitud=" & txtsolicitud.Text & " order by id_solicitud desc "

        sqlcom_masgastossol = New SqlCommand
        sqlcom_masgastossol.CommandText = sql
        sqlcom_masgastossol.Connection = conexsql
        sqldr_masgastossol = sqlcom_masgastossol.ExecuteReader

        If sqldr_masgastossol.Read Then
            btnagregargastossol.Enabled = False
        Else
            btnagregargastossol.Enabled = True
        End If
        sqldr_masgastossol.Close()

        lblregistros.Text = buscardt.Rows.Count & " DE " & buscardt.Rows.Count

        For i = buscardt.Rows.Count - 1 To buscardt.Rows.Count - 1

            ' Write value of first Integer.
            ' Console.WriteLine(row.Field(Of Integer)(0))
            txtsolicitud.Text = buscardt.Rows(i).Item("SOLICITUD")
            If IsDBNull(buscardt.Rows(i).Item("FACTURA1")) Or buscardt.Rows(i).Item("FACTURA1").Equals("") Then
                txtFactura1.Text = ""
            Else
                txtFactura1.Text = buscardt.Rows(i).Item("FACTURA1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA2")) Or buscardt.Rows(i).Item("FACTURA2").Equals("") Then
                txtFactura2.Text = ""
            Else
                txtFactura2.Text = buscardt.Rows(i).Item("FACTURA2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA3")) Or buscardt.Rows(i).Item("FACTURA3").Equals("") Then
                txtFactura3.Text = ""
            Else
                txtFactura3.Text = buscardt.Rows(i).Item("FACTURA3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA4")) Or buscardt.Rows(i).Item("FACTURA4").Equals("") Then
                txtFactura4.Text = ""
            Else
                txtFactura4.Text = buscardt.Rows(i).Item("FACTURA4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA5")) Or buscardt.Rows(i).Item("FACTURA5").Equals("") Then
                txtFactura5.Text = ""
            Else
                txtFactura5.Text = buscardt.Rows(i).Item("FACTURA5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA6")) Or buscardt.Rows(i).Item("FACTURA6").Equals("") Then
                txtFactura6.Text = ""
            Else
                txtFactura6.Text = buscardt.Rows(i).Item("FACTURA6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA7")) Or buscardt.Rows(i).Item("FACTURA7").Equals("") Then
                txtFactura7.Text = ""
            Else
                txtFactura7.Text = buscardt.Rows(i).Item("FACTURA7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA8")) Or buscardt.Rows(i).Item("FACTURA8").Equals("") Then
                txtFactura8.Text = ""
            Else
                txtFactura8.Text = buscardt.Rows(i).Item("FACTURA8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON")) Or buscardt.Rows(i).Item("TALON").Equals("") Then
                txtTalon1.Text = ""
            Else
                txtTalon1.Text = buscardt.Rows(i).Item("TALON")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON2")) Or buscardt.Rows(i).Item("TALON2").Equals("") Then
                txtTalon2.Text = ""
            Else
                txtTalon2.Text = buscardt.Rows(i).Item("TALON2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON3")) Or buscardt.Rows(i).Item("TALON3").Equals("") Then
                txtTalon3.Text = ""
            Else
                txtTalon3.Text = buscardt.Rows(i).Item("TALON3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON4")) Or buscardt.Rows(i).Item("TALON4").Equals("") Then
                txtTalon4.Text = ""
            Else
                txtTalon4.Text = buscardt.Rows(i).Item("TALON4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON5")) Or buscardt.Rows(i).Item("TALON5").Equals("") Then
                txtTalon5.Text = ""
            Else
                txtTalon5.Text = buscardt.Rows(i).Item("TALON5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON6")) Or buscardt.Rows(i).Item("TALON6").Equals("") Then
                txtTalon6.Text = ""
            Else
                txtTalon6.Text = buscardt.Rows(i).Item("TALON6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON7")) Or buscardt.Rows(i).Item("TALON7").Equals("") Then
                txtTalon7.Text = ""
            Else
                txtTalon7.Text = buscardt.Rows(i).Item("TALON7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON8")) Or buscardt.Rows(i).Item("TALON8").Equals("") Then
                txtTalon8.Text = ""
            Else
                txtTalon8.Text = buscardt.Rows(i).Item("TALON8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("OPERADOR")) Or buscardt.Rows(i).Item("OPERADOR").Equals(0) Then
                txtOperador.Text = ""
            Else
                txtOperador.Text = buscardt.Rows(i).Item("OPERADOR")
            End If
            If IsDBNull(buscardt.Rows(i).Item("NOMBRE")) Or buscardt.Rows(i).Item("NOMBRE").Equals("") Then
                txtNombreOperador.Text = ""
            Else
                txtNombreOperador.Text = buscardt.Rows(i).Item("NOMBRE")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE1")) Or buscardt.Rows(i).Item("CLAVE1").Equals("") Then
                cbdescripciongastos1.Text = ""
            Else
                cbdescripciongastos1.Text = buscardt.Rows(i).Item("CLAVE1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO1")) Or buscardt.Rows(i).Item("MONTO1").Equals(0) Then
                txtmonto1.Text = "0.00"
            Else
                txtmonto1.Text = Format(Val(buscardt.Rows(i).Item("MONTO1")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA1")) Or buscardt.Rows(i).Item("CAUSA1").Equals("") Then
                txtcausa1.Text = ""
            Else
                txtcausa1.Text = buscardt.Rows(i).Item("CAUSA1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE2")) Or buscardt.Rows(i).Item("CLAVE2").Equals("") Then
                cbdescripciongastos2.Text = ""
            Else
                cbdescripciongastos2.Text = buscardt.Rows(i).Item("CLAVE2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO2")) Or buscardt.Rows(i).Item("MONTO2").Equals(0) Then
                txtmonto2.Text = "0.00"
            Else
                txtmonto2.Text = Format(Val(buscardt.Rows(i).Item("MONTO2")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA2")) Or buscardt.Rows(i).Item("CAUSA2").Equals("") Then
                txtcausa2.Text = ""
            Else
                txtcausa2.Text = buscardt.Rows(i).Item("CAUSA2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE3")) Or buscardt.Rows(i).Item("CLAVE3").Equals("") Then
                cbdescripciongastos3.Text = ""
            Else
                cbdescripciongastos3.Text = buscardt.Rows(i).Item("CLAVE3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO3")) Or buscardt.Rows(i).Item("MONTO3").Equals(0) Then
                txtmonto3.Text = "0.00"
            Else
                txtmonto3.Text = Format(Val(buscardt.Rows(i).Item("MONTO3")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA3")) Or buscardt.Rows(i).Item("CAUSA3").Equals("") Then
                txtcausa3.Text = ""
            Else
                txtcausa3.Text = buscardt.Rows(i).Item("CAUSA3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE4")) Or buscardt.Rows(i).Item("CLAVE4").Equals("") Then
                cbdescripciongastos4.Text = ""
            Else
                cbdescripciongastos4.Text = buscardt.Rows(i).Item("CLAVE4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO4")) Or buscardt.Rows(i).Item("MONTO4").Equals(0) Then
                txtmonto4.Text = "0.00"
            Else
                txtmonto4.Text = Format(Val(buscardt.Rows(i).Item("MONTO4")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA4")) Or buscardt.Rows(i).Item("CAUSA4").Equals("") Then
                txtcausa4.Text = ""
            Else
                txtcausa4.Text = buscardt.Rows(i).Item("CAUSA4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE5")) Or buscardt.Rows(i).Item("CLAVE5").Equals("") Then
                cbdescripciongastos5.Text = ""
            Else
                cbdescripciongastos5.Text = buscardt.Rows(i).Item("CLAVE5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO5")) Or buscardt.Rows(i).Item("MONTO5").Equals(0) Then
                txtmonto5.Text = "0.00"
            Else
                txtmonto5.Text = Format(Val(buscardt.Rows(i).Item("MONTO5")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA5")) Or buscardt.Rows(i).Item("CAUSA5").Equals("") Then
                txtcausa5.Text = ""
            Else
                txtcausa5.Text = buscardt.Rows(i).Item("CAUSA5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE6")) Or buscardt.Rows(i).Item("CLAVE6").Equals("") Then
                cbdescripciongastos6.Text = ""
            Else
                cbdescripciongastos6.Text = buscardt.Rows(i).Item("CLAVE6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO6")) Or buscardt.Rows(i).Item("MONTO6").Equals(0) Then
                txtmonto6.Text = "0.00"
            Else
                txtmonto6.Text = Format(Val(buscardt.Rows(i).Item("MONTO6")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA6")) Or buscardt.Rows(i).Item("CAUSA6").Equals("") Then
                txtcausa6.Text = ""
            Else
                txtcausa6.Text = buscardt.Rows(i).Item("CAUSA6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE7")) Or buscardt.Rows(i).Item("CLAVE7").Equals("") Then
                cbdescripciongastos7.Text = ""
            Else
                cbdescripciongastos7.Text = buscardt.Rows(i).Item("CLAVE7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO7")) Or buscardt.Rows(i).Item("MONTO7").Equals(0) Then
                txtmonto7.Text = "0.00"
            Else
                txtmonto7.Text = Format(Val(buscardt.Rows(i).Item("MONTO7")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA7")) Or buscardt.Rows(i).Item("CAUSA7").Equals("") Then
                txtcausa7.Text = ""
            Else
                txtcausa7.Text = buscardt.Rows(i).Item("CAUSA7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE8")) Or buscardt.Rows(i).Item("CLAVE8").Equals("") Then
                cbdescripciongastos8.Text = ""
            Else
                cbdescripciongastos8.Text = buscardt.Rows(i).Item("CLAVE8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO8")) Or buscardt.Rows(i).Item("MONTO8").Equals(0) Then
                txtmonto8.Text = "0.00"
            Else
                txtmonto8.Text = Format(Val(buscardt.Rows(i).Item("MONTO8")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA8")) Or buscardt.Rows(i).Item("CAUSA8").Equals("") Then
                txtcausa8.Text = ""
            Else
                txtcausa8.Text = buscardt.Rows(i).Item("CAUSA8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_EMI")) Then
                txtfemision.Text = ""
            Else
                txtfemision.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_EMI")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_CONS")) Then
                txtfcons.Text = ""
            Else
                txtfcons.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_CONS")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_PAGO")) Then
                txtfpago.Text = ""
            Else
                txtfpago.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_PAGO")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("BASE_PAGO")) Or buscardt.Rows(i).Item("BASE_PAGO").Equals("") Then
                cbpatio.Text = ""
            Else
                cbpatio.Text = buscardt.Rows(i).Item("BASE_PAGO")
            End If
            If IsDBNull(buscardt.Rows(i).Item("DESTINO")) Or buscardt.Rows(i).Item("DESTINO").Equals("") Then
                cbdestino.Text = ""
            Else
                cbdestino.Text = buscardt.Rows(i).Item("DESTINO")
            End If
            If IsDBNull(buscardt.Rows(i).Item("OBSERVA")) Or buscardt.Rows(i).Item("OBSERVA").Equals("") Then
                txtobservaciones.Text = ""
            Else
                txtobservaciones.Text = buscardt.Rows(i).Item("OBSERVA")
            End If
            If IsDBNull(buscardt.Rows(i).Item("NUM_ECO")) Or buscardt.Rows(i).Item("NUM_ECO").Equals("") Then
                txtequipo.Text = ""
            Else
                txtequipo.Text = buscardt.Rows(i).Item("NUM_ECO")
            End If
            ID_SOLICITUD = buscardt.Rows(i).Item("ID_SOLICITUD")
        Next

        conexsql.Close()

        btnprimero.Enabled = True
        btnanterior.Enabled = True
        btnsiguiente.Enabled = False
        btnultimo.Enabled = False

    End Sub

    Private Sub btnanterior_Click(sender As Object, e As EventArgs) Handles btnanterior.Click
        Try

            registro_anterior()
            monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)
            Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                    Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
            Me.Refresh()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Sub registro_anterior()


        registro = registro - 1
        lblregistros.Text = registro & " DE " & buscardt.Rows.Count

        btnprimero.Enabled = True
        btnanterior.Enabled = True
        btnsiguiente.Enabled = True
        btnultimo.Enabled = True

        If registro = 1 Then
            btnanterior.Enabled = False
            btnprimero.Enabled = False

        End If

        registrodt = registro - 1

        If registrodt < 0 Then
            Form3.buscar(txtsolicitud.Text)
            Exit Sub
        End If


        For i = registrodt To registrodt

            ' Write value of first Integer.
            ' Console.WriteLine(row.Field(Of Integer)(0))
            txtsolicitud.Text = buscardt.Rows(i).Item("SOLICITUD")
            If IsDBNull(buscardt.Rows(i).Item("FACTURA1")) Or buscardt.Rows(i).Item("FACTURA1").Equals("") Then
                txtFactura1.Text = ""
            Else
                txtFactura1.Text = buscardt.Rows(i).Item("FACTURA1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA2")) Or buscardt.Rows(i).Item("FACTURA2").Equals("") Then
                txtFactura2.Text = ""
            Else
                txtFactura2.Text = buscardt.Rows(i).Item("FACTURA2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA3")) Or buscardt.Rows(i).Item("FACTURA3").Equals("") Then
                txtFactura3.Text = ""
            Else
                txtFactura3.Text = buscardt.Rows(i).Item("FACTURA3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA4")) Or buscardt.Rows(i).Item("FACTURA4").Equals("") Then
                txtFactura4.Text = ""
            Else
                txtFactura4.Text = buscardt.Rows(i).Item("FACTURA4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA5")) Or buscardt.Rows(i).Item("FACTURA5").Equals("") Then
                txtFactura5.Text = ""
            Else
                txtFactura5.Text = buscardt.Rows(i).Item("FACTURA5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA6")) Or buscardt.Rows(i).Item("FACTURA6").Equals("") Then
                txtFactura6.Text = ""
            Else
                txtFactura6.Text = buscardt.Rows(i).Item("FACTURA6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA7")) Or buscardt.Rows(i).Item("FACTURA7").Equals("") Then
                txtFactura7.Text = ""
            Else
                txtFactura7.Text = buscardt.Rows(i).Item("FACTURA7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FACTURA8")) Or buscardt.Rows(i).Item("FACTURA8").Equals("") Then
                txtFactura8.Text = ""
            Else
                txtFactura8.Text = buscardt.Rows(i).Item("FACTURA8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON")) Or buscardt.Rows(i).Item("TALON").Equals("") Then
                txtTalon1.Text = ""
            Else
                txtTalon1.Text = buscardt.Rows(i).Item("TALON")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON2")) Or buscardt.Rows(i).Item("TALON2").Equals("") Then
                txtTalon2.Text = ""
            Else
                txtTalon2.Text = buscardt.Rows(i).Item("TALON2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON3")) Or buscardt.Rows(i).Item("TALON3").Equals("") Then
                txtTalon3.Text = ""
            Else
                txtTalon3.Text = buscardt.Rows(i).Item("TALON3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON4")) Or buscardt.Rows(i).Item("TALON4").Equals("") Then
                txtTalon4.Text = ""
            Else
                txtTalon4.Text = buscardt.Rows(i).Item("TALON4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON5")) Or buscardt.Rows(i).Item("TALON5").Equals("") Then
                txtTalon5.Text = ""
            Else
                txtTalon5.Text = buscardt.Rows(i).Item("TALON5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON6")) Or buscardt.Rows(i).Item("TALON6").Equals("") Then
                txtTalon6.Text = ""
            Else
                txtTalon6.Text = buscardt.Rows(i).Item("TALON6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON7")) Or buscardt.Rows(i).Item("TALON7").Equals("") Then
                txtTalon7.Text = ""
            Else
                txtTalon7.Text = buscardt.Rows(i).Item("TALON7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("TALON8")) Or buscardt.Rows(i).Item("TALON8").Equals("") Then
                txtTalon8.Text = ""
            Else
                txtTalon8.Text = buscardt.Rows(i).Item("TALON8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("OPERADOR")) Or buscardt.Rows(i).Item("OPERADOR") = 0 Then
                txtOperador.Text = ""
            Else
                txtOperador.Text = buscardt.Rows(i).Item("OPERADOR")
            End If
            If IsDBNull(buscardt.Rows(i).Item("NOMBRE")) Or buscardt.Rows(i).Item("NOMBRE").Equals("") Then
                txtNombreOperador.Text = ""
            Else
                txtNombreOperador.Text = buscardt.Rows(i).Item("NOMBRE")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE1")) Or buscardt.Rows(i).Item("CLAVE1").Equals("") Then
                cbdescripciongastos1.Text = ""
                cbdescripciongastos1.SelectedValue = 0
            Else
                cbdescripciongastos1.Text = buscardt.Rows(i).Item("CLAVE1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO1")) Or buscardt.Rows(i).Item("MONTO1") = 0 Then
                txtmonto1.Text = "0.00"
            Else
                txtmonto1.Text = Format(Val(buscardt.Rows(i).Item("MONTO1")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA1")) Or buscardt.Rows(i).Item("CAUSA1").Equals("") Then
                txtcausa1.Text = ""
            Else
                txtcausa1.Text = buscardt.Rows(i).Item("CAUSA1")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE2")) Or buscardt.Rows(i).Item("CLAVE2").Equals("") Then
                cbdescripciongastos2.Text = ""
                cbdescripciongastos2.SelectedValue = 0
            Else
                cbdescripciongastos2.Text = buscardt.Rows(i).Item("CLAVE2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO2")) Or buscardt.Rows(i).Item("MONTO2") = 0 Then
                txtmonto2.Text = "0.00"
            Else
                txtmonto2.Text = Format(Val(buscardt.Rows(i).Item("MONTO2")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA2")) Or buscardt.Rows(i).Item("CAUSA2").Equals("") Then
                txtcausa2.Text = ""
            Else
                txtcausa2.Text = buscardt.Rows(i).Item("CAUSA2")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE3")) Or buscardt.Rows(i).Item("CLAVE3").Equals("") Then
                cbdescripciongastos3.Text = ""
                cbdescripciongastos3.SelectedValue = 0
            Else
                cbdescripciongastos3.Text = buscardt.Rows(i).Item("CLAVE3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO3")) Or buscardt.Rows(i).Item("MONTO3") = 0 Then
                txtmonto3.Text = "0.00"
            Else
                txtmonto3.Text = Format(Val(buscardt.Rows(i).Item("MONTO3")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA3")) Or buscardt.Rows(i).Item("CAUSA3").Equals("") Then
                txtcausa3.Text = ""
            Else
                txtcausa3.Text = buscardt.Rows(i).Item("CAUSA3")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE4")) Or buscardt.Rows(i).Item("CLAVE4").Equals("") Then
                cbdescripciongastos4.Text = ""
                cbdescripciongastos4.SelectedValue = 0
            Else
                cbdescripciongastos4.Text = buscardt.Rows(i).Item("CLAVE4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO4")) Or buscardt.Rows(i).Item("MONTO4") = 0 Then
                txtmonto4.Text = "0.00"
            Else
                txtmonto4.Text = Format(Val(buscardt.Rows(i).Item("MONTO4")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA4")) Or buscardt.Rows(i).Item("CAUSA4").Equals("") Then
                txtcausa4.Text = ""
            Else
                txtcausa4.Text = buscardt.Rows(i).Item("CAUSA4")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE5")) Or buscardt.Rows(i).Item("CLAVE5").Equals("") Then
                cbdescripciongastos5.Text = ""
                cbdescripciongastos5.SelectedValue = 0
            Else
                cbdescripciongastos5.Text = buscardt.Rows(i).Item("CLAVE5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO5")) Or buscardt.Rows(i).Item("MONTO5") = 0 Then
                txtmonto5.Text = "0.00"
            Else
                txtmonto5.Text = Format(Val(buscardt.Rows(i).Item("MONTO5")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA5")) Or buscardt.Rows(i).Item("CAUSA5").Equals("") Then
                txtcausa5.Text = ""
            Else
                txtcausa5.Text = buscardt.Rows(i).Item("CAUSA5")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE6")) Or buscardt.Rows(i).Item("CLAVE6").Equals("") Then
                cbdescripciongastos6.Text = ""
                cbdescripciongastos6.SelectedValue = 0
            Else
                cbdescripciongastos6.Text = buscardt.Rows(i).Item("CLAVE6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO6")) Or buscardt.Rows(i).Item("MONTO6") = 0 Then
                txtmonto6.Text = "0.00"
            Else
                txtmonto6.Text = Format(Val(buscardt.Rows(i).Item("MONTO6")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA6")) Or buscardt.Rows(i).Item("CAUSA6").Equals("") Then
                txtcausa6.Text = ""
            Else
                txtcausa6.Text = buscardt.Rows(i).Item("CAUSA6")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE7")) Or buscardt.Rows(i).Item("CLAVE7").Equals("") Then
                cbdescripciongastos7.Text = ""
                cbdescripciongastos7.SelectedValue = 0
            Else
                cbdescripciongastos7.Text = buscardt.Rows(i).Item("CLAVE7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO7")) Or buscardt.Rows(i).Item("MONTO7") = 0 Then
                txtmonto7.Text = "0.00"
            Else
                txtmonto7.Text = Format(Val(buscardt.Rows(i).Item("MONTO7")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA7")) Or buscardt.Rows(i).Item("CAUSA7").Equals("") Then
                txtcausa7.Text = ""
            Else
                txtcausa7.Text = buscardt.Rows(i).Item("CAUSA7")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CLAVE8")) Or buscardt.Rows(i).Item("CLAVE8").Equals("") Then
                cbdescripciongastos8.Text = ""
                cbdescripciongastos8.SelectedValue = 0
            Else
                cbdescripciongastos8.Text = buscardt.Rows(i).Item("CLAVE8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("MONTO8")) Or buscardt.Rows(i).Item("MONTO8") = 0 Then
                txtmonto8.Text = "0.00"
            Else
                txtmonto8.Text = Format(Val(buscardt.Rows(i).Item("MONTO8")), "###,###,##0.00")
            End If
            If IsDBNull(buscardt.Rows(i).Item("CAUSA8")) Or buscardt.Rows(i).Item("CAUSA8").Equals("") Then
                txtcausa8.Text = ""
            Else
                txtcausa8.Text = buscardt.Rows(i).Item("CAUSA8")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_EMI")) Then
                txtfemision.Text = ""
            Else
                txtfemision.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_EMI")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_CONS")) Then
                txtfcons.Text = ""
            Else
                txtfcons.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_CONS")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("FECHA_PAGO")) Then
                txtfpago.Text = ""
            Else
                txtfpago.Text = Format(CDate(buscardt.Rows(i).Item("FECHA_PAGO")), "dd MMMM yyyy")
            End If
            If IsDBNull(buscardt.Rows(i).Item("BASE_PAGO")) Or buscardt.Rows(i).Item("BASE_PAGO").Equals("") Then
                cbpatio.Text = ""
            Else
                cbpatio.Text = buscardt.Rows(i).Item("BASE_PAGO")
            End If
            If IsDBNull(buscardt.Rows(i).Item("DESTINO")) Or buscardt.Rows(i).Item("DESTINO").Equals("") Then
                cbdestino.Text = ""
            Else
                cbdestino.Text = buscardt.Rows(i).Item("DESTINO")
            End If
            If IsDBNull(buscardt.Rows(i).Item("OBSERVA")) Or buscardt.Rows(i).Item("OBSERVA").Equals("") Then
                txtobservaciones.Text = ""
            Else
                txtobservaciones.Text = buscardt.Rows(i).Item("OBSERVA")
            End If
            If IsDBNull(buscardt.Rows(i).Item("NUM_ECO")) Or buscardt.Rows(i).Item("NUM_ECO").Equals("") Then
                txtequipo.Text = ""
            Else
                txtequipo.Text = buscardt.Rows(i).Item("NUM_ECO")
            End If
            ID_SOLICITUD = buscardt.Rows(i).Item("ID_SOLICITUD")
        Next



    End Sub


    Private Sub btnagregargastossol_Click(sender As Object, e As EventArgs) Handles btnagregargastossol.Click
        Try

            Label17.Text = "PROCESANDO"
            btnadd.Enabled = False
            Me.Refresh()

            Dim sqlcom_masgastossol As SqlCommand
            Dim sqldr_masgastossol As SqlDataReader

            conexsql = New SqlConnection(CONEXION_GASTOS)
            conexsql.Open()

            solicitud = txtsolicitud.Text

            sql = "select * from excede where (talon='' or talon2='' or talon3='' or talon4='' or talon5='' " &
                            "or talon6='' or talon7='' or talon8='' OR TALON IS NULL OR talon2 IS NULL OR talon3 IS NULL OR talon4 IS NULL OR talon5 IS NULL  " &
                        "OR talon6 IS NULL OR talon7 IS NULL OR talon8 IS NULL ) and solicitud=" & solicitud & " AND (ESTATUS not LIKE '%ELIMINADO%' OR ESTATUS IS NULL) " &
            "order by id_solicitud desc"

            sqlcom_masgastossol = New SqlCommand
            sqlcom_masgastossol.CommandText = sql
            sqlcom_masgastossol.Connection = conexsql
            sqldr_masgastossol = sqlcom_masgastossol.ExecuteReader

            If sqldr_masgastossol.Read Then
                sqldr_masgastossol.Close()
                MsgBox("DEBE LLENAR TODOS LOS TALONES PARA CREAR MAS GASTOS")
                Exit Sub

            Else

                sqldr_masgastossol.Close()

                If VALIDAR_DATOS() = False Then
                    Exit Sub
                End If

                If txtfcons.Text = "" Then
                    fcons = "NULL"
                Else
                    fcons = "'" & Format(CDate(txtfcons.Text), "yyyyMMdd") & "'"
                End If


                If txtfpago.Text = "" Then
                    fpago = "NULL"
                Else
                    fpago = "'" & Format(CDate(txtfpago.Text), "yyyyMMdd") & "'"
                End If

                If ChckAUTORIZA.Checked <> True Then
                    AUTORIZA = "NULL"
                Else
                    AUTORIZA = "'" & usuario & "'"
                End If

                sql = " GUARDA_SOLICITUD " & txtsolicitud.Text & ",'','','','','','','','','','','','','','','',''," & AUTORIZA & "," & txtOperador.Text & ",'" & txtNombreOperador.Text &
                           "',0,NULL,0,0,'',0,0,'',0,0,'',0,0,'',0,0,'',0,0,'',0,0,'',0,0,'','" & DateTime.Now.ToString("yyyyMMdd") & "',0,NULL,NULL,'" &
                           DateTime.Now.ToString("yyyyMMdd") & "','" & DateTime.Now.ToString("HH:mm:ss") &
                           "',NULL,NULL,NULL,NULL," & fcons &
                           "," & fpago & ",'" & cbpatio.Text & "','" & cbdestino.Text &
                           "','" & txtobservaciones.Text & "','" & txtequipo.Text & "',NULL,'AGREGADO POR: " & usuario & " " &
                        DateTime.Now.ToString("dd MMM yyy HH:mm:ss") & "'"

                sqlcom_masgastossol = New SqlCommand
                sqlcom_masgastossol.CommandText = sql
                sqlcom_masgastossol.Connection = conexsql
                sqlcom_masgastossol.ExecuteNonQuery()
                sqldr_masgastossol.Close()

                SQL1 = "UPDATE EXCEDE SET VERIFICA=" & AUTORIZA & " WHERE SOLICITUD=" & txtsolicitud.Text

                sqlcom_masgastossol = New SqlCommand
                sqlcom_masgastossol.CommandText = SQL1
                sqlcom_masgastossol.Connection = conexsql
                sqlcom_masgastossol.ExecuteNonQuery()

            End If
            sqldr_masgastossol.Close()
            conexsql.Close()
            registro = 0

            gastos_agregados()

            Label17.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub txtmonto2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto2.KeyPress
        Try

            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsPunctuation(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
                MessageBox.Show("Solo numeros", "validacion numero", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtmonto3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto3.KeyPress
        Try

            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsPunctuation(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
                MessageBox.Show("Solo numeros", "validacion numero", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtmonto4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto4.KeyPress
        Try

            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsPunctuation(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
                MessageBox.Show("Solo numeros", "validacion numero", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtmonto5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto5.KeyPress
        Try

            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsPunctuation(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
                MessageBox.Show("Solo numeros", "validacion numero", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtmonto6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto6.KeyPress
        Try

            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsPunctuation(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
                MessageBox.Show("Solo numeros", "validacion numero", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtmonto7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto7.KeyPress
        Try

            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsPunctuation(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
                MessageBox.Show("Solo numeros", "validacion numero", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtmonto8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto8.KeyPress
        Try

            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsPunctuation(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
                MessageBox.Show("Solo numeros", "validacion numero", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtmonto8_LostFocus(sender As Object, e As EventArgs) Handles txtmonto8.LostFocus
        txtmonto8.Text = Format(CDbl(txtmonto8.Text), "###,###,##0.00")
        monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

        Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
        Me.Refresh()
    End Sub

    Private Sub txtmonto1_LostFocus(sender As Object, e As EventArgs) Handles txtmonto1.LostFocus
        txtmonto1.Text = Format(CDbl(txtmonto1.Text), "###,###,##0.00")
        monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

        Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
        Me.Refresh()
    End Sub

    Private Sub txtmonto2_LostFocus(sender As Object, e As EventArgs) Handles txtmonto2.LostFocus
        txtmonto2.Text = Format(CDbl(txtmonto2.Text), "###,###,##0.00")
        monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

        Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
        Me.Refresh()
    End Sub

    Private Sub txtmonto3_LostFocus(sender As Object, e As EventArgs) Handles txtmonto3.LostFocus
        txtmonto3.Text = Format(CDbl(txtmonto3.Text), "###,###,##0.00")
        monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

        Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
        Me.Refresh()
    End Sub

    Private Sub txtmonto4_LostFocus(sender As Object, e As EventArgs) Handles txtmonto4.LostFocus
        txtmonto4.Text = Format(CDbl(txtmonto4.Text), "###,###,##0.00")
        monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

        Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
        Me.Refresh()
    End Sub

    Private Sub txtmonto5_LostFocus(sender As Object, e As EventArgs) Handles txtmonto5.LostFocus
        txtmonto5.Text = Format(CDbl(txtmonto5.Text), "###,###,##0.00")
        monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

        Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
        Me.Refresh()
    End Sub

    Private Sub txtmonto6_LostFocus(sender As Object, e As EventArgs) Handles txtmonto6.LostFocus
        txtmonto6.Text = Format(CDbl(txtmonto6.Text), "###,###,##0.00")
        monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

        Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
        Me.Refresh()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnprimersol.Click
        Try

            Label17.Text = "PROCESANDO........................."
            Me.Refresh()
            actualizar_numeroregistros()

            conexsql = New SqlConnection(CONEXION_GASTOS)
            conexsql.Open()
            sql = "select TOP 1 SOLICITUD from EXCEDE WHERE ESTATUS not LIKE '%ELIMINADO%' OR ESTATUS IS NULL ORDER BY SOLICITUD asc "
            Dim sqlda_primerasolictud = New SqlDataAdapter(sql, conexsql)
            SOLICDT = New DataTable
            sqlda_primerasolictud.Fill(SOLICDT)

            For Each ROW In SOLICDT.Rows
                primera_solicitud = ROW(0)
                btnsigsol.Enabled = True
                btnultimasol.Enabled = True
                btnprimersol.Enabled = False
                btnantsol.Enabled = False

            Next

            conexsql.Close()

            Form3.buscar(primera_solicitud)

            monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

            Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
            Me.Refresh()

            Label17.Text = ""


        Catch ex As Exception
            Label17.Text = ""
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnultimasol_Click(sender As Object, e As EventArgs) Handles btnultimasol.Click
        Try
            Label17.Text = "PROCESANDO........................."
            Me.Refresh()
            actualizar_numeroregistros()

            conexsql = New SqlConnection(CONEXION_GASTOS)
            conexsql.Open()
            sql = "select TOP 1 SOLICITUD from EXCEDE WHERE ESTATUS not LIKE '%ELIMINADO%' OR ESTATUS IS NULL ORDER BY SOLICITUD desc "
            Dim sqlda_ultimasolictud = New SqlDataAdapter(sql, conexsql)
            SOLICDT = New DataTable
            sqlda_ultimasolictud.Fill(SOLICDT)


            For Each ROW In SOLICDT.Rows
                ultima_solicitud = ROW(0)
                btnsigsol.Enabled = False
                btnultimasol.Enabled = False
                btnprimersol.Enabled = True
                btnantsol.Enabled = True
            Next

            conexsql.Close()

            Form3.buscar(ultima_solicitud)

            monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

            Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
            Me.Refresh()

            Label17.Text = ""

        Catch ex As Exception
            Label17.Text = ""
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnantsol_Click(sender As Object, e As EventArgs) Handles btnantsol.Click
        Try

            Label17.Text = "PROCESANDO.................."
            Me.Refresh()
            actualizar_numeroregistros()

            conexsql = New SqlConnection(CONEXION_GASTOS)
            conexsql.Open()
            Dim anterior_sol As Integer
            anterior_sol = CInt(txtsolicitud.Text) - 1

            sql = "select TOP 1 SOLICITUD from EXCEDE where solicitud=" & anterior_sol & " AND (ESTATUS not LIKE '%ELIMINADO%' OR ESTATUS IS NULL)"
            Dim sqlda_ultimasolictud = New SqlDataAdapter(sql, conexsql)
            SOLICDT = New DataTable
            sqlda_ultimasolictud.Fill(SOLICDT)

            If SOLICDT.Rows.Count = 0 Then
                Label17.Text = "NO EXISTE LA SOLICITUD " & anterior_sol
                txtsolicitud.Text = anterior_sol
                Exit Sub
            End If

            For Each ROW In SOLICDT.Rows
                anterior_sol = ROW(0)

            Next

            conexsql.Close()

            Form3.buscar(anterior_sol)

            If primera_solicitud = anterior_sol Then
                btnsigsol.Enabled = True
                btnultimasol.Enabled = True
                btnprimersol.Enabled = False
                btnantsol.Enabled = False

            Else
                btnsigsol.Enabled = True
                btnultimasol.Enabled = True
                btnprimersol.Enabled = True
                btnantsol.Enabled = True

            End If
            Label17.Text = ""

            monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

            Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                    Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
            Me.Refresh()


        Catch ex As Exception
            Label17.Text = ""
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnsigsol_Click(sender As Object, e As EventArgs) Handles btnsigsol.Click
        Try

            Label17.Text = "PROCESANDO........................."
            Me.Refresh()
            actualizar_numeroregistros()

            conexsql = New SqlConnection(CONEXION_GASTOS)
            conexsql.Open()
            Dim siguiente_sol As Integer
            siguiente_sol = CInt(txtsolicitud.Text) + 1

            sql = "select TOP 1 SOLICITUD from EXCEDE where solicitud=" & siguiente_sol & " AND (ESTATUS not LIKE '%ELIMINADO%' OR ESTATUS IS NULL)"
            Dim sqlda_ultimasolictud = New SqlDataAdapter(sql, conexsql)
            SOLICDT = New DataTable
            sqlda_ultimasolictud.Fill(SOLICDT)

            If SOLICDT.Rows.Count = 0 Then
                Label17.Text = "NO EXISTE LA SOLICITUD " & siguiente_sol
                txtsolicitud.Text = siguiente_sol
                Exit Sub

            End If

            For Each ROW In SOLICDT.Rows
                siguiente_sol = ROW(0)

            Next

            conexsql.Close()

            Form3.buscar(siguiente_sol)

            If SOLICDT.Rows.Count = 0 Then
                txtsolicitud.Text = siguiente_sol
            End If


            If ultima_solicitud = siguiente_sol Then
                btnsigsol.Enabled = False
                btnultimasol.Enabled = False
                btnprimersol.Enabled = True
                btnantsol.Enabled = True

            Else
                btnsigsol.Enabled = True
                btnultimasol.Enabled = True
                btnprimersol.Enabled = True
                btnantsol.Enabled = True

            End If
            monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

            Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
            Me.Refresh()
            Label17.Text = ""

        Catch ex As Exception
            Label17.Text = ""
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtmonto7_LostFocus(sender As Object, e As EventArgs) Handles txtmonto7.LostFocus
        txtmonto7.Text = Format(CDbl(txtmonto7.Text), "###,###,##0.00")
        monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

        Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
        Me.Refresh()
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnreportes.Click
        FormReporte.Show()
    End Sub

    Sub gastos_agregados()
        Try

            Dim TALON = txtTalon8.Text

            registro = buscardt.Rows.Count
            sql = "select * from excede where solicitud = '" & solicitud & "' AND (ESTATUS not LIKE '%ELIMINADO%' OR ESTATUS IS NULL) " &
            "order by id_solicitud "

            buscar_nuevosgastos_conec = New SqlConnection(CONEXION_GASTOS)
            buscar_nuevosgastos_conec.Open()

            Dim buscarsa As SqlDataAdapter
            buscarsa = New SqlDataAdapter(sql, buscar_nuevosgastos_conec)
            buscardt = New DataTable
            buscarsa.Fill(buscardt)


            If buscardt.Rows.Count = 0 Then
                MsgBox("SOLICITUD NO ENCONTRADA")

            Else

                btnprimero.Enabled = True
                btnanterior.Enabled = True
                btnsiguiente.Enabled = False
                btnultimo.Enabled = False

                registro = registro + 1
                lblregistros.Text = buscardt.Rows.Count & " DE " & buscardt.Rows.Count
                btnimpresion.Enabled = True
                btnedit.Enabled = True
                btndelete.Enabled = True
                btncancelar.Visible = True
                btnbuscar.Enabled = False
                Dim fila As Integer = 0


                For Each row As DataRow In buscardt.Rows


                    Dim sqlcom_masgastossol As SqlCommand
                    Dim sqldr_masgastossol As SqlDataReader

                    sql = "select * from excede where (talon='' or talon2='' or talon3='' or talon4='' or talon5='' " &
                        "or talon6='' or talon7='' or talon8='' OR TALON IS NULL OR talon2 IS NULL OR talon3 IS NULL OR talon4 IS NULL OR talon5 IS NULL  " &
                        "OR talon6 IS NULL OR talon7 IS NULL OR talon8 IS NULL ) and solicitud=" & row(0) & " AND (ESTATUS not LIKE '%ELIMINADO%' OR ESTATUS IS NULL) order by id_solicitud desc"

                    sqlcom_masgastossol = New SqlCommand
                    sqlcom_masgastossol.CommandText = sql
                    sqlcom_masgastossol.Connection = buscar_nuevosgastos_conec
                    sqldr_masgastossol = sqlcom_masgastossol.ExecuteReader

                    If sqldr_masgastossol.Read Then
                        sqldr_masgastossol.Close()
                        btnagregargastossol.Enabled = False
                    Else
                        btnagregargastossol.Enabled = True
                    End If
                    sqldr_masgastossol.Close()

                    If fila = buscardt.Rows.Count - 1 Then
                        ' Write value of first Integer.
                        ' Console.WriteLine(row.Field(Of Integer)(0))
                        txtsolicitud.Text = row(0)
                        If IsDBNull(row(1)) Or row(1).Equals("") Then
                            txtFactura1.Text = ""
                        Else
                            txtFactura1.Text = row(1)
                        End If
                        If IsDBNull(row(2)) Or row(2).Equals("") Then
                            txtFactura2.Text = ""
                        Else
                            txtFactura2.Text = row(2)
                        End If
                        If IsDBNull(row(3)) Or row(3).Equals("") Then
                            txtFactura3.Text = ""
                        Else
                            txtFactura3.Text = row(3)
                        End If
                        If IsDBNull(row(4)) Or row(4).Equals("") Then
                            txtFactura4.Text = ""
                        Else
                            txtFactura4.Text = row(4)
                        End If
                        If IsDBNull(row(5)) Or row(5).Equals("") Then
                            txtFactura5.Text = ""
                        Else
                            txtFactura5.Text = row(5)
                        End If
                        If IsDBNull(row(6)) Or row(6).Equals("") Then
                            txtFactura6.Text = ""
                        Else
                            txtFactura6.Text = row(6)
                        End If
                        If IsDBNull(row(7)) Or row(7).Equals("") Then
                            txtFactura7.Text = ""
                        Else
                            txtFactura7.Text = row(7)
                        End If
                        If IsDBNull(row(8)) Or row(8).Equals("") Then
                            txtFactura8.Text = ""
                        Else
                            txtFactura8.Text = row(8)
                        End If
                        If IsDBNull(row(9)) Or row(9).Equals("") Then
                            txtTalon1.Text = ""
                        Else
                            txtTalon1.Text = row(9)
                        End If
                        If IsDBNull(row(10)) Or row(10).Equals("") Then
                            txtTalon2.Text = ""
                        Else
                            txtTalon2.Text = row(10)
                        End If
                        If IsDBNull(row(11)) Or row(11).Equals("") Then
                            txtTalon3.Text = ""
                        Else
                            txtTalon3.Text = row(11)
                        End If
                        If IsDBNull(row(12)) Or row(12).Equals("") Then
                            txtTalon4.Text = ""
                        Else
                            txtTalon4.Text = row(12)
                        End If
                        If IsDBNull(row(13)) Or row(13).Equals("") Then
                            txtTalon5.Text = ""
                        Else
                            txtTalon5.Text = row(13)
                        End If
                        If IsDBNull(row(14)) Or row(14).Equals("") Then
                            txtTalon6.Text = ""
                        Else
                            txtTalon6.Text = row(14)
                        End If
                        If IsDBNull(row(15)) Or row(15).Equals("") Then
                            txtTalon7.Text = ""
                        Else
                            txtTalon7.Text = row(15)
                        End If
                        If IsDBNull(row(16)) Or row(16).Equals("") Then
                            txtTalon8.Text = ""
                        Else
                            txtTalon8.Text = row(16)
                        End If
                        If IsDBNull(row(18)) Or row(18) = 0 Then
                            txtOperador.Text = ""
                        Else
                            txtOperador.Text = row(18)
                        End If
                        If IsDBNull(row(19)) Or row(19).Equals("") Then
                            txtNombreOperador.Text = ""
                        Else
                            txtNombreOperador.Text = row(19)
                        End If
                        If IsDBNull(row(22)) Or row(22) = 0 Then
                            cbdescripciongastos1.Text = ""
                        Else
                            cbdescripciongastos1.Text = row(22)
                        End If
                        If IsDBNull(row(23)) Or row(23) = 0 Then
                            txtmonto1.Text = "0.00"
                        Else
                            txtmonto1.Text = Format(Val(row(23)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(24)) Or row(24).Equals("") Then
                            txtcausa1.Text = ""
                        Else
                            txtcausa1.Text = row(24)
                        End If
                        If IsDBNull(row(25)) Or row(25) = 0 Then
                            cbdescripciongastos2.Text = ""
                        Else
                            cbdescripciongastos2.Text = row(25)
                        End If
                        If IsDBNull(row(26)) Or row(26) = 0 Then
                            txtmonto2.Text = "0.00"
                        Else
                            txtmonto2.Text = Format(Val(row(26)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(27)) Or row(27).Equals("") Then
                            txtcausa2.Text = ""
                        Else
                            txtcausa2.Text = row(27)
                        End If
                        If IsDBNull(row(28)) Or row(28) = 0 Then
                            cbdescripciongastos3.Text = ""
                        Else
                            cbdescripciongastos3.Text = row(28)
                        End If
                        If IsDBNull(row(29)) Or row(29) = 0 Then
                            txtmonto3.Text = "0.00"
                        Else
                            txtmonto3.Text = Format(Val(row(29)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(30)) Or row(30).Equals("") Then
                            txtcausa3.Text = ""
                        Else
                            txtcausa3.Text = row(30)
                        End If
                        If IsDBNull(row(31)) Or row(31) = 0 Then
                            cbdescripciongastos4.Text = ""
                        Else
                            cbdescripciongastos4.Text = row(31)
                        End If
                        If IsDBNull(row(32)) Or row(32) = 0 Then
                            txtmonto4.Text = "0.00"
                        Else
                            txtmonto4.Text = Format(Val(row(32)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(33)) Or row(33).Equals("") Then
                            txtcausa4.Text = ""
                        Else
                            txtcausa4.Text = row(33)
                        End If
                        If IsDBNull(row(34)) Or row(34) = 0 Then
                            cbdescripciongastos5.Text = ""
                        Else
                            cbdescripciongastos5.Text = row(34)
                        End If
                        If IsDBNull(row(35)) Or row(35) = 0 Then
                            txtmonto5.Text = "0.00"
                        Else
                            txtmonto5.Text = Format(Val(row(35)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(36)) Or row(36).Equals("") Then
                            txtcausa5.Text = ""
                        Else
                            txtcausa5.Text = row(36)
                        End If
                        If IsDBNull(row(37)) Or row(37) = 0 Then
                            cbdescripciongastos6.Text = ""
                        Else
                            cbdescripciongastos6.Text = row(37)
                        End If
                        If IsDBNull(row(38)) Or row(38) = 0 Then
                            txtmonto6.Text = "0.00"
                        Else
                            txtmonto6.Text = Format(Val(row(38)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(39)) Or row(39).Equals("") Then
                            txtcausa6.Text = ""
                        Else
                            txtcausa6.Text = row(39)
                        End If
                        If IsDBNull(row(40)) Or row(40) = 0 Then
                            cbdescripciongastos7.Text = ""
                        Else
                            cbdescripciongastos7.Text = row(40)
                        End If
                        If IsDBNull(row(41)) Or row(41) = 0 Then
                            txtmonto7.Text = "0.00"
                        Else
                            txtmonto7.Text = Format(Val(row(41)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(42)) Or row(42).Equals("") Then
                            txtcausa7.Text = ""
                        Else
                            txtcausa7.Text = row(42)
                        End If
                        If IsDBNull(row(43)) Or row(43) = 0 Then
                            cbdescripciongastos8.Text = ""
                        Else
                            cbdescripciongastos8.Text = row(43)
                        End If
                        If IsDBNull(row(44)) Or row(44) = 0 Then
                            txtmonto8.Text = "0.00"
                        Else
                            txtmonto8.Text = Format(Val(row(44)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(45)) Or row(45).Equals("") Then
                            txtcausa8.Text = ""
                        Else
                            txtcausa8.Text = row(45)
                        End If
                        If IsDBNull(row(46)) Then
                            txtfemision.Text = ""
                        Else
                            txtfemision.Text = Format(CDate(row(46)), "dd MMMM yyyy")
                        End If
                        If IsDBNull(row(56)) Then
                            txtfcons.Text = ""
                        Else
                            txtfcons.Text = Format(CDate(row(56)), "dd MMMM yyyy")
                        End If
                        If IsDBNull(row(57)) Then
                            txtfpago.Text = ""
                        Else
                            txtfpago.Text = Format(CDate(row(57)), "dd MMMM yyyy")
                        End If
                        If IsDBNull(row(58)) Or row(58).Equals("") Then
                            cbpatio.Text = ""
                        Else
                            cbpatio.Text = row(58)
                        End If
                        If IsDBNull(row(59)) Or row(59).Equals("") Then
                            cbdestino.Text = ""
                        Else
                            cbdestino.Text = row(59)
                        End If
                        If IsDBNull(row(60)) Or row(60).Equals("") Then
                            txtobservaciones.Text = ""
                        Else
                            txtobservaciones.Text = row(60)
                        End If
                        If IsDBNull(row(61)) Or row(61).Equals("") Then
                            txtequipo.Text = ""
                        Else
                            txtequipo.Text = row(61)
                        End If

                        ID_SOLICITUD = row(64)

                    End If

                    fila = fila + 1

                Next

                monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

                Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")

                buscar_nuevosgastos_conec.Close()
                If txtTalon1.Text = "" Then
                    txtTalon1.Text = TALON
                End If
                Refresh()

            End If

        Catch ex As Exception
            buscar_nuevosgastos_conec.Close()
            sql = ""
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub actualizar_ultimasolicitud()
        Try

            Label17.Text = "PROCESANDO................"
            Me.Refresh()
            conexsql = New SqlConnection(CONEXION_GASTOS)
            conexsql.Open()
            sql = "select TOP 1 SOLICITUD from EXCEDE WHERE ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL ORDER BY SOLICITUD DESC "
            Dim sqlda_actuliza = New SqlDataAdapter(sql, conexsql)
            SOLICDT = New DataTable
            sqlda_actuliza.Fill(SOLICDT)

            For Each ROW In SOLICDT.Rows
                ultima_solicitud = ROW(0)
                txtsolicitud.Text = ROW(0)

            Next

            Form3.buscar(ultima_solicitud)

            btnultimasol.Enabled = False
            btnsigsol.Enabled = False
            btnantsol.Enabled = True
            btnprimersol.Enabled = True
            monto_total = CDbl(txtmonto1.Text) + CDbl(txtmonto2.Text) + CDbl(txtmonto3.Text) + CDbl(txtmonto4.Text) + CDbl(txtmonto5.Text) + CDbl(txtmonto6.Text) + CDbl(txtmonto7.Text) + CDbl(txtmonto8.Text)

            Label16.Text = "TOTAL PAGINA " & Format(Val(monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(SUMA_SOLICITUD), "###,###,##0.00")
            'Label16.Text = Format(Val(SUMA_SOLICITUD), "###,###,##0.00")


            Me.Refresh()
            Label17.Text = ""

            conexsql.Close()

            solicitud_ = txtsolicitud.Text

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtcausa1_TextChanged(sender As Object, e As EventArgs) Handles txtcausa1.TextChanged

    End Sub

    Private Sub txtcausa2_TextChanged(sender As Object, e As EventArgs) Handles txtcausa2.TextChanged

    End Sub

    Sub actualizar_numeroregistros()
        Try

            Label17.Text = "PROCESANDO................"
            Me.Refresh()
            conexsql = New SqlConnection(CONEXION_GASTOS)
            conexsql.Open()
            sql = "select TOP 1 SOLICITUD from EXCEDE WHERE ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL ORDER BY SOLICITUD DESC "
            Dim sqlda_actuliza = New SqlDataAdapter(sql, conexsql)
            SOLICDT = New DataTable
            sqlda_actuliza.Fill(SOLICDT)

            For Each ROW In SOLICDT.Rows
                ultima_solicitud = ROW(0)

            Next

            sql = "select TOP 1 SOLICITUD from EXCEDE WHERE ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL ORDER BY SOLICITUD asc "
            sqlda_actuliza = New SqlDataAdapter(sql, conexsql)
            SOLICDT = New DataTable
            sqlda_actuliza.Fill(SOLICDT)

            For Each ROW In SOLICDT.Rows
                primera_solicitud = ROW(0)

            Next

            conexsql.Close()
            Label17.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub txtcausa1_Leave(sender As Object, e As EventArgs) Handles txtcausa1.Leave
        Try
            Dim caracteres As Integer = 0
            caracteres = Len(txtTalon1.Text)

            If txtTalon1.Text <> "" And caracteres >= 4 Then
                If txtTalon1.Text.Substring(0, 4).Equals("LIS ") Then
                    txtTalon2.Text = txtTalon1.Text.Substring(4, 6)
                Else
                    txtTalon2.Text = txtTalon1.Text
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtcausa2_Leave(sender As Object, e As EventArgs) Handles txtcausa2.Leave
        Try
            If txtTalon2.Text <> "" Then
                If txtTalon2.Text.Substring(0, 4).Equals("LIS ") Then
                    txtTalon3.Text = txtTalon2.Text.Substring(4, 6)
                Else
                    txtTalon3.Text = txtTalon2.Text
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtcausa3_Leave(sender As Object, e As EventArgs) Handles txtcausa3.Leave
        Try
            If txtTalon3.Text <> "" Then
                If txtTalon3.Text.Substring(0, 4).Equals("LIS ") Then
                    txtTalon4.Text = txtTalon3.Text.Substring(4, 6)
                Else
                    txtTalon4.Text = txtTalon3.Text
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtcausa4_Leave(sender As Object, e As EventArgs) Handles txtcausa4.Leave
        Try
            If txtTalon4.Text <> "" Then
                If txtTalon4.Text.Substring(0, 4).Equals("LIS ") Then
                    txtTalon5.Text = txtTalon4.Text.Substring(4, 6)
                Else
                    txtTalon5.Text = txtTalon4.Text
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtcausa5_Leave(sender As Object, e As EventArgs) Handles txtcausa5.Leave
        Try
            If txtTalon5.Text <> "" Then
                If txtTalon5.Text.Substring(0, 4).Equals("LIS ") Then
                    txtTalon6.Text = txtTalon5.Text.Substring(4, 6)
                Else
                    txtTalon6.Text = txtTalon5.Text
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtcausa6_Leave(sender As Object, e As EventArgs) Handles txtcausa6.Leave
        Try
            If txtTalon6.Text <> "" Then
                If txtTalon6.Text.Substring(0, 4).Equals("LIS ") Then
                    txtTalon7.Text = txtTalon6.Text.Substring(4, 6)
                Else
                    txtTalon7.Text = txtTalon6.Text
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtcausa7_Leave(sender As Object, e As EventArgs) Handles txtcausa7.Leave
        Try
            If txtTalon7.Text <> "" Then
                If txtTalon7.Text.Substring(0, 4).Equals("LIS ") Then
                    txtTalon8.Text = txtTalon7.Text.Substring(4, 6)
                Else
                    txtTalon8.Text = txtTalon7.Text
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtOperador_Leave(sender As Object, e As EventArgs) Handles txtOperador.Leave
        Try

            If txtOperador.Text = "" Then
                txtOperador.Text = 0
                Exit Sub
            End If

            Dim SQLCOM_operador As SqlCommand
            Dim SQLDR_operador As SqlDataReader

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "SELECT TOP 1 pp.id_personal No_Operador,pp.nombre,tg.id_unidad,tg.fecha_guia	FROM trafico_guia tg  " &
                    "INNER JOIN personal_personal pp ON tg.id_personal = pp.id_personal " &
                    "where pp.id_personal=" & txtOperador.Text & " and status_guia<>'C' group by pp.id_personal 	,pp.nombre	,tg.id_unidad	,tg.fecha_guia " &
                    "Order by tg.fecha_guia desc"

            SQLCOM_operador = New SqlCommand
            SQLCOM_operador.CommandText = sql
            SQLCOM_operador.Connection = conexsql
            SQLDR_operador = SQLCOM_operador.ExecuteReader
            If SQLDR_operador.Read Then
                txtNombreOperador.Text = SQLDR_operador(1)
                txtOperador.Text = SQLDR_operador(0)
                txtequipo.Text = SQLDR_operador(2)
                NUM_OPERADOR = SQLDR_operador(0)

            Else
                MsgBox("EL NUMERO DE OPERADOR NO EXISTE")
            End If
            SQLDR_operador.Close()
            'conexsql.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtTalon2_Leave(sender As Object, e As EventArgs) Handles txtTalon2.Leave

        Try


            Dim SQLCOM_TALON2 As SqlCommand
            Dim SQLDR_TALON2 As SqlDataReader
            Dim texto_msgbox As String

            If txtTalon2.Text = "" Then
                MsgBox("ESCRIBA UN TALON O SOLICITUD DE PAGO VALIDO")
                Exit Sub
            End If

            Dim TALON2 As String
            Dim OPERADOR2 As String
            TALON2 = txtTalon2.Text
            OPERADOR = txtOperador.Text
            'Limpiar_TextBox(Me)

            Label16.Text = ""
            SUMA_SOLICITUD = 0
            Me.Refresh()

            txtTalon2.Text = TALON2

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "Select tg.num_guia, pp.id_personal No_Operador, pp.nombre,tg.id_unidad from trafico_guia tg inner join " &
                "personal_personal pp On tg.id_personal = pp.id_personal " &
                "where tg.num_guia = '" & txtTalon2.Text & "'"

            SQLCOM_TALON2 = New SqlCommand
            SQLCOM_TALON2.CommandText = sql
            SQLCOM_TALON2.Connection = conexsql
            SQLDR_TALON2 = SQLCOM_TALON2.ExecuteReader
            If SQLDR_TALON2.Read Then
                txtNombreOperador.Text = SQLDR_TALON2(2)
                txtOperador.Text = SQLDR_TALON2(1)
                txtTalon2.Text = SQLDR_TALON2(0)
                txtequipo.Text = SQLDR_TALON2(3)
                btnadd.Enabled = True
                txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                btnsiguiente.Enabled = False
                btnanterior.Enabled = False
                btnprimero.Enabled = False
                btnultimo.Enabled = False

            Else
                'btnadd.Enabled = False
                texto_msgbox = "TALON "
                SQLDR_TALON2.Close()
                'conexsql.Close()

                If Not IsNumeric(txtTalon2.Text) Then
                    MsgBox("NO ES UNA SOLICTUD DE RH NI UN TALON")
                    Exit Sub
                End If

                sql =
                "SELECT TOP 1 rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto,tg.id_unidad,RSP.fecha_solicitud,tg.fecha_guia,tg.num_guia," &
                     "TG.status_guia,RSP.status FROM rho_solicitud_pago RSP  " &
                     "INNER JOIN rho_solicitud_pago_det rspd ON rsp.id_solicitud = rspd.id_solicitud " &
                     "INNER JOIN personal_personal pp ON rsp.id_personal = pp.id_personal INNER JOIN trafico_guia tg ON tg.id_personal = rsp.id_personal " &
                     "WHERE rsp.id_solicitud = " & txtTalon2.Text & " AND TG.status_guia<>'C' AND RSP.status <> 'C' " &
                     "GROUP BY rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto	,tg.id_unidad	,RSP.fecha_solicitud	,tg.fecha_guia," &
                     "tg.num_guia,TG.status_guia,RSP.status ORDER BY tg.fecha_guia DESC"

                SQLCOM_TALON2 = New SqlCommand
                SQLCOM_TALON2.CommandText = sql
                SQLCOM_TALON2.Connection = conexsql
                SQLDR_TALON2 = SQLCOM_TALON2.ExecuteReader
                If SQLDR_TALON2.Read Then
                    txtNombreOperador.Text = SQLDR_TALON2(2)
                    txtOperador.Text = SQLDR_TALON2(1)
                    txtTalon2.Text = "LIS " & SQLDR_TALON2(0)
                    txtequipo.Text = SQLDR_TALON2(5)
                    txtmonto2.Text = Format(CDbl(SQLDR_TALON2(3)), "###,###,##0.00")
                    txtcausa2.Text = SQLDR_TALON2(4)
                    btnadd.Enabled = True
                    txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                    btnsiguiente.Enabled = False
                    btnanterior.Enabled = False
                    btnprimero.Enabled = False
                    btnultimo.Enabled = False

                Else
                    'btnadd.Enabled = False
                    MsgBox(" Y SOLICITUD NO ENCONTRADO FAVOR DE VERIFICAR")

                End If

            End If

            SQLDR_TALON2.Close()
            conexsql.Close()

            If txtOperador.Text <> OPERADOR Then
                MsgBox("EL OPERADOR A CAMBIADO FAVOR DE VERIFICAR")
                Exit Sub
            End If

            'conexsql.Close()


        Catch ex As Exception
            conexsql.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtTalon3_Leave(sender As Object, e As EventArgs) Handles txtTalon3.Leave
        Try


            Dim SQLCOM_TALON3 As SqlCommand
            Dim SQLDR_TALON3 As SqlDataReader
            Dim texto_msgbox As String

            If txtTalon3.Text = "" Then
                MsgBox("ESCRIBA UN TALON O SOLICITUD DE PAGO VALIDO")

                Exit Sub
            End If

            Dim TALON3 As String
            Dim OPERADOR3 As String
            TALON3 = txtTalon3.Text
            OPERADOR = txtOperador.Text
            'Limpiar_TextBox(Me)

            Label16.Text = ""
            SUMA_SOLICITUD = 0
            Me.Refresh()

            txtTalon3.Text = TALON3

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "Select tg.num_guia, pp.id_personal No_Operador, pp.nombre,tg.id_unidad from trafico_guia tg inner join " &
                "personal_personal pp On tg.id_personal = pp.id_personal " &
                "where tg.num_guia = '" & txtTalon3.Text & "'"

            SQLCOM_TALON3 = New SqlCommand
            SQLCOM_TALON3.CommandText = sql
            SQLCOM_TALON3.Connection = conexsql
            SQLDR_TALON3 = SQLCOM_TALON3.ExecuteReader
            If SQLDR_TALON3.Read Then
                txtNombreOperador.Text = SQLDR_TALON3(2)
                txtOperador.Text = SQLDR_TALON3(1)
                txtTalon3.Text = SQLDR_TALON3(0)
                txtequipo.Text = SQLDR_TALON3(3)
                btnadd.Enabled = True
                txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                btnsiguiente.Enabled = False
                btnanterior.Enabled = False
                btnprimero.Enabled = False
                btnultimo.Enabled = False

            Else
                'btnadd.Enabled = False
                texto_msgbox = "TALON "
                SQLDR_TALON3.Close()
                'conexsql.Close()

                If Not IsNumeric(txtTalon3.Text) Then
                    MsgBox("NO ES UNA SOLICTUD DE RH NI UN TALON")
                    Exit Sub
                End If

                sql =
                "SELECT TOP 1 rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto,tg.id_unidad,RSP.fecha_solicitud,tg.fecha_guia,tg.num_guia," &
                     "TG.status_guia,RSP.status FROM rho_solicitud_pago RSP  " &
                     "INNER JOIN rho_solicitud_pago_det rspd ON rsp.id_solicitud = rspd.id_solicitud " &
                     "INNER JOIN personal_personal pp ON rsp.id_personal = pp.id_personal INNER JOIN trafico_guia tg ON tg.id_personal = rsp.id_personal " &
                     "WHERE rsp.id_solicitud = " & txtTalon3.Text & " AND TG.status_guia<>'C' AND RSP.status <> 'C' " &
                     "GROUP BY rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto	,tg.id_unidad	,RSP.fecha_solicitud	,tg.fecha_guia," &
                     "tg.num_guia,TG.status_guia,RSP.status ORDER BY tg.fecha_guia DESC"

                SQLCOM_TALON3 = New SqlCommand
                SQLCOM_TALON3.CommandText = sql
                SQLCOM_TALON3.Connection = conexsql
                SQLDR_TALON3 = SQLCOM_TALON3.ExecuteReader
                If SQLDR_TALON3.Read Then
                    txtNombreOperador.Text = SQLDR_TALON3(2)
                    txtOperador.Text = SQLDR_TALON3(1)
                    txtTalon3.Text = "LIS " & SQLDR_TALON3(0)
                    txtequipo.Text = SQLDR_TALON3(5)
                    txtmonto3.Text = Format(CDbl(SQLDR_TALON3(3)), "###,###,##0.00")
                    txtcausa3.Text = SQLDR_TALON3(4)
                    btnadd.Enabled = True
                    txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                    btnsiguiente.Enabled = False
                    btnanterior.Enabled = False
                    btnprimero.Enabled = False
                    btnultimo.Enabled = False

                Else
                    'btnadd.Enabled = False
                    MsgBox(" Y SOLICITUD NO ENCONTRADO FAVOR DE VERIFICAR")

                End If

            End If

            SQLDR_TALON3.Close()
            conexsql.Close()

            If txtOperador.Text <> OPERADOR Then
                MsgBox("EL OPERADOR A CAMBIADO")
                Exit Sub
            End If


            'conexsql.Close()


        Catch ex As Exception
            conexsql.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtTalon4_Leave(sender As Object, e As EventArgs) Handles txtTalon4.Leave
        Try


            Dim SQLCOM_TALON4 As SqlCommand
            Dim SQLDR_TALON4 As SqlDataReader
            Dim texto_msgbox As String

            If txtTalon4.Text = "" Then
                MsgBox("ESCRIBA UN TALON O SOLICITUD DE PAGO VALIDO")

                Exit Sub
            End If

            Dim TALON4 As String
            Dim OPERADOR4 As String
            TALON4 = txtTalon4.Text
            OPERADOR = txtOperador.Text
            'Limpiar_TextBox(Me)

            Label16.Text = ""
            SUMA_SOLICITUD = 0
            Me.Refresh()

            txtTalon4.Text = TALON4

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "Select tg.num_guia, pp.id_personal No_Operador, pp.nombre,tg.id_unidad from trafico_guia tg inner join " &
                "personal_personal pp On tg.id_personal = pp.id_personal " &
                "where tg.num_guia = '" & txtTalon4.Text & "'"

            SQLCOM_TALON4 = New SqlCommand
            SQLCOM_TALON4.CommandText = sql
            SQLCOM_TALON4.Connection = conexsql
            SQLDR_TALON4 = SQLCOM_TALON4.ExecuteReader
            If SQLDR_TALON4.Read Then
                txtNombreOperador.Text = SQLDR_TALON4(2)
                txtOperador.Text = SQLDR_TALON4(1)
                txtTalon4.Text = SQLDR_TALON4(0)
                txtequipo.Text = SQLDR_TALON4(3)
                btnadd.Enabled = True
                txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                btnsiguiente.Enabled = False
                btnanterior.Enabled = False
                btnprimero.Enabled = False
                btnultimo.Enabled = False

            Else
                'btnadd.Enabled = False
                texto_msgbox = "TALON "
                SQLDR_TALON4.Close()
                'conexsql.Close()

                If Not IsNumeric(txtTalon4.Text) Then
                    MsgBox("NO ES UNA SOLICTUD DE RH NI UN TALON")
                    Exit Sub
                End If

                sql =
                "SELECT TOP 1 rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto,tg.id_unidad,RSP.fecha_solicitud,tg.fecha_guia,tg.num_guia," &
                     "TG.status_guia,RSP.status FROM rho_solicitud_pago RSP  " &
                     "INNER JOIN rho_solicitud_pago_det rspd ON rsp.id_solicitud = rspd.id_solicitud " &
                     "INNER JOIN personal_personal pp ON rsp.id_personal = pp.id_personal INNER JOIN trafico_guia tg ON tg.id_personal = rsp.id_personal " &
                     "WHERE rsp.id_solicitud = " & txtTalon4.Text & " AND TG.status_guia<>'C' AND RSP.status <> 'C' " &
                     "GROUP BY rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto	,tg.id_unidad	,RSP.fecha_solicitud	,tg.fecha_guia," &
                     "tg.num_guia,TG.status_guia,RSP.status ORDER BY tg.fecha_guia DESC"

                SQLCOM_TALON4 = New SqlCommand
                SQLCOM_TALON4.CommandText = sql
                SQLCOM_TALON4.Connection = conexsql
                SQLDR_TALON4 = SQLCOM_TALON4.ExecuteReader
                If SQLDR_TALON4.Read Then
                    txtNombreOperador.Text = SQLDR_TALON4(2)
                    txtOperador.Text = SQLDR_TALON4(1)
                    txtTalon4.Text = "LIS " & SQLDR_TALON4(0)
                    txtequipo.Text = SQLDR_TALON4(5)
                    txtmonto4.Text = Format(CDbl(SQLDR_TALON4(3)), "###,###,##0.00")
                    txtcausa4.Text = SQLDR_TALON4(4)
                    btnadd.Enabled = True
                    txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                    btnsiguiente.Enabled = False
                    btnanterior.Enabled = False
                    btnprimero.Enabled = False
                    btnultimo.Enabled = False

                Else
                    'btnadd.Enabled = False
                    MsgBox(" Y SOLICITUD NO ENCONTRADO FAVOR DE VERIFICAR")

                End If

            End If

            SQLDR_TALON4.Close()
            conexsql.Close()

            If txtOperador.Text <> OPERADOR Then
                MsgBox("EL OPERADOR A CAMBIADO")
                Exit Sub
            End If
            'conexsql.Close()


        Catch ex As Exception
            conexsql.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtTalon5_Leave(sender As Object, e As EventArgs) Handles txtTalon5.Leave
        Try


            Dim SQLCOM_TALON5 As SqlCommand
            Dim SQLDR_TALON5 As SqlDataReader
            Dim texto_msgbox As String

            If txtTalon5.Text = "" Then
                MsgBox("ESCRIBA UN TALON O SOLICITUD DE PAGO VALIDO")

                Exit Sub
            End If

            Dim TALON5 As String
            Dim OPERADOR5 As String
            TALON5 = txtTalon5.Text
            OPERADOR = txtOperador.Text
            'Limpiar_TextBox(Me)

            Label16.Text = ""
            SUMA_SOLICITUD = 0
            Me.Refresh()

            txtTalon5.Text = TALON5

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "Select tg.num_guia, pp.id_personal No_Operador, pp.nombre,tg.id_unidad from trafico_guia tg inner join " &
                "personal_personal pp On tg.id_personal = pp.id_personal " &
                "where tg.num_guia = '" & txtTalon5.Text & "'"

            SQLCOM_TALON5 = New SqlCommand
            SQLCOM_TALON5.CommandText = sql
            SQLCOM_TALON5.Connection = conexsql
            SQLDR_TALON5 = SQLCOM_TALON5.ExecuteReader
            If SQLDR_TALON5.Read Then
                txtNombreOperador.Text = SQLDR_TALON5(2)
                txtOperador.Text = SQLDR_TALON5(1)
                txtTalon5.Text = SQLDR_TALON5(0)
                txtequipo.Text = SQLDR_TALON5(3)
                btnadd.Enabled = True
                txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                btnsiguiente.Enabled = False
                btnanterior.Enabled = False
                btnprimero.Enabled = False
                btnultimo.Enabled = False

            Else
                'btnadd.Enabled = False
                texto_msgbox = "TALON "
                SQLDR_TALON5.Close()
                'conexsql.Close()

                If Not IsNumeric(txtTalon5.Text) Then
                    MsgBox("NO ES UNA SOLICTUD DE RH NI UN TALON")
                    Exit Sub
                End If

                sql =
                "SELECT TOP 1 rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto,tg.id_unidad,RSP.fecha_solicitud,tg.fecha_guia,tg.num_guia," &
                     "TG.status_guia,RSP.status FROM rho_solicitud_pago RSP  " &
                     "INNER JOIN rho_solicitud_pago_det rspd ON rsp.id_solicitud = rspd.id_solicitud " &
                     "INNER JOIN personal_personal pp ON rsp.id_personal = pp.id_personal INNER JOIN trafico_guia tg ON tg.id_personal = rsp.id_personal " &
                     "WHERE rsp.id_solicitud = " & txtTalon5.Text & " AND TG.status_guia<>'C' AND RSP.status <> 'C' " &
                     "GROUP BY rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto	,tg.id_unidad	,RSP.fecha_solicitud	,tg.fecha_guia," &
                     "tg.num_guia,TG.status_guia,RSP.status ORDER BY tg.fecha_guia DESC"

                SQLCOM_TALON5 = New SqlCommand
                SQLCOM_TALON5.CommandText = sql
                SQLCOM_TALON5.Connection = conexsql
                SQLDR_TALON5 = SQLCOM_TALON5.ExecuteReader
                If SQLDR_TALON5.Read Then
                    txtNombreOperador.Text = SQLDR_TALON5(2)
                    txtOperador.Text = SQLDR_TALON5(1)
                    txtTalon5.Text = "LIS " & SQLDR_TALON5(0)
                    txtequipo.Text = SQLDR_TALON5(5)
                    txtmonto5.Text = Format(CDbl(SQLDR_TALON5(3)), "###,###,##0.00")
                    txtcausa5.Text = SQLDR_TALON5(4)
                    btnadd.Enabled = True
                    txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                    btnsiguiente.Enabled = False
                    btnanterior.Enabled = False
                    btnprimero.Enabled = False
                    btnultimo.Enabled = False

                Else
                    'btnadd.Enabled = False
                    MsgBox(" Y SOLICITUD NO ENCONTRADO FAVOR DE VERIFICAR")

                End If

            End If

            SQLDR_TALON5.Close()
            conexsql.Close()

            If txtOperador.Text <> OPERADOR Then
                MsgBox("EL OPERADOR A CAMBIADO")
                Exit Sub
            End If
            'conexsql.Close()


        Catch ex As Exception
            conexsql.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtTalon6_Leave(sender As Object, e As EventArgs) Handles txtTalon6.Leave
        Try


            Dim SQLCOM_TALON6 As SqlCommand
            Dim SQLDR_TALON6 As SqlDataReader
            Dim texto_msgbox As String

            If txtTalon6.Text = "" Then
                MsgBox("ESCRIBA UN TALON O SOLICITUD DE PAGO VALIDO")

                Exit Sub
            End If

            Dim TALON6 As String
            Dim OPERADOR6 As String
            TALON6 = txtTalon6.Text
            OPERADOR = txtOperador.Text
            'Limpiar_TextBox(Me)

            Label16.Text = ""
            SUMA_SOLICITUD = 0
            Me.Refresh()

            txtTalon6.Text = TALON6

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "Select tg.num_guia, pp.id_personal No_Operador, pp.nombre,tg.id_unidad from trafico_guia tg inner join " &
                "personal_personal pp On tg.id_personal = pp.id_personal " &
                "where tg.num_guia = '" & txtTalon6.Text & "'"

            SQLCOM_TALON6 = New SqlCommand
            SQLCOM_TALON6.CommandText = sql
            SQLCOM_TALON6.Connection = conexsql
            SQLDR_TALON6 = SQLCOM_TALON6.ExecuteReader
            If SQLDR_TALON6.Read Then
                txtNombreOperador.Text = SQLDR_TALON6(2)
                txtOperador.Text = SQLDR_TALON6(1)
                txtTalon6.Text = SQLDR_TALON6(0)
                txtequipo.Text = SQLDR_TALON6(3)
                btnadd.Enabled = True
                txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                btnsiguiente.Enabled = False
                btnanterior.Enabled = False
                btnprimero.Enabled = False
                btnultimo.Enabled = False

            Else
                'btnadd.Enabled = False
                texto_msgbox = "TALON "
                SQLDR_TALON6.Close()
                'conexsql.Close()

                If Not IsNumeric(txtTalon6.Text) Then
                    MsgBox("NO ES UNA SOLICTUD DE RH NI UN TALON")
                    Exit Sub
                End If

                sql =
                "SELECT TOP 1 rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto,tg.id_unidad,RSP.fecha_solicitud,tg.fecha_guia,tg.num_guia," &
                     "TG.status_guia,RSP.status FROM rho_solicitud_pago RSP  " &
                     "INNER JOIN rho_solicitud_pago_det rspd ON rsp.id_solicitud = rspd.id_solicitud " &
                     "INNER JOIN personal_personal pp ON rsp.id_personal = pp.id_personal INNER JOIN trafico_guia tg ON tg.id_personal = rsp.id_personal " &
                     "WHERE rsp.id_solicitud = " & txtTalon6.Text & " AND TG.status_guia<>'C' AND RSP.status <> 'C' " &
                     "GROUP BY rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto	,tg.id_unidad	,RSP.fecha_solicitud	,tg.fecha_guia," &
                     "tg.num_guia,TG.status_guia,RSP.status ORDER BY tg.fecha_guia DESC"

                SQLCOM_TALON6 = New SqlCommand
                SQLCOM_TALON6.CommandText = sql
                SQLCOM_TALON6.Connection = conexsql
                SQLDR_TALON6 = SQLCOM_TALON6.ExecuteReader
                If SQLDR_TALON6.Read Then
                    txtNombreOperador.Text = SQLDR_TALON6(2)
                    txtOperador.Text = SQLDR_TALON6(1)
                    txtTalon6.Text = "LIS " & SQLDR_TALON6(0)
                    txtequipo.Text = SQLDR_TALON6(5)
                    txtmonto6.Text = Format(CDbl(SQLDR_TALON6(3)), "###,###,##0.00")
                    txtcausa6.Text = SQLDR_TALON6(4)
                    btnadd.Enabled = True
                    txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                    btnsiguiente.Enabled = False
                    btnanterior.Enabled = False
                    btnprimero.Enabled = False
                    btnultimo.Enabled = False

                Else
                    'btnadd.Enabled = False
                    MsgBox(" Y SOLICITUD NO ENCONTRADO FAVOR DE VERIFICAR")

                End If

            End If

            SQLDR_TALON6.Close()
            conexsql.Close()

            If txtOperador.Text <> OPERADOR Then
                MsgBox("EL OPERADOR A CAMBIADO")
                Exit Sub
            End If

            'conexsql.Close()


        Catch ex As Exception
            conexsql.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub txtTalon7_Leave(sender As Object, e As EventArgs) Handles txtTalon7.Leave
        Try


            Dim SQLCOM_TALON7 As SqlCommand
            Dim SQLDR_TALON7 As SqlDataReader
            Dim texto_msgbox As String

            If txtTalon7.Text = "" Then
                MsgBox("ESCRIBA UN TALON O SOLICITUD DE PAGO VALIDO")

                Exit Sub
            End If

            Dim TALON7 As String
            Dim OPERADOR7 As String
            TALON7 = txtTalon7.Text
            OPERADOR = txtOperador.Text
            'Limpiar_TextBox(Me)

            Label16.Text = ""
            SUMA_SOLICITUD = 0
            Me.Refresh()

            txtTalon7.Text = TALON7

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "Select tg.num_guia, pp.id_personal No_Operador, pp.nombre,tg.id_unidad from trafico_guia tg inner join " &
                "personal_personal pp On tg.id_personal = pp.id_personal " &
                "where tg.num_guia = '" & txtTalon7.Text & "'"

            SQLCOM_TALON7 = New SqlCommand
            SQLCOM_TALON7.CommandText = sql
            SQLCOM_TALON7.Connection = conexsql
            SQLDR_TALON7 = SQLCOM_TALON7.ExecuteReader
            If SQLDR_TALON7.Read Then
                txtNombreOperador.Text = SQLDR_TALON7(2)
                txtOperador.Text = SQLDR_TALON7(1)
                txtTalon7.Text = SQLDR_TALON7(0)
                txtequipo.Text = SQLDR_TALON7(3)
                btnadd.Enabled = True
                txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                btnsiguiente.Enabled = False
                btnanterior.Enabled = False
                btnprimero.Enabled = False
                btnultimo.Enabled = False

            Else
                'btnadd.Enabled = False
                texto_msgbox = "TALON "
                SQLDR_TALON7.Close()
                'conexsql.Close()

                If Not IsNumeric(txtTalon7.Text) Then
                    MsgBox("NO ES UNA SOLICTUD DE RH NI UN TALON")
                    Exit Sub
                End If

                sql =
                "SELECT TOP 1 rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto,tg.id_unidad,RSP.fecha_solicitud,tg.fecha_guia,tg.num_guia," &
                     "TG.status_guia,RSP.status FROM rho_solicitud_pago RSP  " &
                     "INNER JOIN rho_solicitud_pago_det rspd ON rsp.id_solicitud = rspd.id_solicitud " &
                     "INNER JOIN personal_personal pp ON rsp.id_personal = pp.id_personal INNER JOIN trafico_guia tg ON tg.id_personal = rsp.id_personal " &
                     "WHERE rsp.id_solicitud = " & txtTalon7.Text & " AND TG.status_guia<>'C' AND RSP.status <> 'C' " &
                     "GROUP BY rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto	,tg.id_unidad	,RSP.fecha_solicitud	,tg.fecha_guia," &
                     "tg.num_guia,TG.status_guia,RSP.status ORDER BY tg.fecha_guia DESC"

                SQLCOM_TALON7 = New SqlCommand
                SQLCOM_TALON7.CommandText = sql
                SQLCOM_TALON7.Connection = conexsql
                SQLDR_TALON7 = SQLCOM_TALON7.ExecuteReader
                If SQLDR_TALON7.Read Then
                    txtNombreOperador.Text = SQLDR_TALON7(2)
                    txtOperador.Text = SQLDR_TALON7(1)
                    txtTalon7.Text = "LIS " & SQLDR_TALON7(0)
                    txtequipo.Text = SQLDR_TALON7(5)
                    txtmonto7.Text = Format(CDbl(SQLDR_TALON7(3)), "###,###,##0.00")
                    txtcausa7.Text = SQLDR_TALON7(4)
                    btnadd.Enabled = True
                    txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                    btnsiguiente.Enabled = False
                    btnanterior.Enabled = False
                    btnprimero.Enabled = False
                    btnultimo.Enabled = False

                Else
                    'btnadd.Enabled = False
                    MsgBox(" Y SOLICITUD NO ENCONTRADO FAVOR DE VERIFICAR")

                End If

            End If

            SQLDR_TALON7.Close()
            conexsql.Close()

            If txtOperador.Text <> OPERADOR Then
                MsgBox("EL OPERADOR A CAMBIADO")
                Exit Sub
            End If

            'conexsql.Close()


        Catch ex As Exception
            conexsql.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtTalon8_Leave(sender As Object, e As EventArgs) Handles txtTalon8.Leave
        Try


            Dim SQLCOM_TALON8 As SqlCommand
            Dim SQLDR_TALON8 As SqlDataReader
            Dim texto_msgbox As String

            If txtTalon8.Text = "" Then
                MsgBox("ESCRIBA UN TALON O SOLICITUD DE PAGO VALIDO")

                Exit Sub
            End If

            Dim TALON8 As String
            Dim OPERADOR8 As String
            TALON8 = txtTalon8.Text
            OPERADOR = txtOperador.Text
            'Limpiar_TextBox(Me)

            Label16.Text = ""
            SUMA_SOLICITUD = 0
            Me.Refresh()

            txtTalon8.Text = TALON8

            conexsql = New SqlConnection(CONEXION_DB)
            conexsql.Open()
            sql = "Select tg.num_guia, pp.id_personal No_Operador, pp.nombre,tg.id_unidad from trafico_guia tg inner join " &
                "personal_personal pp On tg.id_personal = pp.id_personal " &
                "where tg.num_guia = '" & txtTalon8.Text & "'"

            SQLCOM_TALON8 = New SqlCommand
            SQLCOM_TALON8.CommandText = sql
            SQLCOM_TALON8.Connection = conexsql
            SQLDR_TALON8 = SQLCOM_TALON8.ExecuteReader
            If SQLDR_TALON8.Read Then
                txtNombreOperador.Text = SQLDR_TALON8(2)
                txtOperador.Text = SQLDR_TALON8(1)
                txtTalon8.Text = SQLDR_TALON8(0)
                txtequipo.Text = SQLDR_TALON8(3)
                btnadd.Enabled = True
                txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                btnsiguiente.Enabled = False
                btnanterior.Enabled = False
                btnprimero.Enabled = False
                btnultimo.Enabled = False

            Else
                'btnadd.Enabled = False
                texto_msgbox = "TALON "
                SQLDR_TALON8.Close()
                'conexsql.Close()

                If Not IsNumeric(txtTalon8.Text) Then
                    MsgBox("NO ES UNA SOLICTUD DE RH NI UN TALON")
                    Exit Sub
                End If

                sql =
                "SELECT TOP 1 rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto,tg.id_unidad,RSP.fecha_solicitud,tg.fecha_guia,tg.num_guia," &
                     "TG.status_guia,RSP.status FROM rho_solicitud_pago RSP  " &
                     "INNER JOIN rho_solicitud_pago_det rspd ON rsp.id_solicitud = rspd.id_solicitud " &
                     "INNER JOIN personal_personal pp ON rsp.id_personal = pp.id_personal INNER JOIN trafico_guia tg ON tg.id_personal = rsp.id_personal " &
                     "WHERE rsp.id_solicitud = " & txtTalon8.Text & " AND TG.status_guia<>'C' AND RSP.status <> 'C' " &
                     "GROUP BY rsp.id_solicitud,rsp.id_personal	,pp.nombre,rspd.monto_concepto,rspd.desc_concepto	,tg.id_unidad	,RSP.fecha_solicitud	,tg.fecha_guia," &
                     "tg.num_guia,TG.status_guia,RSP.status ORDER BY tg.fecha_guia DESC"

                SQLCOM_TALON8 = New SqlCommand
                SQLCOM_TALON8.CommandText = sql
                SQLCOM_TALON8.Connection = conexsql
                SQLDR_TALON8 = SQLCOM_TALON8.ExecuteReader
                If SQLDR_TALON8.Read Then
                    txtNombreOperador.Text = SQLDR_TALON8(2)
                    txtOperador.Text = SQLDR_TALON8(1)
                    txtTalon8.Text = "LIS " & SQLDR_TALON8(0)
                    txtequipo.Text = SQLDR_TALON8(5)
                    txtmonto8.Text = Format(CDbl(SQLDR_TALON8(3)), "###,###,##0.00")
                    txtcausa8.Text = SQLDR_TALON8(4)
                    btnadd.Enabled = True
                    txtfemision.Text = DateTime.Now.ToString("dd MMMM yyyy")
                    btnsiguiente.Enabled = False
                    btnanterior.Enabled = False
                    btnprimero.Enabled = False
                    btnultimo.Enabled = False

                Else
                    'btnadd.Enabled = False
                    MsgBox(" Y SOLICITUD NO ENCONTRADO FAVOR DE VERIFICAR")

                End If

            End If

            SQLDR_TALON8.Close()
            conexsql.Close()

            If txtOperador.Text <> OPERADOR Then
                MsgBox("EL OPERADOR A CAMBIADO")
                Exit Sub
            End If

            'conexsql.Close()


        Catch ex As Exception
            conexsql.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cbdescripciongastos1_Leave(sender As Object, e As EventArgs) Handles cbdescripciongastos1.Leave
        'Dim Index = cbdescripciongastos1.FindString(cbdescripciongastos1.Text)
        'If Index < 0 Then
        '    MsgBox("ESCRIBA O SELECCIONE O GASTO VALIDO")
        '    Exit Sub
        'Else
        '    cbdescripciongastos1.SelectedIndex = Index
        'End If

        TEXTO1 = ""

        Try

            If NUM_OPERADOR <> "" Then
                If cbdescripciongastos1.Text = "LIQUIDACION" Then
                    liquidaciones.NUM_OPERADOR_LIQUIDACION = NUM_OPERADOR
                    liquidaciones.Show()
                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()
                    Dim sqlda As SqlDataAdapter
                    Dim ds1 As DataSet = New DataSet

                    dATOS_REPETIDOS = New DataTable
                    sql = "GASTOS_REPETIDOS '" & txtOperador.Text & "','" & cbdescripciongastos1.SelectedValue & "'"
                    sqlda = New SqlDataAdapter(sql, conexsql)
                    sqlda.Fill(dATOS_REPETIDOS)
                    If dATOS_REPETIDOS.Rows.Count = 0 Then

                    Else
                        GASTOS_REPETIDOS.Show()
                    End If
                End If
            Else
                MsgBox("FALTA OPERADOR")
            End If

            conexsql.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cbdescripciongastos2_Leave(sender As Object, e As EventArgs) Handles cbdescripciongastos2.Leave
        'Dim Index = cbdescripciongastos2.FindString(cbdescripciongastos2.Text)
        'cbdescripciongastos2.SelectedIndex = Index
        Try
            If NUM_OPERADOR <> "" Then
                If cbdescripciongastos2.Text = "LIQUIDACION" Then
                    liquidaciones.NUM_OPERADOR_LIQUIDACION = NUM_OPERADOR
                    liquidaciones.Show()
                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()
                    Dim sqlda As SqlDataAdapter
                    Dim ds1 As DataSet = New DataSet

                    dATOS_REPETIDOS = New DataTable
                    sql = "GASTOS_REPETIDOS '" & txtOperador.Text & "','" & cbdescripciongastos2.SelectedValue & "'"
                    sqlda = New SqlDataAdapter(sql, conexsql)
                    sqlda.Fill(dATOS_REPETIDOS)
                    If dATOS_REPETIDOS.Rows.Count = 0 Then

                    Else
                        GASTOS_REPETIDOS.Show()
                    End If
                End If
            Else
                MsgBox("FALTA OPERADOR")
            End If
            conexsql.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cbdescripciongastos3_Leave(sender As Object, e As EventArgs) Handles cbdescripciongastos3.Leave
        'Dim Index = cbdescripciongastos3.FindString(cbdescripciongastos3.Text)
        'cbdescripciongastos3.SelectedIndex = Index
        Try
            If NUM_OPERADOR <> "" Then
                If cbdescripciongastos3.Text = "LIQUIDACION" Then
                    liquidaciones.NUM_OPERADOR_LIQUIDACION = NUM_OPERADOR
                    liquidaciones.Show()
                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()
                    Dim sqlda As SqlDataAdapter
                    Dim ds1 As DataSet = New DataSet

                    dATOS_REPETIDOS = New DataTable
                    sql = "GASTOS_REPETIDOS '" & txtOperador.Text & "','" & cbdescripciongastos3.SelectedValue & "'"
                    sqlda = New SqlDataAdapter(sql, conexsql)
                    sqlda.Fill(dATOS_REPETIDOS)
                    If dATOS_REPETIDOS.Rows.Count = 0 Then

                    Else
                        GASTOS_REPETIDOS.Show()
                    End If
                End If
            Else
                MsgBox("FALTA OPERADOR")
            End If
            conexsql.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cbdescripciongastos4_Leave(sender As Object, e As EventArgs) Handles cbdescripciongastos4.Leave
        'Dim Index = cbdescripciongastos4.FindString(cbdescripciongastos4.Text)
        'cbdescripciongastos4.SelectedIndex = Index
        Try
            If NUM_OPERADOR <> "" Then
                If cbdescripciongastos4.Text = "LIQUIDACION" Then
                    liquidaciones.NUM_OPERADOR_LIQUIDACION = NUM_OPERADOR
                    liquidaciones.Show()
                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()
                    Dim sqlda As SqlDataAdapter
                    Dim ds1 As DataSet = New DataSet

                    dATOS_REPETIDOS = New DataTable
                    sql = "GASTOS_REPETIDOS '" & txtOperador.Text & "','" & cbdescripciongastos4.SelectedValue & "'"
                    sqlda = New SqlDataAdapter(sql, conexsql)
                    sqlda.Fill(dATOS_REPETIDOS)
                    If dATOS_REPETIDOS.Rows.Count = 0 Then

                    Else
                        GASTOS_REPETIDOS.Show()
                    End If
                End If
            Else
                MsgBox("FALTA OPERADOR")
            End If
            conexsql.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cbdescripciongastos5_Leave(sender As Object, e As EventArgs) Handles cbdescripciongastos5.Leave
        'Dim Index = cbdescripciongastos5.FindString(cbdescripciongastos5.Text)
        'cbdescripciongastos5.SelectedIndex = Index
        Try
            If NUM_OPERADOR <> "" Then
                If cbdescripciongastos5.Text = "LIQUIDACION" Then
                    liquidaciones.NUM_OPERADOR_LIQUIDACION = NUM_OPERADOR
                    liquidaciones.Show()
                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()
                    Dim sqlda As SqlDataAdapter
                    Dim ds1 As DataSet = New DataSet

                    dATOS_REPETIDOS = New DataTable
                    sql = "GASTOS_REPETIDOS '" & txtOperador.Text & "','" & cbdescripciongastos5.SelectedValue & "'"
                    sqlda = New SqlDataAdapter(sql, conexsql)
                    sqlda.Fill(dATOS_REPETIDOS)
                    If dATOS_REPETIDOS.Rows.Count = 0 Then

                    Else
                        GASTOS_REPETIDOS.Show()
                    End If
                End If
            Else
                MsgBox("FALTA OPERADOR")
            End If
            conexsql.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cbdescripciongastos6_Leave(sender As Object, e As EventArgs) Handles cbdescripciongastos6.Leave
        'Dim Index = cbdescripciongastos6.FindString(cbdescripciongastos6.Text)
        'cbdescripciongastos6.SelectedIndex = Index

        Try
            If NUM_OPERADOR <> "" Then
                If cbdescripciongastos6.Text = "LIQUIDACION" Then
                    liquidaciones.NUM_OPERADOR_LIQUIDACION = NUM_OPERADOR
                    liquidaciones.Show()
                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()
                    Dim sqlda As SqlDataAdapter
                    Dim ds1 As DataSet = New DataSet

                    dATOS_REPETIDOS = New DataTable
                    sql = "GASTOS_REPETIDOS '" & txtOperador.Text & "','" & cbdescripciongastos6.SelectedValue & "'"
                    sqlda = New SqlDataAdapter(sql, conexsql)
                    sqlda.Fill(dATOS_REPETIDOS)
                    If dATOS_REPETIDOS.Rows.Count = 0 Then

                    Else
                        GASTOS_REPETIDOS.Show()
                    End If
                End If
            Else
                MsgBox("FALTA OPERADOR")
            End If
            conexsql.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cbdescripciongastos7_Leave(sender As Object, e As EventArgs) Handles cbdescripciongastos7.Leave
        'Dim Index = cbdescripciongastos7.FindString(cbdescripciongastos7.Text)
        'cbdescripciongastos7.SelectedIndex = Index
        Try
            If NUM_OPERADOR <> "" Then
                If cbdescripciongastos7.Text = "LIQUIDACION" Then
                    liquidaciones.NUM_OPERADOR_LIQUIDACION = NUM_OPERADOR
                    liquidaciones.Show()
                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()
                    Dim sqlda As SqlDataAdapter
                    Dim ds1 As DataSet = New DataSet

                    dATOS_REPETIDOS = New DataTable
                    sql = "GASTOS_REPETIDOS '" & txtOperador.Text & "','" & cbdescripciongastos7.SelectedValue & "'"
                    sqlda = New SqlDataAdapter(sql, conexsql)
                    sqlda.Fill(dATOS_REPETIDOS)
                    If dATOS_REPETIDOS.Rows.Count = 0 Then

                    Else
                        GASTOS_REPETIDOS.Show()
                    End If
                End If
            Else
                MsgBox("FALTA OPERADOR")
            End If
            conexsql.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cbdescripciongastos8_Leave(sender As Object, e As EventArgs) Handles cbdescripciongastos8.Leave
        'Dim Index = cbdescripciongastos8.FindString(cbdescripciongastos8.Text)
        'cbdescripciongastos8.SelectedIndex = Index
        Try
            If NUM_OPERADOR <> "" Then
                If cbdescripciongastos8.Text = "LIQUIDACION" Then
                    liquidaciones.NUM_OPERADOR_LIQUIDACION = NUM_OPERADOR
                    liquidaciones.Show()
                    conexsql = New SqlConnection(CONEXION_GASTOS)
                    conexsql.Open()
                    Dim sqlda As SqlDataAdapter
                    Dim ds1 As DataSet = New DataSet

                    dATOS_REPETIDOS = New DataTable
                    sql = "GASTOS_REPETIDOS '" & txtOperador.Text & "','" & cbdescripciongastos8.SelectedValue & "'"
                    sqlda = New SqlDataAdapter(sql, conexsql)
                    sqlda.Fill(dATOS_REPETIDOS)
                    If dATOS_REPETIDOS.Rows.Count = 0 Then

                    Else
                        GASTOS_REPETIDOS.Show()
                    End If
                End If
            Else
                MsgBox("FALTA OPERADOR")
            End If
            conexsql.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtOperador_TextChanged(sender As Object, e As EventArgs) Handles txtOperador.TextChanged

    End Sub

    Private Sub txtTalon1_TextChanged(sender As Object, e As EventArgs) Handles txtTalon1.TextChanged

    End Sub

    Private Sub cbdescripciongastos1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbdescripciongastos1.SelectedIndexChanged

    End Sub

    Private Sub cbdescripciongastos1_GotFocus(sender As Object, e As EventArgs) Handles cbdescripciongastos1.GotFocus
        'cbdescripciongastos1.DroppedDown = True

    End Sub

    Sub NO_REPETIR_GASTOS()

    End Sub

    Private Sub txtTalon1_CursorChanged(sender As Object, e As EventArgs) Handles txtTalon1.CursorChanged

    End Sub


End Class