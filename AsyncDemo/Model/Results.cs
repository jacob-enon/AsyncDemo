using AsyncDemo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncDemo.Model
{
    public class Results
    {
        private readonly Database db;
        private readonly List<string> content;

        public Results()
        {
            db = new Database();
            content = new List<string>()
            {
                "a",
                "abc",
                "abcde"
            };
        }

        public IEnumerable<int> GetResults()
        {
            var output = new List<int>();

            foreach (var item in content)
            {
                output.Add(db.GetContents(item));
            }

            return output;
        }

        public async Task<IEnumerable<int>> GetResultsAsync()
        {
            var results = new List<int>();

            foreach (var item in content)
            {
                results.Add(await Task.Run(() => db.GetContents(item)));
            }

            return results;
        }

        public async Task<IEnumerable<int>> GetResultsParallelAsync()
        {
            var tasks = new List<Task<int>>();

            foreach (var item in content)
            {
                tasks.Add(Task.Run(() => db.GetContents(item)));
            }

            return await Task.WhenAll(tasks);
        }
    }
}