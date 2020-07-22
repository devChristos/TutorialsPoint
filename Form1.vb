
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System
Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Database1DataSet1.tblAnalyzedData' table. You can move, or remove it, as needed.
        Me.TblAnalyzedDataTableAdapter.Fill(Me.Database1DataSet1.tblAnalyzedData)
        'TODO: This line of code loads data into the 'Database1DataSet1.tblGender' table. You can move, or remove it, as needed.
        Me.TblGenderTableAdapter.Fill(Me.Database1DataSet1.tblGender)
        'TODO: This line of code loads data into the 'Database1DataSet.Table1' table. You can move, or remove it, as needed.
        Me.Table1TableAdapter1.Fill(Me.Database1DataSet1.Table1)

        'My Code, use below line of code to remove browser in Windows Form and instead do subroutines in the background. Kept browser for testing
        'Dim webBrowser1 As WebBrowser = New WebBrowser(),
        WebBrowser2.Navigate("http://casesearch.courts.state.md.us/casesearch/")

        'This piece of code surpresses the script warning/error messages, it doesn't affect the fucntion of the script, it's just annoying
        WebBrowser2.ScriptErrorsSuppressed = True
    End Sub


    'Closes the Windows Form
    Private Sub closeWindow(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    'HELPER METHODS FROM INTERNET
    Private Property pageready As Boolean = False
    Private Sub WaitForPageLoad()
        AddHandler WebBrowser2.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        While Not pageready
            Application.DoEvents()
        End While
        pageready = False
    End Sub
    Private Sub PageWaiter(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        If WebBrowser2.ReadyState = WebBrowserReadyState.Complete Then
            pageready = True
            RemoveHandler WebBrowser2.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        End If
    End Sub

    'END OF HELPER METHODS FROM INTERNET

    'Search Test, improved version of Search, with more functionality and bug fixes

    'general error, after contacting the site hundreds of times, the site returns a 404 Error if you contact it too much, need to use a user agent or to let it cool down
    Private Sub searchTest(sender As Object, e As EventArgs) Handles Button4.Click
        Dim theElementCollection As HtmlElementCollection = WebBrowser2.Document.All
        theElementCollection = WebBrowser2.Document.GetElementsByTagName("input")

        For Each curElement As HtmlElement In theElementCollection
            If curElement.GetAttribute("name") = "disclaimer" Then
                curElement.InvokeMember("click")
            ElseIf curElement.GetAttribute("name") = "action" Then
                curElement.InvokeMember("click")
            End If
        Next

        'FIXED IT WITH METHOD / CODE FROM THE INTERNET WaitForPageLoad() https://stackoverflow.com/questions/3275515/how-to-wait-until-webbrowser-is-completely-loaded-in-vb-net
        WaitForPageLoad()
        Dim theElementCollection2 As HtmlElementCollection = WebBrowser2.Document.All
        theElementCollection2 = WebBrowser2.Document.GetElementsByTagName("select")

        For Each curElement As HtmlElement In theElementCollection2
            If curElement.GetAttribute("name") = "locationCode" Then
                curElement.SetAttribute("value", "15")
            End If
        Next

        'Extracting using Regex
        Dim caseIdIntExtract As MatchCollection = Regex.Matches(TextBox1.Text, "\d+")
        Dim caseIdLettersExtract As MatchCollection = Regex.Matches(TextBox1.Text, "\D+")

        For caseId As Integer = CInt(caseIdIntExtract.Item(0).Value) To CInt(caseIdIntExtract.Item(0).Value) + CInt(TextBox2.Text) - 1
            theElementCollection2 = WebBrowser2.Document.GetElementsByTagName("input")
            For Each curElement As HtmlElement In theElementCollection2
                If curElement.GetAttribute("name") = "caseId" Then
                    curElement.SetAttribute("value", caseId.ToString + caseIdLettersExtract.Item(0).Value.ToString)
                ElseIf curElement.GetAttribute("value") = "Get Case" Then
                    curElement.InvokeMember("click")
                End If
            Next
            WaitForPageLoad()
            Dim webBrowserText = WebBrowser2.DocumentText

            'Prepare a regular expression object
            Dim myMatches As MatchCollection = Regex.Matches(webBrowserText, "<span class=""Value"">(.*?)</span>")

            '<-------------------------------------------- DEFENDANT SECTION ------------------------------->

            'NEED TO DO THE CASE IF THERE IS MULTIPLE DEFENDANTS I.E. 160887FL
            'HINT FOR MULTIOPLE DEFENDERS, EACH SINGLE DEFENDANT IS SEPARATED LIKE THIS DEFENDANT1 DATA <HR/> or <hr/> DEFENDANT 2 DATA <HR>... DEFENDANT N DATA <HR><ISSUES/OTHER PARTY>
            'DEFENDANT ATTORNEY

            '<-------------------------------------------- DEFENDANT SECTION 2.0 ------------------------------->
            'defendant name variables
            Dim myMatchesDefendants As MatchCollection
            Dim allDefendantsStr As String = ""
            Dim tblGenderCheck As Boolean = False
            Dim defendantNonMissingName As String = ""
            Dim defendantSamePlaintiffName As New List(Of String)

            'defendant attorney variables
            Dim myMatchesDefendantAttorneyInfo As MatchCollection
            Dim attorneyDefendantInfoNames1 As String = ""
            Dim attorneyDefendantInfoAddress1 = ""

            If webBrowserText.Contains("Other Party Information") Then
                myMatchesDefendants = Regex.Matches(webBrowserText, "(?s)<H5>Defendant Information</H5>(.*?)<H5>Other Party Information</H5>")
                myMatchesDefendantAttorneyInfo = Regex.Matches(webBrowserText, "(?s)<H6>Attorney\(s\) for the Defendant</H6>(.*?)<H5>Other Party Information</H5>")
            ElseIf webBrowserText.Contains("Interested Party Information") Then
                myMatchesDefendants = Regex.Matches(webBrowserText, "(?s)<H5>Defendant Information</H5>(.*?)<H5>Interested Party Information</H5>")
                myMatchesDefendantAttorneyInfo = Regex.Matches(webBrowserText, "(?s)<H6>Attorney\(s\) for the Defendant</H6>(.*?)<H5>Interested Party Information</H5>")
            Else
                myMatchesDefendants = Regex.Matches(webBrowserText, "(?s)<H5>Defendant Information</H5>(.*?)<H5>Issues Information</H5>")
                myMatchesDefendantAttorneyInfo = Regex.Matches(webBrowserText, "(?s)<H6>Attorney\(s\) for the Defendant</H6>(.*?)<H5>Issues Information</H5>")
            End If

            Dim myMatchesDefendantName As MatchCollection

            If myMatchesDefendants.Count <> 0 Then

                'defendant name section
                'ran into the error where the defendant did not have an address, thus causing my MatchesDefendantName to match to nothing
                If myMatchesDefendants.Item(0).Groups(0).Value.Contains("Address:") Then
                    myMatchesDefendantName = Regex.Matches(myMatchesDefendants.Item(0).Groups(0).Value, "(?s)<H5>Defendant Information</H5>(.*?)<span class=""FirstColumnPrompt"">Address:</span>")
                Else
                    myMatchesDefendantName = Regex.Matches(myMatchesDefendants.Item(0).Groups(0).Value, "(?s)<H5>Defendant Information</H5>(.*?)<hr/>")
                End If

                Dim defendantInfoNames As MatchCollection = Regex.Matches(myMatchesDefendantName.Item(0).Groups(0).Value, "<span class=""Value"">(.*?)</span>")
                    Dim defendantNameStr As String = ""

                    If defendantInfoNames.Item(0).Groups(1).Value.Contains(",") = True Then
                        defendantNameStr = (Regex.Matches(defendantInfoNames.Item(0).Groups(1).Value, ", (\D+)")).Item(0).Groups(1).Value.Trim
                    Else
                        defendantNameStr = defendantInfoNames.Item(0).Groups(1).Value
                    End If

                    Dim defendantNameStrSingle1 As String = (Regex.Matches(defendantNameStr, "(\w+)")).Item(0).Groups(1).Value

                    defendantSamePlaintiffName.Add(defendantNameStrSingle1)

                    For i As Integer = 0 To Database1DataSet1.Tables("tblGender").Rows.Count - 1
                        If String.Compare(defendantNameStrSingle1, Database1DataSet1.Tables("tblGender").Rows(i).Item(1).ToString) = 0 Then
                            tblGenderCheck = True
                            Database1DataSet1.tblGender.Rows(i)("instances") += 1
                            TblGenderTableAdapter.Update(Database1DataSet1.tblGender)
                            TblGenderTableAdapter.Fill(Database1DataSet1.tblGender)
                        End If
                    Next

                    'CHECKS THE WORDLIST IF THE NAME IS THERE AND WASN'T ALREADY IN THE DATABASE
                    If tblGenderCheck = False Then
                        Dim firstNameSingle As String = (Regex.Matches(defendantNameStr, "(\w+)")).Item(0).Groups(1).Value
                        Dim firstNameSingleLower As String = firstNameSingle.ToLower.Trim
                        Dim wordListGender As String = TestWordList1(firstNameSingleLower)
                        If wordListGender = "Male" Then
                            TblGenderTableAdapter.Insert(firstNameSingle, "M", 1)
                            tblGenderCheck = True
                        ElseIf wordListGender = "Female" Then
                            TblGenderTableAdapter.Insert(firstNameSingle, "F", 1)
                            tblGenderCheck = True
                        Else

                        End If
                    End If

                    If tblGenderCheck = False Then
                        Dim oForm As Form2
                        oForm = New Form2()
                        oForm.StringPass = defendantNameStr
                        oForm.ShowDialog()
                    End If

                    defendantNonMissingName = defendantInfoNames.Item(0).Groups(1).Value

                    'attorney name and address section
                    Dim defendant1Attorney As MatchCollection
                    If myMatchesDefendantAttorneyInfo.Count <> 0 Then
                        defendant1Attorney = Regex.Matches(myMatchesDefendantAttorneyInfo.Item(0).Groups(0).Value, "(?s)<H6>Attorney\(s\) for the Defendant</H6>(.*?)<hr/>")
                        If defendant1Attorney.Count <> 0 Then
                            Dim attorneyDefendantInfoNames As MatchCollection = Regex.Matches(defendant1Attorney.Item(0).Groups(0).Value, "(?s)<span class=""FirstColumnPrompt"">Name:</span>(.*?)<span class=""FirstColumnPrompt"">Address:</span>")

                            For Each curr As Match In attorneyDefendantInfoNames
                                For Each curr1 As Match In Regex.Matches(curr.Value, "<span class=""Value"">(.*?)</span>")
                                    attorneyDefendantInfoNames1 += curr1.Groups(1).Value + vbNewLine
                                Next
                            Next

                            Dim attorneyDefendantInfoAddress As MatchCollection = Regex.Matches(defendant1Attorney.Item(0).Groups(0).Value, "(?s)<span class=""FirstColumnPrompt"">Address:</span>(.*?)<span class=""FirstColumnPrompt"">Phone:</span>")

                        For Each curr As Match In attorneyDefendantInfoAddress
                            For Each curr1 As Match In Regex.Matches(curr.Value, "<span class=""Value"">(.*?)</span>")
                                attorneyDefendantInfoAddress1 += curr1.Groups(1).Value + " "
                            Next
                        Next
                        If attorneyDefendantInfoAddress1.Length <> 0 Then
                            attorneyDefendantInfoAddress1 = attorneyDefendantInfoAddress1.Substring(0, attorneyDefendantInfoAddress1.Length - 1)
                            attorneyDefendantInfoAddress1 = attorneyDefendantInfoAddress1.Replace("&amp;", "&")
                        End If

                    End If
                    End If

                    'additonal defendants section
                    Dim additionalDefendants As MatchCollection = Regex.Matches(myMatchesDefendants.Item(0).Groups(0).Value, "(?s)<hr/>(.*?)<hr/>")
                    tblGenderCheck = False

                    For Each curr As Match In additionalDefendants

                    'additional defendant names section
                    myMatchesDefendantName = Regex.Matches(curr.Groups(0).Value, "(?s)<hr/>(.*?)<span class=""FirstColumnPrompt"">Address:</span>")
                    If myMatchesDefendantName.Count = 0 Then
                        myMatchesDefendantName = Regex.Matches(curr.Groups(0).Value, "(?s)<hr/>(.*?)<hr/>")
                    End If
                    defendantInfoNames = Regex.Matches(myMatchesDefendantName.Item(0).Groups(0).Value, "<span class=""Value"">(.*?)</span>")
                        defendantNameStr = ""

                        If defendantInfoNames.Item(0).Groups(1).Value.Contains(",") = True Then
                            defendantNameStr = (Regex.Matches(defendantInfoNames.Item(0).Groups(1).Value, ", (\D+)")).Item(0).Groups(1).Value.Trim
                        Else
                            defendantNameStr = defendantInfoNames.Item(0).Groups(1).Value
                        End If

                        defendantNameStrSingle1 = (Regex.Matches(defendantNameStr, "(\w+)")).Item(0).Groups(1).Value
                        defendantSamePlaintiffName.Add(defendantNameStrSingle1)

                        For i As Integer = 0 To Database1DataSet1.Tables("tblGender").Rows.Count - 1
                            If String.Compare(defendantNameStrSingle1, Database1DataSet1.Tables("tblGender").Rows(i).Item(1).ToString) = 0 Then
                                tblGenderCheck = True
                                Database1DataSet1.tblGender.Rows(i)("instances") += 1
                                TblGenderTableAdapter.Update(Database1DataSet1.tblGender)
                                TblGenderTableAdapter.Fill(Database1DataSet1.tblGender)
                            End If
                        Next

                        'CHECKS THE WORDLIST IF THE NAME IS THERE AND WASN'T ALREADY IN THE DATABASE
                        If tblGenderCheck = False Then
                            Dim firstNameSingle As String = (Regex.Matches(defendantNameStr, "(\w+)")).Item(0).Groups(1).Value
                            Dim firstNameSingleLower As String = firstNameSingle.ToLower.Trim
                            Dim wordListGender As String = TestWordList1(firstNameSingleLower)
                            If wordListGender = "Male" Then
                                TblGenderTableAdapter.Insert(firstNameSingle, "M", 1)
                                tblGenderCheck = True
                            ElseIf wordListGender = "Female" Then
                                TblGenderTableAdapter.Insert(firstNameSingle, "F", 1)
                                tblGenderCheck = True
                            Else

                            End If
                        End If

                        If tblGenderCheck = False Then
                            Dim oForm As Form2
                            oForm = New Form2()
                            oForm.StringPass = defendantNameStr
                            oForm.ShowDialog()
                        End If

                        defendantNonMissingName = String.Concat(defendantNonMissingName, ",", defendantInfoNames.Item(0).Groups(1).Value)

                        'attorney name and address
                        defendant1Attorney = Regex.Matches(curr.Groups(0).Value, "(?s)<H6>Attorney\(s\) for the Defendant</H6>(.*?)<hr/>")
                        If defendant1Attorney.Count <> 0 Then
                            Dim attorneyDefendantInfoNames As MatchCollection = Regex.Matches(defendant1Attorney.Item(0).Groups(0).Value, "(?s)<span class=""FirstColumnPrompt"">Name:</span>(.*?)<span class=""FirstColumnPrompt"">Address:</span>")

                            For Each curr2 As Match In attorneyDefendantInfoNames
                                For Each curr1 As Match In Regex.Matches(curr2.Value, "<span class=""Value"">(.*?)</span>")
                                    attorneyDefendantInfoNames1 += curr1.Groups(1).Value + vbNewLine
                                Next
                            Next

                            Dim attorneyDefendantInfoAddress As MatchCollection = Regex.Matches(defendant1Attorney.Item(0).Groups(0).Value, "(?s)<span class=""FirstColumnPrompt"">Address:</span>(.*?)<span class=""FirstColumnPrompt"">Phone:</span>")

                            For Each curr2 As Match In attorneyDefendantInfoAddress
                                For Each curr1 As Match In Regex.Matches(curr2.Value, "<span class=""Value"">(.*?)</span>")
                                    attorneyDefendantInfoAddress1 += " "
                                    attorneyDefendantInfoAddress1 += curr1.Groups(1).Value + " "
                                Next
                            Next
                            attorneyDefendantInfoAddress1 = attorneyDefendantInfoAddress1.Substring(0, attorneyDefendantInfoAddress1.Length - 1)
                            attorneyDefendantInfoAddress1 = attorneyDefendantInfoAddress1.Replace("&amp;", "&")
                        End If
                    Next


                End If
                tblGenderCheck = False

            '<-------------------------------------------- DEFENDANT SECTION 2.0 END------------------------------->



            '<--------------------------------------------PLAINTIFF SECTION ------------------------------->

            'PLAINTIFF ATTORNEY
            Dim myMatchesAttorneyInfo As MatchCollection = Regex.Matches(webBrowserText, "(?s)<H6>Attorney\(s\) for the Plaintiff</H6>(.*?)<H5>Defendant Information</H5>")

            Dim attorneyInfoNames1 As String = ""
            Dim attorneyInfoAddress1 = ""

            If myMatchesAttorneyInfo.Count <> 0 Then
                Dim attorneyInfoNames As MatchCollection = Regex.Matches(myMatchesAttorneyInfo.Item(0).Groups(0).Value, "(?s)<span class=""FirstColumnPrompt"">Name:</span>(.*?)<span class=""FirstColumnPrompt"">Address:</span>")

                For Each curr As Match In attorneyInfoNames
                    For Each curr1 As Match In Regex.Matches(curr.Value, "<span class=""Value"">(.*?)</span>")
                        attorneyInfoNames1 += curr1.Groups(1).Value + vbNewLine
                    Next
                Next

                Dim attorneyInfoAddress As MatchCollection = Regex.Matches(myMatchesAttorneyInfo.Item(0).Groups(0).Value, "(?s)<span class=""FirstColumnPrompt"">Address:</span>(.*?)<span class=""FirstColumnPrompt"">Phone:</span>")
                'CHECKING FOR THE CASE 164406FL WITH ATTORNEY WITH NO PHONE, WHICH WOULD MESS UP THE REGEX ABOVE. INSTEAD OF GOING TO PHONE, GO TO </hr> for the end of the regex
                If attorneyInfoAddress.Count = 0 Then
                    If Regex.Matches(myMatchesAttorneyInfo.Item(0).Groups(0).Value, "Phone").Count = 0 Then
                        attorneyInfoAddress = Regex.Matches(myMatchesAttorneyInfo.Item(0).Groups(0).Value, "(?s)<span class=""FirstColumnPrompt"">Address:</span>(.*?)</table>")
                    End If
                End If

                For Each curr As Match In attorneyInfoAddress
                        For Each curr1 As Match In Regex.Matches(curr.Value, "<span class=""Value"">(.*?)</span>")
                            attorneyInfoAddress1 += curr1.Groups(1).Value + " "
                        Next
                    Next

                    attorneyInfoAddress1 = attorneyInfoAddress1.Substring(0, attorneyInfoAddress1.Length - 1)
                    attorneyInfoAddress1 = attorneyInfoAddress1.Replace("&amp;", "&")
                End If

                'PLANINTIFF GENDER AND NAME SECTION
                tblGenderCheck = False
            Dim firstName As String = ""
            TblGenderTableAdapter.Update(Database1DataSet1.tblGender)
            TblGenderTableAdapter.Fill(Database1DataSet1.tblGender)

            If myMatches.Count <> 0 And webBrowserText.Contains("Plaintiff Information") = True Then
                If myMatches.Item(5).Groups(1).Value.Contains(",") = True Then
                    firstName = (Regex.Matches(myMatches.Item(5).Groups(1).Value, ", (\D+)")).Item(0).Groups(1).Value.Trim
                Else
                    firstName = myMatches.Item(5).Groups(1).Value
                End If

                Dim firstNameSingle1 As String = (Regex.Matches(firstName, "(\w+)")).Item(0).Groups(1).Value
                Dim sameNameCheck As Boolean = False

                For Each curr As String In defendantSamePlaintiffName
                    If curr = firstNameSingle1 Then
                        sameNameCheck = True
                    End If
                Next

                If sameNameCheck = False Then
                    For i As Integer = 0 To Database1DataSet1.Tables("tblGender").Rows.Count - 1
                        If String.Compare(firstNameSingle1, Database1DataSet1.Tables("tblGender").Rows(i).Item(1).ToString) = 0 Then
                            tblGenderCheck = True
                            Database1DataSet1.tblGender.Rows(i)("instances") += 1
                            TblGenderTableAdapter.Update(Database1DataSet1.tblGender)
                            TblGenderTableAdapter.Fill(Database1DataSet1.tblGender)
                        End If
                    Next

                    'CHECKS THE WORDLIST IF THE NAME IS THERE AND WASN'T ALREADY IN THE DATABASE
                    If tblGenderCheck = False Then
                        Dim firstNameSingle As String = (Regex.Matches(firstName, "(\w+)")).Item(0).Groups(1).Value
                        Dim firstNameSingleLower As String = firstNameSingle.ToLower.Trim
                        Dim wordListGender As String = TestWordList1(firstNameSingleLower)
                        If wordListGender = "Male" Then
                            TblGenderTableAdapter.Insert(firstNameSingle, "M", 1)
                            tblGenderCheck = True
                        ElseIf wordListGender = "Female" Then
                            TblGenderTableAdapter.Insert(firstNameSingle, "F", 1)
                            tblGenderCheck = True
                        Else

                        End If
                    End If

                    If tblGenderCheck = False Then
                        Dim oForm As Form2
                        oForm = New Form2()
                        oForm.StringPass = firstName
                        oForm.ShowDialog()
                    End If
                Else
                    For i As Integer = 0 To Database1DataSet1.Tables("tblGender").Rows.Count - 1
                        If String.Compare(firstNameSingle1, Database1DataSet1.Tables("tblGender").Rows(i).Item(1).ToString) = 0 Then
                            tblGenderCheck = True
                            Database1DataSet1.tblGender.Rows(i)("instances") += 1
                            TblGenderTableAdapter.Update(Database1DataSet1.tblGender)
                            TblGenderTableAdapter.Fill(Database1DataSet1.tblGender)
                        End If
                    Next
                End If
            End If

            'ISSUES SECTION
            Dim myMatchesIssuesInfo As MatchCollection = Regex.Matches(webBrowserText, "(?s)<H5>Issues Information</H5>(.*?)<H5>Document Tracking</H5>")
            Dim issuesInfo1 As String = ""

            If myMatchesIssuesInfo.Count <> 0 Then
                Dim issuesInfo As MatchCollection = Regex.Matches(myMatchesIssuesInfo.Item(0).Groups(0).Value, "<span class=""Value"">(.*?)</span>")
                For Each curr As Match In issuesInfo
                    issuesInfo1 += curr.Groups(1).Value + ","
                Next
            End If

            'Have to update and fill gender when doing multiple case amounts at once (Amount > 1)
            TblGenderTableAdapter.Update(Database1DataSet1.tblGender)
            TblGenderTableAdapter.Fill(Database1DataSet1.tblGender)

            Dim caseIdFull = caseId.ToString + caseIdLettersExtract.Item(0).Value
            If issuesInfo1 <> "" Then
                issuesInfo1 = issuesInfo1.Substring(0, issuesInfo1.Length - 1)
            End If

            'Checks whether the Plaintiff information is missing
            Dim dateCase As Date = Nothing
            Dim plaintiffName As String = ""
            Dim caseStatus As String = ""

            If myMatches.Count <> 0 Then
                dateCase = myMatches.Item(3).Groups(1).Value
                If webBrowserText.Contains("Plaintiff Information") = True Then
                    plaintiffName = myMatches.Item(5).Groups(1).Value
                End If
                caseStatus = myMatches.Item(4).Groups(1).Value
            End If

            '160293FL Case for Defendant Attorney
            'Updating the Microsoft Access Database
            'CASE 160496fl
            'THE FIELD IS TOO SMALL TO ACCEPT THE DATA, REGEX FUCKED UP? CASE 160496FL, THE INCLUSION OF AN OTHER PARTY SECTION FUCKED UP THE REGEX?
            'PROBABLY IN THE DEFENDANT REGEX SECTION BECAUSE IT GOES TO ISSUES, THE INCLUSION OF OTHER PARTY FUCKS IT UP, DO AN IF .CONTAINS OTHER PARTY TO FIX
            'NEW ERROR, CASE 160887FL, THE CASE OF MULTIPLE DEFENDANTS, DEFENDANT SECTIONS SEPARATED USING AN <HR> TAG
            If issuesInfo1.Length >= 50 Then
                issuesInfo1 = issuesInfo1.Substring(0, 50)
            End If
            'MsgBox("CaseId:" + caseIdFull + vbNewLine +
            '  "dateCase:" + dateCase + vbNewLine +
            '"plaintiffName:" + plaintiffName + vbNewLine +
            '"caseStatus:" + caseStatus + vbNewLine +
            '"attorneyAddress:" + attorneyInfoAddress1 + vbNewLine +
            '"attorneyNames:" + attorneyInfoNames1 + vbNewLine +
            '"defendantName:" + defendantNonMissingName + vbNewLine +
            '"issues:" + issuesInfo1 + vbNewLine +
            '"attorneyDefendants:" + attorneyDefendantInfoNames1 + vbNewLine +
            '"attorneyDefendantAddress:" + attorneyDefendantInfoAddress1)
            If attorneyInfoAddress1.Length > 255 Then
                attorneyInfoAddress1 = attorneyInfoAddress1.Substring(0, 254)
            End If
            If attorneyDefendantInfoAddress1.Length > 255 Then
                attorneyDefendantInfoAddress1 = attorneyDefendantInfoAddress1.Substring(0, 254)
            End If

            Table1TableAdapter1.Insert(caseIdFull, dateCase, plaintiffName, caseStatus, attorneyInfoAddress1,
                                   attorneyInfoNames1, defendantNonMissingName, issuesInfo1, attorneyDefendantInfoNames1, attorneyDefendantInfoAddress1, webBrowserText)
            'Table1TableAdapter1.Fill(Database1DataSet1.Table1)
            WebBrowser2.GoBack()
            WaitForPageLoad()
        Next

        TableAdapterManager1.UpdateAll(Database1DataSet1)
        'TblGenderTableAdapter.Fill(Database1DataSet1.tblGender)
        MsgBox("Raw Data Gathered")

    End Sub

    'Clear Table1
    Private Sub clearRawData(sender As Object, e As EventArgs) Handles Button5.Click
        For i As Integer = 0 To Database1DataSet1.Tables("Table1").Rows.Count - 1
            Database1DataSet1.Table1.Rows.Item(i).Delete()
            'MsgBox("Got in here")
        Next
        'ALWAYS MAKE SURE YOU UPDATE THEN FILL, THAT'S THE CORRECT WAY TO AFFECT TABLEADAPTERS
        Table1TableAdapter1.Update(Database1DataSet1.Table1)
        Table1TableAdapter1.Fill(Database1DataSet1.Table1)
    End Sub

    'Clear tblGender
    Private Sub clearTblGender(sender As Object, e As EventArgs) Handles Button6.Click
        For i As Integer = 0 To Database1DataSet1.Tables("tblGender").Rows.Count - 1
            Database1DataSet1.tblGender.Rows.Item(i).Delete()
            'MsgBox("Got in here")
        Next
        'ALWAYS MAKE SURE YOU UPDATE THEN FILL, THAT'S THE CORRECT WAY TO AFFECT TABLEADAPTERS
        TblGenderTableAdapter.Update(Database1DataSet1.tblGender)
        TblGenderTableAdapter.Fill(Database1DataSet1.tblGender)
    End Sub

    'tblAnalyzedData
    Private Sub tblAnalyzedData(sender As Object, e As EventArgs) Handles Button7.Click

        '1) CLEAR OUT THE ENTIRE DATABASE TO MAKE A NEW ONE
        For i As Integer = 0 To Database1DataSet1.Tables("tblAnalyzedData").Rows.Count - 1
            Database1DataSet1.tblAnalyzedData.Rows.Item(i).Delete()
            'MsgBox("Got in here")
        Next

        'ALWAYS MAKE SURE YOU UPDATE THEN FILL, THAT'S THE CORRECT WAY TO AFFECT TABLEADAPTERS
        TblAnalyzedDataTableAdapter.Update(Database1DataSet1.tblAnalyzedData)
        TblAnalyzedDataTableAdapter.Fill(Database1DataSet1.tblAnalyzedData)

        '2) FILL THE DATABASE WITH THE SAME FIELDS AS Table1 (Raw Data), but add two new fields at the end of plaintiffGender and defendantGender
        For i As Integer = 0 To Database1DataSet1.Tables("Table1").Rows.Count - 1
            Dim plaintiffGender As String = ""
            Dim defendantGender As String = ""
            Dim plaintiffName As String = ""
            Dim defendantName As String = ""

            If Database1DataSet1.Tables("Table1").Rows(i).Item(3).ToString.Contains(",") = True Then
                plaintiffName = (Regex.Matches(Database1DataSet1.Tables("Table1").Rows(i).Item(3).ToString, ", (\D+)")).Item(0).Groups(1).Value.Trim
                plaintiffName = (Regex.Matches(plaintiffName, "(\w+)")).Item(0).Groups(1).Value
            Else
                plaintiffName = Database1DataSet1.Tables("Table1").Rows(i).Item(3).ToString
            End If

            If Database1DataSet1.Tables("Table1").Rows(i).Item(8).ToString.Contains(",") = True Then
                defendantName = (Regex.Matches(Database1DataSet1.Tables("Table1").Rows(i).Item(8).ToString, ", (\D+)")).Item(0).Groups(1).Value.Trim
                defendantName = (Regex.Matches(defendantName, "(\w+)")).Item(0).Groups(1).Value
            Else
                defendantName = Database1DataSet1.Tables("Table1").Rows(i).Item(8).ToString
            End If

            For j As Integer = 0 To Database1DataSet1.Tables("tblGender").Rows.Count - 1
                'Item(2) in .Rows(i) is plaintiffName
                If String.Compare(plaintiffName, Database1DataSet1.Tables("tblGender").Rows(j).Item(1).ToString) = 0 Then
                    'MsgBox("plaintiffGender Found: " + Database1DataSet1.Tables("tblGender").Rows(j).Item(2).ToString)
                    plaintiffGender = Database1DataSet1.Tables("tblGender").Rows(j).Item(2).ToString
                End If
            Next

            For j As Integer = 0 To Database1DataSet1.Tables("tblGender").Rows.Count - 1
                'Item(2) in .Rows(i) is plaintiffName
                If String.Compare(defendantName, Database1DataSet1.Tables("tblGender").Rows(j).Item(1).ToString) = 0 Then
                    'MsgBox("defendantGender Found: " + Database1DataSet1.Tables("tblGender").Rows(j).Item(2).ToString)
                    defendantGender = Database1DataSet1.Tables("tblGender").Rows(j).Item(2).ToString
                End If
            Next

            TblAnalyzedDataTableAdapter.Insert(Database1DataSet1.Tables("Table1").Rows(i).Item(1).ToString,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(2).ToString,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(3).ToString,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(4).ToString,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(5).ToString,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(6).ToString,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(7).ToString,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(8).ToString,
                                               plaintiffGender,
                                               defendantGender,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(10).ToString,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(9).ToString,
                                               Database1DataSet1.Tables("Table1").Rows(i).Item(11).ToString)
        Next
        TblAnalyzedDataTableAdapter.Update(Database1DataSet1.tblAnalyzedData)
        TblAnalyzedDataTableAdapter.Fill(Database1DataSet1.tblAnalyzedData)
    End Sub

    'Testing if wordlist.txt files can be used in order to screen male and female names automating Form2, in the case of 200 cases
    'FIXED: WE CAN,NOT VERY GOOD AS THE WORDLISTS ARE NOT COMPREHENSIVE
    Private Sub TestWordList(sender As Object, e As EventArgs) Handles Button8.Click
        'matches henry and henryetta #FIXED USING .SPLIT OF MALE AND FEMALE TXT
        MsgBox(TestWordList1("henry"))
        MsgBox(TestWordList1("aaren"))
        MsgBox(TestWordList1("abbey"))
        If TestWordList1("deandre") = "None" Then
            MsgBox("None")
        End If
    End Sub

    Private Function TestWordList1(str As String)
        Dim txt As String
        Dim txt1 As String
        txt = My.Computer.FileSystem.ReadAllText("C:\Users\Christopher Nguyen\Downloads\malenamewordlist.txt")
        txt1 = My.Computer.FileSystem.ReadAllText("C:\Users\Christopher Nguyen\Downloads\femalenamewordlist.txt")

        Dim arrMale As Array = txt.Split()
        Dim arrFemale As Array = txt1.Split()
        Dim arrMFound As Boolean = False
        Dim arrFFound As Boolean = False
        'ArrLength:3903, FArrLength:4961

        For Each curr As String In arrMale
            If StrComp(str, curr) = 0 Then
                arrMFound = True
            End If
        Next
        For Each curr As String In arrFemale
            If StrComp(str, curr) = 0 Then
                arrFFound = True
            End If
        Next
        If arrMFound And arrFFound Then
            Return "Both"
        ElseIf arrMFound Then
            Return "Male"
        ElseIf arrFFound Then
            Return "Female"
        Else
            Return "None"

        End If
    End Function

    Private Sub testing(sender As Object, e As EventArgs) Handles Button9.Click
        For i As Integer = 1 To 1
            MsgBox("Test")
        Next


    End Sub

    Private Sub clearAll(sender As Object, e As EventArgs) Handles Button2.Click
        clearRawData(sender, e)
        clearTblGender(sender, e)
        tblAnalyzedData(sender, e)
    End Sub

    Private Sub clearTblAnalyzedData(sender As Object, e As EventArgs) Handles Button10.Click
        For i As Integer = 0 To Database1DataSet1.Tables("tblAnalyzedData").Rows.Count - 1
            Database1DataSet1.tblAnalyzedData.Rows.Item(i).Delete()
            'MsgBox("Got in here")
        Next
        'ALWAYS MAKE SURE YOU UPDATE THEN FILL, THAT'S THE CORRECT WAY TO AFFECT TABLEADAPTERS
        TblAnalyzedDataTableAdapter.Update(Database1DataSet1.tblAnalyzedData)
        TblAnalyzedDataTableAdapter.Fill(Database1DataSet1.tblAnalyzedData)
        MsgBox("Cleared tblAnalyzedData")
    End Sub

    Private Sub clearTblGenderInstances(sender As Object, e As EventArgs) Handles Button11.Click
        For i As Integer = 0 To Database1DataSet1.Tables("tblGender").Rows.Count - 1
            Database1DataSet1.tblGender.Rows(i)("instances") = 0
        Next
        TblGenderTableAdapter.Update(Database1DataSet1.tblGender)
        TblGenderTableAdapter.Fill(Database1DataSet1.tblGender)
        MsgBox("TblGender Instances Cleared")
    End Sub

    'Methods Auto-Loaded for Binding Navigatorwhen I added the Data set stuff from the test Database https://www.youtube.com/watch?v=F-A90eIzV9Y, did not need them, so they were deleted

End Class
