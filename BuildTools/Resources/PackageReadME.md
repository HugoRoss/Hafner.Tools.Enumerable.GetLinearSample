# Hafner.Tools.Enumerable.GetLinearSample

This micro package provides extension method `System.Collection.Generic.IEnumerable<T>.GetLinearSample(int count)`.

## Description

Package "Hafner.Tools.Enumerable.GetLinearSample" contains an extension method for an `IEnumerable<T>` that returns a linear sample
of the desired number of elements from the collection. Always the first and the last elements are returned and evenly spaced elements in between.

Assuming a collection contains 100 elements, a call to `collection.GetLinearSample(10)` would return a new `List<T>` containing the elements at index 0, 11, 22, 33, 44, 55, 66, 77, 88 and 99.

## Edge cases:

<li /> If a negative number of samples is requested, an <code>ArgumentOutOfRangeException</code> is thrown.
<li /> If the source list has less elements than requested samples, all elements are returned.
<li /> If the source list is null, an empty <code>List&lt;T&gt;</code> is returned.
<li /> If 0 samples are requested, an empty <code>List&lt;T&gt;</code> is returned.
<li /> If 1 sample is requested, the first element is returned.
<li /> If 2 samples are requested, the first and the last elements are returned.

## Supported Frameworks:

<li /> .NET framework versions <code>2.0</code>, <code>3.0</code>, <code>3.5</code>, <code>4.0</code>, <code>4.0.3</code>, <code>4.5</code>, <code>4.5.1</code>, <code>4.5.2</code>, <code>4.6</code>, <code>4.6.1</code>, <code>4.6.2</code>, <code>4.7</code>, <code>4.7.1</code>, <code>4.7.2</code>, <code>4.8</code>, <code>4.8.1</code>
<li /> .NET core versions <code>1.0</code>, <code>1.1</code>, <code>2.0</code>, <code>2.1</code>, <code>2.2</code>, <code>3.0</code>, <code>3.1</code>, <code>5.0</code>, <code>6.0</code>, <code>7.0</code>, <code>8.0</code>, <code>9.0</code>
<li /> .NET standard versions <code>1.0</code>, <code>1.1</code>, <code>1.2</code>, <code>1.3</code>, <code>1.4</code>, <code>1.5</code>, <code>1.6</code>, <code>2.0</code>, <code>2.1</code>
