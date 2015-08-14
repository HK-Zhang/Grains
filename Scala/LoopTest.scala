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

object ImplictParameterDemo {

  class RichString(val s:String){
    def read = (s + "_r").mkString
  }

  object Context{
    implicit val ccc:String = "implicit"
    implicit def fun(s:String) = new RichString(s)
  }


  object Param{
    def print(content:String)(implicit prefix:String){
      println(prefix+":"+content)
    }
  }

  def main(args: Array[String]) {
    Param.print("jack")("hello")

    import Context._
    import Context.fun
    Param.print("jack")
    print(new String("").read)
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
