using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsg.ECS.Components
{
    public class TextureComponent : IComponent
    {
        public Texture2D texture;

        public TextureComponent(Texture2D texture = null)
        {
            this.texture = texture;
        }

        public Constants.ECSTypes.ComponentType GetComponentType()
        {
            return Constants.ECSTypes.ComponentType.TextureComponent;
        }
    }
}
