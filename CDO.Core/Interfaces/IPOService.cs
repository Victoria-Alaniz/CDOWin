using CDO.Core.Models;

namespace CDO.Core.Interfaces;

public interface IPOService {

    // -----------------------------
    // Service Initialization Tasks
    // -----------------------------
    public Task InitializeAsync();

    // -----------------------------
    // GET Methods
    // -----------------------------
    public Task<List<PO>?> GetAllPOsAsync();

    public Task<PO?> GetPOAsync(string id);

    // -----------------------------
    // POST Methods
    // -----------------------------

    // -----------------------------
    // PATCH Methods
    // -----------------------------

    // -----------------------------
    // DELETE Methods
    // -----------------------------
}
