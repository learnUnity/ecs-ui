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

        void IEcsRunSystem.Run () {
            int entity;

            for (var i = 0; i < _clickEvents.EntitiesCount; i++) {
                entity = _clickEvents.Entities[i];
                _world.GetComponent<EcsUiClickEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = 0; i < _beginDragEvents.EntitiesCount; i++) {
                entity = _beginDragEvents.Entities[i];
                _world.GetComponent<EcsUiBeginDragEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = 0; i < _dragEvents.EntitiesCount; i++) {
                entity = _dragEvents.Entities[i];
                _world.GetComponent<EcsUiDragEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = 0; i < _endDragEvents.EntitiesCount; i++) {
                entity = _endDragEvents.Entities[i];
                _world.GetComponent<EcsUiEndDragEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = 0; i < _enterEvents.EntitiesCount; i++) {
                entity = _enterEvents.Entities[i];
                _world.GetComponent<EcsUiEnterEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = 0; i < _exitEvents.EntitiesCount; i++) {
                entity = _exitEvents.Entities[i];
                _world.GetComponent<EcsUiExitEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = 0; i < _inputChangeEvents.EntitiesCount; i++) {
                entity = _inputChangeEvents.Entities[i];
                _world.GetComponent<EcsUiInputChangeEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = 0; i < _inputEndEvents.EntitiesCount; i++) {
                entity = _inputEndEvents.Entities[i];
                _world.GetComponent<EcsUiInputEndEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
            for (var i = 0; i < _scrollViewEvents.EntitiesCount; i++) {
                entity = _scrollViewEvents.Entities[i];
                _world.GetComponent<EcsUiScrollViewEvent> (entity).Sender = null;
                _world.RemoveEntity (entity);
            }
        }
    }
}