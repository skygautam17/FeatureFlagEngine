
using MediatR;
using System;

public record UpdateFeatureCommand(Guid Id, string Key, string Description, bool Enabled) : IRequest<bool>;
