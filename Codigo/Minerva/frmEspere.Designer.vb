﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEspere
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlFondo = New System.Windows.Forms.Panel()
        Me.lblEspere = New System.Windows.Forms.Label()
        Me.pbFalsa = New System.Windows.Forms.ProgressBar()
        Me.pnlFondo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFondo
        '
        Me.pnlFondo.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.pnlFondo.Controls.Add(Me.pbFalsa)
        Me.pnlFondo.Controls.Add(Me.lblEspere)
        Me.pnlFondo.Location = New System.Drawing.Point(5, 5)
        Me.pnlFondo.Name = "pnlFondo"
        Me.pnlFondo.Size = New System.Drawing.Size(390, 200)
        Me.pnlFondo.TabIndex = 0
        '
        'lblEspere
        '
        Me.lblEspere.AutoSize = True
        Me.lblEspere.Font = New System.Drawing.Font("Corbel", 30.0!)
        Me.lblEspere.ForeColor = System.Drawing.Color.White
        Me.lblEspere.Location = New System.Drawing.Point(59, 40)
        Me.lblEspere.Name = "lblEspere"
        Me.lblEspere.Size = New System.Drawing.Size(282, 49)
        Me.lblEspere.TabIndex = 0
        Me.lblEspere.Text = "Espere porfavor"
        '
        'pbFalsa
        '
        Me.pbFalsa.Location = New System.Drawing.Point(48, 145)
        Me.pbFalsa.Name = "pbFalsa"
        Me.pbFalsa.Size = New System.Drawing.Size(305, 23)
        Me.pbFalsa.Step = 1
        Me.pbFalsa.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbFalsa.TabIndex = 1
        Me.pbFalsa.Value = 50
        '
        'frmEspere
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(400, 210)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlFondo)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEspere"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmEspere"
        Me.TopMost = True
        Me.pnlFondo.ResumeLayout(False)
        Me.pnlFondo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlFondo As System.Windows.Forms.Panel
    Friend WithEvents pbFalsa As System.Windows.Forms.ProgressBar
    Friend WithEvents lblEspere As System.Windows.Forms.Label
End Class
