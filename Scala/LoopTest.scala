object LoopTest extends App {
  def forLoop(n: Int) {
    var total = 0
    for (i <- 0 until n) {
      total += i
    }
  }

  def whileLoop(n: Int) {
    var total = 0
    var i = 0
    while (i < n) {
      i = i + 1;
      total += i
    }
  }

  def testMethod(n: Int)(m: Int)(body: (Int) => Unit) {
    var avgMilliSec = 0.0
    for (i <- 1 to n) {
      val start = System.currentTimeMillis()
      body(m)
      val end = System.currentTimeMillis()
      val time = end - start
      avgMilliSec = 1.0 * ((i - 1) * avgMilliSec + time) / i
    }
    println("avg time: " + avgMilliSec)
  }

  override def main(args: Array[String]): Unit = {
    testMethod(100)(10000)(forLoop)
    testMethod(100)(1000000)(forLoop)
    testMethod(100)(100000000)(forLoop)
    println()
    testMethod(100)(10000)(whileLoop)
    testMethod(100)(1000000)(whileLoop)
    testMethod(100)(100000000)(whileLoop)
  }
}

object ImplicitTest {

  def display(input:String):Unit = println(input)
  def display2(input:String):Unit = println(input+",2")

  implicit def typeConvertor(input:Int):String = input.toString

  implicit def typeConvertor(input:Boolean):String = if(input) "true" else "false"

  //  implicit def booleanTypeConvertor(input:Boolean):String = if(input) "true" else "false"
  def booleanTypeConvertor(input:Boolean):String = if(input) "true" else "false"

  def main(args: Array[String]): Unit = {
    display("1212")
    display(12)
    display(true)
    display2(12)
    display2(true)
  }

}

object ImplictDemo {

  class RichString(val s:String){
    def read = (s + "_fun").mkString
  }

  object Context{
    implicit val impStr:String = "It is implicit"
    implicit def fun(s:String) = new RichString(s)
    implicit class myString(val s:String){
      def read2 = (s + "_class").mkString
    }
  }


  object Param{
    def print(content:String)(implicit prefix:String){
      println(prefix+":"+content)
    }
  }

  def main(args: Array[String]) {
    Param.print("A")("It is not implicit")

    import Context._
    import Context.fun
    Param.print("B")
    println(new String("").read)
    println(new String("").read2)
  }

}

import java.io.File

import scala.io.Source

class RichFile(val file:File){
  def read = Source.fromFile(file.getPath()).mkString
}

object Context{
  implicit def file2RichFile(f:File)= new RichFile(f)
}

object ImplictExtensionDemo {

  def main(args: Array[String]) {
    import Context.file2RichFile
    println(new File("DemoScala.iml").read)
  }

}


object NeighborMerge extends App{
  var a=ArrayBuffer(1,2,4,3)
  println(a.size)
  var b = a.sliding(2,1).map(_.sum)
  b.foreach(println)
  var c = a.head +: a.drop(1).dropRight(1).sliding(2,1).map(_.sum).toArray :+ a.last
  c.foreach(println)
  var middle: Iterator[Int] = a.drop(1).dropRight(1).sliding(2,1).map(_.sum)
  var d = (Iterator(a.head)++middle++Iterator(a.last)).toArray
  d.foreach(println)

}

object CaseClassTesting extends App {

  abstract class Term

  case class Var(name: String) extends Term

  case class Fun(arg: String, body: Term) extends Term

  case class App(f: Term, v: Term) extends Term

  val x1 = Var("x")
  val x2 = Var("x")
  val y1 = Var("y")
  println("" + x1 + " == " + x2 + " => " + (x1 == x2))
  println("" + x1 + " == " + y1 + " => " + (x1 == y1))

  val x = Var("x")
  Console.println(x.name)

  def printTerm(term: Term) {
    term match {
      case Var(n) =>
        print(n)
      case Fun(x, b) =>
        print("^" + x + ".")
        printTerm(b)
      case App(f, v) =>
        Console.print("(")
        printTerm(f)
        print(" ")
        printTerm(v)
        print(")")
    }
  }
  def isIdentityFun(term: Term): Boolean = term match {
    case Fun(x, Var(y)) if x == y => true
    case _ => false
  }
  val id = Fun("x", Var("x"))
  val t = Fun("x", Fun("y", App(Var("x"), Var("y"))))
  printTerm(t)
  println
  println(isIdentityFun(id))
  println(isIdentityFun(t))

}
