using MediatR;
using FeatureFlagEngine.Domain.Entities;
using System.Collections.Generic;

public class GetAllOverridesQuery : IRequest<List<FeatureOverride>>
{
}