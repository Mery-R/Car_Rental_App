   M S B A M L   `   `   `  ����E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Car_Rental.ViewsCar_Rental.Views  5   	   =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels  5   	   !    Car_Rental.Views.Admin_Menu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Car_Rental.Views     5   	   9	viewModel#clr-namespace:Car_Rental.ViewModels     5   	   X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	     � Title$  MainWindowView��5
   	   $	��700��6    $
��1350��6-   $	��500��5   	   $	��600��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency .  � DataContext 5      )   #Car_Rental.ViewModels.MainViewModel  5   
    � 	Resources 5       �� DataType-   'Car_Rental.ViewModels.ShowCarsViewModel(   "Car_Rental.Views.Show_Cars_Control+   %Car_Rental.ViewModels.PricesViewModel)   #Car_Rental.Views.Price_List_Control,   &Car_Rental.ViewModels.HistoryViewModel&    Car_Rental.Views.History_Control4   .Car_Rental.ViewModels.FleetManagementViewModel/	   )Car_Rental.Views.Fleet_Management_Control3
   -Car_Rental.ViewModels.UserManagementViewModel.   (Car_Rental.Views.User_Management_Control7  1Car_Rental.ViewModels.CustomerManagementViewModel2   ,Car_Rental.Views.Customer_Management_Control��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5#      *, +)(�� �     5'      *,
 +)(�� �     5+      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5         5!      �� 5#   
   "  6   .R�5$      	  5%      �� 5'   
   " 
 6   .R�5(        5)      �� 5+   
   "  6   .R�5,        5-      5.      .��50      ��  �� CornerRadius$ 10��6   $��5q�51      ��52   
   �� 53       �� 
StartPoint$	 0,0&�6"   	 �� EndPoint$		 1,1&�63   .��54      �    winBorderColor1
 � Color#
 [  6    � Offset$ 0Q�6H   � 55        winBorderColor2#
 [ 6   $	 0.5Q�6H   � 56        winBorderColor3#
 [ 6   $ 1Q�6H   57      ._�59   
   �  � ColumnDefinitions 5:      �� 5<      $	��250 �6#   �� 5>      $��* �6#   .+�5A      �� $ 	10,0,0,10��6   $��0��5B   	   ��5C      �� 5D      $	 0,0&�6*   $	 1,0.7&�6;   .��5E      �   secondaryBackColor1#
 [ 6'   $ 0Q�6T   � 5F        secondaryBackColor2#
 [ 6'   $ 1Q�6T   5G      ._�5K      �  � RowDefinitions 5L      �� 5M      $
��Auto �6(   �� 5O      $	��330 �6(   �� 5Q      $��* �6(   .+�5U      �� $��0��6!    �� Orientation$ 
Horizontal=�5V      $	��100��5W      $��
40,30,0,40q�5X      .+�5Y      �� $��/Images/3.png��6    $	��100��67   5Z      �� 5]      $��1��6!   .+�5^      	�   
menuButton#��[ 6&    
 color1
 � Tag# [ 5_   &    d� 	IsChecked$
 TrueY�5`   &   ��5a   &   �� *ShowCarViewCommand+.��5b      �� $ 
Horizontal=�6)   .+�5c   "   !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$	 Car=�6/     menuButtonIcon#��[ 6:   �� 5d   "     menuButtonText#��[ 6,   $��	Show cars��6T   5e      5f      	� 5h      #��[ 6&    
	 color2# [	 5i   &   ��5j   &   �� *PricesViewCommand+.��5k      �� $ 
Horizontal=�6)   .+�5l   "     $
 Tags=�6/   #��[ 6;   �� 5m   "   #��[ 6,   $��Prices��6T   5n      5o      	� 5q      #��[ 6&    

 color3# [
 5r   &   ��5s   &   �� *HistoryViewCommand+.��5t      �� $ 
Horizontal=�6)   .+�5u   "     $ ClockRotateLeft=�6/   #��[ 6F   �� 5v   "   #��[ 6,   $��History��6T   5w      5x      	� 5z      #��[ 6&    
 color4# [ 5{   &   ��5|   &   �� *FleetManagementViewCommand+.��5}      �� $ 
Horizontal=�6)   .+�5~   "     $ Gears=�6/   #��[ 6<   �� 5   "   #��[ 6,   $��Fleet management��6T   5�      5�      	� 5�      #��[ 6&    
 color5# [ 5�   &   ��5�   &   �� *UserManagementViewCommand+.��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ 	Briefcase=�6/   #��[ 6@   �� 5�   "   #��[ 6,   $��Users��6T   5�      5�      	� 5�      #��[ 6&    
 color6# [ 5�   &   ��5�   &   �� *CustomerManagementViewCommand+.��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ 
PeopleRoof=�6/   #��[ 6A   �� 5�   "   #��[ 6,   $��	Customers��6T   5�      5�      5�      �� 5�      $��2��6!   $ 
Horizontal=�5�   !   $��LeftToRight=�5�   !   $��Bottom=�5�   !   $��0,0,0,10q�5�   !   .+�5�      � $��2��6   $��10,10,10,10q�5�      $��Bottom=�5�       5�      �� 5�   "   $	��180 �63   �� 5�   "   $��60 �63   .+�5�      �� $ 
Horizontal=�6)   $��Bottom=�5�   !   $��0��5�   !   .+�5�   "   A� $��50��6*   $��50��66   #��[	 5�   %   $��2��5�   %   $��	10,0,10,0q�5�   %   ��5�   &   �� 5�   *    �� ImageSource$ /Images/AdminIcon.png��65   5�   #   �� 5�   "     titleColor3#��[ 5�   ,   $��
Montserrat)�5�   ,   $��17(�5�   ,   $��Center=�5�   ,    J� Opacity$	 0.8Q�5�   ,   $
��Wrap=�5�   ,   $��CharacterEllipsis=�5�   ,   $	��110��5�   ,   ��5�   ,   �� *CurrentUser.Username+5�   ,   5�      �� 5�      -   5        $��1��5�   %     
iconButton#��[ 5�   !   # [ 5�   %   .��5�   "     $ RightFromBracket=�6/     iconButtonIcon#��[ 6G   5�      5�      5�      5�      5�      �� 5�      $ 	0,10,10,0��6   $��1��6.   ��5�      �� 5�      $	 1,1&�6*   $		 0,0&�6;   .��5�      �   primaryBackColor1#
 [ 6'   $ 0Q�6R   � 5�        primaryBackColor2#
 [ 6'   $ 1Q�6R   5�      ._�5�      �  5�      �� 5�      $��35 �6(   �� 5�      $��35 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ pnlControlBar��5�   !   $��0��5�   !   $ 
Horizontal=�5�   !   $��RightToLeft=�5�   !   
������ $��0,0,5,0q�5�   !   $��35��5�   G   $��Bottom=�6S   .+�5�      �� -   5         ��Name$ btnClose��5�   !     controlButton#��[ 5�   !   # [ 5�   !   .��5�        $ Xmark=�6+     controlButtonIcon#��[ 68   5�      �� 5�      -   5        $ btnMaximize��5�   !   #��[ 5�   !   # [ 5�   !   .��5�        $ Square=�6+   #��[ 69   5�      �� 5�      -   5        $ btnMinimize��5�   !   #��[ 5�   !    
 color8# [ 5�   !   .��5�        $ WindowMinimize=�6+   $��12��6A   #��[ 6L   5�      5�      �� 5�      $��1��6!   $ 
Horizontal=�5   !   $��Center=�5  !   .+�5       $��30��5  #   $��30��5  #     titleColor2   
Foreground# [ 5  #   $��	35,0,10,0q�5  #    5  '   �� *Icon+5  #   �� 5     #��[ 5	      $��17(�5
      $��
Montserrat)�5      $��Medium"�5      $��Center=�5      ��5  $   �� *	Caption+5      5     �� 5     $��2��6J   $��25q�6W   ��6%   �� *CurrentChildView+6W   5     5     5     5!     5#     