Imports System
Imports System.IO

Module Program
    Structure personal_information
        Public name As String
        Public last_name As String
        Public telephone As String
        Public age As Integer
    End Structure
    Sub Main(args As String())
        WriterFile()
        ReaderFile()
        Console.WriteLine("Presiona una tecla para salir...")
        Console.ReadKey()
    End Sub

    Private Sub WriterFile()
        Dim direccion = Directory.GetCurrentDirectory()
        Dim archivo = Path.Combine(direccion, "./BinariFile.dat")

        Try

            Using Writer_Information As BinaryWriter = New BinaryWriter(File.Open(archivo, FileMode.Create))
                Writer_Information.Write("Ana")
                Writer_Information.Write("Valdez")
                Writer_Information.Write("866-345-00-12")
                Writer_Information.Write(20)
            End Using

        Catch ex As Exception
            Console.WriteLine(Environment.NewLine + ex.Message)
        End Try
    End Sub

    Private Sub ReaderFile()
        Dim direccion = Directory.GetCurrentDirectory()
        Dim archivo = Path.Combine(direccion, "./BinariFile.dat")
        Dim persona As personal_information = New personal_information()

        Try

            If File.Exists(archivo) Then

                Using Reader_Information As BinaryReader = New BinaryReader(File.Open(archivo, FileMode.Open))
                    persona.name = Reader_Information.ReadString()
                    persona.last_name = Reader_Information.ReadString()
                    persona.telephone = Reader_Information.ReadString()
                    persona.age = Reader_Information.ReadInt32()
                End Using
            End If

        Catch ex As Exception
            Console.WriteLine(Environment.NewLine + ex.Message)
        End Try

        Console.WriteLine("Nombre: " & persona.name)
        Console.WriteLine("Apellido: " & persona.last_name)
        Console.WriteLine("Telefono: " & persona.telephone)
        Console.WriteLine("Edad: " & persona.age)
    End Sub
End Module
