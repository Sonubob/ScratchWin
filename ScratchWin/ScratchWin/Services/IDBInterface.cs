using SQLite;

using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchWin.Services
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
