using System;
using MigratingListViewToCollectionView.Attributes;
using MigratingListViewToCollectionView.ViewModels;
using Xamarin.Forms;

namespace MigratingListViewToCollectionView.Controls
{
    [DesignTimeBindingContext(typeof(ItemViewModel))]
    public partial class InteractiveItemView : SwipeView
    {
        public void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            OnItemSelected?.Invoke(this, new ItemSelectionEventArgs(BindingContext as ItemViewModel));
        }

        public event EventHandler<ItemSelectionEventArgs> OnItemSelected;

        public InteractiveItemView()
        {
            InitializeComponent();
        }
    }
}
