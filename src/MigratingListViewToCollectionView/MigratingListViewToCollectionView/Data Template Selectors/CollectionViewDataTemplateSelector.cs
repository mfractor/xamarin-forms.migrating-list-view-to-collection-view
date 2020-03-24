using System;
using Xamarin.Forms;


namespace MigratingListViewToCollectionView.DataTemplateSelectors
{
    public class CollectionViewDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate 
        { 
            get; 
            set; 
        }

        public CollectionViewDataTemplateSelector()
        {
            CollectionItemTemplate = CreateDataTemplate(new ContentView()
                              {
                                  Content = new Label() 
                                  { 
                                      Text = "Ooops! No template found!"
                                  },
                              });



            // TODO: Declare your data templates here.
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // TODO: Inspect the "item" and return the relevant data template.

            return DefaultTemplate;
        }
    }
}
