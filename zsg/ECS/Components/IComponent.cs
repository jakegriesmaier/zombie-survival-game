using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS.Components
{
    public interface IComponent
    {
        Constants.ECSTypes.ComponentType GetComponentType();
    }
}
