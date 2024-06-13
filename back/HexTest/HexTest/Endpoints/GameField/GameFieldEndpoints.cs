using HexTest.Application.Commands.GameField;
using HexTest.Endpoints.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static HexTest.Endpoints.GameField.GameFieldRequests;

namespace HexTest.Endpoints.GameField;

public class GameFieldEndpoints : IEndpoints
{
    
    public static void DefineEndPoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("game");

        group.MapPost("create",
            async ([FromBody] CreateFieldCommand request, IMediator sender) => await sender.Send(request));
        
    }

   
}