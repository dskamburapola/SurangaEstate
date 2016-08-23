﻿
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Imports System
Public Class iStockExpenses

#Region "Variables"
    Private _ExpenseID As Int64
    Private _ExpenseTypeID As Int64
    Private _PaymentTypeID As Int64
    Private _ExpenseDate As Date
    Private _Amount As Decimal
    Private _Note As String
    Private _Remarks As String
    Private _Description As String
    Private _CurrentExpenseID As Int64
    Private _CreatedBy As Int64
    Private _CreatedDate As Date
    Private _UpdatedBy As Int64
    Private _UpdatedDate As Date
    Private _FromDate As DateTime
    Private _ToDate As DateTime

    Private _EmployerID As Int64
    Private _PayDate As Date
    Private _StaffPayID As Int64
    Private _EmployerNo As Int64
    Private _EmployerName As String

    Private _Department As String



#End Region

#Region "Porperties"
    Public Property ExpenseID() As Int64
        Get
            Return _ExpenseID
        End Get
        Set(ByVal value As Int64)
            _ExpenseID = value
        End Set
    End Property
    Public Property ExpenseTypeID() As Int64
        Get
            Return _ExpenseTypeID
        End Get
        Set(ByVal value As Int64)
            _ExpenseTypeID = value
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
    Public Property ExpenseDate() As Date
        Get
            Return _ExpenseDate
        End Get
        Set(ByVal value As Date)
            _ExpenseDate = value
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
    Public Property Note() As String
        Get
            Return _Note
        End Get
        Set(ByVal value As String)
            _Note = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Public Property CurrentExpenseID() As Int64
        Get
            Return _CurrentExpenseID
        End Get
        Set(ByVal value As Int64)
            _CurrentExpenseID = value
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
    Public Property CreatedDate() As Date
        Get
            Return _CreatedDate
        End Get
        Set(ByVal value As Date)
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
    Public Property UpdatedDate() As Date
        Get
            Return _UpdatedDate
        End Get
        Set(ByVal value As Date)
            _UpdatedDate = value
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
            _ToDate = Value
        End Set
    End Property

    Public Property EmployerID() As Int64
        Get
            Return _EmployerID
        End Get
        Set(ByVal value As Int64)
            _EmployerID = value
        End Set
    End Property

    Public Property PayDate() As Date
        Get
            Return _PayDate
        End Get
        Set(ByVal value As Date)
            _PayDate = value
        End Set
    End Property

    Public Property StaffPayID() As Int64
        Get
            Return _StaffPayID
        End Get
        Set(ByVal value As Int64)
            _StaffPayID = value
        End Set
    End Property

    Public Property EmployerNo() As Int64
        Get
            Return _EmployerNo
        End Get
        Set(ByVal value As Int64)
            _EmployerNo = value
        End Set
    End Property

    Public Property EmployerName() As String
        Get
            Return _EmployerName
        End Get
        Set(ByVal value As String)
            _EmployerName = value
        End Set
    End Property

    Public Property Department() As String
        Get
            Return _Department
        End Get
        Set(ByVal value As String)
            _Department = value
        End Set
    End Property

#End Region

#Region "Insert Staff Pay"
    Public Sub InsertStaffPay()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(STAFFPAY_INSERT)
            DB.AddInParameter(DBC, "@StaffPayID", DbType.Int64, StaffPayID)
            DB.AddInParameter(DBC, "@Department", DbType.String, Department)

            DB.AddInParameter(DBC, "@EmployerID", DbType.Int64, EmployerID)
            If PayDate <> Date.MinValue Then
                DB.AddInParameter(DBC, "@PayDate", DbType.Date, PayDate)
            Else
                DB.AddInParameter(DBC, "@PayDate", DbType.Date, DBNull.Value)
            End If
            DB.AddInParameter(DBC, "@Amount", DbType.Decimal, Amount)
            DB.AddInParameter(DBC, "@CreatedBy", DbType.Int64, CreatedBy)
            DB.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, UpdatedBy)


            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Get Staff Pay By Staff Pay ID"
    Public Sub SelectStaffPayByID()


            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(GETSTAFFPAYBYID)

        Try
            DB.AddInParameter(DBC, "@StaffPayID", DbType.Int64, Me.StaffPayID)
            Using DR As IDataReader = DB.ExecuteReader(DBC)


                With DR
                    Do While .Read

                        Me.StaffPayID = Convert.ToInt64(IIf(Not IsDBNull(.Item("StaffPayID")), Trim(.Item("StaffPayID").ToString), 0))
                        Me.Department = IIf(Not IsDBNull(.Item("Department")), Trim(.Item("Department").ToString), String.Empty)
                        Me.EmployerID = IIf(Not IsDBNull(.Item("EmployerID")), Trim(.Item("EmployerID").ToString), String.Empty)
                        ' Me.EmployerNo = IIf(Not IsDBNull(.Item("EmployerNo")), Trim(.Item("EmployerNo").ToString), String.Empty)
                        Me.PayDate = IIf(Not IsDBNull(.Item("PayDate")), Trim(.Item("PayDate").ToString), String.Empty)
                        Me.Amount = IIf(Not IsDBNull(.Item("Amount")), Trim(.Item("Amount").ToString), String.Empty)

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

#Region "StaffPay GetAll"
    Public Function StaffPayGetAll() As DataSet

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(STAFFPAY_GETALL)

            Return db.ExecuteDataSet(DBC)
        Catch ex As Exception
            Return Nothing
            Throw
        End Try





    End Function
#End Region


#Region "Expense Delete"
    Public Sub StaffPayDelete()

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(STAFFPAY_DELETE)
            db.AddInParameter(DBC, "@StaffPayID", DbType.Int64, Me.StaffPayID)
            db.ExecuteNonQuery(DBC)

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region


#Region "Expense Insert"
    Public Sub InsertExpnese(ByVal db As Database, ByVal transaction As DbTransaction)

        Try


            Dim DBC As DbCommand = db.GetStoredProcCommand(EXPENSES_INSERT)

            db.AddInParameter(DBC, "@ExpenseID", DbType.Int64, Me.ExpenseID)
            db.AddInParameter(DBC, "@ExpenseTypeID", DbType.Int64, Me.ExpenseTypeID)
            db.AddInParameter(DBC, "@PaymentTypeID", DbType.Int64, Me.PaymentTypeID)
            db.AddInParameter(DBC, "@ExpenseDate", DbType.Date, Me.ExpenseDate)
            db.AddInParameter(DBC, "@Amount", DbType.Decimal, Me.Amount)
            db.AddInParameter(DBC, "@Note", DbType.String, Me.Note)
            db.AddInParameter(DBC, "@Remarks", DbType.String, Me.Remarks)
            db.AddOutParameter(DBC, "@CurrentExpenseID", DbType.Int64, 0)
            db.AddInParameter(DBC, "@CreatedBy", DbType.Int64, CreatedBy)
            db.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, UpdatedBy)

            db.ExecuteNonQuery(DBC, transaction)
            Me.CurrentExpenseID = Convert.ToInt64(db.GetParameterValue(DBC, "@CurrentExpenseID").ToString())

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region

#Region "Expense Delete"
    Public Sub ExpenseDelete()

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(EXPENSES_DELETE)
            db.AddInParameter(DBC, "@ExpenseID", DbType.Int64, Me.ExpenseID)
            db.ExecuteNonQuery(DBC)

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region

#Region "Expense GetAll"
    Public Function ExpenseGetByDates() As DataSet

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(EXPENSES_GETBYDATES)
            db.AddInParameter(DBC, "@FromDate", DbType.DateTime, Me.FromDate)
            db.AddInParameter(DBC, "@ToDate", DbType.DateTime, Me.ToDate)

            Return db.ExecuteDataSet(DBC)
        Catch ex As Exception
            Return Nothing
            Throw
        End Try





    End Function
#End Region

#Region "Get Expense By ExpenseID"
    Public Sub GetExpenseByID()
        Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
        Dim DBC As DbCommand = DB.GetStoredProcCommand(EXPENSE_GETBYID)
        Try

            DB.AddInParameter(DBC, "@ExpenseID", DbType.Int64, Me.ExpenseID)

            Using DR As IDataReader = DB.ExecuteReader(DBC)


                With DR
                    Do While .Read
                        Me.ExpenseID = Convert.ToInt64(IIf(Not IsDBNull(.Item("ExpenseID")), Trim(.Item("ExpenseID").ToString), String.Empty))
                        Me.ExpenseTypeID = Convert.ToInt64(IIf(Not IsDBNull(.Item("ExpenseTypeID")), Trim(.Item("ExpenseTypeID").ToString), String.Empty))
                        Me.PaymentTypeID = Convert.ToInt64(IIf(Not IsDBNull(.Item("PaymentTypeID")), Trim(.Item("PaymentTypeID").ToString), String.Empty))
                        Me.ExpenseDate = (IIf(Not IsDBNull(.Item("ExpenseDate")), Trim(.Item("ExpenseDate")), String.Empty))
                        Me.Amount = IIf(Not IsDBNull(.Item("Amount")), Trim(.Item("Amount").ToString), String.Empty)
                        Me.Note = IIf(Not IsDBNull(.Item("Note")), Trim(.Item("Note").ToString), String.Empty)
                        Me.Remarks = IIf(Not IsDBNull(.Item("Remarks")), Trim(.Item("Remarks").ToString), String.Empty)
                        Me.CreatedBy = Convert.ToInt64(IIf(Not IsDBNull(.Item("CreatedBy")), Trim(.Item("CreatedBy").ToString), 0))
                        Me.CreatedDate = Convert.ToDateTime((IIf(Not IsDBNull(.Item("CreatedDate")), Trim(.Item("CreatedDate").ToString), Date.MinValue)))
                        Me.UpdatedBy = Convert.ToInt64(IIf(Not IsDBNull(.Item("UpdatedBy")), Trim(.Item("UpdatedBy").ToString), 0))
                        Me.UpdatedDate = Convert.ToDateTime((IIf(Not IsDBNull(.Item("UpdatedDate")), Trim(.Item("UpdatedDate").ToString), Date.MinValue)))
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

#Region "ExpensTypse Insert"
    Public Sub InsertExpneseTypes()

        Try

            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(EXPENSETYPES_INSERT)
            db.AddInParameter(DBC, "@Description", DbType.String, Me.Description)
            db.ExecuteNonQuery(DBC)

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region

#Region "ExpenseTypes Delete"
    Public Sub ExpenseTypesDelete()

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(EXPENSETYPES_DELETE)
            db.AddInParameter(DBC, "@Description", DbType.String, Me.Description)
            db.ExecuteNonQuery(DBC)

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region

#Region "ExpenseTypes GetAll"
    Public Function ExpenseTypesGetAll() As DataSet

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(EXPENSETYPES_GETALL)

            Return db.ExecuteDataSet(DBC)
        Catch ex As Exception
            Return Nothing
            Throw
        End Try





    End Function
#End Region

End Class
