using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_33
{
    public class Customer
    {
        private Shop _shop;
        public void Subscribe(Shop shop)
        {
            _shop = shop;
            _shop.Items.CollectionChanged += OnItemChanged;
        
        }

        private void OnItemChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {

                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is Item newItem)
                        Console.WriteLine($"В магазин был добавлен новый товар, Id: {newItem.Id} Наименование: {newItem.Name}");
                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Item oldItem)
                        Console.WriteLine($"Из магазина был удален товар, Id: {oldItem.Id} Наименование: {oldItem.Name} ");
                    break;

            }
        }
    }
}
