## Introduction

Lists are a fundamental and inescapable part of mobile applications. Think of your favourite email client or social media app; without a doubt they present scrolling vertical list of emails or posts. Presenting a list of

In Xamarin.Forms, we display can use the `ListView` to display scrolling

However, Xamarin.Forms 4.3 introduced CollectionView, a successor to ListView. CollectionView has simplifies

In this 3 part series, we examine the benefits of collection view and how

In part one (this article), we explore the benefits of collection view and what we gain by migrating away from list view.

In part two, we learn how to migrate our item user interfaces to support collection view.

In part three, we learn how to convert the interactivity of a list view to a collection view. This includes item selection events, context menu items and pull to refresh.

## Benefits

Let's start by examining the core benefits of converting a ListView to a CollectionView.

At a glance, CollectionView has three major benefits:

 * Simpler API surface.
 * Feature richness
 * Increased Flexibility

## Simpler API Surface

The first major benefit of CollectionView is that its API's are simpler and more intuitive than ListView.

So why is a simpler API surface important?

Firstly, a simpler API makes is **easier** to write correct code the first time and thus avoid bugs.

Next, a simpler API means that we write less code. In general, the less code that we have, the less likely we are to write bugs.

Lastly, a simpler API reduces cognitive load. Property names clearly indicate what they do and we can understand at a glance what they will accomplish. This

### No More ViewCell

To create the user interface of a list views item, we would define our visual content inside a `ViewCell` that then lay within a `DataTemplate`.

In a CollectionView, however, we define our visual content directly within the `DataTemplate`.

By removing the concept of `ViewCell`s, we do not need to remember this abstraction. This makes it simpler and more intuitive to define list items.

### Automatic Virtualisation

Cell virtualisation refers to when a list recycles the cells displayed in the list when they scroll off screen, rather than creating a new one for every item

ListViews

### Built In Dynamic Cell Sizes

It is *very* common to create lists with multiple cell types that have varying sizes. ListView, however, did not support varying cell heights by default.

To accomplish variable cell sizes, we would omit the `RowHeight` property and then set `HasUnevenRows` to `true`. If we forgot to do this, it would lead to bugs where the cells content would be clipped where it exceeded

CollectionView supports dynamic cell sizes out of the box.

If we did want t

## CollectionView: Feature Richness

CollectionView adds several useful

### Built-In Empty View

When a CollectionView's `ItemSource` is null or empty, we can use the `EmptyView` to defin

### Item Snapping



## CollectionView: Increased Flexibility

Lastly, CollectionView is a much more flexible for presenting collections of items.

### Vertical/Horizontal Scrolling

CollectionViews


### Grid Display

A popular method to present

## Feature Parity

CollectionViews also have full feature parity with ListViews, this includes the following features:

 * Grouping: Items in a CollectionView also support grouping through the
 * Header View: CollectionView supports header
 * Footer View: CollectionView also support
 * [Scroll To:](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/collectionview/scrolling) Use the `ScrollTo` method to scroll an item in the collection into view.
 * Seperator Item: CollectionViews do not have

## Summary

CollectionViews, with their simpler API surface, rich features and increased flexibility, provide many benefits
