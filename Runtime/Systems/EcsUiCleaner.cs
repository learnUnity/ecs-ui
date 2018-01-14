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

        EcsRunSystemType IEcsRunSystem.GetRunSystemType () {
            return EcsRunSystemType.Update;
        }

        void IEcsRunSystem.Run () {
            for (var i = _clickEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _clickEvents.Entities[i];
                _world.GetComponent<EcsUiClickEvent> (entity, _clickEventId).HitResult.Clear ();
                _world.RemoveEntity (entity);
            }
            for (var i = _beginDragEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _beginDragEvents.Entities[i];
                _world.GetComponent<EcsUiBeginDragEvent> (entity, _beginDragEventId).HitResult.Clear ();
                _world.RemoveEntity (entity);
            }
            for (var i = _dragEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _dragEvents.Entities[i];
                _world.GetComponent<EcsUiDragEvent> (entity, _dragEventId).HitResult.Clear ();
                _world.RemoveEntity (entity);
            }
            for (var i = _endDragEvents.Entities.Count - 1; i >= 0; i--) {
                var entity = _endDragEvents.Entities[i];
                _world.GetComponent<EcsUiEndDragEvent> (entity, _endDragEventId).HitResult.Clear ();
                _world.RemoveEntity (entity);
            }
        }
    }
}