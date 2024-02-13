namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services
{
    public static class ServiceLocator
    {
        public static void RegisterService<T>(T service) where T : IService =>
            Implementation<T>.Instance = service;
        
        public static void UnregisterService<T>() where T : IService => 
            Implementation<T>.Instance = default;
        
        public static T Get<T>() where T : IService =>
            Implementation<T>.Instance;
        
        private static class Implementation<T> where T : IService
        {
            public static T Instance;
        }
    }
}