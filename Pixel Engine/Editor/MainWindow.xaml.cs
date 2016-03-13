using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dragablz;
using Dragablz.Core;
using Dragablz.Dockablz;
using Dragablz.Themes;
using Dragablz.Converters;

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

        public MainWindow( )
        {
            InitializeComponent( );
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