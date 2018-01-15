// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using LeopotamGroup.Ecs.Ui.Components;
using UnityEngine;
using UnityEngine.UI;

namespace LeopotamGroup.Ecs.Ui.Actions {
    /// <summary>
    /// Ui action for processing ScrollView events.
    /// </summary>
    [RequireComponent (typeof (ScrollRect))]
    public sealed class EcsUiScrollViewAction : EcsUiActionBase {
        ScrollRect _scrollView;

        int _scrollViewEventId = -1;

        void Awake () {
            _scrollView = GetComponent<ScrollRect> ();
            _scrollView.onValueChanged.AddListener (OnScrollViewValueChanged);
        }

        void OnScrollViewValueChanged (Vector2 value) {
            if ((object) Emitter != null) {
                if (_scrollViewEventId == -1) {
                    _scrollViewEventId = Emitter.GetComponentIndex<EcsUiScrollViewEvent> ();
                }
                var msg = Emitter.CreateMessage<EcsUiScrollViewEvent> (_scrollViewEventId);
                msg.WidgetName = WidgetName;
                msg.Sender = _scrollView;
                msg.Value = value;
            }
        }
    }
}