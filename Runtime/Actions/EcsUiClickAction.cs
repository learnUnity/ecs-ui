// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LeopotamGroup.Ecs.Ui.Actions {
    /// <summary>
    /// Ui action for processing OnClick events.
    /// </summary>
    public sealed class EcsUiClickAction : EcsUiActionBase, IPointerClickHandler {
        [Range (1f, 2048f)]
        public float DragTreshold = 5f;

        int _clickEventId = -1;

        void IPointerClickHandler.OnPointerClick (PointerEventData eventData) {
            if ((eventData.pressPosition - eventData.position).sqrMagnitude < DragTreshold * DragTreshold) {
                if ((object) Emitter != null) {
                    if (_clickEventId == -1) {
                        _clickEventId = Emitter.GetComponentIndex<EcsUiClickEvent> ();
                    }
                    var msg = Emitter.CreateMessage<EcsUiClickEvent> (_clickEventId);
                    msg.WidgetName = WidgetName;
                    msg.Sender = gameObject;
                }
            }
        }
    }
}