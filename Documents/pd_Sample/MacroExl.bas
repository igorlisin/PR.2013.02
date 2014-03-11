' ������ ��������� � �������� DLL GetFIOPadegFSAS � GetNominativePadeg
' ��������� � ������ �������� ����������� ����������
' Copyright (c) 2001 Gennady Pokatashkin e-mail: pgl@tut.by
'                    Sergey Plahov e-mail: S.Plahov@vaz.ru

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
  (ByVal pFIO As String, ByVal nPadeg As Long, ByVal pResult As String, ByRef nLen As Long) As Integer

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
  If Len(cFIO) = 1 Then Exit Function
  nLen = 255
  tmpS = String(nLen, 0)
  RetVal = GetPadeg(cFIO, nPadeg, tmpS, nLen)
  If RetVal = -1 Then MsgBox "������������ �������� ������ - " & "(" & nPadeg & ")", , "��������� ���"
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


' ������� �������������� ��� � �������� ������ � ��������������� �����

Public Sub ������������()
  Cells(ActiveCell.Row, ActiveCell.Column) = Nominative(ActiveCell)
End Sub

Public Sub �����������()
  Cells(ActiveCell.Row, ActiveCell.Column) = MakePadeg(ActiveCell, 2)
End Sub

Public Sub ���������()
  Cells(ActiveCell.Row, ActiveCell.Column) = MakePadeg(ActiveCell, 3)
End Sub

Public Sub �����������()
  Cells(ActiveCell.Row, ActiveCell.Column) = MakePadeg(ActiveCell, 4)
End Sub

Public Sub ������������()
  Cells(ActiveCell.Row, ActiveCell.Column) = MakePadeg(ActiveCell, 5)
End Sub

Public Sub ����������()
  Cells(ActiveCell.Row, ActiveCell.Column) = MakePadeg(ActiveCell, 6)
End Sub
