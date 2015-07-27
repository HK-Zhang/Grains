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
  def add(that:Rational):Rational=new Rational(number*that.denom+denom*that.number,denom*that.denom)
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
    val r=new Rational(3,6)
    val t=new Rational(1,2)
    println(r.add(t).toString)
    println(r.max(t))
  }
}
