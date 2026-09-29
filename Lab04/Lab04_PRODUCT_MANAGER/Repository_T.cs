using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_PRODUCT_MANAGER
{
    public class Repository_T Where T : IEntity
    {
        private List<T> items = new List<T>();

    public void Add(T items)
    {
        items.Add(items);
    }

    public bool Remove(string id)
    {
        T items = FindById(id);
        if (items == null)
        {
            return false;
        }
        items.Remove(items);
        return true;
    }



}

}
