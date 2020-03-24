using System;
using System.Collections.Generic;
using MigratingListViewToCollectionView.Attributes;
using MigratingListViewToCollectionView.ViewModels;
using Xamarin.Forms;

namespace MigratingListViewToCollectionView
{
    [DesignTimeBindingContext(typeof(ItemsViewModel))]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();

            BindingContext = new ItemsViewModel();
        }

        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e.Item is ItemViewModel itemViewModel)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert("You selected " + itemViewModel.Text);
            }
        }
    }
}
