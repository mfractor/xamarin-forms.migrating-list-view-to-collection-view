using System;
using MigratingListViewToCollectionView.Attributes;
using MigratingListViewToCollectionView.ViewModels;
using Xamarin.Forms;

namespace MigratingListViewToCollectionView
{
    [DesignTimeBindingContext(typeof(ItemsViewModel))]
    public partial class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            InitializeComponent();

            BindingContext = new ItemsViewModel();
        }
    }
}
