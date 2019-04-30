using System;
namespace LFramework.Core.Module
{
    public class Event<Key,Fun,Args>:IDisposable where Fun:new()
    {
        //释放
        public void Dispose()
        {

        }
    }
}