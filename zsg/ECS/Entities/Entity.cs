using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Components;

namespace zsg.ECS.Entities
{
    public abstract class Entity
    {

        protected Dictionary<Constants.ECSTypes.ComponentType, IComponent> components;
        protected EntityId id;
        protected Constants.ECSTypes.EntityType entityType;

        /// <summary>
        /// returns the unique id for the entity
        /// </summary>
        /// <returns>unique entity id</returns>
        public EntityId GetEntityId()
        {
            return id;
        }

        /// <summary>
        /// returns the type of the entity (used to match textures with an entity)
        /// </summary>
        /// <returns>the type of the entity</returns>
        public Constants.ECSTypes.EntityType GetEntityType()
        {
            return entityType;
        }

        /// <summary>
        /// retrieves a list of components that are on the entity
        /// </summary>
        /// <returns>components on the entity</returns>
        public Dictionary<Constants.ECSTypes.ComponentType,IComponent> GetComponents()
        {
            return components;
        }

        /// <summary>
        /// updated the entire list of components on the entity
        /// </summary>
        /// <param name="components">new list of components for the entity</param>
        public void UpdateComponents(Dictionary<Constants.ECSTypes.ComponentType,IComponent> components)
        {
            this.components = components;
        }

        /// <summary>
        /// updated a specific component on the entity or if it is not present, adds a new component to the list 
        /// </summary>
        /// <param name="component">component to be adde or updated</param>
        /// <param name="type">type of the component being added or updated (for quick lookuup)</param>
        public void UpdateComponent(IComponent component, Constants.ECSTypes.ComponentType type)
        {
            if (components.ContainsKey(type))
            {
                components[type] = component;
            }
            else
            {
                components.Add(type,component);
            }
        }

        protected abstract Dictionary<Constants.ECSTypes.ComponentType, Components.IComponent> AddMyComponents();

    }
}
