// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using Leopotam.Ecs.Ui.Components;

namespace Leopotam.Ecs.Ui.Systems {
#if !LEOECS_DISABLE_INJECT
    [EcsInject]
#endif
    public class EcsUiCleaner : IEcsRunSystem {
        EcsWorld _world = null;

        EcsFilter<EcsUiClickEvent> _clickEvents = null;

        EcsFilter<EcsUiBeginDragEvent> _beginDragEvents = null;

        EcsFilter<EcsUiDragEvent> _dragEvents = null;

        EcsFilter<EcsUiEndDragEvent> _endDragEvents = null;

        EcsFilter<EcsUiEnterEvent> _enterEvents = null;

        EcsFilter<EcsUiExitEvent> _exitEvents = null;

        EcsFilter<EcsUiInputChangeEvent> _inputChangeEvents = null;

        EcsFilter<EcsUiInputEndEvent> _inputEndEvents = null;

        EcsFilter<EcsUiScrollViewEvent> _scrollViewEvents = null;

#if LEOECS_DISABLE_INJECT
        /// <summary>
        /// Sets EcsWorld instance.
        /// </summary>
        /// <param name="world">Instance.</param>
        public EcsUiCleaner SetWorld (EcsWorld world) {
            _world = world;
            ValidateEcsFields ();
            _clickEvents = _world.GetFilter<EcsFilter<EcsUiClickEvent>> ();
            _beginDragEvents = _world.GetFilter<EcsFilter<EcsUiBeginDragEvent>> ();
            _dragEvents = _world.GetFilter<EcsFilter<EcsUiDragEvent>> ();
            _endDragEvents = _world.GetFilter<EcsFilter<EcsUiEndDragEvent>> ();
            _enterEvents = _world.GetFilter<EcsFilter<EcsUiEnterEvent>> ();
            _exitEvents = _world.GetFilter<EcsFilter<EcsUiExitEvent>> ();
            _inputChangeEvents = _world.GetFilter<EcsFilter<EcsUiInputChangeEvent>> ();
            _inputEndEvents = _world.GetFilter<EcsFilter<EcsUiInputEndEvent>> ();
            _scrollViewEvents = _world.GetFilter<EcsFilter<EcsUiScrollViewEvent>> ();
            return this;
        }
#endif

        void IEcsRunSystem.Run () {
            ValidateEcsFields ();
            for (var i = 0; i < _clickEvents.EntitiesCount; i++) {
                _clickEvents.Components1[i].Sender = null;
                _world.RemoveEntity (_clickEvents.Entities[i]);
            }
            for (var i = 0; i < _beginDragEvents.EntitiesCount; i++) {
                _beginDragEvents.Components1[i].Sender = null;
                _world.RemoveEntity (_beginDragEvents.Entities[i]);
            }
            for (var i = 0; i < _dragEvents.EntitiesCount; i++) {
                _dragEvents.Components1[i].Sender = null;
                _world.RemoveEntity (_dragEvents.Entities[i]);
            }
            for (var i = 0; i < _endDragEvents.EntitiesCount; i++) {
                _endDragEvents.Components1[i].Sender = null;
                _world.RemoveEntity (_endDragEvents.Entities[i]);
            }
            for (var i = 0; i < _enterEvents.EntitiesCount; i++) {
                _enterEvents.Components1[i].Sender = null;
                _world.RemoveEntity (_enterEvents.Entities[i]);
            }
            for (var i = 0; i < _exitEvents.EntitiesCount; i++) {
                _exitEvents.Components1[i].Sender = null;
                _world.RemoveEntity (_exitEvents.Entities[i]);
            }
            for (var i = 0; i < _inputChangeEvents.EntitiesCount; i++) {
                _inputChangeEvents.Components1[i].Sender = null;
                _world.RemoveEntity (_inputChangeEvents.Entities[i]);
            }
            for (var i = 0; i < _inputEndEvents.EntitiesCount; i++) {
                _inputEndEvents.Components1[i].Sender = null;
                _world.RemoveEntity (_inputEndEvents.Entities[i]);
            }
            for (var i = 0; i < _scrollViewEvents.EntitiesCount; i++) {
                _scrollViewEvents.Components1[i].Sender = null;
                _world.RemoveEntity (_scrollViewEvents.Entities[i]);
            }
        }

        [System.Diagnostics.Conditional ("DEBUG")]
        void ValidateEcsFields () {
            if (_world == null) {
                throw new System.Exception ("[EcsUiCleaner] Call SetWorld() method first with valid world instance.");
            }
        }
    }
}