﻿Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Imports System
Public Class iStockCollections
#Region "Variables"
    Private _CollectionID As Int64
    Private _SystemID As Int64
    Private _TransactionTypeID As Int64
    Private _PaymentTypeID As Int64
    Private _Date As Date
    Private _Reference As String
    Private _Amount As Decimal
    Private _FromDate As DateTime
    Private _ToDate As DateTime

#End Region

#Region "Properties"
    Public Property CollectionID() As Int64
        Get
            Return _CollectionID
        End Get
        Set(ByVal value As Int64)
            _CollectionID = value
        End Set
    End Property
    Public Property SystemID() As Int64
        Get
            Return _SystemID
        End Get
        Set(ByVal value As Int64)
            _SystemID = value
        End Set
    End Property
    Public Property TransactionTypeID() As Int64
        Get
            Return _TransactionTypeID
        End Get
        Set(ByVal value As Int64)
            _TransactionTypeID = value
        End Set
    End Property
    Public Property PaymentTypeID() As Int64
        Get
            Return _PaymentTypeID
        End Get
        Set(ByVal value As Int64)
            _PaymentTypeID = value
        End Set
    End Property
    Public Property [Date]() As Date
        Get
            Return _Date
        End Get
        Set(ByVal value As Date)
            _Date = value
        End Set
    End Property
    Public Property Reference() As String
        Get
            Return _Reference
        End Get
        Set(ByVal value As String)
            _Reference = value
        End Set
    End Property
    Public Property Amount() As Decimal
        Get
            Return _Amount
        End Get
        Set(ByVal value As Decimal)
            _Amount = value
        End Set
    End Property

    Public Property FromDate() As DateTime
        Get
            Return _FromDate
        End Get
        Set(ByVal value As DateTime)
            _FromDate = value
        End Set
    End Property


    Public Property ToDate() As DateTime
        Get
            Return _ToDate
        End Get
        Set(ByVal value As DateTime)
            _ToDate = value
        End Set
    End Property

#End Region

#Region "Collection Insert"
    Public Sub InsertCollection(ByVal db As Database, ByVal transaction As DbTransaction)

        Try

            Dim DBC As DbCommand = db.GetStoredProcCommand(COLLECTION_INSERT)

            DB.AddInParameter(DBC, "@SystemID", DbType.Int64, Me.SystemID)
            DB.AddInParameter(DBC, "@TransactionTypeID", DbType.Int64, Me.TransactionTypeID)
            DB.AddInParameter(DBC, "@PaymentTypeID", DbType.Int64, Me.PaymentTypeID)
            DB.AddInParameter(DBC, "@Date", DbType.DateTime, Me.Date)
            DB.AddInParameter(DBC, "@Reference", DbType.String, Me.Reference)
            DB.AddInParameter(DBC, "@Amount", DbType.Decimal, Me.Amount)
            db.ExecuteNonQuery(DBC, transaction)

        Catch ex As Exception

            Throw
        End Try

    End Sub
#End Region

#Region "Collection Delete"
    Public Sub CollectionDelete(ByVal db As Database, ByVal transaction As DbTransaction)

        Try

            Dim DBC As DbCommand = db.GetStoredProcCommand(COLLECTION_DELETE)

            DB.AddInParameter(DBC, "@SystemID", DbType.Int64, Me.SystemID)
            DB.AddInParameter(DBC, "@TransactionTypeID", DbType.Int64, Me.TransactionTypeID)
            db.ExecuteNonQuery(DBC, transaction)

        Catch ex As Exception


        End Try

    End Sub
#End Region

#Region "Collection GetByID"
    Public Function CollectionGetByID() As DataSet

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(COLLECTION_GETBYID)
            db.AddInParameter(DBC, "@SystemID", DbType.Int64, Me.SystemID)
            db.AddInParameter(DBC, "@TransactionTypeID", DbType.Int64, Me.TransactionTypeID)

            Return db.ExecuteDataSet(DBC)
        Catch ex As Exception
            Return Nothing

        End Try





    End Function
#End Region

#Region "Collection Get All"
    Public Function CollectionGetAll() As DataSet

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(COLLECTION_GETALL)


            Return db.ExecuteDataSet(DBC)
        Catch ex As Exception
            Return Nothing

        End Try





    End Function
#End Region

#Region "Collection By Dates"
    Public Function CollectionGetByDates() As DataSet

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(COLLECTION_GETBYDATES)
            db.AddInParameter(DBC, "@FromDate", DbType.DateTime, Me.FromDate)
            db.AddInParameter(DBC, "@ToDate", DbType.DateTime, Me.ToDate)

            Return db.ExecuteDataSet(DBC)
        Catch ex As Exception
            Return Nothing

        End Try





    End Function
#End Region
End Class
