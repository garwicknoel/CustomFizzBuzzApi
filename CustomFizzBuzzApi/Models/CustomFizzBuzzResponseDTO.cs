namespace CustomFizzBuzzApi.Models;

public class CustomFizzBuzzResponseDTO
{
    public CustomFizzBuzzResponseDTO()
    {
        OutputLines = new List<string>();
    }
    public List<string> OutputLines { get; set; }
    public string OutputText { get; set; }
}