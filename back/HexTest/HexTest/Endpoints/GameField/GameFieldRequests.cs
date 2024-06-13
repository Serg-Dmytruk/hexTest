using HexTest.Application.Commands.GameField;
using Microsoft.AspNetCore.Mvc;

namespace HexTest.Endpoints.GameField;

public static  class GameFieldRequests
{
    public record GameFieldRequest([FromBody] CreateFieldCommand Command);
}