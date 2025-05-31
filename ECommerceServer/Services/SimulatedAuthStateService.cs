// Services/SimulatedAuthStateService.cs
namespace ECommerceServer.Services // Ajusta el namespace a tu proyecto
{
    public class SimulatedAuthStateService
    {
        public bool IsLoggedIn { get; private set; }
        public string? Username { get; private set; }

        public event Action? OnChange;

        public void Login(string username)
        {
            IsLoggedIn = true;
            Username = username;
            NotifyStateChanged();
            Console.WriteLine($"SimulatedAuthStateService: User '{Username}' logged in.");
        }

        public void Logout()
        {
            IsLoggedIn = false;
            Username = null;
            NotifyStateChanged();
            Console.WriteLine("SimulatedAuthStateService: User logged out.");
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}