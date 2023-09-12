using CustomFizzBuzzApi.Interfaces;
using CustomFizzBuzzApi.Models;
using static System.Linq.Enumerable;

namespace CustomFizzBuzzApi.Services;

public class CustomFizzBuzzService : ICustomFizzBuzzService
{
    public CustomFizzBuzzResponseDTO GenerateCustomFizzBuzzOutput(CustomFizzBuzzRequestDTO request)
    {
        var output = new CustomFizzBuzzResponseDTO();

        // loop through the expected response and add it to the output text
        foreach (var index in Range(1, request.MaxNumber))
        {
            var lineValue = GetCombinedReplacementWordOrIndexString(index, request.ReplacementWords);
            var lineText = $"{lineValue}";
            output.OutputLines.Add(lineText);
        }

        output.OutputText = GetCombinedOutputText("\n", output.OutputLines);

        return output;
    }

    private string GetCombinedOutputText(string joinPattern, List<string> outputLines)
    {
        return string.Join(joinPattern, outputLines);
    }

    private string GetCombinedReplacementWordOrIndexString(int index, Dictionary<int, string> replacementWords)
    {
        var outputString = String.Empty;

        var potentialKeys = replacementWords.Keys.Where(key => key <= index).ToList();

        var validKeys = FindValidMultiplesFromKeys(index, potentialKeys);

        // If there are no valid multiples, we can return early with the index
        if (validKeys.Count < 1) { return index.ToString(); }

        foreach (int key in validKeys)
        {
            outputString += replacementWords[key];
        }

        return outputString;
        
    }

    private List<int> FindValidMultiplesFromKeys(int index, List<int> potentialMultiples)
    {
        var multiples = new List<int>();

        foreach (int key in potentialMultiples)
        {
            if (index % key == 0)
            {
                multiples.Add(key);
            }
        }

        return multiples;
    }
}
