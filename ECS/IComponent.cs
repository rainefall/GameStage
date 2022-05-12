using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStage.ECS
{
    public interface IComponent
    {
        public int entity { get; }
    }
}
