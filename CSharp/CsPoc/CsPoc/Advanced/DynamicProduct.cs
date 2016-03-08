using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class DynamicProduct:DynamicObject
    {
        public string name;
        public int ID { get; set; }

        public void ShowProduct()
        {
            System.Console.WriteLine("Name={0},ID={1}", name, ID);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return base.GetDynamicMemberNames();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Console.WriteLine("TryGetMember is called,Name:{0}", binder.Name);
            bool tryResult = base.TryGetMember(binder, out result);

            return true;

        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Console.WriteLine("TrySetMember is called,Name:{0}", binder.Name);
            bool tryResult = base.TrySetMember(binder, value);

            return true;

        }

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            Console.WriteLine("TryInvoke is called");
            bool tryResult = base.TryInvoke(binder, args, out result);

            return true;

        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine("TryInvokeMember is called,Name:{0}", binder.Name);
            bool tryResult = base.TryInvokeMember(binder, args, out result);

            return true;
        }
    }
}
