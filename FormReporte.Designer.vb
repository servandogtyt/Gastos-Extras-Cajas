<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormReporte
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbporpatio = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblporgasto = New System.Windows.Forms.Label()
        Me.cbporgasto = New System.Windows.Forms.ComboBox()
        Me.cbporchofer = New System.Windows.Forms.ComboBox()
        Me.lblporchofer = New System.Windows.Forms.Label()
        Me.cbporgasto1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbporchofer1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cbordenar = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"PAGADOS", "NO PAGADOS", "PAGADOS Y NO PAGADOS", "GASTOS EXTRAS PAGADOS", "REPORTES"})
        Me.ComboBox1.Location = New System.Drawing.Point(109, 20)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(203, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(226, 434)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 29)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "GENERAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbporpatio
        '
        Me.cbporpatio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbporpatio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbporpatio.FormattingEnabled = True
        Me.cbporpatio.Location = New System.Drawing.Point(61, 24)
        Me.cbporpatio.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbporpatio.Name = "cbporpatio"
        Me.cbporpatio.Size = New System.Drawing.Size(305, 21)
        Me.cbporpatio.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 374)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(474, 55)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "AL:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "DEL:"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(271, 18)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(194, 20)
        Me.DateTimePicker2.TabIndex = 6
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(47, 20)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(194, 20)
        Me.DateTimePicker1.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(223, 488)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 17)
        Me.Label5.TabIndex = 10
        '
        'lblporgasto
        '
        Me.lblporgasto.AutoSize = True
        Me.lblporgasto.Location = New System.Drawing.Point(70, 26)
        Me.lblporgasto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblporgasto.Name = "lblporgasto"
        Me.lblporgasto.Size = New System.Drawing.Size(68, 13)
        Me.lblporgasto.TabIndex = 11
        Me.lblporgasto.Text = "DEL GASTO"
        '
        'cbporgasto
        '
        Me.cbporgasto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbporgasto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbporgasto.FormattingEnabled = True
        Me.cbporgasto.Location = New System.Drawing.Point(142, 20)
        Me.cbporgasto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbporgasto.Name = "cbporgasto"
        Me.cbporgasto.Size = New System.Drawing.Size(203, 21)
        Me.cbporgasto.TabIndex = 12
        '
        'cbporchofer
        '
        Me.cbporchofer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbporchofer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbporchofer.FormattingEnabled = True
        Me.cbporchofer.Location = New System.Drawing.Point(98, 20)
        Me.cbporchofer.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbporchofer.Name = "cbporchofer"
        Me.cbporchofer.Size = New System.Drawing.Size(305, 21)
        Me.cbporchofer.TabIndex = 13
        '
        'lblporchofer
        '
        Me.lblporchofer.AutoSize = True
        Me.lblporchofer.Location = New System.Drawing.Point(14, 23)
        Me.lblporchofer.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblporchofer.Name = "lblporchofer"
        Me.lblporchofer.Size = New System.Drawing.Size(75, 13)
        Me.lblporchofer.TabIndex = 14
        Me.lblporchofer.Text = "DEL CHOFER"
        '
        'cbporgasto1
        '
        Me.cbporgasto1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbporgasto1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbporgasto1.FormattingEnabled = True
        Me.cbporgasto1.Location = New System.Drawing.Point(142, 45)
        Me.cbporgasto1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbporgasto1.Name = "cbporgasto1"
        Me.cbporgasto1.Size = New System.Drawing.Size(203, 21)
        Me.cbporgasto1.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(70, 50)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "AL GASTO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 51)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "AL CHOFER"
        '
        'cbporchofer1
        '
        Me.cbporchofer1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbporchofer1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbporchofer1.FormattingEnabled = True
        Me.cbporchofer1.Location = New System.Drawing.Point(98, 46)
        Me.cbporchofer1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbporchofer1.Name = "cbporchofer1"
        Me.cbporchofer1.Size = New System.Drawing.Size(305, 21)
        Me.cbporchofer1.TabIndex = 17
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbporpatio)
        Me.GroupBox2.Location = New System.Drawing.Point(52, 79)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(419, 59)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PATIO"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbporchofer1)
        Me.GroupBox3.Controls.Add(Me.cbporchofer)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.lblporchofer)
        Me.GroupBox3.Location = New System.Drawing.Point(52, 147)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(419, 81)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CHOFER"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbporgasto1)
        Me.GroupBox4.Controls.Add(Me.cbporgasto)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.lblporgasto)
        Me.GroupBox4.Location = New System.Drawing.Point(52, 237)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(419, 81)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GASTOS"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ComboBox1)
        Me.GroupBox5.Location = New System.Drawing.Point(52, 15)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox5.Size = New System.Drawing.Size(419, 56)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "REPORTE"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(42, 434)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(109, 49)
        Me.DataGridView1.TabIndex = 23
        Me.DataGridView1.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbordenar)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Location = New System.Drawing.Point(52, 325)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox6.Size = New System.Drawing.Size(419, 50)
        Me.GroupBox6.TabIndex = 24
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ORDENAR POR"
        '
        'cbordenar
        '
        Me.cbordenar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbordenar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbordenar.FormattingEnabled = True
        Me.cbordenar.Items.AddRange(New Object() {"GASTO", "OPERADOR", "SOLICITUD", "CAUSA"})
        Me.cbordenar.Location = New System.Drawing.Point(142, 17)
        Me.cbordenar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbordenar.Name = "cbordenar"
        Me.cbordenar.Size = New System.Drawing.Size(203, 21)
        Me.cbordenar.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(70, 26)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 11
        '
        'FormReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(533, 506)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FormReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents cbporpatio As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents lblporgasto As Label
    Friend WithEvents cbporgasto As ComboBox
    Friend WithEvents cbporchofer As ComboBox
    Friend WithEvents lblporchofer As Label
    Friend WithEvents cbporgasto1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbporchofer1 As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents cbordenar As ComboBox
    Friend WithEvents Label7 As Label
End Class
