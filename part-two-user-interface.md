## Introduction

In this article we'll cover how to migrate your `ListView` cells so you can use them in a `CollectionView`.

## Cells

Setting your cell with a `ListView` uses a `DataTemplate` but requires your view to be contained within a `ViewCell` class. It looked a bit like this:

### Data Templates
~~~ xml
<ListView.ItemTemplate>
    <DataTemplate>
        <ViewCell>
            <controls:ItemView/>
        </ViewCell>
    </DataTemplate>
</ListView.ItemTemplate>
~~~

`CollectionView` simplifies this. We no longer have to wrap our content in a `ViewCell` and instead can set our content directly. Here we're using our own `InteractiveItemView` that we'll see later:

~~~ xml
<CollectionView.ItemTemplate>
    <DataTemplate>
        <controls:InteractiveItemView OnItemSelected="InteractiveItemView_OnItemSelected"/>
    </DataTemplate>
</CollectionView.ItemTemplate>
~~~

See full documentation [here](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview/populate-data#define-item-appearance).

### Supporting Dynamic Cell Sizes

With `ListView` we needed to specify `HasUnevenRows="true"` and `RowHeight="-1"` to get dynamic cell sizes. Since `CollectionView` supports this by default, the sizes are determined by the content of our `DataTemplate` and that's it. This means that when you're displaying multiple cell types in your list, the heights are driven from the `View` from each `DataTemplate`.

## Data Template Selector

`DataTemplateSelector` functions the same as before but make sure the content of your `DataTemplate` is no longer wrapped in a `ViewCell`.

## Empty View Support

To support this on `ListView` we would add an empty view to the layout containing our list, then bind `IsVisible` to view model properties that we have to manage ourselves. Here we use `HasFilteredItems` and `DoesNotHaveFilteredItems`.

~~~ xml
<ListView Grid.Row="2"
    ...
    IsVisible="{Binding HasFilteredItems}"
    ItemsSource="{Binding FilteredItems}"
    VerticalOptions="FillAndExpand">
...
...
</ListView>

<ContentView Grid.Row="2" 
	VerticalOptions="FillAndExpand" 
	IsVisible="{Binding DoesNotHaveFilteredItems}">
	<controls:EmptyView/>
</ContentView>
~~~

`CollectionView` makes this dead simple. All we need to do is set the `EmptyView` property and it takes care of the rest!

~~~xml
<CollectionView ItemsSource="{Binding FilteredItems}" VerticalOptions="FillAndExpand">
	...
	...
    <CollectionView.EmptyView>
        <ContentView>
            <controls:EmptyView/>
        </ContentView>
    </CollectionView.EmptyView>
</CollectionView>
~~~

See full documentation [here](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview/emptyview).


## Summary
Migrating your user interface from `ListVew` to `CollectionView` is worth the minimal effort. We can easily support single or multiple cell `DataTemplate`s with dynamic sizes, as well as empty views that automatically display by reading our `ItemsSource` data. 