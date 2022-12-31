<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.x_solicitud_IMPRESIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GASTOS_EXTRASDataSet = New GASTOS_EXTRAS.GASTOS_EXTRASDataSet()
        Me.x_solicitud_IMPRESION_1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GASTOS_EXTRASDataSet1 = New GASTOS_EXTRAS.GASTOS_EXTRASDataSet1()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.x_solicitud_IMPRESIONTableAdapter = New GASTOS_EXTRAS.GASTOS_EXTRASDataSetTableAdapters.x_solicitud_IMPRESIONTableAdapter()
        Me.x_solicitud_IMPRESION_1TableAdapter = New GASTOS_EXTRAS.GASTOS_EXTRASDataSet1TableAdapters.x_solicitud_IMPRESION_1TableAdapter()
        CType(Me.x_solicitud_IMPRESIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GASTOS_EXTRASDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.x_solicitud_IMPRESION_1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GASTOS_EXTRASDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'x_solicitud_IMPRESIONBindingSource
        '
        Me.x_solicitud_IMPRESIONBindingSource.DataMember = "x_solicitud_IMPRESION"
        Me.x_solicitud_IMPRESIONBindingSource.DataSource = Me.GASTOS_EXTRASDataSet
        '
        'GASTOS_EXTRASDataSet
        '
        Me.GASTOS_EXTRASDataSet.DataSetName = "GASTOS_EXTRASDataSet"
        Me.GASTOS_EXTRASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'x_solicitud_IMPRESION_1BindingSource
        '
        Me.x_solicitud_IMPRESION_1BindingSource.DataMember = "x_solicitud_IMPRESION_1"
        Me.x_solicitud_IMPRESION_1BindingSource.DataSource = Me.GASTOS_EXTRASDataSet1
        '
        'GASTOS_EXTRASDataSet1
        '
        Me.GASTOS_EXTRASDataSet1.DataSetName = "GASTOS_EXTRASDataSet1"
        Me.GASTOS_EXTRASDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.x_solicitud_IMPRESIONBindingSource
        ReportDataSource2.Name = "DataSet2"
        ReportDataSource2.Value = Me.x_solicitud_IMPRESION_1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "GASTOS_EXTRAS.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'x_solicitud_IMPRESIONTableAdapter
        '
        Me.x_solicitud_IMPRESIONTableAdapter.ClearBeforeFill = True
        '
        'x_solicitud_IMPRESION_1TableAdapter
        '
        Me.x_solicitud_IMPRESION_1TableAdapter.ClearBeforeFill = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Form4"
        Me.Text = "Form4"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.x_solicitud_IMPRESIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GASTOS_EXTRASDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.x_solicitud_IMPRESION_1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GASTOS_EXTRASDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents x_solicitud_IMPRESIONBindingSource As BindingSource
    Friend WithEvents GASTOS_EXTRASDataSet As GASTOS_EXTRASDataSet
    Friend WithEvents x_solicitud_IMPRESION_1BindingSource As BindingSource
    Friend WithEvents GASTOS_EXTRASDataSet1 As GASTOS_EXTRASDataSet1
    Friend WithEvents x_solicitud_IMPRESIONTableAdapter As GASTOS_EXTRASDataSetTableAdapters.x_solicitud_IMPRESIONTableAdapter
    Friend WithEvents x_solicitud_IMPRESION_1TableAdapter As GASTOS_EXTRASDataSet1TableAdapters.x_solicitud_IMPRESION_1TableAdapter
End Class
