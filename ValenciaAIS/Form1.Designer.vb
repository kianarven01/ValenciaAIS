<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		btn_transaction = New Button()
		btn_supplier = New Button()
		btn_product = New Button()
		btn_stores = New Button()
		btn_invoice = New Button()
		mainpanel = New Panel()
		Panel1 = New Panel()
		btn_settings = New Button()
		btn_logout = New Button()
		Panel1.SuspendLayout()
		SuspendLayout()
		' 
		' btn_transaction
		' 
		btn_transaction.Location = New Point(12, 126)
		btn_transaction.Name = "btn_transaction"
		btn_transaction.Size = New Size(169, 118)
		btn_transaction.TabIndex = 13
		btn_transaction.Text = "Transaction"
		btn_transaction.UseVisualStyleBackColor = True
		' 
		' btn_supplier
		' 
		btn_supplier.Location = New Point(12, 250)
		btn_supplier.Name = "btn_supplier"
		btn_supplier.Size = New Size(169, 117)
		btn_supplier.TabIndex = 15
		btn_supplier.Text = "Supplier"
		btn_supplier.UseVisualStyleBackColor = True
		' 
		' btn_product
		' 
		btn_product.Location = New Point(12, 373)
		btn_product.Name = "btn_product"
		btn_product.Size = New Size(169, 117)
		btn_product.TabIndex = 16
		btn_product.Text = "Product"
		btn_product.UseVisualStyleBackColor = True
		' 
		' btn_stores
		' 
		btn_stores.Location = New Point(12, 496)
		btn_stores.Name = "btn_stores"
		btn_stores.Size = New Size(169, 117)
		btn_stores.TabIndex = 17
		btn_stores.Text = "Stores"
		btn_stores.UseVisualStyleBackColor = True
		' 
		' btn_invoice
		' 
		btn_invoice.Location = New Point(12, 619)
		btn_invoice.Name = "btn_invoice"
		btn_invoice.Size = New Size(169, 117)
		btn_invoice.TabIndex = 18
		btn_invoice.Text = "Invoice"
		btn_invoice.UseVisualStyleBackColor = True
		' 
		' mainpanel
		' 
		mainpanel.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
		mainpanel.BorderStyle = BorderStyle.FixedSingle
		mainpanel.Location = New Point(196, 126)
		mainpanel.Name = "mainpanel"
		mainpanel.Size = New Size(1354, 610)
		mainpanel.TabIndex = 19
		' 
		' Panel1
		' 
		Panel1.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(255))
		Panel1.BorderStyle = BorderStyle.Fixed3D
		Panel1.Controls.Add(btn_settings)
		Panel1.Controls.Add(btn_logout)
		Panel1.Location = New Point(12, 12)
		Panel1.Name = "Panel1"
		Panel1.Size = New Size(1538, 97)
		Panel1.TabIndex = 20
		' 
		' btn_settings
		' 
		btn_settings.Location = New Point(1417, 50)
		btn_settings.Name = "btn_settings"
		btn_settings.Size = New Size(94, 29)
		btn_settings.TabIndex = 1
		btn_settings.Text = "Settings"
		btn_settings.UseVisualStyleBackColor = True
		' 
		' btn_logout
		' 
		btn_logout.Location = New Point(1417, 15)
		btn_logout.Name = "btn_logout"
		btn_logout.Size = New Size(94, 29)
		btn_logout.TabIndex = 0
		btn_logout.Text = "Logout"
		btn_logout.UseVisualStyleBackColor = True
		' 
		' Form1
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(1562, 748)
		Controls.Add(Panel1)
		Controls.Add(mainpanel)
		Controls.Add(btn_invoice)
		Controls.Add(btn_stores)
		Controls.Add(btn_product)
		Controls.Add(btn_supplier)
		Controls.Add(btn_transaction)
		Name = "Form1"
		StartPosition = FormStartPosition.CenterScreen
		Text = "Form1"
		Panel1.ResumeLayout(False)
		ResumeLayout(False)
	End Sub
	Friend WithEvents btn_transaction As Button
	Friend WithEvents gbx_supplier As GroupBox
	Friend WithEvents btn_supplier As Button
	Friend WithEvents btn_product As Button
	Friend WithEvents btn_stores As Button
	Friend WithEvents btn_invoice As Button
	Friend WithEvents mainpanel As Panel
	Friend WithEvents Panel1 As Panel
	Friend WithEvents btn_logout As Button
	Friend WithEvents btn_settings As Button

End Class
