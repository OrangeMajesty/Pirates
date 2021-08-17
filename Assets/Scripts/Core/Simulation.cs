using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public static partial class Simulation
    {
        private static HeapQueue<Event> _eventQueue = new HeapQueue<Event>();
        private static Dictionary<System.Type, Stack<Event>> _eventPool = new Dictionary<Type, Stack<Event>>();

        public static T New<T>() where T : Event, new()
        {
            Stack<Event> pool;

            if (!_eventPool.TryGetValue(typeof(T), out pool))
            {
                pool = new Stack<Event>(4);
                //pool.Push(new T());
                _eventPool[typeof(T)] = pool;
            }

            if (pool.Count > 0)
                return (T)pool.Pop();
            else
                return new T();
        }

        public static void Tick()
        {
            var time = Time.time;
            //var excutedEvensCount = 0;

            while (_eventQueue.Count > 0 && _eventQueue.Peek().tick <= time)
            {
                var ev = _eventQueue.Pop();
                //var tick = ev.tick;
                ev.ExecuteEvent();

                /*if (ev.tick == tick)
                {
                    ev.CleanUp();
                }
                else
                {
                    // Событие было переподписано
                }*/
            }
            //Debug.Log(_eventQueue.Count);
        }
        
        // queue
        public static T Shedule<T>(float tick = 0) where T : Event, new()
        {
            var ev = new T();
            ev.tick = Time.time + tick;
            _eventQueue.Push(ev);
            return ev;
        }
        
        // models
        public static T GetModel<T>() where T : class, new()
        {
            return InstanceRegister<T>.instance;
        }

        public static void SetModel<T>(T instance) where T : class, new()
        {
            InstanceRegister<T>.instance = instance;
        }
    }
}
