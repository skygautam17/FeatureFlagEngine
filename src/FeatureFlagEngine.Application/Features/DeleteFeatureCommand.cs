
using MediatR;
using System;
public record DeleteFeatureCommand(Guid Id) : IRequest<bool>;
