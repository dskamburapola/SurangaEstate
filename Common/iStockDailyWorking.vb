Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Public Class iStockDailyWorking

#Region "Variables"
    Private _DailyWorkingID As Int64
    Private _WorkingDate As Date
    Private _StartDate As Date
    Private _EndDate As Date
    Private _WorkType As String
    Private _AbbreviationID As Int64
    Private _EmployeeID As Int64
    Private _WorkedDays As Double
    Private _Quantity As Double

    Private _CheckDays As Double
    Private _CheckEmployeeID As Int64

    Private _DayRate As Double
    Private _OTRate As Double
    Private _KgsPerDay As Double
    Private _EPF As Double
    Private _OverKgRate As Double

    Private _CasualPayRate As Decimal
    Private _CasualOTPayRate As Decimal

    Private _CreatedBy As Int64
    Private _CreatedDate As DateTime
    Private _UpdatedBy As Int64
    Private _UpdatedDate As DateTime

    Private _Designation As String
    Private _RubberLtrs As Decimal

    Private _PayChitCost As Decimal
    Private _DevalutionAllowance As Decimal
    Private _IncentiveDays As Decimal
    Private _IncentiveRate As Decimal

    Private _ETF As Decimal
    Private _WCPay As Decimal

    Private _IsDeleted As Boolean

    Private _StockID As Int64

#End Region

#Region "Properties"

    Public Property StockID() As Int64
        Get
            Return _StockID
        End Get
        Set(ByVal value As Int64)
            _StockID = value
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

    Public Property CheckEmployeeID() As Int64
        Get
            Return _CheckEmployeeID
        End Get
        Set(ByVal value As Int64)
            _CheckEmployeeID = value
        End Set
    End Property

    Public Property CheckDays() As Double
        Get
            Return _CheckDays
        End Get
        Set(ByVal value As Double)
            _CheckDays = value
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

    Public Property DayRate() As Double
        Get
            Return _DayRate
        End Get
        Set(ByVal value As Double)
            _DayRate = value
        End Set
    End Property
    Public Property OTRate() As Double
        Get
            Return _OTRate
        End Get
        Set(ByVal value As Double)
            _OTRate = value
        End Set
    End Property
    Public Property KgsPerDay() As Double
        Get
            Return _KgsPerDay
        End Get
        Set(ByVal value As Double)
            _KgsPerDay = value
        End Set
    End Property
  
    Public Property EPF() As Double
        Get
            Return _EPF
        End Get
        Set(ByVal value As Double)
            _EPF = value
        End Set
    End Property
    Public Property OverKgRate() As Double
        Get
            Return _OverKgRate
        End Get
        Set(ByVal value As Double)
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

    Public Property Designation() As String
        Get
            Return _Designation
        End Get
        Set(ByVal value As String)
            _Designation = value
        End Set
    End Property

    Public Property RubberLtrs() As Decimal
        Get
            Return _RubberLtrs
        End Get
        Set(ByVal value As Decimal)
            _RubberLtrs = value
        End Set
    End Property

    Public Property PayChitCost() As Decimal
        Get
            Return _PayChitCost
        End Get
        Set(ByVal value As Decimal)
            _PayChitCost = value
        End Set
    End Property
    Public Property DevalutionAllowance() As Decimal
        Get
            Return _DevalutionAllowance
        End Get
        Set(ByVal value As Decimal)
            _DevalutionAllowance = value
        End Set
    End Property
    Public Property IncentiveDays() As Decimal
        Get
            Return _IncentiveDays
        End Get
        Set(ByVal value As Decimal)
            _IncentiveDays = value
        End Set
    End Property
    Public Property IncentiveRate() As Decimal
        Get
            Return _IncentiveRate
        End Get
        Set(ByVal value As Decimal)
            _IncentiveRate = value
        End Set
    End Property

    Public Property ETF() As Decimal
        Get
            Return _ETF
        End Get
        Set(ByVal value As Decimal)
            _ETF = value
        End Set
    End Property
    Public Property WCPay() As Decimal
        Get
            Return _WCPay
        End Get
        Set(ByVal value As Decimal)
            _WCPay = value
        End Set
    End Property
    Public Property IsDeleted() As Boolean
        Get
            Return _IsDeleted
        End Get
        Set(ByVal value As Boolean)
            _IsDeleted = value
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
            DB.AddInParameter(DBC, "@WorkedDays", DbType.Decimal, Me.WorkedDays)
            DB.AddInParameter(DBC, "@Quantity", DbType.Decimal, Me.Quantity)
            DB.AddInParameter(DBC, "@DayRate", DbType.Decimal, Me.DayRate)
            DB.AddInParameter(DBC, "@OTRate", DbType.Decimal, Me.OTRate)
            DB.AddInParameter(DBC, "@KgsPerDay", DbType.Decimal, Me.KgsPerDay)
            DB.AddInParameter(DBC, "@OverKgRate", DbType.Decimal, Me.OverKgRate)
            '-------
            DB.AddInParameter(DBC, "@WCPayRate", DbType.Decimal, Me.WCPay)
            DB.AddInParameter(DBC, "@DevalutionRate", DbType.Decimal, Me.IncentiveRate)
            DB.AddInParameter(DBC, "@DevaluationDays", DbType.Decimal, Me.IncentiveDays)
            DB.AddInParameter(DBC, "@PayChit", DbType.Decimal, Me.PayChitCost)

            '-------

            DB.AddInParameter(DBC, "@EPF", DbType.Decimal, Me.EPF)
            DB.AddInParameter(DBC, "@CasualPayRate", DbType.Decimal, Me.CasualPayRate)
            DB.AddInParameter(DBC, "@CasualOTPayRate", DbType.Decimal, Me.CasualOTPayRate)
            DB.AddInParameter(DBC, "@IsDeleted", DbType.Boolean, Me.IsDeleted)
            DB.AddInParameter(DBC, "@CreatedBy", DbType.Int64, Me.CreatedBy)
            DB.AddInParameter(DBC, "@StockID", DbType.Int64, Me.StockID)


            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Update Rates"
    Public Sub UpdateRates()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(DAILYWORKING_UPDATERATE)
            DB.AddInParameter(DBC, "@DailyWorkingID", DbType.Int64, Me.DailyWorkingID)
            DB.AddInParameter(DBC, "@DayRate", DbType.Decimal, Me.DayRate)
            DB.AddInParameter(DBC, "@OTRate", DbType.Decimal, Me.OTRate)
            DB.AddInParameter(DBC, "@KgsPerDay", DbType.Decimal, Me.KgsPerDay)
            DB.AddInParameter(DBC, "@OverKgRate", DbType.Decimal, Me.OverKgRate)
            DB.AddInParameter(DBC, "@EPF", DbType.Decimal, Me.EPF)
            DB.AddInParameter(DBC, "@CasualPayRate", DbType.Decimal, Me.CasualPayRate)
            DB.AddInParameter(DBC, "@CasualOTPayRate", DbType.Decimal, Me.CasualOTPayRate)
            'DB.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, Me.UpdatedBy)

            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Get RubberLtrs By Date"
    Public Sub GetRubberLtrByDate()
        Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
        Dim DBC As DbCommand = DB.GetStoredProcCommand(GETRUBBERLTRSBYDATE)
        Try

            DB.AddInParameter(DBC, "@WorkingDate", DbType.Date, Me.WorkingDate)
            Using DR As IDataReader = DB.ExecuteReader(DBC)


                With DR
                    Do While .Read
                        Me.RubberLtrs = Convert.ToDecimal(IIf(Not IsDBNull(.Item("RubberLtrs")), .Item("RubberLtrs").ToString, 0))


                    Loop
                End With

                If (Not DR Is Nothing) Then
                    DR.Close()
                End If


            End Using



        Catch ex As Exception
            Throw
        Finally
            DBC.Dispose()



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
    Public Function DailyWorkingGetAllByDates() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(DAILYWORKING_GETALL_BYDATES)
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

#Region "Daily Working Get for Rate Update"
    Public Function DailyWorkingGetforRateUpdate() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(DAILYWORKING_GETALLFORRATEUPDATE)
            DB.AddInParameter(DBC, "@StartDate", DbType.Date, Me.StartDate)
            DB.AddInParameter(DBC, "@EndDate", DbType.Date, Me.EndDate)
            DB.AddInParameter(DBC, "@Designation", DbType.String, Me.Designation)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

#Region "DailyWorking Delete"
    Public Sub DailyWorkingDelete()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(DAILYWORKING_DELETE)
            DB.AddInParameter(DBC, "@DailyWorkingID ", DbType.Int64, Me.DailyWorkingID)
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

#Region "Attedence Report"
    Public Function GetAttendanceReport(ByVal currentDate As Date, ByVal workType As String) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("ReportAttendance")
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, currentDate)
            DB.AddInParameter(DBC, "@WorkType", DbType.String, workType)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function
#End Region

#Region "DailyWorking IfExists"
    Public Sub DailyWorkingIfExists()
        Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
        Dim DBC As DbCommand = DB.GetStoredProcCommand(DAILYWORKING_IFEXISTS)
        Try

            DB.AddInParameter(DBC, "@EmployeeID", DbType.Int64, Me.EmployeeID)
            DB.AddInParameter(DBC, "@WorkingDate", DbType.Date, Me.WorkingDate)

            Using DR As IDataReader = DB.ExecuteReader(DBC)


                With DR
                    Do While .Read
                        Me.CheckEmployeeID = Convert.ToInt64(IIf(Not IsDBNull(.Item("EmployeeID")), Trim(.Item("EmployeeID").ToString), 0))
                        Me.CheckDays = Convert.ToDecimal(IIf(Not IsDBNull(.Item("WorkedDays")), Trim(.Item("WorkedDays").ToString), 0))
                    Loop

                End With

                If (Not DR Is Nothing) Then
                    DR.Close()
                End If


            End Using



        Catch ex As Exception
            Throw
        Finally
            DBC.Dispose()



        End Try


    End Sub





#End Region

#Region "Update Daily workings"

    Public Sub UpdateDailyWorking()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("DailyWorking_Update")
            DB.AddInParameter(DBC, "@DailyWorkingID", DbType.Date, Me.DailyWorkingID)
            DB.AddInParameter(DBC, "@WorkingDate", DbType.Date, Me.WorkingDate)
            DB.AddInParameter(DBC, "@WorkType", DbType.String, Me.WorkType)
            DB.AddInParameter(DBC, "@AbbreviationID", DbType.Int64, Me.AbbreviationID)
            DB.AddInParameter(DBC, "@EmployeeID", DbType.Int64, Me.EmployeeID)
            DB.AddInParameter(DBC, "@WorkedDays", DbType.Decimal, Me.WorkedDays)
            DB.AddInParameter(DBC, "@Quantity", DbType.Decimal, Me.Quantity)
            DB.AddInParameter(DBC, "@DayRate", DbType.Decimal, Me.DayRate)
            DB.AddInParameter(DBC, "@OTRate", DbType.Decimal, Me.OTRate)
            DB.AddInParameter(DBC, "@KgsPerDay", DbType.Decimal, Me.KgsPerDay)
            DB.AddInParameter(DBC, "@OverKgRate", DbType.Decimal, Me.OverKgRate)
            DB.AddInParameter(DBC, "@EPF", DbType.Decimal, Me.EPF)
            DB.AddInParameter(DBC, "@CasualPayRate", DbType.Decimal, Me.CasualPayRate)
            DB.AddInParameter(DBC, "@CasualOTPayRate", DbType.Decimal, Me.CasualOTPayRate)

            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "Check Roll Report"
    Public Function GetCheckRollReport(ByVal currentDate As Date) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("ReportAttendanceAdvance")
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, currentDate)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function
#End Region

#Region "Check Roll Report Casual"
    Public Function GetCheckRollCasualReport(ByVal currentDate As Date) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("ReportAttendanceAdvanceCasual")
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, currentDate)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function
#End Region

#Region "Crop Summary Report"
    Public Function GetCropSummary(ByVal abbreviationID As Int64) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("ReportCropSummary")
            DB.AddInParameter(DBC, "@AbreviationID", DbType.Int64, AbbreviationID)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function
#End Region

#Region "Crop Summary Report Monthly"
    Public Function GetCropSummaryMonthly(ByVal currentDate As Date) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("ReportCropSummaryByMonthly")
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, currentDate)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function
#End Region


End Class
