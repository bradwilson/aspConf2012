using System;
using System.Threading.Tasks;

namespace WebApiTimeout.Services
{
    public class RandomNumberService
    {
        private Random _random = new Random();

        public async Task<int> GetRandomNumber()
        {
            await Task.Delay(1000);
            return _random.Next();
        }
    }
}
