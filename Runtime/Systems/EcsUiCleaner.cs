// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using LeopotamGroup.Ecs.Ui.Components;

namespace LeopotamGroup.Ecs.Ui.Systems {
    public class EcsUiCleaner : IEcsRunSystem {
        [EcsWorld]
        EcsWorld _world;

        [EcsFilterInclude (typeof (EcsUiClickEvent))]
        EcsFilter _clickEvents;

        [EcsIndex (typeof (EcsUiClickEvent))]
        int _clickEventId;

        [EcsFilterInclude (typeof (EcsUiBeginDragEvent))]
        EcsFilter _beginDragEvents;

        [EcsIndex (typeof (EcsUiBeginDragEvent))]
        int _beginDragEventId;

        [EcsFilterInclude (typeof (EcsUiDragEvent))]
        EcsFilter _dragEvents;

        [EcsIndex (typeof (EcsUiDragEvent))]
        int _dragEventId;

        [EcsFilterInclude (typeof (EcsUiEndDragEvent))]
        EcsFilter _endDragEvents;

        [EcsIndex (typeof (EcsUiEndDragEvent))]
        int _endDragEventId;

        [EcsFilterInclude (typeof (EcsUiEnterEvent))]
        EcsFilter _enterEvents;

        [EcsIndex (typeof (EcsUiEnterEvent))]
        int _enterEventId;

        [EcsFilterInclude (typeof (EcsUiExitEvent))]
        EcsFilter _exitEvents;

        [EcsIndex (typeof (EcsUiExitEvent))]
        int _exitEventId;

        [EcsFilterInclude (typeof (EcsUiInputChangeEvent))]
        EcsFilter _inputChangeEvents;

        [EcsIndex (typeof (EcsUiInputChangeEvent))]
        int _inputChangeEventId;

        [EcsFilterInclude (typeof (EcsUiInputEndEvent))]
        EcsFilter _inputEndEvents;

        [EcsIndex (typeof (EcsUiInputEndEvent))]
        int _inputEndEventId;

        [EcsFilterInclude (typeof (EcsUiScrollViewEvent))]
        EcsFilter _scrollViewEvents;

        [EcsIndex (typeof (EcsUiScrollViewEvent))]
        int _scrollViewEventId;

        EcsRunSystemType IEcsRunSystem.GetRunSystemType () {
            return EcsRunSystemType.Update;
        }

        void IEcsRunSystem.Run () {
            for (var i = _clickEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _clickEvents.Entities[i];
                _world.GetComponent<EcsUiClickEvent> (entity, _clickEventId).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _beginDragEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _beginDragEvents.Entities[i];
                _world.GetComponent<EcsUiBeginDragEvent> (entity, _beginDragEventId).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _dragEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _dragEvents.Entities[i];
                _world.GetComponent<EcsUiDragEvent> (entity, _dragEventId).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _endDragEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _endDragEvents.Entities[i];
                _world.GetComponent<EcsUiEndDragEvent> (entity, _endDragEventId).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _enterEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _enterEvents.Entities[i];
                _world.GetComponent<EcsUiEnterEvent> (entity, _enterEventId).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _exitEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _exitEvents.Entities[i];
                _world.GetComponent<EcsUiExitEvent> (entity, _exitEventId).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _inputChangeEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _inputChangeEvents.Entities[i];
                _world.GetComponent<EcsUiInputChangeEvent> (entity, _inputChangeEventId).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _inputEndEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _inputEndEvents.Entities[i];
                _world.GetComponent<EcsUiInputEndEvent> (entity, _inputEndEventId).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _scrollViewEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _scrollViewEvents.Entities[i];
                _world.GetComponent<EcsUiScrollViewEvent> (entity, _scrollViewEventId).Sender = null;
                _world.RemoveEntity (entity);
            }
        }
    }
}