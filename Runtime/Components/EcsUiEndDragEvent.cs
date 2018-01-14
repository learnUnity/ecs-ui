// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2018 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine.EventSystems;

namespace LeopotamGroup.Ecs.Ui.Components {
    public sealed class EcsUiEndDragEvent {
        public string WidgetName;

        public int PointerId;

        public RaycastResult HitResult;
    }
}