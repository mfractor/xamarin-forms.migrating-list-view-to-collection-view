using System;
using MigratingListViewToCollectionView.Attributes;
using MigratingListViewToCollectionView.ViewModels;
using Xamarin.Forms;


namespace MigratingListViewToCollectionView.Controls
{
    [DesignTimeBindingContext(typeof(ItemViewModel))]
    public partial class InteractiveItemView : SwipeView
    {
        public InteractiveItemView()
        {
            InitializeComponent();
        }
    }
}
