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
        [SerializeField]
        protected string WidgetName;

        /// <summary>
        /// Ecs entities emitter.
        /// </summary>
        [SerializeField]
        protected EcsUiEmitter Emitter;

        [SerializeField]
        bool _registerAsNamedObject;

        void Start () {
            if ((object) Emitter == null) {
                Emitter = GetComponentInParent<EcsUiEmitter> ();
            }
#if DEBUG && !ECS_PERF_TEST
            if ((object) Emitter == null) {
                Debug.LogError ("EcsUiEmitter not found in hierarchy", this);
            }
#endif
            if ((object) Emitter != null) {
                if (_registerAsNamedObject) {
                    Emitter.SetNamedObject (WidgetName, gameObject);
                }
            }
        }

        /// <summary>
        /// Helper to add ecs actions from code.
        /// </summary>
        /// <param name="go">GameObject holder.</param>
        /// <param name="widgetName">Optional logical widget name.</param>
        /// <param name="registerObject">Should this action will be registered at emitter or not. Registered actions cant be removed!</param>
        /// <param name="emitter">Optional emitter. If not provided - will be detected automatically.</param>
        public static T AddAction<T> (
            GameObject go,
            string widgetName = null,
            bool registerObject = false,
            EcsUiEmitter emitter = null) where T : EcsUiActionBase {
            var action = go.AddComponent<T> ();
            action.WidgetName = widgetName;
            action._registerAsNamedObject = registerObject;
            action.Emitter = emitter;
            return action;
        }
    }
}