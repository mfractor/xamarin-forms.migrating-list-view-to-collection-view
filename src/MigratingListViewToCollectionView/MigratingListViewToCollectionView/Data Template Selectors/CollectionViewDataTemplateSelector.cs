using System;
using Xamarin.Forms;
using MigratingListViewToCollectionView.Controls;

namespace MigratingListViewToCollectionView.DataTemplateSelectors
{
    public class CollectionViewDataTemplateSelector : DataTemplateSelector
    {
        public event EventHandler<ItemSelectionEventArgs> OnItemSelected;

        DataTemplate ItemTemplate { get; set; }

        public CollectionViewDataTemplateSelector()
        {
            ItemTemplate = new DataTemplate(() =>
           {
               var item = new Controls.InteractiveItemView();
               item.OnItemSelected += Item_OnItemSelected;

               return item;
           });
        }

        private void Item_OnItemSelected(object sender, ItemSelectionEventArgs e)
        {
            OnItemSelected?.Invoke(this, e);
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // TODO: Inspect the "item" and return the relevant data template.

            return ItemTemplate;
        }
    }
}
