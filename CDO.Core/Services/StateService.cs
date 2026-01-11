using CDO.Core.Constants;
using CDO.Core.DTOs;
using CDO.Core.ErrorHandling;
using CDO.Core.Interfaces;
using CDO.Core.Models;

namespace CDO.Core.Services;

public class StateService : IStateService {
    private readonly INetworkService _network;

    public StateService(INetworkService network) {
        _network = network;
    }

    public Task<List<State>?> GetAllStatesAsync() {
        return _network.GetAsync<List<State>>(Endpoints.States);
    }

    public Task<State?> GetStateAsync(int id) {
        return _network.GetAsync<State>(Endpoints.State(id));
    }

    // -----------------------------
    // POST Methods
    // -----------------------------
    //public Task<State?> CreateStateAsync(CreateStateDTO dto) {
    //    return _network.PostAsync<CreateStateDTO, State>(Endpoints.States, dto);
    //}
    public async Task<Result<State>> CreateStateAsync(CreateStateDTO dto) {
        var result = await _network.NeoPostAsync<CreateStateDTO, State>(Endpoints.States, dto);
        if (!result.IsSuccess) return Result<State>.Fail(TranslateError(result.Error!));
        return Result<State>.Success(result.Value!);
    }

    // -----------------------------
    // PATCH Methods
    // -----------------------------
    public Task<State?> UpdateStateAsync(int id, UpdateStateDTO dto) {
        return _network.UpdateAsync<UpdateStateDTO, State>(Endpoints.State(id), dto);
    }

    // -----------------------------
    // DELETE Methods
    // -----------------------------
    public Task<bool> DeleteStateAsync(int id) {
        return _network.DeleteAsync(Endpoints.State(id));
    }

    // -----------------------------
    // Utility Methods
    // -----------------------------
    private static AppError TranslateError(AppError error) =>
        error.Kind switch {
            ErrorKind.Conflict => error with { Message = "A state with this value already exists." },
            ErrorKind.Validation => error with { Message = "Invalid data." },
            _ => error
        };
}
