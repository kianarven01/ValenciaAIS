﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class transaction
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
		lbl_transaction = New Label()
		cbx_stname = New ComboBox()
		lbl_store = New Label()
		txb_search = New TextBox()
		lbl_payment = New Label()
		cbx_payment = New ComboBox()
		btn_stadd = New Button()
		lbl_date = New Label()
		txb_total = New TextBox()
		lbl_total = New Label()
		btn_addItem = New Button()
		btn_generate = New Button()
		btn_removeItem = New Button()
		cbx_vehicle = New ComboBox()
		lbl_vehicle = New Label()
		dgv_lplist = New DataGridView()
		loaded_productID = New DataGridViewTextBoxColumn()
		prod_name = New DataGridViewTextBoxColumn()
		prod_price = New DataGridViewTextBoxColumn()
		loaded_stock = New DataGridViewTextBoxColumn()
		prod_stock_format = New DataGridViewTextBoxColumn()
		ColumnHeader1 = New ColumnHeader()
		ColumnHeader2 = New ColumnHeader()
		ColumnHeader3 = New ColumnHeader()
		ColumnHeader4 = New ColumnHeader()
		lsv_transaction = New ListView()
		dtp_transaction = New DateTimePicker()
		CType(dgv_lplist, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' lbl_transaction
		' 
		lbl_transaction.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_transaction.AutoSize = True
		lbl_transaction.Font = New Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_transaction.Location = New Point(46, 10)
		lbl_transaction.Name = "lbl_transaction"
		lbl_transaction.Size = New Size(265, 60)
		lbl_transaction.TabIndex = 22
		lbl_transaction.Text = "Transaction"
		' 
		' cbx_stname
		' 
		cbx_stname.FormattingEnabled = True
		cbx_stname.Location = New Point(170, 100)
		cbx_stname.Name = "cbx_stname"
		cbx_stname.Size = New Size(367, 28)
		cbx_stname.TabIndex = 24
		' 
		' lbl_store
		' 
		lbl_store.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_store.AutoSize = True
		lbl_store.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_store.Location = New Point(51, 97)
		lbl_store.Name = "lbl_store"
		lbl_store.Size = New Size(70, 31)
		lbl_store.TabIndex = 25
		lbl_store.Text = "Store"
		' 
		' txb_search
		' 
		txb_search.BackColor = Color.WhiteSmoke
		txb_search.BorderStyle = BorderStyle.None
		txb_search.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_search.Location = New Point(46, 267)
		txb_search.Name = "txb_search"
		txb_search.PlaceholderText = "Search Product"
		txb_search.Size = New Size(302, 27)
		txb_search.TabIndex = 38
		' 
		' lbl_payment
		' 
		lbl_payment.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_payment.AutoSize = True
		lbl_payment.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_payment.Location = New Point(51, 145)
		lbl_payment.Name = "lbl_payment"
		lbl_payment.Size = New Size(107, 31)
		lbl_payment.TabIndex = 41
		lbl_payment.Text = "Payment"
		' 
		' cbx_payment
		' 
		cbx_payment.FormattingEnabled = True
		cbx_payment.Items.AddRange(New Object() {"Cash", "Gcash"})
		cbx_payment.Location = New Point(170, 145)
		cbx_payment.Name = "cbx_payment"
		cbx_payment.Size = New Size(367, 28)
		cbx_payment.TabIndex = 40
		' 
		' btn_stadd
		' 
		btn_stadd.Location = New Point(543, 100)
		btn_stadd.Name = "btn_stadd"
		btn_stadd.Size = New Size(133, 28)
		btn_stadd.TabIndex = 42
		btn_stadd.Text = "Insert New Store"
		btn_stadd.UseVisualStyleBackColor = True
		' 
		' lbl_date
		' 
		lbl_date.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_date.AutoSize = True
		lbl_date.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_date.Location = New Point(51, 188)
		lbl_date.Name = "lbl_date"
		lbl_date.Size = New Size(64, 31)
		lbl_date.TabIndex = 44
		lbl_date.Text = "Date"
		' 
		' txb_total
		' 
		txb_total.BackColor = Color.WhiteSmoke
		txb_total.BorderStyle = BorderStyle.None
		txb_total.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		txb_total.Location = New Point(908, 526)
		txb_total.Name = "txb_total"
		txb_total.Size = New Size(160, 27)
		txb_total.TabIndex = 45
		' 
		' lbl_total
		' 
		lbl_total.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_total.AutoSize = True
		lbl_total.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_total.Location = New Point(835, 524)
		lbl_total.Name = "lbl_total"
		lbl_total.Size = New Size(67, 31)
		lbl_total.TabIndex = 46
		lbl_total.Text = "Total"
		' 
		' btn_addItem
		' 
		btn_addItem.Location = New Point(653, 520)
		btn_addItem.Name = "btn_addItem"
		btn_addItem.Size = New Size(133, 28)
		btn_addItem.TabIndex = 47
		btn_addItem.Text = "Add Item"
		btn_addItem.UseVisualStyleBackColor = True
		' 
		' btn_generate
		' 
		btn_generate.Location = New Point(1162, 463)
		btn_generate.Name = "btn_generate"
		btn_generate.Size = New Size(110, 28)
		btn_generate.TabIndex = 48
		btn_generate.Text = "Generate"
		btn_generate.UseVisualStyleBackColor = True
		' 
		' btn_removeItem
		' 
		btn_removeItem.Location = New Point(835, 463)
		btn_removeItem.Name = "btn_removeItem"
		btn_removeItem.Size = New Size(110, 28)
		btn_removeItem.TabIndex = 49
		btn_removeItem.Text = "Remove Item"
		btn_removeItem.UseVisualStyleBackColor = True
		' 
		' cbx_vehicle
		' 
		cbx_vehicle.FormattingEnabled = True
		cbx_vehicle.Location = New Point(543, 266)
		cbx_vehicle.Name = "cbx_vehicle"
		cbx_vehicle.Size = New Size(243, 28)
		cbx_vehicle.TabIndex = 50
		' 
		' lbl_vehicle
		' 
		lbl_vehicle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_vehicle.AutoSize = True
		lbl_vehicle.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_vehicle.Location = New Point(446, 265)
		lbl_vehicle.Name = "lbl_vehicle"
		lbl_vehicle.Size = New Size(91, 31)
		lbl_vehicle.TabIndex = 51
		lbl_vehicle.Text = "Vehicle"
		' 
		' dgv_lplist
		' 
		dgv_lplist.AllowUserToAddRows = False
		dgv_lplist.AllowUserToDeleteRows = False
		dgv_lplist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgv_lplist.BackgroundColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
		dgv_lplist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgv_lplist.Columns.AddRange(New DataGridViewColumn() {loaded_productID, prod_name, prod_price, loaded_stock, prod_stock_format})
		dgv_lplist.Location = New Point(46, 300)
		dgv_lplist.Name = "dgv_lplist"
		dgv_lplist.ReadOnly = True
		dgv_lplist.RowHeadersVisible = False
		dgv_lplist.RowHeadersWidth = 51
		dgv_lplist.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgv_lplist.Size = New Size(740, 214)
		dgv_lplist.TabIndex = 58
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
		' ColumnHeader1
		' 
		ColumnHeader1.Text = "Product"
		ColumnHeader1.Width = 80
		' 
		' ColumnHeader2
		' 
		ColumnHeader2.Text = "Quantity"
		ColumnHeader2.Width = 80
		' 
		' ColumnHeader3
		' 
		ColumnHeader3.Text = "Format"
		' 
		' ColumnHeader4
		' 
		ColumnHeader4.Text = "Total"
		' 
		' lsv_transaction
		' 
		lsv_transaction.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4})
		lsv_transaction.FullRowSelect = True
		lsv_transaction.GridLines = True
		lsv_transaction.Location = New Point(836, 100)
		lsv_transaction.Name = "lsv_transaction"
		lsv_transaction.Size = New Size(436, 343)
		lsv_transaction.TabIndex = 39
		lsv_transaction.UseCompatibleStateImageBehavior = False
		lsv_transaction.View = View.Details
		' 
		' dtp_transaction
		' 
		dtp_transaction.Location = New Point(170, 192)
		dtp_transaction.Name = "dtp_transaction"
		dtp_transaction.Size = New Size(367, 27)
		dtp_transaction.TabIndex = 52
		' 
		' transaction
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
		ClientSize = New Size(1354, 733)
		Controls.Add(dgv_lplist)
		Controls.Add(dtp_transaction)
		Controls.Add(lbl_vehicle)
		Controls.Add(cbx_vehicle)
		Controls.Add(btn_removeItem)
		Controls.Add(btn_generate)
		Controls.Add(btn_addItem)
		Controls.Add(lbl_total)
		Controls.Add(txb_total)
		Controls.Add(lbl_date)
		Controls.Add(btn_stadd)
		Controls.Add(lbl_payment)
		Controls.Add(cbx_payment)
		Controls.Add(lsv_transaction)
		Controls.Add(txb_search)
		Controls.Add(lbl_store)
		Controls.Add(cbx_stname)
		Controls.Add(lbl_transaction)
		FormBorderStyle = FormBorderStyle.None
		Name = "transaction"
		Text = "transaction"
		CType(dgv_lplist, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents lbl_transaction As Label
	Friend WithEvents cbx_stname As ComboBox
	Friend WithEvents lbl_store As Label
	Friend WithEvents txb_search As TextBox
	Friend WithEvents lbl_payment As Label
	Friend WithEvents cbx_payment As ComboBox
	Friend WithEvents btn_stadd As Button
	Friend WithEvents lbl_date As Label
	Friend WithEvents txb_total As TextBox
	Friend WithEvents lbl_total As Label
	Friend WithEvents btn_addItem As Button
	Friend WithEvents btn_generate As Button
	Friend WithEvents btn_removeItem As Button
	Friend WithEvents cbx_vehicle As ComboBox
	Friend WithEvents lbl_vehicle As Label
	Friend WithEvents dgv_lplist As DataGridView
	Friend WithEvents loaded_productID As DataGridViewTextBoxColumn
	Friend WithEvents prod_name As DataGridViewTextBoxColumn
	Friend WithEvents prod_price As DataGridViewTextBoxColumn
	Friend WithEvents loaded_stock As DataGridViewTextBoxColumn
	Friend WithEvents prod_stock_format As DataGridViewTextBoxColumn
	Friend WithEvents ColumnHeader1 As ColumnHeader
	Friend WithEvents ColumnHeader2 As ColumnHeader
	Friend WithEvents ColumnHeader3 As ColumnHeader
	Friend WithEvents ColumnHeader4 As ColumnHeader
	Friend WithEvents lsv_transaction As ListView
	Friend WithEvents dtp_transaction As DateTimePicker
End Class
