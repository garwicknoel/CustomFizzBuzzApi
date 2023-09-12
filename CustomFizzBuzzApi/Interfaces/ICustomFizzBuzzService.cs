using CustomFizzBuzzApi.Models;

namespace CustomFizzBuzzApi.Interfaces;

public interface ICustomFizzBuzzService
{
    CustomFizzBuzzResponseDTO GenerateCustomFizzBuzzOutput(CustomFizzBuzzRequestDTO request);
}