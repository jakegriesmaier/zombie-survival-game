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
        /// executes changes to the components of entites (RETURNS ALL OF THE ENTITIES IN THE SYSTEM EVEN IF THEY ARE NOT CHANGED)
        /// </summary>
        /// <param name="entities">entities to be changed</param>
        /// <returns>list of changed entites</returns>
        List<IEntity> ExecuteSystem(List<IEntity> entities);

        /// <summary>
        /// returns a list of the required component types the system
        /// </summary>
        /// <returns>list of the required component types</returns>
        List<Constants.ECSTypes.ComponentType> GetRequiredComponentTypes(); 

    }
}
