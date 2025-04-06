namespace Hafner.Tools.ManualTests;

using System;
using System.Collections.Generic;

internal static class Enumerable {

    public static IEnumerable<int> Range(int from, int to) {
        for (int i = from; i < to; i++) {
            yield return i;
        }
    }

    /// <summary>
    /// Determines whether two sequences are equal by comparing the elements by using the default equality comparer for their type.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}" /> to compare to second.</param>
    /// <param name="second">An <see cref="IEnumerable{T}" /> to compare to the first sequence.</param>
    /// <returns><see langword="true"/> if the two source sequences are of equal length and their corresponding elements are equal according to the default equality comparer for their type; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">An <see cref="ArgumentNullException"/> is thrown if <paramref name="first"/> or <paramref name="second"/> is <see langword="null"/>.</exception>
    public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
        return first.SequenceEqual(second, null);
    }

    /// <summary>
    /// Determines whether two sequences are equal by comparing the elements by using the given <paramref name="comparer"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="first">An <see cref="IEnumerable{T}" /> to compare to second.</param>
    /// <param name="second">An <see cref="IEnumerable{T}" /> to compare to the first sequence.</param>
    /// <param name="comparer">An equality comparer used to compare the elements.</param>
    /// <returns><see langword="true"/> if the two source sequences are of equal length and their corresponding elements are equal according to the given equality comparer; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">An <see cref="ArgumentNullException"/> is thrown if <paramref name="first"/> or <paramref name="second"/> is <see langword="null"/>.</exception>
    public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) {
        comparer ??= EqualityComparer<TSource>.Default;

        if (first is null) throw new ArgumentNullException(nameof(first));
        if (second is null) throw new ArgumentNullException(nameof(second));

        using (IEnumerator<TSource> enumerator = first.GetEnumerator()) {
            using IEnumerator<TSource> enumerator2 = second.GetEnumerator();
            while (enumerator.MoveNext()) {
                if (!enumerator2.MoveNext() || !comparer.Equals(enumerator.Current, enumerator2.Current)) {
                    return false;
                }
            }

            if (enumerator2.MoveNext())  return false;
        }

        return true;
    }

}
