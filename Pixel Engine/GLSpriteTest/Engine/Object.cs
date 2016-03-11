using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLSpriteTest.Engine
{
    public abstract class Object
    {
        public readonly int m_InstanceId;

        public Object( )
        {
            Random _rand = new Random( );
            m_InstanceId = _rand.Next( 1000, 99999 );
        }

        public static void Destroy( )
        {
            
        }
    }
}
