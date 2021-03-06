Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim str As String = "Data Source=(local);Initial Catalog=Northwind;" _
       & "Integrated Security=SSPI;"
        Dim qs As String = "SELECT OrderID, CustomerID FROM dbo.Orders;"
        CreateCommand(qs, str)
    End Sub

    ' <Snippet1>
    Public Sub CreateCommand(ByVal queryString As String, _
      ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            command.Connection = connection
            command.CommandTimeout = 15
            command.CommandType = CommandType.Text
            command.CommandText = queryString

            connection.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                Console.WriteLine(String.Format("{0}, {1}", _
                    reader(0), reader(1)))
            End While
        End Using
    End Sub
    ' </Snippet1>

End Module
