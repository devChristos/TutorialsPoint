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
        Me.components = New System.ComponentModel.Container()
        Dim IDLabel1 As System.Windows.Forms.Label
        Dim PlaintiffNameLabel1 As System.Windows.Forms.Label
        Dim GenderLabel As System.Windows.Forms.Label
        Dim InstancesLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim CaseIdLabel As System.Windows.Forms.Label
        Dim DateFiledLabel As System.Windows.Forms.Label
        Dim PlaintiffNameLabel As System.Windows.Forms.Label
        Dim CaseStatusLabel As System.Windows.Forms.Label
        Dim AttorneyNameLabel As System.Windows.Forms.Label
        Dim AttorneyAddressLabel As System.Windows.Forms.Label
        Dim IssuesLabel As System.Windows.Forms.Label
        Dim DefendantNameLabel As System.Windows.Forms.Label
        Dim DefendantAttorneyNameLabel As System.Windows.Forms.Label
        Dim DefendantAttorneyAddressLabel As System.Windows.Forms.Label
        Dim HtmlLabel As System.Windows.Forms.Label
        Me.Database1DataSet1 = New TutorialsPoint.Database1DataSet()
        Me.Table1BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Table1TableAdapter1 = New TutorialsPoint.Database1DataSetTableAdapters.Table1TableAdapter()
        Me.TableAdapterManager1 = New TutorialsPoint.Database1DataSetTableAdapters.TableAdapterManager()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TblGenderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblGenderTableAdapter = New TutorialsPoint.Database1DataSetTableAdapters.tblGenderTableAdapter()
        Me.IDTextBox2 = New System.Windows.Forms.TextBox()
        Me.PlaintiffNameTextBox2 = New System.Windows.Forms.TextBox()
        Me.GenderTextBox = New System.Windows.Forms.TextBox()
        Me.InstancesTextBox = New System.Windows.Forms.TextBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TblAnalyzedDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblAnalyzedDataTableAdapter = New TutorialsPoint.Database1DataSetTableAdapters.tblAnalyzedDataTableAdapter()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.IDTextBox3 = New System.Windows.Forms.TextBox()
        Me.CaseIdTextBox2 = New System.Windows.Forms.TextBox()
        Me.DateFiledDateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.PlaintiffNameTextBox3 = New System.Windows.Forms.TextBox()
        Me.CaseStatusTextBox1 = New System.Windows.Forms.TextBox()
        Me.AttorneyNameTextBox1 = New System.Windows.Forms.TextBox()
        Me.AttorneyAddressTextBox1 = New System.Windows.Forms.TextBox()
        Me.IssuesTextBox1 = New System.Windows.Forms.TextBox()
        Me.DefendantNameTextBox1 = New System.Windows.Forms.TextBox()
        Me.DefendantAttorneyNameTextBox = New System.Windows.Forms.TextBox()
        Me.DefendantAttorneyAddressTextBox = New System.Windows.Forms.TextBox()
        Me.HtmlTextBox = New System.Windows.Forms.TextBox()
        IDLabel1 = New System.Windows.Forms.Label()
        PlaintiffNameLabel1 = New System.Windows.Forms.Label()
        GenderLabel = New System.Windows.Forms.Label()
        InstancesLabel = New System.Windows.Forms.Label()
        IDLabel = New System.Windows.Forms.Label()
        CaseIdLabel = New System.Windows.Forms.Label()
        DateFiledLabel = New System.Windows.Forms.Label()
        PlaintiffNameLabel = New System.Windows.Forms.Label()
        CaseStatusLabel = New System.Windows.Forms.Label()
        AttorneyNameLabel = New System.Windows.Forms.Label()
        AttorneyAddressLabel = New System.Windows.Forms.Label()
        IssuesLabel = New System.Windows.Forms.Label()
        DefendantNameLabel = New System.Windows.Forms.Label()
        DefendantAttorneyNameLabel = New System.Windows.Forms.Label()
        DefendantAttorneyAddressLabel = New System.Windows.Forms.Label()
        HtmlLabel = New System.Windows.Forms.Label()
        CType(Me.Database1DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Table1BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblGenderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblAnalyzedDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IDLabel1
        '
        IDLabel1.AutoSize = True
        IDLabel1.Location = New System.Drawing.Point(43, 181)
        IDLabel1.Name = "IDLabel1"
        IDLabel1.Size = New System.Drawing.Size(25, 17)
        IDLabel1.TabIndex = 35
        IDLabel1.Text = "ID:"
        '
        'PlaintiffNameLabel1
        '
        PlaintiffNameLabel1.AutoSize = True
        PlaintiffNameLabel1.Location = New System.Drawing.Point(43, 209)
        PlaintiffNameLabel1.Name = "PlaintiffNameLabel1"
        PlaintiffNameLabel1.Size = New System.Drawing.Size(98, 17)
        PlaintiffNameLabel1.TabIndex = 37
        PlaintiffNameLabel1.Text = "plaintiff Name:"
        '
        'GenderLabel
        '
        GenderLabel.AutoSize = True
        GenderLabel.Location = New System.Drawing.Point(43, 237)
        GenderLabel.Name = "GenderLabel"
        GenderLabel.Size = New System.Drawing.Size(57, 17)
        GenderLabel.TabIndex = 39
        GenderLabel.Text = "gender:"
        '
        'InstancesLabel
        '
        InstancesLabel.AutoSize = True
        InstancesLabel.Location = New System.Drawing.Point(43, 265)
        InstancesLabel.Name = "InstancesLabel"
        InstancesLabel.Size = New System.Drawing.Size(72, 17)
        InstancesLabel.TabIndex = 41
        InstancesLabel.Text = "instances:"
        '
        'Database1DataSet1
        '
        Me.Database1DataSet1.DataSetName = "Database1DataSet"
        Me.Database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Table1BindingSource1
        '
        Me.Table1BindingSource1.DataMember = "Table1"
        Me.Table1BindingSource1.DataSource = Me.Database1DataSet1
        '
        'Table1TableAdapter1
        '
        Me.Table1TableAdapter1.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.Table1TableAdapter = Me.Table1TableAdapter1
        Me.TableAdapterManager1.tblAnalyzedDataTableAdapter = Nothing
        Me.TableAdapterManager1.tblGenderTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = TutorialsPoint.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Location = New System.Drawing.Point(694, 29)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(674, 448)
        Me.WebBrowser2.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(422, 32)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Maryland Judiciary Case Search"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Case Id:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Amount:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(145, 55)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 15
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(145, 95)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 22)
        Me.TextBox2.TabIndex = 16
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(556, 54)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(276, 54)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(115, 23)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "Search Test"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TblGenderBindingSource
        '
        Me.TblGenderBindingSource.DataMember = "tblGender"
        Me.TblGenderBindingSource.DataSource = Me.Database1DataSet1
        '
        'TblGenderTableAdapter
        '
        Me.TblGenderTableAdapter.ClearBeforeFill = True
        '
        'IDTextBox2
        '
        Me.IDTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblGenderBindingSource, "ID", True))
        Me.IDTextBox2.Location = New System.Drawing.Point(147, 178)
        Me.IDTextBox2.Name = "IDTextBox2"
        Me.IDTextBox2.Size = New System.Drawing.Size(100, 22)
        Me.IDTextBox2.TabIndex = 36
        '
        'PlaintiffNameTextBox2
        '
        Me.PlaintiffNameTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblGenderBindingSource, "plaintiffName", True))
        Me.PlaintiffNameTextBox2.Location = New System.Drawing.Point(147, 206)
        Me.PlaintiffNameTextBox2.Name = "PlaintiffNameTextBox2"
        Me.PlaintiffNameTextBox2.Size = New System.Drawing.Size(100, 22)
        Me.PlaintiffNameTextBox2.TabIndex = 38
        '
        'GenderTextBox
        '
        Me.GenderTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblGenderBindingSource, "gender", True))
        Me.GenderTextBox.Location = New System.Drawing.Point(147, 234)
        Me.GenderTextBox.Name = "GenderTextBox"
        Me.GenderTextBox.Size = New System.Drawing.Size(100, 22)
        Me.GenderTextBox.TabIndex = 40
        '
        'InstancesTextBox
        '
        Me.InstancesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblGenderBindingSource, "instances", True))
        Me.InstancesTextBox.Location = New System.Drawing.Point(147, 262)
        Me.InstancesTextBox.Name = "InstancesTextBox"
        Me.InstancesTextBox.Size = New System.Drawing.Size(100, 22)
        Me.InstancesTextBox.TabIndex = 42
        '
        'ComboBox3
        '
        Me.ComboBox3.DataSource = Me.TblGenderBindingSource
        Me.ComboBox3.DisplayMember = "plaintiffName"
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(46, 138)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox3.TabIndex = 43
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(276, 95)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(115, 22)
        Me.Button5.TabIndex = 44
        Me.Button5.Text = "Clear Raw Data"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(416, 93)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(123, 23)
        Me.Button6.TabIndex = 45
        Me.Button6.Text = "Clear tblGender"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(416, 54)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(123, 23)
        Me.Button7.TabIndex = 46
        Me.Button7.Text = "tblAnalyzedData"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'TblAnalyzedDataBindingSource
        '
        Me.TblAnalyzedDataBindingSource.DataMember = "tblAnalyzedData"
        Me.TblAnalyzedDataBindingSource.DataSource = Me.Database1DataSet1
        '
        'TblAnalyzedDataTableAdapter
        '
        Me.TblAnalyzedDataTableAdapter.ClearBeforeFill = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(46, 354)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(123, 23)
        Me.Button8.TabIndex = 69
        Me.Button8.Text = "Test WordList"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(46, 318)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 70
        Me.Button9.Text = "testing"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(556, 93)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 71
        Me.Button2.Text = "Clear All"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(468, 138)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(163, 23)
        Me.Button10.TabIndex = 97
        Me.Button10.Text = "Clear tblAnalyzedData"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(40, 396)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(158, 23)
        Me.Button11.TabIndex = 98
        Me.Button11.Text = "Clear tblGender Inst."
        Me.Button11.UseVisualStyleBackColor = True
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Location = New System.Drawing.Point(273, 183)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(25, 17)
        IDLabel.TabIndex = 98
        IDLabel.Text = "ID:"
        '
        'IDTextBox3
        '
        Me.IDTextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "ID", True))
        Me.IDTextBox3.Location = New System.Drawing.Point(468, 180)
        Me.IDTextBox3.Name = "IDTextBox3"
        Me.IDTextBox3.Size = New System.Drawing.Size(200, 22)
        Me.IDTextBox3.TabIndex = 99
        '
        'CaseIdLabel
        '
        CaseIdLabel.AutoSize = True
        CaseIdLabel.Location = New System.Drawing.Point(273, 211)
        CaseIdLabel.Name = "CaseIdLabel"
        CaseIdLabel.Size = New System.Drawing.Size(57, 17)
        CaseIdLabel.TabIndex = 100
        CaseIdLabel.Text = "case Id:"
        '
        'CaseIdTextBox2
        '
        Me.CaseIdTextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "caseId", True))
        Me.CaseIdTextBox2.Location = New System.Drawing.Point(468, 208)
        Me.CaseIdTextBox2.Name = "CaseIdTextBox2"
        Me.CaseIdTextBox2.Size = New System.Drawing.Size(200, 22)
        Me.CaseIdTextBox2.TabIndex = 101
        '
        'DateFiledLabel
        '
        DateFiledLabel.AutoSize = True
        DateFiledLabel.Location = New System.Drawing.Point(273, 240)
        DateFiledLabel.Name = "DateFiledLabel"
        DateFiledLabel.Size = New System.Drawing.Size(74, 17)
        DateFiledLabel.TabIndex = 102
        DateFiledLabel.Text = "date Filed:"
        '
        'DateFiledDateTimePicker2
        '
        Me.DateFiledDateTimePicker2.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.Table1BindingSource1, "dateFiled", True))
        Me.DateFiledDateTimePicker2.Location = New System.Drawing.Point(468, 236)
        Me.DateFiledDateTimePicker2.Name = "DateFiledDateTimePicker2"
        Me.DateFiledDateTimePicker2.Size = New System.Drawing.Size(200, 22)
        Me.DateFiledDateTimePicker2.TabIndex = 103
        '
        'PlaintiffNameLabel
        '
        PlaintiffNameLabel.AutoSize = True
        PlaintiffNameLabel.Location = New System.Drawing.Point(273, 267)
        PlaintiffNameLabel.Name = "PlaintiffNameLabel"
        PlaintiffNameLabel.Size = New System.Drawing.Size(98, 17)
        PlaintiffNameLabel.TabIndex = 104
        PlaintiffNameLabel.Text = "plaintiff Name:"
        '
        'PlaintiffNameTextBox3
        '
        Me.PlaintiffNameTextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "plaintiffName", True))
        Me.PlaintiffNameTextBox3.Location = New System.Drawing.Point(468, 264)
        Me.PlaintiffNameTextBox3.Name = "PlaintiffNameTextBox3"
        Me.PlaintiffNameTextBox3.Size = New System.Drawing.Size(200, 22)
        Me.PlaintiffNameTextBox3.TabIndex = 105
        '
        'CaseStatusLabel
        '
        CaseStatusLabel.AutoSize = True
        CaseStatusLabel.Location = New System.Drawing.Point(273, 295)
        CaseStatusLabel.Name = "CaseStatusLabel"
        CaseStatusLabel.Size = New System.Drawing.Size(86, 17)
        CaseStatusLabel.TabIndex = 106
        CaseStatusLabel.Text = "case Status:"
        '
        'CaseStatusTextBox1
        '
        Me.CaseStatusTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "caseStatus", True))
        Me.CaseStatusTextBox1.Location = New System.Drawing.Point(468, 292)
        Me.CaseStatusTextBox1.Name = "CaseStatusTextBox1"
        Me.CaseStatusTextBox1.Size = New System.Drawing.Size(200, 22)
        Me.CaseStatusTextBox1.TabIndex = 107
        '
        'AttorneyNameLabel
        '
        AttorneyNameLabel.AutoSize = True
        AttorneyNameLabel.Location = New System.Drawing.Point(273, 323)
        AttorneyNameLabel.Name = "AttorneyNameLabel"
        AttorneyNameLabel.Size = New System.Drawing.Size(105, 17)
        AttorneyNameLabel.TabIndex = 108
        AttorneyNameLabel.Text = "attorney Name:"
        '
        'AttorneyNameTextBox1
        '
        Me.AttorneyNameTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "attorneyName", True))
        Me.AttorneyNameTextBox1.Location = New System.Drawing.Point(468, 320)
        Me.AttorneyNameTextBox1.Name = "AttorneyNameTextBox1"
        Me.AttorneyNameTextBox1.Size = New System.Drawing.Size(200, 22)
        Me.AttorneyNameTextBox1.TabIndex = 109
        '
        'AttorneyAddressLabel
        '
        AttorneyAddressLabel.AutoSize = True
        AttorneyAddressLabel.Location = New System.Drawing.Point(273, 351)
        AttorneyAddressLabel.Name = "AttorneyAddressLabel"
        AttorneyAddressLabel.Size = New System.Drawing.Size(120, 17)
        AttorneyAddressLabel.TabIndex = 110
        AttorneyAddressLabel.Text = "attorney Address:"
        '
        'AttorneyAddressTextBox1
        '
        Me.AttorneyAddressTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "attorneyAddress", True))
        Me.AttorneyAddressTextBox1.Location = New System.Drawing.Point(468, 348)
        Me.AttorneyAddressTextBox1.Name = "AttorneyAddressTextBox1"
        Me.AttorneyAddressTextBox1.Size = New System.Drawing.Size(200, 22)
        Me.AttorneyAddressTextBox1.TabIndex = 111
        '
        'IssuesLabel
        '
        IssuesLabel.AutoSize = True
        IssuesLabel.Location = New System.Drawing.Point(273, 379)
        IssuesLabel.Name = "IssuesLabel"
        IssuesLabel.Size = New System.Drawing.Size(52, 17)
        IssuesLabel.TabIndex = 112
        IssuesLabel.Text = "issues:"
        '
        'IssuesTextBox1
        '
        Me.IssuesTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "issues", True))
        Me.IssuesTextBox1.Location = New System.Drawing.Point(468, 376)
        Me.IssuesTextBox1.Name = "IssuesTextBox1"
        Me.IssuesTextBox1.Size = New System.Drawing.Size(200, 22)
        Me.IssuesTextBox1.TabIndex = 113
        '
        'DefendantNameLabel
        '
        DefendantNameLabel.AutoSize = True
        DefendantNameLabel.Location = New System.Drawing.Point(273, 407)
        DefendantNameLabel.Name = "DefendantNameLabel"
        DefendantNameLabel.Size = New System.Drawing.Size(117, 17)
        DefendantNameLabel.TabIndex = 114
        DefendantNameLabel.Text = "defendant Name:"
        '
        'DefendantNameTextBox1
        '
        Me.DefendantNameTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "defendantName", True))
        Me.DefendantNameTextBox1.Location = New System.Drawing.Point(468, 404)
        Me.DefendantNameTextBox1.Name = "DefendantNameTextBox1"
        Me.DefendantNameTextBox1.Size = New System.Drawing.Size(200, 22)
        Me.DefendantNameTextBox1.TabIndex = 115
        '
        'DefendantAttorneyNameLabel
        '
        DefendantAttorneyNameLabel.AutoSize = True
        DefendantAttorneyNameLabel.Location = New System.Drawing.Point(273, 435)
        DefendantAttorneyNameLabel.Name = "DefendantAttorneyNameLabel"
        DefendantAttorneyNameLabel.Size = New System.Drawing.Size(174, 17)
        DefendantAttorneyNameLabel.TabIndex = 116
        DefendantAttorneyNameLabel.Text = "defendant Attorney Name:"
        '
        'DefendantAttorneyNameTextBox
        '
        Me.DefendantAttorneyNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "defendantAttorneyName", True))
        Me.DefendantAttorneyNameTextBox.Location = New System.Drawing.Point(468, 432)
        Me.DefendantAttorneyNameTextBox.Name = "DefendantAttorneyNameTextBox"
        Me.DefendantAttorneyNameTextBox.Size = New System.Drawing.Size(200, 22)
        Me.DefendantAttorneyNameTextBox.TabIndex = 117
        '
        'DefendantAttorneyAddressLabel
        '
        DefendantAttorneyAddressLabel.AutoSize = True
        DefendantAttorneyAddressLabel.Location = New System.Drawing.Point(273, 463)
        DefendantAttorneyAddressLabel.Name = "DefendantAttorneyAddressLabel"
        DefendantAttorneyAddressLabel.Size = New System.Drawing.Size(189, 17)
        DefendantAttorneyAddressLabel.TabIndex = 118
        DefendantAttorneyAddressLabel.Text = "defendant Attorney Address:"
        '
        'DefendantAttorneyAddressTextBox
        '
        Me.DefendantAttorneyAddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "defendantAttorneyAddress", True))
        Me.DefendantAttorneyAddressTextBox.Location = New System.Drawing.Point(468, 460)
        Me.DefendantAttorneyAddressTextBox.Name = "DefendantAttorneyAddressTextBox"
        Me.DefendantAttorneyAddressTextBox.Size = New System.Drawing.Size(200, 22)
        Me.DefendantAttorneyAddressTextBox.TabIndex = 119
        '
        'HtmlLabel
        '
        HtmlLabel.AutoSize = True
        HtmlLabel.Location = New System.Drawing.Point(273, 491)
        HtmlLabel.Name = "HtmlLabel"
        HtmlLabel.Size = New System.Drawing.Size(38, 17)
        HtmlLabel.TabIndex = 120
        HtmlLabel.Text = "html:"
        '
        'HtmlTextBox
        '
        Me.HtmlTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Table1BindingSource1, "html", True))
        Me.HtmlTextBox.Location = New System.Drawing.Point(468, 488)
        Me.HtmlTextBox.Name = "HtmlTextBox"
        Me.HtmlTextBox.Size = New System.Drawing.Size(200, 22)
        Me.HtmlTextBox.TabIndex = 121
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(1403, 650)
        Me.Controls.Add(IDLabel)
        Me.Controls.Add(Me.IDTextBox3)
        Me.Controls.Add(CaseIdLabel)
        Me.Controls.Add(Me.CaseIdTextBox2)
        Me.Controls.Add(DateFiledLabel)
        Me.Controls.Add(Me.DateFiledDateTimePicker2)
        Me.Controls.Add(PlaintiffNameLabel)
        Me.Controls.Add(Me.PlaintiffNameTextBox3)
        Me.Controls.Add(CaseStatusLabel)
        Me.Controls.Add(Me.CaseStatusTextBox1)
        Me.Controls.Add(AttorneyNameLabel)
        Me.Controls.Add(Me.AttorneyNameTextBox1)
        Me.Controls.Add(AttorneyAddressLabel)
        Me.Controls.Add(Me.AttorneyAddressTextBox1)
        Me.Controls.Add(IssuesLabel)
        Me.Controls.Add(Me.IssuesTextBox1)
        Me.Controls.Add(DefendantNameLabel)
        Me.Controls.Add(Me.DefendantNameTextBox1)
        Me.Controls.Add(DefendantAttorneyNameLabel)
        Me.Controls.Add(Me.DefendantAttorneyNameTextBox)
        Me.Controls.Add(DefendantAttorneyAddressLabel)
        Me.Controls.Add(Me.DefendantAttorneyAddressTextBox)
        Me.Controls.Add(HtmlLabel)
        Me.Controls.Add(Me.HtmlTextBox)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(IDLabel1)
        Me.Controls.Add(Me.IDTextBox2)
        Me.Controls.Add(PlaintiffNameLabel1)
        Me.Controls.Add(Me.PlaintiffNameTextBox2)
        Me.Controls.Add(GenderLabel)
        Me.Controls.Add(Me.GenderTextBox)
        Me.Controls.Add(InstancesLabel)
        Me.Controls.Add(Me.InstancesTextBox)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.WebBrowser2)
        Me.Name = "Form1"
        CType(Me.Database1DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Table1BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblGenderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblAnalyzedDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents TxtStart As Windows.Forms.TextBox
    Friend WithEvents txtEnd As Windows.Forms.TextBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents WebBrowser1 As Windows.Forms.WebBrowser
    Friend WithEvents btnClose As Windows.Forms.Button
    Friend WithEvents Database1DataSet As Database1DataSet
    Friend WithEvents Table1BindingSource As Windows.Forms.BindingSource
    Friend WithEvents Table1TableAdapter As Database1DataSetTableAdapters.Table1TableAdapter
    Friend WithEvents TableAdapterManager As Database1DataSetTableAdapters.TableAdapterManager
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents PlaintiffNameTextBox As Windows.Forms.TextBox
    Friend WithEvents DateFiledDateTimePicker As Windows.Forms.DateTimePicker
    Friend WithEvents CaseIdTextBox As Windows.Forms.TextBox
    Friend WithEvents IDTextBox As Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As Windows.Forms.ComboBox
    Friend WithEvents Database1DataSet1 As Database1DataSet
    Friend WithEvents Table1BindingSource1 As Windows.Forms.BindingSource
    Friend WithEvents Table1TableAdapter1 As Database1DataSetTableAdapters.Table1TableAdapter
    Friend WithEvents TableAdapterManager1 As Database1DataSetTableAdapters.TableAdapterManager
    Friend WithEvents WebBrowser2 As Windows.Forms.WebBrowser
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button4 As Windows.Forms.Button
    Friend WithEvents ComboBox2 As Windows.Forms.ComboBox
    Friend WithEvents IDTextBox1 As Windows.Forms.TextBox
    Friend WithEvents CaseIdTextBox1 As Windows.Forms.TextBox
    Friend WithEvents DateFiledDateTimePicker1 As Windows.Forms.DateTimePicker
    Friend WithEvents PlaintiffNameTextBox1 As Windows.Forms.TextBox
    Friend WithEvents CaseStatusTextBox As Windows.Forms.TextBox
    Friend WithEvents AttorneyNameTextBox As Windows.Forms.TextBox
    Friend WithEvents AttorneyAddressTextBox As Windows.Forms.TextBox
    Friend WithEvents IssuesTextBox As Windows.Forms.TextBox
    Friend WithEvents DefendantNameTextBox As Windows.Forms.TextBox
    Friend WithEvents TblGenderBindingSource As Windows.Forms.BindingSource
    Friend WithEvents TblGenderTableAdapter As Database1DataSetTableAdapters.tblGenderTableAdapter
    Friend WithEvents IDTextBox2 As Windows.Forms.TextBox
    Friend WithEvents PlaintiffNameTextBox2 As Windows.Forms.TextBox
    Friend WithEvents GenderTextBox As Windows.Forms.TextBox
    Friend WithEvents InstancesTextBox As Windows.Forms.TextBox
    Friend WithEvents ComboBox3 As Windows.Forms.ComboBox
    Friend WithEvents Button5 As Windows.Forms.Button
    Friend WithEvents Button6 As Windows.Forms.Button
    Friend WithEvents Button7 As Windows.Forms.Button
    Friend WithEvents TblAnalyzedDataBindingSource As Windows.Forms.BindingSource
    Friend WithEvents TblAnalyzedDataTableAdapter As Database1DataSetTableAdapters.tblAnalyzedDataTableAdapter
    Friend WithEvents Button8 As Windows.Forms.Button
    Friend WithEvents Button9 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button10 As Windows.Forms.Button
    Friend WithEvents Button11 As Windows.Forms.Button
    Friend WithEvents IDTextBox3 As Windows.Forms.TextBox
    Friend WithEvents CaseIdTextBox2 As Windows.Forms.TextBox
    Friend WithEvents DateFiledDateTimePicker2 As Windows.Forms.DateTimePicker
    Friend WithEvents PlaintiffNameTextBox3 As Windows.Forms.TextBox
    Friend WithEvents CaseStatusTextBox1 As Windows.Forms.TextBox
    Friend WithEvents AttorneyNameTextBox1 As Windows.Forms.TextBox
    Friend WithEvents AttorneyAddressTextBox1 As Windows.Forms.TextBox
    Friend WithEvents IssuesTextBox1 As Windows.Forms.TextBox
    Friend WithEvents DefendantNameTextBox1 As Windows.Forms.TextBox
    Friend WithEvents DefendantAttorneyNameTextBox As Windows.Forms.TextBox
    Friend WithEvents DefendantAttorneyAddressTextBox As Windows.Forms.TextBox
    Friend WithEvents HtmlTextBox As Windows.Forms.TextBox
End Class
