Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Public Class iStockTermDeductions

#Region "Variables"
    Private _NewTermDeductionID As Int64
    Private _TermDeductionID As Int64
    Private _TDDate As Date
    Private _TDType As String
    Private _EmployerID As Int64
    Private _TDAmount As Decimal
    Private _TDInstallments As Int64
    Private _CreatedBy As Int64
    Private _CreatedDate As DateTime
    Private _UpdatedBy As Int64
    Private _UpdatedDate As DateTime

    Private _TDMonthName As String
    Private _TDInsAmount As Decimal


#End Region

#Region "Properties"
   
    Public Property NewTermDeductionID() As Int64
        Get
            Return _NewTermDeductionID
        End Get
        Set(ByVal value As Int64)
            _NewTermDeductionID = value
        End Set
    End Property
    Public Property TermDeductionID() As Int64
        Get
            Return _TermDeductionID
        End Get
        Set(ByVal value As Int64)
            _TermDeductionID = value
        End Set
    End Property
    Public Property TDDate() As Date
        Get
            Return _TDDate
        End Get
        Set(ByVal value As Date)
            _TDDate = value
        End Set
    End Property
    Public Property TDType() As String
        Get
            Return _TDType
        End Get
        Set(ByVal value As String)
            _TDType = value
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
    Public Property TDAmount() As Decimal
        Get
            Return _TDAmount
        End Get
        Set(ByVal value As Decimal)
            _TDAmount = value
        End Set
    End Property
    Public Property TDInstallments() As Int64
        Get
            Return _TDInstallments
        End Get
        Set(ByVal value As Int64)
            _TDInstallments = value
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
    Public Property TDMonthName() As String
        Get
            Return _TDMonthName
        End Get
        Set(ByVal value As String)
            _TDMonthName = value
        End Set
    End Property
    Public Property TDInsAmount() As Decimal
        Get
            Return _TDInsAmount
        End Get
        Set(ByVal value As Decimal)
            _TDInsAmount = value
        End Set
    End Property
#End Region

#Region "Insert TermDeductions"
    Public Sub InsertTermDeductions(ByVal db As Database, ByVal transaction As DbTransaction)
        Try
            ' Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)

            Dim DBC As DbCommand = db.GetStoredProcCommand(TERMDEDUCTIONS_INSERT)

            db.AddInParameter(DBC, "@TDDate", DbType.Date, Me.TDDate)
            DB.AddInParameter(DBC, "@TDType", DbType.String, Me.TDType)
            DB.AddInParameter(DBC, "@EmployerID", DbType.Int64, Me.EmployerID)
            DB.AddInParameter(DBC, "@TDAmount", DbType.Decimal, Me.TDAmount)
            DB.AddInParameter(DBC, "@TDInstallments", DbType.Int64, Me.TDInstallments)
            DB.AddInParameter(DBC, "@CreatedBy", DbType.Int64, Me.CreatedBy)
            DB.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, Me.UpdatedBy)

            DB.AddOutParameter(DBC, "@NewTermDeductionID", DbType.Int64, 0)

            db.ExecuteNonQuery(DBC, transaction)

            Me.NewTermDeductionID = Convert.ToInt64(db.GetParameterValue(DBC, "@NewTermDeductionID").ToString())
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Insert TermDeductions"
    Public Sub UpdateTermDeductions(ByVal db As Database, ByVal transaction As DbTransaction)
        Try
            ' Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)

            Dim DBC As DbCommand = db.GetStoredProcCommand("TermDeductions_Update")

            db.AddInParameter(DBC, "@TermDeductionID", DbType.Int64, Me.TermDeductionID)
            db.AddInParameter(DBC, "@TDDate", DbType.Date, Me.TDDate)
            db.AddInParameter(DBC, "@TDType", DbType.String, Me.TDType)
            db.AddInParameter(DBC, "@EmployerID", DbType.Int64, Me.EmployerID)
            db.AddInParameter(DBC, "@TDAmount", DbType.Decimal, Me.TDAmount)
            db.AddInParameter(DBC, "@TDInstallments", DbType.Int64, Me.TDInstallments)
            db.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, Me.UpdatedBy)

            db.ExecuteNonQuery(DBC, transaction)

        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Insert TermDeductionsDescription"
    Public Sub InsertTermDeductionsDescription(ByVal db As Database, ByVal transaction As DbTransaction)
        Try
            ' Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = db.GetStoredProcCommand(TERMDEDUCTIONDESCRIPTION_INSERT)
            db.AddInParameter(DBC, "@TermDeductionID", DbType.Int64, Me.TermDeductionID)
            DB.AddInParameter(DBC, "@TDMonthName", DbType.String, Me.TDMonthName)
            db.AddInParameter(DBC, "@TDInsAmount", DbType.Decimal, Me.TDInsAmount)

            DB.ExecuteNonQuery(DBC, transaction)

        Catch ex As Exception
            Throw

        End Try

    End Sub
#End Region

#Region "Get TermDeductions"
    Public Function GetTermDeductions() As DataSet

        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(TERMDEDUCTIONS_SELECTALL)
            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception

            Return Nothing
            Throw
        End Try




    End Function

#End Region

#Region "Get TermDeductions By ID"
    Public Function GetTermDeductionsByID() As DataSet

        Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
        Dim DBC As DbCommand = DB.GetStoredProcCommand(TERMDEDUCTIONS_GETBYTERMDEDUCTIONID)
        Try

            DB.AddInParameter(DBC, "@TermDeductionID", DbType.Int64, Me.TermDeductionID)
            Using DR As IDataReader = DB.ExecuteReader(DBC)


                With DR
                    Do While .Read
                        Me.TDDate = Convert.ToDateTime(IIf(Not IsDBNull(.Item("TDDate")), Trim(.Item("TDDate").ToString), Date.MinValue))

                        '   Me.TDDate = IIf(Not IsDBNull(.Item("TDDate")), Trim(.Item("TDDate").ToString), String.Empty)
                        Me.TDType = IIf(Not IsDBNull(.Item("TDType")), Trim(.Item("TDType").ToString), String.Empty)
                        Me.EmployerID = Convert.ToInt64(IIf(Not IsDBNull(.Item("EmployerID")), Trim(.Item("EmployerID").ToString), 0))
                        Me.TDAmount = Convert.ToDecimal(IIf(Not IsDBNull(.Item("TDAmount")), Trim(.Item("TDAmount").ToString), 0))
                        Me.TDInstallments = Convert.ToInt64(IIf(Not IsDBNull(.Item("TDInstallments")), Trim(.Item("TDInstallments").ToString), 0))
                        Me.CreatedBy = Convert.ToInt64(IIf(Not IsDBNull(.Item("CreatedBy")), Trim(.Item("CreatedBy").ToString), 0))
                        Me.UpdatedBy = Convert.ToInt64(IIf(Not IsDBNull(.Item("UpdatedBy")), Trim(.Item("UpdatedBy").ToString), 0))



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



    End Function

#End Region

#Region "Get Installments By TermDeductionID"
    Public Function GetInstallmentsByID() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(TERMDEDUCTIONSDESCRIPTION_GETBYTERMDEDUCTIONID)
            DB.AddInParameter(DBC, "@TermDeductionID ", DbType.Int64, Me.TermDeductionID)
            Return DB.ExecuteDataSet(DBC)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region

#Region "Delete Term deduction"
    Public Function DeleteTermDescriptionByID() As Boolean
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(TERMDEDUCTIONS_DELETE)
            DB.AddInParameter(DBC, "@TermDeductionID ", DbType.Int64, Me.TermDeductionID)
            DB.ExecuteNonQuery(DBC)
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "Delete Term deduction description"
    Public Function DeleteTermDeductionDescriptionByTermDeductionID(ByVal db As Database, ByVal transaction As DbTransaction) As Boolean
        Try

            Dim DBC As DbCommand = db.GetStoredProcCommand("TermDeductionDescription_DeleteByTermDeductionID")
            DB.AddInParameter(DBC, "@TermDeductionID ", DbType.Int64, Me.TermDeductionID)
            DB.ExecuteNonQuery(DBC, transaction)
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

End Class
