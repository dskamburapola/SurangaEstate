Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Imports System.Drawing

Public Class iStockWorkDays

#Region "Variables"
    Private _NewWorkDayID As Int64
    Private _WorkDayID As Int64
    Private _YearName As String
    Private _MonthName As String
    Private _WorkDays As Int32
    Private _CreatedBy As Int64
    Private _UpdatedBy As Int64

    Private _HolyDayID As Int64
    Private _HDate As Date
    Private _Description As String

#End Region

#Region "Properties"

    Public Property NewWorkDayID() As Int64
        Get
            Return _NewWorkDayID
        End Get
        Set(ByVal value As Int64)
            _NewWorkDayID = value
        End Set
    End Property

    Public Property WorkDayID() As Int64
        Get
            Return _WorkDayID
        End Get
        Set(ByVal value As Int64)
            _WorkDayID = value
        End Set
    End Property
    Public Property YearName() As String
        Get
            Return _YearName
        End Get
        Set(ByVal value As String)
            _YearName = value
        End Set
    End Property
    Public Property MonthName() As String
        Get
            Return _MonthName
        End Get
        Set(ByVal value As String)
            _MonthName = value
        End Set
    End Property
    Public Property WorkDays() As Int32
        Get
            Return _WorkDays
        End Get
        Set(ByVal value As Int32)
            _WorkDays = value
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
    Public Property UpdatedBy() As Int64
        Get
            Return _UpdatedBy
        End Get
        Set(ByVal value As Int64)
            _UpdatedBy = value
        End Set
    End Property

    Public Property HolyDayID() As Int64
        Get
            Return _HolyDayID
        End Get
        Set(ByVal value As Int64)
            _HolyDayID = value
        End Set
    End Property

    Public Property HDate() As Date
        Get
            Return _HDate
        End Get
        Set(ByVal value As Date)
            _HDate = value
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


#End Region


#Region "Insert WorkDays"
    Public Sub WorkDayInsert(ByVal db As Database, ByVal transaction As DbTransaction)

        Try

            Dim DBC As DbCommand = db.GetStoredProcCommand(WORKDAYS_INSERT)

            db.AddInParameter(DBC, "@YearName", DbType.String, YearName)

            db.AddInParameter(DBC, "@CreatedBy", DbType.Int64, CreatedBy)
            '  db.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, UpdatedBy)
            db.AddOutParameter(DBC, "@NewWorkDayID", DbType.Int32, 0)

            db.ExecuteNonQuery(DBC, transaction)
            Me.NewWorkDayID = Convert.ToInt64(db.GetParameterValue(DBC, "@NewWorkDayID").ToString())


        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Insert Holy Day"
    Public Sub HolyDayInsert(ByVal db As Database, ByVal transaction As DbTransaction)

        Try

            Dim DBC As DbCommand = db.GetStoredProcCommand(HOLYDAY_INSERT)

            db.AddInParameter(DBC, "@HDate", DbType.Date, HDate)

            db.AddInParameter(DBC, "@Description", DbType.String, Description)

            db.AddInParameter(DBC, "@CreatedBy", DbType.Int64, CreatedBy)

            db.ExecuteNonQuery(DBC, transaction)
            

        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Delete HolyDay"
    Public Sub HolydayDelete()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(HOLYDAY_DELETE)
            DB.AddInParameter(DBC, "@HolydayID", DbType.Int64, Me.HolyDayID)
            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try

    End Sub
#End Region

#Region "Get MonthList"
    Public Function GetHolyDaysAll() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(HOLYDAY_GET_ALL)


            DB.AddInParameter(DBC, "@YearName", DbType.String, Me.YearName)
            DB.AddInParameter(DBC, "@MonthName", DbType.String, Me.MonthName)


            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try

    End Function
#End Region

#Region "Update WorkDays"
    Public Sub WorkDayUpdate(ByVal db As Database, ByVal transaction As DbTransaction)

        Try

            Dim DBC As DbCommand = db.GetStoredProcCommand(WORKDAYS_UPDATE)

            db.AddInParameter(DBC, "@WorkDayID", DbType.Int64, WorkDayID)
            db.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, UpdatedBy)
      
            db.ExecuteNonQuery(DBC, transaction)
        
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Insert WorkDay Description"
    Public Sub WorkDayDescriptionInsert(ByVal db As Database, ByVal transaction As DbTransaction)

        Try

            Dim DBC As DbCommand = db.GetStoredProcCommand(WORKDAYSDESCRIPTION_INSERT)

            db.AddInParameter(DBC, "@WorkDayID", DbType.Int32, WorkDayID)
            db.AddInParameter(DBC, "@MonthName", DbType.String, MonthName)
            db.AddInParameter(DBC, "@WorkDays", DbType.Int32, WorkDays)

            db.ExecuteNonQuery(DBC, transaction)


        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Delete WorkDayDescription"
    Public Sub DeleteWorkDayDescription()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(WORKDAYSDESCRIPTION_DELETE)
            DB.AddInParameter(DBC, "@WorkDayID", DbType.Int64, Me.WorkDayID)
            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try

    End Sub
#End Region

#Region "Get Active Year"
    Public Sub GetActiveYear()
        Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
        Dim DBC As DbCommand = DB.GetStoredProcCommand(WORKDAYS_GETACTIVEYEAR)
        Try

            Using DR As IDataReader = DB.ExecuteReader(DBC)


                With DR
                    Do While .Read
                        Me.WorkDayID = Convert.ToInt64(IIf(Not IsDBNull(.Item("WorkDayID")), Trim(.Item("WorkDayID").ToString), 0))
                        Me.YearName = IIf(Not IsDBNull(.Item("YearName")), Trim(.Item("YearName").ToString), String.Empty)

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

#Region "Get MonthList"
    Public Function GetMonthList() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(WORKDAYS_GETMONTHLIST)


            DB.AddInParameter(DBC, "@WorkDayID", DbType.Int32, Me.WorkDayID)


            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try

    End Function
#End Region

#Region "Get Selected Month Work Days"

    Public Sub GetSelectedMonthWorkDays()
        Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
        Dim DBC As DbCommand = DB.GetStoredProcCommand(GET_SELECTEDMONTH_WORKDAYS)
        Try

            DB.AddInParameter(DBC, "@MonthName", DbType.String, Me.MonthName)
            DB.AddInParameter(DBC, "@YearName", DbType.String, Me.YearName)
            Using DR As IDataReader = DB.ExecuteReader(DBC)


                With DR
                    Do While .Read
                        Me.WorkDays = Convert.ToInt64(IIf(Not IsDBNull(.Item("WorkDays")), Trim(.Item("WorkDays").ToString), 0))


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

End Class
