<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stores
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
		txb_search = New TextBox()
		txb_stname = New TextBox()
		btn_new = New Button()
		btn_delete = New Button()
		btn_update = New Button()
		btn_create = New Button()
		cbx_stmunicipality = New ComboBox()
		txb_stID = New TextBox()
		txb_stmanager = New TextBox()
		lbl_poduct = New Label()
		dgv_stlist = New DataGridView()
		Column1 = New DataGridViewTextBoxColumn()
		Column2 = New DataGridViewTextBoxColumn()
		Column3 = New DataGridViewTextBoxColumn()
		Column4 = New DataGridViewTextBoxColumn()
		Column5 = New DataGridViewTextBoxColumn()
		txb_stbarangay = New TextBox()
		txb_stcontact = New TextBox()
		CType(dgv_stlist, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' txb_search
		' 
		txb_search.BackColor = Color.WhiteSmoke
		txb_search.BorderStyle = BorderStyle.None
		txb_search.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_search.Location = New Point(108, 330)
		txb_search.Name = "txb_search"
		txb_search.PlaceholderText = "Search Here"
		txb_search.Size = New Size(406, 27)
		txb_search.TabIndex = 49
		' 
		' txb_stname
		' 
		txb_stname.BackColor = Color.WhiteSmoke
		txb_stname.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_stname.Location = New Point(108, 187)
		txb_stname.Name = "txb_stname"
		txb_stname.PlaceholderText = "Store Name"
		txb_stname.Size = New Size(505, 34)
		txb_stname.TabIndex = 41
		' 
		' btn_new
		' 
		btn_new.Location = New Point(746, 257)
		btn_new.Name = "btn_new"
		btn_new.Size = New Size(110, 40)
		btn_new.TabIndex = 44
		btn_new.Text = "New"
		btn_new.UseVisualStyleBackColor = True
		' 
		' btn_delete
		' 
		btn_delete.Location = New Point(1141, 257)
		btn_delete.Name = "btn_delete"
		btn_delete.Size = New Size(110, 40)
		btn_delete.TabIndex = 45
		btn_delete.Text = "Delete"
		btn_delete.UseVisualStyleBackColor = True
		' 
		' btn_update
		' 
		btn_update.Location = New Point(1010, 257)
		btn_update.Name = "btn_update"
		btn_update.Size = New Size(110, 40)
		btn_update.TabIndex = 43
		btn_update.Text = "Update"
		btn_update.UseVisualStyleBackColor = True
		' 
		' btn_create
		' 
		btn_create.Location = New Point(877, 257)
		btn_create.Name = "btn_create"
		btn_create.Size = New Size(110, 40)
		btn_create.TabIndex = 42
		btn_create.Text = "Create"
		btn_create.UseVisualStyleBackColor = True
		' 
		' cbx_stmunicipality
		' 
		cbx_stmunicipality.FormattingEnabled = True
		cbx_stmunicipality.Items.AddRange(New Object() {"Paracale", "Panganiban"})
		cbx_stmunicipality.Location = New Point(366, 251)
		cbx_stmunicipality.Name = "cbx_stmunicipality"
		cbx_stmunicipality.Size = New Size(247, 28)
		cbx_stmunicipality.TabIndex = 50
		' 
		' txb_stID
		' 
		txb_stID.BackColor = Color.WhiteSmoke
		txb_stID.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_stID.Location = New Point(108, 121)
		txb_stID.Name = "txb_stID"
		txb_stID.PlaceholderText = "Store ID"
		txb_stID.Size = New Size(505, 34)
		txb_stID.TabIndex = 48
		' 
		' txb_stmanager
		' 
		txb_stmanager.BackColor = Color.WhiteSmoke
		txb_stmanager.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_stmanager.Location = New Point(746, 121)
		txb_stmanager.Name = "txb_stmanager"
		txb_stmanager.PlaceholderText = "Store Manager"
		txb_stmanager.Size = New Size(505, 34)
		txb_stmanager.TabIndex = 39
		' 
		' lbl_poduct
		' 
		lbl_poduct.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_poduct.AutoSize = True
		lbl_poduct.Font = New Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_poduct.Location = New Point(108, 21)
		lbl_poduct.Name = "lbl_poduct"
		lbl_poduct.Size = New Size(398, 60)
		lbl_poduct.TabIndex = 46
		lbl_poduct.Text = "Store Information"
		' 
		' dgv_stlist
		' 
		dgv_stlist.AllowUserToAddRows = False
		dgv_stlist.AllowUserToDeleteRows = False
		dgv_stlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgv_stlist.BackgroundColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
		dgv_stlist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgv_stlist.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5})
		dgv_stlist.Location = New Point(108, 370)
		dgv_stlist.Name = "dgv_stlist"
		dgv_stlist.ReadOnly = True
		dgv_stlist.RowHeadersVisible = False
		dgv_stlist.RowHeadersWidth = 51
		dgv_stlist.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgv_stlist.Size = New Size(1143, 226)
		dgv_stlist.TabIndex = 47
		' 
		' Column1
		' 
		Column1.DataPropertyName = "storeID"
		Column1.HeaderText = "Store ID"
		Column1.MinimumWidth = 6
		Column1.Name = "Column1"
		Column1.ReadOnly = True
		' 
		' Column2
		' 
		Column2.DataPropertyName = "store_name"
		Column2.HeaderText = "Store Name"
		Column2.MinimumWidth = 6
		Column2.Name = "Column2"
		Column2.ReadOnly = True
		' 
		' Column3
		' 
		Column3.DataPropertyName = "store_location"
		Column3.HeaderText = "Store Location"
		Column3.MinimumWidth = 6
		Column3.Name = "Column3"
		Column3.ReadOnly = True
		' 
		' Column4
		' 
		Column4.DataPropertyName = "store_manager"
		Column4.HeaderText = "Manager"
		Column4.MinimumWidth = 6
		Column4.Name = "Column4"
		Column4.ReadOnly = True
		' 
		' Column5
		' 
		Column5.DataPropertyName = "store_contact"
		Column5.HeaderText = "Contact"
		Column5.MinimumWidth = 6
		Column5.Name = "Column5"
		Column5.ReadOnly = True
		' 
		' txb_stbarangay
		' 
		txb_stbarangay.BackColor = Color.WhiteSmoke
		txb_stbarangay.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_stbarangay.Location = New Point(108, 251)
		txb_stbarangay.Name = "txb_stbarangay"
		txb_stbarangay.PlaceholderText = "Barangay"
		txb_stbarangay.Size = New Size(252, 34)
		txb_stbarangay.TabIndex = 52
		' 
		' txb_stcontact
		' 
		txb_stcontact.BackColor = Color.WhiteSmoke
		txb_stcontact.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_stcontact.Location = New Point(746, 187)
		txb_stcontact.Name = "txb_stcontact"
		txb_stcontact.PlaceholderText = "Store Contact"
		txb_stcontact.Size = New Size(505, 34)
		txb_stcontact.TabIndex = 54
		' 
		' stores
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
		ClientSize = New Size(1336, 686)
		Controls.Add(txb_stcontact)
		Controls.Add(txb_stbarangay)
		Controls.Add(txb_search)
		Controls.Add(txb_stname)
		Controls.Add(btn_new)
		Controls.Add(btn_delete)
		Controls.Add(btn_update)
		Controls.Add(btn_create)
		Controls.Add(cbx_stmunicipality)
		Controls.Add(txb_stID)
		Controls.Add(txb_stmanager)
		Controls.Add(lbl_poduct)
		Controls.Add(dgv_stlist)
		FormBorderStyle = FormBorderStyle.FixedToolWindow
		Name = "stores"
		Text = "Stores"
		CType(dgv_stlist, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents cbx_pformat As ComboBox
	Friend WithEvents txb_search As TextBox
	Friend WithEvents txb_stname As TextBox
	Friend WithEvents btn_new As Button
	Friend WithEvents btn_delete As Button
	Friend WithEvents btn_update As Button
	Friend WithEvents btn_create As Button
	Friend WithEvents cbx_stmunicipality As ComboBox
	Friend WithEvents txb_stID As TextBox
	Friend WithEvents txb_stmanager As TextBox
	Friend WithEvents lbl_poduct As Label
	Friend WithEvents txb_pstock As TextBox
	Friend WithEvents dgv_stlist As DataGridView
	Friend WithEvents txb_stbarangay As TextBox
	Friend WithEvents txb_stcontact As TextBox
	Friend WithEvents Column1 As DataGridViewTextBoxColumn
	Friend WithEvents Column2 As DataGridViewTextBoxColumn
	Friend WithEvents Column3 As DataGridViewTextBoxColumn
	Friend WithEvents Column4 As DataGridViewTextBoxColumn
	Friend WithEvents Column5 As DataGridViewTextBoxColumn
End Class
