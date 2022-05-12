using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStage.ECS
{
    public struct Entity
    {
        public int Id;
    }

    public class World
    {
        public List<Entity> Entities;

        private Entity _nextEntity = new Entity() { Id = 0 };

        public World()
        {
            Entities = new List<Entity>();
        }

        public Entity AddEntity()
        {
            _nextEntity.Id++;
            while(Alive(_nextEntity))
                _nextEntity.Id++;
            Entities.Add(_nextEntity);
            return _nextEntity;

        }

        public bool Alive(Entity e)
        {
            return Entities.Contains(e);
        }

        public void Destroy(Entity e)
        {
            Entities.Remove(e);
        }
    }
}
