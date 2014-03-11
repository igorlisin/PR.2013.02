
ACCEPT SNAME PROMPT '������� ����� � ������� ����� ����������� �������:';

ACCEPT PATHDLL PROMPT '������� ������ ���� � ����� � ��� ����� ������������ ���������� (C:\padeg.dll):';

-- ������ ����������
CREATE or replace LIBRARY &SNAME..padeg_dll AS '&PATHDLL';

-- ������ �������
CREATE OR REPLACE 
PACKAGE &SNAME..padeg$
IS  
-- ����� ������������ Padeg.dll ������������ dll
-- ������ �.�.      S.Plahov@vaz.ru
-- ���������� �.�.  pgl@gsu.unibel.by
-- ������ ���� ����� 
-- ����� �.�.   nike@protek30.ru 
--
-- MODIFICATION HISTORY
-- Person      Date             Comments
-- ---------   ----------      ------------------------------------------
-- Nike        15.02.2002      Create this package
-- Nike        25.05.2004      Add functions Padeg v3.
/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������� ��������� ������� (pLastName),
����� (pFirstName) � �������� (pMiddleName) ���� (bSex) � �������� �����  (nPadeg).
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetFIOPadeg (
      pLastName    IN       CHAR,
      pFirstName   IN       CHAR,
      pMiddlName   IN       CHAR,
      bSex         IN       BOOLEAN,
      nPadeg       IN       PLS_INTEGER,
      pResult      IN OUT   CHAR,
      nLen         IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetFIOPadeg, WNDS);

   FUNCTION f_GetFIOPadeg (
      pLastName    IN   CHAR,
      pFirstName   IN   CHAR,
      pMiddlName   IN   CHAR,
      bSex         IN   PLS_INTEGER,
      nPadeg       IN   PLS_INTEGER)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetFIOPadeg, WNDS);

/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������� ��������� ������� (pLastName),
����� (pFirstName) � �������� (pMiddleName) � �������� ����� (nPadeg)
� �������������� ������������ ����.
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetFIOPadegAS (
      pLastName    IN       CHAR,
      pFirstName   IN       CHAR,
      pMiddlName   IN       CHAR,
      nPadeg       IN       PLS_INTEGER,
      pResult      IN OUT   CHAR,
      nLen         IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetFIOPadegAS, WNDS);

   FUNCTION f_GetFIOPadegAS (
      pLastName    IN   CHAR,
      pFirstName   IN   CHAR,
      pMiddlName   IN   CHAR,
      nPadeg       IN   PLS_INTEGER)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetFIOPadegAS, WNDS);

/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������� ��������� ������� ����� � ��������,
���������� ����� ������� (pFIO), ���� (bSex) � �������� ����� (nPadeg).
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetFIOPadegFS (
      pFIO      IN       CHAR,
      bSex      IN       BOOLEAN,
      nPadeg    IN       PLS_INTEGER,
      pResult   IN OUT   CHAR,
      nLen      IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetFIOPadegFS, WNDS);

   FUNCTION f_GetFIOPadegFS (pFIO IN CHAR, bSex IN PLS_INTEGER, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetFIOPadegFS, WNDS);

/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������� ��������� ������� ����� � ��������,
���������� ����� ������� (pFIO), � �������� ����� (nPadeg) � �������������� ������������ ����.
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetFIOpadegFSAS (
      pFIO      IN       CHAR,
      nPadeg    IN       PLS_INTEGER,
      pResult   IN OUT   CHAR,
      nLen      IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetFIOpadegFSAS, WNDS);

   FUNCTION f_GetFIOpadegFSAS (pFIO IN CHAR, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetFIOpadegFSAS, WNDS);

/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������� ��������� ����� (pFirstName)
� ������� (pLastName) ���� (bSex) � �������� ����� (nPadeg).
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetIFPadeg (
      pFirstName   IN       CHAR,
      pLastName    IN       CHAR,
      bSex         IN       BOOLEAN,
      nPadeg       IN       PLS_INTEGER,
      pResult      IN OUT   CHAR,
      nLen         IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetIFPadeg, WNDS);

   FUNCTION f_GetIFPadeg (
      pFirstName   IN   CHAR,
      pLastName    IN   CHAR,
      bSex         IN   PLS_INTEGER,
      nPadeg       IN   PLS_INTEGER)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetIFPadeg, WNDS);

/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������� ��������� ����� � ������� (pIF),
���������� ����� �������, ���� (bSex) � ��������� ����� (nPadeg).
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetIFPadegFS (
      pIF       IN       CHAR,
      bSex      IN       BOOLEAN,
      nPadeg    IN       PLS_INTEGER,
      pResult   IN OUT   CHAR,
      nLen      IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetIFPadegFS, WNDS);

   FUNCTION f_GetIFPadegFS (pIF IN CHAR, bSex IN PLS_INTEGER, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetIFPadegFS, WNDS);

/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������������� ������������ ����� ��� ���,
����������� ����� ������� (pFIO) � ������������ ������.
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetNominativePadeg (pFIO IN CHAR, pResult IN OUT CHAR, nLen IN OUT PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetNominativePadeg, WNDS);

   FUNCTION f_GetNominativePadeg (pFIO IN CHAR)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetNominativePadeg, WNDS);

/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������� ��������� ������������
��������� (pAppointment) � �������� ����� (nPadeg).
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetAppointmentPadeg (
      pAppointment   IN       CHAR,
      nPadeg         IN       PLS_INTEGER,
      pResult        IN OUT   CHAR,
      nLen           IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetAppointmentPadeg, WNDS);

   FUNCTION f_GetAppointmentPadeg (pAppointment IN CHAR, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetAppointmentPadeg, WNDS);

/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������� ���������� ������������
��������� (Appointment) � ������������� (Office) � ������ (nPadeg).
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetFullAppointmentPadeg (
      pAppointment   IN       CHAR,
      pOffice        IN       CHAR,
      nPadeg         IN       PLS_INTEGER,
      pResult        IN OUT   CHAR,
      nLen           IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetFullAppointmentPadeg, WNDS);

   FUNCTION f_GetFullAppointmentPadeg (pAppointment IN CHAR, pOffice IN CHAR, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetFullAppointmentPadeg, WNDS);

/*****************************************************************************/
/*�������� � ����� (pResult) ������� (nLen) ��������� ��������� ������������
������������� (pSrc) � �������� ����� (nPadeg).
�������� ������� - ��������� ���������� �������� ��������������.*/
   FUNCTION GetOfficePadeg (
      pOffice   IN       CHAR,
      nPadeg    IN       PLS_INTEGER,
      pResult   IN OUT   CHAR,
      nLen      IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetOfficePadeg, WNDS);

   FUNCTION f_GetOfficePadeg (pOffice IN CHAR, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2;

   PRAGMA RESTRICT_REFERENCES (f_GetOfficePadeg, WNDS);

/*****************************************************************************/
/*���������� ��� �� ��������, ����������� � ������������ ������.*/
   FUNCTION GetSex (pMiddleName IN CHAR)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetSex, WNDS);

   FUNCTION f_GetSex (pMiddleName IN CHAR)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (f_GetSex, WNDS);

/*****************************************************************************/
/*���������� ����� ������ � ������� �������� ���(pFIO).*/
   FUNCTION GetPadegID (pFIO IN CHAR)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (GetPadegID, WNDS);

   FUNCTION f_GetPadegID (pFIO IN CHAR)
      RETURN PLS_INTEGER;

   PRAGMA RESTRICT_REFERENCES (f_GetPadegID, WNDS);
END;                                                                                 -- Package spec
/


CREATE OR REPLACE 
PACKAGE BODY      &SNAME..padeg$ IS
-- MODIFICATION HISTORY
-- Person      Date             Comments
-- ---------   ----------      ------------------------------------------
-- Nike        15.02.2002      Create this package
-- Nike        25.05.2004      Add function for Padeg v3.
/*****************************************************************************/
-- GetFIOPadeg
   FUNCTION GetFIOPadeg (
      pLastName    IN       CHAR,
      pFirstName   IN       CHAR,
      pMiddlName   IN       CHAR,
      bSex         IN       BOOLEAN,
      nPadeg       IN       PLS_INTEGER,
      pResult      IN OUT   CHAR,
      nLen         IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetFIOPadeg"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pLastName STRING,
         pFirstName STRING,
         pMiddlName STRING,
         bSex INT,
         nPadeg LONG,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetFIOPadeg
   FUNCTION f_GetFIOPadeg (
      pLastName    IN   CHAR,
      pFirstName   IN   CHAR,
      pMiddlName   IN   CHAR,
      bSex         IN   PLS_INTEGER,
      nPadeg       IN   PLS_INTEGER)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      err      PLS_INTEGER;
      Sex      BOOLEAN;                                                -- 0- �������; 1- ������� :)
   BEGIN
      IF    (LTRIM (RTRIM (pLastName || ' ' || pFirstName || ' ' || pMiddlName)) = '')
         OR (LENGTH (LTRIM (RTRIM (pLastName || ' ' || pFirstName || ' ' || pMiddlName))) <= 1) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pLastName || ' ' || pFirstName || ' ' || pMiddlName, len, ' ');

      IF bSex = 0 THEN
         Sex := FALSE;
      ELSE
         Sex := TRUE;
      END IF;

      BEGIN
         err := GetFIOPadeg (pLastName, pFirstName, pMiddlName, Sex, nPadeg, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF err = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || err;
      END IF;
   END;

/*****************************************************************************/
-- GetFIOPadegAS
   FUNCTION GetFIOPadegAS (
      pLastName    IN       CHAR,
      pFirstName   IN       CHAR,
      pMiddlName   IN       CHAR,
      nPadeg       IN       PLS_INTEGER,
      pResult      IN OUT   CHAR,
      nLen         IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetFIOPadegAS"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pLastName STRING,
         pFirstName STRING,
         pMiddlName STRING,
         nPadeg LONG,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetFIOPadegAS
   FUNCTION f_GetFIOPadegAS (
      pLastName    IN   CHAR,
      pFirstName   IN   CHAR,
      pMiddlName   IN   CHAR,
      nPadeg       IN   PLS_INTEGER)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      err      PLS_INTEGER;
   BEGIN
      IF    (LTRIM (RTRIM (pLastName || ' ' || pFirstName || ' ' || pMiddlName)) = '')
         OR (LENGTH (LTRIM (RTRIM (pLastName || ' ' || pFirstName || ' ' || pMiddlName))) <= 1) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pLastName || ' ' || pFirstName || ' ' || pMiddlName, len, ' ');

      BEGIN
         err := GetFIOPadegAS (pLastName, pFirstName, pMiddlName, nPadeg, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF err = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || err;
      END IF;
   END;

/*****************************************************************************/
-- GetFIOPadegFS
   FUNCTION GetFIOPadegFS (
      pFIO      IN       CHAR,
      bSex      IN       BOOLEAN,
      nPadeg    IN       PLS_INTEGER,
      pResult   IN OUT   CHAR,
      nLen      IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetFIOPadegFS"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pFIO STRING,
         bSex INT,
         nPadeg LONG,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetFIOPadegFS
   FUNCTION f_GetFIOPadegFS (pFIO IN CHAR, bSex IN PLS_INTEGER, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      err      PLS_INTEGER;
      Sex      BOOLEAN;
   BEGIN
      IF    (LTRIM (RTRIM (pFIO)) = '')
         OR (LENGTH (LTRIM (RTRIM (pFIO))) <= 1)
         OR (pFIO IS NULL) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pFIO, len, ' ');

      IF bSex = 0 THEN
         Sex := FALSE;
      ELSE
         Sex := TRUE;
      END IF;

      BEGIN
         err := GetFIOPadegFS (pFIO, Sex, nPadeg, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF err = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || err;
      END IF;
   END;

/*****************************************************************************/
-- GetFIOpadegFSAS
   FUNCTION GetFIOpadegFSAS (
      pFIO      IN       CHAR,
      nPadeg    IN       PLS_INTEGER,
      pResult   IN OUT   CHAR,
      nLen      IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetFIOPadegFSAS"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pFIO STRING,
         nPadeg LONG,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetFIOPadegFSAS
   FUNCTION f_GetFIOpadegFSAS (pFIO IN CHAR, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      rfs      PLS_INTEGER;
   BEGIN
      IF    (LTRIM (RTRIM (pFIO)) = '')
         OR (LENGTH (LTRIM (RTRIM (pFIO))) <= 1)
         OR (pFIO IS NULL) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pFIO, len, ' ');

      BEGIN
         rfs := GetFIOpadegFSAS (pFIO, nPadeg, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF rfs = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || rfs;
      END IF;
   END;

/*****************************************************************************/
-- GetIFPadeg
   FUNCTION GetIFPadeg (
      pFirstName   IN       CHAR,
      pLastName    IN       CHAR,
      bSex         IN       BOOLEAN,
      nPadeg       IN       PLS_INTEGER,
      pResult      IN OUT   CHAR,
      nLen         IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetIFPadeg"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pFirstName STRING,
         pLastName STRING,
         bSex INT,
         nPadeg LONG,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetIFPadeg
   FUNCTION f_GetIFPadeg (
      pFirstName   IN   CHAR,
      pLastName    IN   CHAR,
      bSex         IN   PLS_INTEGER,
      nPadeg       IN   PLS_INTEGER)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      err      PLS_INTEGER;
      Sex      BOOLEAN;                                                -- 0- �������; 1- ������� :)
   BEGIN
      IF    (LTRIM (RTRIM (pLastName || ' ' || pFirstName)) = '')
         OR (LENGTH (LTRIM (RTRIM (pLastName || ' ' || pFirstName))) <= 1) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pLastName || ' ' || pFirstName, len, ' ');

      IF bSex = 0 THEN
         Sex := FALSE;
      ELSE
         Sex := TRUE;
      END IF;

      BEGIN
         err := GetIFPadeg (pFirstName, pLastName, Sex, nPadeg, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF err = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || err;
      END IF;
   END;

/*****************************************************************************/
-- GetIFPadegFS
   FUNCTION GetIFPadegFS (
      pIF       IN       CHAR,
      bSex      IN       BOOLEAN,
      nPadeg    IN       PLS_INTEGER,
      pResult   IN OUT   CHAR,
      nLen      IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetIFPadegFS"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pIF STRING,
         bSex INT,
         nPadeg LONG,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetIFPadegFS
   FUNCTION f_GetIFPadegFS (pIF IN CHAR, bSex IN PLS_INTEGER, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      err      PLS_INTEGER;
      Sex      BOOLEAN;                                                -- 0- �������; 1- ������� :)
   BEGIN
      IF    (LTRIM (RTRIM (pIF)) = '')
         OR (LENGTH (LTRIM (RTRIM (pIF))) <= 1)
         OR (pIF IS NULL) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pIF, len, ' ');

      IF bSex = 0 THEN
         Sex := FALSE;
      ELSE
         Sex := TRUE;
      END IF;

      BEGIN
         err := GetIFPadegFS (pIF, Sex, nPadeg, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF err = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || err;
      END IF;
   END;

/*****************************************************************************/
-- GetNominativePadeg
   FUNCTION GetNominativePadeg (pFIO IN CHAR, pResult IN OUT CHAR, nLen IN OUT PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetNominativePadeg"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pFIO STRING,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetNominativePadeg
   FUNCTION f_GetNominativePadeg (pFIO IN CHAR)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      err      PLS_INTEGER;
   BEGIN
      IF    (LTRIM (RTRIM (pFIO)) = '')
         OR (LENGTH (LTRIM (RTRIM (pFIO))) <= 1)
         OR (pFIO IS NULL) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pFIO, len, ' ');

      BEGIN
         err := GetNominativePadeg (pFIO, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF err = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || err;
      END IF;
   END;

/*****************************************************************************/
-- GetAppointmentPadeg
   FUNCTION GetAppointmentPadeg (
      pAppointment   IN       CHAR,
      nPadeg         IN       PLS_INTEGER,
      pResult        IN OUT   CHAR,
      nLen           IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetAppointmentPadeg"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pAppointment STRING,
         nPadeg LONG,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetAppointmentPadeg
   FUNCTION f_GetAppointmentPadeg (pAppointment IN CHAR, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      rfs      PLS_INTEGER;
   BEGIN
      IF    (LTRIM (RTRIM (pAppointment)) = '')
         OR (LENGTH (LTRIM (RTRIM (pAppointment))) <= 1)
         OR (pAppointment IS NULL) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pAppointment, len, ' ');

      BEGIN
         rfs := GetAppointmentPadeg (pAppointment, nPadeg, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF rfs = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || rfs;
      END IF;
   END;

/*****************************************************************************/
-- GetFullAppointmentPadeg
   FUNCTION GetFullAppointmentPadeg (
      pAppointment   IN       CHAR,
      pOffice        IN       CHAR,
      nPadeg         IN       PLS_INTEGER,
      pResult        IN OUT   CHAR,
      nLen           IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetFullAppointmentPadeg"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pAppointment STRING,
         pOffice STRING,
         nPadeg LONG,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetFullAppointmentPadeg
   FUNCTION f_GetFullAppointmentPadeg (pAppointment IN CHAR, pOffice IN CHAR, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      rfs      PLS_INTEGER;
   BEGIN
      IF    (LTRIM (RTRIM (pAppointment || ' ' || pOffice)) = '')
         OR (LENGTH (LTRIM (RTRIM (pAppointment || ' ' || pOffice))) <= 1)
         OR (pAppointment IS NULL) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pAppointment || ' ' || pOffice, len, ' ');

      BEGIN
         rfs := GetFullAppointmentPadeg (pAppointment, pOffice, nPadeg, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF rfs = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || rfs;
      END IF;
   END;

/*****************************************************************************/
-- GetOfficePadeg
   FUNCTION GetOfficePadeg (
      pOffice   IN       CHAR,
      nPadeg    IN       PLS_INTEGER,
      pResult   IN OUT   CHAR,
      nLen      IN OUT   PLS_INTEGER)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetOfficePadeg"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pOffice STRING,
         nPadeg LONG,
         pResult STRING,
         nLen LONG
      );

   -- ������������� GetOfficePadeg
   FUNCTION f_GetOfficePadeg (pOffice IN CHAR, nPadeg IN PLS_INTEGER)
      RETURN VARCHAR2 IS
      len      PLS_INTEGER;
      stroka   CHAR (255);
      rfs      PLS_INTEGER;
   BEGIN
      IF    (LTRIM (RTRIM (pOffice)) = '')
         OR (LENGTH (LTRIM (RTRIM (pOffice))) <= 1)
         OR (pOffice IS NULL) THEN
         RETURN '';
      END IF;

      len := 255;
      stroka := LPAD (pOffice, len, ' ');

      BEGIN
         rfs := GetOfficePadeg (pOffice, nPadeg, stroka, len);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      IF rfs = 0 THEN
         RETURN SUBSTR (stroka, 1, len);
      ELSE
         RETURN '������' || rfs;
      END IF;
   END;

/*****************************************************************************/
-- GetSex
   FUNCTION GetSex (pMiddleName IN CHAR)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetSex"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pMiddleName STRING
      );

   -- ������������� GetSex
   FUNCTION f_GetSex (pMiddleName IN CHAR)
      RETURN PLS_INTEGER IS
      Sex   PLS_INTEGER;
   BEGIN
      IF    (LTRIM (RTRIM (pMiddleName)) = '')
         OR (LENGTH (LTRIM (RTRIM (pMiddleName))) <= 1) THEN
         RETURN '';
      END IF;

      BEGIN
         Sex := GetSex (pMiddleName);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      RETURN Sex;
   END;
  
/*****************************************************************************/
-- GetPadegID
   FUNCTION GetPadegID (pFIO IN CHAR)
      RETURN PLS_INTEGER AS
   EXTERNAL
      LANGUAGE c
      CALLING STANDARD pascal
      NAME "GetPadegID"
      LIBRARY &SNAME..padeg_dll
      PARAMETERS (
         pFIO STRING
      );

   -- ������������� GetPadegID
   FUNCTION f_GetPadegID (pFIO IN CHAR)
      RETURN PLS_INTEGER IS
      PadegID   PLS_INTEGER;
   BEGIN
      IF    (LTRIM (RTRIM (pFIO)) = '')
         OR (LENGTH (LTRIM (RTRIM (pFIO))) <= 1) THEN
         RETURN '';
      END IF;

      BEGIN
         PadegID := GetPadegID (pFIO);
      EXCEPTION
         WHEN OTHERS THEN
            RETURN '������';
      END;

      RETURN PadegID;
   END;
END;
/
