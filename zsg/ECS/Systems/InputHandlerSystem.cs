using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Components;
using zsg.ECS.Entities;

namespace zsg.ECS.Systems
{
    public class InputHandlerSystem : ISystem
    {
        private List<Constants.ECSTypes.ComponentType> requiredComponents;

        public InputHandlerSystem()
        {
            requiredComponents = new List<Constants.ECSTypes.ComponentType> { Constants.ECSTypes.ComponentType.PositionComponent,
                                                                              Constants.ECSTypes.ComponentType.VelocityComponent};
        }

        public List<Entity> ExecuteSystem(List<Entity> entities, GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            PositionComponent pc;
            VelocityComponent vc;

            foreach(var e in entities)
            {
                pc = (PositionComponent)e.GetComponents()[Constants.ECSTypes.ComponentType.PositionComponent];
                vc = (VelocityComponent)e.GetComponents()[Constants.ECSTypes.ComponentType.PositionComponent];

                if (kstate.IsKeyDown(Keys.Up))
                {
                    pc.position.Y -= vc.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (kstate.IsKeyDown(Keys.Down))
                {
                    pc.position.Y += vc.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (kstate.IsKeyDown(Keys.Left))
                {
                    pc.position.X -= vc.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (kstate.IsKeyDown(Keys.Right))
                {
                    pc.position.X += vc.velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                e.UpdateComponent(pc, Constants.ECSTypes.ComponentType.PositionComponent);
                e.UpdateComponent(vc, Constants.ECSTypes.ComponentType.VelocityComponent);
            }

            return entities;
        }

        public List<Constants.ECSTypes.ComponentType> GetRequiredComponentTypes()
        {
            return requiredComponents;
        }
    }
}
