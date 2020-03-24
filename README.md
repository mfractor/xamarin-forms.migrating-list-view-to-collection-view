# Migrating ListView to CollectionView in Xamarin.Forms

*A guide for converting a ListView to CollectionView*

## Introduction

One of the *most common* patterns in mobile applications is displaying a list of items.

Think of your favourite email, social media or recip

For displaying lists of items in

 * Display lists of items in Xamarin.Forms

 List view has long been the staple

Firstly, why would you migrate? If your app is working already, what are the benefits that we



 **What is ListView**

 **What is CollectionView**

 **Why would we migrate?**

  * Simpler API surface (no need for ViewCells)
  * Grid and horizontal support.
  *

In this three part series, we will explore how to convert a ListView to a CollectionView, examining

This series is

These steps are:

 Part One: Benfits of Collection RefreshView
 Part Two: User Interface
 Part Three: Interactivity


 1. Convert the list item views from ViewCells to DataTemplates.
 2. Handle item selection events in a CollectionView.
 3. Adding pull to refresh to a CollectionView.
 4. Display an empty view when your list contains no items.
 5. Add item interactivity/context actions using SwipeView.

Firstly, let's examine the major benefits that a CollectionView provides over ListView.

## Simpler API Surface

## Built-In Dynamic Cell Sizes

## In-Built Support For Empty Collections

## Summary

 * No more view cells.
 * Automatic dynamic cell size support.

  * Simplier API surface:
  * More flexible , supports grid layout and horizontal scrolling
  * Support for automatic.
  * Empty view support.

## Recipe

In **Part 1** of this series, I will examine the benefits that COllectionView provides and

In **Part 2** of this series, I will walk through the process of converting the user interface of

Part 1: **Converting our cells to normal data templates (including guide for data template selectors)**

 * Removing the ViewCell.


Part 2: **Handling Item Selection Events**

 * Adding a TapGestureRecogniser -> Command/Tapped onto a view in the data template.

Part 3: **Adding refresh support (pull to refresh)**

 * Outline how to wrap a colleciton view with a RefreshView.

Part 4: **Adding empty support**

  * Outline how to use the EmptyView to show a "Sorry, no your search returned no result." message
  * Explain that EmptyView is much simplier than implementing the equivalent behaviour using a list view.

Part 5: **Adding swipe actions (menu items)**

 * Outline how to use SwipeView to add backing actions to a cell.


**Summary:**
