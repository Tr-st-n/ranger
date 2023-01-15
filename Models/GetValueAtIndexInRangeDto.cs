namespace RangerWebAPI.Models;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// DTO for getting a value at an index in an arithmetic sequence of <see cref="int"/> with a term to term rule of +1.
/// </summary>
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class GetValueAtIndexInRangeDto
{
    public int Begin { get; set; }

    public int End { get; set; }

    public int GetAtIndex { get; set; }
}
