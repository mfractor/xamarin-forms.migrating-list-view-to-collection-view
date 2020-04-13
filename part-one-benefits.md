## Introduction

Lists are a fundamental and inescapable part of mobile applications. Think of your favourite email client or social media app; without a doubt they present scrolling vertical list of emails or posts.

In Xamarin.Forms, we can use the `ListView` to display vertical scrolling lists of items. However, Xamarin.Forms 4.3 introduced `CollectionView` as its successor. `CollectionView` simplifies many aspects of `ListView` and also adds new features.

In this 3-part blog series, we examine the benefits of collection views and how to migrate our existing list views to them.

 * In part one, we explore the benefits of collection view and what we gain by migrating away from list view.
 * In part two, we learn how to migrate our item user interfaces to support collection view.
 * In part three, we learn how to convert the interactivity of a list view to a collection view.

## Benefits

Let's start by examining the core benefits of converting a `ListView` to a `CollectionView`.

At a glance, `CollectionView` has some major benefits:

 * Simpler API surface.
 * Feature richness.
 * Increased flexibility.
 * Better performance

## Simpler API Surface

The first major benefit of `CollectionView` is that its API's are simpler and more intuitive than `ListView`.

So why is a simpler API surface important?

Firstly, a simpler API makes it **easier** to write correct code the first time and thus avoid bugs.

Next, a simpler API means that we write less code. In general, the less code that we have, the less likely we are to write bugs.

Lastly, a simpler API reduces cognitive load. Property names clearly indicate what they do and we can understand at a glance what they will accomplish.

### No More ViewCell

To create the user interface of a list views item, we would define our visual content inside a `ViewCell` that then lay within a `DataTemplate`.

In a `CollectionView`, however, we define our visual content directly within the `DataTemplate`.

By removing the concept of `ViewCell`s, we do not need to remember this abstraction. This makes it simpler and more intuitive to define list items.

### Automatic Virtualisation

Virtualisation, or cell recycling, refers to the practice of reusing views in the list as they scroll offscreen, rather than creating a new one for every item.

If we have 50 items available in our list, but we can only display 8 items, the list view would create 10 views. As an item scrolls off-screen, the list will reuse one of the non-visible views to present the next item as it appears on-screen.

ListViews use the `CachingStrategy` API to achieve this, however, CollectionViews automatically use virtualisation. This removes another piece of complexity that we used to need to consider.

### Built In Dynamic Cell Sizes

It is *very* common to create lists with multiple cell types that have varying sizes. `ListView`, however, did not support varying cell heights by default.

To support cells with differing height, we would omit the `RowHeight` property and then set `HasUnevenRows` to `true`. If we forgot to do this, it would lead to bugs where the cells content would be clipped where it exceeded the row height or show excessive padding.

CollectionView supports dynamic cell sizes out of the box.

## CollectionView: Feature Richness

CollectionView adds several useful features for us:

### Built-In Empty View

A common scenario we need to support when displaying lists of data is to accommodate when the list has no elements. Consider a search that returns no results; with `ListView` we have to manage toggling between the empty view and list items ourselves. With `CollectionView` we simply use the `EmptyView` property to specify what will be shown.

We will cover the `EmptyView` property in depth in the next article in this series.

## CollectionView: Increased Flexibility

Lastly, `CollectionView` is much more flexible for presenting collections of items:

### Vertical/Horizontal Scrolling

Collection views can scroll vertically or horizontally by specifiying the `IItemsLayout.Orientation` property. This works with both grid and list layouts!


### Grid Display

A popular layout for presenting data is a grid. Using `GridItemsLayout` on our `CollectionView` makes it easy to display grids of x rows or columns. 

## Feature Parity

CollectionViews also have full feature parity with ListViews, including the following features:

 * [Grouping](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview/grouping): Items in a CollectionView also support grouping and have additional features such as `GroupFooterTemplate`.
 * [Headers and Footers](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview/layout#headers-and-footers)
 * [Scroll To:](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview/scrolling) Use the `ScrollTo` method to scroll an item in the collection into view.
 * Separators: CollectionViews do not have them by default (removing them is a common task for devs).

## Summary

`CollectionView`, with its simpler API surface, rich features, and increased flexibility, provide many benefits over the traditional `ListView`.
