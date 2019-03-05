using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zsg.ECS.Components;

namespace zsg.ECS.Entities
{
    public class TileEntity : Entity
    {
        public int locationX;//temp
        public int locationY;//temp


        public TileEntity(int locationX, int locationY)
        {
            this.locationX = locationX;//temp
            this.locationY = locationY;
            this.entityType = Constants.ECSTypes.EntityType.Tile;
            this.id = new EntityId();
            this.components = AddMyComponents();
        }

        protected override Dictionary<Constants.ECSTypes.ComponentType, IComponent> AddMyComponents()
        {
            var res = new Dictionary<Constants.ECSTypes.ComponentType, IComponent>();

            var pos = new PositionComponent();
            pos.position.X = pos.position.X + (16 * locationX);
            pos.position.Y = pos.position.Y + (16 * locationY);

            res.Add(Constants.ECSTypes.ComponentType.PositionComponent, pos);
            res.Add(Constants.ECSTypes.ComponentType.TextureComponent, new TextureComponent());
            //res.Add(Constants.ECSTypes.ComponentType.PhysicalStateComponent, new PhysicalStateComponent(false));//for collision (may take off for speed?)
            //too slow with collision detection :( need to make a change?

            return res;
        }
    }
}
