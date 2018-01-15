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
    /// Ui action for processing OnBeginDrag / OnDrag / OnEndDrag events.
    /// </summary>
    public sealed class EcsUiDragAction : EcsUiActionBase, IBeginDragHandler, IDragHandler, IEndDragHandler {
        int _beginDragEventId = -1;

        int _dragEventId = -1;

        int _endDragEventId = -1;

        void IBeginDragHandler.OnBeginDrag (PointerEventData eventData) {
            if ((object) Emitter != null) {
                if (_beginDragEventId == -1) {
                    _beginDragEventId = Emitter.GetComponentIndex<EcsUiBeginDragEvent> ();
                }
                var msg = Emitter.CreateMessage<EcsUiBeginDragEvent> (_beginDragEventId);
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
                msg.PointerId = eventData.pointerId;
            }
        }

        void IDragHandler.OnDrag (PointerEventData eventData) {
            if ((object) Emitter != null) {
                if (_dragEventId == -1) {
                    _dragEventId = Emitter.GetComponentIndex<EcsUiDragEvent> ();
                }
                var msg = Emitter.CreateMessage<EcsUiDragEvent> (_dragEventId);
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
                msg.Delta = eventData.delta;
            }
        }

        void IEndDragHandler.OnEndDrag (PointerEventData eventData) {
            if ((object) Emitter != null) {
                if (_endDragEventId == -1) {
                    _endDragEventId = Emitter.GetComponentIndex<EcsUiEndDragEvent> ();
                }
                var msg = Emitter.CreateMessage<EcsUiEndDragEvent> (_endDragEventId);
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
            }
        }
    }
}