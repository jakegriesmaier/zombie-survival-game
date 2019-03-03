using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg
{
    public static class Constants
    {
        public static class ECSTypes
        {
            public enum ComponentType
            {
                TextureComponent,
                PositionComponent,
                VelocityComponent,
                HealthComponent,
                PhysicalStateComponent
            }

            public enum EntityType
            {
                Player,
                Wall
            }

        }


    }
}
