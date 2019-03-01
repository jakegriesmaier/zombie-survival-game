using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS.Components
{
    public class VelocityComponent : IComponent
    {
        public float velocity;

        public VelocityComponent()
        {
            velocity = 0f;
        }

        public Constants.ECSTypes.ComponentType GetComponentType()
        {
            return Constants.ECSTypes.ComponentType.VelocityComponent;
        }
    }
}
