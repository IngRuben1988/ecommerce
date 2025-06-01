// Services/SimulatedAuthStateService.cs
namespace ECommerceServer.Services // Ajusta el namespace a tu proyecto
{
    public class SimulatedAuthStateService
    {
        public bool IsLoggedIn { get; private set; }
        public string? Username { get; private set; }

        public event Action? OnChange;

        // Services/SimulatedAuthStateService.cs
        public void Login(string username)
        {
            IsLoggedIn = true;
            Username = username; // Asegúrate que 'username' que pasas desde Login.razor no sea null o vacío
            NotifyStateChanged();
            Console.WriteLine($"SimulatedAuthStateService: User '{Username}' logged in.");
        }

        public void Logout()
        {
            IsLoggedIn = false;
            Username = null;
            Console.WriteLine($"SimulatedAuthStateService Logout: IsLoggedIn={IsLoggedIn}. HashCode: {this.GetHashCode()}");
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            Console.WriteLine($"SimulatedAuthStateService NotifyStateChanged called. IsLoggedIn={IsLoggedIn}. HashCode: {this.GetHashCode()}");
            OnChange?.Invoke();
        }

    }
}