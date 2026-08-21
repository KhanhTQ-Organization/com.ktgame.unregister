using UnityEngine;

namespace com.ktgame.unregister
{
    public static class UnRegisterExtension
    {
        public static IUnRegister UnRegisterWhenGameObjectDestroyed(this IUnRegister unRegister, GameObject gameObject)
        {
            var trigger = gameObject.GetComponent<UnRegisterOnDestroyTrigger>();

            if (!trigger)
            {
                trigger = gameObject.AddComponent<UnRegisterOnDestroyTrigger>();
            }

            trigger.AddUnRegister(unRegister);
            return unRegister;
        }

        public static System.IDisposable DisposeWhenGameObjectDestroyed(this System.IDisposable disposable, GameObject gameObject)
        {
            var trigger = gameObject.GetComponent<UnRegisterOnDestroyTrigger>();

            if (!trigger)
            {
                trigger = gameObject.AddComponent<UnRegisterOnDestroyTrigger>();
            }

            trigger.AddUnRegister(new UnRegister(disposable.Dispose));
            return disposable;
        }

        public static IUnRegister UnRegisterWhenGameObjectDestroyed(this IUnRegister unRegister, Component component)
        {
            return unRegister.UnRegisterWhenGameObjectDestroyed(component.gameObject);
        }

        public static System.IDisposable DisposeWhenGameObjectDestroyed(this System.IDisposable disposable, Component component)
        {
            return disposable.DisposeWhenGameObjectDestroyed(component.gameObject);
        }
    }
}