using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenskiObjekat
    {
        string Table { get; }
        string InsertValues { get; }
        string UpdateValues { get; }
        string Join { get; }
        string SearchWhere(string criteria);
        string SearchId { get; }
        object ColumnId { get; }

        List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader);
    }
}
