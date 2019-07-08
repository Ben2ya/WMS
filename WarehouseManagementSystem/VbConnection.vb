Imports MySql.Data.MySqlClient
Module VbConnection
    Public con As New MySqlConnection("server=localhost;uid=root;password=;database=warehousesystem")
    Public rs As New DataTable
    Public bsource As New BindingSource
    Public cmd As MySqlCommand
    Public adp As MySqlDataAdapter
    Public read As MySqlDataReader
    Public sql As String
    Sub connect()
        con.Close()
        con.Open()

    End Sub

    Sub RunSQL(ByVal query As String)
        con.Close()
        con.Open()
        cmd = New MySqlCommand(query, con)
        cmd.ExecuteNonQuery()
    End Sub

    Function Login(ByVal sql As String)
        con.Close()
        con.Open()
        cmd = New MySqlCommand(sql, con)
        read = cmd.ExecuteReader()
        If read.Read Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub SetConnection(Optional ByVal Firstcomp As Boolean = False)
        Dim str As String
        str = "server=localhost;uid=root;password=;database=warehousesystem"
        Try
            If IsNothing(con) = False Then
                If con.State = ConnectionState.Closed Then
                    con.Close()
                End If
            End If
            con = New MySqlConnection(str)
            con.Open()
        Catch ex As System.Exception
            MsgBox(ex.Message)
            MsgBox("Not Connecting to Database Server.Please check your network.")
        End Try
    End Sub


End Module
