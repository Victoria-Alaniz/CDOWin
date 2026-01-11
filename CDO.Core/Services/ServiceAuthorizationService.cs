using CDO.Core.Constants;
using CDO.Core.DTOs;
using CDO.Core.ErrorHandling;
using CDO.Core.Interfaces;
using CDO.Core.Models;

namespace CDO.Core.Services;

public class ServiceAuthorizationService : IServiceAuthorizationService {
    private readonly INetworkService _network;
    public List<ServiceAuthorization> ServiceAuthorizations { get; private set; } = new();

    public ServiceAuthorizationService(INetworkService network) {
        _network = network;
    }

    // -----------------------------
    // GET
    // -----------------------------
    public Task<List<ServiceAuthorization>?> GetAllServiceAuthorizationsAsync() {
        return _network.GetAsync<List<ServiceAuthorization>>(Endpoints.ServiceAuthorizations);
    }

    public Task<ServiceAuthorization?> GetServiceAuthorizationAsync(string id) {
        return _network.GetAsync<ServiceAuthorization>(Endpoints.ServiceAuthorization(id));
    }

    // -----------------------------
    // POST Methods
    // -----------------------------
    //public Task<ServiceAuthorization?> CreateServiceAuthorizationAsync(CreateSADTO dto) {
    //    return _network.PostAsync<CreateSADTO, ServiceAuthorization>(Endpoints.ServiceAuthorizations, dto);
    //}

    public async Task<Result<ServiceAuthorization>> CreateServiceAuthorizationAsync(CreateSADTO dto) {
        var result = await _network.NeoPostAsync<CreateSADTO, ServiceAuthorization>(Endpoints.ServiceAuthorizations, dto);
        if (!result.IsSuccess) return Result<ServiceAuthorization>.Fail(TranslateError(result.Error!));
        return Result<ServiceAuthorization>.Success(result.Value!);
    }

    // -----------------------------
    // PATCH Methods
    // -----------------------------
    public Task<ServiceAuthorization?> UpdateServiceAuthorizationAsync(string id, UpdateServiceAuthorizationDTO dto) {
        return _network.UpdateAsync<UpdateServiceAuthorizationDTO, ServiceAuthorization>(Endpoints.ServiceAuthorization(id), dto);
    }

    // -----------------------------
    // DELETE Methods
    // -----------------------------
    public Task<bool> DeleteServiceAuthorizationAsync(string id) {
        return _network.DeleteAsync(Endpoints.ServiceAuthorization(id));
    }

    // -----------------------------
    // Utility Methods
    // -----------------------------
    private static AppError TranslateError(AppError error) =>
        error.Kind switch {
            ErrorKind.Conflict => error with { Message = "An SA with this ID already exists." },
            ErrorKind.Validation => error with { Message = "Invalid data." },
            _ => error
        };
}
