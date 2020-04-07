## Introduction

Now that we've migrated our user interfaces to `CollectionView`, let's have a look at user interaction by adding cell selection, tap navigation, swipe context actions, and pull to refresh.

## Cell Selection

How to process tap events on your cells

- single template
- with data template selector

### Inline Views

Adding a tap gesture recogniser to your data template.

## Pull To Refresh

### ListView
`ListView` pull to refresh is supported through the bindable properties `IsPullToRefreshEnabled`, `RefreshCommand`, and `IsRefreshing`. It looked like this:

~~~xml
<ListView Grid.Row="2"
	..
	IsRefreshing="{Binding IsRefreshing}"
	IsPullToRefreshEnabled="true"
	RefreshCommand="{Binding RefreshCommand}">
~~~
 
By enabling pull to refresh, binding to our `ItemsViewModel.IsRefreshing` property and `ItemsViewModel.RefreshCommand`, the `ListView` will set `IsRefreshing = true` and execute the `RefreshCommand`. It's up to us to display a refresh view driven from our view model properties. In our example we re-use the `EmptyView`.

~~~xml
<?xml version="1.0" encoding="utf-8"?>
<StackLayout Orientation="Vertical"
	 VerticalOptions="Center"
	 HorizontalOptions="Center"
	 xmlns="http://xamarin.com/schemas/2014/forms"
	 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
	 x:Class="MigratingListViewToCollectionView.Controls.EmptyView"
	 xmlns:local="clr-namespace:MigratingListViewToCollectionView">
	 
	<ActivityIndicator IsRunning="true"
   		IsVisible="{Binding IsRefreshing}"/>
   		
	<Label Text="Your search returned no results"
		VerticalTextAlignment="Center"
		HorizontalTextAlignment="Center">
		<Label.Triggers>
			<DataTrigger TargetType="Label"
		       Binding="{Binding IsRefreshing}"
		       Value="true">
				<Setter Property="Text"
				    Value="Refreshing..."/>
			</DataTrigger>
		</Label.Triggers>
	</Label>
	
</StackLayout>
~~~

Here we show the running `ActivityIndicator` during refresh, and use a `Label.Trigger` to display a refresh message to the user. 

### CollectionView

To support pull to refresh on `CollectionView` we wrap it in a `RefreshView`. The `RefreshView` is more flexible in that it works on any control as long as it's scrollable, meaning you could just as easily use it with a `ScrollView` that is displaying a page of data instead of a collection. 

~~~xml
<RefreshView IsRefreshing="{Binding IsRefreshing}" Command="{Binding RefreshCommand}" Grid.Row="2">
    <CollectionView ItemsSource="{Binding FilteredItems}" VerticalOptions="FillAndExpand">
        ...
        <CollectionView.EmptyView>
            <ContentView>
                <controls:EmptyView/>
            </ContentView>
        </CollectionView.EmptyView>
    </CollectionView>
</RefreshView>
~~~

The control will set `IsRefreshing = true` and execute the `RefreshCommand` when the user pulls to refresh. Like before, we re-use the `EmptyView` to display a loading indicator and message. This time, however, it's contained in our `CollectionView.EmptyView` property which is automatically shown during refresh. We can see in our `ItemsViewModel.RefreshCommand` that we set our `Items = null` which causes the `EmptyView` to be displayed.

~~~csharp
public ICommand RefreshCommand
{
    get
    {
        return new Command(async () =>
        {
            try
            {
                Items = null;

                await Task.Delay(5000); // Only to demonstrate refresh views..

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
~~~
  

## Cell Context Actions

Swipe context actions on `ListView` cells were supports through an `IList` of `ViewCell.ContextActions` like so:

~~~xml
<ListView.ItemTemplate>
    <DataTemplate>
        <ViewCell>
            <ViewCell.ContextActions>
                <MenuItem Text="⭐️" Command="{Binding ItemFavourited}"/>
            </ViewCell.ContextActions>
            <controls:ItemView/>
        </ViewCell>
    </DataTemplate>
</ListView.ItemTemplate>
~~~

Here we have one `MenuItem` displaying "⭐️" and executing our `ItemViewModel.ItemFavourited` command when tapped. To migrate this to `CollectionView` we have to embed our `ItemView` in a `SwipeView` container:

~~~xml
<?xml version="1.0" encoding="utf-8"?>
<SwipeView xmlns="http://xamarin.com/schemas/2014/forms"
           xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
           x:Class="MigratingListViewToCollectionView.Controls.InteractiveItemView"
           x:Name="self"
           xmlns:controls="clr-namespace:MigratingListViewToCollectionView.Controls">
    <SwipeView.RightItems>
        <SwipeItems Mode="Reveal">
            <SwipeItemView Command="{Binding ItemFavourited}">
                <Label Padding="0,0,0,20"
                   Text="⭐️"
                   VerticalTextAlignment="Center"
                   HorizontalTextAlignment="End"
                   FontSize="48"
                   WidthRequest="300"/>
            </SwipeItemView>
        </SwipeItems>
    </SwipeView.RightItems>
    <controls:ItemView>
        <controls:ItemView.GestureRecognizers>
            <TapGestureRecognizer Tapped="TapGestureRecognizer_Tapped"/>
        </controls:ItemView.GestureRecognizers>
    </controls:ItemView>
</SwipeView>
~~~

The `SwipeView` is highly customizable. Here we implement our `ListView` feature by setting some right swipe items. When our `Mode="Reveal"` the items are revealed on swipe. The user has to then tap on the item to execute the bound `ItemViewModel.ItemFavourited` command. If `Mode="Execute"` the command is executed on swipe. Then by default the drawer closes after execution, but it can be customized to stay open. We can also supply our own layout to `SwipeItemView` as we do here, which is very nice.

The combination of items, directions, execution modes, and swipe behaviors make this a powerful control. See the full documentation [here](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/swipeview)

## Summary
`CollectionView` interactivity is more flexible than `ListView`. Using the new APIs makes it easy to add context actions, pull to refresh, single or multi-select, and navigation.