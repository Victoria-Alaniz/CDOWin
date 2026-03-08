using CDO.Core.DTOs.SAs;
using CDO.Core.ErrorHandling;

namespace CDO.Core.Interfaces;

public interface IServiceAuthorizationService {

    // -----------------------------
    // GET Methods
    // -----------------------------
    public Task<List<SASummary>?> GetAllServiceAuthorizationsAsync();

    public Task<SADetail?> GetServiceAuthorizationAsync(int id);

    // -----------------------------
    // POST Methods
    // -----------------------------
    public Task<Result<SADetail>> CreateServiceAuthorizationAsync(NewSA dto);

    // -----------------------------
    // PATCH Methods
    // -----------------------------
    public Task<Result> UpdateServiceAuthorizationAsync(int id, SAUpdate dto);

    // -----------------------------
    // DELETE Methods
    // -----------------------------
    public Task<Result> DeleteServiceAuthorizationAsync(int id);

}
