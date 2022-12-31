Imports System.Data.SqlClient
Public Class Form3
    Dim buscarconec As SqlConnection
    Dim buscarsa As SqlDataAdapter
    Dim buscards As DataSet

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'sql = "SELECT SC.NAME FROM sys.objects SO INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID where so.name='excede' order by 1"
            'Dim buscarconec As SqlConnection
            'Dim buscarsa As SqlDataAdapter
            'Dim buscards As DataSet

            'buscarconec = New SqlConnection(CONEXION_GASTOS)
            'buscarconec.Open()
            'buscarsa = New SqlDataAdapter(sql, buscarconec)
            'buscards = New DataSet
            'buscarsa.Fill(buscards)

            'ComboBox1.DataSource = buscards.Tables(0)
            'ComboBox1.DisplayMember = "NAME"

            'buscarconec.Close()
            'sql = ""
            'buscarsa.Dispose()
            'buscards.Dispose()

        Catch ex As Exception
            buscarconec.Close()
            sql = ""
            buscarsa.Dispose()
            buscards.Dispose()
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Label2.Text = "PROCESANDO................."
            Me.Refresh()


            buscar(TextBox1.Text)
            Form2.monto_total = CDbl(Form2.txtmonto1.Text) + CDbl(Form2.txtmonto2.Text) + CDbl(Form2.txtmonto3.Text) +
                CDbl(Form2.txtmonto4.Text) + CDbl(Form2.txtmonto5.Text) + CDbl(Form2.txtmonto6.Text) + CDbl(Form2.txtmonto7.Text) +
                CDbl(Form2.txtmonto8.Text)

            Form2.Label16.Text = "TOTAL PAGINA " & Format(Val(Form2.monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(Form2.SUMA_SOLICITUD), "###,###,##0.00")

            Form2.Label17.Text = ""


            If moduio.Equals("CAJA Y NOMINA") Or moduio.Equals("CAJA") Then
                Form2.btnadd.Enabled = False
                Form2.btndelete.Enabled = False
                Form2.btncancelar.Enabled = False
                Form2.btncatalogo.Enabled = False
                Form2.btnadd.Enabled = False
                Form2.Label17.Text = ""
                Form2.inhabilitar_Textbox(Me)
                Form2.btnagregargastossol.Enabled = False
                Form2.btnanterior.Enabled = False
                Form2.btnantsol.Enabled = False
                Form2.btnprimero.Enabled = False
                Form2.btnprimersol.Enabled = False
                Form2.btnsigsol.Enabled = False
                Form2.btnsiguiente.Enabled = False
                Form2.btnultimasol.Enabled = False
                Form2.btnultimo.Enabled = False

            End If

            Label2.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub DateTimePicker1_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker1.CloseUp
        TextBox2.Text = Format(CDate(DateTimePicker1.Value), "dd MMMM yyyy")

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

    End Sub

    Private Sub DateTimePicker2_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker2.CloseUp
        TextBox3.Text = Format(CDate(DateTimePicker2.Value), "dd MMMM yyyy")

    End Sub

    Sub buscar(solicitud As String)
        Try

            Form2.registro = 0
            'sql = "select * from excede where solicitud = '" & solicitud & "' order by id_solicitud "

            If moduio.Equals("CAJA Y NOMINA") Or moduio.Equals("CAJA") Then

                sql = "SELECT SOLICITUD,FACTURA1,FACTURA2,FACTURA3,FACTURA4,FACTURA5,FACTURA6,FACTURA7,FACTURA8,TALON " &
                ",TALON2,TALON3,TALON4,TALON5,TALON6,TALON7,TALON8,VERIFICA,OPERADOR,NOMBRE,CLAVE,DESCRIP " &
                ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE1)CLAVE1,MONTO1,CAUSA1 " &
                ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE2)CLAVE2,MONTO2,CAUSA2 " &
                ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE3)CLAVE3,MONTO3,CAUSA3 " &
                ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE4)CLAVE4,MONTO4,CAUSA4 " &
                ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE5)CLAVE5,MONTO5,CAUSA5 " &
                ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE6)CLAVE6,MONTO6,CAUSA6 " &
                ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE7)CLAVE7,MONTO7,CAUSA7 " &
                ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE8)CLAVE8,MONTO8,CAUSA8 " &
                ",FECHA_EMI,MONTO,CAJA,CLAVE_TRAF,FECHAREG,HORAREG,FECHA_PAG,CLAVE_CAJ,FECHAREGCA,HORAREGCAJ " &
                ",FECHA_CONS,FECHA_PAGO,BASE_PAGO,DESTINO,OBSERVA,NUM_ECO,PAGADO,ESTATUS,ID_SOLICITUD " &
                "FROM excede WHERE SOLICITUD='" & solicitud & "' AND  base_pago='" & usuario_basepago & "' AND VERIFICA IS NOT NULL and (ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL) order by id_solicitud "


            Else

                sql = "SELECT SOLICITUD,FACTURA1,FACTURA2,FACTURA3,FACTURA4,FACTURA5,FACTURA6,FACTURA7,FACTURA8,TALON " &
                    ",TALON2,TALON3,TALON4,TALON5,TALON6,TALON7,TALON8,VERIFICA,OPERADOR,NOMBRE,CLAVE,DESCRIP " &
                    ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE1)CLAVE1,MONTO1,CAUSA1 " &
                    ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE2)CLAVE2,MONTO2,CAUSA2 " &
                    ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE3)CLAVE3,MONTO3,CAUSA3 " &
                    ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE4)CLAVE4,MONTO4,CAUSA4 " &
                    ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE5)CLAVE5,MONTO5,CAUSA5 " &
                    ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE6)CLAVE6,MONTO6,CAUSA6 " &
                    ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE7)CLAVE7,MONTO7,CAUSA7 " &
                    ",(select TOP 1 DESCRIP from VARIOS where  CLAVE=CLAVE8)CLAVE8,MONTO8,CAUSA8 " &
                    ",FECHA_EMI,MONTO,CAJA,CLAVE_TRAF,FECHAREG,HORAREG,FECHA_PAG,CLAVE_CAJ,FECHAREGCA,HORAREGCAJ " &
                    ",FECHA_CONS,FECHA_PAGO,BASE_PAGO,DESTINO,OBSERVA,NUM_ECO,PAGADO,ESTATUS,ID_SOLICITUD " &
                    "FROM excede WHERE SOLICITUD='" & solicitud & "'  AND (ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL) order by id_solicitud "

            End If

            buscarconec = New SqlConnection(CONEXION_GASTOS)
            buscarconec.Open()

            Dim buscarsa As SqlDataAdapter
            buscarsa = New SqlDataAdapter(sql, buscarconec)
            Form2.buscardt = New DataTable
            buscarsa.Fill(Form2.buscardt)

            sql = "x_solicitud_SUMA_MONTOS '" & solicitud & "'"
            Dim buscarsa_SUMA As SqlDataAdapter
            buscarsa_SUMA = New SqlDataAdapter(sql, buscarconec)
            Form2.buscardt_SUMA = New DataTable
            buscarsa_SUMA.Fill(Form2.buscardt_SUMA)

            If Form2.buscardt_SUMA.Rows.Count = 0 Then
                Form2.SUMA_SOLICITUD = 0
            Else
                For Each ROW_SUMA In Form2.buscardt_SUMA.Rows
                    Form2.SUMA_SOLICITUD = ROW_SUMA(0)
                Next
            End If

            Form2.monto_total = CDbl(Form2.txtmonto1.Text) + CDbl(Form2.txtmonto2.Text) + CDbl(Form2.txtmonto3.Text) +
                CDbl(Form2.txtmonto4.Text) + CDbl(Form2.txtmonto5.Text) + CDbl(Form2.txtmonto6.Text) + CDbl(Form2.txtmonto7.Text) +
                CDbl(Form2.txtmonto8.Text)

            Form2.Label16.Text = "TOTAL PAGINA " & Format(Val(Form2.monto_total), "###,###,##0.00") & " TOTAL SOLICITUD " &
                Format(Val(Form2.SUMA_SOLICITUD), "###,###,##0.00")

            If Form2.buscardt.Rows.Count = 0 Then
                MsgBox("SOLICITUD NO ENCONTRADA")

            Else

                If moduio = "CAJA Y NOMINA" Then
                    For Each row As DataRow In Form2.buscardt.Rows
                        If Trim(Form2.PATIO) = Trim(row(58).ToString()) Then

                        Else
                            MsgBox("LA SOLICITUD NO PERTENECE AL PATIO")
                            Exit Sub
                        End If
                    Next

                Else

                End If

                solicitud_ = solicitud


                Form2.btnprimero.Enabled = False
                    Form2.btnanterior.Enabled = False
                    Form2.btnsiguiente.Enabled = True
                    Form2.btnultimo.Enabled = True


                    Form2.registro = Form2.registro + 1
                Form2.lblregistros.Text = Form2.registro & " DE " & Form2.buscardt.Rows.Count
                Form2.btnimpresion.Enabled = True
                'Form2.btnadd.Enabled = False
                'Form2.btnedit.Enabled = True
                'Form2.btndelete.Enabled = True
                'Form2.btncancelar.Visible = True
                'Form2.btnbuscar.Enabled = False
                Dim fila As Integer = 1

                If Form2.registro = Form2.buscardt.Rows.Count Then
                    Form2.btnsiguiente.Enabled = False
                    Form2.btnultimo.Enabled = False
                End If

                For Each row As DataRow In Form2.buscardt.Rows


                    Dim sqlcom_masgastossol As SqlCommand
                    Dim sqldr_masgastossol As SqlDataReader

                    sql = "select * from excede where (talon='' or talon2='' or talon3='' or talon4='' or talon5='' " &
                        "or talon6='' or talon7='' or talon8='' OR TALON IS NULL OR talon2 IS NULL OR talon3 IS NULL OR talon4 IS NULL OR talon5 IS NULL  " &
                        "OR talon6 IS NULL OR talon7 IS NULL OR talon8 IS NULL ) And solicitud=" & row(0) & " AND (ESTATUS NOT LIKE '%ELIMINADO%' OR ESTATUS IS NULL) "

                    sqlcom_masgastossol = New SqlCommand
                    sqlcom_masgastossol.CommandText = sql
                    sqlcom_masgastossol.Connection = buscarconec
                    sqldr_masgastossol = sqlcom_masgastossol.ExecuteReader

                    If sqldr_masgastossol.Read Then

                        Form2.btnagregargastossol.Enabled = False
                    Else
                        Form2.btnagregargastossol.Enabled = True
                    End If
                    sqldr_masgastossol.Close()


                    If fila = 1 Then
                        ' Write value of first Integer.
                        ' Console.WriteLine(row.Field(Of Integer)(0))
                        Form2.txtsolicitud.Text = row(0)
                        If IsDBNull(row(1)) Or row(1).Equals("") Then
                            Form2.txtFactura1.Text = ""
                        Else
                            Form2.txtFactura1.Text = row(1)
                        End If
                        If IsDBNull(row(2)) Or row(2).Equals("") Then
                            Form2.txtFactura2.Text = ""
                        Else
                            Form2.txtFactura2.Text = row(2)
                        End If
                        If IsDBNull(row(3)) Or row(3).Equals("") Then
                            Form2.txtFactura3.Text = ""
                        Else
                            Form2.txtFactura3.Text = row(3)
                        End If
                        If IsDBNull(row(4)) Or row(4).Equals("") Then
                            Form2.txtFactura4.Text = ""
                        Else
                            Form2.txtFactura4.Text = row(4)
                        End If
                        If IsDBNull(row(5)) Or row(5).Equals("") Then
                            Form2.txtFactura5.Text = ""
                        Else
                            Form2.txtFactura5.Text = row(5)
                        End If
                        If IsDBNull(row(6)) Or row(6).Equals("") Then
                            Form2.txtFactura6.Text = ""
                        Else
                            Form2.txtFactura6.Text = row(6)
                        End If
                        If IsDBNull(row(7)) Or row(7).Equals("") Then
                            Form2.txtFactura7.Text = ""
                        Else
                            Form2.txtFactura7.Text = row(7)
                        End If
                        If IsDBNull(row(8)) Or row(8).Equals("") Then
                            Form2.txtFactura8.Text = ""
                        Else
                            Form2.txtFactura8.Text = row(8)
                        End If
                        If IsDBNull(row(9)) Or row(9).Equals("") Then
                            Form2.txtTalon1.Text = ""
                        Else
                            Form2.txtTalon1.Text = row(9)
                        End If
                        If IsDBNull(row(10)) Or row(10).Equals("") Then
                            Form2.txtTalon2.Text = ""
                        Else
                            Form2.txtTalon2.Text = row(10)
                        End If
                        If IsDBNull(row(11)) Or row(11).Equals("") Then
                            Form2.txtTalon3.Text = ""
                        Else
                            Form2.txtTalon3.Text = row(11)
                        End If
                        If IsDBNull(row(12)) Or row(12).Equals("") Then
                            Form2.txtTalon4.Text = ""
                        Else
                            Form2.txtTalon4.Text = row(12)
                        End If
                        If IsDBNull(row(13)) Or row(13).Equals("") Then
                            Form2.txtTalon5.Text = ""
                        Else
                            Form2.txtTalon5.Text = row(13)
                        End If
                        If IsDBNull(row(14)) Or row(14).Equals("") Then
                            Form2.txtTalon6.Text = ""
                        Else
                            Form2.txtTalon6.Text = row(14)
                        End If
                        If IsDBNull(row(15)) Or row(15).Equals("") Then
                            Form2.txtTalon7.Text = ""
                        Else
                            Form2.txtTalon7.Text = row(15)
                        End If
                        If IsDBNull(row(16)) Or row(16).Equals("") Then
                            Form2.txtTalon8.Text = ""
                        Else
                            Form2.txtTalon8.Text = row(16)
                        End If
                        If IsDBNull(row(17)) Or row(17).Equals("") Then
                            Form2.ChckAUTORIZA.Checked = False
                        Else
                            Form2.ChckAUTORIZA.Checked = True
                        End If
                        If IsDBNull(row(18)) Or row(18) = 0 Then
                            Form2.txtOperador.Text = ""
                        Else
                            Form2.txtOperador.Text = row(18)
                        End If
                        If IsDBNull(row(19)) Or row(19).Equals("") Then
                            Form2.txtNombreOperador.Text = ""
                        Else
                            Form2.txtNombreOperador.Text = row(19)
                        End If
                        If IsDBNull(row(22)) Or row(22).Equals("") Then
                            Form2.cbdescripciongastos1.Text = ""
                        Else
                            'Form2.cbdescripciongastos1.SelectedValue = row(22)
                            Form2.cbdescripciongastos1.Text = row(22)
                        End If
                        If IsDBNull(row(23)) Or row(23) = 0 Then
                            Form2.txtmonto1.Text = "0.00"
                        Else
                            Form2.txtmonto1.Text = Format(Val(row(23)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(24)) Or row(24).Equals("") Then
                            Form2.txtcausa1.Text = ""
                        Else
                            Form2.txtcausa1.Text = row(24)
                        End If
                        If IsDBNull(row(25)) Or row(25).Equals("") Then
                            Form2.cbdescripciongastos2.Text = ""
                        Else
                            'Form2.cbdescripciongastos2.SelectedValue = row(25)
                            Form2.cbdescripciongastos2.Text = row(25)
                        End If
                        If IsDBNull(row(26)) Or row(26) = 0 Then
                            Form2.txtmonto2.Text = "0.00"
                        Else
                            Form2.txtmonto2.Text = Format(Val(row(26)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(27)) Or row(27).Equals("") Then
                            Form2.txtcausa2.Text = ""
                        Else
                            Form2.txtcausa2.Text = row(27)
                        End If
                        If IsDBNull(row(28)) Or row(28).Equals("") Then
                            Form2.cbdescripciongastos3.Text = ""
                        Else
                            'Form2.cbdescripciongastos3.SelectedValue = row(28)
                            Form2.cbdescripciongastos3.Text = row(28)
                        End If
                        If IsDBNull(row(29)) Or row(29) = 0 Then
                            Form2.txtmonto3.Text = "0.00"
                        Else
                            Form2.txtmonto3.Text = Format(Val(row(29)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(30)) Or row(30).Equals("") Then
                            Form2.txtcausa3.Text = ""
                        Else
                            Form2.txtcausa3.Text = row(30)
                        End If
                        If IsDBNull(row(31)) Or row(31).Equals("") Then
                            Form2.cbdescripciongastos4.Text = ""
                        Else
                            'Form2.cbdescripciongastos4.SelectedValue = row(31)
                            Form2.cbdescripciongastos4.Text = row(31)
                        End If
                        If IsDBNull(row(32)) Or row(32) = 0 Then
                            Form2.txtmonto4.Text = "0.00"
                        Else
                            Form2.txtmonto4.Text = Format(Val(row(32)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(33)) Or row(33).Equals("") Then
                            Form2.txtcausa4.Text = ""
                        Else
                            Form2.txtcausa4.Text = row(33)
                        End If
                        If IsDBNull(row(34)) Or row(34).Equals("") Then
                            Form2.cbdescripciongastos5.Text = ""
                        Else
                            'Form2.cbdescripciongastos5.SelectedValue = row(34)
                            Form2.cbdescripciongastos5.Text = row(34)
                        End If
                        If IsDBNull(row(35)) Or row(35) = 0 Then
                            Form2.txtmonto5.Text = "0.00"
                        Else
                            Form2.txtmonto5.Text = Format(Val(row(35)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(36)) Or row(36).Equals("") Then
                            Form2.txtcausa5.Text = ""
                        Else
                            Form2.txtcausa5.Text = row(36)
                        End If
                        If IsDBNull(row(37)) Or row(37).Equals("") Then
                            Form2.cbdescripciongastos6.Text = ""
                        Else
                            'Form2.cbdescripciongastos6.SelectedValue = row(37)
                            Form2.cbdescripciongastos6.Text = row(37)
                        End If
                        If IsDBNull(row(38)) Or row(38) = 0 Then
                            Form2.txtmonto6.Text = "0.00"
                        Else
                            Form2.txtmonto6.Text = Format(Val(row(38)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(39)) Or row(39).Equals("") Then
                            Form2.txtcausa6.Text = ""
                        Else
                            Form2.txtcausa6.Text = row(39)
                        End If
                        If IsDBNull(row(40)) Or row(40).Equals("") Then
                            Form2.cbdescripciongastos7.Text = ""
                        Else
                            'Form2.cbdescripciongastos7.SelectedValue = row(40)
                            Form2.cbdescripciongastos7.Text = row(40)
                        End If
                        If IsDBNull(row(41)) Or row(41) = 0 Then
                            Form2.txtmonto7.Text = "0.00"
                        Else
                            Form2.txtmonto7.Text = Format(Val(row(41)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(42)) Or row(42).Equals("") Then
                            Form2.txtcausa7.Text = ""
                        Else
                            Form2.txtcausa7.Text = row(42)
                        End If
                        If IsDBNull(row(43)) Or row(43).Equals("") Then
                            Form2.cbdescripciongastos8.Text = ""
                        Else
                            'Form2.cbdescripciongastos8.SelectedValue = row(43)
                            Form2.cbdescripciongastos8.Text = row(43)
                        End If
                        If IsDBNull(row(44)) Or row(44) = 0 Then
                            Form2.txtmonto8.Text = "0.00"
                        Else
                            Form2.txtmonto8.Text = Format(Val(row(44)), "###,###,##0.00")
                        End If
                        If IsDBNull(row(45)) Or row(45).Equals("") Then
                            Form2.txtcausa8.Text = ""
                        Else
                            Form2.txtcausa8.Text = row(45)
                        End If
                        If IsDBNull(row(46)) Then
                            Form2.txtfemision.Text = ""
                        Else
                            Form2.txtfemision.Text = Format(CDate(row(46)), "dd MMMM yyyy")
                        End If
                        If IsDBNull(row(56)) Then
                            Form2.txtfcons.Text = ""
                        Else
                            Form2.txtfcons.Text = Format(CDate(row(56)), "dd MMMM yyyy")
                        End If
                        If IsDBNull(row(57)) Then
                            Form2.txtfpago.Text = ""
                        Else
                            Form2.txtfpago.Text = Format(CDate(row(57)), "dd MMMM yyyy")
                        End If
                        If IsDBNull(row(58)) Or row(58).Equals("") Then
                            Form2.cbpatio.Text = ""
                        Else
                            Form2.cbpatio.Text = row(58)
                        End If
                        If IsDBNull(row(59)) Or row(59).Equals("") Then
                            Form2.cbdestino.Text = ""
                        Else
                            Form2.cbdestino.Text = row(59)
                        End If
                        If IsDBNull(row(60)) Or row(60).Equals("") Then
                            Form2.txtobservaciones.Text = ""
                        Else
                            Form2.txtobservaciones.Text = row(60)
                        End If
                        If IsDBNull(row(61)) Or row(61).Equals("") Then
                            Form2.txtequipo.Text = ""
                        Else
                            Form2.txtequipo.Text = row(61)
                        End If

                        ID_SOLICITUD = row(64)

                    End If
                    fila = fila + 1
                Next

                buscarconec.Close()

                If Form2.ultima_solicitud = solicitud Then
                    Form2.btnantsol.Enabled = True
                    Form2.btnprimersol.Enabled = True
                    Form2.btnsigsol.Enabled = False
                    Form2.btnultimasol.Enabled = False

                ElseIf Form2.primera_solicitud = solicitud Then
                    Form2.btnantsol.Enabled = False
                    Form2.btnprimersol.Enabled = False
                    Form2.btnsigsol.Enabled = True
                    Form2.btnultimasol.Enabled = True

                Else
                    Form2.btnantsol.Enabled = True
                    Form2.btnprimersol.Enabled = True
                    Form2.btnsigsol.Enabled = True
                    Form2.btnultimasol.Enabled = True

                End If

                Me.Hide()
                'Form2.Refresh()

            End If
        Catch ex As Exception
            buscarconec.Close()
            sql = ""
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
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

End Class