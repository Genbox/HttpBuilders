using System.Reflection;
using Genbox.HttpBuilders.Abstracts;
using Xunit;

namespace Genbox.HttpBuilders.Tests.Builders;

public class GenericBuilderTests
{
    private static IEnumerable<IHttpHeaderBuilder> GetBuilders()
    {
        Type type = typeof(IHttpHeaderBuilder);
        Assembly assembly = type.Assembly;

        foreach (Type exportedType in assembly.GetTypes())
        {
            //Skip the type itself - we only want types that inherit from the type
            if (exportedType == type)
                continue;

            if (!type.IsAssignableFrom(exportedType))
                continue;

            if (!exportedType.IsClass)
                continue;

            if (exportedType.IsAbstract)
                continue;

            if (exportedType.IsInterface)
                continue;

            if (type.ContainsGenericParameters)
                continue;

            IHttpHeaderBuilder? builder = (IHttpHeaderBuilder?)Activator.CreateInstance(exportedType);

            if (builder == null)
                throw new InvalidOperationException("Could not create an instance of the type " + exportedType);

            yield return builder;
        }
    }

    [Fact]
    public void AllEmptyBuildersReturnNull()
    {
        foreach (IHttpHeaderBuilder builder in GetBuilders())
        {
            Assert.Null(builder.Build());
        }
    }

    [Fact]
    public void BuildTwiceReturnSame()
    {
        foreach (IHttpHeaderBuilder builder in GetBuilders())
        {
            string? first = builder.Build();
            string? second = builder.Build();

            Assert.Equal(first, second);
        }
    }

    [Fact]
    public void ResetWorks()
    {
        foreach (IHttpHeaderBuilder builder in GetBuilders())
        {
            builder.Reset();
            Assert.Null(builder.Build());
        }
    }
}