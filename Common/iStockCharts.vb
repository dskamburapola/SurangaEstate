Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Public Class iStockCharts

#Region "Variable"

    Private _IncomeType As Long
    Private _ExpenseType As Long
    Private _Year As Integer
    Private _Month As Integer

#End Region

#Region "Properties"

    Public Property IncomeType() As Long
        Get
            Return _IncomeType
        End Get
        Set(ByVal value As Long)
            _IncomeType = value
        End Set
    End Property

    Public Property ExpenseType() As Long
        Get
            Return _ExpenseType
        End Get
        Set(ByVal value As Long)
            _ExpenseType = value
        End Set
    End Property

    Public Property Year() As Long
        Get
            Return _Year
        End Get
        Set(ByVal value As Long)
            _Year = value
        End Set

    End Property


    Public Property Month() As Long
        Get
            Return _Month
        End Get
        Set(ByVal value As Long)
            _Month = value
        End Set

    End Property
#End Region

#Region "Charts income"

    Public Function ChartIncome() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("Charts_Income")
            DB.AddInParameter(DBC, "@IncomeType", DbType.Int64, Me.IncomeType)
            DB.AddInParameter(DBC, "@Year", DbType.Int32, Me.Year)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

#Region "Charts expenses"
    Public Function ChartExpenses() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("Charts_Expense")
            DB.AddInParameter(DBC, "@Month", DbType.Int64, Me.Month)
            DB.AddInParameter(DBC, "@Year", DbType.Int32, Me.Year)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

#Region "Charts attendance"
    Public Function ChartAttendance() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("Charts_Attendance")
            DB.AddInParameter(DBC, "@Month", DbType.Int64, Me.Month)
            DB.AddInParameter(DBC, "@Year", DbType.Int32, Me.Year)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

#Region "Charts crop summary"
    Public Function ChartCropSummary() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("Charts_CropSummary")
            DB.AddInParameter(DBC, "@Month", DbType.Int64, Me.Month)
            DB.AddInParameter(DBC, "@Year", DbType.Int32, Me.Year)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

End Class
