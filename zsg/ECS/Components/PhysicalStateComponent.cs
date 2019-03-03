using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS.Components
{
    public class PhysicalStateComponent : IComponent
    {
        public bool solid;

        public PhysicalStateComponent(bool solid = false)
        {
            this.solid = solid;
        }

        public Constants.ECSTypes.ComponentType GetComponentType()
        {
            return Constants.ECSTypes.ComponentType.PhysicalStateComponent;
        }
    }
}
