namespace APICQRS.Filters
{
    public class PaginationFilter
    {
       public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 7;
        }

        //representa el numero de pagina actual
        public int PageNumber { get; set; }
        //Representa el total de registros o filas por pagina que se mostraran
        public int PageSize { get; set; }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 7 ? 7 : pageSize;
        }
    }
}
