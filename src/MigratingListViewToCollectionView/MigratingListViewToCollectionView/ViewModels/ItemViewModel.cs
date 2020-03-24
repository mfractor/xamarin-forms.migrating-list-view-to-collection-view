
using System.Windows.Input;
using Xamarin.Forms;
using System;
using PropertyChanged;

namespace MigratingListViewToCollectionView.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ItemViewModel
    {
        public ICommand ItemFavourited
        {
            get
            {
                return new Command(() =>
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast(Text + " favourited");
                });
            }
        }

        public string Text
        {
            get;
            set;
        }

        public string Icon
        {
            get;
            set;
        }
    }
}
