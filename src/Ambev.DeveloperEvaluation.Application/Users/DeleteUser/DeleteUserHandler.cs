using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

/// <summary>
/// Handler for processing DeleteUserCommand requests
/// </summary>
public class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    /// <summary>
    /// Handles the DeleteUserCommand request
    /// </summary>
    /// <param name="request">The DeleteUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        { 
            throw new ValidationException(validationResult.Errors);
        }

        var result = await userRepository.DeleteAsync(request.Id, cancellationToken);
        var message = null as string;
        if (!result)
        {
            message = $"User with ID {request.Id} not found";
        }
        return new DeleteUserResponse { Success = result, Error = message };
    }
}
