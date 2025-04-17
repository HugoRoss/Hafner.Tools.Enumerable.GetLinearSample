namespace Hafner.Tools.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hafner.Tools;

/// <summary>
/// Ensures correct functionality of the <see cref="IEnumerableExtension_GetLinearSample.GetLinearSample{T}(IEnumerable{T}?, Int32)"/> extension methods.
/// </summary>
[TestClass]
public class Test_IEnumerable_GetLinearSample {

    [TestMethod]
    public void GetLinearSample_Enumerable_MoreElements() {
        //Arrange
        IEnumerable<int> collection = Enumerable.Range(0, 100);
        //Act
        List<int> result = collection.GetLinearSample(10);
        //Assert
        Assert.AreEqual(10, result.Count);
        result.Should().ContainInConsecutiveOrder([0, 11, 22, 33, 44, 55, 66, 77, 88, 99]);
        List<int> expectedElements = [0, 11, 22, 33, 44, 55, 66, 77, 88, 99];
        Assert.IsTrue(expectedElements.SequenceEqual(result));
    }

    [TestMethod]
    public void GetLinearSample_Collection_MoreElements() {
        //Arrange
        List<int> collection = Enumerable.Range(0, 100).ToList();
        //Act
        List<int> result = collection.GetLinearSample(10);
        //Assert
        Assert.AreEqual(10, result.Count);
        result.Should().ContainInConsecutiveOrder([0, 11, 22, 33, 44, 55, 66, 77, 88, 99]);
    }

    [TestMethod]
    public void GetLinearSample_Enumerable_LessElements() {
        //Arrange
        IEnumerable<int> collection = Enumerable.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(10);
        //Assert
        Assert.AreEqual(5, result.Count);
        result.Should().ContainInConsecutiveOrder([0, 1, 2, 3, 4]);
    }

    [TestMethod]
    public void GetLinearSample_Collection_LessElements() {
        //Arrange
        List<int> collection = Enumerable.Range(0, 5).ToList();
        //Act
        List<int> result = collection.GetLinearSample(10);
        //Assert
        Assert.AreEqual(5, result.Count);
        result.Should().ContainInConsecutiveOrder([0, 1, 2, 3, 4]);
        Assert.AreNotSame(collection, result, "The list must be cloned to avoid side-effects!");
    }

    [TestMethod]
    public void GetLinearSample_Enumerable_SameNumberOfElements() {
        //Arrange
        IEnumerable<int> collection = Enumerable.Range(0, 5);
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(5, result.Count);
        result.Should().ContainInConsecutiveOrder([0, 1, 2, 3, 4]);
    }

    [TestMethod]
    public void GetLinearSample_Collection_SameNumberOfElements() {
        //Arrange
        List<int> collection = Enumerable.Range(0, 5).ToList();
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(5, result.Count);
        result.Should().ContainInConsecutiveOrder([0, 1, 2, 3, 4]);
    }

    [TestMethod]
    public void GetLinearSample_Enumerable_NegativeNumberOfSamples() {
        //Arrange
        IEnumerable<int> collection = Enumerable.Range(0, 5);
        //Act
        Func<List<int>> sut = () => collection.GetLinearSample(-1);
        sut.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("The value of the argument for parameter '*' cannot be negative!*").And.ParamName.Should().Be("count");
    }

    [TestMethod]
    public void GetLinearSample_Collection_ZeroSamples() {
        //Arrange
        List<int> collection = Enumerable.Range(0, 5).ToList();
        //Act
        List<int> result = collection.GetLinearSample(0);
        //Assert
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void GetLinearSample_Collection_OneSample() {
        //Arrange
        List<int> collection = Enumerable.Range(0, 5).ToList();
        //Act
        List<int> result = collection.GetLinearSample(1);
        //Assert
        Assert.AreEqual(1, result.Count);
        result.Should().ContainInConsecutiveOrder([0]);
    }

    [TestMethod]
    public void GetLinearSample_Collection_TwoSamples() {
        //Arrange
        List<int> collection = Enumerable.Range(0, 5).ToList();
        //Act
        List<int> result = collection.GetLinearSample(2);
        //Assert
        Assert.AreEqual(2, result.Count);
        result.Should().ContainInConsecutiveOrder([0, 4]);
    }

    [TestMethod]
    public void GetLinearSample_Collection_ThreeSamples() {
        //Arrange
        List<int> collection = Enumerable.Range(0, 5).ToList();
        //Act
        List<int> result = collection.GetLinearSample(3);
        //Assert
        Assert.AreEqual(3, result.Count);
        result.Should().ContainInConsecutiveOrder([0, 2, 4]);
    }

    [TestMethod]
    public void GetLinearSample_Enumerable_NoElements() {
        //Arrange
        IEnumerable<int> collection = [];
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(0, result.Count);
        result.Should().BeEmpty();
    }

    [TestMethod]
    public void GetLinearSample_Collection_NoElements() {
        //Arrange
        List<int> collection = [];
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(0, result.Count);
        Assert.AreNotSame(collection, result);
    }

    [TestMethod]
    public void GetLinearSample_Enumerable_Null() {
        //Arrange
        IEnumerable<int>? collection = null;
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(0, result.Count);
        result.Should().BeEmpty();
    }

    [TestMethod]
    public void GetLinearSample_Collection_Null() {
        //Arrange
        List<int>? collection = null;
        //Act
        List<int> result = collection.GetLinearSample(5);
        //Assert
        Assert.AreEqual(0, result.Count);
    }

}
