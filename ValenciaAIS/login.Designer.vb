﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
		pcb_login = New PictureBox()
		lbl_signin = New Label()
		Panel1 = New Panel()
		txb_username = New TextBox()
		PictureBox1 = New PictureBox()
		Panel2 = New Panel()
		txb_password = New TextBox()
		PictureBox2 = New PictureBox()
		btn_login = New Button()
		btn_cancel = New Button()
		Panel3 = New Panel()
		cbx_privilege = New ComboBox()
		PictureBox3 = New PictureBox()
		CType(pcb_login, ComponentModel.ISupportInitialize).BeginInit()
		Panel1.SuspendLayout()
		CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
		Panel2.SuspendLayout()
		CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
		Panel3.SuspendLayout()
		CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' pcb_login
		' 
		pcb_login.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		pcb_login.Image = CType(resources.GetObject("pcb_login.Image"), Image)
		pcb_login.Location = New Point(159, 87)
		pcb_login.Name = "pcb_login"
		pcb_login.Size = New Size(156, 156)
		pcb_login.SizeMode = PictureBoxSizeMode.StretchImage
		pcb_login.TabIndex = 0
		pcb_login.TabStop = False
		' 
		' lbl_signin
		' 
		lbl_signin.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		lbl_signin.AutoSize = True
		lbl_signin.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lbl_signin.Location = New Point(195, 262)
		lbl_signin.Name = "lbl_signin"
		lbl_signin.Size = New Size(89, 31)
		lbl_signin.TabIndex = 1
		lbl_signin.Text = "Sign In"
		' 
		' Panel1
		' 
		Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		Panel1.Controls.Add(txb_username)
		Panel1.Controls.Add(PictureBox1)
		Panel1.Location = New Point(76, 384)
		Panel1.Name = "Panel1"
		Panel1.Size = New Size(323, 58)
		Panel1.TabIndex = 2
		' 
		' txb_username
		' 
		txb_username.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		txb_username.Location = New Point(59, 17)
		txb_username.Name = "txb_username"
		txb_username.Size = New Size(251, 27)
		txb_username.TabIndex = 4
		' 
		' PictureBox1
		' 
		PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
		PictureBox1.Location = New Point(8, 9)
		PictureBox1.Name = "PictureBox1"
		PictureBox1.Size = New Size(40, 40)
		PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
		PictureBox1.TabIndex = 3
		PictureBox1.TabStop = False
		' 
		' Panel2
		' 
		Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		Panel2.Controls.Add(txb_password)
		Panel2.Controls.Add(PictureBox2)
		Panel2.Location = New Point(76, 460)
		Panel2.Name = "Panel2"
		Panel2.Size = New Size(323, 58)
		Panel2.TabIndex = 5
		' 
		' txb_password
		' 
		txb_password.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		txb_password.Location = New Point(59, 17)
		txb_password.Name = "txb_password"
		txb_password.Size = New Size(251, 27)
		txb_password.TabIndex = 4
		' 
		' PictureBox2
		' 
		PictureBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
		PictureBox2.Location = New Point(8, 9)
		PictureBox2.Name = "PictureBox2"
		PictureBox2.Size = New Size(40, 40)
		PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
		PictureBox2.TabIndex = 3
		PictureBox2.TabStop = False
		' 
		' btn_login
		' 
		btn_login.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		btn_login.Location = New Point(190, 537)
		btn_login.Name = "btn_login"
		btn_login.Size = New Size(94, 29)
		btn_login.TabIndex = 6
		btn_login.Text = "Login"
		btn_login.UseVisualStyleBackColor = True
		' 
		' btn_cancel
		' 
		btn_cancel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		btn_cancel.Location = New Point(190, 581)
		btn_cancel.Name = "btn_cancel"
		btn_cancel.Size = New Size(94, 29)
		btn_cancel.TabIndex = 7
		btn_cancel.Text = "Cancel"
		btn_cancel.UseVisualStyleBackColor = True
		' 
		' Panel3
		' 
		Panel3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		Panel3.Controls.Add(cbx_privilege)
		Panel3.Controls.Add(PictureBox3)
		Panel3.Location = New Point(76, 310)
		Panel3.Name = "Panel3"
		Panel3.Size = New Size(323, 58)
		Panel3.TabIndex = 5
		' 
		' cbx_privilege
		' 
		cbx_privilege.AutoCompleteCustomSource.AddRange(New String() {"admin", "user"})
		cbx_privilege.DropDownStyle = ComboBoxStyle.DropDownList
		cbx_privilege.FormattingEnabled = True
		cbx_privilege.Location = New Point(59, 16)
		cbx_privilege.Name = "cbx_privilege"
		cbx_privilege.Size = New Size(251, 28)
		cbx_privilege.TabIndex = 4
		' 
		' PictureBox3
		' 
		PictureBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
		PictureBox3.Location = New Point(8, 9)
		PictureBox3.Name = "PictureBox3"
		PictureBox3.Size = New Size(40, 40)
		PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
		PictureBox3.TabIndex = 3
		PictureBox3.TabStop = False
		' 
		' login
		' 
		AutoScaleDimensions = New SizeF(8F, 20F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(490, 648)
		Controls.Add(Panel3)
		Controls.Add(btn_cancel)
		Controls.Add(btn_login)
		Controls.Add(Panel2)
		Controls.Add(Panel1)
		Controls.Add(lbl_signin)
		Controls.Add(pcb_login)
		FormBorderStyle = FormBorderStyle.FixedSingle
		MaximizeBox = False
		MinimizeBox = False
		Name = "login"
		StartPosition = FormStartPosition.CenterScreen
		CType(pcb_login, ComponentModel.ISupportInitialize).EndInit()
		Panel1.ResumeLayout(False)
		Panel1.PerformLayout()
		CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
		Panel2.ResumeLayout(False)
		Panel2.PerformLayout()
		CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
		Panel3.ResumeLayout(False)
		CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents pcb_login As PictureBox
	Friend WithEvents lbl_signin As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents txb_username As TextBox
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents Panel2 As Panel
	Friend WithEvents txb_password As TextBox
	Friend WithEvents PictureBox2 As PictureBox
	Friend WithEvents btn_login As Button
	Friend WithEvents btn_cancel As Button
	Friend WithEvents Panel3 As Panel
	Friend WithEvents PictureBox3 As PictureBox
	Friend WithEvents cbx_privilege As ComboBox
End Class
