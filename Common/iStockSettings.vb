Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Public Class iStockSettings

#Region "Variables"
    Private _AbbreviationID As Int64
    Private _AbbreviationCode As String
    Private _AbbreviationDesc As String

    Private _PayChitCost As Int64
    Private _DevalutionAllowance As Int64
    Private _DayRate As Int64
    Private _OTRate As Int64
    Private _KgsPerDay As Int64
    Private _IncentiveDays As Int64
    Private _IncentiveRate As Int64

#End Region

#Region "Properties"
    Public Property AbbreviationID() As Int64
        Get
            Return _AbbreviationID
        End Get
        Set(ByVal value As Int64)
            _AbbreviationID = value
        End Set
    End Property
    Public Property AbbreviationCode() As String
        Get
            Return _AbbreviationCode
        End Get
        Set(ByVal value As String)
            _AbbreviationCode = value
        End Set
    End Property
    Public Property AbbreviationDesc() As String
        Get
            Return _AbbreviationDesc
        End Get
        Set(ByVal value As String)
            _AbbreviationDesc = value
        End Set
    End Property
    Public Property PayChitCost() As Int64
        Get
            Return _PayChitCost
        End Get
        Set(ByVal value As Int64)
            _PayChitCost = value
        End Set
    End Property
    Public Property DevalutionAllowance() As Int64
        Get
            Return _DevalutionAllowance
        End Get
        Set(ByVal value As Int64)
            _DevalutionAllowance = value
        End Set
    End Property
    Public Property DayRate() As Int64
        Get
            Return _DayRate
        End Get
        Set(ByVal value As Int64)
            _DayRate = value
        End Set
    End Property
    Public Property OTRate() As Int64
        Get
            Return _OTRate
        End Get
        Set(ByVal value As Int64)
            _OTRate = value
        End Set
    End Property
    Public Property KgsPerDay() As Int64
        Get
            Return _KgsPerDay
        End Get
        Set(ByVal value As Int64)
            _KgsPerDay = value
        End Set
    End Property
    Public Property IncentiveDays() As Int64
        Get
            Return _IncentiveDays
        End Get
        Set(ByVal value As Int64)
            _IncentiveDays = value
        End Set
    End Property
    Public Property IncentiveRate() As Int64
        Get
            Return _IncentiveRate
        End Get
        Set(ByVal value As Int64)
            _IncentiveRate = value
        End Set
    End Property


#End Region

#Region "Insert Settings"
    Public Sub InsertSettings()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(SETTINGS_INSERT)
            DB.AddInParameter(DBC, "@PayChitCost", DbType.String, Me.PayChitCost)
            DB.AddInParameter(DBC, "@DevalutionAllowance", DbType.String, Me.DevalutionAllowance)
            DB.AddInParameter(DBC, "@DayRate", DbType.String, Me.DayRate)
            DB.AddInParameter(DBC, "@OTRate", DbType.String, Me.OTRate)
            DB.AddInParameter(DBC, "@KgsPerDay", DbType.String, Me.KgsPerDay)
            DB.AddInParameter(DBC, "@IncentiveDays", DbType.String, Me.IncentiveDays)
            DB.AddInParameter(DBC, "@IncentiveRate", DbType.String, Me.IncentiveRate)
            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Insert Settings"
    Public Sub InsertAbbreviation()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(ABBREVIATION_INSERT)
            DB.AddInParameter(DBC, "@AbbreviationCode", DbType.String, Me.AbbreviationCode)
            DB.AddInParameter(DBC, "@AbbreviationDesc", DbType.String, Me.AbbreviationDesc)

            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Get Settings"
    Public Sub GetSettings()
        Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
        Dim DBC As DbCommand = DB.GetStoredProcCommand(SETTINGS_GETALL)
        Try


            Using DR As IDataReader = DB.ExecuteReader(DBC)


                With DR
                    Do While .Read
                        Me.PayChitCost = IIf(Not IsDBNull(.Item("PayChitCost")), Trim(.Item("PayChitCost").ToString), String.Empty)
                        Me.DevalutionAllowance = IIf(Not IsDBNull(.Item("DevalutionAllowance")), Trim(.Item("DevalutionAllowance").ToString), String.Empty)
                        Me.DayRate = IIf(Not IsDBNull(.Item("DayRate")), Trim(.Item("DayRate").ToString), String.Empty)
                        Me.OTRate = IIf(Not IsDBNull(.Item("OTRate")), Trim(.Item("OTRate").ToString), String.Empty)
                        Me.KgsPerDay = IIf(Not IsDBNull(.Item("KgsPerDay")), Trim(.Item("KgsPerDay").ToString), String.Empty)
                        Me.IncentiveDays = IIf(Not IsDBNull(.Item("IncentiveDays")), Trim(.Item("IncentiveDays").ToString), String.Empty)
                        Me.IncentiveRate = IIf(Not IsDBNull(.Item("IncentiveRate")), Trim(.Item("IncentiveRate").ToString), String.Empty)





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

#Region "Get Abbreviations"
    Public Function GetAbbreviations() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(ABBREVIATION_GETALL)

            Return DB.ExecuteDataSet(DBC)
            DBC.Dispose()
        Catch ex As Exception
            Return Nothing
            Throw
        End Try


    End Function

#End Region

#Region "Delete Abbrevation"
    Public Sub DeleteAbbrevation()
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(ABBREVIATION_DELETE)
            DB.AddInParameter(DBC, "@AbbreviationID", DbType.Int64, Me.AbbreviationID)
            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try

    End Sub
#End Region

End Class
