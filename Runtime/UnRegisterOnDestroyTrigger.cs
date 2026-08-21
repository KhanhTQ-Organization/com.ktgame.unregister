using System.Collections.Generic;
using UnityEngine;

namespace com.ktgame.unregister
{
    public class UnRegisterOnDestroyTrigger : MonoBehaviour
    {
        private readonly List<IUnRegister> _unRegisters = new List<IUnRegister>();

        public void AddUnRegister(IUnRegister unRegister)
        {
            _unRegisters.Add(unRegister);
        }

        public void RemoveUnRegister(IUnRegister unRegister)
        {
            _unRegisters.Remove(unRegister);
        }

        private void OnDestroy()
        {
            for (int i = _unRegisters.Count - 1; i >= 0; i--)
            {
                _unRegisters[i].UnRegister();
            }

            _unRegisters.Clear();
        }
    }
}