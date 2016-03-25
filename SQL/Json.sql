-- Create the data type 
IF EXISTS (SELECT * FROM sys.types WHERE name LIKE 'Hierarchy')

  DROP TYPE dbo.Hierarchy

go

CREATE TYPE dbo.Hierarchy AS TABLE

(

   element_id INT NOT NULL, /* internal surrogate primary key gives the order of parsing and the list order */

   sequenceNo [int] NULL, /* the place in the sequence for the element */

   parent_ID INT,/* if the element has a parent then it is in this column. The document is the ultimate parent, so you can get the structure from recursing from the document */

   [Object_ID] INT,/* each list or object has an object id. This ties all elements to a parent. Lists are treated as objects here */

   NAME NVARCHAR(2000),/* the name of the object, null if it hasn't got one */

   StringValue NVARCHAR(MAX) NOT NULL,/*the string representation of the value of the element. */

   ValueType VARCHAR(10) NOT null /* the declared type of the value represented as a string in StringValue*/

    PRIMARY KEY (element_id)

)

go

CREATE FUNCTION dbo.parseJSON( @JSON NVARCHAR(MAX))

RETURNS @hierarchy TABLE

   (

   element_id INT IDENTITY(1, 1) NOT NULL, /* internal surrogate primary key gives the order of parsing and the list order */

   sequenceNo [int] NULL, /* the place in the sequence for the element */

   parent_ID INT,/* if the element has a parent then it is in this column. The document is the ultimate parent, so you can get the structure from recursing from the document */

    Object_ID INT,/* each list or object has an object id. This ties all elements to a parent. Lists are treated as objects here */

   NAME NVARCHAR(2000),/* the name of the object */

   StringValue NVARCHAR(MAX) NOT NULL,/*the string representation of the value of the element. */

   ValueType VARCHAR(10) NOT null /* the declared type of the value represented as a string in StringValue*/

  )

AS

BEGIN

   DECLARE

    @FirstObject INT, --the index of the first open bracket found in the JSON string

    @OpenDelimiter INT,--the index of the next open bracket found in the JSON string

    @NextOpenDelimiter INT,--the index of subsequent open bracket found in the JSON string

    @NextCloseDelimiter INT,--the index of subsequent close bracket found in the JSON string

    @Type NVARCHAR(10),--whether it denotes an object or an array

    @NextCloseDelimiterChar CHAR(1),--either a '}' or a ']'

    @Contents NVARCHAR(MAX), --the unparsed contents of the bracketed expression

    @Start INT, --index of the start of the token that you are parsing

    @end INT,--index of the end of the token that you are parsing

    @param INT,--the parameter at the end of the next Object/Array token

    @EndOfName INT,--the index of the start of the parameter at end of Object/Array token

    @token NVARCHAR(200),--either a string or object

    @value NVARCHAR(MAX), -- the value as a string

    @SequenceNo int, -- the sequence number within a list

    @name NVARCHAR(200), --the name as a string

    @parent_ID INT,--the next parent ID to allocate

    @lenJSON INT,--the current length of the JSON String

    @characters NCHAR(36),--used to convert hex to decimal

    @result BIGINT,--the value of the hex symbol being parsed

    @index SMALLINT,--used for parsing the hex value

    @Escape INT --the index of the next escape character

     

 

   DECLARE @Strings TABLE /* in this temporary table we keep all strings, even the names of the elements, since they are 'escaped' in a different way, and may contain, unescaped, brackets denoting objects or lists. These are replaced in the JSON string by tokens representing the string */

    (

     String_ID INT IDENTITY(1, 1),

     StringValue NVARCHAR(MAX)

     )

   SELECT--initialise the characters to convert hex to ascii

    @characters='0123456789abcdefghijklmnopqrstuvwxyz',

    @SequenceNo=0, --set the sequence no. to something sensible.

  /* firstly we process all strings. This is done because [{} and ] aren't escaped in strings, which complicates an iterative parse. */

    @parent_ID=0;

   WHILE 1=1 --forever until there is nothing more to do

     BEGIN

       SELECT

        @start=PATINDEX('%[^a-zA-Z]["]%', @json collate SQL_Latin1_General_CP850_Bin);--next delimited string

       IF @start=0 BREAK --no more so drop through the WHILE loop

       IF SUBSTRING(@json, @start+1, 1)='"' 

        BEGIN --Delimited Name

          SET @start=@Start+1;

          SET @end=PATINDEX('%[^\]["]%', RIGHT(@json, LEN(@json+'|')-@start) collate SQL_Latin1_General_CP850_Bin);

        END

       IF @end=0 --no end delimiter to last string

        BREAK --no more

       SELECT @token=SUBSTRING(@json, @start+1, @end-1)

       --now put in the escaped control characters

       SELECT @token=REPLACE(@token, FROMString, TOString)

       FROM

        (SELECT

          '\"' AS FromString, '"' AS ToString

         UNION ALL SELECT '\\', '\'

         UNION ALL SELECT '\/', '/'

         UNION ALL SELECT '\b', CHAR(08)

         UNION ALL SELECT '\f', CHAR(12)

         UNION ALL SELECT '\n', CHAR(10)

         UNION ALL SELECT '\r', CHAR(13)

         UNION ALL SELECT '\t', CHAR(09)

        ) substitutions

       SELECT @result=0, @escape=1

   --Begin to take out any hex escape codes

       WHILE @escape>0

        BEGIN

          SELECT @index=0,

          --find the next hex escape sequence

          @escape=PATINDEX('%\x[0-9a-f][0-9a-f][0-9a-f][0-9a-f]%', @token collate SQL_Latin1_General_CP850_Bin)

          IF @escape>0 --if there is one

            BEGIN

              WHILE @index<4  --there are always four digits to a \x sequence    

                BEGIN 

                  SELECT --determine its value

                    @result=@result+POWER(16, @index)

                    *(CHARINDEX(SUBSTRING(@token, @escape+2+3-@index, 1),

                                @characters)-1), @index=@index+1 ;

         

                END

                -- and replace the hex sequence by its unicode value

              SELECT @token=STUFF(@token, @escape, 6, NCHAR(@result))

            END

        END

       --now store the string away 

       INSERT INTO @Strings  (StringValue) SELECT @token

       -- and replace the string with a token

       SELECT @JSON=STUFF(@json, @start, @end+1,

                    '@string'+CONVERT(NVARCHAR(5), @@identity))

     END

  -- all strings are now removed. Now we find the first leaf.   

   WHILE 1=1   --forever until there is nothing more to do

   BEGIN

 

   SELECT @parent_ID=@parent_ID+1

   --find the first object or list by looking for the open bracket

   SELECT @FirstObject=PATINDEX('%[{[[]%', @json collate SQL_Latin1_General_CP850_Bin)--object or array

  IF @FirstObject = 0 BREAK

  IF (SUBSTRING(@json, @FirstObject, 1)='{') 

     SELECT @NextCloseDelimiterChar='}', @type='object'

  ELSE 

     SELECT @NextCloseDelimiterChar=']', @type='array'

   SELECT @OpenDelimiter=@firstObject

 

   WHILE 1=1 --find the innermost object or list...

     BEGIN

       SELECT

        @lenJSON=LEN(@JSON+'|')-1

   --find the matching close-delimiter proceeding after the open-delimiter

       SELECT

        @NextCloseDelimiter=CHARINDEX(@NextCloseDelimiterChar, @json,

                                      @OpenDelimiter+1)

   --is there an intervening open-delimiter of either type

       SELECT @NextOpenDelimiter=PATINDEX('%[{[[]%',

             RIGHT(@json, @lenJSON-@OpenDelimiter)collate SQL_Latin1_General_CP850_Bin)--object

       IF @NextOpenDelimiter=0 

        BREAK

       SELECT @NextOpenDelimiter=@NextOpenDelimiter+@OpenDelimiter

       IF @NextCloseDelimiter<@NextOpenDelimiter 

        BREAK

       IF SUBSTRING(@json, @NextOpenDelimiter, 1)='{' 

        SELECT @NextCloseDelimiterChar='}', @type='object'

       ELSE 

        SELECT @NextCloseDelimiterChar=']', @type='array'

       SELECT @OpenDelimiter=@NextOpenDelimiter

     END

   ---and parse out the list or name/value pairs

   SELECT

    @contents=SUBSTRING(@json, @OpenDelimiter+1,

                        @NextCloseDelimiter-@OpenDelimiter-1)

   SELECT

    @JSON=STUFF(@json, @OpenDelimiter,

                @NextCloseDelimiter-@OpenDelimiter+1,

                '@'+@type+CONVERT(NVARCHAR(5), @parent_ID))

   WHILE (PATINDEX('%[A-Za-z0-9@+.e]%', @contents collate SQL_Latin1_General_CP850_Bin))<>0 

     BEGIN

       IF @Type='Object' --it will be a 0-n list containing a string followed by a string, number,boolean, or null

        BEGIN

          SELECT

            @SequenceNo=0,@end=CHARINDEX(':', ' '+@contents)--if there is anything, it will be a string-based name.

          SELECT  @start=PATINDEX('%[^A-Za-z@][@]%', ' '+@contents collate SQL_Latin1_General_CP850_Bin)--AAAAAAAA

          SELECT @token=SUBSTRING(' '+@contents, @start+1, @End-@Start-1),

            @endofname=PATINDEX('%[0-9]%', @token collate SQL_Latin1_General_CP850_Bin),

            @param=RIGHT(@token, LEN(@token)-@endofname+1)

          SELECT

            @token=LEFT(@token, @endofname-1),

            @Contents=RIGHT(' '+@contents, LEN(' '+@contents+'|')-@end-1)

          SELECT  @name=stringvalue FROM @strings

            WHERE string_id=@param --fetch the name

        END

       ELSE 

        SELECT @Name=null,@SequenceNo=@SequenceNo+1 

       SELECT

        @end=CHARINDEX(',', @contents)-- a string-token, object-token, list-token, number,boolean, or null

       IF @end=0 

        SELECT  @end=PATINDEX('%[A-Za-z0-9@+.e][^A-Za-z0-9@+.e]%', @Contents+' ' collate SQL_Latin1_General_CP850_Bin)

          +1

        SELECT

        @start=PATINDEX('%[^A-Za-z0-9@+.e][A-Za-z0-9@+.e]%', ' '+@contents collate SQL_Latin1_General_CP850_Bin)

       --select @start,@end, LEN(@contents+'|'), @contents  

       SELECT

        @Value=RTRIM(SUBSTRING(@contents, @start, @End-@Start)),

        @Contents=RIGHT(@contents+' ', LEN(@contents+'|')-@end)

       IF SUBSTRING(@value, 1, 7)='@object' 

        INSERT INTO @hierarchy

          (NAME, SequenceNo, parent_ID, StringValue, Object_ID, ValueType)

          SELECT @name, @SequenceNo, @parent_ID, SUBSTRING(@value, 8, 5),

            SUBSTRING(@value, 8, 5), 'object' 

       ELSE 

        IF SUBSTRING(@value, 1, 6)='@array' 

          INSERT INTO @hierarchy

            (NAME, SequenceNo, parent_ID, StringValue, Object_ID, ValueType)

            SELECT @name, @SequenceNo, @parent_ID, SUBSTRING(@value, 7, 5),

              SUBSTRING(@value, 7, 5), 'array' 

        ELSE 

          IF SUBSTRING(@value, 1, 7)='@string' 

            INSERT INTO @hierarchy

              (NAME, SequenceNo, parent_ID, StringValue, ValueType)

              SELECT @name, @SequenceNo, @parent_ID, stringvalue,  'string'

              FROM @strings

              WHERE string_id=SUBSTRING(@value, 8, 5)

          ELSE 

            IF @value IN  ('true', 'false') 

              INSERT INTO @hierarchy

                (NAME, SequenceNo, parent_ID, StringValue, ValueType)

                SELECT @name, @SequenceNo, @parent_ID, @value, 'boolean'

            ELSE 

              IF @value='null' 

                INSERT INTO @hierarchy

                  (NAME, SequenceNo, parent_ID, StringValue, ValueType)

                  SELECT @name, @SequenceNo, @parent_ID, @value, 'null'

              ELSE 

                IF PATINDEX('%[^0-9]%', @value collate SQL_Latin1_General_CP850_Bin)>0 

                  INSERT INTO @hierarchy

                    (NAME, SequenceNo, parent_ID, StringValue, ValueType)

                    SELECT @name, @SequenceNo, @parent_ID, @value, 'real'

                ELSE 

                  INSERT INTO @hierarchy

                    (NAME, SequenceNo, parent_ID, StringValue, ValueType)

                    SELECT @name, @SequenceNo, @parent_ID, @value, 'int'

       if @Contents=' ' Select @SequenceNo=0

     END

  END

INSERT INTO @hierarchy (NAME, SequenceNo, parent_ID, StringValue, Object_ID, ValueType)

   SELECT '-',1, NULL, '', @parent_id-1, @type

--

    RETURN

END

GO

IF OBJECT_ID (N'dbo.parseJSON') IS NOT NULL 
   DROP FUNCTION dbo.JSONEscaped

GO

 

CREATE FUNCTION JSONEscaped ( /* this is a simple utility function that takes a SQL String with all its clobber and outputs it as a sting with all the JSON escape sequences in it.*/

  @Unescaped NVARCHAR(MAX) --a string with maybe characters that will break json

  )

RETURNS NVARCHAR(MAX)

AS 

BEGIN

  SELECT  @Unescaped = REPLACE(@Unescaped, FROMString, TOString)

  FROM    (SELECT

            '\"' AS FromString, '"' AS ToString

           UNION ALL SELECT '\', '\\'

           UNION ALL SELECT '/', '\/'

           UNION ALL SELECT  CHAR(08),'\b'

           UNION ALL SELECT  CHAR(12),'\f'

           UNION ALL SELECT  CHAR(10),'\n'

           UNION ALL SELECT  CHAR(13),'\r'

           UNION ALL SELECT  CHAR(09),'\t'

          ) substitutions

RETURN @Unescaped

END

GO

CREATE FUNCTION ToJSON

(

       @Hierarchy Hierarchy READONLY

)

 

/*

the function that takes a Hierarchy table and converts it to a JSON string

 

Author: Phil Factor

Revision: 1.5

date: 1 May 2014

why: Added a fix to add a name for a list.

example:

 

Declare @XMLSample XML

Select @XMLSample='

   <glossary><title>example glossary</title>

  <GlossDiv><title>S</title>

   <GlossList>

    <GlossEntry ID="SGML" SortAs="SGML">

      <GlossTerm>Standard Generalized Markup Language</GlossTerm>

      <Acronym>SGML</Acronym>

      <Abbrev>ISO 8879:1986</Abbrev>

      <GlossDef>

      <para>A meta-markup language, used to create markup languages such as DocBook.</para>

      <GlossSeeAlso OtherTerm="GML" />

      <GlossSeeAlso OtherTerm="XML" />

      </GlossDef>

      <GlossSee OtherTerm="markup" />

    </GlossEntry>

   </GlossList>

  </GlossDiv>

 </glossary>'

 

DECLARE @MyHierarchy Hierarchy -- to pass the hierarchy table around

insert into @MyHierarchy select * from dbo.ParseXML(@XMLSample)

SELECT dbo.ToJSON(@MyHierarchy)

 

       */

RETURNS NVARCHAR(MAX)--JSON documents are always unicode.

AS

BEGIN

   DECLARE

    @JSON NVARCHAR(MAX),

    @NewJSON NVARCHAR(MAX),

    @Where INT,

    @ANumber INT,

    @notNumber INT,

    @indent INT,

    @ii int,

    @CrLf CHAR(2)--just a simple utility to save typing!

       

   --firstly get the root token into place 

   SELECT @CrLf=CHAR(13)+CHAR(10),--just CHAR(10) in UNIX

         @JSON = CASE ValueType WHEN 'array' THEN 

         +COALESCE('{'+@CrLf+'  "'+NAME+'" : ','')+'[' 

         ELSE '{' END

            +@CrLf

            + case when ValueType='array' and NAME is not null then '  ' else '' end

            + '@Object'+CONVERT(VARCHAR(5),OBJECT_ID)

            +@CrLf+CASE ValueType WHEN 'array' THEN

            case when NAME is null then ']' else '  ]'+@CrLf+'}'+@CrLf end

                ELSE '}' END

  FROM @Hierarchy 

     WHERE parent_id IS NULL AND valueType IN  ('object','document','array') --get the root element

/* now we simply iterat from the root token growing each branch and leaf in each iteration. This won't be enormously quick, but it is simple to do. All values, or name/value pairs withing a structure can be created in one SQL Statement*/

   Select @ii=1000

   WHILE @ii>0

     begin

     SELECT @where= PATINDEX('%[^[a-zA-Z0-9]@Object%',@json)--find NEXT token

     if @where=0 BREAK

     /* this is slightly painful. we get the indent of the object we've found by looking backwards up the string */ 

     SET @indent=CHARINDEX(char(10)+char(13),Reverse(LEFT(@json,@where))+char(10)+char(13))-1

     SET @NotNumber= PATINDEX('%[^0-9]%', RIGHT(@json,LEN(@JSON+'|')-@Where-8)+' ')--find NEXT token

     SET @NewJSON=NULL --this contains the structure in its JSON form

     SELECT  

        @NewJSON=COALESCE(@NewJSON+','+@CrLf+SPACE(@indent),'')

        +case when parent.ValueType='array' then '' else COALESCE('"'+TheRow.NAME+'" : ','') end

        +CASE TheRow.valuetype 

        WHEN 'array' THEN '  ['+@CrLf+SPACE(@indent+2)

           +'@Object'+CONVERT(VARCHAR(5),TheRow.[OBJECT_ID])+@CrLf+SPACE(@indent+2)+']' 

        WHEN 'object' then '  {'+@CrLf+SPACE(@indent+2)

           +'@Object'+CONVERT(VARCHAR(5),TheRow.[OBJECT_ID])+@CrLf+SPACE(@indent+2)+'}'

        WHEN 'string' THEN '"'+dbo.JSONEscaped(TheRow.StringValue)+'"'

        ELSE TheRow.StringValue

        END 

      FROM @Hierarchy TheRow 

      inner join @hierarchy Parent

      on parent.element_ID=TheRow.parent_ID

       WHERE TheRow.parent_id= SUBSTRING(@JSON,@where+8, @Notnumber-1)

      /* basically, we just lookup the structure based on the ID that is appended to the @Object token. Simple eh? */

     --now we replace the token with the structure, maybe with more tokens in it.

     Select @JSON=STUFF (@JSON, @where+1, 8+@NotNumber-1, @NewJSON),@ii=@ii-1

     end

   return @JSON

end

go

IF OBJECT_ID (N'dbo.ToXML') IS NOT NULL

   DROP FUNCTION dbo.ToXML

GO

CREATE FUNCTION ToXML

(

/*this function converts a Hierarchy table into an XML document. This uses the same technique as the toJSON function, and uses the 'entities' form of XML syntax to give a compact rendering of the structure */

      @Hierarchy Hierarchy READONLY

)

RETURNS NVARCHAR(MAX)--use unicode.

AS

BEGIN

  DECLARE

    @XMLAsString NVARCHAR(MAX),

    @NewXML NVARCHAR(MAX),

    @Entities NVARCHAR(MAX),

    @Objects NVARCHAR(MAX),

    @Name NVARCHAR(200),

    @Where INT,

    @ANumber INT,

    @notNumber INT,

    @indent INT,

    @CrLf CHAR(2)--just a simple utility to save typing!

      

  --firstly get the root token into place 

  --firstly get the root token into place 

  SELECT @CrLf=CHAR(13)+CHAR(10),--just CHAR(10) in UNIX

         @XMLasString ='<?xml version="1.0" ?>

@Object'+CONVERT(VARCHAR(5),OBJECT_ID)+'

'

    FROM @hierarchy 

    WHERE parent_id IS NULL AND valueType IN ('object','array') --get the root element

/* now we simply iterate from the root token growing each branch and leaf in each iteration. This won't be enormously quick, but it is simple to do. All values, or name/value pairs within a structure can be created in one SQL Statement*/

  WHILE 1=1

    begin

    SELECT @where= PATINDEX('%[^a-zA-Z0-9]@Object%',@XMLAsString)--find NEXT token

    if @where=0 BREAK

    /* this is slightly painful. we get the indent of the object we've found by looking backwards up the string */ 

    SET @indent=CHARINDEX(char(10)+char(13),Reverse(LEFT(@XMLasString,@where))+char(10)+char(13))-1

    SET @NotNumber= PATINDEX('%[^0-9]%', RIGHT(@XMLasString,LEN(@XMLAsString+'|')-@Where-8)+' ')--find NEXT token

    SET @Entities=NULL --this contains the structure in its XML form

    SELECT @Entities=COALESCE(@Entities+' ',' ')+NAME+'="'

     +REPLACE(REPLACE(REPLACE(StringValue, '<', '&lt;'), '&', '&amp;'),'>', '&gt;')

     + '"'  

       FROM @hierarchy 

       WHERE parent_id= SUBSTRING(@XMLasString,@where+8, @Notnumber-1) 

          AND ValueType NOT IN ('array', 'object')

    SELECT @Entities=COALESCE(@entities,''),@Objects='',@name=CASE WHEN Name='-' THEN 'root' ELSE NAME end

      FROM @hierarchy 

      WHERE [Object_id]= SUBSTRING(@XMLasString,@where+8, @Notnumber-1) 

    

    SELECT  @Objects=@Objects+@CrLf+SPACE(@indent+2)

           +'@Object'+CONVERT(VARCHAR(5),OBJECT_ID)

           --+@CrLf+SPACE(@indent+2)+''

      FROM @hierarchy 

      WHERE parent_id= SUBSTRING(@XMLasString,@where+8, @Notnumber-1) 

      AND ValueType IN ('array', 'object')

    IF @Objects='' --if it is a lef, we can do a more compact rendering

         SELECT @NewXML='<'+COALESCE(@name,'item')+@entities+' />'

    ELSE

        SELECT @NewXML='<'+COALESCE(@name,'item')+@entities+'>'

            +@Objects+@CrLf++SPACE(@indent)+'</'+COALESCE(@name,'item')+'>'

     /* basically, we just lookup the structure based on the ID that is appended to the @Object token. Simple eh? */

    --now we replace the token with the structure, maybe with more tokens in it.

    Select @XMLasString=STUFF (@XMLasString, @where+1, 8+@NotNumber-1, @NewXML)

    end

  return @XMLasString

  end

go