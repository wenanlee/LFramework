namespace LFramework.Core.Common
{
    /// <summary>
    /// 单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> where T:Singleton<T>,new()
    {
        private static T _instance = default(T);
        public static T Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new T();
                    _instance.InitSingleton();
                }
                return _instance;
            }
        }

        private void InitSingleton()
        {
            
        }
    }
}
