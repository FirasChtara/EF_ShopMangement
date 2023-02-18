namespace ShopManagement.API.Exercices
{
    public class SingletonExample
    {
        //lock --> Try > monitor.enter / finally -> monitor.exist

        private static object threadSafe = new object();

        private static SingletonExample? instance;
        public static SingletonExample Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (threadSafe)
                    {
                        if (instance == null)
                          instance = new SingletonExample();
                    }
                }
                return instance;
            }
        } 
        private SingletonExample()
        {

        }
    }
}
