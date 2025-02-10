namespace MyFirstApplication.Extensions
{
    public static class Extensions
    {
        public static (List<T>, int) Pagify<T>(this List<T> list, int pageNumber, int pageSize)
        {
            var totalPages = (int)Math.Ceiling((double)(list.Count / pageSize));
            var paginatedListOfShows = list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return (paginatedListOfShows, totalPages);
        }
    }
}