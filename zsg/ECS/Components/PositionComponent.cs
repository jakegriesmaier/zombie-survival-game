using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS.Components
{
    public class PositionComponent : IComponent
    {
        public Vector2 position;


        public PositionComponent()
        {
            position = new Vector2();
        }

        public Constants.ECSTypes.ComponentType GetComponentType()
        {
            return Constants.ECSTypes.ComponentType.PositionComponent;
        }
    }
}
