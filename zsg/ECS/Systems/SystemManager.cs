using Microsoft.Xna.Framework;
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
            res.Add(new InputHandlerSystem());
            res.Add(new CollisionHandlerSystem());

            return res;
        }

        /// <summary>
        /// updates the components on entities and returns the updataed entities
        /// </summary>
        /// <param name="entities">list of entities to be updated with game logic</param>
        /// <returns>entities that have been updated by the systems</returns>
        public List<Entity> ExecuteSystems(List<Entity> entities, GameTime gameTime)
        {
            List<Entity> valid;// entities that contain the required components
            List<Entity> invalid;// entities that do not contain the required components
            List<Constants.ECSTypes.ComponentType> requiredComponents;

            foreach (ISystem sys in systems)
            {               
                valid = new List<Entity>();             
                invalid = new List<Entity>();
                requiredComponents = sys.GetRequiredComponentTypes();

                foreach(Entity e in entities)
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
                valid = sys.ExecuteSystem(valid, gameTime);
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
        private bool HasRequiredComponents(List<Constants.ECSTypes.ComponentType> required, Entity entity)
        {
            foreach(var req in required)
            {
                if (!entity.GetComponents().ContainsKey(req))
                {
                    //does not have one of the required components
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
        public void Draw(List<Entity> entities, SpriteBatch spriteBatch)
        {
            TextureComponent tc;
            PositionComponent pc;
            Vector2 vec;
            foreach(var e in entities)
            {
                if (HasRequiredComponents(drawComponents, e))
                {
                    tc = (TextureComponent)e.GetComponents()[Constants.ECSTypes.ComponentType.TextureComponent];
                    pc = (PositionComponent)e.GetComponents()[Constants.ECSTypes.ComponentType.PositionComponent];
                    spriteBatch.Draw(tc.texture, pc.position, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
                }
            }
        }

    }
}
