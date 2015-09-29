/**
 * Created by Administrator on 2015/9/29.
 */
package me.rerun.akkanotes.messaging.protocols

object TeacherProtocol{

  case class QuoteRequest()
  case class QuoteResponse(quoteString:String)

}