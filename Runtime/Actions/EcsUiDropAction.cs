// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine.EventSystems;

namespace LeopotamGroup.Ecs.Ui.Actions {
    /// <summary>
    /// Ui action for processing OnDrop events.
    /// </summary>
    public sealed class EcsUiDropAction : EcsUiActionBase, IDropHandler {
        int _dropEventId = -1;

        void IDropHandler.OnDrop (PointerEventData eventData) {
            if ((object) Emitter != null) {
                if (_dropEventId == -1) {
                    _dropEventId = Emitter.GetComponentIndex<EcsUiDropEvent> ();
                }
                var msg = Emitter.CreateMessage<EcsUiDropEvent> (_dropEventId);
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
            }
        }
    }
}