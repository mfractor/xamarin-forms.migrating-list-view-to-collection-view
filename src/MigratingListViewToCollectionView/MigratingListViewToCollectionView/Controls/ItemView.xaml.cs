using System;
using System.Collections.Generic;
using MigratingListViewToCollectionView.Attributes;
using MigratingListViewToCollectionView.ViewModels;
using Xamarin.Forms;

namespace MigratingListViewToCollectionView.Controls
{
    [DesignTimeBindingContext(typeof(ItemViewModel))]
    public partial class ItemView : StackLayout
    {
        public ItemView()
        {
            InitializeComponent();
        }
    }
}
