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

        [EcsFilterInclude (typeof (EcsUiBeginDragEvent))]
        EcsFilter _beginDragEvents;

        [EcsFilterInclude (typeof (EcsUiDragEvent))]
        EcsFilter _dragEvents;

        [EcsFilterInclude (typeof (EcsUiEndDragEvent))]
        EcsFilter _endDragEvents;

        [EcsFilterInclude (typeof (EcsUiEnterEvent))]
        EcsFilter _enterEvents;

        [EcsFilterInclude (typeof (EcsUiExitEvent))]
        EcsFilter _exitEvents;

        [EcsFilterInclude (typeof (EcsUiInputChangeEvent))]
        EcsFilter _inputChangeEvents;

        [EcsFilterInclude (typeof (EcsUiInputEndEvent))]
        EcsFilter _inputEndEvents;

        [EcsFilterInclude (typeof (EcsUiScrollViewEvent))]
        EcsFilter _scrollViewEvents;

        EcsRunSystemType IEcsRunSystem.GetRunSystemType () {
            return EcsRunSystemType.Update;
        }

        void IEcsRunSystem.Run () {
            for (var i = _clickEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _clickEvents.Entities[i];
                _world.GetComponent<EcsUiClickEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _beginDragEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _beginDragEvents.Entities[i];
                _world.GetComponent<EcsUiBeginDragEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _dragEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _dragEvents.Entities[i];
                _world.GetComponent<EcsUiDragEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _endDragEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _endDragEvents.Entities[i];
                _world.GetComponent<EcsUiEndDragEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _enterEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _enterEvents.Entities[i];
                _world.GetComponent<EcsUiEnterEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _exitEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _exitEvents.Entities[i];
                _world.GetComponent<EcsUiExitEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _inputChangeEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _inputChangeEvents.Entities[i];
                _world.GetComponent<EcsUiInputChangeEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _inputEndEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _inputEndEvents.Entities[i];
                _world.GetComponent<EcsUiInputEndEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = _scrollViewEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _scrollViewEvents.Entities[i];
                _world.GetComponent<EcsUiScrollViewEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
        }
    }
}