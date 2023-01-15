namespace API.Tests;

using System.Diagnostics.CodeAnalysis;
using Types;

[SuppressMessage("ReSharper", "CollectionNeverQueried.Local")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Local")]
public class RangerTests
{
    #region Ctor

    [Fact]
    public void Ctor_ValidParams_GetsValidBeginAndEndProperties()
    {
        // Arrange - Ranger of values 100 to 200
        var beginParam = 100;
        var endParam = 200;
        var ranger = new Ranger(beginParam, endParam);

        // Act - Get Begin and End
        var begin = ranger.Begin;
        var end = ranger.End;

        // Assert - Begin in equals begin out, end in equals end out
        Assert.Equal(beginParam, begin);
        Assert.Equal(endParam, end);
    }

    [Fact]
    public void Ctor_BeginGreaterThanEnd_ThrowsArgumentOutOfRangeException()
    {
        // AAA - Constructing Ranger with Begin of 200 and End of 100 throws ArgumentOutOfRangeException
        Assert.Throws<ArgumentOutOfRangeException>(() => new Ranger(200, 100));
    }

    [Fact]
    public void Ctor_BeginEqualsEnd_ThrowsArgumentOutOfRangeException()
    {
        // AAA - Constructing Ranger with Begin and End of 100 throws ArgumentOutOfRangeException
        Assert.Throws<ArgumentOutOfRangeException>(() => new Ranger(100, 100));
    }

    #endregion

    #region Count

    [Fact]
    public void Count_Get_IsValid()
    {
        // Arrange - Ranger of values 1 to 5 (1, 2, 3, 4, 5)
        var ranger = new Ranger(1, 5);

        // Act - Get Count
        var count = ranger.Count;

        // Assert - Count is 5
        Assert.Equal(5, count);
    }

    #endregion

    #region IsReadOnly

    [Fact]
    public void IsReadOnly_Get_IsTrue()
    {
        // Arrange - Ranger of values 1 to 5
        var ranger = new Ranger(1, 5);

        // Act - Get IsReadyOnly
        var isReadOnly = ranger.IsReadOnly;

        // Assert - is TRUE
        Assert.True(isReadOnly);
    }

    #endregion

    #region [this] Index

    [Fact]
    public void ThisIndex_AtValidIndex_IsValid()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act - Get value at index 50
        var value = ranger[50];

        // Assert - Value is 150
        Assert.Equal(150, value);
    }

    [Fact]
    public void ThisIndex_AtInvalidIndex_ThrowsIndexOutOfRangeException()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act and Assert - Accessing out of range index throws IndexOutOfRangeException
        Assert.Throws<IndexOutOfRangeException>(() => ranger[150]);
    }

    [Fact]
    public void ThisIndex_Set_ThrowsNotSupportedException()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act and Assert - Setting index throws NotSupportedException
        Assert.Throws<NotSupportedException>(() => ranger[50] = 60);
    }

    #endregion

    #region Index Of

    [Fact]
    public void IndexOf_ValidValue_IsValid()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act - Get index of value 150
        var index = ranger.IndexOf(150);

        // Assert - Index is 50
        Assert.Equal(50, index);
    }

    [Fact]
    public void IndexOf_InvalidValue_IsMinusOne()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act - Get index of [invalid] value 300
        var index = ranger.IndexOf(300);

        // Assert - Index is -1 (not found)
        Assert.Equal(-1, index);
    }

    #endregion

    #region Contains

    [Fact]
    public void Contains_ValidItem_IsTrue()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act - Get Contains of value 150
        var contains = ranger.Contains(150);

        // Assert - Contains is TRUE
        Assert.True(contains);
    }

    [Fact]
    public void Contains_InvalidItem_IsFalse()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act - Get Contains of value 300
        var contains = ranger.Contains(300);

        // Assert - Contains is FALSE
        Assert.False(contains);
    }

    #endregion

    #region CopyTo

    [Fact]
    public void CopyTo_ValidParams_IsValid()
    {
        // Arrange
        var rangeStart = 3;
        var rangeEnd = 5;
        var ranger = new Ranger(rangeStart, rangeEnd);
        var array = new[] { 1, 1, 1, 1, 1 };
        var startingIndex = 2;

        // Act - Copy to array
        ranger.CopyTo(array, startingIndex);

        // Assert - Array at index below startingIndex is value 1, array at index startingIndex and greater is valid
        for (var i = 0; i < startingIndex; i++)
        {
            Assert.Equal(1, array[i]);
        }
        for (var i = startingIndex; i < array.Length; i++)
        {
            Assert.Equal(rangeStart + i, array[i]);
        }
    }

    [Fact]
    public void CopyTo_NotEnoughSpace_ThrowsArgumentException()
    {
        // Arrange
        var rangeStart = 3;
        var rangeEnd = 5;
        var ranger = new Ranger(rangeStart, rangeEnd);
        var array = new[] { 1, 1, 1, 1, 1 };
        var startingIndex = 3;

        // Act and Assert - Copy to with invalid index throws ArgumentOutOfRangeException
        Assert.Throws<ArgumentException>(() => ranger.CopyTo(array, startingIndex));
    }

    [Fact]
    public void CopyTo_InvalidIndexParam_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var rangeStart = 3;
        var rangeEnd = 5;
        var ranger = new Ranger(rangeStart, rangeEnd);
        var array = new[] { 1, 1, 1, 1, 1 };
        var startingIndex = -1;

        // Act and Assert - Copy to with invalid index throws ArgumentOutOfRangeException
        Assert.Throws<ArgumentOutOfRangeException>(() => ranger.CopyTo(array, startingIndex));
    }

    [Fact]
    public void CopyTo_NullArrayParam_ThrowsArgumentNullException()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act and Assert - Copy to null array throws ArgumentNullException
        Assert.Throws<ArgumentNullException>(() => ranger.CopyTo(null!, 50));
    }

    #endregion

    #region Enumeration

    [Fact]
    public void Enumeration_ForEach_ValuesAreValid()
    {
        // Arrange - Ranger of values 100 to 200
        var begin = 100;
        var end = 200;
        var ranger = new Ranger(begin, end);
        var index = 0;

        // Act and Assert - Enumerated values are as expected
        foreach (var item in ranger)
        {
            Assert.Equal(item, begin + index);
            index++;
        }
    }

    #endregion

    #region Not Supported

    [Fact]
    public void Add_Call_ThrowsNotSupported()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act and Assert - Add throws NotSupportedException
        Assert.Throws<NotSupportedException>(() => ranger.Add(201));
    }

    [Fact]
    public void Clear_Call_ThrowsNotSupported()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act and Assert - Clear throws NotSupportedException
        Assert.Throws<NotSupportedException>(() => ranger.Clear());
    }

    [Fact]
    public void Insert_Call_ThrowsNotSupported()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act and Assert - Insert throws NotSupportedException
        Assert.Throws<NotSupportedException>(() => ranger.Insert(0, 1));
    }

    [Fact]
    public void Remove_Call_ThrowsNotSupported()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act and Assert - Insert throws NotSupportedException
        Assert.Throws<NotSupportedException>(() => ranger.Remove(150));
    }

    [Fact]
    public void RemoveAt_Call_ThrowsNotSupported()
    {
        // Arrange - Ranger of values 100 to 200
        var ranger = new Ranger(100, 200);

        // Act and Assert - Insert throws NotSupportedException
        Assert.Throws<NotSupportedException>(() => ranger.RemoveAt(50));
    }

    #endregion
}
