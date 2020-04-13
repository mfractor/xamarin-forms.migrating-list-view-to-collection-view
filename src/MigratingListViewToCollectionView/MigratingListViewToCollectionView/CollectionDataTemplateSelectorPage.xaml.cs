using System;
using MigratingListViewToCollectionView.Attributes;
using MigratingListViewToCollectionView.ViewModels;
using Xamarin.Forms;

namespace MigratingListViewToCollectionView
{
    [DesignTimeBindingContext(typeof(ItemsViewModel))]
    public partial class CollectionDataTemplateSelectorPage : ContentPage
    {
        public CollectionDataTemplateSelectorPage()
        {
            InitializeComponent();

            BindingContext = new ItemsViewModel();
        }

        void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
        }
    }
}
