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
    /// Ui action for processing OnDrag events.
    /// </summary>
    public sealed class EcsUiDragAction : EcsUiActionBase, IBeginDragHandler, IDragHandler, IEndDragHandler {
        void IBeginDragHandler.OnBeginDrag (PointerEventData eventData) {
            if ((object) Emitter != null) {
                var msg = Emitter.CreateMessage<EcsUiBeginDragEvent> ();
                msg.WidgetName = WidgetName;
                msg.HitResult = eventData.pointerCurrentRaycast;
                msg.PointerId = eventData.pointerId;
            }
        }

        void IDragHandler.OnDrag (PointerEventData eventData) {
            if ((object) Emitter != null) {
                var msg = Emitter.CreateMessage<EcsUiDragEvent> ();
                msg.WidgetName = WidgetName;
                msg.HitResult = eventData.pointerCurrentRaycast;
                msg.PointerId = eventData.pointerId;
            }
        }

        void IEndDragHandler.OnEndDrag (PointerEventData eventData) {
            if ((object) Emitter != null) {
                var msg = Emitter.CreateMessage<EcsUiEndDragEvent> ();
                msg.WidgetName = WidgetName;
                msg.HitResult = eventData.pointerCurrentRaycast;
                msg.PointerId = eventData.pointerId;
            }
        }
    }
}