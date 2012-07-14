using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTimeout.Services;

namespace WebApiTimeout.Controllers
{
    public class RandomController : ApiController
    {
        static RandomNumberService _service = new RandomNumberService();

        public async Task<IEnumerable<int>> GetRandomNumbers(int count = 5)
        {
            List<int> results = new List<int>(count);

            for (int i = 0; i < count; ++i)
                results.Add(await _service.GetRandomNumber());

            return results;
        }
    }
}
