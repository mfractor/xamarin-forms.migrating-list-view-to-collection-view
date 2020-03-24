using System;

using System.Collections.Generic;
using System.Linq;
using MigratingListViewToCollectionView.Fonts;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MigratingListViewToCollectionView.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ItemsViewModel 
    {
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        Items = null;

                        await Task.Delay(5000);

                        UpdateItems();

                        Acr.UserDialogs.UserDialogs.Instance.Toast("Items refreshed");
                    }
                    finally
                    {
                        IsRefreshing = false;
                    }
                });
            }
        }

        public bool IsRefreshing
        {
            get;
            set;
        }

        [AlsoNotifyFor(nameof(FilteredItems), nameof(HasFilteredItems), nameof(DoesNotHaveFilteredItems))]
        public string SearchText
        {
            get;
            set;
        }

        public bool HasFilteredItems
        {
            get => FilteredItems.Any();
        }

        public bool DoesNotHaveFilteredItems
        {
            get => !HasFilteredItems;
        }

        [AlsoNotifyFor(nameof(FilteredItems), nameof(HasFilteredItems), nameof(DoesNotHaveFilteredItems))]
        public List<ItemViewModel> Items
        {
            get;
            private set;
        }

        public List<ItemViewModel> FilteredItems
        {
            get
            {
                if (Items == null)
                {
                    return new List<ItemViewModel>();
                }

                if (string.IsNullOrEmpty(SearchText))
                {
                    return Items;
                }

                return Items.Where(i => i.Text.Contains(SearchText)).ToList();
            }
        }

        public ItemsViewModel()
        {
            UpdateItems();
        }

        private void UpdateItems()
        {
            Items = new List<ItemViewModel>()
            {
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.AlarmClock,
                    Text = "Alarm Clock",
                },
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.Thermometer,
                    Text = "Thermometer",
                },
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.Washer,
                    Text = "Washer",
                },
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.Gramophone,
                    Text = "Gramophone",
                },
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.FireExtinguisher,
                    Text = "Fire Extinguisher",
                },
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.Hammer,
                    Text = "Hammer",
                },
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.Bath,
                    Text = "Bath",
                },
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.AppleCrate,
                    Text = "Apple Crate",
                },
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.Starship,
                    Text = "Starship",
                },
                new ItemViewModel()
                {
                    Icon = FontAwesomeIcons.Pumpkin,
                    Text = "Pumpkin",
                }
            };
        }
    }
}
