namespace Hafner.Tools;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Class that contains the extension method <see cref="IEnumerator{T}" />.<see cref="GetLinearSample{T}(IEnumerable{T}?, Int32)">GetLinearSample(int count)</see>`.
/// </summary>
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "It looks smarter.")]
public static class IEnumerableExtension_GetLinearSample {

    /// <summary>
    /// Extension method for an <see cref="IEnumerable{T}"/> that returns a linear sample of the desired number of elements (<paramref name="count"/>) from
    /// the <paramref name="collection"/> (or less if the collection does not contain that many elements). Always the first and the last elements
    /// are returned and evenly spaced elements in between.<br/><br/>
    /// Assuming the collection contains 100 elements, a call to <c>collection.GetLinearSample(10)</c> would return a new List&lt;T&gt; containing the elements at index 0, 11, 22, 33, 44, 55, 66, 77, 88 and 99.
    /// </summary>
    /// <typeparam name="T">The type of the collection's elements.</typeparam>
    /// <param name="collection">The source collection from which to take the sample elements.</param>
    /// <param name="count">The (maximum) number of elements to sample.</param>
    /// <returns>A new <see cref="List{T}"/> containing the sample elements.</returns>
    /// <exception cref="ArgumentOutOfRangeException">An <see cref="ArgumentOutOfRangeException"/> is thrown if the <paramref name="count"/> is negative.</exception>
    [SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "It is guaranteed that always a new instance is returned and therefore no side-effect is possible.")]
    public static List<T> GetLinearSample<T>(this IEnumerable<T>? collection, int count) {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), count, $"The value of the argument for parameter '{nameof(count)}' cannot be negative!");
        if (collection is null) return [];
        if (count == 0) return [];

        bool isClone = false;
        List<T>? list = null;
        if (collection is not IList<T> iList) {
            iList = list = [.. collection];
            isClone = true;
        }
        if (iList.Count == 0) return isClone ? list! : [.. iList];
        if (iList.Count <= count) return isClone ? list! : [.. iList];

        if (count == 1) return [iList[0]];
        if (count == 2) return [iList[0], iList[iList.Count - 1]];

        list = new List<T>(count);
        foreach (int index in GetIndex(iList.Count, count)) {
            T element = iList[index];
            list.Add(element);
        }
        return list;
    }

    private static IEnumerable<int> GetIndex(int numberOfElements, int numberOfSamples) {
        double spacing = GetExactSpacing(numberOfElements, numberOfSamples);
        for (int i = 0; i < numberOfSamples; i++) {
            double indexValue = spacing * i;
            int index = (int)Math.Round(indexValue);
            yield return index;
        }
    }

    private static double GetExactSpacing(int numberOfElements, int numberOfSamples) {
        return (numberOfElements - 1.0) / (numberOfSamples - 1.0);
    }

}
