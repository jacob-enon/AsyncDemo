using System.Threading;

namespace AsyncDemo.Data
{
    public class Database
    {
        public int GetContents(string entry)
        {
            Thread.Sleep(2000);
            return entry.Length;
        }
    }
}