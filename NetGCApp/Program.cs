namespace NetGCApp
{
    class BigUser : IDisposable
    {
        List<long> users = new List<long>(1000);

        public void Dispose()
        {
            Console.WriteLine("User dispose");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GC.MaxGeneration);
            Console.WriteLine(GC.GetTotalMemory(false));
            int count = Int32.Parse(Console.ReadLine());

            using (BigUser userObj = new BigUser())
            {
                Console.WriteLine(GC.GetGeneration(userObj));

                for (int i = 0; i < count; i++)
                {
                    BigUser user = new();
                }

                Console.WriteLine(GC.GetTotalMemory(false));

                GC.Collect(1);

                Console.WriteLine(GC.GetGeneration(userObj));
            }

            
            Console.WriteLine(GC.GetTotalMemory(false));

            
        }
    }
}