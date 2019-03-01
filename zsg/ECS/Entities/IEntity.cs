using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Components;

namespace zsg.ECS.Entities
{
    public interface IEntity
    {

        EntityId GetEntityId();
        List<IComponent> GetComponents();
        void UpdateComponents(List<IComponent> components);

    }
}
