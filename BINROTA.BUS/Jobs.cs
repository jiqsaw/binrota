using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BINROTA.DAL;
using CARETTA.COM;
using BINROTA.COM; 

namespace BINROTA.BUS
{
    public class Jobs
    {
        public static DataTable GetJobs()
        {
            return BINROTA.DAL.Jobs.LoadAll().Tables[0]; 
        }
    }
}
