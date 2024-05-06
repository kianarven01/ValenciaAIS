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
		mainpanel = New Panel()
		top_panel = New Panel()
		btn_settings = New Button()
		btn_logout = New Button()
		btn_vehicle = New Button()
		top_panel.SuspendLayout()
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
		btn_product.Location = New Point(12, 619)
		btn_product.Name = "btn_product"
		btn_product.Size = New Size(169, 117)
		btn_product.TabIndex = 16
		btn_product.Text = "Product Inventory"
		btn_product.UseVisualStyleBackColor = True
		' 
		' btn_stores
		' 
		btn_stores.Location = New Point(12, 373)
		btn_stores.Name = "btn_stores"
		btn_stores.Size = New Size(169, 117)
		btn_stores.TabIndex = 17
		btn_stores.Text = "Stores"
		btn_stores.UseVisualStyleBackColor = True
		' 
		' mainpanel
		' 
		mainpanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
		mainpanel.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
		mainpanel.BorderStyle = BorderStyle.FixedSingle
		mainpanel.Location = New Point(196, 126)
		mainpanel.Name = "mainpanel"
		mainpanel.Size = New Size(1354, 733)
		mainpanel.TabIndex = 19
		' 
		' top_panel
		' 
		top_panel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		top_panel.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(255))
		top_panel.BorderStyle = BorderStyle.Fixed3D
		top_panel.Controls.Add(btn_settings)
		top_panel.Controls.Add(btn_logout)
		top_panel.Location = New Point(12, 12)
		top_panel.Name = "top_panel"
		top_panel.Size = New Size(1538, 97)
		top_panel.TabIndex = 20
		' 
		' btn_settings
		' 
		btn_settings.Anchor = AnchorStyles.Right
		btn_settings.Location = New Point(1417, 50)
		btn_settings.Name = "btn_settings"
		btn_settings.Size = New Size(94, 29)
		btn_settings.TabIndex = 1
		btn_settings.Text = "Settings"
		btn_settings.UseVisualStyleBackColor = True
		' 
		' btn_logout
		' 
		btn_logout.Anchor = AnchorStyles.Right
		btn_logout.Location = New Point(1417, 15)
		btn_logout.Name = "btn_logout"
		btn_logout.Size = New Size(94, 29)
		btn_logout.TabIndex = 0
		btn_logout.Text = "Logout"
		btn_logout.UseVisualStyleBackColor = True
		' 
		' btn_vehicle
		' 
		btn_vehicle.Location = New Point(12, 496)
		btn_vehicle.Name = "btn_vehicle"
		btn_vehicle.Size = New Size(169, 117)
		btn_vehicle.TabIndex = 21
		btn_vehicle.Text = "Load Products"
		btn_vehicle.UseVisualStyleBackColor = True
		' 
		' Form1
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(1562, 879)
		Controls.Add(btn_stores)
		Controls.Add(btn_vehicle)
		Controls.Add(top_panel)
		Controls.Add(mainpanel)
		Controls.Add(btn_product)
		Controls.Add(btn_supplier)
		Controls.Add(btn_transaction)
		FormBorderStyle = FormBorderStyle.FixedToolWindow
		Name = "Form1"
		StartPosition = FormStartPosition.CenterScreen
		Text = "Valencia AIS"
		WindowState = FormWindowState.Maximized
		top_panel.ResumeLayout(False)
		ResumeLayout(False)
	End Sub
	Friend WithEvents btn_transaction As Button
	Friend WithEvents gbx_supplier As GroupBox
	Friend WithEvents btn_supplier As Button
	Friend WithEvents btn_product As Button
	Friend WithEvents btn_stores As Button
	Friend WithEvents mainpanel As Panel
	Friend WithEvents top_panel As Panel
	Friend WithEvents btn_logout As Button
	Friend WithEvents btn_settings As Button
	Friend WithEvents btn_vehicle As Button

End Class
