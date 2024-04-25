<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class supplier
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
		txb_sID = New TextBox()
		txb_sname = New TextBox()
		Label1 = New Label()
		txb_scontact = New TextBox()
		dgv_slist = New DataGridView()
		Column1 = New DataGridViewTextBoxColumn()
		Column2 = New DataGridViewTextBoxColumn()
		Column3 = New DataGridViewTextBoxColumn()
		Column4 = New DataGridViewTextBoxColumn()
		txb_saddress = New TextBox()
		btn_new = New Button()
		btn_refresh = New Button()
		btn_delete = New Button()
		btn_update = New Button()
		btn_create = New Button()
		txb_search = New TextBox()
		CType(dgv_slist, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' txb_sID
		' 
		txb_sID.BackColor = Color.WhiteSmoke
		txb_sID.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_sID.Location = New Point(12, 185)
		txb_sID.Name = "txb_sID"
		txb_sID.PlaceholderText = "Supplier ID"
		txb_sID.Size = New Size(505, 34)
		txb_sID.TabIndex = 23
		' 
		' txb_sname
		' 
		txb_sname.BackColor = Color.WhiteSmoke
		txb_sname.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_sname.Location = New Point(12, 235)
		txb_sname.Name = "txb_sname"
		txb_sname.PlaceholderText = "Business Name"
		txb_sname.Size = New Size(505, 34)
		txb_sname.TabIndex = 13
		' 
		' Label1
		' 
		Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		Label1.AutoSize = True
		Label1.Font = New Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label1.Location = New Point(12, 46)
		Label1.Name = "Label1"
		Label1.Size = New Size(462, 60)
		Label1.TabIndex = 21
		Label1.Text = "Supplier Information"
		' 
		' txb_scontact
		' 
		txb_scontact.BackColor = Color.WhiteSmoke
		txb_scontact.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_scontact.Location = New Point(12, 285)
		txb_scontact.Name = "txb_scontact"
		txb_scontact.PlaceholderText = "Contact Number"
		txb_scontact.Size = New Size(505, 34)
		txb_scontact.TabIndex = 14
		' 
		' dgv_slist
		' 
		dgv_slist.AllowUserToAddRows = False
		dgv_slist.AllowUserToDeleteRows = False
		dgv_slist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgv_slist.BackgroundColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
		dgv_slist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgv_slist.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4})
		dgv_slist.Location = New Point(541, 185)
		dgv_slist.Name = "dgv_slist"
		dgv_slist.ReadOnly = True
		dgv_slist.RowHeadersVisible = False
		dgv_slist.RowHeadersWidth = 51
		dgv_slist.Size = New Size(783, 188)
		dgv_slist.TabIndex = 22
		' 
		' Column1
		' 
		Column1.DataPropertyName = "supplierID"
		Column1.HeaderText = "Supplier ID"
		Column1.MinimumWidth = 6
		Column1.Name = "Column1"
		Column1.ReadOnly = True
		' 
		' Column2
		' 
		Column2.DataPropertyName = "supp_name"
		Column2.HeaderText = "Business Name"
		Column2.MinimumWidth = 6
		Column2.Name = "Column2"
		Column2.ReadOnly = True
		' 
		' Column3
		' 
		Column3.DataPropertyName = "supp_contact"
		Column3.HeaderText = "Contact"
		Column3.MinimumWidth = 6
		Column3.Name = "Column3"
		Column3.ReadOnly = True
		' 
		' Column4
		' 
		Column4.DataPropertyName = "supp_address"
		Column4.HeaderText = "Address"
		Column4.MinimumWidth = 6
		Column4.Name = "Column4"
		Column4.ReadOnly = True
		' 
		' txb_saddress
		' 
		txb_saddress.BackColor = Color.WhiteSmoke
		txb_saddress.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_saddress.Location = New Point(12, 339)
		txb_saddress.Name = "txb_saddress"
		txb_saddress.PlaceholderText = "Address"
		txb_saddress.Size = New Size(505, 34)
		txb_saddress.TabIndex = 15
		' 
		' btn_new
		' 
		btn_new.Location = New Point(317, 420)
		btn_new.Name = "btn_new"
		btn_new.Size = New Size(200, 40)
		btn_new.TabIndex = 18
		btn_new.Text = "New"
		btn_new.UseVisualStyleBackColor = True
		' 
		' btn_refresh
		' 
		btn_refresh.Location = New Point(1119, 420)
		btn_refresh.Name = "btn_refresh"
		btn_refresh.Size = New Size(205, 40)
		btn_refresh.TabIndex = 20
		btn_refresh.Text = "Refresh"
		btn_refresh.UseVisualStyleBackColor = True
		' 
		' btn_delete
		' 
		btn_delete.Location = New Point(317, 484)
		btn_delete.Name = "btn_delete"
		btn_delete.Size = New Size(200, 40)
		btn_delete.TabIndex = 19
		btn_delete.Text = "Delete"
		btn_delete.UseVisualStyleBackColor = True
		' 
		' btn_update
		' 
		btn_update.Location = New Point(12, 484)
		btn_update.Name = "btn_update"
		btn_update.Size = New Size(200, 40)
		btn_update.TabIndex = 17
		btn_update.Text = "Update"
		btn_update.UseVisualStyleBackColor = True
		' 
		' btn_create
		' 
		btn_create.Location = New Point(12, 420)
		btn_create.Name = "btn_create"
		btn_create.Size = New Size(200, 40)
		btn_create.TabIndex = 16
		btn_create.Text = "Create"
		btn_create.UseVisualStyleBackColor = True
		' 
		' txb_search
		' 
		txb_search.BackColor = Color.WhiteSmoke
		txb_search.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_search.Location = New Point(918, 145)
		txb_search.Name = "txb_search"
		txb_search.PlaceholderText = "Search Here"
		txb_search.Size = New Size(406, 34)
		txb_search.TabIndex = 24
		' 
		' supplier
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
		ClientSize = New Size(1336, 563)
		Controls.Add(txb_search)
		Controls.Add(txb_sID)
		Controls.Add(txb_sname)
		Controls.Add(Label1)
		Controls.Add(txb_scontact)
		Controls.Add(dgv_slist)
		Controls.Add(txb_saddress)
		Controls.Add(btn_new)
		Controls.Add(btn_refresh)
		Controls.Add(btn_delete)
		Controls.Add(btn_update)
		Controls.Add(btn_create)
		FormBorderStyle = FormBorderStyle.None
		Name = "supplier"
		Text = "supplier"
		CType(dgv_slist, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents txb_sID As TextBox
	Friend WithEvents txb_sname As TextBox
	Friend WithEvents Label1 As Label
	Friend WithEvents txb_scontact As TextBox
	Friend WithEvents dgv_slist As DataGridView
	Friend WithEvents Column1 As DataGridViewTextBoxColumn
	Friend WithEvents Column2 As DataGridViewTextBoxColumn
	Friend WithEvents Column3 As DataGridViewTextBoxColumn
	Friend WithEvents Column4 As DataGridViewTextBoxColumn
	Friend WithEvents txb_saddress As TextBox
	Friend WithEvents btn_new As Button
	Friend WithEvents btn_refresh As Button
	Friend WithEvents btn_delete As Button
	Friend WithEvents btn_update As Button
	Friend WithEvents btn_create As Button
	Friend WithEvents txb_search As TextBox
End Class
