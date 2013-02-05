using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq.Expressions;

namespace dynamic_examples.DynamicObjectSamples
{
    public class ListBag : DynamicObject, IEnumerable
    {
        
        IDictionary<string,object> _dict = new Dictionary<string,object>();
        IList<object> _list = new List<object>();
        public ListBag(){}
        private ListBag(IDictionary<string, object> dict, IList<object> value_list)
        {
            
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            
            AddMember(binder.Name, value);
            return true;
        }

        void AddMember(string name, object value)
        {
            _dict[name] = value;
            _list.Add(value);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            
            return _dict.TryGetValue(binder.Name, out result);
            
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            var i = (int) indexes[0];
            result = _list[i];
            return true;
        }
        public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object result) {
            if(binder.Operation == ExpressionType.LeftShiftAssign)
            {
                var copy = new ListBag(_dict, _list);
                copy.AddMembersFromObject(arg);
                result = copy;
                return true;
            }
            result = null;
            return false;
        }

        void AddMembersFromObject(object o)
        {
            var properties = TypeDescriptor.GetProperties(o);
            foreach (PropertyDescriptor prop in properties)
            {
                AddMember(prop.Name,prop.GetValue(o));
            }

        }

        public IEnumerator GetEnumerator()
        {
            return _dict.GetEnumerator();
        }
    }
}