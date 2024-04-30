<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vehicle
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
		lbl_vehicle = New Label()
		cbx_vehicle = New ComboBox()
		lbl_vehicle1 = New Label()
		lbl_model = New Label()
		lbl_make = New Label()
		txb_make = New TextBox()
		txb_model = New TextBox()
		lbl_plate = New Label()
		txb_plate = New TextBox()
		dgv_plist = New DataGridView()
		Column1 = New DataGridViewTextBoxColumn()
		Column2 = New DataGridViewTextBoxColumn()
		Column3 = New DataGridViewTextBoxColumn()
		Column4 = New DataGridViewTextBoxColumn()
		Column5 = New DataGridViewTextBoxColumn()
		dgv_lplist = New DataGridView()
		loaded_productID = New DataGridViewTextBoxColumn()
		prod_name = New DataGridViewTextBoxColumn()
		prod_price = New DataGridViewTextBoxColumn()
		loaded_stock = New DataGridViewTextBoxColumn()
		prod_stock_format = New DataGridViewTextBoxColumn()
		Label1 = New Label()
		txb_search = New TextBox()
		Label2 = New Label()
		btn_generate = New Button()
		btn_remove_item = New Button()
		TextBox1 = New TextBox()
		btn_new = New Button()
		btn_delete = New Button()
		btn_update = New Button()
		btn_create = New Button()
		dgv_vlist = New DataGridView()
		DataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
		DataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
		DataGridViewTextBoxColumn3 = New DataGridViewTextBoxColumn()
		DataGridViewTextBoxColumn4 = New DataGridViewTextBoxColumn()
		TextBox2 = New TextBox()
		Label3 = New Label()
		txb_vhcode = New TextBox()
		CType(dgv_plist, ComponentModel.ISupportInitialize).BeginInit()
		CType(dgv_lplist, ComponentModel.ISupportInitialize).BeginInit()
		CType(dgv_vlist, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' lbl_vehicle
		' 
		lbl_vehicle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_vehicle.AutoSize = True
		lbl_vehicle.Font = New Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_vehicle.Location = New Point(36, 34)
		lbl_vehicle.Name = "lbl_vehicle"
		lbl_vehicle.Size = New Size(791, 60)
		lbl_vehicle.TabIndex = 34
		lbl_vehicle.Text = "Vehicle Product Loading Information"
		' 
		' cbx_vehicle
		' 
		cbx_vehicle.FormattingEnabled = True
		cbx_vehicle.Location = New Point(130, 654)
		cbx_vehicle.Name = "cbx_vehicle"
		cbx_vehicle.Size = New Size(175, 28)
		cbx_vehicle.TabIndex = 37
		' 
		' lbl_vehicle1
		' 
		lbl_vehicle1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_vehicle1.AutoSize = True
		lbl_vehicle1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_vehicle1.Location = New Point(33, 185)
		lbl_vehicle1.Name = "lbl_vehicle1"
		lbl_vehicle1.Size = New Size(151, 31)
		lbl_vehicle1.TabIndex = 38
		lbl_vehicle1.Text = "Vehicle Code"
		' 
		' lbl_model
		' 
		lbl_model.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_model.AutoSize = True
		lbl_model.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_model.Location = New Point(33, 243)
		lbl_model.Name = "lbl_model"
		lbl_model.Size = New Size(83, 31)
		lbl_model.TabIndex = 39
		lbl_model.Text = "Model"
		' 
		' lbl_make
		' 
		lbl_make.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_make.AutoSize = True
		lbl_make.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_make.Location = New Point(323, 185)
		lbl_make.Name = "lbl_make"
		lbl_make.Size = New Size(73, 31)
		lbl_make.TabIndex = 40
		lbl_make.Text = "Make"
		' 
		' txb_make
		' 
		txb_make.BackColor = Color.WhiteSmoke
		txb_make.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_make.Location = New Point(420, 185)
		txb_make.Name = "txb_make"
		txb_make.Size = New Size(191, 34)
		txb_make.TabIndex = 49
		' 
		' txb_model
		' 
		txb_model.BackColor = Color.WhiteSmoke
		txb_model.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_model.Location = New Point(130, 240)
		txb_model.Name = "txb_model"
		txb_model.Size = New Size(175, 34)
		txb_model.TabIndex = 50
		' 
		' lbl_plate
		' 
		lbl_plate.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_plate.AutoSize = True
		lbl_plate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_plate.Location = New Point(323, 245)
		lbl_plate.Name = "lbl_plate"
		lbl_plate.Size = New Size(68, 31)
		lbl_plate.TabIndex = 51
		lbl_plate.Text = "Plate"
		' 
		' txb_plate
		' 
		txb_plate.BackColor = Color.WhiteSmoke
		txb_plate.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_plate.Location = New Point(420, 242)
		txb_plate.Name = "txb_plate"
		txb_plate.Size = New Size(191, 34)
		txb_plate.TabIndex = 52
		' 
		' dgv_plist
		' 
		dgv_plist.AllowUserToAddRows = False
		dgv_plist.AllowUserToDeleteRows = False
		dgv_plist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgv_plist.BackgroundColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
		dgv_plist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgv_plist.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5})
		dgv_plist.Location = New Point(658, 218)
		dgv_plist.Name = "dgv_plist"
		dgv_plist.ReadOnly = True
		dgv_plist.RowHeadersVisible = False
		dgv_plist.RowHeadersWidth = 51
		dgv_plist.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgv_plist.Size = New Size(637, 191)
		dgv_plist.TabIndex = 55
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
		' dgv_lplist
		' 
		dgv_lplist.AllowUserToAddRows = False
		dgv_lplist.AllowUserToDeleteRows = False
		dgv_lplist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgv_lplist.BackgroundColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
		dgv_lplist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgv_lplist.Columns.AddRange(New DataGridViewColumn() {loaded_productID, prod_name, prod_price, loaded_stock, prod_stock_format})
		dgv_lplist.Location = New Point(658, 494)
		dgv_lplist.Name = "dgv_lplist"
		dgv_lplist.ReadOnly = True
		dgv_lplist.RowHeadersVisible = False
		dgv_lplist.RowHeadersWidth = 51
		dgv_lplist.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgv_lplist.Size = New Size(637, 191)
		dgv_lplist.TabIndex = 57
		' 
		' loaded_productID
		' 
		loaded_productID.DataPropertyName = "loaded_productID"
		loaded_productID.HeaderText = "Load Product ID"
		loaded_productID.MinimumWidth = 6
		loaded_productID.Name = "loaded_productID"
		loaded_productID.ReadOnly = True
		' 
		' prod_name
		' 
		prod_name.DataPropertyName = "prod_name"
		prod_name.HeaderText = "Product Name"
		prod_name.MinimumWidth = 6
		prod_name.Name = "prod_name"
		prod_name.ReadOnly = True
		' 
		' prod_price
		' 
		prod_price.DataPropertyName = "prod_price"
		prod_price.HeaderText = "Price"
		prod_price.MinimumWidth = 6
		prod_price.Name = "prod_price"
		prod_price.ReadOnly = True
		' 
		' loaded_stock
		' 
		loaded_stock.DataPropertyName = "loaded_stock"
		loaded_stock.HeaderText = "Loaded Stock"
		loaded_stock.MinimumWidth = 6
		loaded_stock.Name = "loaded_stock"
		loaded_stock.ReadOnly = True
		' 
		' prod_stock_format
		' 
		prod_stock_format.DataPropertyName = "prod_stock_format"
		prod_stock_format.HeaderText = "Format"
		prod_stock_format.MinimumWidth = 6
		prod_stock_format.Name = "prod_stock_format"
		prod_stock_format.ReadOnly = True
		' 
		' Label1
		' 
		Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		Label1.AutoSize = True
		Label1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label1.Location = New Point(658, 151)
		Label1.Name = "Label1"
		Label1.Size = New Size(268, 31)
		Label1.TabIndex = 58
		Label1.Text = "Product Available Stock"
		' 
		' txb_search
		' 
		txb_search.BackColor = Color.WhiteSmoke
		txb_search.BorderStyle = BorderStyle.None
		txb_search.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_search.Location = New Point(658, 185)
		txb_search.Name = "txb_search"
		txb_search.PlaceholderText = "Search Here"
		txb_search.Size = New Size(406, 27)
		txb_search.TabIndex = 59
		' 
		' Label2
		' 
		Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		Label2.AutoSize = True
		Label2.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.Location = New Point(658, 427)
		Label2.Name = "Label2"
		Label2.Size = New Size(193, 31)
		Label2.TabIndex = 60
		Label2.Text = "Loaded Products"
		' 
		' btn_generate
		' 
		btn_generate.Location = New Point(1185, 415)
		btn_generate.Name = "btn_generate"
		btn_generate.Size = New Size(110, 28)
		btn_generate.TabIndex = 61
		btn_generate.Text = "Load Product"
		btn_generate.UseVisualStyleBackColor = True
		' 
		' btn_remove_item
		' 
		btn_remove_item.Location = New Point(1185, 691)
		btn_remove_item.Name = "btn_remove_item"
		btn_remove_item.Size = New Size(110, 28)
		btn_remove_item.TabIndex = 62
		btn_remove_item.Text = "Remove Item"
		btn_remove_item.UseVisualStyleBackColor = True
		' 
		' TextBox1
		' 
		TextBox1.BackColor = Color.WhiteSmoke
		TextBox1.BorderStyle = BorderStyle.None
		TextBox1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		TextBox1.Location = New Point(658, 461)
		TextBox1.Name = "TextBox1"
		TextBox1.PlaceholderText = "Search Here"
		TextBox1.Size = New Size(406, 27)
		TextBox1.TabIndex = 63
		' 
		' btn_new
		' 
		btn_new.Location = New Point(33, 538)
		btn_new.Name = "btn_new"
		btn_new.Size = New Size(139, 40)
		btn_new.TabIndex = 66
		btn_new.Text = "New"
		btn_new.UseVisualStyleBackColor = True
		' 
		' btn_delete
		' 
		btn_delete.Location = New Point(472, 538)
		btn_delete.Name = "btn_delete"
		btn_delete.Size = New Size(139, 40)
		btn_delete.TabIndex = 67
		btn_delete.Text = "Delete"
		btn_delete.UseVisualStyleBackColor = True
		' 
		' btn_update
		' 
		btn_update.Location = New Point(327, 538)
		btn_update.Name = "btn_update"
		btn_update.Size = New Size(139, 40)
		btn_update.TabIndex = 65
		btn_update.Text = "Update"
		btn_update.UseVisualStyleBackColor = True
		' 
		' btn_create
		' 
		btn_create.Location = New Point(178, 538)
		btn_create.Name = "btn_create"
		btn_create.Size = New Size(143, 40)
		btn_create.TabIndex = 64
		btn_create.Text = "Create"
		btn_create.UseVisualStyleBackColor = True
		' 
		' dgv_vlist
		' 
		dgv_vlist.AllowUserToAddRows = False
		dgv_vlist.AllowUserToDeleteRows = False
		dgv_vlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgv_vlist.BackgroundColor = Color.FromArgb(CByte(255), CByte(255), CByte(128))
		dgv_vlist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgv_vlist.Columns.AddRange(New DataGridViewColumn() {DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, DataGridViewTextBoxColumn3, DataGridViewTextBoxColumn4})
		dgv_vlist.Location = New Point(33, 341)
		dgv_vlist.Name = "dgv_vlist"
		dgv_vlist.ReadOnly = True
		dgv_vlist.RowHeadersVisible = False
		dgv_vlist.RowHeadersWidth = 51
		dgv_vlist.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgv_vlist.Size = New Size(578, 191)
		dgv_vlist.TabIndex = 68
		' 
		' DataGridViewTextBoxColumn1
		' 
		DataGridViewTextBoxColumn1.DataPropertyName = "vehicle_code"
		DataGridViewTextBoxColumn1.HeaderText = "Vehicle Code"
		DataGridViewTextBoxColumn1.MinimumWidth = 6
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
		DataGridViewTextBoxColumn1.ReadOnly = True
		' 
		' DataGridViewTextBoxColumn2
		' 
		DataGridViewTextBoxColumn2.DataPropertyName = "make"
		DataGridViewTextBoxColumn2.HeaderText = "Make"
		DataGridViewTextBoxColumn2.MinimumWidth = 6
		DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
		DataGridViewTextBoxColumn2.ReadOnly = True
		' 
		' DataGridViewTextBoxColumn3
		' 
		DataGridViewTextBoxColumn3.DataPropertyName = "model"
		DataGridViewTextBoxColumn3.HeaderText = "Model"
		DataGridViewTextBoxColumn3.MinimumWidth = 6
		DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
		DataGridViewTextBoxColumn3.ReadOnly = True
		' 
		' DataGridViewTextBoxColumn4
		' 
		DataGridViewTextBoxColumn4.DataPropertyName = "plate"
		DataGridViewTextBoxColumn4.HeaderText = "Plate"
		DataGridViewTextBoxColumn4.MinimumWidth = 6
		DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
		DataGridViewTextBoxColumn4.ReadOnly = True
		' 
		' TextBox2
		' 
		TextBox2.BackColor = Color.WhiteSmoke
		TextBox2.BorderStyle = BorderStyle.None
		TextBox2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		TextBox2.Location = New Point(33, 308)
		TextBox2.Name = "TextBox2"
		TextBox2.PlaceholderText = "Search Vehicle"
		TextBox2.Size = New Size(406, 27)
		TextBox2.TabIndex = 69
		' 
		' Label3
		' 
		Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		Label3.AutoSize = True
		Label3.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label3.Location = New Point(33, 654)
		Label3.Name = "Label3"
		Label3.Size = New Size(91, 31)
		Label3.TabIndex = 70
		Label3.Text = "Vehicle"
		' 
		' txb_vhcode
		' 
		txb_vhcode.BackColor = Color.WhiteSmoke
		txb_vhcode.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_vhcode.Location = New Point(190, 184)
		txb_vhcode.Name = "txb_vhcode"
		txb_vhcode.Size = New Size(115, 34)
		txb_vhcode.TabIndex = 71
		' 
		' vehicle
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
		ClientSize = New Size(1354, 733)
		Controls.Add(txb_vhcode)
		Controls.Add(Label3)
		Controls.Add(TextBox2)
		Controls.Add(dgv_vlist)
		Controls.Add(btn_new)
		Controls.Add(btn_delete)
		Controls.Add(btn_update)
		Controls.Add(btn_create)
		Controls.Add(TextBox1)
		Controls.Add(btn_remove_item)
		Controls.Add(btn_generate)
		Controls.Add(Label2)
		Controls.Add(txb_search)
		Controls.Add(Label1)
		Controls.Add(dgv_lplist)
		Controls.Add(dgv_plist)
		Controls.Add(txb_plate)
		Controls.Add(lbl_plate)
		Controls.Add(txb_model)
		Controls.Add(txb_make)
		Controls.Add(lbl_make)
		Controls.Add(lbl_model)
		Controls.Add(lbl_vehicle1)
		Controls.Add(cbx_vehicle)
		Controls.Add(lbl_vehicle)
		FormBorderStyle = FormBorderStyle.None
		Name = "vehicle"
		Text = "vehicle"
		CType(dgv_plist, ComponentModel.ISupportInitialize).EndInit()
		CType(dgv_lplist, ComponentModel.ISupportInitialize).EndInit()
		CType(dgv_vlist, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents lbl_vehicle As Label
	Friend WithEvents cbx_vehicle As ComboBox
	Friend WithEvents lbl_vehicle1 As Label
	Friend WithEvents lbl_model As Label
	Friend WithEvents lbl_make As Label
	Friend WithEvents txb_make As TextBox
	Friend WithEvents txb_model As TextBox
	Friend WithEvents lbl_plate As Label
	Friend WithEvents txb_plate As TextBox
	Friend WithEvents dgv_plist As DataGridView
	Friend WithEvents Column1 As DataGridViewTextBoxColumn
	Friend WithEvents Column2 As DataGridViewTextBoxColumn
	Friend WithEvents Column3 As DataGridViewTextBoxColumn
	Friend WithEvents Column4 As DataGridViewTextBoxColumn
	Friend WithEvents Column5 As DataGridViewTextBoxColumn
	Friend WithEvents dgv_lplist As DataGridView
	Friend WithEvents Label1 As Label
	Friend WithEvents txb_search As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents btn_generate As Button
	Friend WithEvents btn_remove_item As Button
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents loaded_productID As DataGridViewTextBoxColumn
	Friend WithEvents prod_name As DataGridViewTextBoxColumn
	Friend WithEvents prod_price As DataGridViewTextBoxColumn
	Friend WithEvents loaded_stock As DataGridViewTextBoxColumn
	Friend WithEvents prod_stock_format As DataGridViewTextBoxColumn
	Friend WithEvents btn_new As Button
	Friend WithEvents btn_delete As Button
	Friend WithEvents btn_update As Button
	Friend WithEvents btn_create As Button
	Friend WithEvents dgv_vlist As DataGridView
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents txb_vhcode As TextBox
	Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
End Class
