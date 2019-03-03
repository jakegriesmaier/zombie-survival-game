using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Components;

namespace zsg.ECS.Entities
{
    public class WallEntity : Entity
    {

        public WallEntity()
        {
            this.id = new EntityId();
            this.entityType = Constants.ECSTypes.EntityType.Wall;
            this.components = AddMyComponents(); 
        }

        protected override Dictionary<Constants.ECSTypes.ComponentType, IComponent> AddMyComponents()
        {
            var res = new Dictionary<Constants.ECSTypes.ComponentType, IComponent>();

            res.Add(Constants.ECSTypes.ComponentType.PhysicalStateComponent, new PhysicalStateComponent(true));
            res.Add(Constants.ECSTypes.ComponentType.PositionComponent, new PositionComponent());
            res.Add(Constants.ECSTypes.ComponentType.TextureComponent, new TextureComponent());
            ((PositionComponent)res[Constants.ECSTypes.ComponentType.PositionComponent]).position = new Vector2(200, 200);//temp for testing

            return res; 
        }
    }
}
