using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models;

namespace MyMeetings.Services
{
    public class IncomeDataStore: IIncomeDataStore
    {
        public Task<Income> GetIncomeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
