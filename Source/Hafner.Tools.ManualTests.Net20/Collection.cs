namespace Hafner.Tools.ManualTests;

using System.Collections.Generic;

internal static class Collection {

    public static List<int> Range(int from, int to) {
        List<int> result = new List<int>(to - from);
        for (int i = from; i < to; i++) {
            result.Add(i);
        }
        return result;
    }

}
