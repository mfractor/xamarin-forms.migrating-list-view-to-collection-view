## Introduction

In this article we'll cover how to migrate your `ListView` cells so you can use them in a `CollectionView`.

## Cells

Setting your cell with a `ListView` uses a `DataTemplate` but requires your view to be contained within a `ViewCell` class. It looked a bit like this:

### Data Templates
~~~ xaml
<ListView.ItemTemplate>
    <DataTemplate>
        <ViewCell>
            <controls:ItemView/>
        </ViewCell>
    </DataTemplate>
</ListView.ItemTemplate>
~~~

`CollectionView` simplifies this. Since it doesn't use a `ViewCell` to display an item, we can assign any old `View` as the content of our `DataTemplate`. Here we're using our own `InteractiveItemView` that we'll see later:

~~~ xaml
<CollectionView.ItemTemplate>
    <DataTemplate>
        <controls:InteractiveItemView OnItemSelected="InteractiveItemView_OnItemSelected"/>
    </DataTemplate>
</CollectionView.ItemTemplate>
~~~

### Supporting Dynamic Cell Sizes

With `ListView` we needed to specify `HasUnevenRows="true"` and `RowHeight="-1"` to get dynamic cell sizes. Since `CollectionView` supports this by default, the sizes are determined by the content of our `DataTemplate` and that's it. This means that when you're displaying multiple cell types in your list, the heights are driven from the `View` from each `DataTemplate`.

## Data Template Selector

Migrating a data template selector to

**ListView - Data Template Selector**

**CollectionView - Data Template Selector**

## Empty View Support

To support this on `ListView` we would add an empty view to the layout containing our list, then bind `IsVisible` to view model properties that we have to manage ourselves. Here we use `HasFilteredItems` and `DoesNotHaveFilteredItems`.

~~~ xaml
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

(**Matthew: add view model implementation here? or is that too verbose?**)

`CollectionView` makes this dead simple. All we need to do is set the `EmptyView` property and it takes care of the rest!

~~~xaml
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


## Summary
