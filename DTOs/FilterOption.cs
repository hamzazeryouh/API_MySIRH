using API_MySIRH.Enums;

namespace API_MySIRH.DTOs
{
   

        /// <summary>
        /// a class that defines the filter option to get the data as paged list
        /// </summary>
        public class FilterOption
        {

            /// <summary>
            /// the index of the page to retrieve
            /// </summary>
            public int Page { get; set; }

            /// <summary>
            /// size of the page, how many records to include
            /// </summary>
            public int PageSize { get; set; }

            /// <summary>
            /// the sort direction : Descending or Ascending
            /// </summary>
            public SortDirection SortDirection { get; set; }

            /// <summary>
            /// what property to order by with it
            /// </summary>
            public string OrderBy { get; set; }
        }
    public class ListFilterOption
    {
        public ListFilterOption()
        {

        }
    }


}

