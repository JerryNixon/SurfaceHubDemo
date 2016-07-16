using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp.Services
{
    public class DataService
    {
        public async Task<IEnumerable<Models.Restaurant>> GetReataurantsAsync()
        {
            await Task.CompletedTask;
            return Enumerable.Range(1, 10).Select(x => new Models.Restaurant(x) { Name = Guid.NewGuid().ToString() });
        }
    }
}
