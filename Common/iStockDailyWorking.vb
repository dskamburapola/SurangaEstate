Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Public Class iStockDailyWorking

#Region "Variables"
    Private _DailyWorkingID As Int64
    Private _WorkingDate As Date
    Private _WorkType As String
    Private _AbbreviationID As Int64
    Private _EmployeeID As Int64
    Private _WorkedDays As Double
    Private _Quantity As Double
#End Region

#Region "Properties"

    Public Property DailyWorkingID() As Int64
        Get
            Return _DailyWorkingID
        End Get
        Set(ByVal value As Int64)
            _DailyWorkingID = value
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
    Public Function DailyWorkingGetAllByDates() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(DAILYWORKING_GETALL_BYDATES)
            DB.AddInParameter(DBC, "@WorkingDate", DbType.Date, Me.WorkingDate)
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

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

End Class
