using System;
namespace LFramework.Core.Module
{
    public abstract class ServiceModule<T>:Module where T:ServiceModule<T>,new()
    {
        private static T _instance=default(T);
        public static T Instance{
            get 
            {
                if (_instance==null)
                {
                    _instance=new T();
                }
                return _instance;
            }
        }
        protected void CheckSingleton()
        {
            if (_instance==null)
            {
                var exp=new Exception("ServiceModule<" + typeof(T).Name + "> 无法直接实例化，因为它是一个单例!");
                throw exp;
            }
        }
    }

}