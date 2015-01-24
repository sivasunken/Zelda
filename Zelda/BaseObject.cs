﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zelda
{
    class BaseObject
    {
        private readonly List<Component> _components;

        public int Id { get; set; }

        public BaseObject()
        {
            _components = new List<Component>();
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _components.Find(c => c.ComponentType == componentType) as TComponentType;
        }

        public void AddComponent(Component component)
        {
            _components.Add(component);
            component.Initialize(this);
        }

        public void AddComponent(List<Component> components)
        {
            _components.AddRange(components);
            foreach (var component in components)
                component.Initialize(this);
        }

        public void RemoveComponent(Component component)
        {
            _components.Remove(component);
        }

        public void Update(double gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
                component.Draw(spriteBatch);
        }
    }
}
