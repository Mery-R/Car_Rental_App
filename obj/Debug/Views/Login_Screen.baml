   M S B A M L   `   `   `  ����E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Car_Rental
Car_Rental  5   	   E'clr-namespace:Car_Rental.CustomControlsCar_Rental.CustomControls  5   	   =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels  5   	       Car_Rental.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Car_Rental     5   	   Bcustomcontrols'clr-namespace:Car_Rental.CustomControls     5   	   9	viewModel#clr-namespace:Car_Rental.ViewModels     5   	   -   5        
������   � AllowsTransparency  .  � WindowStyle$
 None=�5   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5      *   $Car_Rental.ViewModels.LoginViewModel  5   
    � 	Resources 5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'    �� 	Converter# [  65   .��5      � $	��200��6   $	��300��6   .+�5   
   ��  �� CornerRadius$ 10��6   $��5q�6#   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5       $ 
BlueViolet��6#    � Offset$	 1.5Q�66   5!      ��5$      �� 5%      $		 1,1&�6&   $	
 0,0&�65   .��5&      � $ Violet��6#   $	 0.2Q�62   � 5'      $
 Blue��6#   $ 1Q�60   5(      5*      �� 5,   
   $ 10��6   $��5q�6#    J� Opacity$	 0.5Q�67   ��5-      �� 5.       �� ImageSource$ /Images/background.jpg��6   50      � 52   
    � RowDefinitions 53      �� 54      $��30 �6    �� 55      $��* �6    .+�58      �  � ColumnDefinitions 59      �� 5:      $��* �6'   �� 5;      $��25 �6'   �� 5<      $��25 �6'   �� 5=      $��5 �6'   .+�5@      �� $��0��6   $��Log In��6,   $��15(�6:   $��Center=�6H   $��10,0,0,0q�6c   
�������6u   �� 5B      -   5         ��Name$ Button_Minimize��5B      $��1��62   $��-��6B   $��16(�6l   
���   �$��0q�6�   $��0,5,0,0q�6�   ��5C      �� 5D       �� 
TargetType" ��6    .�5E      ��  �� Property � �� �� Value
 �����6;    �� Triggers 5F      P� 5G   "    P� Property �@J�IsMouseOver P� Value . . �5H   &   ��  � ��
 �����6C   5I   #   5K      ��5N      �� 5O       �� 
TargetType" ��6*   .R�5P      �� $��18��6%   $��18��60   #��z��6<   $ 9��6f   ._�5Q   "   �� $��Center=�63   $��Center=�6N    � Cursor$ Arrow��6k   $��0,-5,0,0q�6z   5R      5S      5U      �� 5W      -   5        $ Button_Close��5W      $��2��6/   $��16(�6Z   
���   �$��0,5,5,0q�6{   $��x��6�   $��1,1,1,1q�6�   $ Arrow��6�    J� RenderTransformOrigin$ 0.5,0&�6�   ��5X      �� 5Y      " ��6    .�5Z      ��  � ��
 �����6;    5[      P� 5\   "    �@J�IsMouseOver . . �5]   &   ��  � ��
 �����6C   5^   #   5`      ��5c      �� 5d      " ��6*   .R�5e      �� $��18��6%   $��18��60   #��z��6<   $ 9��6f   ._�5f   "   �� $��Center=�63   $��Center=�6N   $ Arrow��6k   $��0,-5,0,0q�6z   5g      5h      5j      5l      �� 5n      $	��250��6   $��2��6%    �� Orientation$ Vertical=�62   $��	0,-60,0,0q�6I   $��Center=�6\   $��Center=�6y   .+�5o      �� $��/Images/3.png��6   $	��150��6/   $	��150��6;   �� 5p      $��Welcome to Car Rental��6   $��	0,-20,0,0q�69   $��20(�6L   $
��Bold"�6Z   
�������$��30��6�   $��Center=�6�   �� 5q      $��Username��6   $��14(�6,   
�������6:   �� 5s      -   5         ��Name$ Username��5s      $��25,0,0,0q�6k   $��14(�6~   $��0,0,0,1q�6�   
�������
�������$��Center=�6�    �� TextWrapping$
 Wrap=�6�   $	��250��6�   $��25��6	  $��0,5,0,0q�6  ��6,   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.��6&  ��5t      �� 5u      $ /Images/user_icon.png��6%    j� Stretch$
 None=�6I     j� 
AlignmentX$
  Left=�6X   .��5v   *   5w      �� 5y      $��Password��6   $��0,5,0,0q�6,   $��14(�6=   
�������6K   3   -Car_Rental.CustomControls.BindablePasswordBox  5{      $��25��6�   $��0,5,0,0q�6�   !   Password! 65   �� *
Password+$ TwoWay=�$ PropertyChanged=�6�   �� 5}      $��Center=�6:   $��0,10,0,0q�6W   $��12(�6i   
���  ��$
��Wrap=�6�   ��6   �� *ErrorMessage+6�   �� 5      -   5        $ Login��5      $��LOG IN��6I   $��Center=�6Z   $��0,10,0,0q�6w   $��35��6�   $	��150��6�   $��20(�6�   $
��Bold"�6�   
�������
�������" �� 	IsDefault" . ��6(   �� *LoginCommand+��6�   Z� 6  5�      5�      5�      5�      