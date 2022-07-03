using App.Core;
using App.MVVM.ViewItem;
using System;
using System.Collections.Generic;

namespace App.Registries
{
    public static class ViewItemFactory
    {
        public static Dictionary<Guid,ViewItem> ViewItems { get; set; }

        static ViewItemFactory()
        {
            ViewItems = new Dictionary<Guid,ViewItem>();

            ViewItems.Add(BankBalanceViewItem.Id, new BankBalanceViewItem());
        }

        public static void StartUpMVVM()
        {
            foreach (var viewItem in ViewItems)
            {
                viewItem.Value.OnStartup();
            }
        }

    }
}
