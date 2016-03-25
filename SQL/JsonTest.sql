Select * from parseJSON('{
  "联系人":
  {
     "姓名": "huang",
     "网名": "HTL",
     "AGE": 05,
     "男人":true,
      "PhoneNumbers":
     {
        "mobile":"135123100514",
        "phone":"0251-123456789"
     }
     
  }
}
')  

--条件查询：
Select * from parseJSON('{
  "联系人":
  {
     "姓名": "huang",
     "网名": "HTL",
     "AGE": 05,
     "男人":true     
  }
}
') 
 WHERE name='姓名'

 --排序
 Select * from parseJSON('{
  "联系人":
  {
     "姓名": "huang",
     "网名": "HTL",
     "AGE": 05,
     "男人":true
     
  }
}
') 
ORDER BY name 

--分组查询
Select valuetype from parseJSON('{
  "联系人":
  {
     "姓名": "huang",
     "网名": "HTL",
     "AGE": 05,
     "男人":true       
  }
}
') 
GROUP BY valuetype

--converting a JSON string into XML

DECLARE @MyHierarchy Hierarchy,@xml XML

INSERT INTO @myHierarchy 

select * from parseJSON('{"menu": {

  "id": "file",

  "value": "File",

  "popup": {

    "menuitem": [

      {"value": "New", "onclick": "CreateNewDoc()"},

      {"value": "Open", "onclick": "OpenDoc()"},

      {"value": "Close", "onclick": "CloseDoc()"}

    ]

  }

}}')

SELECT dbo.ToXML(@MyHierarchy)

SELECT @XML=dbo.ToXML(@MyHierarchy)

SELECT @XML

--extract the data from a JSON document:
Select * from parseJSON('{  
  "Person": 

  {

     "firstName": "John",

     "lastName": "Smith",

     "age": 25,

     "Address": 

     {

        "streetAddress":"21 2nd Street",

        "city":"New York",

        "state":"NY",

        "postalCode":"10021"

     },

     "PhoneNumbers": 

     {

        "home":"212 555-1234",

        "fax":"646 555-4567"

     }

  }

}

')

--to json
DECLARE @MyHierarchy Hierarchy 
INSERT INTO @myHierarchy 

select * from parseJSON('{"menu": {

  "id": "file",

  "value": "File",

  "popup": {

    "menuitem": [

      {"value": "New", "onclick": "CreateNewDoc()"},

      {"value": "Open", "onclick": "OpenDoc()"},

      {"value": "Close", "onclick": "CloseDoc()"}

    ]

  }

}}')

SELECT dbo.ToJSON(@MyHierarchy)
