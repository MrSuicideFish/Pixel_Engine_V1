   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5
   	   A =Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EditorEditor 5   	   E AXNAControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:XNAControl;assembly=XNAControl
XNAControl 5   	      Editor.MainWindow   5   	   E ADragablz, Version=0.0.3.157, Culture=neutral, PublicKeyToken=null6dragablz'http://dragablz.net/winfx/xaml/dragablz  5   	   5tabablz'http://dragablz.net/winfx/xaml/dockablz  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5
   	   &localclr-namespace:Editor     5   	   U	 QMaterialDesignThemes.Wpf, Version=1.4.1.485, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5   	   <	integrate,clr-namespace:XNAControl;assembly=XNAControl 	 5   	      MaterialDesignBody#���   5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � Title$  
MainWindow��5   	   $	��900��6   $
��1440��6)    � WindowStartupLocation$ CenterScreen=�66    � WindowStyle$ ThreeDBorderWindow=�6[    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $C =pack://application:,,,/Dragablz;component/Themes/Generic.xaml?�6%   %    5      .��5      ]� ���	#FF7A7A7A.+�5   
   �� 
�������$��Bottom=�6'   $��Bottom=�6?   $��Stretch=�6Z   $��24��6x    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#   5       o� 5"   
   $	��Top=�6   ���	#FF5B5B5B$��0q�6;   $��30��6F   ���	#FFA0A0A0.@�5%      m� $��_File��6   $��16(�6&   $
��Bold"�64    �� TextAlignment$ Center=�6F   $��Center=�6g   $��0q�6�   $��30��6�   $��Center=�6�   ��6�   Z� .@�5&      m� $��_Preferences...��6   ���	#FF5B5B5B���	#FF5B5B5B6L   m� 5'      -   5        $��_Exit��5'      ���	#FF5B5B5B���	#FF5B5B5B6Y   5(      m� 5+      $��_Engine��6   $��16(�6(   $
��Bold"�66   $ Center=�6H   $��Center=�6i   $��0q�6�   $��30��6�   $��Center=�6�   5,      m� 5/      $��_Window��6   $��16(�6(   $
��Bold"�66   $ Center=�6H   $��Center=�6i   $��0q�6�   $��30��6�   $��Center=�6�   51      m� 54      $��_Help��6   $��16(�6&   $
��Bold"�64   $ Center=�6F   $��Center=�6g   $��0q�6�   $��30��6�   $��Center=�6�   56      57        Dragablz.TabablzControl  5:   
   $��8,0,6,5q�6"   ���	#FF616161$��2q�6J   	   ShowDefaultCloseButton	 . 
   ShowDefaultAddButton
 .  J� SnapsToDevicePixels .  ! TrapezoidDragableTabItemStyle#��[ 5;         AdjacentHeaderItemOffset$	 -10Q�5<         InterTabController 5=      !  Dragablz.InterTabController  5>      .@�5A      �� $��World Editor��6    �� 
IsSelected . .��5B      ]� ��. $��Stretch=�61   $��Stretch=�6M   $
��auto��6k   $
��auto��6x   .+�5E      �� $��55��6   $
��auto��6)    �� Padding$ 5q�66   
����������	#FFBFBFBF$��1q�6p   $	��Top=�6�   $	��Top=�6�   $��Stretch=�6�   ._�5F      � $��LeftToRight=�6    � ColumnDefinitions 5G      �� 5J   "   $
��Auto �63   �� 5K   "   $
��Auto �63   �� 5L   "   $
��Auto �63   �� 5O   "   $��20 �63   �� 5R   "   $
��Auto �63   �� 5S   "   $
��Auto �63   �� 5T   "   $
��Auto �63   �� 5W   "   $��20 �63   �� 5Z   "   $
��Auto �63   �� 5[   "   $
��Auto �63   �� 5\   "   $
��Auto �63   .+�5`      �� $��0��6%   $��0��62   $��0q�6B   $��0,0,3,0q�6N   $��40��6`   $��40��6k   .��5a   "   ' 	 !MaterialDesignThemes.Wpf.PackIcon  � 	 �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=1.4.1.485, Culture=neutral, PublicKeyToken=null]]   Kind$
 File=�6:   5b      �� 5d      $��0��6%   $��1��62   $��0q�6B   $��0,0,3,0q�6N   $��40��6`   $��40��6k   .��5e   "     $ Folder=�6:   5f      �� 5h      $��0��6%   $��2��62   $��0q�6B   $��3,0,0,0q�6N   $��40��6_   $��40��6j   .��5i   "     $ Floppy=�6:   5j      �� 5m      -   5        $��0��5m   %   $��4��62   $��0q�6B   $��3,0,0,0q�6N   $��40��6_   $��40��6j   .��5n   "     $ 
CursorMove=�6:   5o      �� 5q      $��0��6%   $��5��62   $��0q�6B   $��3,0,0,0q�6N   $��40��6_   $��40��6j   .��5r   "     $ Rotate3d=�6:   5s      �� 5u      $��0��6%   $��6��62   $��0q�6B   $��3,0,0,0q�6N   $��40��6_   $��40��6j   .��5v   "     $ ArrowExpand=�6:   5w      �� 5z      $��0��6%   $��8��62   $��0q�6B   $��3,0,0,0q�6N   $��40��6_   $��40��6j   .��5{   "   � .+�5|   &     $ CropFree=�6>   $��0q�6N   $��0q�6Z   $��30��6e   $��30��6p     5}   &   $ 
CursorMove=�6>   $��0q�6P   $��0q�6\   $��Center=�6g   $��Center=�6�   5~   #   5      �� 5�      $��0��6%   $��9��62   $��0q�6B   $��3,0,0,0q�6N   $��40��6_   $��40��6j   .��5�   "   � .+�5�   &     $ CropFree=�6>   $��0q�6N   $��0q�6Z   $��30��6e   $��30��6p     5�   &   $ Rotate3d=�6>   $��0q�6N   $��0q�6Z   $��Center=�6e   $��Center=�6�   5�   #   5�      �� 5�      $��0��6%   $��10��62   $��0q�6C   $��3,0,0,0q�6O   $��40��6`   $��40��6k   .��5�   "   � .+�5�   &     $ CropFree=�6>   $��0q�6N   $��0q�6Z   $��30��6e   $��30��6p     5�   &   $ ArrowExpand=�6>   $��0q�6Q   $��0q�6]   $��Center=�6h   $��Center=�6�   5�   #   5�      5�      5�        5�      $��8,0,6,5q�6.   
�������$��2q�6R   $	��200��6^   ��.    FixedHeaderCount$ 0��6�   #��[ 5�   .   	 . .@�5�      �� $��	Heirarchy��6    J� 	AllowDrop .  . ���	#FFA0A0A0.��5�      ]� ��. $��Stretch=�69   $��Stretch=�6U   $
��auto��6s   $
��auto��6�   5�      5�      5�        5�      $��8,0,6,5q�6.   
�������$��2q�6R   $	��200��6^   ��. $ 0��6�   $��Right=�6�   #��[ 5�   .   	 .  5�        5�        Dragablz.Dockablz.Layout   FloatingItemState$ 	Maximized=�6;   .@�5�      �� $��	Inspector��6"    .  . ���	#FFA0A0A0.��5�      ]� ��. $��Stretch=�6=   $��Stretch=�6Y   $
��auto��6w   $
��auto��6�   5�      5�      5�        XNAControl.UserControl1  5�      -   5          Name$ EditorViewport��5�   -   
�������$
��auto��6X   $
��auto��6e   6s   5�      5�      �� 5�      $��Sheet Editor��6   ���	#FF6C5C5C5�      5�      5�      5�      