using FindTheNumber.Enums;

namespace FindTheNumber.DTOs;

public record GameStats
{
    public required int? LastNumber { get; init; }
    public required int UserTries { get; init; }
    public required NumberStatus NumberStatus { get; init; }
    public required GameStatus GameStatus { get; init; }
};