using HexTest.Domain.DtoModels;
using MediatR;

namespace HexTest.Application.Commands.GameField;

public record CreateFieldCommand(int Width, int Height) : IRequest<GameFieldResponseDto>;


public class CreateFieldCommandHandler() : IRequestHandler<CreateFieldCommand, GameFieldResponseDto>
{
    public Task<GameFieldResponseDto> Handle(CreateFieldCommand request, CancellationToken cancellationToken)
    {
        var result = new GameFieldResponseDto();
        
        for (var x = 0; x < request.Width; x++)
            for (var y = 0; y < request.Height; y++)
                result.GameField.Add(new Hexagon2D(new Point2D(x, y)));
            
        //db save possibly
        return Task.FromResult(result);
    }
}