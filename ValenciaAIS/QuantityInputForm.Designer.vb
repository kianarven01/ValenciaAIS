<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuantityInputForm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		lbl_quantity = New Label()
		txb_quantity = New TextBox()
		btn_OK = New Button()
		btn_cancel = New Button()
		SuspendLayout()
		' 
		' lbl_quantity
		' 
		lbl_quantity.AutoSize = True
		lbl_quantity.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_quantity.Location = New Point(162, 75)
		lbl_quantity.Name = "lbl_quantity"
		lbl_quantity.Size = New Size(142, 41)
		lbl_quantity.TabIndex = 0
		lbl_quantity.Text = "Quantity"
		' 
		' txb_quantity
		' 
		txb_quantity.Location = New Point(122, 132)
		txb_quantity.Name = "txb_quantity"
		txb_quantity.Size = New Size(213, 27)
		txb_quantity.TabIndex = 1
		' 
		' btn_OK
		' 
		btn_OK.Location = New Point(122, 279)
		btn_OK.Name = "btn_OK"
		btn_OK.Size = New Size(94, 29)
		btn_OK.TabIndex = 2
		btn_OK.Text = "OK"
		btn_OK.UseVisualStyleBackColor = True
		' 
		' btn_cancel
		' 
		btn_cancel.Location = New Point(241, 279)
		btn_cancel.Name = "btn_cancel"
		btn_cancel.Size = New Size(94, 29)
		btn_cancel.TabIndex = 3
		btn_cancel.Text = "Cancel"
		btn_cancel.UseVisualStyleBackColor = True
		' 
		' QuantityInputForm
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
		ClientSize = New Size(457, 388)
		Controls.Add(btn_cancel)
		Controls.Add(btn_OK)
		Controls.Add(txb_quantity)
		Controls.Add(lbl_quantity)
		FormBorderStyle = FormBorderStyle.FixedToolWindow
		Name = "QuantityInputForm"
		Text = "QuantityInputForm"
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents lbl_quantity As Label
	Friend WithEvents txb_quantity As TextBox
	Friend WithEvents btn_OK As Button
	Friend WithEvents btn_cancel As Button
End Class
