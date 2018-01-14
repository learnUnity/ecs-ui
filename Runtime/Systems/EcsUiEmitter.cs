// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Systems {
    public class EcsUiEmitter : MonoBehaviour, IEcsRunSystem {
        [EcsWorld]
        EcsWorld _world;

        public T CreateMessage<T> () where T : class {
            return _world.AddComponent<T> (_world.CreateEntity ());
        }

        EcsRunSystemType IEcsRunSystem.GetRunSystemType () {
            return EcsRunSystemType.Update;
        }

        void IEcsRunSystem.Run () { }
    }
}