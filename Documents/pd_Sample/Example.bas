' ������ ��������� � �������� DLL GetFIOPadegFSAS � GetNominativePadeg
' ��������� � ������ �������� ����������� ����������

Option Explicit

' ������� ��������� ��� � �������������� ������������ ���� �� ��������
' ���������: pFIO    - �������, ���, ��������
'            nPadeg  - ����� (���������� ��������: 1..6)
'            pResult - ����� ����������
'            nLen    - ������ ������ (����� �������������� - ����� ����������)
' ��������:  0 - �������� ����������
'           -1 - ������������ �������� ������
'           -3 - ��������� �� ���������� � ������

Private Declare Function GetPadeg Lib "Padeg.dll" Alias "GetFIOPadegFSAS" _
  (ByVal pFIO As String, ByVal nPadeg As Long, ByVal pResult As String, _
   ByRef nLen As Long) As Integer

' ������� �������������� ������������� ������
' ���������: pFIO    - �������, ���, ��������
'            pResult - ����� ����������
'            nLen    - ������ ������ (����� �������������� - ����� ����������)
' ��������:  0 - �������� ����������
'           -3 - ��������� �� ���������� � ������

Private Declare Function GetNominativePadeg Lib "Padeg.dll" _
  (ByVal pFIO As String, ByVal pResult As String, ByRef nLen As Long) As Integer

' ������� �������������� cFIO � ����� nPadeg
Public Function MakePadeg(ByVal cFIO As String, ByVal nPadeg As Long) As String
Dim tmpS As String
Dim nLen As Long
Dim RetVal As Integer
  nLen = 255
  tmpS = String(nLen, 0)
  RetVal = GetPadeg(cFIO, nPadeg, tmpS, nLen)
  If RetVal = -1 Then MsgBox "������������ �������� ������ - " & _
                             "(" & nPadeg & ")", , "��������� ���"
  MakePadeg = Mid(tmpS, 1, nLen)
End Function

' ������� �������������� ������������� ������
Public Function Nominative(ByVal cFIO As String) As String
Dim tmpS As String
Dim nLen As Long
Dim RetVal As Integer
  nLen = 255
  tmpS = String(nLen, 0)
  RetVal = GetNominativePadeg(cFIO, tmpS, nLen)
  Nominative = Mid(tmpS, 1, nLen)
End Function

' ������� �������������� ������������� ������ � �������������� ��������� ���� ���
' ���������: cFIO      - ��� � ������������ ������
'            TableNmae - ��� �������, ���������� ���
'            Exact     - ������� ����, ��� ��� ���� � ����         
Public Function NominativeByBase(ByVal cFIO As String, TableName As String, _
                                 Exact As Boolean) As String
Dim sqlStr As String, Mask As String, tmpS As String
Dim rst As Recordset, i As Integer, nLen As Integer
Dim LocalFIO As String

  tmpS = Mid(cFIO, 1, InStr(cFIO, " ") - 1)     ' ������� �������
  If Len(tmpS) > 4 Then nLen = Len(tmpS) - 4 _
                   Else nLen = 1
  Mask = Mid(tmpS, 1, nLen) & "*"               ' ��������� ����� ��� ��� �������
  
  ' ����� ������� ������� � ������ "�������", "���" � "��������"
  ' ��� ���������� ������� ���������� ��������������� ����� �����
  sqlStr = "SELECT �������, ���, �������� FROM [" & TableName & "] " & _
           "WHERE (������� Like '" & Mask & "');"
  
  Set rst = CurrentDb.OpenRecordset(sqlStr)
  If rst.RecordCount > 0 Then rst.MoveFirst
  
  Exact = False                       ' ��� � ���� ������ ���
  While Not rst.EOF                   ' ��� ���� ��� �� ������� � ����
    ' ���������� ��������� ���
    LocalFIO = rst!������� & " " & rst!��� & " " & rst!��������
    For i = 1 To 6
      tmpS = MakePadeg(LocalFIO, i)   ' �������� ��������� ���������� ��� �� ��� ������
      If tmpS = cFIO Then             ' ������� � ��������
        NominativeByBase = LocalFIO   ' ��������� ��������� ������
        Exact = True                  ' ��� ���� � ���� ������
        rst.Close
        Exit Function
      End If
    Next i
    rst.MoveNext
  Wend
  rst.Close
  ' ���� ������ ����, ������: 1. � ���� �� ������� ����������� ���
  '                           2. ��� ��� �������������� ������ � �������
  '                           3. ��� �� ���� ���������� � �������
  ' � ���� ������ ���������� ��. ����� �������� DLL (�������� ������ ��������������)
  NominativeByBase = Nominative(cFIO) 
End Function
