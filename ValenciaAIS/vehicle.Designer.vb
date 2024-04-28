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
		ComboBox1 = New ComboBox()
		lbl_vehicle1 = New Label()
		lbl_model = New Label()
		lbl_make = New Label()
		txb_make = New TextBox()
		txb_model = New TextBox()
		lbl_plate = New Label()
		txb_plate = New TextBox()
		lbl_date = New Label()
		dgv_plist = New DataGridView()
		Column1 = New DataGridViewTextBoxColumn()
		Column2 = New DataGridViewTextBoxColumn()
		Column3 = New DataGridViewTextBoxColumn()
		Column4 = New DataGridViewTextBoxColumn()
		Column5 = New DataGridViewTextBoxColumn()
		DateTimePicker1 = New DateTimePicker()
		dgv_lplist = New DataGridView()
		Label1 = New Label()
		txb_search = New TextBox()
		Label2 = New Label()
		btn_generate = New Button()
		Button1 = New Button()
		TextBox1 = New TextBox()
		DataGridViewTextBoxColumn1 = New DataGridViewTextBoxColumn()
		DataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
		DataGridViewTextBoxColumn3 = New DataGridViewTextBoxColumn()
		DataGridViewTextBoxColumn4 = New DataGridViewTextBoxColumn()
		DataGridViewTextBoxColumn5 = New DataGridViewTextBoxColumn()
		CType(dgv_plist, ComponentModel.ISupportInitialize).BeginInit()
		CType(dgv_lplist, ComponentModel.ISupportInitialize).BeginInit()
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
		' ComboBox1
		' 
		ComboBox1.FormattingEnabled = True
		ComboBox1.Location = New Point(126, 218)
		ComboBox1.Name = "ComboBox1"
		ComboBox1.Size = New Size(175, 28)
		ComboBox1.TabIndex = 37
		' 
		' lbl_vehicle1
		' 
		lbl_vehicle1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_vehicle1.AutoSize = True
		lbl_vehicle1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_vehicle1.Location = New Point(29, 215)
		lbl_vehicle1.Name = "lbl_vehicle1"
		lbl_vehicle1.Size = New Size(91, 31)
		lbl_vehicle1.TabIndex = 38
		lbl_vehicle1.Text = "Vehicle"
		' 
		' lbl_model
		' 
		lbl_model.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_model.AutoSize = True
		lbl_model.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_model.Location = New Point(29, 273)
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
		lbl_make.Location = New Point(319, 215)
		lbl_make.Name = "lbl_make"
		lbl_make.Size = New Size(73, 31)
		lbl_make.TabIndex = 40
		lbl_make.Text = "Make"
		' 
		' txb_make
		' 
		txb_make.BackColor = Color.WhiteSmoke
		txb_make.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_make.Location = New Point(416, 215)
		txb_make.Name = "txb_make"
		txb_make.Size = New Size(191, 34)
		txb_make.TabIndex = 49
		' 
		' txb_model
		' 
		txb_model.BackColor = Color.WhiteSmoke
		txb_model.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_model.Location = New Point(126, 270)
		txb_model.Name = "txb_model"
		txb_model.Size = New Size(175, 34)
		txb_model.TabIndex = 50
		' 
		' lbl_plate
		' 
		lbl_plate.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_plate.AutoSize = True
		lbl_plate.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_plate.Location = New Point(319, 275)
		lbl_plate.Name = "lbl_plate"
		lbl_plate.Size = New Size(68, 31)
		lbl_plate.TabIndex = 51
		lbl_plate.Text = "Plate"
		' 
		' txb_plate
		' 
		txb_plate.BackColor = Color.WhiteSmoke
		txb_plate.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_plate.Location = New Point(416, 272)
		txb_plate.Name = "txb_plate"
		txb_plate.Size = New Size(191, 34)
		txb_plate.TabIndex = 52
		' 
		' lbl_date
		' 
		lbl_date.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_date.AutoSize = True
		lbl_date.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_date.Location = New Point(29, 320)
		lbl_date.Name = "lbl_date"
		lbl_date.Size = New Size(64, 31)
		lbl_date.TabIndex = 53
		lbl_date.Text = "Date"
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
		' DateTimePicker1
		' 
		DateTimePicker1.Location = New Point(126, 324)
		DateTimePicker1.Name = "DateTimePicker1"
		DateTimePicker1.Size = New Size(261, 27)
		DateTimePicker1.TabIndex = 56
		' 
		' dgv_lplist
		' 
		dgv_lplist.AllowUserToAddRows = False
		dgv_lplist.AllowUserToDeleteRows = False
		dgv_lplist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgv_lplist.BackgroundColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
		dgv_lplist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgv_lplist.Columns.AddRange(New DataGridViewColumn() {DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, DataGridViewTextBoxColumn3, DataGridViewTextBoxColumn4, DataGridViewTextBoxColumn5})
		dgv_lplist.Location = New Point(658, 494)
		dgv_lplist.Name = "dgv_lplist"
		dgv_lplist.ReadOnly = True
		dgv_lplist.RowHeadersVisible = False
		dgv_lplist.RowHeadersWidth = 51
		dgv_lplist.Size = New Size(637, 191)
		dgv_lplist.TabIndex = 57
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
		' Button1
		' 
		Button1.Location = New Point(1185, 691)
		Button1.Name = "Button1"
		Button1.Size = New Size(110, 28)
		Button1.TabIndex = 62
		Button1.Text = "Remove Item"
		Button1.UseVisualStyleBackColor = True
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
		' DataGridViewTextBoxColumn1
		' 
		DataGridViewTextBoxColumn1.DataPropertyName = "loaded_productID"
		DataGridViewTextBoxColumn1.HeaderText = "Load Product ID"
		DataGridViewTextBoxColumn1.MinimumWidth = 6
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
		DataGridViewTextBoxColumn1.ReadOnly = True
		' 
		' DataGridViewTextBoxColumn2
		' 
		DataGridViewTextBoxColumn2.DataPropertyName = "prod_name"
		DataGridViewTextBoxColumn2.HeaderText = "Product Name"
		DataGridViewTextBoxColumn2.MinimumWidth = 6
		DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
		DataGridViewTextBoxColumn2.ReadOnly = True
		' 
		' DataGridViewTextBoxColumn3
		' 
		DataGridViewTextBoxColumn3.DataPropertyName = "prod_price"
		DataGridViewTextBoxColumn3.HeaderText = "Price"
		DataGridViewTextBoxColumn3.MinimumWidth = 6
		DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
		DataGridViewTextBoxColumn3.ReadOnly = True
		' 
		' DataGridViewTextBoxColumn4
		' 
		DataGridViewTextBoxColumn4.DataPropertyName = "loaded_stock"
		DataGridViewTextBoxColumn4.HeaderText = "Loaded Stock"
		DataGridViewTextBoxColumn4.MinimumWidth = 6
		DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
		DataGridViewTextBoxColumn4.ReadOnly = True
		' 
		' DataGridViewTextBoxColumn5
		' 
		DataGridViewTextBoxColumn5.DataPropertyName = "prod_stock_format"
		DataGridViewTextBoxColumn5.HeaderText = "Format"
		DataGridViewTextBoxColumn5.MinimumWidth = 6
		DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
		DataGridViewTextBoxColumn5.ReadOnly = True
		' 
		' vehicle
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
		ClientSize = New Size(1354, 733)
		Controls.Add(TextBox1)
		Controls.Add(Button1)
		Controls.Add(btn_generate)
		Controls.Add(Label2)
		Controls.Add(txb_search)
		Controls.Add(Label1)
		Controls.Add(dgv_lplist)
		Controls.Add(DateTimePicker1)
		Controls.Add(dgv_plist)
		Controls.Add(lbl_date)
		Controls.Add(txb_plate)
		Controls.Add(lbl_plate)
		Controls.Add(txb_model)
		Controls.Add(txb_make)
		Controls.Add(lbl_make)
		Controls.Add(lbl_model)
		Controls.Add(lbl_vehicle1)
		Controls.Add(ComboBox1)
		Controls.Add(lbl_vehicle)
		FormBorderStyle = FormBorderStyle.None
		Name = "vehicle"
		Text = "vehicle"
		CType(dgv_plist, ComponentModel.ISupportInitialize).EndInit()
		CType(dgv_lplist, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents lbl_vehicle As Label
	Friend WithEvents ComboBox1 As ComboBox
	Friend WithEvents lbl_vehicle1 As Label
	Friend WithEvents lbl_model As Label
	Friend WithEvents lbl_make As Label
	Friend WithEvents txb_make As TextBox
	Friend WithEvents txb_model As TextBox
	Friend WithEvents lbl_plate As Label
	Friend WithEvents txb_plate As TextBox
	Friend WithEvents lbl_date As Label
	Friend WithEvents dgv_plist As DataGridView
	Friend WithEvents Column1 As DataGridViewTextBoxColumn
	Friend WithEvents Column2 As DataGridViewTextBoxColumn
	Friend WithEvents Column3 As DataGridViewTextBoxColumn
	Friend WithEvents Column4 As DataGridViewTextBoxColumn
	Friend WithEvents Column5 As DataGridViewTextBoxColumn
	Friend WithEvents DateTimePicker1 As DateTimePicker
	Friend WithEvents dgv_lplist As DataGridView
	Friend WithEvents Label1 As Label
	Friend WithEvents txb_search As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents btn_generate As Button
	Friend WithEvents Button1 As Button
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
End Class
