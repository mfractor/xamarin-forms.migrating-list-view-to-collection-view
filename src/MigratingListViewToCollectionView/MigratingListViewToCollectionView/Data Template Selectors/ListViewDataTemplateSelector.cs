using System;
using Xamarin.Forms;


namespace MigratingListViewToCollectionView.DataTemplateSelectors
{
    public class ListViewDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemTemplate
        {
            get;
            set;
        }

        public ListViewDataTemplateSelector()
        {
            ItemTemplate = new DataTemplate(() =>
           {
               return new ViewCell()
               {
                   View = new Controls.ItemView()
               };
           });
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ItemTemplate;
        }
    }
}
