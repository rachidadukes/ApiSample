namespace VideoGameApi
{
    public interface IApiService
    {
        Task<List<ApiObject>> GetObjectsAsync();
    }

}
