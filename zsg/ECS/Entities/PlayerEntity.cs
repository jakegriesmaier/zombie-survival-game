using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Components;

namespace zsg.ECS.Entities
{
    public class PlayerEntity : Entity
    {

        public PlayerEntity()
        {
            this.id = new EntityId();
            this.entityType = Constants.ECSTypes.EntityType.Player;
            this.components = AddMyComponents();

        }

        private Dictionary<Constants.ECSTypes.ComponentType, Components.IComponent> AddMyComponents()
        {
            var res = new Dictionary<Constants.ECSTypes.ComponentType, Components.IComponent>();

            res.Add(Constants.ECSTypes.ComponentType.HealthComponent, new HealthComponent());
            res.Add(Constants.ECSTypes.ComponentType.PositionComponent, new PositionComponent());
            res.Add(Constants.ECSTypes.ComponentType.TextureComponent, new TextureComponent());
            res.Add(Constants.ECSTypes.ComponentType.VelocityComponent, new VelocityComponent());
            ((VelocityComponent)res[Constants.ECSTypes.ComponentType.VelocityComponent]).velocity = 100f;//temp for testing
            ((PositionComponent)res[Constants.ECSTypes.ComponentType.PositionComponent]).position = new Vector2(50,50);//temp for testing

            return res;
        }
    }
}
