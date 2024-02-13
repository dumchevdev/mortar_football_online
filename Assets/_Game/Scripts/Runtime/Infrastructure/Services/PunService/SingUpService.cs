using System;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService
{
    public class SingUpService : IService
    {
        public event Action<string> OnSignUp;

        private readonly PunService _punService;

        public SingUpService(PunService punService)
        {
            _punService = punService;
        }

        public void SignUp(string name)
        {
            _punService.SetUserInfo(name);
            OnSignUp?.Invoke(name);
        }
    }
}