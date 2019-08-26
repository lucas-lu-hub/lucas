Module Module1

    Sub Main()
        Console.WriteLine("please input the number list:")
        Dim source = Console.ReadLine()
        Dim stringList As String() = source.Split(" ")
        Dim numberList As List(Of Integer) = GetIntList(stringList)
        QuickSort(numberList, 0, numberList.Count - 1)
        For Each num In numberList
            Console.WriteLine(num)
        Next

        Console.ReadLine()

    End Sub
    Public Sub QuickSort(ByRef numberList As List(Of Integer), ByVal listStart As Int16, ByVal listEnd As Int16)
        If listStart >= listEnd Or listEnd < 0 Then
            Return
        End If
        Dim mid = (listStart + listEnd) \ 2
        swap(numberList(mid), numberList(listEnd))
        Dim i As Int16 = listStart
        Dim j As Int16 = listEnd - 1
        While i < j
            While i < listEnd And numberList(i) < numberList(listEnd)
                i = i + 1
            End While
            While j > listStart And numberList(j) > numberList(listEnd)
                j = j - 1
            End While
            If i < j Then
                swap(numberList(i), numberList(j))
            End If
        End While
        If numberList(i) > numberList(listEnd) Then
            swap(numberList(i), numberList(listEnd))
        End If
        QuickSort(numberList, listStart, i)
        QuickSort(numberList, i + 1, listEnd)

    End Sub
    Public Sub swap(ByRef a As Int32, ByRef b As Int32)
        Dim c As Int32
        c = a
        a = b
        b = c
    End Sub
    Public Function GetIntList(ByVal source As String()) As List(Of Integer)
        Dim value As Int32
        Dim a = (From str In source
                 Let isInt = Int32.TryParse(str, value)
                 Where isInt
                 Select Int32.Parse(str)
                 ).ToList()
        GetIntList = a
    End Function

End Module
