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

    Private _EPF As Int64
    Private _ETF As Int64
    Private _OverKgRate As Int64
    Private _WCPay As Int64
    Private _CasualPayRate As Decimal
    Private _CasualOTPayRate As Decimal

    Private _CreatedBy As Int64
    Private _CreatedDate As DateTime
    Private _UpdatedBy As Int64
    Private _UpdatedDate As DateTime
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

    Public Property EPF() As Int64
        Get
            Return _EPF
        End Get
        Set(ByVal value As Int64)
            _EPF = value
        End Set
    End Property
    Public Property ETF() As Int64
        Get
            Return _ETF
        End Get
        Set(ByVal value As Int64)
            _ETF = value
        End Set
    End Property
    Public Property OverKgRate() As Int64
        Get
            Return _OverKgRate
        End Get
        Set(ByVal value As Int64)
            _OverKgRate = value
        End Set
    End Property
    Public Property WCPay() As Int64
        Get
            Return _WCPay
        End Get
        Set(ByVal value As Int64)
            _WCPay = value
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
            ' DB.AddInParameter(DBC, "@IncentiveRate", DbType.String, Me.IncentiveRate)
            DB.AddInParameter(DBC, "@EPF", DbType.String, Me.EPF)
            DB.AddInParameter(DBC, "@ETF", DbType.String, Me.ETF)
            DB.AddInParameter(DBC, "@OverKgRate", DbType.String, Me.OverKgRate)
            DB.AddInParameter(DBC, "@WCPay", DbType.String, Me.WCPay)
            DB.AddInParameter(DBC, "@CasualPayRate", DbType.Decimal, Me.CasualPayRate)
            DB.AddInParameter(DBC, "@CasualOTPayRate", DbType.Decimal, Me.CasualOTPayRate)


            DB.AddInParameter(DBC, "@CreatedBy", DbType.Int64, Me.CreatedBy)
            DB.AddInParameter(DBC, "@UpdatedBy", DbType.Int64, Me.UpdatedBy)

            DB.ExecuteNonQuery(DBC)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Insert Abbreviation"
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
                        Me.EPF = IIf(Not IsDBNull(.Item("EPF")), Trim(.Item("EPF").ToString), String.Empty)
                        Me.ETF = IIf(Not IsDBNull(.Item("ETF")), Trim(.Item("ETF").ToString), String.Empty)
                        Me.OverKgRate = IIf(Not IsDBNull(.Item("OverKgRate")), Trim(.Item("OverKgRate").ToString), String.Empty)
                        Me.WCPay = IIf(Not IsDBNull(.Item("WCPay")), Trim(.Item("WCPay").ToString), String.Empty)
                        Me.CasualPayRate = Convert.ToDecimal(IIf(Not IsDBNull(.Item("CasualPayRate")), Trim(.Item("CasualPayRate").ToString), 0))
                        Me.CasualOTPayRate = Convert.ToDecimal(IIf(Not IsDBNull(.Item("CasualOTPayRate")), Trim(.Item("CasualOTPayRate").ToString), 0))






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
