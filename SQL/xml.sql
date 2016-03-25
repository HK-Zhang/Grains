declare @XMLVar xml = '
<catalog> 
       <book category="ITPro">   
              <title>Windows Step By Step</title>   
              <author>Bill Zack</author>   
              <price>49.99</price> 
       </book> 
       <book category="Developer">   
              <title>Developing ADO .NET</title>   
              <author>Andrew Brust</author>   
              <price>39.93</price> 
       </book> 
       <book category="ITPro">   
              <title>Windows Cluster Server</title>   
              <author>Stephen Forte</author>   
              <price>59.99</price> 
       </book>
</catalog>'

--xml.exist 
select @XMLVar.exist('/catalog/book')-----����1  
select @XMLVar.exist('/catalog/book/@category')-----����1  
select @XMLVar.exist('/catalog/book1')-----����0  
set @XMLVar = null  
select @XMLVar.exist('/catalog/book')-----����null


--xml.value
select @XMLVar.value('/catalog[1]/book[1]','varchar(MAX)')  
select @XMLVar.value('/catalog[1]/book[2]/@category','varchar(MAX)')  
select @XMLVar.value('/catalog[2]/book[1]','varchar(MAX)')  


--xml.query
select @XMLVar.query('/catalog[1]/book')   
select @XMLVar.query('/catalog[1]/book[1]')  
select @XMLVar.query('/catalog[1]/book[2]/author')

--xml.nodes
select T.c.query('.') as result from @XMLVar.nodes('/catalog/book') as T(c)  
select T.c.query('title') as result from @XMLVar.nodes('/catalog/book') as T(c)

--����as first,at last,before,after�ĸ�������Ԫ�ز���ָ����λ�� 
set @XMLVar.modify(
 'insert <first name="at first" /> as first into (/catalog[1]/book[1])')
set @XMLVar.modify(
 'insert <last name="at last"/> as last into (/catalog[1]/book[1])')
set @XMLVar.modify(
 'insert <before name="before"/> before (/catalog[1]/book[1]/author[1])')
set @XMLVar.modify(
 'insert <after name="after"/> after (/catalog[1]/book[1]/author[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--����һ�����ñ������в���
DECLARE @newFeatures xml;
SET @newFeatures = N'
<first>one element</first>
<second>second element</second>'
SET @XMLVar.modify(' 
insert sql:variable("@newFeatures")
into (/catalog[1]/book[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--��������ֱ�Ӳ���
set @XMLVar.modify('
insert (<first>one element</first>,<second>second element</second>)
into (/catalog[1]/book[1]/author[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--ʹ�ñ�������
declare @var nvarchar(10) = '��������'
set @XMLVar.modify(
'insert (attribute var {sql:variable("@var")})
into (/catalog[1]/book[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--ֱ�Ӳ���
set @XMLVar.modify(
'insert (attribute name {"ֱ�Ӳ���"})
into (/catalog[1]/book[1]/title[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--��ֵ����
set @XMLVar.modify(
'insert (attribute Id {"��ֵ����1"},attribute name {"��ֵ����2"}) 
into (/catalog[1]/book[1]/author[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--�����ı��ڵ� 
set @XMLVar.modify(
'insert text{"at first"} as first
into (/catalog[1]/book[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--����ע�ͽڵ� 
set @XMLVar.modify(
'insert <!--��������-->
before (/catalog[1]/book[1]/title[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--���봦��ָ��
set @XMLVar.modify(
'insert <?Program "Instructions.exe" ?>
before (/catalog[1]/book[1]/title[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--���� if ���������в��� 
set @XMLVar.modify(
'insert 
if (/catalog[1]/book[1]/title[2]) then
 text{"this is a 1 step"}
else ( text{"this is a 2 step"} )
 into (/catalog[1]/book[1]/price[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--ɾ������
set @XMLVar.modify('delete /catalog[1]/book[1]/@category')
--ɾ���ڵ�
set @XMLVar.modify('delete /catalog[1]/book[1]/title[1]')
--ɾ������
set @XMLVar.modify('delete /catalog[1]/book[1]/author[1]/text()')
--ȫ��ɾ��
set @XMLVar.modify('delete /catalog[1]/book[2]')
 
SELECT @XMLVar.query('/catalog[1]');

--�滻����
set @XMLVar.modify('replace value of(/catalog[1]/book[1]/@category)
 with ("�滻����")')
--�滻����
set @XMLVar.modify('replace value of(/catalog[1]/book[1]/author[1]/text()[1])
 with("�滻����")')
--�����滻
set @XMLVar.modify('replace value of (/catalog[1]/book[2]/@category)
with(
if(count(/catalog[1]/book)>4) then
 "�����滻1"
else
 "�����滻2")')
 
SELECT @XMLVar.query('/catalog[1]');



