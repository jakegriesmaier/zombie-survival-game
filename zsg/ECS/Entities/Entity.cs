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

        private Dictionary<Constants.ECSTypes.ComponentType, IComponent> components;
        private EntityId id;

        /// <summary>
        /// returns the unique id for the entity
        /// </summary>
        /// <returns>unique entity id</returns>
        EntityId GetEntityId()
        {
            return id;
        }

        /// <summary>
        /// retrieves a list of components that are on the entity
        /// </summary>
        /// <returns>components on the entity</returns>
        Dictionary<Constants.ECSTypes.ComponentType,IComponent> GetComponents()
        {
            return components;
        }

        /// <summary>
        /// updated the entire list of components on the entity
        /// </summary>
        /// <param name="components">new list of components for the entity</param>
        void UpdateComponents(Dictionary<Constants.ECSTypes.ComponentType,IComponent> components)
        {
            this.components = components;
        }

        /// <summary>
        /// updated a specific component on the entity or if it is not present, adds a new component to the list 
        /// </summary>
        /// <param name="component">component to be adde or updated</param>
        /// <param name="type">type of the component being added or updated (for quick lookuup)</param>
        void UpdateComponent(IComponent component, Constants.ECSTypes.ComponentType type)
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

    }
}
