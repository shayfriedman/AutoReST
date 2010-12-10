namespace AutoRestRoute
{
    public interface IUrlGenerator
    {
        string GenerateUrl(ActionInfo actionInfo);
    }
}