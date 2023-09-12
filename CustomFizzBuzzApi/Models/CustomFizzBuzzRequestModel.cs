namespace CustomFizzBuzzApi.Models;

public class CustomFizzBuzzRequestModel
{
    public int MaxNumber { get; set; }
    public required Dictionary<int, string> ReplacementWords { get; set; }
    public string ErrorMessage { get; set; }
}