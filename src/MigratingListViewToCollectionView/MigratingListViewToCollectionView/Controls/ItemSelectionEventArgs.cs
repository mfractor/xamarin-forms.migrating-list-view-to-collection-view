using System;
using MigratingListViewToCollectionView.ViewModels;

namespace MigratingListViewToCollectionView.Controls
{
    public class ItemSelectionEventArgs : EventArgs
    {
        public ItemSelectionEventArgs(ItemViewModel selectedItem)
        {
            SelectedItem = selectedItem;
        }

        public ItemViewModel SelectedItem { get; }
    }
}