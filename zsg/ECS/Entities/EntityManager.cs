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
        public List<Entity> entities;//entities in the world
        public List<TileEntity> tileMap;//world map

        public EntityManager()
        {
            entities = AddEntities();

            tileMap = GenerateMap();

        }

        private List<Entity> AddEntities()
        {
            var res = new List<Entity>();

            res.Add(new PlayerEntity());//temp added for testing
            for(int i = 0; i < 64; i++)
            {
                res.Add(new WallEntity(i));//temp added for testing
            }


            for(int x = 0; x < 50; x++)
            {
                for(int y = 0; y < 30; y++)
                {
                    res.Add(new TileEntity(x,y));
                }
            }

            return res;
        }

        private List<TileEntity> GenerateMap()
        {
            var res = new List<TileEntity>();

            //TODO add a list tiles to cover the area that needs to be rendered (tiles are 16 x 16)

            return res;
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
