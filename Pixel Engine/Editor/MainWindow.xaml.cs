using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using PixelEngine;
using PixelEngine.Engine;
using XNAControl;

namespace Editor
{

    public enum OBJECT_TRANSFORM_MODE
    {
        MOVE,
        ROTATE,
        SCALE
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OBJECT_TRANSFORM_MODE TRANSFORM_MODE = OBJECT_TRANSFORM_MODE.MOVE;

        // We use a Stopwatch to track our total time for cube animation
        private Stopwatch watch = new Stopwatch( );

        private EditorGame NewGame;

        public MainWindow( )
        {
            InitializeComponent( );
            NewGame = new EditorGame( WorldViewport.Handle, "Shared" );
        }

        #region Click Events

        private void MenuItem_Click( object sender, RoutedEventArgs e )
        {

        }

        private void ExitApplication( object sender, RoutedEventArgs e )
        {
            //Exit
            Shutdown( );
        }

        #endregion

        #region VIEWPORT
        #endregion

        #region Application Methods

        private void Shutdown( )
        {
            Application.Current.Shutdown( );
        }

        #region GAMEOBJECT TRANSFORM
        public void Toggle_Transform_Mode( object sender, RoutedEventArgs e )
        {

        }

        public void Toggle_GameObject_Snap_Move( object sender, RoutedEventArgs e )
        {

        }

        public void Toggle_GameObject_Snap_Rotate( object sender, RoutedEventArgs e )
        {

        }

        public void Toggle_GameObject_Snap_Scale( object sender, RoutedEventArgs e )
        {

        }
        #endregion

        #endregion

    }
}