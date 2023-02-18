using ShopManagement.API.Models;

namespace ShopManagement.API.Exercices
{
    public class ExampleDisposble : IDisposable
    {
        private bool disposed = false;

        private ShopEFContext _shopEFContext = new ShopEFContext();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        StreamReader st;

        void DoSomething()
        {
            var orders = _shopEFContext.Orders.ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Nettoie les ressources gérées
                    _shopEFContext.Dispose();
                }

                // Nettoie les ressources non gérées

                disposed = true;
            }
        }

        ~ExampleDisposble()
        {
            Dispose(false);
        }
    }
}
