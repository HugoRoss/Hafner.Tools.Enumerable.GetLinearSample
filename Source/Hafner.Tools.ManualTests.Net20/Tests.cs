namespace Hafner.Tools.ManualTests;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("Usage", "CA2201:Do not raise reserved exception types", Justification = $"It's good enough, minimal effort to write the '{nameof(Tests)}' class.")]
internal static class Tests {

    public static void GetLinearSample_Enumerable_MoreElements() {
        //Arrange
        IEnumerable<int> collection = Enumerable.Range(0, 100);
        //Act
        List<int> result = collection.GetLinearSample(10);
        //Assert
        Assert.AreEqual(10, result.Count);
        List<int> expectedElements = [0, 11, 22, 33, 44, 55, 66, 77, 88, 99];
        Assert.IsTrue(expectedElements.SequenceEqual(result), "The result does not contain the expected elements!");
    }

    public static void GetLinearSample_Collection_MoreElements() {
        //Arrange
        List<int> collection = Collection.Range(0, 100);
        //Act
        List<int> result = collection.GetLinearSample(10);
        //Assert
        List<int> expectedElements = [0, 11, 22, 33, 44, 55, 66, 77, 88, 99];
        Assert.IsTrue(expectedElements.SequenceEqual(result), "The result does not contain the expected elements!");
    }

    public static void GetLinearSample_Enumerable_LessElements() {
        //Arrange
        IEnumerable<int> collection = Enumerable.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(10);
        //Assert
        Assert.AreEqual(5, result.Count);
        List<int> expectedElements = [0, 1, 2, 3, 4];
        Assert.IsTrue(expectedElements.SequenceEqual(result), "The result does not contain the expected elements!");
        Assert.AreNotSame(collection, result, "The list must be cloned to avoid side-effects!");
    }

    public static void GetLinearSample_Collection_LessElements() {
        //Arrange
        List<int> collection = Collection.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(10);
        //Assert
        Assert.AreEqual(5, result.Count);
        List<int> expectedElements = [0, 1, 2, 3, 4];
        Assert.IsTrue(expectedElements.SequenceEqual(result), "The result does not contain the expected elements!");
        Assert.AreNotSame(collection, result, "The list must be cloned to avoid side-effects!");
    }

    public static void GetLinearSample_Enumerable_SameNumberOfElements() {
        //Arrange
        IEnumerable<int> collection = Enumerable.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(5, result.Count);
        List<int> expectedElements = [0, 1, 2, 3, 4];
        Assert.IsTrue(expectedElements.SequenceEqual(result), "The result does not contain the expected elements!");
        Assert.AreNotSame(collection, result, "The list must be cloned to avoid side-effects!");
    }

    public static void GetLinearSample_Collection_SameNumberOfElements() {
        //Arrange
        List<int> collection = Collection.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        List<int> expectedElements = [0, 1, 2, 3, 4];
        Assert.IsTrue(expectedElements.SequenceEqual(result), "The result does not contain the expected elements!");
        Assert.AreNotSame(collection, result, "The list must be cloned to avoid side-effects!");
    }

    public static void GetLinearSample_Enumerable_NegativeNumberOfSamples() {
        //Arrange
        IEnumerable<int> collection = Enumerable.Range(0, 5);
        //Act
        try {
            collection.GetLinearSample(-1);
        } catch (ArgumentOutOfRangeException) {
            return; //Expected
        }
        throw new Exception("An ArgumentOutOfRangeException expected!");
    }

    public static void GetLinearSample_Collection_ZeroSamples() {
        //Arrange
        List<int> collection = Collection.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(0);
        //Assert
        Assert.AreEqual(0, result.Count);
    }

    public static void GetLinearSample_Collection_OneSample() {
        //Arrange
        List<int> collection = Collection.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(1);
        //Assert
        Assert.AreEqual(1, result.Count);
        List<int> expectedElements = [0];
        Assert.IsTrue(expectedElements.SequenceEqual(result), "The result does not contain the expected elements!");
    }

    public static void GetLinearSample_Collection_TwoSamples() {
        //Arrange
        List<int> collection = Collection.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(2);
        //Assert
        Assert.AreEqual(2, result.Count);
        List<int> expectedElements = [0, 4];
        Assert.IsTrue(expectedElements.SequenceEqual(result), "The result does not contain the expected elements!");
    }

    public static void GetLinearSample_Collection_ThreeSamples() {
        //Arrange
        List<int> collection = Collection.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(3);
        //Assert
        Assert.AreEqual(3, result.Count);
        List<int> expectedElements = [0, 2, 4];
        Assert.IsTrue(expectedElements.SequenceEqual(result), "The result does not contain the expected elements!");
    }

    public static void GetLinearSample_Enumerable_NoElements() {
        //Arrange
        IEnumerable<int> collection = [];
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(0, result.Count);
    }

    public static void GetLinearSample_Enumerable_Null() {
        //Arrange
        IEnumerable<int>? collection = null;
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(0, result.Count);
    }

    public static void GetLinearSample_Collection_Null() {
        //Arrange
        List<int>? collection = null;
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(0, result.Count);
    }

}
