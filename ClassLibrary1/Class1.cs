using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1
{
    public class Class1 : DbContext
    {
        public Class1()
        {
            var x = new SqlConnection();
        }
    }
}
