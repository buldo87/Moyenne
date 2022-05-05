Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim serializer = New XmlSerializer(GetType(NIMConfig))
        Dim paths() As String = Directory.GetFiles("C:\Users\buldo\source\repos\buldo87\Jeu_Nim\IA_Nim", "*.xlm")
        Dim cfg As NIMConfig
        Dim allConfig As List(Of NIMConfig)

        allConfig = New List(Of NIMConfig)

        For Each path As String In paths
            Using reader = XmlReader.Create(path)
                cfg = CType(serializer.Deserialize(reader), NIMConfig)
            End Using

            allConfig.Add(cfg)
        Next

        If allConfig.Count < 1 Then
            MessageBox.Show("Pas de fichier trouvé ...")
            Return
        End If

        Dim sommePartieScoreIA, sommePartieScoreHU As List(Of Integer)
        sommePartieScoreIA = New List(Of Integer)
        sommePartieScoreHU = New List(Of Integer)

        Dim nbPartieScoreIA, nbPartieScoreHU As List(Of Integer)
        nbPartieScoreIA = New List(Of Integer)
        nbPartieScoreHU = New List(Of Integer)

        For Each config As NIMConfig In allConfig

            If config.ScorePartieIA.Count > 0 Then
                For i As Integer = 0 To config.ScorePartieIA.Count - 1
                    If i >= sommePartieScoreIA.Count Then
                        sommePartieScoreIA.Add(config.ScorePartieIA(i))
                        nbPartieScoreIA.Add(1)
                    Else
                        sommePartieScoreIA(i) += config.ScorePartieIA(i)
                        nbPartieScoreIA(i) += 1
                    End If
                Next
            End If

            If config.ScorePartieHumain.Count > 0 Then
                For i As Integer = 0 To config.ScorePartieHumain.Count - 1
                    If i >= sommePartieScoreHU.Count Then
                        sommePartieScoreHU.Add(config.ScorePartieHumain(i))
                        nbPartieScoreHU.Add(1)
                    Else
                        sommePartieScoreHU(i) += config.ScorePartieHumain(i)
                        nbPartieScoreHU(i) += 1
                    End If
                Next
            End If
        Next

        cfg.ScorePartieIA = New List(Of String)
        cfg.ScorePartieHumain = New List(Of String)

        For i As Integer = 0 To sommePartieScoreIA.Count - 1
            cfg.ScorePartieIA.Add(sommePartieScoreIA(i) / nbPartieScoreIA(i))
        Next

        For i As Integer = 0 To sommePartieScoreHU.Count - 1
            cfg.ScorePartieHumain.Add(sommePartieScoreHU(i) / nbPartieScoreHU(i))
        Next

        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        settings.IndentChars = (ControlChars.Tab)

        Using writer = XmlWriter.Create("C:\Users\buldo\source\repos\buldo87\Jeu_Nim\IA_Nim\result.xlm", settings)
            serializer.Serialize(writer, cfg)
        End Using

        MessageBox.Show("OK")
    End Sub
End Class
