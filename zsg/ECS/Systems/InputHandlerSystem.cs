using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<IEntity> ExecuteSystem(List<IEntity> entities)
        {
            throw new NotImplementedException();
        }

        public List<Constants.ECSTypes.ComponentType> GetRequiredComponentTypes()
        {
            return requiredComponents;
        }
    }
}
