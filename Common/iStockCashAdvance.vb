Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Public Class iStockCashAdvance

#Region "Variables"

    Private _CashRewardsID As Int64
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

    Public Property CashRewardsID() As Int64
        Get
            Return _CashRewardsID
        End Get
        Set(ByVal value As Int64)
            _CashRewardsID = value
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

#Region "Cash Advance Get All By Dates"
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

#Region "CashAdvance Delete"
    Public Sub CashAdvanceDelete()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(CASHADVANCE_DELETE)
            DB.AddInParameter(DBC, "@CashAdvanceId ", DbType.Int64, Me.CashRewardsID)
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

#Region "Insert CashRewards"
    Public Sub InsertCashRewards()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(CASHREWARDS_INSERT)
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

#Region "Cash Rewards Get All By Dates"
    Public Function CashRewardsGetAllByDates() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(CASHREWARDS_GETALL_BYDATES)
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

#Region "CashRewards Delete"
    Public Sub CashRewardsDelete()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(CASHREWARDS_DELETE)
            DB.AddInParameter(DBC, "@CashRewardsId ", DbType.Int64, Me.CashRewardsID)
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

    '----------------------------------------- Festival Recovery ------------------------------------

#Region "Insert Festival Recovery"
    Public Sub InsertFestivalRecovery()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(FESTIVALRECOVERY_INSERT)
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

#Region "Festival Recovery Delete"
    Public Sub FestivalRecoveryDelete()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(FESTIVALRECOVERY_DELETE)
            DB.AddInParameter(DBC, "FestivalRecoveryId", DbType.Int64, Me.CashAdvanceID)
            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try

    End Sub
#End Region

#Region "Festival Recovery Get All By Dates"
    Public Function FestivalRecoveryGetAllByDates() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(FESTIVALRECOVERY_GETALL_BYDATES)
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
End Class
