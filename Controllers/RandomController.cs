using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTimeout.Services;

namespace WebApiTimeout.Controllers
{
    public class RandomController : ApiController
    {
        static RandomNumberService _service = new RandomNumberService();

        public async Task<IEnumerable<int>> GetRandomNumbers(CancellationToken token, int count = 5)
        {
            List<Task<int>> resultTasks = new List<Task<int>>(count);

            for (int i = 0; i < count; ++i)
                resultTasks.Add(_service.GetRandomNumber(token));

            await Task.WhenAll(resultTasks.ToArray());

            IEnumerable<int> results = resultTasks.Select(task => task.Result);
            return results;
        }
    }
}
