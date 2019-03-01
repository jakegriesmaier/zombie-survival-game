using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS.Entities
{
    public class EntityManager
    {
        public List<Entity> entities;

        public EntityManager()
        {
            entities = new List<Entity>();
        }

    }
}
