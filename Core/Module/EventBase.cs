using System;
using System.Collections.Generic;
using LFramework.Core.Common;

namespace LFramework.Core.Module
{
    public class EventBase<Key, Fun, Args> : Singleton<EventBase<Key, Fun, Args>>, IDisposable where Fun : new()
    {
        /// <summary>
        /// 释放事件
        /// </summary>
        public void Dispose()
        {

        }
        public delegate void OnActionHandler(Args args);
        protected Dictionary<Key, List<OnActionHandler>> dic = new Dictionary<Key, List<OnActionHandler>>();
        /// <summary>
        /// 添加监听
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void AddEventListener(Key key, OnActionHandler handler)
        {
            if (dic.ContainsKey(key))
            {
                dic[key].Add(handler);
            }
            else
            {
                List<OnActionHandler> handlers = new List<OnActionHandler>();
                handlers.Add(handler);
                dic[key] = handlers;
            }
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void RemoveEventListener(Key key, OnActionHandler handler = null)
        {
            if (dic.ContainsKey(key))
            {
                if (dic[key].Count == 0 || handler == null)
                {
                    dic.Remove(key);
                    return;
                }
                dic[key].Remove(handler);
            }
        }
        /// <summary>
        /// 派发事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="args"></param>
        public virtual void Dispatch(Key key, Args args)
        {
            if (dic.ContainsKey(key))
            {
                List<OnActionHandler> lstHandler = dic[key];
                if (lstHandler != null && lstHandler.Count > 0)
                {
                    for (int i = 0; i < lstHandler.Count; i++)
                    {
                        if (lstHandler[i] != null)
                        {
                            lstHandler[i](args);
                        }
                    }
                }
            }
        }
    }
}