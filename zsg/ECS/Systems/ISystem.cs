using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Entities;

namespace zsg.ECS.Systems
{
    public interface ISystem
    {
        
        /// <summary>
        /// executes changes to the components of entites
        /// </summary>
        /// <param name="entities">entities to be changed</param>
        /// <returns>list of changed entites</returns>
        List<Entity> ExecuteSystem(List<Entity> entities, GameTime gameTime);

        /// <summary>
        /// returns a list of the required component types the system
        /// </summary>
        /// <returns>list of the required component types</returns>
        List<Constants.ECSTypes.ComponentType> GetRequiredComponentTypes(); 

    }
}
