using System;
using MigratingListViewToCollectionView.Controls;
using Xamarin.Forms;

namespace MigratingListViewToCollectionView.DataTemplateSelectors
{
    public class CollectionViewDataTemplateSelector : DataTemplateSelector
    {
        DataTemplate ItemTemplate { get; set; }

        public CollectionViewDataTemplateSelector()
        {
            ItemTemplate = new DataTemplate(() => new InteractiveItemView());
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ItemTemplate;
        }
    }
}
