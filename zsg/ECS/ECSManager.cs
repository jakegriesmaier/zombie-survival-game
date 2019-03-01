using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Entities;
using zsg.ECS.Systems;

namespace zsg.ECS
{
    public class ECSManager
    {
        EntityManager entityManager;
        SystemManager systemManager;

        public ECSManager()
        {
            this.entityManager = new EntityManager();
            this.systemManager = new SystemManager();
        }

        /// <summary>
        /// retrieves any entities from memory and loads them into the intity manager
        /// </summary>
        public void Initialize()
        {
            List<Entity> initialized = new List<Entity>();
            entityManager.entities = initialized;
        }

        /// <summary>
        /// adds the textures to the entities/components
        /// </summary>
        /// <param name="textures">Textures associated with entities</param>
        public void LoadContent(List<Texture2D> textures)
        {
            throw new NotImplementedException();
        }

        public void UnloadContent()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            entityManager.entities = systemManager.ExecuteSystems(entityManager.entities, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            systemManager.Draw(entityManager.entities, spriteBatch);
        }


    }
}
