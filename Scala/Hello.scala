object hello extends App {
  val greets=new Array[String](3)
  greets(0)="Hello"
  greets(1)=","
  greets(2)="world"
  for(i<-0 to 2)
    print(greets(i))
  println("")

  println(greets.hashCode())
  val greets2=new Array[String](3)
  greets2(0)="Hello"
  greets2(1)=","
  greets2(2)="world"
  println(greets2.hashCode())
}

object listDemo extends App{
  val onetwothreefour=1::2::3::Nil
  print(onetwothreefour)
}

object TupleDeom extends App{
  val pair=(99,"one zero")
  println(pair._1)
}

object SetDemo extends App{
  var immutableSet = Set("A","B")
  println("[immutable]Before Change:"+immutableSet.hashCode())
  immutableSet+="C"
  println("[immutable]After Change: "+immutableSet.hashCode())

  val mutableSet = scala.collection.mutable.Set("C","D")
  println("[mutable]Before Change:"+mutableSet.hashCode())
  mutableSet+="C"
  println("[mutable]After Change:"+mutableSet.hashCode())

  val mutableSet1 = scala.collection.mutable.Set("A","B")
  println("[mutable]Before Change:"+mutableSet1.hashCode())
  mutableSet1+="C"
  println("[mutable]After Change:"+mutableSet1.hashCode())
  println(immutableSet.eq(mutableSet1))

  val mutableSet2 = scala.collection.mutable.Set("C","D")
  println("[mutable]Before Change:"+mutableSet2.hashCode())
  mutableSet2+="C"
  println("[mutable]After Change:"+mutableSet2.hashCode())

}

object MapDemo extends App{
  var immutableMap = Map(1->"A",2->"B")
  var mtmp=immutableMap
  println("[immutable]Before Change:"+immutableMap.hashCode())
  immutableMap += 3->"C"
  println(immutableMap(3))
  println("[immutable]After Change:"+immutableMap.hashCode())
  println(mtmp.eq(immutableMap))

  var mutableMap = scala.collection.mutable.Map(3->"A",4->"B")
  var mtmp2=mutableMap
  println("[mutable]Before Change:"+mutableMap.hashCode())
  mutableMap += 3->"C"
  println("[mutable]After Change:"+mutableMap.hashCode())
  println(mtmp2.eq(mutableMap))

  var mutableMap2 = scala.collection.mutable.Map(1->"A",2->"B")
  println("[mutable]Before Change:"+mutableMap2.hashCode())
  println(immutableMap.eq(mutableMap2))
  mutableMap2+= 3->"C"
  println("[mutable]After Change:"+mutableMap2.hashCode())
  println(immutableMap.eq(mutableMap2))

  var mutableMap3 = scala.collection.mutable.Map(3->"A",4->"B")
  println("[mutable]Before Change:"+mutableMap3.hashCode())
  println(mutableMap3.eq(mutableMap))
  mutableMap3 += 3->"C"
  println("[mutable]After Change:"+mutableMap3.hashCode())
  println(mutableMap3.eq(mutableMap))


}

class Worker private{
  def work()=println("I am the only worker")
}

object Worker{
  val worker = new Worker
  def GetWorkerInstance(): Worker={
  worker.work()
    worker
  }
}

object Job{
  def main(args: Array[String]): Unit={
    for(i <- 1 to 5){
      Worker.GetWorkerInstance()
    }
  }
}

object ByteDemo extends App{
  var s='H'
  println(s.toByte)
  println(~(s.toByte & 0xFF)+1)

  var str="Every value is an object"
  for(c<-str) println(c)

}

import scala.collection.mutable.Map
class ChecksumAccumulator{
  private var sum=0
  def add(b:Byte)={
    sum+=b
  }

  def checkSum():Int= ~(sum & 0xFF) + 1
}

  object ChecksumAccumulator{
    private val cache=Map[String,Int]()
    def calculate(s:String):Int={
      if(cache.contains(s))
      cache(s)
      else{
        val acc=new ChecksumAccumulator
        for(c<-s) acc.add(c.toByte)
        val cs=acc.checkSum()
        cache+=(s->cs)
        cs
      }
    }
  }

object Summer{
  def main (args: Array[String]) {
    println(ChecksumAccumulator.calculate("Every value is an object"))
  }
}

class Rational(n:Int,d:Int){
  require(d!=0)
  private val g=gcd(n.abs,d.abs)
  val number = n/g
  val denom = d/g

  override def toString= {if(denom==1) number.toString else number+"/"+denom}

  def +(that:Rational):Rational=new Rational(number*that.denom+denom*that.number,denom*that.denom)

  def +(i:Int):Rational=new Rational(number+i*denom,denom)

  def *(that:Rational):Rational=new Rational(number*that.number,denom*that.denom)

  def lessThan(that:Rational)=number*that.denom<denom*that.number

  def max(that:Rational):Rational={
    if(lessThan(that)) that else this
  }

  def this(i:Int)=this(i,1)

  private def gcd(a:Int,b:Int): Int ={
    if(b==0) a else gcd(b,a%b)
  }



}

object TestRational{
  def main(args: Array[String]) {
    implicit def intToRational(x:Int) = new Rational(x)
    val r=new Rational(3,6)
    val t=new Rational(1,2)
    println((r+t*r).toString)
    println((r+1).toString)
    println((1+r).toString)
    println(r.max(t))
  }
}

object controlTest extends App{
  val boolVal=if(true) "true" else "false"
  println(boolVal)

  def fileLines(file:java.io.File)=scala.io.Source.fromFile(file).getLines().toList

  val filesHere = (new File("./src")).listFiles()
  for(file<-filesHere
      if file.isFile
      if file.getName.endsWith(".iml")
  )
    println(file)

  def grep(pattern:String)=
  for(file<-filesHere
      if file.getName.endsWith(".scala");
  line<-fileLines(file)
  if line.trim.matches(pattern)
  )
    println(file+":"+line.trim)

  def grep2(pattern: String) =
    for {file <- filesHere
         if file.getName.endsWith(".scala")
         line <- fileLines(file)
         trimmed = line.trim
         if trimmed.matches(pattern)
    }
      println(file + ":" + trimmed)

  grep2(".*gcd.*")

  def scalaFiles=for{
    file <- filesHere
    if file.getName.endsWith(".scala")
  } yield file

  println(scalaFiles.length)



}

object tryTest extends App{
  val n=3


 try{
   val f = new java.io.FileReader("input.txt")
 }catch{
   case ex:FileNotFoundException => println("no this file")
   case ex:java.io.IOException => println("this is a IO error")
 }finally {
   println("END")
 }

  def f():Int=try {return 1} finally {return 2}

  println(f())

  val half=
    if(n%2==0)
      n/2
    else
      throw new RuntimeException("n must be even")
}

object matchTest{
  def main(args:Array[String]): Unit ={
    val firstArg = if(args.length>0) args(0) else ""
    val friend = firstArg match{
      case "salt"=>"pepper"
      case "chips"=>"salsa"
      case "eggs" => "bacon"
      case _ => "huh?"
    }

    println(friend)
  }
}

object createArgs{
  val greets=new Array[String](3)
  greets(0)="Hello"
  greets(1)=","
  greets(2)="World.scala"

}

object breakTest extends App{
  var i=0
  var foundIt=false
  var args2=createArgs.greets

  while(i<args2.length && !foundIt){
    if(!args2(i).startsWith("-")){
      if(args2(i).endsWith(".scala")){
        foundIt=true
        println(args2(i))
      }
    }
    i=i+1
  }

  i=0
  def searchFrom(i:Int):Int=
  if(i >= args2.length) -1
  else if(args2(i).startsWith("-")) searchFrom(i+1)
  else if(args2(i).endsWith(".scala")) i
  else searchFrom(i+1)

  val j=searchFrom(0)
  println(args2(j))

}

import scala.io.Source
object LongLines{
  def processFile(fileName:String, width:Int): Unit ={
    def processLine(line:String): Unit ={
      if(line.length>width) println(fileName+":"+line.trim)
    }


    val source= Source.fromFile(fileName)
    for (line <- source.getLines())
      processLine(line)
}
}

object funTest extends App{
  var increase=(x:Int)=>x+1
  val someNumbers = List ( -11, -10, - 5, 0, 5, 10)
  def sum=(_:Int)+(_:Int)+(_:Int)
  val sumb=sum(1,_:Int,2)
  //println(someNumbers.foreach(increase))
  someNumbers.foreach((x:Int) => println(x))
  someNumbers.foreach(x=>println(x-1))
  someNumbers.filter(_>1).foreach(println(_))
  someNumbers.foreach(println)

  val f=(_:Int)+(_:Int)
  println(f(5,10))
  println(sum(7,8,9))
  println(sumb(3))

}

object closureTest extends App{
  val more=1
  def addMore=(x:Int)=>x+1
  val minusMore=(x:Int)=>x-1
  println(addMore(10))
  println(minusMore(10))

  val someNumbers = List ( -11, -10, - 5, 0, 5, 10)
  var sum=0
  someNumbers.foreach(sum+=_)
  println(sum)
}

object functionArgsTest extends App{
  def echo(args:String *): Unit ={
    for(arg<-args) println(arg)
  }

  var arr=Array[String]("I","am","Scala")
  echo("Hello", "World")
  echo(arr:_*)

  def speed(distance:Float,time:Float):Float=distance/time
  println(speed(100,10))
  println(speed(distance = 100,time=10))
  println(speed(time=10,distance = 100))

  def printTime(out:java.io.PrintStream=Console.out,divisor:Int=1)=
    out.println("Time ="+System.currentTimeMillis()/divisor)

  printTime()
  printTime(divisor = 1000)
}

object recursionTest extends App{
  def boom(x:Int):Int=if(x==0) throw new Exception("boom") else boom(x-1)+1

  boom(5)
}

object tailRecursionTest extends App{
  def boom(x:Int):Int=if(x==0) throw new Exception("boom") else boom(x-1)
  boom(5)
}

object delegateTest extends App{
    val filesHere = (new File("./src")).listFiles()
    filesHere.foreach(println)

    def filesMatching(matcher: (String) => Boolean) = {
      for(file <- filesHere; if matcher(file.getName))
        yield file
    }

    def rB(t:String,r:String):Boolean={
      println(t+":"+r)
      true
    }

    def filesEnding(query:String) = {
      filesMatching(_.endsWith(query))
    }

    def filesContaining(query:String)= filesMatching(_.contains(query))

    def filesRegex(query:String) = filesMatching(_.matches(query))

    def filesrB(query:String) = {
      filesMatching(rB(_,query))
    }


    print(filesEnding("iml"))
    filesrB("iml")
  }


object curryTest extends App{
  def curriedSum(x:Int)(y:Int)=x+y
  println(curriedSum(1)(2))
}

object controlStructureTest extends App{
  def twice(op:Double=>Double,x:Double)=op(op(x))
  println(twice(_+1,5))
}
