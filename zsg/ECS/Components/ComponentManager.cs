using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS.Components
{
    public class ComponentManager
    {
        private List<IComponent> components;

        public ComponentManager()
        {
            components = new List<IComponent>();
        }

    }
}
