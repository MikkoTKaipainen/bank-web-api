using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;
using BankWepApi.Repositories;

namespace BankWepApi.Services
{
    public class BankService : IBankService
    {

        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public Bank CreateBank(Bank bank)
        {
            return _bankRepository.CreateBank(bank);
        }

        public Bank DeleteBank(int id)
        {
            var bank = _bankRepository.ReadBank(id);
            return _bankRepository.DeleteBank(bank);
        }

        public List<Bank> ReadBank(string name)
        {
            return _bankRepository.ReadBank(name);
        }

        public Bank ReadBank(int id)
        {
            return _bankRepository.ReadBank(id);
        }

        public List<Bank> ReadBanks()
        {
            return _bankRepository.ReadBanks();
        }

        public Bank UpdateBank(Bank bank, int id)
        {
            return _bankRepository.UpdateBank(bank,);
        }
    }
}
