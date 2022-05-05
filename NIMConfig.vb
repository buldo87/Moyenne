
Public Class NIMConfig

    Public Class Allumette
        Public Property PBVisible As Boolean
        Public Property LBValues As List(Of String) = New List(Of String)
        Public Property LBIndex As Integer
        Public Property TBValue As String
    End Class

    Public Property ListAllumettes As List(Of Allumette) = New List(Of Allumette)
    Public Property NombreAllumetteRestante As Integer
    Public Property NombrebAllumetteDepart As Integer
    Public Property NombrebAllumettePrise As Integer
    Public Property AllumetteRestante As String
    Public Property ScoreIA As String
    Public Property Scorehumain As String
    Public Property Prise As String
    Public Property QuelNiveau As String
    Public Property QuiCommence As String
    Public Property DerniereAllumette As String
    Public Property CombienAllumette As String
    Public Property DeroulementPartie As List(Of String) = New List(Of String)
    Public Property CommentaireIA As List(Of String) = New List(Of String)
    Public Property ScorePartieIA As List(Of String) = New List(Of String)
    Public Property ScorePartieHumain As List(Of String) = New List(Of String)
    Public Property Dernierchoix As List(Of String) = New List(Of String)
End Class