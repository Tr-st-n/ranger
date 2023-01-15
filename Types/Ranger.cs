namespace RangerWebAPI.Types;

using System.Collections;

/// <summary>
/// Represents a arithmetic sequence of <see cref="int"/> with a term to term rule of +1.
/// </summary>
public class Ranger : IList<int>
{
    /// <summary>
    /// Constructs a <see cref="Ranger"/>.
    /// </summary>
    /// <param name="begin">The inclusive lower bound (and first item) of the sequence.</param>
    /// <param name="end">  The inclusive upper bound (and last item) of the sequence.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if begin is not less than end.</exception>
    public Ranger(int begin, int end)
    {
        // Ensure begin ctor param is less than end
        if (begin >= end)
        {
            throw new ArgumentOutOfRangeException($"Begin value must be greater than End value");
        }

        // Initialize properties
        Begin = begin;
        End = end;
        Count = End - Begin + 1;
    }

    /// <summary>Gets the inclusive lower bound and first item of the <see cref="Ranger"/> sequence.</summary>
    /// <returns>The inclusive lower bound and first item of the <see cref="Ranger"/> sequence.</returns>
    public int Begin { get; }

    /// <summary>Gets the inclusive upper bound and last item of the <see cref="Ranger"/> sequence.</summary>
    /// <returns>The inclusive upper bound and last item of the <see cref="Ranger"/> sequence.</returns>
    public int End { get; }

    #region Implements Properties

    /// <inheritdoc />
    public int Count { get; }

    /// <inheritdoc />
    public int this[int index]
    {
        get
        {
            // If index is in possible range
            if (index >= 0 && index < Count)
            {
                return index + Begin;
            }

            // Otherwise throw index out of range exception
            throw new IndexOutOfRangeException($"index is not a valid index in the {nameof(Ranger)}.");
        }
        set => throw new NotSupportedException($"{nameof(Ranger)} is read-only.");
    }

    /// <inheritdoc />
    public bool IsReadOnly => true;

    #endregion

    #region Implements IList<T> (Methods)

    /// <inheritdoc />
    public int IndexOf(int item)
    {
        // If this Contains item
        if (Contains(item))
        {
            // Return index
            return item - Begin;
        }

        // Otherwise -1
        return -1;
    }

    #endregion

    #region Implements ICollection<T> (Methods)

    /// <inheritdoc />
    /// <remarks>
    /// Will return true if the item is greater than or equal to <see cref="Begin"/>
    /// or less than or equal to <see cref="End"/>.
    /// </remarks>
    public bool Contains(int item)
    {
        return item >= Begin && item <= End;
    }

    /// <inheritdoc />
    public void CopyTo(int[] array, int arrayIndex)
    {
        // Throw if array is null
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        // Throw if arrayIndex is less than 0
        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException($"{nameof(arrayIndex)} is less than 0.");
        }

        // Throw if not enough space in destination array
        if (Count + arrayIndex > array.Length)
        {
            throw new ArgumentException(
                $"The number of elements in the source {nameof(Ranger)} is greater than the available space from arrayIndex to the end of the destination array.");
        }

        // Copy sequence into array
        for (var i = arrayIndex; i < Count + arrayIndex; i++)
        {
            array[i] = Begin + i;
        }
    }

    #endregion

    #region Implements IEnumerable<T> (Methods)

    /// <inheritdoc />
    public IEnumerator<int> GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
        {
            yield return i + Begin;
        }
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion

    #region Not Supported

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">Always thrown as <see cref="Ranger"/> is read-only.</exception>
    /// <remarks><see cref="NotSupportedException"/> is always thrown as <see cref="Ranger"/> is read-only.</remarks>
    public void Add(int item) => throw new NotSupportedException();

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">Always thrown as <see cref="Ranger"/> is read-only.</exception>
    /// <remarks><see cref="NotSupportedException"/> is always thrown as <see cref="Ranger"/> is read-only.</remarks>
    public void Clear() => throw new NotSupportedException();

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">Always thrown as <see cref="Ranger"/> is read-only.</exception>
    /// <remarks><see cref="NotSupportedException"/> is always thrown as <see cref="Ranger"/> is read-only.</remarks>
    public void Insert(int index, int item) => throw new NotSupportedException();

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">Always thrown as <see cref="Ranger"/> is read-only.</exception>
    /// <remarks><see cref="NotSupportedException"/> is always thrown as <see cref="Ranger"/> is read-only.</remarks>
    public bool Remove(int item) => throw new NotSupportedException();

    /// <inheritdoc />
    /// <exception cref="NotSupportedException">Always thrown as <see cref="Ranger"/> is read-only.</exception>
    /// <remarks><see cref="NotSupportedException"/> is always thrown as <see cref="Ranger"/> is read-only.</remarks>
    public void RemoveAt(int index) => throw new NotSupportedException();

    #endregion
}
