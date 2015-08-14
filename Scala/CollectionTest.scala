object ListFuns {
  def main (args: Array[String]) {
    val data0 = List(1,2,3,4)
    println(data0.map(item => item + 1)) //List(2, 3, 4, 5)
    //下面这种方式更简洁
    println(data0.map(_ + 1))            //List(2, 3, 4, 5)

    val data = List("Scala","Hadoop","Spark")
    //计算出data中每个单词的长度
    println(data.map(_.length)) //List(5, 6, 5)
    println(data.map(_.toList.reverse.mkString)) //List(alacS, poodaH, krapS)
    println(data.map(_.toList)) //List(List(S, c, a, l, a), List(H, a, d, o, o, p), List(S, p, a, r, k))
    println(data.map(_.toArray)) //List([C@3d2f40eb, [C@694f23ae, [C@4aafaa85)
    println(data.flatMap(_.toList)) //List(S, c, a, l, a, H, a, d, o, o, p, S, p, a, r, k)
    //println(data.flatMap(_.toArray)) //报错
    println(data.flatMap(_.toArray.toList)) //List(S, c, a, l, a, H, a, d, o, o, p, S, p, a, r, k)
    println(List.range(1,10)) //List(1, 2, 3, 4, 5, 6, 7, 8, 9)
    println(List.range(1,10).flatMap(i => List.range(1,i).map(j => (i,j))))

    var sum = 0
    List(1, 2, 3, 4).foreach(sum += _)
    println("sum:" + sum) //sum:10

    println(List(1, 2, 3, 4, 5, 6, 7, 8, 9).filter(_ % 2 == 0)) //List(2, 4, 6, 8)
    //对List进行分区
    println(List(1, 2, 3, 4, 5).partition( _ % 2 == 0)) //(List(2, 4),List(1, 3, 5))
    //找出第一个偶数
    println(List(1, 2, 3, 4, 5).find(_ % 2 == 0)) //Some(2)
    //找出第一个大于3的元素
    println(List(1, 2, 3, 4, 5).find(_ > 3)) //Some(4)
    //注意：Some和None都是Option的子类
    println(List(1, 2, 3, 4, 5).find(_ < 0)) //None
    //获取所有符合条件的数
    println(List(1, 2, 3, 4, 5).takeWhile(_ < 4)) //List(1, 2, 3)
    //移除所有符合条件的数
    println(List(1, 2, 3, 4, 5).dropWhile(_ < 4)) //List(4, 5)
    //将元素按条件分成两部分
    println(List(1, 2, 3, 4, 5).span(_ < 4)) //(List(1, 2, 3),List(4, 5))
    //这里有两个重要的方法：exists 和 forall
    def hasTotallyZeroRow(m: List[List[Int]]) = m.exists(row => row.forall(_ == 0))
    val m = List(List(1,0,0),List(0,1,0),List(0,0,0))
    println(hasTotallyZeroRow(m)) //true
    println(List(1, 2, 3, 4, 5).forall( _ > 0)) //true
    println(List(0, 1, 2, 3, 4, 5).forall( _ > 0)) //false
    println(List(1, 2, 3, 4, 5).exists( _ > 5 )) //false
    println(List(1, 2, 3, 4, 5, 6).exists( _ > 5 )) //true

    //初始化数据是foldLeft的第一个参数0，然后对这个初始化数据从1到100累加：即 0 + 1 + 2 ... + 100
    println((1 to 100).foldLeft(0)(_ + _)) //5050
    //上面的语句还可以写成下面的方式：
    println((0/:(1 to 100))(_ + _)) //5050
    //初始化数据是foldLeft的第一个参数1，然后对这个初始化数据从1到100累加：即 1 + 1 + 2 ... + 100
    println((1 to 100).foldLeft(1)(_ + _)) //5051
    println((1/:(1 to 100))(_ + _))
    //初始化数据是foldLeft的第一个参数0，然后对这个初始化数据从1到100相减：即 0 - 1 - 2 ... - 100
    println((1 to 100).foldLeft(0)(_ - _)) //-5050
    println((0/:(1 to 100))(_ - _))
    //初始化数据是foldLeft的第一个参数1，然后对这个初始化数据从1到100相减：即 1 - 1 - 2 ... - 100
    println((1 to 100).foldLeft(1)(_ - _)) //-5049
    println((1/:(1 to 100))(_ - _))

    //另有foldRight方法，下面的例子相当于(3-(2-(1-10))) = -8
    println((1 to 3).foldRight(10)(_ - _)) //-8

    //对List从小到大排序
    println(List(1, -3, 4, 2, 6).sortWith(_ < _)) //List(-3, 1, 2, 4, 6)
    //对List从大到小排序
    println(List(1, -3, 4, 2, 6).sortWith(_ > _)) //List(6, 4, 2, 1, -3)

    println(List.apply(1, 2, 3)) //List(1, 2, 3)
    
    //println(List.make(3, 5)) //List(5, 5, 5)
    println(List.range(1, 5)) //List(1, 2, 3, 4)
    //打印出从9到1的数，每次-3
    println(List.range(9, 1, -3)) //List(9, 6, 3)
    val zipped = "abcde".toList.zip(List(1, 2, 3, 4, 5, 6))
    println(zipped) //List((a,1), (b,2), (c,3), (d,4), (e,5))
    println(zipped.unzip) //(List(a, b, c, d, e),List(1, 2, 3, 4, 5))
    println(List(List('a','b'),List('c'),List('d','e')).flatten) //List(a, b, c, d, e)
    println(List.concat(List(),List('b'),List('c'))) //List(b,c)
  }
}



object BufferOps {
  def main(args: Array[String]) {
    val listBuffer = new scala.collection.mutable.ListBuffer[Int]
    listBuffer += 1
    listBuffer += 2
    println(listBuffer) //ListBuffer(1, 2)

    val arrayBuffer = new scala.collection.mutable.ArrayBuffer[Int]()
    arrayBuffer += 1
    arrayBuffer += 2
    println(arrayBuffer) //ArrayBuffer(1, 2)


    val empty = scala.collection.immutable.Queue[Int]()
    val queue1 = empty.enqueue(1)
    println(queue1) //Queue(1)
    val queue2 = queue1.enqueue(List(2, 3, 4, 5, 6))
    println(queue2) //Queue(1, 2, 3, 4, 5, 6)

    val queue = scala.collection.mutable.Queue[String]()
    queue += "a"
    queue ++= List("b", "c")
    println(queue) //Queue(a, b, c)
    println(queue.dequeue()) //a
    println(queue) //Queue(b, c)
    println(queue.dequeue()) //b
    println(queue) //Queue(c)

    val stack = new scala.collection.mutable.Stack[Int]
    stack.push(1)
    stack.push(2)
    stack.push(3)
    println(stack) //Stack(3, 2, 1)
    println(stack.top) //3
    println(stack) //Stack(3, 2, 1)
    println(stack.pop) //3
    println(stack) //Stack(2, 1)

    val data = scala.collection.mutable.Set.empty[Int]
    data ++= List(1,2,3,4)
    println(data) //Set(1, 2, 3, 4)
    data += 5
    println(data) //Set(1, 5, 2, 3, 4)
    data --= List(1,2)
    println(data) //Set(5, 3, 4)
    //data中已经有元素5了，所以不会再将5添加进去
    data += 5
    println(data) //Set(5, 3, 4)
    //清除所有的元素
    data.clear()
    println(data) //Set()

    //使用empty来定义一个空的map
    val map = scala.collection.mutable.Map.empty[String, String]
    map("Java") = "Hadoop"
    map("Scala") = "Spark"
    println(map) //Map(Scala -> Spark, Java -> Hadoop)
    println(map("Scala")) //Spark
    //println(map("C++")) //Exception in thread "main" java.util.NoSuchElementException: key not found:
    //有顺序的集合
    val treeSet = scala.collection.immutable.TreeSet(9, 3, 1, 8, 0, 2, 7, 4, 6, 5)
    println(treeSet) //TreeSet(0, 1, 2, 3, 4, 5, 6, 7, 8, 9)
    //按字典顺序排序
    val treeMap = scala.collection.immutable.TreeMap("Scala" -> "Spark", "Java" -> "Hadoop")
    println(treeMap) //Map(Java -> Hadoop, Scala -> Spark)
  }
}

object mapPrinter extends App{

  implicit class PrettyPrintMap[K, V](val map: Map[K, V]) {
    def prettyPrint: PrettyPrintMap[K, V] = this

    override def toString: String = {
      val valuesString = toStringLines.mkString("\n")

      "Map (\n" + valuesString + "\n)"
    }

    def toStringLines = {
      map
        .flatMap{ case (k, v) => keyValueToString(k, v)}
        .map(indentLine(_))
    }

    def keyValueToString(key: K, value: V): Iterable[String] = {
      value match {
        case v: Map[_, _] => Iterable(key + " -> Map (") ++ v.prettyPrint.toStringLines ++ Iterable(")")
        case x => Iterable(key + " -> " + x.toString)
      }
    }

    def indentLine(line: String): String = {
      "\t" + line
    }
  }

  type MapType = Map[String, Map[String, Map[String, (String, String)]]]

  val m: MapType = Map("Alphabet" -> Map( "Big Boss" -> Map("Clandestine Mssion" -> ("Dracula Returns", "Enemy at the Gates"))))

  println(m.prettyPrint)
}
