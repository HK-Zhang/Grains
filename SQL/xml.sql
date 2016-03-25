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
select @XMLVar.exist('/catalog/book')-----返回1  
select @XMLVar.exist('/catalog/book/@category')-----返回1  
select @XMLVar.exist('/catalog/book1')-----返回0  
set @XMLVar = null  
select @XMLVar.exist('/catalog/book')-----返回null


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

--利用as first,at last,before,after四个参数将元素插入指定的位置 
set @XMLVar.modify(
 'insert <first name="at first" /> as first into (/catalog[1]/book[1])')
set @XMLVar.modify(
 'insert <last name="at last"/> as last into (/catalog[1]/book[1])')
set @XMLVar.modify(
 'insert <before name="before"/> before (/catalog[1]/book[1]/author[1])')
set @XMLVar.modify(
 'insert <after name="after"/> after (/catalog[1]/book[1]/author[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--方法一：利用变量进行插入
DECLARE @newFeatures xml;
SET @newFeatures = N'
<first>one element</first>
<second>second element</second>'
SET @XMLVar.modify(' 
insert sql:variable("@newFeatures")
into (/catalog[1]/book[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--方法二：直接插入
set @XMLVar.modify('
insert (<first>one element</first>,<second>second element</second>)
into (/catalog[1]/book[1]/author[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--使用变量插入
declare @var nvarchar(10) = '变量插入'
set @XMLVar.modify(
'insert (attribute var {sql:variable("@var")})
into (/catalog[1]/book[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--直接插入
set @XMLVar.modify(
'insert (attribute name {"直接插入"})
into (/catalog[1]/book[1]/title[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--多值插入
set @XMLVar.modify(
'insert (attribute Id {"多值插入1"},attribute name {"多值插入2"}) 
into (/catalog[1]/book[1]/author[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--插入文本节点 
set @XMLVar.modify(
'insert text{"at first"} as first
into (/catalog[1]/book[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--插入注释节点 
set @XMLVar.modify(
'insert <!--插入评论-->
before (/catalog[1]/book[1]/title[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--插入处理指令
set @XMLVar.modify(
'insert <?Program "Instructions.exe" ?>
before (/catalog[1]/book[1]/title[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--根据 if 条件语句进行插入 
set @XMLVar.modify(
'insert 
if (/catalog[1]/book[1]/title[2]) then
 text{"this is a 1 step"}
else ( text{"this is a 2 step"} )
 into (/catalog[1]/book[1]/price[1])')
SELECT @XMLVar.query('/catalog[1]/book[1]');

--删除属性
set @XMLVar.modify('delete /catalog[1]/book[1]/@category')
--删除节点
set @XMLVar.modify('delete /catalog[1]/book[1]/title[1]')
--删除内容
set @XMLVar.modify('delete /catalog[1]/book[1]/author[1]/text()')
--全部删除
set @XMLVar.modify('delete /catalog[1]/book[2]')
 
SELECT @XMLVar.query('/catalog[1]');

--替换属性
set @XMLVar.modify('replace value of(/catalog[1]/book[1]/@category)
 with ("替换属性")')
--替换内容
set @XMLVar.modify('replace value of(/catalog[1]/book[1]/author[1]/text()[1])
 with("替换内容")')
--条件替换
set @XMLVar.modify('replace value of (/catalog[1]/book[2]/@category)
with(
if(count(/catalog[1]/book)>4) then
 "条件替换1"
else
 "条件替换2")')
 
SELECT @XMLVar.query('/catalog[1]');



