using System;
using MigratingListViewToCollectionView.Attributes;
using MigratingListViewToCollectionView.ViewModels;
using Xamarin.Forms;

namespace MigratingListViewToCollectionView
{
    [DesignTimeBindingContext(typeof(ItemsViewModel))]
    public partial class CollectionPage : ContentPage
    {
        public void OnItemTapped(object sender, EventArgs e)
        {
            if (sender is ItemView view
                && view.BindingContext is ItemViewModel itemViewModel)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert("You selected " + itemViewModel.Text);
            }
        }

        public CollectionPage()
        {
            InitializeComponent();

            BindingContext = new ItemsViewModel();
        }
    }
}
