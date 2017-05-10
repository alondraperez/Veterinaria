

    Imports MySql.Data
Imports MySql.Data.MySqlClient
Module conecciondb
    Public Veterinaria As New MySqlConnection

    Sub Conectarsql()
        Try
            Veterinaria.ConnectionString = "server=localhost;user id=root; password=''; database= Veterinaria"
            Veterinaria.Open()
            MsgBox("Conexion exitosa")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim sql As String
    ' Nombre
    Sub insertPersonasql(ByVal Usuario, ByVal Contraseña)
        Try
            sql = "insert into Persona(Usuario, Contraseña)value('" & Usuario & "' ,'" & Contraseña & "')"
            da = New MySqlDataAdapter(sql, Veterinaria)
            dt = New DataTable
            da.Fill(dt)
            MsgBox("Usuario guardado con exito")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub mostrardatossqul(ByVal datagriv As DataGridView)

        Try
            Dim DS As New DataSet
            Dim sql As String
            Dim dv As New DataView
            sql = "SELECT * FROM Usuario"
            Dim DA As New MySqlDataAdapter(sql, Veterinaria)
            DA.Fill(DS)
            datagriv.DataSource = DS
            dv.Table = DS.Tables(0)
            datagriv.DataSource = dv
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
