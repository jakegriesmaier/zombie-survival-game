using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using zsg.ECS.Components;
using zsg.ECS.Entities;

namespace zsg.ECS.Systems
{
    public class CollisionHandlerSystem : ISystem
    {
        private List<Constants.ECSTypes.ComponentType> requiredComponents;

        public CollisionHandlerSystem()
        {
            requiredComponents = new List<Constants.ECSTypes.ComponentType> { Constants.ECSTypes.ComponentType.PhysicalStateComponent,
                                                                              Constants.ECSTypes.ComponentType.PositionComponent,
                                                                              Constants.ECSTypes.ComponentType.TextureComponent};
        }

        public List<Entity> ExecuteSystem(List<Entity> entities, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private bool IsCollision(PositionComponent pc1, TextureComponent tc1, PositionComponent pc2, TextureComponent tc2)
        {
            // gets the color data for entity1
            Color[] colorData1 = new Color[tc1.texture.Width * tc1.texture.Height];
            tc1.texture.GetData(colorData1);
            // gets the color data for entity2
            Color[] colorData2 = new Color[tc2.texture.Width * tc2.texture.Height];
            tc2.texture.GetData(colorData2);

            // creates a box of possible intersection points
            int top = (int)Math.Max(pc1.position.Y, pc2.position.Y);
            int bottom = (int)Math.Min(pc1.position.Y + tc1.texture.Height, pc2.position.Y + tc2.texture.Height);
            int right = (int)Math.Max(pc1.position.X + tc1.texture.Width, pc2.position.X + tc2.texture.Width);
            int left = (int)Math.Min(pc1.position.X, pc2.position.X);

            // iterates over the box of intersecting pixels
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color color1 = colorData1[(x - (int)pc1.position.X) + (y - (int)pc1.position.Y) * tc1.texture.Width];
                    Color color2 = colorData2[(x - (int)pc2.position.X) + (y - (int)pc2.position.Y) * tc2.texture.Width];

                    // checks if both pixels are not transparent (=0)
                    if((color1.A != 0) && (color2.A != 0))
                    {
                        return true;// there was a collision
                    }
                }
            }
                return false;
        }



        public List<Constants.ECSTypes.ComponentType> GetRequiredComponentTypes()
        {
            return requiredComponents;
        }
    }
}
