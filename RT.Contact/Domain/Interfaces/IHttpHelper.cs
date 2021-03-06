using System.Threading;
using System.Threading.Tasks;

namespace RT.Contacts.Domain.Interfaces
{
    public interface IHttpHelper<T>
    {
        Task<T> GetSingleItemRequest(string apiUrl, CancellationToken token = default(CancellationToken));
        Task<T[]> GetMultipleItemsRequest(string apiUrl, CancellationToken token = default(CancellationToken));
        Task<T> PostRequest(string apiUrl, T postObject, CancellationToken token = default(CancellationToken));
        Task PutRequest(string apiUrl, T putObject, CancellationToken token = default(CancellationToken));
        Task DeleteRequest(string apiUrl, CancellationToken token = default(CancellationToken));
    }
}
