   M S B A M L   `   `   `  ����H  DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:UserInterface.WindowsUserInterface.Windows  5   	   ?$clr-namespace:UserInterface.ChartsUCUserInterface.ChartsUC  5   	       UserInterface.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:UserInterface.Windows     5   	   9ChartsUC$clr-namespace:UserInterface.ChartsUC     5   	   -   5          �Name$
  Main��5   	    � Title$ 
MainWindow��5	   	   $	��800��6   $
��1500��6)    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 20��6   ��5   
   �� 5       �� 
StartPoint$	 0,2&�6"    �� EndPoint$	 0,0&�63   .��5      � 	 � Color$	 #00008b��6   
 � Offset$
 0Q�6/   � 5      $	 Black��6   $	
 0.8Q�6-   5      ._�5   
   �  � RowDefinitions 5      �� 5      $��80 �6    6.   �� 5      6"   �� 5      6"   �� 5       $��30 �6    6.    � ColumnDefinitions 5#      �� 5$      $	��350 �6#   61   �� 5%      6%   .+�5(      �� $��Center=�6   $��Center=�66   .+�5)      �� $��PRODUCTIVITY TOOL MANAGER��6   $��22(�6=   
�������5,      �� 5.      $/��)A TOOL YOU CAN USE TO TRACK YOUR BUSINESS��6   $��14(�5/      $��Center=�6*   $��Light"�50      
�������51      52      �� 54      $��1��6   
�������$��0 0 1 0q�66   ._�55      �� .+�56      �� $��AngularGaugeChart��6    $��16(�69   $��Center=�57      
�������$��0 40 0 0q�59      5:      �� 5<      $)��#Track tasks done by year objective!��6    $��12(�5=      $��Center=�6*   $��Light"�5>      
�������$��0 0 0 10q�5?      5@      1   +UserInterface.ChartsUC.AngularGaugeChartsUC  5A      $��Center=�64   5B      5C      �� 5E      $��2��6   
�������$��0 0 1 0q�66   ._�5F      �� $��2��6   .+�5G      �� $��PieChart��6    $��16(�60   $��Center=�5H      
�������$��0 10 0 0q�5J      5K      �� 5M      $!��Track efficience and tasks!��6    $��12(�5N      $��Center=�6*   $��Light"�5O      
�������5P      (   "UserInterface.ChartsUC.PieChartsUC  5Q      $��Center=�6+   $��0 2 0 0q�5R   +   5S      5T      �� 5V      $��5��6   $��	0 10 10 0q�6)   .+�5W      �  5X      �� 5Y      6-   �� 5Z      $��0.05* �6+   6;   .+�5]      �� -   5         ��Name$ 
exitButton��5^      $��1��5]      $��Right=�6-   $��Center=�5_         ButtonsHover#��[  5`      .��5a      �� $5��/C:\ProductivityToolManager\Images\closeIcon.png��6    $��40��5b   !   5c      5d      �� 5f      $��0��6   $��Right=�6-   $��Center=�5g      #��[  5h      .��5i      �� $8��2C:\ProductivityToolManager\Images\settingsIcon.png��6    $��40��5j       5k      5l      5m      5n      �� 5p      $��1��6   $��1��6)   $��2��66   .+�5q      �  5r      �� 5s      $��2* �6+   68   �� 5t      6-    5w      �� 5x      $	��100 �6(   67   �� 5y      6*   .+�5|      �� $��0��6!   .+�5}      �  5~      �� 5   "   65   �� 5�   "   65   .+�5�      � -   5         �Name$ checkBoxDadWrapPanel��5�   (   $��0��6F   $��20q�5�   (   5�      �� 5�      $��1��6)   $��0 20 0 0q�69   .+�5�   "   �  5�   &   �� 5�   *   $
��1.5* �6;   6J   �� 5�   *   6=   .+�5�   &   �� -   5         ��Name$ topComboBox��5�   B   $��1��5�   /   $��60��6?   $��30��6J   $��Center=�5�   '   $��Center=�5�   '   $
��Left=�6K   $��14(�5�   /   5�   '   �� 5�   &   $��NUMBER OF COLLABORATORS��60   
�������$��Right=�5�   0   $��0 0 10 0q�6L   $��Center=�5�   0   $��14(�6K   5�   '   5�   #   5�      5�      5�      � 5�      -   5        $ cardsDadWrapPanel��5�       $��20 0 0 0q�5�       $��0��62   $��1��6B   5�      5�      5�      �� 5�      $g��aThis sample was created to show advanced programation code techniques and dinamyc user interface!��6   
�������$��3��5�   +   $��5��68   $��Center=�5�      67   5�      5�      5�      