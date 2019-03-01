using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS.EID
{
    public class EntityIdComparer : IEqualityComparer<EntityId>
    {

        public bool Equals(EntityId x, EntityId y)
        {
            return x.id == y.id;
        }

        public int GetHashCode(EntityId obj)
        {
            return obj.id.GetHashCode();
        }

    }
}
