using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiTimeout.Services
{
    public class RandomNumberService
    {
        private Random _random = new Random();

        public async Task<int> GetRandomNumber(CancellationToken token)
        {
            await Task.Delay(1000, token);
            return _random.Next();
        }
    }
}
