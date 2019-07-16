using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BACommerce.Models.Data.Context
{
    public class ProjectContext:DbContext
    {
    
    }

public ProjectContext()
    {
        //Integrated Security=true
        Database.Connection.ConnectionString = @"Server=DESKTOP-N00BKHH\MERT;Database=AccountDB;uid=sa;pwd=123";

    }

}