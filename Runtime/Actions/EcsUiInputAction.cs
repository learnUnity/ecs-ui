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
    /// Ui action for processing InputField events.
    /// </summary>
    [RequireComponent (typeof (InputField))]
    public sealed class EcsUiInputAction : EcsUiActionBase {
        InputField _input;

        int _inputChangeEventId = -1;

        int _inputEndEventId = -1;

        void Awake () {
            _input = GetComponent<InputField> ();
            _input.onValueChanged.AddListener (OnInputValueChanged);
            _input.onEndEdit.AddListener (OnInputEnded);
        }

        void OnInputValueChanged (string value) {
            if ((object) Emitter != null) {
                if (_inputChangeEventId == -1) {
                    _inputChangeEventId = Emitter.GetComponentIndex<EcsUiInputChangeEvent> ();
                }
                var msg = Emitter.CreateMessage<EcsUiInputChangeEvent> (_inputChangeEventId);
                msg.WidgetName = WidgetName;
                msg.Sender = _input;
                msg.Value = value;
            }
        }

        void OnInputEnded (string value) {
            if ((object) Emitter != null) {
                if (_inputEndEventId == -1) {
                    _inputEndEventId = Emitter.GetComponentIndex<EcsUiInputEndEvent> ();
                }
                var msg = Emitter.CreateMessage<EcsUiInputEndEvent> (_inputEndEventId);
                msg.WidgetName = WidgetName;
                msg.Sender = _input;
                msg.Value = value;
            }
        }
    }
}