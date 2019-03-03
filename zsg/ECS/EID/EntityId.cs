using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS
{
    public class EntityId
    {
        private static int previousId = 0;
        public int id { get; private set; }

        public EntityId(int id = -1)
        {
            if(id == -1)
            {
                previousId++;
                id = previousId;
            }
            this.id = id;//TEMPORARY FOR TESTING: need to check the global id counter
        }

    }
}
