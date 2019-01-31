using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Services
{
    public interface IBankService
    {
        Bank CreateBank(Bank bank);
        List<Bank> ReadBanks();
        List<Bank> ReadBank(string name);
        Bank ReadBank(int id);
        Bank UpdateBank(Bank bank, int id);
        Bank DeleteBank(Bank bank, int id);
    }
}
