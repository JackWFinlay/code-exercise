// System.Text using removed here, we don't need it,
// we can format with an interpolated string instead
// we don't need to worry about the templating.

// Moved to file-scoped namespace
// You would potentially change a flag in the .csproj or .sln 
// to allow this on older versions of .NET
namespace PointsBet_Backend_Online_Code_Test;

/*
Improve a block of code as you see fit in C#.
You may make any improvements you see fit, for example:
    - Cleaning up code
    - Removing redundancy
    - Refactoring / simplifying
    - Fixing typos
    - Any other light-weight optimisation
*/
public class StringFormatter
{
    //Code to improve
    // Renamed to "ToCommaSeparatedList", fixes typo.
    // The name suggests this could alternatively be an extension method with the signature:
    // public static string ToCommaSeparatedList(this string[] items, string quote)
    public static string ToCommaSeparatedList(string[] items, string quote)
    {
        // No point attempting a Select and Join on an empty array below
        if (items.Length == 0)
        {
            // This could alternatively throw an exception,
            // but it really depends on the context this method is called in.
            return "";
        }

        // Project items values to new format
        // An interpolated string is fine here as we don't have to worry about memory issues in this case
        // (think logging frameworks that cache, there you would use a template instead).
        // Also, because this returns an enumerable, it potentially isn't enumerated until actually used.
        var escapedItems = items.Select(item => $"{quote}{item}{quote}");
        
        // This automatically handles cases where escapedItems is length 0, 1, or >1
        // length 0 -> "" - we've already checked for this
        // length 1 -> "{quote}{item}{quote}"
        // length 2 -> "{quote}{item}{quote}, {quote}{item}{quote}"
        // length >2 -> "{quote}{item}{quote}, {quote}{item}{quote}, {quote}{item}{quote}[...etc]"
        var csv = string.Join(", ", escapedItems);
        
        // Assigning to a variable before returning a result aids in debugging
        return csv;
    }
}

