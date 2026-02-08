using MediatR;

public class EvaluateFeatureQuery : IRequest<bool>
{
    public string FeatureKey { get; set; }
    public string UserId { get; set; }
    public string GroupId { get; set; }
    public string Region { get; set; }
}