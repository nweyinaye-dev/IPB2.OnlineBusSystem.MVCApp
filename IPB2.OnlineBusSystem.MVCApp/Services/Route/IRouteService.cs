using IPB2.OnlineBusSystem.MVCApp.Common;
using IPB2.OnlineBusSystem.MVCApp.Models;

namespace IPB2.OnlineBusSystem.MVCApp.Services.Route
{
    public interface IRouteService
    {
        Task<ServiceResponse> CreateAsync(UpsertRouteRequest request);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<RouteResponse?> GetRouteByIdAsync(string id);
        Task<List<RouteComboSetModel>> GetRouteComboSet();
        Task<GetRoutesResponse> GetRoutesAsync(int pageNo, int pageSize);
        Task<ServiceResponse> UpdateAsync(UpdateRouteRequest request, string id);
        Task<ServiceResponse> UpsertAsync(UpsertRouteRequest request, string id);
    }
}