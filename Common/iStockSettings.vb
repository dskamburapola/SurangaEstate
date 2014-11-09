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
    Private _IsOutPutTypes As String


    Private _PayChitCost As Decimal
    Private _DevalutionAllowance As Decimal
    Private _DayRate As Decimal
    Private _OTRate As Decimal
    Private _KgsPerDay As Decimal
    Private _KgsPerDayNotMandatory As Decimal
    Private _IncentiveDays As Decimal
    Private _IncentiveRate As Decimal

    Private _EPF As Decimal
    Private _ETF As Decimal
    Private _OverKgRate As Decimal
    Private _WCPay As Decimal
    Private _CasualPayRate As Decimal
    Private _CasualOTPayRate As Decimal

    Private _CreatedBy As Int64
    Private _CreatedDate As DateTime
    Private _UpdatedBy As Int64
    Private _UpdatedDate As DateTime


#End Region

#Region "Properties"

    Public Property IsOutPutTypes() As String
        Get
            Return _IsOutPutTypes
        End Get
        Set(ByVal value As String)
            _IsOutPutTypes = value
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
    Public Property PayChitCost() As Decimal
        Get
            Return _PayChitCost
        End Get
        Set(ByVal value As Decimal)
            _PayChitCost = value
        End Set
    End Property
    Public Property DevalutionAllowance() As Decimal
        Get
            Return _DevalutionAllowance
        End Get
        Set(ByVal value As Decimal)
            _DevalutionAllowance = value
        End Set
    End Property
    Public Property DayRate() As Decimal
        Get
            Return _DayRate
        End Get
        Set(ByVal value As Decimal)
            _DayRate = value
        End Set
    End Property
    Public Property OTRate() As Decimal
        Get
            Return _OTRate
        End Get
        Set(ByVal value As Decimal)
            _OTRate = value
        End Set
    End Property
    Public Property KgsPerDay() As Decimal
        Get
            Return _KgsPerDay
        End Get
        Set(ByVal value As Decimal)
            _KgsPerDay = value
        End Set
    End Property

    Public Property KgsPerDayNotMandatory() As Decimal
        Get
            Return _KgsPerDayNotMandatory
        End Get
        Set(ByVal value As Decimal)
            _KgsPerDayNotMandatory = value
        End Set
    End Property

    Public Property IncentiveDays() As Decimal
        Get
            Return _IncentiveDays
        End Get
        Set(ByVal value As Decimal)
            _IncentiveDays = value
        End Set
    End Property
    Public Property IncentiveRate() As Decimal
        Get
            Return _IncentiveRate
        End Get
        Set(ByVal value As Decimal)
            _IncentiveRate = value
        End Set
    End Property

    Public Property EPF() As Decimal
        Get
            Return _EPF
        End Get
        Set(ByVal value As Decimal)
            _EPF = value
        End Set
    End Property
    Public Property ETF() As Decimal
        Get
            Return _ETF
        End Get
        Set(ByVal value As Decimal)
            _ETF = value
        End Set
    End Property
    Public Property OverKgRate() As Decimal
        Get
            Return _OverKgRate
        End Get
        Set(ByVal value As Decimal)
            _OverKgRate = value
        End Set
    End Property
    Public Property WCPay() As Decimal
        Get
            Return _WCPay
        End Get
        Set(ByVal value As Decimal)
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
            DB.AddInParameter(DBC, "@PayChitCost", DbType.Decimal, Me.PayChitCost)
            DB.AddInParameter(DBC, "@DevalutionAllowance", DbType.Decimal, Me.DevalutionAllowance)
            DB.AddInParameter(DBC, "@DayRate", DbType.Decimal, Me.DayRate)
            DB.AddInParameter(DBC, "@OTRate", DbType.Decimal, Me.OTRate)
            DB.AddInParameter(DBC, "@KgsPerDay", DbType.Decimal, Me.KgsPerDay)
            DB.AddInParameter(DBC, "@KgsPerDayNotMandatory", DbType.Decimal, Me.KgsPerDayNotMandatory)
            DB.AddInParameter(DBC, "@IncentiveDays", DbType.Decimal, Me.IncentiveDays)
            ' DB.AddInParameter(DBC, "@IncentiveRate", DbType.String, Me.IncentiveRate)
            DB.AddInParameter(DBC, "@EPF", DbType.Decimal, Me.EPF)
            DB.AddInParameter(DBC, "@ETF", DbType.Decimal, Me.ETF)
            DB.AddInParameter(DBC, "@OverKgRate", DbType.Decimal, Me.OverKgRate)
            DB.AddInParameter(DBC, "@WCPay", DbType.Decimal, Me.WCPay)
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
            DB.AddInParameter(DBC, "@IsProductionType", DbType.String, Me.IsOutPutTypes)

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
                        Me.PayChitCost = IIf(Not IsDBNull(.Item("PayChitCost")), Trim(.Item("PayChitCost").ToString), 0)
                        Me.DevalutionAllowance = IIf(Not IsDBNull(.Item("DevalutionAllowance")), Trim(.Item("DevalutionAllowance").ToString), 0)
                        Me.DayRate = IIf(Not IsDBNull(.Item("DayRate")), Trim(.Item("DayRate").ToString), 0)
                        Me.OTRate = IIf(Not IsDBNull(.Item("OTRate")), Trim(.Item("OTRate").ToString), 0)
                        Me.KgsPerDay = IIf(Not IsDBNull(.Item("KgsPerDay")), Trim(.Item("KgsPerDay").ToString), 0)
                        Me.KgsPerDayNotMandatory = IIf(Not IsDBNull(.Item("KgsPerDayNotMandatory")), Trim(.Item("KgsPerDayNotMandatory").ToString), 0)
                        Me.IncentiveDays = IIf(Not IsDBNull(.Item("IncentiveDays")), Trim(.Item("IncentiveDays").ToString), 0)
                        Me.EPF = IIf(Not IsDBNull(.Item("EPF")), Trim(.Item("EPF").ToString), 0)
                        Me.ETF = IIf(Not IsDBNull(.Item("ETF")), Trim(.Item("ETF").ToString), 0)
                        Me.OverKgRate = IIf(Not IsDBNull(.Item("OverKgRate")), Trim(.Item("OverKgRate").ToString), 0)
                        Me.WCPay = IIf(Not IsDBNull(.Item("WCPay")), Trim(.Item("WCPay").ToString), 0)
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

#Region "Get Abbreviations For Rubber Sheets"

    Public Function GetAbbreviationsForRubberSheets() As DataSet
        Try
            Dim DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            Dim DBC As DbCommand = DB.GetStoredProcCommand(ABBREVIATION_FOR_RUBBERSHEETS)

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
