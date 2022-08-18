using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_33
{
    public class Shop
    {

        public ObservableCollection<Item> Items = new ObservableCollection<Item>();

        public void Add(Item item)
        { 
            Items.Add(item);
            
        }
        public void Remove(Item item)
        {
            Items.Remove(item);          
        }
    }
}
