using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc.ThreadTest
{
    public delegate void RefAsyncCallback(ref string resultStr,IAsyncResult ar);
    public class RealAsyncResultDemo
    {
        public IAsyncResult BeginCalculate(int num1, int num2, RefAsyncCallback userCallback, object asyncState)
        {
            IAsyncResult result = new CalculateAsyncResult(num1, num2, userCallback, asyncState);
            return result;
        }

        public int EndCalculate(ref string resultStr, IAsyncResult ar)
        {
            CalculateAsyncResult result = ar as CalculateAsyncResult;
            if (Interlocked.CompareExchange(ref result.EndCallCount, 1, 0) == 1)
            {
                throw new Exception("End方法只能调用一次。");
            }
            result.AsyncWaitHandle.WaitOne();

            resultStr = result.ResultStr;

            return result.FinnalyResult;
        }

        public int Calculate(int num1, int num2, ref string resultStr)
        {
            resultStr = (num1 * num2).ToString();
            return num1 * num2;
        }

        public void Execute()
        {
            IAsyncResult calculateResult = BeginCalculate(123, 456, null, null);
            string resultStr = string.Empty;
            int result = EndCalculate(ref resultStr, calculateResult);
            Console.WriteLine(result);
        }
    }

    public class CalculateAsyncResult : IAsyncResult 
    {
        private int _calcNum1;
        private int _calcNum2;
        private RefAsyncCallback _userCallback;
        private ManualResetEvent _asyncWaitHandle;
        public WaitHandle AsyncWaitHandle
        {
            get
            {
                if (this._asyncWaitHandle == null)
                {
                    ManualResetEvent event2 = new ManualResetEvent(false);
                    Interlocked.CompareExchange<ManualResetEvent>(ref this._asyncWaitHandle, event2, null);
                     // 异步执行操作
                    ThreadPool.QueueUserWorkItem((obj)=>{ AsyncCalculate(obj); }, this);
                }
                return _asyncWaitHandle;
            }
        }


        public object AsyncState { get; private set; }

        public bool CompletedSynchronously { get; private set; }

        public bool IsCompleted { get; private set; }

        public int FinnalyResult { get; set; }

        public int EndCallCount = 0;
        public string ResultStr;

        public CalculateAsyncResult(int num1, int num2, RefAsyncCallback userCallback, object asyncState)
        {
            this._calcNum1 = num1;
            this._calcNum2 = num2;
            this._userCallback = userCallback;
            AsyncState = asyncState;
            //this.
        }

        private static void AsyncCalculate(object obj)
        {
            CalculateAsyncResult asyncResult = obj as CalculateAsyncResult;
            Thread.SpinWait(1000);
            asyncResult.FinnalyResult = asyncResult._calcNum1 * asyncResult._calcNum2;
            asyncResult.ResultStr = asyncResult.FinnalyResult.ToString();

            // 是否同步完成
            asyncResult.CompletedSynchronously = false;
            asyncResult.IsCompleted = true;
            ((ManualResetEvent)asyncResult.AsyncWaitHandle).Set();
            if (asyncResult._userCallback != null)
                asyncResult._userCallback(ref asyncResult.ResultStr, asyncResult);
        }
    }
}
