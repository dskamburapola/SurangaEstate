Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Public Class iStockCashAdvance

#Region "Variables"

    Private _CashAdvanceID As Int64

    Private _CWorkedDays As Decimal
    Private _PWorkedDays As Decimal
    Private _CAmount As Decimal
    Private _PAmount As Decimal
    Private _FestivalAdvance As Decimal
    Private _Loan As Decimal
    Private _CashAdvance As Decimal
    Private _IssueDate As Date
    Private _AdvanceAmount As Decimal


    Private _DailyWorkingID As Int64
    Private _WorkingDate As Date
    Private _StartDate As Date
    Private _EndDate As Date
    Private _WorkType As String
    Private _AbbreviationID As Int64
    Private _EmployeeID As Int64
    Private _WorkedDays As Double
    Private _Quantity As Double


    Private _DayRate As Int64
    Private _OTRate As Int64
    Private _KgsPerDay As Int64
    Private _EPF As Int64
    Private _OverKgRate As Int64

    Private _CasualPayRate As Decimal
    Private _CasualOTPayRate As Decimal

    Private _CreatedBy As Int64
    Private _CreatedDate As DateTime
    Private _UpdatedBy As Int64
    Private _UpdatedDate As DateTime
#End Region

#Region "Properties"


    Public Property CashAdvanceID() As Int64
        Get
            Return _CashAdvanceID
        End Get
        Set(ByVal value As Int64)
            _CashAdvanceID = value
        End Set
    End Property

    Public Property CWorkedDays() As Decimal
        Get
            Return _CWorkedDays
        End Get
        Set(ByVal value As Decimal)
            _CWorkedDays = value
        End Set
    End Property

    Public Property PWorkedDays() As Decimal
        Get
            Return _PWorkedDays
        End Get
        Set(ByVal value As Decimal)
            _PWorkedDays = value
        End Set
    End Property

    Public Property CAmount() As Decimal
        Get
            Return _CAmount
        End Get
        Set(ByVal value As Decimal)
            _CAmount = value
        End Set
    End Property

    Public Property FestivalAdvance() As Decimal
        Get
            Return _FestivalAdvance
        End Get
        Set(ByVal value As Decimal)
            _FestivalAdvance = value
        End Set
    End Property


    Public Property Loan() As Decimal
        Get
            Return _Loan
        End Get
        Set(ByVal value As Decimal)
            _Loan = value
        End Set
    End Property

    Public Property CashAdvance() As Decimal
        Get
            Return _CashAdvance
        End Get
        Set(ByVal value As Decimal)
            _CashAdvance = value
        End Set
    End Property

    Public Property IssueDate() As Date
        Get
            Return _IssueDate
        End Get
        Set(ByVal value As Date)
            _IssueDate = value
        End Set
    End Property

    Public Property AdvanceAmount() As Decimal
        Get
            Return _AdvanceAmount
        End Get
        Set(ByVal value As Decimal)
            _AdvanceAmount = value
        End Set
    End Property


    Public Property DailyWorkingID() As Int64
        Get
            Return _DailyWorkingID
        End Get
        Set(ByVal value As Int64)
            _DailyWorkingID = value
        End Set
    End Property

    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get
        Set(ByVal value As Date)
            _StartDate = value
        End Set
    End Property

    Public Property EndDate() As Date
        Get
            Return _EndDate
        End Get
        Set(ByVal value As Date)
            _EndDate = value
        End Set
    End Property

    Public Property WorkingDate() As Date
        Get
            Return _WorkingDate
        End Get
        Set(ByVal value As Date)
            _WorkingDate = value
        End Set
    End Property
    Public Property WorkType() As String
        Get
            Return _WorkType
        End Get
        Set(ByVal value As String)
            _WorkType = value
        End Set
    End Property
    Public Property AbbreviationID() As Int64
        Get
            Return _AbbreviationID
        End Get
        Set(ByVal value As Int64)
            _AbbreviationID = value
        End Set
    End Property

    Public Property EmployeeID() As Int64
        Get
            Return _EmployeeID
        End Get
        Set(ByVal value As Int64)
            _EmployeeID = value
        End Set
    End Property







    Public Property WorkedDays() As Double
        Get
            Return _WorkedDays
        End Get
        Set(ByVal value As Double)
            _WorkedDays = value
        End Set
    End Property
    Public Property Quantity() As Double
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Double)
            _Quantity = value
        End Set
    End Property

    Public Property DayRate() As Int64
        Get
            Return _DayRate
        End Get
        Set(ByVal value As Int64)
            _DayRate = value
        End Set
    End Property
    Public Property OTRate() As Int64
        Get
            Return _OTRate
        End Get
        Set(ByVal value As Int64)
            _OTRate = value
        End Set
    End Property
    Public Property KgsPerDay() As Int64
        Get
            Return _KgsPerDay
        End Get
        Set(ByVal value As Int64)
            _KgsPerDay = value
        End Set
    End Property

    Public Property EPF() As Int64
        Get
            Return _EPF
        End Get
        Set(ByVal value As Int64)
            _EPF = value
        End Set
    End Property
    Public Property OverKgRate() As Int64
        Get
            Return _OverKgRate
        End Get
        Set(ByVal value As Int64)
            _OverKgRate = value
        End Set
    End Property

    Public Property CasualPayRate() As Decimal
        Get
            Return _CasualPayRate
        End Get
        Set(ByVal value As Decimal)
            _CasualPayRate = value
        End Set
    End Property
    Public Property CasualOTPayRate() As Decimal
        Get
            Return _CasualOTPayRate
        End Get
        Set(ByVal value As Decimal)
            _CasualOTPayRate = value
        End Set
    End Property

    Public Property CreatedBy() As Int64
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As Int64)
            _CreatedBy = value
        End Set
    End Property
    Public Property CreatedDate() As DateTime
        Get
            Return _CreatedDate
        End Get
        Set(ByVal value As DateTime)
            _CreatedDate = value
        End Set
    End Property
    Public Property UpdatedBy() As Int64
        Get
            Return _UpdatedBy
        End Get
        Set(ByVal value As Int64)
            _UpdatedBy = value
        End Set
    End Property
    Public Property UpdatedDate() As DateTime
        Get
            Return _UpdatedDate
        End Get
        Set(ByVal value As DateTime)
            _UpdatedDate = value
        End Set
    End Property
#End Region

#Region "Insert Daily Working"
    Public Sub InsertDailyWorking()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(DAILYWORKING_INSERT)
            DB.AddInParameter(DBC, "@WorkingDate", DbType.Date, Me.WorkingDate)
            DB.AddInParameter(DBC, "@WorkType", DbType.String, Me.WorkType)
            DB.AddInParameter(DBC, "@AbbreviationID", DbType.Int64, Me.AbbreviationID)
            DB.AddInParameter(DBC, "@EmployeeID", DbType.Int64, Me.EmployeeID)
            DB.AddInParameter(DBC, "@WorkedDays", DbType.Double, Me.WorkedDays)
            DB.AddInParameter(DBC, "@Quantity", DbType.Double, Me.Quantity)

            DB.AddInParameter(DBC, "@DayRate", DbType.Double, Me.DayRate)
            DB.AddInParameter(DBC, "@OTRate", DbType.Double, Me.OTRate)
            DB.AddInParameter(DBC, "@KgsPerDay", DbType.Double, Me.KgsPerDay)
            DB.AddInParameter(DBC, "@OverKgRate", DbType.Double, Me.OverKgRate)
            DB.AddInParameter(DBC, "@EPF", DbType.Double, Me.EPF)
            DB.AddInParameter(DBC, "@CasualPayRate", DbType.Double, Me.CasualPayRate)
            DB.AddInParameter(DBC, "@CasualOTPayRate", DbType.Double, Me.CasualOTPayRate)




            DB.AddInParameter(DBC, "@CreatedBy", DbType.Double, Me.CreatedBy)


            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "DailyWorking GetBy Date"
    Public Function DailyWorkingGetByDate() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(DAILYWORKING_GETBY_DATE)
            DB.AddInParameter(DBC, "@WorkingDate", DbType.Date, Me.WorkingDate)
            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

#Region "Daily Working GetAll ByDates"
    Public Function CashAdvanceGetAllByDates() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(CASHADVANCE_GETALL_BYDATES)
            DB.AddInParameter(DBC, "@StartDate", DbType.Date, Me.StartDate)
            DB.AddInParameter(DBC, "@EndDate", DbType.Date, Me.EndDate)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

#Region "DailyWorking Delete"
    Public Sub CashAdvanceDelete()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(CASHADVANCE_DELETE)
            DB.AddInParameter(DBC, "@CashAdvanceId ", DbType.Int64, Me.CashAdvanceID)
            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try

    End Sub
#End Region

#Region "Get Employee For Work"
    Public Function GetEmployeeForWork() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(EMPLOYEE_GETALL_WORKERS)
            DB.AddInParameter(DBC, "@Designation", DbType.String, Me.WorkType)
            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

#Region "Insert CashAdvance"
    Public Sub InsertCashAdvance()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(CASHADVANCE_INSERT)
            DB.AddInParameter(DBC, "@EmployerId", DbType.Int64, Me.EmployeeID)
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, Me.IssueDate)
            DB.AddInParameter(DBC, "@AdvanceAmount", DbType.Decimal, Me.AdvanceAmount)

            DB.AddInParameter(DBC, "@CreatedBy", DbType.Int64, Me.CreatedBy)
            DB.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, Me.UpdatedBy)




            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Get Payment Details for Advance"
    Public Function GetPaymentDetailsForAdvance() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(EMPLOYEE_CALCULATEADVANCE)
            DB.AddInParameter(DBC, "@EmployeeID", DbType.Int64, Me.EmployeeID)
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, Me.IssueDate)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

    '#Region "Get CashAdvance By CashAdvanceID"
    '    Public Sub GetCustomerByID()
    '        Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
    '        Dim DBC As DbCommand = DB.GetStoredProcCommand(CUSTOMERS_GETBYID)
    '        Try

    '            DB.AddInParameter(DBC, "@CashAdvanceID", DbType.Int64, Me.CashAdvanceID)
    '            Using DR As IDataReader = DB.ExecuteReader(DBC)


    '                With DR
    '                    Do While .Read
    '                        Me.CustomerID = Convert.ToInt64(IIf(Not IsDBNull(.Item("CustomerID")), Trim(.Item("CustomerID").ToString), 0))
    '                        Me.CustomerNo = IIf(Not IsDBNull(.Item("CustomerNo")), Trim(.Item("CustomerNo").ToString), String.Empty)
    '                        Me.Salutation = IIf(Not IsDBNull(.Item("Salutation")), Trim(.Item("Salutation").ToString), String.Empty)

    '                        Me.CustomerName = IIf(Not IsDBNull(.Item("CustomerName")), Trim(.Item("CustomerName").ToString), String.Empty)
    '                        Me.AddressLine1 = IIf(Not IsDBNull(.Item("AddressLine1")), Trim(.Item("AddressLine1").ToString), String.Empty)
    '                        Me.AddressLine2 = IIf(Not IsDBNull(.Item("AddressLine2")), Trim(.Item("AddressLine2").ToString), String.Empty)
    '                        Me.AddressLine3 = IIf(Not IsDBNull(.Item("AddressLine3")), Trim(.Item("AddressLine3").ToString), String.Empty)
    '                        Me.Telephone = IIf(Not IsDBNull(.Item("Telephone")), Trim(.Item("Telephone").ToString), String.Empty)
    '                        Me.Fax = IIf(Not IsDBNull(.Item("Fax")), Trim(.Item("Fax").ToString), String.Empty)
    '                        Me.Email = IIf(Not IsDBNull(.Item("Email")), Trim(.Item("Email").ToString), String.Empty)
    '                        Me.WebURL = IIf(Not IsDBNull(.Item("WebURL")), Trim(.Item("WebURL").ToString), String.Empty)
    '                        Me.CreatedBy = Convert.ToInt64(IIf(Not IsDBNull(.Item("CreatedBy")), Trim(.Item("CreatedBy").ToString), 0))
    '                        Me.UpdatedBy = Convert.ToInt64(IIf(Not IsDBNull(.Item("UpdatedBy")), Trim(.Item("UpdatedBy").ToString), 0))



    '                    Loop
    '                End With

    '                If (Not DR Is Nothing) Then
    '                    DR.Close()
    '                End If


    '            End Using



    '        Catch ex As Exception
    '            Throw
    '        Finally
    '            DBC.Dispose()



    '        End Try


    '    End Sub
    '#End Region


End Class
