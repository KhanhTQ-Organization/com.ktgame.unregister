using System;

namespace com.ktgame.unregister
{
    public class UnRegister : IUnRegister
    {
        private Action _onUnRegister;

        public UnRegister(Action onUnRegister)
        {
            _onUnRegister = onUnRegister;
        }

        void IUnRegister.UnRegister()
        {
            _onUnRegister?.Invoke();
            _onUnRegister = null;
        }
    }
}