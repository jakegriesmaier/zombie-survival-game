﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Components;
using zsg.ECS.Entities;

namespace zsg.ECS.Systems
{
    public class SystemManager
    {
        List<ISystem> systems;
        List<Constants.ECSTypes.ComponentType> drawComponents;

        public SystemManager()
        {
            this.systems = addSystems();
            this.drawComponents = new List<Constants.ECSTypes.ComponentType> {
                                                                              Constants.ECSTypes.ComponentType.PositionComponent,
                                                                              Constants.ECSTypes.ComponentType.TextureComponent
                                                                              };

        }

        private List<ISystem> addSystems()
        {
            List<ISystem> res = new List<ISystem>();

            //TODO add systems here

            return res;
        }

        /// <summary>
        /// updates the components on entities and returns the updataed entities
        /// </summary>
        /// <param name="entities">list of entities to be updated with game logic</param>
        /// <returns>entities that have been updated by the systems</returns>
        public List<IEntity> ExecuteSystems(List<IEntity> entities)
        {
            List<IEntity> valid;// entities that contain the required components
            List<IEntity> invalid;// entities that do not contain the required components
            List<Constants.ECSTypes.ComponentType> requiredComponents;

            foreach (ISystem sys in systems)
            {               
                valid = new List<IEntity>();             
                invalid = new List<IEntity>();
                requiredComponents = sys.GetRequiredComponentTypes();

                foreach(IEntity e in entities)
                {
                    if (HasRequiredComponents(requiredComponents, e))
                    {
                        valid.Add(e);
                    }
                    else
                    {
                        invalid.Add(e);
                    }
                }
                valid = sys.ExecuteSystem(valid);
                entities = invalid.Concat(valid).ToList();
            }

            return entities;
        }

        /// <summary>
        /// checks to see if the entity has the components 
        /// </summary>
        /// <param name="required">components that are being checked on entity</param>
        /// <param name="entity">entity that the components are being checked on</param>
        /// <returns>true if entity contains all of teh components in required</returns>
        private bool HasRequiredComponents(List<Constants.ECSTypes.ComponentType> required, IEntity entity)
        {
            foreach(var req in required)
            {
                if(!entity.GetComponents().Any(c => c.GetType() == req.GetType()))
                {
                    //does not contain the required component
                    return false; 
                }
            }
            return true;
        }

        /// <summary>
        /// draws the entities passed in that contain the required components
        /// </summary>
        /// <param name="entities">list of entities to draw to the screen</param>
        /// <param name="spriteBatch">draws the entites to the game screen</param>
        public void Draw(List<IEntity> entities, SpriteBatch spriteBatch)
        {
            TextureComponent tc;
            PositionComponent pc;
            Vector2 vec;
            foreach(var e in entities)
            {
                if (HasRequiredComponents(drawComponents, e))
                {
                    tc = (TextureComponent) e.GetComponents().First(c => c.GetComponentType() == Constants.ECSTypes.ComponentType.TextureComponent);
                    pc = (PositionComponent)e.GetComponents().First(c => c.GetComponentType() == Constants.ECSTypes.ComponentType.PositionComponent);
                    vec = new Vector2(tc.texture.Width / 2, tc.texture.Height / 2);
                    spriteBatch.Draw(tc.texture, pc.position, null, Color.White, 0f, vec, Vector2.One, SpriteEffects.None, 0f);
                }
            }
        }

    }
}