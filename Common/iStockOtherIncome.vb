
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Imports System
Public Class iStockOtherIncome

#Region "Variables"
    Private _OtherIncomeID As Int64
    Private _OtherIncomeTypeID As Int64
    Private _PaymentTypeID As Int64
    Private _OtherIncomeDate As Date
    Private _Amount As Decimal
    Private _Rate As Decimal
    Private _Quantity As Decimal
    Private _Note As String
    Private _Description As String
    Private _CurrentOtherIncomeID As Int64
    Private _CreatedBy As Int64
    Private _CreatedDate As Date
    Private _UpdatedBy As Int64
    Private _UpdatedDate As Date
    Private _FromDate As DateTime
    Private _ToDate As DateTime

#End Region

#Region "Porperties"
    Public Property OtherIncomeID() As Int64
        Get
            Return _OtherIncomeID
        End Get
        Set(ByVal value As Int64)
            _OtherIncomeID = value
        End Set
    End Property
    Public Property OtherIncomeTypeID() As Int64
        Get
            Return _OtherIncomeTypeID
        End Get
        Set(ByVal value As Int64)
            _OtherIncomeTypeID = value
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
    Public Property OtherIncomeDate() As Date
        Get
            Return _OtherIncomeDate
        End Get
        Set(ByVal value As Date)
            _OtherIncomeDate = value
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

    Public Property Rate() As Decimal
        Get
            Return _Rate
        End Get
        Set(ByVal value As Decimal)
            _Rate = value
        End Set
    End Property

    Public Property Quantity() As Decimal
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Decimal)
            _Quantity = value
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
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Public Property CurrentOtherIncomeID() As Int64
        Get
            Return _CurrentOtherIncomeID
        End Get
        Set(ByVal value As Int64)
            _CurrentOtherIncomeID = value
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
            _ToDate = value
        End Set
    End Property
#End Region

#Region "OtherIncome Insert"
    Public Sub InsertExpnese(ByVal db As Database, ByVal transaction As DbTransaction)

        Try


            Dim DBC As DbCommand = db.GetStoredProcCommand("OtherIncomes_Insert")

            db.AddInParameter(DBC, "@OtherIncomeID", DbType.Int64, Me.OtherIncomeID)
            db.AddInParameter(DBC, "@OtherIncomeTypeID", DbType.Int64, Me.OtherIncomeTypeID)
            db.AddInParameter(DBC, "@PaymentTypeID", DbType.Int64, Me.PaymentTypeID)
            db.AddInParameter(DBC, "@OtherIncomeDate", DbType.Date, Me.OtherIncomeDate)
            db.AddInParameter(DBC, "@Amount", DbType.Decimal, Me.Amount)
            db.AddInParameter(DBC, "@Rate", DbType.Decimal, Me.Rate)
            db.AddInParameter(DBC, "@Quantity", DbType.Decimal, Me.Quantity)
            db.AddInParameter(DBC, "@Note", DbType.String, Me.Note)
            db.AddOutParameter(DBC, "@CurrentOtherIncomeID", DbType.Int64, 0)
            db.AddInParameter(DBC, "@CreatedBy", DbType.Int64, CreatedBy)
            db.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, UpdatedBy)

            db.ExecuteNonQuery(DBC, transaction)
            Me.CurrentOtherIncomeID = Convert.ToInt64(db.GetParameterValue(DBC, "@CurrentOtherIncomeID").ToString())

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region

#Region "OtherIncome Delete"
    Public Sub OtherIncomeDelete()

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand("OtherIncomes_Delete")
            db.AddInParameter(DBC, "@OtherIncomeID", DbType.Int64, Me.OtherIncomeID)
            db.ExecuteNonQuery(DBC)

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region

#Region "OtherIncome GetAll"
    Public Function OtherIncomeGetByDates() As DataSet

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand("OtherIncomes_GetByDates")
            db.AddInParameter(DBC, "@FromDate", DbType.DateTime, Me.FromDate)
            db.AddInParameter(DBC, "@ToDate", DbType.DateTime, Me.ToDate)

            Return db.ExecuteDataSet(DBC)
        Catch ex As Exception
            Return Nothing
            Throw
        End Try





    End Function
#End Region

#Region "Get OtherIncome By OtherIncomeID"
    Public Sub GetOtherIncomeByID()
        Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
        Dim DBC As DbCommand = DB.GetStoredProcCommand("OtherIncome_GetByID")
        Try

            DB.AddInParameter(DBC, "@OtherIncomeID", DbType.Int64, Me.OtherIncomeID)

            Using DR As IDataReader = DB.ExecuteReader(DBC)


                With DR
                    Do While .Read
                        Me.OtherIncomeID = Convert.ToInt64(IIf(Not IsDBNull(.Item("OtherIncomeID")), Trim(.Item("OtherIncomeID").ToString), String.Empty))
                        Me.OtherIncomeTypeID = Convert.ToInt64(IIf(Not IsDBNull(.Item("OtherIncomeTypeID")), Trim(.Item("OtherIncomeTypeID").ToString), String.Empty))
                        Me.PaymentTypeID = Convert.ToInt64(IIf(Not IsDBNull(.Item("PaymentTypeID")), Trim(.Item("PaymentTypeID").ToString), String.Empty))
                        Me.OtherIncomeDate = (IIf(Not IsDBNull(.Item("OtherIncomeDate")), Trim(.Item("OtherIncomeDate")), String.Empty))
                        Me.Amount = IIf(Not IsDBNull(.Item("Amount")), Trim(.Item("Amount").ToString), String.Empty)
                        Me.Note = IIf(Not IsDBNull(.Item("Note")), Trim(.Item("Note").ToString), String.Empty)
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
            Dim DBC As DbCommand = db.GetStoredProcCommand("OtherIncomeTypes_Insert")
            db.AddInParameter(DBC, "@Description", DbType.String, Me.Description)
            db.ExecuteNonQuery(DBC)

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region

#Region "OtherIncomeTypes Delete"
    Public Sub OtherIncomeTypesDelete()

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand("OtherIncomeTypes_Delete")
            db.AddInParameter(DBC, "@Description", DbType.String, Me.Description)
            db.ExecuteNonQuery(DBC)

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region

#Region "OtherIncomeTypes GetAll"
    Public Function OtherIncomeTypesGetAll() As DataSet

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand("OtherIncomeTypes_GetAll")

            Return db.ExecuteDataSet(DBC)
        Catch ex As Exception
            Return Nothing
            Throw
        End Try





    End Function
#End Region

End Class
