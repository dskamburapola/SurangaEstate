
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Public Class iStockDailyWorking

    '#Region "Variables"

    '    Private _DailyWorkingID As Int64
    '    Private _WorkingDate As Date
    '    Private _StartDate As Date
    '    Private _EndDate As Date
    '    Private _WorkType As String
    '    Private _AbbreviationID As Int64
    '    Private _EmployeeID As Int64
    '    Private _WorkedDays As Double
    '    Private _OTHours As Double
    '    Private _Quantity As Double

    '    Private _CheckDays As Double
    '    Private _CheckEmployeeID As Int64

    '    Private _DayRate As Double
    '    Private _OTRate As Double
    '    Private _KgsPerDay As Double
    '    Private _KgsPerDayNotMandatory As Double

    '    Private _EPF As Double
    '    Private _OverKgRate As Double

    '    Private _CasualPayRate As Decimal
    '    Private _CasualOTPayRate As Decimal

    '    Private _CreatedBy As Int64
    '    Private _CreatedDate As DateTime
    '    Private _UpdatedBy As Int64
    '    Private _UpdatedDate As DateTime

    '    Private _Designation As String
    '    Private _RubberLtrs As Decimal

    '    Private _PayChitCost As Decimal
    '    Private _EvalutionAllowance As Decimal
    '    Private _IncentiveDays As Decimal
    '    Private _IncentiveRate As Decimal

    '    Private _ETF As Decimal
    '    Private _WCPay As Decimal

    '    Private _IsDeleted As Boolean

    '    Private _StockID As Int64
    '    Private _OverKGUpperLimit As Decimal
    '    Private _LowerKgRate As Decimal
    '    Private _SheetsPerDay As Decimal
    '    Private _OverSheetsUpperLimit As Decimal
    '    Private _OverSheetsRate As Decimal
    '    Private _LowerSheetsRate As Decimal
    '    Private _SmokingSheetsPayRate As Decimal

    '#End Region

    '#Region "Properties"

    '    Public Property StockID() As Int64
    '        Get
    '            Return _StockID
    '        End Get
    '        Set(ByVal value As Int64)
    '            _StockID = value
    '        End Set
    '    End Property

    '    Public Property DailyWorkingID() As Int64
    '        Get
    '            Return _DailyWorkingID
    '        End Get
    '        Set(ByVal value As Int64)
    '            _DailyWorkingID = value
    '        End Set
    '    End Property

    '    Public Property StartDate() As Date
    '        Get
    '            Return _StartDate
    '        End Get
    '        Set(ByVal value As Date)
    '            _StartDate = value
    '        End Set
    '    End Property

    '    Public Property EndDate() As Date
    '        Get
    '            Return _EndDate
    '        End Get
    '        Set(ByVal value As Date)
    '            _EndDate = value
    '        End Set
    '    End Property

    '    Public Property WorkingDate() As Date
    '        Get
    '            Return _WorkingDate
    '        End Get
    '        Set(ByVal value As Date)
    '            _WorkingDate = value
    '        End Set
    '    End Property
    '    Public Property WorkType() As String
    '        Get
    '            Return _WorkType
    '        End Get
    '        Set(ByVal value As String)
    '            _WorkType = value
    '        End Set
    '    End Property
    '    Public Property AbbreviationID() As Int64
    '        Get
    '            Return _AbbreviationID
    '        End Get
    '        Set(ByVal value As Int64)
    '            _AbbreviationID = value
    '        End Set
    '    End Property

    '    Public Property EmployeeID() As Int64
    '        Get
    '            Return _EmployeeID
    '        End Get
    '        Set(ByVal value As Int64)
    '            _EmployeeID = value
    '        End Set
    '    End Property

    '    Public Property CheckEmployeeID() As Int64
    '        Get
    '            Return _CheckEmployeeID
    '        End Get
    '        Set(ByVal value As Int64)
    '            _CheckEmployeeID = value
    '        End Set
    '    End Property

    '    Public Property CheckDays() As Double
    '        Get
    '            Return _CheckDays
    '        End Get
    '        Set(ByVal value As Double)
    '            _CheckDays = value
    '        End Set
    '    End Property



    '    Public Property WorkedDays() As Double
    '        Get
    '            Return _WorkedDays
    '        End Get
    '        Set(ByVal value As Double)
    '            _WorkedDays = value
    '        End Set
    '    End Property

    '    Public Property OTHours() As Double
    '        Get
    '            Return _OTHours
    '        End Get
    '        Set(ByVal value As Double)
    '            _OTHours = value
    '        End Set
    '    End Property

    '    Public Property Quantity() As Double
    '        Get
    '            Return _Quantity
    '        End Get
    '        Set(ByVal value As Double)
    '            _Quantity = value
    '        End Set
    '    End Property

    '    Public Property DayRate() As Double
    '        Get
    '            Return _DayRate
    '        End Get
    '        Set(ByVal value As Double)
    '            _DayRate = value
    '        End Set
    '    End Property
    '    Public Property OTRate() As Double
    '        Get
    '            Return _OTRate
    '        End Get
    '        Set(ByVal value As Double)
    '            _OTRate = value
    '        End Set
    '    End Property
    '    Public Property KgsPerDay() As Double
    '        Get
    '            Return _KgsPerDay
    '        End Get
    '        Set(ByVal value As Double)
    '            _KgsPerDay = value
    '        End Set
    '    End Property

    '    Public Property KgsPerDayNotMandatory() As Double
    '        Get
    '            Return _KgsPerDayNotMandatory
    '        End Get
    '        Set(ByVal value As Double)
    '            _KgsPerDayNotMandatory = value
    '        End Set
    '    End Property

    '    Public Property EPF() As Double
    '        Get
    '            Return _EPF
    '        End Get
    '        Set(ByVal value As Double)
    '            _EPF = value
    '        End Set
    '    End Property
    '    Public Property OverKgRate() As Double
    '        Get
    '            Return _OverKgRate
    '        End Get
    '        Set(ByVal value As Double)
    '            _OverKgRate = value
    '        End Set
    '    End Property

    '    Public Property CasualPayRate() As Decimal
    '        Get
    '            Return _CasualPayRate
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _CasualPayRate = value
    '        End Set
    '    End Property
    '    Public Property CasualOTPayRate() As Decimal
    '        Get
    '            Return _CasualOTPayRate
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _CasualOTPayRate = value
    '        End Set
    '    End Property

    '    Public Property CreatedBy() As Int64
    '        Get
    '            Return _CreatedBy
    '        End Get
    '        Set(ByVal value As Int64)
    '            _CreatedBy = value
    '        End Set
    '    End Property
    '    Public Property CreatedDate() As DateTime
    '        Get
    '            Return _CreatedDate
    '        End Get
    '        Set(ByVal value As DateTime)
    '            _CreatedDate = value
    '        End Set
    '    End Property
    '    Public Property UpdatedBy() As Int64
    '        Get
    '            Return _UpdatedBy
    '        End Get
    '        Set(ByVal value As Int64)
    '            _UpdatedBy = value
    '        End Set
    '    End Property
    '    Public Property UpdatedDate() As DateTime
    '        Get
    '            Return _UpdatedDate
    '        End Get
    '        Set(ByVal value As DateTime)
    '            _UpdatedDate = value
    '        End Set
    '    End Property

    '    Public Property Designation() As String
    '        Get
    '            Return _Designation
    '        End Get
    '        Set(ByVal value As String)
    '            _Designation = value
    '        End Set
    '    End Property

    '    Public Property RubberLtrs() As Decimal
    '        Get
    '            Return _RubberLtrs
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _RubberLtrs = value
    '        End Set
    '    End Property

    '    Public Property PayChitCost() As Decimal
    '        Get
    '            Return _PayChitCost
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _PayChitCost = value
    '        End Set
    '    End Property
    '    Public Property EvalutionAllowance() As Decimal
    '        Get
    '            Return _EvalutionAllowance
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _EvalutionAllowance = value
    '        End Set
    '    End Property
    '    Public Property IncentiveDays() As Decimal
    '        Get
    '            Return _IncentiveDays
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _IncentiveDays = value
    '        End Set
    '    End Property
    '    Public Property IncentiveRate() As Decimal
    '        Get
    '            Return _IncentiveRate
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _IncentiveRate = value
    '        End Set
    '    End Property

    '    Public Property ETF() As Decimal
    '        Get
    '            Return _ETF
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _ETF = value
    '        End Set
    '    End Property
    '    Public Property WCPay() As Decimal
    '        Get
    '            Return _WCPay
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _WCPay = value
    '        End Set
    '    End Property
    '    Public Property IsDeleted() As Boolean
    '        Get
    '            Return _IsDeleted
    '        End Get
    '        Set(ByVal value As Boolean)
    '            _IsDeleted = value
    '        End Set
    '    End Property

    '    Public Property OverKGUpperLimit() As Decimal
    '        Get
    '            Return _OverKGUpperLimit
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _OverKGUpperLimit = value
    '        End Set
    '    End Property

    '    Public Property LowerKgRate As Decimal
    '        Get
    '            Return _LowerKgRate
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _LowerKgRate = value
    '        End Set
    '    End Property

    '    Public Property SheetsPerDay As Decimal
    '        Get
    '            Return _SheetsPerDay
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _SheetsPerDay = value
    '        End Set
    '    End Property

    '    Public Property OverSheetsUpperLimit As Decimal
    '        Get
    '            Return _OverSheetsUpperLimit
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _OverSheetsUpperLimit = value
    '        End Set
    '    End Property

    '    Public Property OverSheetsRate As Decimal
    '        Get
    '            Return _OverSheetsRate
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _OverSheetsRate = value
    '        End Set
    '    End Property

    '    Public Property LowerSheetsRate As Decimal
    '        Get
    '            Return _LowerSheetsRate
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _LowerSheetsRate = value
    '        End Set
    '    End Property



    '    Public Property SmokingSheetsPayRate As Decimal
    '        Get
    '            Return _SmokingSheetsPayRate
    '        End Get
    '        Set(ByVal value As Decimal)
    '            _SmokingSheetsPayRate = value
    '        End Set
    '    End Property






    '#End Region

    '#Region "Insert Daily Working"
    '    Public Sub InsertDailyWorking()
    '        Try
    '            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
    '            Dim DBC As DbCommand = DB.GetStoredProcCommand(DAILYWORKING_INSERT)
    '            DB.AddInParameter(DBC, "@WorkingDate", DbType.Date, Me.WorkingDate)
    '            DB.AddInParameter(DBC, "@WorkType", DbType.String, Me.WorkType)
    '            DB.AddInParameter(DBC, "@AbbreviationID", DbType.Int64, Me.AbbreviationID)
    '            DB.AddInParameter(DBC, "@EmployeeID", DbType.Int64, Me.EmployeeID)
    '            DB.AddInParameter(DBC, "@WorkedDays", DbType.Decimal, Me.WorkedDays)
    '            DB.AddInParameter(DBC, "@OTHours", DbType.Decimal, Me.OTHours)
    '            DB.AddInParameter(DBC, "@Quantity", DbType.Decimal, Me.Quantity)
    '            DB.AddInParameter(DBC, "@DayRate", DbType.Decimal, Me.DayRate)
    '            DB.AddInParameter(DBC, "@OTRate", DbType.Decimal, Me.OTRate)
    '            DB.AddInParameter(DBC, "@KgsPerDay", DbType.Decimal, Me.KgsPerDay)
    '            DB.AddInParameter(DBC, "@KgsPerDayNotMandatory", DbType.Decimal, Me.KgsPerDayNotMandatory)
    '            DB.AddInParameter(DBC, "@OverKgRate", DbType.Decimal, Me.OverKgRate)
    '            DB.AddInParameter(DBC, "@LowerKgRate", DbType.Decimal, Me.LowerKgRate)
    '            DB.AddInParameter(DBC, "@WCPayRate", DbType.Decimal, Me.WCPay)
    '            DB.AddInParameter(DBC, "@DevalutionRate", DbType.Decimal, Me.IncentiveRate)
    '            DB.AddInParameter(DBC, "@DevaluationDays", DbType.Decimal, Me.IncentiveDays)
    '            DB.AddInParameter(DBC, "@PayChit", DbType.Decimal, Me.PayChitCost)
    '            DB.AddInParameter(DBC, "@EPF", DbType.Decimal, Me.EPF)
    '            DB.AddInParameter(DBC, "@CasualPayRate", DbType.Decimal, Me.CasualPayRate)
    '            DB.AddInParameter(DBC, "@CasualOTPayRate", DbType.Decimal, Me.CasualOTPayRate)
    '            DB.AddInParameter(DBC, "@IsDeleted", DbType.Boolean, Me.IsDeleted)
    '            DB.AddInParameter(DBC, "@CreatedBy", DbType.Int64, Me.CreatedBy)
    '            DB.AddInParameter(DBC, "@StockID", DbType.Int64, Me.StockID)
    '            DB.AddInParameter(DBC, "@ETF", DbType.Decimal, Me.ETF)

    '            DB.AddInParameter(DBC, "@OverKGUpperLimit", DbType.Decimal, Me.OverKGUpperLimit)
    '            'DB.AddInParameter(DBC, "@LowerKgRate", DbType.Decimal, Me.LowerKgRate)
    '            DB.AddInParameter(DBC, "@SheetsPerDay", DbType.Decimal, Me.SheetsPerDay)
    '            DB.AddInParameter(DBC, "@OverSheetsUpperLimit", DbType.Decimal, Me.OverSheetsUpperLimit)
    '            DB.AddInParameter(DBC, "@OverSheetsRate", DbType.Decimal, Me.OverSheetsRate)
    '            DB.AddInParameter(DBC, "@LowerSheetsRate ", DbType.Decimal, Me.LowerSheetsRate)
    '            DB.AddInParameter(DBC, "@SmokingSheetsPayRate", DbType.Decimal, Me.SmokingSheetsPayRate)

    '            'DB.AddInParameter(DBC, "@OverKGUpperLimit", DbType.Decimal, Me.OverKGUpperLimit)




    '            DB.ExecuteNonQuery(DBC)
    '        Catch ex As Exception
    '            Throw
    '        End Try
    '    End Sub
    '#End Region

#Region "Variables"

    Private _DailyWorkingID As Int64
    Private _WorkingDate As Date
    Private _StartDate As Date
    Private _EndDate As Date
    Private _WorkType As String
    Private _AbbreviationID As Int64
    Private _EmployeeID As Int64
    Private _WorkedDays As Double
    Private _NameDays As Double
    Private _OTHours As Double
    Private _Quantity As Double

    Private _CheckDays As Double
    Private _CheckEmployeeID As Int64

    Private _DayRate As Double
    Private _OTRate As Double
    Private _KgsPerDay As Double
    Private _KgsPerDayNotMandatory As Double

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
    Private _EvalutionAllowance As Decimal
    Private _IncentiveDays As Decimal
    Private _IncentiveRate As Decimal

    Private _ETF As Decimal
    Private _WCPay As Decimal

    Private _IsDeleted As Boolean

    Private _StockID As Int64
    Private _OverKGUpperLimit As Decimal
    Private _LowerKgRate As Decimal
    Private _SheetsPerDay As Decimal
    Private _OverSheetsUpperLimit As Decimal
    Private _OverSheetsRate As Decimal
    Private _LowerSheetsRate As Decimal
    Private _SmokingSheetsPayRate As Decimal




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

    Public Property NameDays() As Double
        Get
            Return _NameDays
        End Get
        Set(ByVal value As Double)
            _NameDays = value
        End Set
    End Property


    Public Property OTHours() As Double
        Get
            Return _OTHours
        End Get
        Set(ByVal value As Double)
            _OTHours = value
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

    Public Property KgsPerDayNotMandatory() As Double
        Get
            Return _KgsPerDayNotMandatory
        End Get
        Set(ByVal value As Double)
            _KgsPerDayNotMandatory = value
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
    Public Property EvalutionAllowance() As Decimal
        Get
            Return _EvalutionAllowance
        End Get
        Set(ByVal value As Decimal)
            _EvalutionAllowance = value
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

    Public Property OverKGUpperLimit() As Decimal
        Get
            Return _OverKGUpperLimit
        End Get
        Set(ByVal value As Decimal)
            _OverKGUpperLimit = value
        End Set
    End Property

    Public Property LowerKgRate As Decimal
        Get
            Return _LowerKgRate
        End Get
        Set(ByVal value As Decimal)
            _LowerKgRate = value
        End Set
    End Property

    Public Property SheetsPerDay As Decimal
        Get
            Return _SheetsPerDay
        End Get
        Set(ByVal value As Decimal)
            _SheetsPerDay = value
        End Set
    End Property

    Public Property OverSheetsUpperLimit As Decimal
        Get
            Return _OverSheetsUpperLimit
        End Get
        Set(ByVal value As Decimal)
            _OverSheetsUpperLimit = value
        End Set
    End Property

    Public Property OverSheetsRate As Decimal
        Get
            Return _OverSheetsRate
        End Get
        Set(ByVal value As Decimal)
            _OverSheetsRate = value
        End Set
    End Property

    Public Property LowerSheetsRate As Decimal
        Get
            Return _LowerSheetsRate
        End Get
        Set(ByVal value As Decimal)
            _LowerSheetsRate = value
        End Set
    End Property



    Public Property SmokingSheetsPayRate As Decimal
        Get
            Return _SmokingSheetsPayRate
        End Get
        Set(ByVal value As Decimal)
            _SmokingSheetsPayRate = value
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
            DB.AddInParameter(DBC, "@NameDays", DbType.Decimal, Me.NameDays)
            DB.AddInParameter(DBC, "@OTHours", DbType.Decimal, Me.OTHours)
            DB.AddInParameter(DBC, "@Quantity", DbType.Decimal, Me.Quantity)
            DB.AddInParameter(DBC, "@DayRate", DbType.Decimal, Me.DayRate)
            DB.AddInParameter(DBC, "@OTRate", DbType.Decimal, Me.OTRate)
            DB.AddInParameter(DBC, "@KgsPerDay", DbType.Decimal, Me.KgsPerDay)
            DB.AddInParameter(DBC, "@KgsPerDayNotMandatory", DbType.Decimal, Me.KgsPerDayNotMandatory)
            DB.AddInParameter(DBC, "@OverKgRate", DbType.Decimal, Me.OverKgRate)
            DB.AddInParameter(DBC, "@LowerKgRate", DbType.Decimal, Me.LowerKgRate)
            DB.AddInParameter(DBC, "@WCPayRate", DbType.Decimal, Me.WCPay)
            DB.AddInParameter(DBC, "@DevalutionRate", DbType.Decimal, Me.IncentiveRate)
            DB.AddInParameter(DBC, "@DevaluationDays", DbType.Decimal, Me.IncentiveDays)
            DB.AddInParameter(DBC, "@PayChit", DbType.Decimal, Me.PayChitCost)
            DB.AddInParameter(DBC, "@EPF", DbType.Decimal, Me.EPF)
            DB.AddInParameter(DBC, "@CasualPayRate", DbType.Decimal, Me.CasualPayRate)
            DB.AddInParameter(DBC, "@CasualOTPayRate", DbType.Decimal, Me.CasualOTPayRate)
            DB.AddInParameter(DBC, "@IsDeleted", DbType.Boolean, Me.IsDeleted)
            DB.AddInParameter(DBC, "@CreatedBy", DbType.Int64, Me.CreatedBy)
            DB.AddInParameter(DBC, "@StockID", DbType.Int64, Me.StockID)
            DB.AddInParameter(DBC, "@ETF", DbType.Decimal, Me.ETF)

            DB.AddInParameter(DBC, "@OverKGUpperLimit", DbType.Decimal, Me.OverKGUpperLimit)
            'DB.AddInParameter(DBC, "@LowerKgRate", DbType.Decimal, Me.LowerKgRate)
            DB.AddInParameter(DBC, "@SheetsPerDay", DbType.Decimal, Me.SheetsPerDay)
            DB.AddInParameter(DBC, "@OverSheetsUpperLimit", DbType.Decimal, Me.OverSheetsUpperLimit)
            DB.AddInParameter(DBC, "@OverSheetsRate", DbType.Decimal, Me.OverSheetsRate)
            DB.AddInParameter(DBC, "@LowerSheetsRate ", DbType.Decimal, Me.LowerSheetsRate)
            DB.AddInParameter(DBC, "@SmokingSheetsPayRate", DbType.Decimal, Me.SmokingSheetsPayRate)

            'DB.AddInParameter(DBC, "@OverKGUpperLimit", DbType.Decimal, Me.OverKGUpperLimit)




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

#Region "Get Employee For Work"
    Public Function GetAllStaff() As DataSet
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
            DB.AddInParameter(DBC, "@OTHours", DbType.Decimal, Me.OTHours)
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

#Region "Attendance Report By Work Category"
    Public Function GetAttendanceReportByWorkCategory(ByVal currentDate As Date, ByVal workType As String, ByVal workDays As Int32) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(ATTENDANCE_REPORT_BY_WORKCATEGORY)
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, currentDate)
            DB.AddInParameter(DBC, "@WorkCategoey", DbType.String, workType)
            DB.AddInParameter(DBC, "@MWA", DbType.Int32, workDays)


            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function
#End Region

#Region "Attendance Report All Work Category"
    Public Function GetAttendanceReportAllWorkCategory(ByVal currentDate As Date, ByVal workDays As Int32) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(ATTENDANCE_REPORT_ALL_WORKCATEGORY)
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, currentDate)
            ' DB.AddInParameter(DBC, "@WorkCategoey", DbType.String, workType)
            DB.AddInParameter(DBC, "@MWA", DbType.Int32, workDays)


            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function
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

#Region "Staff Check Roll Report"
    Public Function GetStaffCheckRollReport(ByVal currentDate As Date) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("StaffPaysheet")
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
    Public Function GetCheckRollCasualReport(ByVal currentDate As Date, ByVal range As Integer) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("ReportAttendanceAdvanceCasual")
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, currentDate)
            DB.AddInParameter(DBC, "@daterange", DbType.Int32, range)


            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function
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


#Region "Field Performance Report"
    Public Function FeildPerformanceReport(ByVal currentDate As Date) As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("FIELDPERFORMANCE")
            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, currentDate)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function
#End Region

#Region "Holiday Is Exits"
    Public Function HolidayIsExits() As Boolean
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(HOLYDAY_ISEXISTS)

            DB.AddInParameter(DBC, "@WorkingDate", DbType.Date, WorkingDate)
            DB.AddOutParameter(DBC, "@IsExists", DbType.Int64, 0)
            DB.ExecuteNonQuery(DBC)

            If DB.GetParameterValue(DBC, "@IsExists") = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            Throw

        End Try

    End Function
#End Region

    '#Region "Field Performance Report"
    '    Public Function FeildPerformanceReport(ByVal type As Long, ByVal currentDate As Date) As DataSet
    '        Try
    '            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
    '            Dim DBC As DbCommand = DB.GetStoredProcCommand("ReportFieldPerformance")
    '            DB.AddInParameter(DBC, "@AbreviationID", DbType.Int64, type)
    '            DB.AddInParameter(DBC, "@IssueDate", DbType.Date, currentDate)

    '            Return DB.ExecuteDataSet(DBC)
    '            DBC.Dispose()
    '        Catch ex As Exception
    '            Return Nothing
    '            Throw
    '        End Try


    '    End Function
    '#End Region

End Class
