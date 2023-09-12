using System.Runtime.Serialization;

namespace CustomFizzBuzzApi.Models;

[DataContract]
public class CustomFizzBuzzRequestDTO
{
    public int MaxNumber { get; set; }
    public required Dictionary<int, string> ReplacementWords { get; set; }
}