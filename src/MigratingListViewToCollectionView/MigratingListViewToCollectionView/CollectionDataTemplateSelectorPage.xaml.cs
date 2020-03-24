using System;
using MigratingListViewToCollectionView.Attributes;
using MigratingListViewToCollectionView.ViewModels;
using Xamarin.Forms;

namespace MigratingListViewToCollectionView
{
    [DesignTimeBindingContext(typeof(ItemsViewModel))]
    public partial class CollectionDataTemplateSelectorPage : ContentPage
    {
        void InteractiveItemView_OnItemSelected(System.Object sender, MigratingListViewToCollectionView.Controls.ItemSelectionEventArgs e)
        {
            Acr.UserDialogs.UserDialogs.Instance.Alert("You selected " + e.SelectedItem.Text);
        }

        public CollectionDataTemplateSelectorPage()
        {
            InitializeComponent();

            BindingContext = new ItemsViewModel();
        }
    }
}
