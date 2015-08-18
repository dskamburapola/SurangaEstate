Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Public Class iStockDailyCropSummary

#Region "Variables"

    Private _DailyCropSummaryID As Long
    Private _CurrentMonth As Integer
    Private _CurrentYear As Integer
    Private _CurrentDate As Date
    Private _AbbreviationID As Integer
    Private _FactoryCrop As Decimal
    Private _Rate As Decimal





#End Region

#Region "Properties"


    Public Property DailyCropSummaryID() As Long
        Get
            Return _DailyCropSummaryID
        End Get
        Set(ByVal value As Long)
            _DailyCropSummaryID = value
        End Set
    End Property

    Public Property CurrentMonth() As Integer
        Get
            Return _CurrentMonth
        End Get
        Set(ByVal value As Integer)
            _CurrentMonth = value
        End Set
    End Property

    Public Property CurrentYear() As Integer
        Get
            Return _CurrentYear
        End Get
        Set(ByVal value As Integer)
            _CurrentYear = value
        End Set
    End Property

    Public Property CurrentDate() As Date
        Get
            Return _CurrentDate
        End Get
        Set(ByVal value As Date)
            _CurrentDate = value
        End Set
    End Property

    Public Property AbbreviationID() As Integer
        Get
            Return _AbbreviationID
        End Get
        Set(ByVal value As Integer)
            _AbbreviationID = value
        End Set
    End Property

    Public Property FactoryCrop() As Decimal
        Get
            Return _FactoryCrop
        End Get
        Set(ByVal value As Decimal)
            _FactoryCrop = value
        End Set
    End Property

    Public Property Rate() As Decimal
        Get
            Return _Rate
        End Get
        Set(ByVal value As Decimal)
            _Rate = value
        End Set
    End Property

#End Region


#Region "Update Daily Crop"
    Public Sub UpdateDailyCrop(ByVal ds As DataSet)
        Try

            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)

            Dim DBCInsert As DbCommand = DB.GetStoredProcCommand("DailyCropSummary_Insert")

            DB.AddInParameter(DBCInsert, "@Month", DbType.Int32, Me.CurrentMonth)
            DB.AddInParameter(DBCInsert, "@Year", DbType.Int32, Me.CurrentYear)
            DB.AddInParameter(DBCInsert, "@AbbreviationID", DbType.Int64, Me.AbbreviationID)
            DB.AddInParameter(DBCInsert, "@CurrentDate", DbType.Date, DataRowVersion.Current)
            DB.AddInParameter(DBCInsert, "@FactoryCrop", DbType.Decimal, DataRowVersion.Current)
            DB.AddInParameter(DBCInsert, "@Rate", DbType.Decimal, DataRowVersion.Current)

            Dim DBCUpdate As DbCommand = DB.GetStoredProcCommand("DailyCropSummary_Update")
            DB.AddInParameter(DBCUpdate, "@DailyCropSummaryID", DbType.Int64, DataRowVersion.Current)
            DB.AddInParameter(DBCUpdate, "@Month", DbType.Int32, Me.CurrentMonth)
            DB.AddInParameter(DBCUpdate, "@Year", DbType.Int32, Me.CurrentYear)
            DB.AddInParameter(DBCUpdate, "@AbbreviationID", DbType.Int32, Me.AbbreviationID)
            DB.AddInParameter(DBCUpdate, "@CurrentDate", DbType.Date, DataRowVersion.Current)
            DB.AddInParameter(DBCUpdate, "@FactoryCrop", DbType.Decimal, DataRowVersion.Current)
            DB.AddInParameter(DBCUpdate, "@Rate", DbType.Decimal, DataRowVersion.Current)

            Dim DBCDelete As DbCommand = DB.GetStoredProcCommand("DailyCropSummary_Delete")
            DB.AddInParameter(DBCDelete, "@DailyCropSummaryID", DbType.Int64, DataRowVersion.Current)

            DB.UpdateDataSet(ds, ds.Tables(0).TableName, DBCInsert, DBCUpdate, DBCDelete, UpdateBehavior.Standard)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region



#Region "Get Daily Crop by Moth Year"
    Public Function GetDailyCropByMonthYear() As DataSet
        Try

            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand("DailyCropSummary_GetByMonthYear")
            DB.AddInParameter(DBC, "@SelecteMonth", DbType.Int32, Me.CurrentMonth)
            DB.AddInParameter(DBC, "@SelectedYear", DbType.Int32, Me.CurrentYear)
            DB.AddInParameter(DBC, "@TypeID", DbType.Int32, Me.AbbreviationID)

            Return DB.ExecuteDataSet(DBC)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region

End Class
