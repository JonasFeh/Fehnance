using App.Core;
using App.MVVM.ViewItem;
using System;
using System.Collections.Generic;

namespace App.Registries
{
    public class ViewItemFactory
    {
        private Dictionary<Guid,ViewItem> ViewItems { get; set; }

        public ViewItemFactory()
        {
            ViewItems = new Dictionary<Guid,ViewItem>();

            ViewItems.Add(BankBalanceViewItem.Id, new BankBalanceViewItem());
        }

        public void StartUpMVVM()
        {
            foreach (var viewItem in ViewItems)
            {
                viewItem.Value.OnStartup();
            }
        }

    }
}
