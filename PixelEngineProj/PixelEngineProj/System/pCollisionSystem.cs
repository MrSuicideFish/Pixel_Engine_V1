using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelEngine;
using SFML;
using SFML.Window; //remove?
using SFML.Graphics;

namespace PixelEngine.System
{
    /// <summary>
    /// This class handles all quadtree initiation and updating.
    /// </summary>
    class pCollisionSystem : pSystemService
    {
        /// <summary>
        /// PUBLIC
        /// </summary>

        /// <summary>
        /// PRIVATE
        /// </summary>
        QuadTreeSystem QUAD_TREE;

        public pCollisionSystem( )
        {
            //Get all "collideable" actors in the scene
            QUAD_TREE.visualizeTree = ( byte )0; //don't visualize tree
        }

        public override void Update( )
        {
            //Update the quad tree elements
            base.Update( );
        }

        public override void Begin( )
        {
            //Init the quad tree system
            QUAD_TREE = new QuadTreeSystem( );
            base.Begin( );
        }
    }

    class QuadTreeSystem
    {
        readonly Int16 treeSize;
        readonly byte[] branches;
        public byte visualizeTree { get; set; }

        Dictionary<int, int> treeLookupTable = new Dictionary<int, int>( );

        public QuadTreeSystem( )
        {
            treeSize = 0;
            branches = new byte[ 1 ]{
                branches[0] = (byte)1
            };
        }

        /// <summary>
        /// This shouldn't exit with '1'
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public int AddObjectToTree( QuadTreeObject _obj )
        {
            if ( _obj != null )
            {
                return 0;
            }
            return 1;
        }

        private void ReconstructBranch( )
        {

        }

        private void ReconstructTree( )
        {

        }
    }

    class QuadTreeObject
    {
        double width, height;
        Vector2f position;
    }
}