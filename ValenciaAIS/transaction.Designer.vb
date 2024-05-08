<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
		lbl_payment = New Label()
		cbx_payment = New ComboBox()
		btn_stadd = New Button()
		lbl_date = New Label()
		txb_total = New TextBox()
		lbl_total = New Label()
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
		btn_showReceipt = New Button()
		dgv_invoice = New DataGridView()
		InvoiceID = New DataGridViewTextBoxColumn()
		Column2 = New DataGridViewTextBoxColumn()
		Column3 = New DataGridViewTextBoxColumn()
		Column4 = New DataGridViewTextBoxColumn()
		btn_showInvoices = New Button()
		CType(dgv_lplist, ComponentModel.ISupportInitialize).BeginInit()
		CType(dgv_invoice, ComponentModel.ISupportInitialize).BeginInit()
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
		cbx_stname.DropDownStyle = ComboBoxStyle.DropDownList
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
		cbx_payment.DropDownStyle = ComboBoxStyle.DropDownList
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
		txb_total.Location = New Point(901, 818)
		txb_total.Name = "txb_total"
		txb_total.Size = New Size(160, 27)
		txb_total.TabIndex = 45
		' 
		' lbl_total
		' 
		lbl_total.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_total.AutoSize = True
		lbl_total.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_total.Location = New Point(828, 816)
		lbl_total.Name = "lbl_total"
		lbl_total.Size = New Size(67, 31)
		lbl_total.TabIndex = 46
		lbl_total.Text = "Total"
		' 
		' btn_generate
		' 
		btn_generate.Location = New Point(1162, 770)
		btn_generate.Name = "btn_generate"
		btn_generate.Size = New Size(110, 28)
		btn_generate.TabIndex = 48
		btn_generate.Text = "Generate"
		btn_generate.UseVisualStyleBackColor = True
		' 
		' btn_removeItem
		' 
		btn_removeItem.Location = New Point(836, 770)
		btn_removeItem.Name = "btn_removeItem"
		btn_removeItem.Size = New Size(110, 28)
		btn_removeItem.TabIndex = 49
		btn_removeItem.Text = "Remove Item"
		btn_removeItem.UseVisualStyleBackColor = True
		' 
		' cbx_vehicle
		' 
		cbx_vehicle.FormattingEnabled = True
		cbx_vehicle.Location = New Point(543, 241)
		cbx_vehicle.Name = "cbx_vehicle"
		cbx_vehicle.Size = New Size(243, 28)
		cbx_vehicle.TabIndex = 50
		' 
		' lbl_vehicle
		' 
		lbl_vehicle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_vehicle.AutoSize = True
		lbl_vehicle.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_vehicle.Location = New Point(446, 240)
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
		dgv_lplist.Location = New Point(46, 275)
		dgv_lplist.Name = "dgv_lplist"
		dgv_lplist.ReadOnly = True
		dgv_lplist.RowHeadersVisible = False
		dgv_lplist.RowHeadersWidth = 51
		dgv_lplist.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgv_lplist.Size = New Size(740, 250)
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
		lsv_transaction.Size = New Size(436, 664)
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
		dtp_transaction.Value = New Date(2024, 5, 8, 1, 15, 24, 0)
		' 
		' btn_showReceipt
		' 
		btn_showReceipt.Location = New Point(46, 531)
		btn_showReceipt.Name = "btn_showReceipt"
		btn_showReceipt.Size = New Size(133, 28)
		btn_showReceipt.TabIndex = 59
		btn_showReceipt.Text = "Show Receipts"
		btn_showReceipt.UseVisualStyleBackColor = True
		' 
		' dgv_invoice
		' 
		dgv_invoice.AllowUserToAddRows = False
		dgv_invoice.AllowUserToDeleteRows = False
		dgv_invoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgv_invoice.BackgroundColor = Color.FromArgb(CByte(128), CByte(64), CByte(64))
		dgv_invoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		dgv_invoice.Columns.AddRange(New DataGridViewColumn() {InvoiceID, Column2, Column3, Column4})
		dgv_invoice.Location = New Point(46, 565)
		dgv_invoice.Name = "dgv_invoice"
		dgv_invoice.ReadOnly = True
		dgv_invoice.RowHeadersVisible = False
		dgv_invoice.RowHeadersWidth = 51
		dgv_invoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgv_invoice.Size = New Size(740, 250)
		dgv_invoice.TabIndex = 60
		' 
		' InvoiceID
		' 
		InvoiceID.DataPropertyName = "invoice_id"
		InvoiceID.HeaderText = "Invoice ID"
		InvoiceID.MinimumWidth = 6
		InvoiceID.Name = "InvoiceID"
		InvoiceID.ReadOnly = True
		' 
		' Column2
		' 
		Column2.DataPropertyName = "store_name"
		Column2.HeaderText = "Store"
		Column2.MinimumWidth = 6
		Column2.Name = "Column2"
		Column2.ReadOnly = True
		' 
		' Column3
		' 
		Column3.DataPropertyName = "payment_method"
		Column3.HeaderText = "Payment"
		Column3.MinimumWidth = 6
		Column3.Name = "Column3"
		Column3.ReadOnly = True
		' 
		' Column4
		' 
		Column4.DataPropertyName = "transaction_date"
		Column4.HeaderText = "Date"
		Column4.MinimumWidth = 6
		Column4.Name = "Column4"
		Column4.ReadOnly = True
		' 
		' btn_showInvoices
		' 
		btn_showInvoices.Location = New Point(46, 821)
		btn_showInvoices.Name = "btn_showInvoices"
		btn_showInvoices.Size = New Size(133, 28)
		btn_showInvoices.TabIndex = 61
		btn_showInvoices.Text = "Show Invoices"
		btn_showInvoices.UseVisualStyleBackColor = True
		' 
		' transaction
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.FromArgb(CByte(192), CByte(192), CByte(255))
		ClientSize = New Size(1580, 926)
		Controls.Add(btn_showInvoices)
		Controls.Add(dgv_invoice)
		Controls.Add(btn_showReceipt)
		Controls.Add(dgv_lplist)
		Controls.Add(dtp_transaction)
		Controls.Add(lbl_vehicle)
		Controls.Add(cbx_vehicle)
		Controls.Add(btn_removeItem)
		Controls.Add(btn_generate)
		Controls.Add(lbl_total)
		Controls.Add(txb_total)
		Controls.Add(lbl_date)
		Controls.Add(btn_stadd)
		Controls.Add(lbl_payment)
		Controls.Add(cbx_payment)
		Controls.Add(lsv_transaction)
		Controls.Add(lbl_store)
		Controls.Add(cbx_stname)
		Controls.Add(lbl_transaction)
		FormBorderStyle = FormBorderStyle.None
		Name = "transaction"
		StartPosition = FormStartPosition.CenterParent
		Text = "transaction"
		CType(dgv_lplist, ComponentModel.ISupportInitialize).EndInit()
		CType(dgv_invoice, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents lbl_transaction As Label
	Friend WithEvents cbx_stname As ComboBox
	Friend WithEvents lbl_store As Label
	Friend WithEvents lbl_payment As Label
	Friend WithEvents cbx_payment As ComboBox
	Friend WithEvents btn_stadd As Button
	Friend WithEvents lbl_date As Label
	Friend WithEvents txb_total As TextBox
	Friend WithEvents lbl_total As Label
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
	Friend WithEvents btn_showReceipt As Button
	Friend WithEvents dgv_invoice As DataGridView
	Friend WithEvents InvoiceID As DataGridViewTextBoxColumn
	Friend WithEvents Column2 As DataGridViewTextBoxColumn
	Friend WithEvents Column3 As DataGridViewTextBoxColumn
	Friend WithEvents Column4 As DataGridViewTextBoxColumn
	Friend WithEvents btn_showInvoices As Button
End Class
