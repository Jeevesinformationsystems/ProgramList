﻿using DevExpress.Xpf.Core;
using System.ComponentModel;

namespace DevExpressSoring
{
    public class MyCollection<T> : ObservableCollectionCore<T>, ITypedList
    {
        public PropertyDescriptorCollection PropertyInfo { get; set; }

        public MyCollection(PropertyDescriptorCollection propertyInfo)
        {
            PropertyInfo = propertyInfo;
        }
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return PropertyInfo;
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return null;
        }
    }
}
