using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS.Components
{
    public class HealthComponent : IComponent
    {
        public int health;
        public int maxHealth;

        public HealthComponent()
        {
            health = 100;
            maxHealth = 100;
        }

        public Constants.ECSTypes.ComponentType GetComponentType()
        {
            return Constants.ECSTypes.ComponentType.HealthComponent;
        }
    }
}
