
using MediatR;
using FeatureFlagEngine.Domain.Entities;
using System.Collections.Generic;
public record GetAllFeaturesQuery() : IRequest<List<FeatureFlag>>;
