using System.Text.Json;
using System.Text.Json.Serialization;
using Refit;
using StarSystems.Shared;
using StarSystems.Shared.Apis;

namespace StarSystems.Client.Providers;

public class RefitProvider
{
    /// <summary>
    /// Initialize Refit and AutoMapper in Dependency injection.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="url"></param>
    public static void AddRefitInterfaces(IServiceCollection services, Uri url)
    {
        services.AddAutoMapper(typeof(Mappings));

        var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        serializerOptions.PropertyNameCaseInsensitive = true;
        serializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        serializerOptions.Converters.Add(new ObjectToInferredTypesConverter());
        serializerOptions.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: false));

        var serializer = new SystemTextJsonContentSerializer(serializerOptions);

        var refitSettings = new RefitSettings()
        {
            ContentSerializer = serializer
        };


        var apiUrl = url;

        services.AddRefitClient<ISpaceObjectController>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = apiUrl);

        services.AddRefitClient<IStarSystemController>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = apiUrl);
    }
}