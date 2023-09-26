using FactoryPattern.Samples;

namespace FactoryPattern.Factories;

public static class GenerateClassWithDataFactoryExtension
{
    //AddGenericClassWithDataFactory
    public static void AddGenericClassWhithFactory(this IServiceCollection services)
    {
        services.AddTransient<IUserData, UserData>();
        services.AddSingleton<Func<IUserData>>(x => () => x.GetService<IUserData>()!);
        services.AddSingleton<IUserDataFactory, UserDataFactory>();
    }

}

public interface IUserDataFactory
{
    IUserData Crete(string name);
}

public class UserDataFactory : IUserDataFactory
{
    private readonly Func<IUserData> _factory;

    public UserDataFactory(Func<IUserData> factory)
    {
        _factory = factory;
    }

    public IUserData Crete(string name)
    {
        var output = _factory();
        output.Name = name;
        return output;
    }
}