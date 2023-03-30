using APICQRS.Filters;

namespace APICQRS.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
