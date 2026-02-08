
using MediatR;
using FeatureFlagEngine.Domain.Entities;

public record CreateFeatureCommand(string Key, string Description, bool Enabled) : IRequest<FeatureFlag>;
