namespace NET.App.API.CommandModels
{
    public interface ICommand<T>
    {
        string Description { get; set; }
        string Name { get; set; }
        T Parameter { get; set; }
    }
}