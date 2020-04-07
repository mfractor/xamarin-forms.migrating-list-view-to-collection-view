## Introduction

Now that we've migrated our user interfaces to `CollectionView`, let's have a look at user interaction.

## Cell Selection

How to process tap events on your cells

- single template
- with data template selector

### Inline Views

Adding a tap gesture recogniser to your data template.

## Pull To Refresh

`ListView` pull to refresh was supported through the bindable properties `IsPullToRefreshEnabled`, `RefreshCommand`, and `IsRefreshing`. It looked like this:

~~~xml
<ListView Grid.Row="2"
	..
	IsRefreshing="{Binding IsRefreshing}"
	IsPullToRefreshEnabled="true"
	RefreshCommand="{Binding RefreshCommand}">
~~~
 
By enabling pull to refresh, binding to the `ItemsViewModel.IsRefreshing` property and `ItemsViewModel.RefreshCommand`, the `ListView` will set `IsRefreshing = true` and execute the `RefreshCommand`. It's up to us to then display a refresh view. In our example we re-use the `EmptyView`.

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

## Cell Context Actions

Using SwipeView

## Summary
