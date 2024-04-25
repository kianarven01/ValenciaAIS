<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class product
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
		txb_pID = New TextBox()
		txb_pprice = New TextBox()
		lbl_poduct = New Label()
		txb_pstock = New TextBox()
		dgv_plist = New DataGridView()
		Column1 = New DataGridViewTextBoxColumn()
		Column2 = New DataGridViewTextBoxColumn()
		Column3 = New DataGridViewTextBoxColumn()
		Column4 = New DataGridViewTextBoxColumn()
		Column5 = New DataGridViewTextBoxColumn()
		txb_search = New TextBox()
		txb_pname = New TextBox()
		btn_new = New Button()
		btn_delete = New Button()
		btn_update = New Button()
		btn_create = New Button()
		cbx_pgroup = New ComboBox()
		cbx_pformat = New ComboBox()
		CType(dgv_plist, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' txb_pID
		' 
		txb_pID.BackColor = Color.WhiteSmoke
		txb_pID.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_pID.Location = New Point(109, 123)
		txb_pID.Name = "txb_pID"
		txb_pID.PlaceholderText = "Product ID"
		txb_pID.Size = New Size(505, 34)
		txb_pID.TabIndex = 35
		' 
		' txb_pprice
		' 
		txb_pprice.BackColor = Color.WhiteSmoke
		txb_pprice.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_pprice.Location = New Point(747, 123)
		txb_pprice.Name = "txb_pprice"
		txb_pprice.PlaceholderText = "Price"
		txb_pprice.Size = New Size(505, 34)
		txb_pprice.TabIndex = 25
		' 
		' lbl_poduct
		' 
		lbl_poduct.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_poduct.AutoSize = True
		lbl_poduct.Font = New Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_poduct.Location = New Point(109, 23)
		lbl_poduct.Name = "lbl_poduct"
		lbl_poduct.Size = New Size(452, 60)
		lbl_poduct.TabIndex = 33
		lbl_poduct.Text = "Product Information"
		' 
		' txb_pstock
		' 
		txb_pstock.BackColor = Color.WhiteSmoke
		txb_pstock.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_pstock.Location = New Point(747, 189)
		txb_pstock.Name = "txb_pstock"
		txb_pstock.PlaceholderText = "Product Stock"
		txb_pstock.Size = New Size(267, 34)
		txb_pstock.TabIndex = 26
		' 
		' dgv_plist
		' 
		dgv_plist.AllowUserToAddRows = False
		dgv_plist.AllowUserToDeleteRows = False
		dgv_plist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgv_plist.BackgroundColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
		dgv_plist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgv_plist.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5})
		dgv_plist.Location = New Point(109, 372)
		dgv_plist.Name = "dgv_plist"
		dgv_plist.ReadOnly = True
		dgv_plist.RowHeadersVisible = False
		dgv_plist.RowHeadersWidth = 51
		dgv_plist.Size = New Size(1143, 226)
		dgv_plist.TabIndex = 34
		' 
		' Column1
		' 
		Column1.DataPropertyName = "productID"
		Column1.HeaderText = "Product ID"
		Column1.MinimumWidth = 6
		Column1.Name = "Column1"
		Column1.ReadOnly = True
		' 
		' Column2
		' 
		Column2.DataPropertyName = "prod_name"
		Column2.HeaderText = "Product Name"
		Column2.MinimumWidth = 6
		Column2.Name = "Column2"
		Column2.ReadOnly = True
		' 
		' Column3
		' 
		Column3.DataPropertyName = "prod_price"
		Column3.HeaderText = "Price"
		Column3.MinimumWidth = 6
		Column3.Name = "Column3"
		Column3.ReadOnly = True
		' 
		' Column4
		' 
		Column4.DataPropertyName = "prod_stock"
		Column4.HeaderText = "Stock"
		Column4.MinimumWidth = 6
		Column4.Name = "Column4"
		Column4.ReadOnly = True
		' 
		' Column5
		' 
		Column5.DataPropertyName = "prod_stock_format"
		Column5.HeaderText = "Format"
		Column5.MinimumWidth = 6
		Column5.Name = "Column5"
		Column5.ReadOnly = True
		' 
		' txb_search
		' 
		txb_search.BackColor = Color.WhiteSmoke
		txb_search.BorderStyle = BorderStyle.None
		txb_search.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_search.Location = New Point(109, 332)
		txb_search.Name = "txb_search"
		txb_search.PlaceholderText = "Search Here"
		txb_search.Size = New Size(406, 27)
		txb_search.TabIndex = 36
		' 
		' txb_pname
		' 
		txb_pname.BackColor = Color.WhiteSmoke
		txb_pname.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_pname.Location = New Point(109, 189)
		txb_pname.Name = "txb_pname"
		txb_pname.PlaceholderText = "Product Name"
		txb_pname.Size = New Size(505, 34)
		txb_pname.TabIndex = 27
		' 
		' btn_new
		' 
		btn_new.Location = New Point(747, 259)
		btn_new.Name = "btn_new"
		btn_new.Size = New Size(110, 40)
		btn_new.TabIndex = 30
		btn_new.Text = "New"
		btn_new.UseVisualStyleBackColor = True
		' 
		' btn_delete
		' 
		btn_delete.Location = New Point(1142, 259)
		btn_delete.Name = "btn_delete"
		btn_delete.Size = New Size(110, 40)
		btn_delete.TabIndex = 31
		btn_delete.Text = "Delete"
		btn_delete.UseVisualStyleBackColor = True
		' 
		' btn_update
		' 
		btn_update.Location = New Point(1011, 259)
		btn_update.Name = "btn_update"
		btn_update.Size = New Size(110, 40)
		btn_update.TabIndex = 29
		btn_update.Text = "Update"
		btn_update.UseVisualStyleBackColor = True
		' 
		' btn_create
		' 
		btn_create.Location = New Point(878, 259)
		btn_create.Name = "btn_create"
		btn_create.Size = New Size(110, 40)
		btn_create.TabIndex = 28
		btn_create.Text = "Create"
		btn_create.UseVisualStyleBackColor = True
		' 
		' cbx_pgroup
		' 
		cbx_pgroup.FormattingEnabled = True
		cbx_pgroup.Location = New Point(109, 259)
		cbx_pgroup.Name = "cbx_pgroup"
		cbx_pgroup.Size = New Size(505, 28)
		cbx_pgroup.TabIndex = 37
		' 
		' cbx_pformat
		' 
		cbx_pformat.BackColor = Color.White
		cbx_pformat.FormattingEnabled = True
		cbx_pformat.Items.AddRange(New Object() {"KG", "QTY"})
		cbx_pformat.Location = New Point(1037, 189)
		cbx_pformat.Name = "cbx_pformat"
		cbx_pformat.Size = New Size(215, 28)
		cbx_pformat.TabIndex = 38
		' 
		' product
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
		ClientSize = New Size(1354, 610)
		Controls.Add(cbx_pformat)
		Controls.Add(cbx_pgroup)
		Controls.Add(txb_pID)
		Controls.Add(txb_pprice)
		Controls.Add(lbl_poduct)
		Controls.Add(txb_pstock)
		Controls.Add(dgv_plist)
		Controls.Add(txb_search)
		Controls.Add(txb_pname)
		Controls.Add(btn_new)
		Controls.Add(btn_delete)
		Controls.Add(btn_update)
		Controls.Add(btn_create)
		FormBorderStyle = FormBorderStyle.None
		Name = "product"
		Text = "product"
		CType(dgv_plist, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents txb_pID As TextBox
	Friend WithEvents txb_pprice As TextBox
	Friend WithEvents lbl_poduct As Label
	Friend WithEvents txb_pstock As TextBox
	Friend WithEvents dgv_plist As DataGridView
	Friend WithEvents txb_search As TextBox
	Friend WithEvents txb_pname As TextBox
	Friend WithEvents btn_new As Button
	Friend WithEvents btn_delete As Button
	Friend WithEvents btn_update As Button
	Friend WithEvents btn_create As Button
	Friend WithEvents cbx_pgroup As ComboBox
	Friend WithEvents cbx_pformat As ComboBox
	Friend WithEvents Column1 As DataGridViewTextBoxColumn
	Friend WithEvents Column2 As DataGridViewTextBoxColumn
	Friend WithEvents Column3 As DataGridViewTextBoxColumn
	Friend WithEvents Column4 As DataGridViewTextBoxColumn
	Friend WithEvents Column5 As DataGridViewTextBoxColumn


End Class
