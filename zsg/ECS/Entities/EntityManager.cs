using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Components;

namespace zsg.ECS.Entities
{
    public class EntityManager
    {
        public List<Entity> entities;

        public EntityManager()
        {
            entities = new List<Entity>();
            entities.Add(new PlayerEntity());//temp added for testing
            entities.Add(new WallEntity());//temp added for testing
        }

        public void LoadTextures(List<Texture2D> textures)
        {
            foreach(var e in entities)
            {
                if (e.GetComponents().ContainsKey(Constants.ECSTypes.ComponentType.TextureComponent))
                {
                    TextureComponent tc = (TextureComponent)e.GetComponents()[Constants.ECSTypes.ComponentType.TextureComponent];
                    tc.texture = textures.First(t => t.Name == e.GetEntityType().ToString());
                    e.UpdateComponent(tc, Constants.ECSTypes.ComponentType.TextureComponent);
                }
            }
        }

    }
}
