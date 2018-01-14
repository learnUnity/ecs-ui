// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using LeopotamGroup.Ecs.Ui.Systems;
using UnityEngine;

namespace LeopotamGroup.Ecs.Ui.Actions {
    /// <summary>
    /// Base class for ui action.
    /// </summary>
    public abstract class EcsUiActionBase : MonoBehaviour {
        /// <summary>
        /// Logical name for filtering widgets.
        /// </summary>
        public string WidgetName;

        /// <summary>
        /// Ecs entities emitter.
        /// </summary>
        public EcsUiEmitter Emitter;

        void OnEnable () {
            if ((object) Emitter == null) {
                Emitter = GetComponentInParent<EcsUiEmitter> ();
            }
#if DEBUG && !ECS_PERF_TEST
            if ((object) Emitter == null) {
                Debug.LogError ("EcsUiEmitter not found in hierarchy", this);
            }
#endif
        }
    }
}