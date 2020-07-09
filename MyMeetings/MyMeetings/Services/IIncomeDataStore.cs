using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models;

namespace MyMeetings.Services
{
    public interface IIncomeDataStore
    {
        Task<Income> GetIncomeAsync();
    }
}
