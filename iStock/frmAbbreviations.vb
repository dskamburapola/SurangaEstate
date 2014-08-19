Imports iStockCommon.iStockCompany
Imports iStockCommon.iStockConstants
Public Class frmAbbreviations

#Region "Properties"
    Private _CWBCompany As iStockCommon.iStockCompany
#End Region

#Region "Constructors"

    Public ReadOnly Property CWBCompany() As iStockCommon.iStockCompany
        Get

            If _CWBCompany Is Nothing Then
                _CWBCompany = New iStockCommon.iStockCompany
            End If

            Return _CWBCompany
        End Get
    End Property
#End Region







    '#Region "Save Company"
    '    Private Sub SaveCompany()

    '        Try
    '            With CWBCompany
    '                .CompanyName = Me.teCompanyName.Text.Trim
    '                .Address1 = Me.teAddressLine1.Text.Trim
    '                .Address2 = Me.teAddressLine2.Text.Trim
    '                .Telephone = Me.teTelephone.Text.Trim
    '                .Fax = Me.teFax.Text.Trim
    '                .Email = Me.teEmail.Text.Trim
    '                .WebURL = Me.teWebURL.Text.Trim
    '                .RegNo = Me.teRegNo.Text.Trim
    '                .InsertCompany()
    '                Dim frm As New frmSavedOk
    '                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
    '                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
    '                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
    '                frm.ShowDialog()
    '            End With

    '        Catch ex As Exception
    '            MessageError(ex.ToString)
    '        End Try




    '    End Sub
    '#End Region



End Class