// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Systems {
    public class EcsUiEmitter : MonoBehaviour, IEcsRunSystem {
        [EcsWorld]
        EcsWorld _world;

        readonly Dictionary<int, GameObject> _actions = new Dictionary<int, GameObject> (64);

        public int GetComponentIndex<T> () where T : class {
            return _world.GetComponentIndex<T> ();
        }

        /// <summary>
        /// Creates ecs entity with T component on it.
        /// </summary>
        /// <param name="componentId">Component index. If equals to "-1" - will try to find registered type.</param>
        public T CreateMessage<T> (int componentId = -1) where T : class {
            return _world.CreateEntityWith<T> (componentId);
        }

        /// <summary>
        /// Sets link to named GameObject to use it later from code.
        /// </summary>
        /// <param name="name">Logical name.</param>
        /// <param name="go">GameObject link.</param>
        public void SetNamedObject (string name, GameObject go) {
            if (go != null && !string.IsNullOrEmpty (name)) {
                var id = name.GetHashCode ();
                if (_actions.ContainsKey (id)) {
                    throw new Exception (string.Format ("Action with \"{0}\" name already registered", name));
                }
                _actions[id] = go.gameObject;
            }
        }

        /// <summary>
        /// Gets link to named GameObject to use it later from code.
        /// </summary>
        /// <param name="name">Logical name.</param>
        public GameObject GetNamedObject (string name) {
            GameObject retVal;
            _actions.TryGetValue (name.GetHashCode (), out retVal);
            return retVal;
        }

        EcsRunSystemType IEcsRunSystem.GetRunSystemType () {
            return EcsRunSystemType.Update;
        }

        void IEcsRunSystem.Run () { }
    }
}