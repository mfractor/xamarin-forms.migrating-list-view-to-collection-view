## Introduction

Now that we've migrated our user interfaces to `CollectionView`, let's have a look at user interaction.

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

Using SwipeView

## Summary
