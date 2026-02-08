using MediatR;
using System;

public class DeleteOverrideCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}